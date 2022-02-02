USE Bank

--1. Create Table Logs
CREATE TABLE Logs (
	LogId INT PRIMARY KEY IDENTITY NOT NULL,
	AccountId INT FOREIGN KEY REFERENCES Accounts (Id) NOT NULL,
	OldSum FLOAT NOT NULL,
	NewSum FLOAT NOT NULL
	)
	DROP TABLE Logs
GO
CREATE TRIGGER TR_AccauntSumDecrease 
ON Accounts 
AFTER UPDATE
AS
BEGIN
	INSERT INTO Logs VALUES
	((SELECT Id FROM inserted) , (SELECT Balance FROM deleted) , (SELECT Balance FROM inserted))
END

BEGIN TRANSACTION
UPDATE Accounts 
SET Balance -= 10
WHERE Id = 1
SELECT * FROM Logs
SELECT * FROM NotificationEmails
SELECT * FROM Accounts
ROLLBACK


--2. Create Table Emails
CREATE TABLE NotificationEmails (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Recipient INT FOREIGN KEY REFERENCES Accounts (Id) NOT NULL,
	[Subject] VARCHAR(100) NOT NULL,
	Body VARCHAR(100) NOT NULL
	)
CREATE TRIGGER TR_NotificationEmailsLogs
ON Logs
AFTER INSERT
AS
BEGIN
	INSERT INTO NotificationEmails VALUES
	((SELECT AccountId FROM inserted) 
	, CONCAT('Balance change for account:' , ' ' , (SELECT AccountId FROM inserted)) 
	, CONCAT('On' , ' ' , GETDATE() , ' ' , 'your balance was changed from' , ' '  
	, (SELECT OldSum FROM inserted) , ' '  , 'to' , ' '  , (SELECT NewSum FROM inserted) , '.'))
END

--3. Deposit Money

CREATE OR ALTER PROC usp_DepositMoney (@AccountId INT, @MoneyAmount FLOAT)
AS
BEGIN
	IF (@MoneyAmount > 0)
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
	IF (@MoneyAmount <= 0) 
    SET @MoneyAmount = 0
	--SELECT A.Id AS AccountId , AH.Id AS AccountHolderId , CONVERT(DECIMAL(38 , 4) , Balance + @MoneyAmount) AS Balance
	--FROM Accounts AS A
	--JOIN AccountHolders AS AH
	--ON A.AccountHolderId = AH.Id
	--WHERE A.Id = @AccountId
END




BEGIN TRANSACTION
EXEC usp_DepositMoney 1 , 10
SELECT * FROM Accounts
ROLLBACK

--4. Withdraw Money
CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount FLOAT)
AS
BEGIN
	IF (@MoneyAmount > 0 AND @MoneyAmount <= (SELECT Balance FROM Accounts WHERE Id = @AccountId))
	BEGIN
		UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @AccountId
	END
	ELSE IF (@MoneyAmount > (SELECT Balance FROM Accounts WHERE Id = @AccountId))
	BEGIN
		UPDATE Accounts
		SET Balance = 0
		WHERE Id = @AccountId
	END
	IF (@MoneyAmount <= 0) 
    SET @MoneyAmount = 0
	--SELECT A.Id AS AccountId , AH.Id AS AccountHolderId , CONVERT(DECIMAL(38 , 4) , Balance + @MoneyAmount) AS Balance
	--FROM Accounts AS A
	--JOIN AccountHolders AS AH
	--ON A.AccountHolderId = AH.Id
	--WHERE A.Id = @AccountId
END

BEGIN TRANSACTION
EXEC usp_WithdrawMoney 1 , 10
SELECT * FROM Accounts
ROLLBACK

--5. Money Transfer
CREATE FUNCTION ufn_AccountHolderAccountId (@AccountHolderId INT)
RETURNS INT
AS
BEGIN
	RETURN
	(
	SELECT A.Id 
	FROM Accounts AS A
	JOIN AccountHolders AS AH
	ON A.AccountHolderId = AH.Id
	WHERE AH.Id = @AccountHolderId
	)
END

CREATE PROC  usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount FLOAT)
AS
BEGIN
	EXEC usp_WithdrawMoney @SenderId  , @Amount
	EXEC usp_DepositMoney @ReceiverId  , @Amount
END
EXEC usp_TransferMoney 5 , 1 , 5000
SELECT * FROM Accounts
ROLLBACK

--8. Employees with Three Projects
GO

USE SoftUni

GO

CREATE FUNCTION ufn_EmployeeProjectCount(@EmloyeeId INT)
RETURNS INT
BEGIN
	RETURN 
	(
	SELECT COUNT(EP.ProjectID)
	FROM EmployeesProjects AS EP
	GROUP BY EP.EmployeeID
	HAVING EP.EmployeeID = @EmloyeeId
	)
END

GO

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
	IF(dbo.ufn_EmployeeProjectCount(@emloyeeId)	> 3)
	BEGIN
		THROW 50001 , 'The employee has too many projects!' , 1
	END
	ELSE
	BEGIN
		INSERT INTO EmployeesProjects VALUES
		(@emloyeeId , @projectID)
	END
END


EXEC usp_AssignProject 263 , 1