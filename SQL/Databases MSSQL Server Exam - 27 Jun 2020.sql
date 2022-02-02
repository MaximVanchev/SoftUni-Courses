CREATE DATABASE WMS

USE WMS

--1. DDL
CREATE TABLE Clients (
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone VARCHAR(12) NOT NULL,
	CHECK (DATALENGTH (Phone) = 12)
	)

CREATE TABLE Mechanics (
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
	)

CREATE TABLE Models (
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
	)

CREATE TABLE Jobs (
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models (ModelId) NOT NULL,
	[Status] VARCHAR(11) NOT NULL DEFAULT 'Pending',
	CHECK ([Status] IN ('Pending' , 'In Progress' , 'Finished')),
	ClientId INT FOREIGN KEY REFERENCES Clients (ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics (MechanicId),
	IssueDate DATETIME2 NOT NULL,
	FinishDate DATETIME2
	)

CREATE TABLE Orders (
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs (JobId) NOT NULL,
	IssueDate DATETIME2,
	Delivered BIT DEFAULT 'FLASE' NOT NULL
	)

CREATE TABLE Vendors (
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
	)

CREATE TABLE Parts (
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(6 , 2) NOT NULL,
	CHECK (Price > 0),
	VendorId INT FOREIGN KEY REFERENCES Vendors (VendorId) NOT NULL,
	StockQty INT DEFAULT 0 NOT NULL,
	CHECK (StockQty >= 0)
	)

CREATE TABLE OrderParts (
	OrderId INT FOREIGN KEY REFERENCES Orders (OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts (PartId) NOT NULL,
	Quantity INT DEFAULT 1 NOT NULL,
	CHECK (Quantity > 0),
	PRIMARY KEY (OrderId , PartId)
	)

CREATE TABLE PartsNeeded (
	JobId INT FOREIGN KEY REFERENCES Jobs (JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts (PartId) NOT NULL,
	Quantity INT DEFAULT 1 NOT NULL,
	CHECK (Quantity > 0),
	PRIMARY KEY (JobId , PartId)
	)

--2. Insert
INSERT INTO Clients VALUES
('Teri' , 'Ennaco' , '570-889-5187'),
('Merlyn' , 'Lawler' , '201-588-7810'),
('Georgene' , 'Montezuma' , '925-615-5185'),
('Jettie' , 'Mconnell' , '908-802-3564'),
('Lemuel' , 'Latzke' , '631-748-6479'),
('Melodie' , 'Knipp' , '805-690-1682'),
('Candida' , 'Corbley' , '908-275-8357')

INSERT INTO Parts VALUES
('WP8182119' , 'Door Boot Seal' , 117.86 , 2 , DEFAULT),
('W10780048' , 'Suspension Rod' , 42.81 , 1 , DEFAULT),
('W10841140' , 'Silicone Adhesive' , 6.77 , 4 , DEFAULT),
('WPY055980' , 'High Temperature Adhesive' , 13.94 , 3 , DEFAULT)

--3. Update
UPDATE Jobs
SET MechanicId = 3
WHERE [Status] = 'Pending'
UPDATE Jobs
SET [Status] = 'In Progress'
WHERE [Status] = 'Pending'

--4. Delete
DELETE FROM OrderParts 
WHERE OrderId = 19
DELETE FROM Orders
WHERE OrderId = 19

--5. Mechanic Assignments
SELECT CONCAT_WS(' ' , M.FirstName , M.LastName) AS Mechanic , J.[Status] , J.IssueDate
FROM Mechanics AS M
JOIN Jobs AS J
ON M.MechanicId = J.MechanicId
ORDER BY M.MechanicId , J.IssueDate , J.JobId

--6. Current Clients
SELECT CONCAT_WS(' ' , C.FirstName , C.LastName) AS Client 
, DATEDIFF(DAY , J.IssueDate , '2017-04-24') AS DaysGoing 
, J.[Status]
FROM Clients AS C
JOIN Jobs AS J
ON C.ClientId = J.ClientId
WHERE J.FinishDate IS NULL
ORDER BY DaysGoing DESC , C.ClientId

--7. Mechanic Performance
SELECT CONCAT_WS(' ' , M.FirstName , M.LastName) AS Mechanic , AVG(DATEDIFF(DAY , J.IssueDate , J.FinishDate)) AS AverageDays
FROM Mechanics AS M
JOIN Jobs AS J
ON M.MechanicId = J.MechanicId
WHERE J.FinishDate IS NOT NULL
GROUP BY J.MechanicId , M.FirstName , M.LastName

--8. Available Mechanics
SELECT S.Available
FROM
(
SELECT CONCAT( M.FirstName , ' ' , M.LastName) AS Available , M.MechanicId
FROM Mechanics AS M
JOIN Jobs AS J
ON M.MechanicId = J.MechanicId
WHERE J.FinishDate IS NOT NULL AND M.MechanicId NOT IN (SELECT MechanicId FROM Jobs WHERE FinishDate IS NULL AND MechanicId IS NOT NULL GROUP BY MechanicId)
GROUP BY M.FirstName , M.LastName , M.MechanicId
) AS S
ORDER BY S.MechanicId

--9. Past Expenses
SELECT *
FROM
(
SELECT J.JobId , SUM(P.Price * PN.Quantity) AS Total	
FROM dbo.PartsNeeded AS PN
JOIN Parts AS P
ON PN.PartId = P.PartId
JOIN Jobs AS J
ON PN.JobId = J.JobId
WHERE J.FinishDate IS NOT NULL
GROUP BY J.JobId
) AS S
ORDER BY S.Total DESC , S.JobId

--10. Missing Parts
SELECT *
FROM
(
SELECT PN.PartId , P.[Description] , PN.Quantity AS [Required] , SUM(P.StockQty) AS InStock 
, 
CASE
WHEN O.OrderId((SELECT SUM(OP1.Quantity) FROM OrderParts AS OP1 JOIN Orders AS O1 ON OP1.OrderId = O1.OrderId WHERE O1.Delivered = 0 GROUP BY O1.JobId)) THEN 0
ELSE (SELECT SUM(OP1.Quantity) FROM OrderParts AS OP1 JOIN Orders AS O1 ON OP1.OrderId = O1.OrderId WHERE O1.Delivered = 0 GROUP BY O1.JobId)
END AS Ordered
FROM dbo.PartsNeeded AS PN
JOIN Parts AS P
ON PN.PartId = P.PartId
JOIN Jobs AS J
ON PN.JobId = J.JobId
JOIN Orders AS O
ON J.JobId = O.JobId
WHERE J.FinishDate IS NULL
GROUP BY PN.PartId , P.[Description] , O.Delivered , PN.Quantity
) AS S
WHERE S.[Required] > (S.InStock + S.Ordered)
ORDER BY S.PartId