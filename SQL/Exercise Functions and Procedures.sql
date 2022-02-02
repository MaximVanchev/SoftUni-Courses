USE SoftUni

--1. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
(
	SELECT FirstName , LastName
	FROM Employees
	WHERE Salary > 35000
)

EXEC usp_GetEmployeesSalaryAbove35000

--2. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@num DECIMAL(18,4))
AS
(
	SELECT FirstName , LastName
	FROM Employees
	WHERE Salary >= @num
)

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith (@startingString VARCHAR(10))
AS
(
	SELECT [Name] AS Town
	FROM Towns
	WHERE [Name] LIKE @startingString + '%'
)

EXEC usp_GetTownsStartingWith b

--4. Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@name VARCHAR(20))
AS
(
	SELECT E.FirstName , E.LastName
	FROM Employees AS E
	JOIN Addresses AS A
	ON E.AddressID = A.AddressID
	JOIN Towns AS T
	ON A.TownID = T.TownID
	WHERE T.Name = @name
)

EXEC usp_GetEmployeesFromTown Sofia

--5. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @result VARCHAR(10)
	IF (@salary < 30000)
	BEGIN
		SET @result = 'Low'
	END
	ELSE IF (@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @result = 'Average'
	END
	ELSE
	BEGIN
		SET @result = 'High'
	END
	RETURN @result
END

--6. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@levelOfSalary VARCHAR(10))
AS
(
	SELECT FirstName , LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
)

EXEC usp_EmployeesBySalaryLevel [High]

--7. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(30) , @word VARCHAR(30))
RETURNS INT AS
BEGIN
	DECLARE @result INT = 1
	DECLARE @cnt INT = 1 
	WHILE @cnt <= LEN(@word)
	BEGIN
	DECLARE @letter VARCHAR(1) = SUBSTRING(@word , @cnt , 1)
	IF (CHARINDEX(@letter , @setOfLetters , 1) = 0)
	BEGIN
		SET @result = 0
	END
	SET @cnt = @cnt + 1
	END
	RETURN @result
END

--8. * Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
(
	SELECT	COUNT(S.EmployeeID)
	FROM
	(
		SELECT E.EmployeeID
		FROM Employees AS E
		JOIN Departments AS D
		ON E.DepartmentID = D.DepartmentID
		WHERE D.DepartmentID = @departmentId
	) AS S
)
DELETE FROM Employees WHERE DepartmentID = @departmentId
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL
UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 3

--9. Find Full Name
USE Bank 

CREATE PROC usp_GetHoldersFullName
AS
(
	SELECT CONCAT(FirstName , ' ' , LastName) AS FullName
	FROM AccountHolders
)

EXEC usp_GetHoldersFullName

--10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@num DECIMAL)
AS
(
	SELECT AH.FirstName , AH.LastName
	FROM AccountHolders AS AH
	JOIN Accounts AS A
	ON AH.Id = A.AccountHolderId
	GROUP BY AH.FirstName , AH.LastName
	HAVING SUM(A.Balance) > @num
)
	ORDER BY AH.FirstName , AH.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 10000

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@I DECIMAL(38, 4), @R FLOAT, @T INT)
RETURNS DECIMAL(38, 4)
AS
BEGIN
	DECLARE @result DECIMAL(38, 4) = ROUND(@I * POWER(1 + @R , @T) , 4)
	RETURN @result
END

DECLARE @result DECIMAL(38, 4)
EXEC @result = ufn_CalculateFutureValue 1000 , 0.1  , 5
SELECT @result

--12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount(@AccountId INT , @InterestRate DECIMAL)
AS
(
	
	SELECT AH.FirstName , AH.LastName , A.Balance AS CurrentBalance , @BalanceIn5Years
	FROM AccountHolders AS AH
	JOIN Accounts AS A
	ON AH.Id = A.AccountHolderId
	WHERE A.Id = @AccountId
	
)
DECLARE @BalanceIn5Years DECIMAL(38, 4)
EXEC @BalanceIn5Years = ufn_CalculateFutureValue A.Balance , @InterestRate , 5

--13. *Scalar Function: Cash in User Games Odd Rows


--14. Create Table Logs
