USE SoftUni

--1. Find Names of All Employees by First Name
SELECT [FirstName] , [LastName] 
FROM Employees
WHERE [FirstName] LIKE 'Sa%'

--2. Find Names of All Employees by Last Name
SELECT [FirstName] , [LastName] 
FROM Employees
WHERE [LastName] LIKE '%ei%'

--3. Find First Names of All Employess
SELECT [FirstName]
FROM Employees
WHERE [DepartmentID] IN (3 , 10) AND DATEPART(YEAR , [HireDate]) BETWEEN 1995 AND 2005

--4. Find All Employees Except Engineers
SELECT [FirstName] , [LastName]
FROM Employees
WHERE [JobTitle] NOT LIKE '%engineer%'

--5. Find Towns with Name Length
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN (5 , 6)
ORDER BY [Name]

--6. Find Towns Starting With
SELECT *
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--7. Find Towns Not Starting With
SELECT *
FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

--8. Create View Employees Hired After
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT [FirstName] , [LastName]
FROM Employees
WHERE DATEPART(YEAR , HireDate) > 2000

--9. Length of Last Name
SELECT [FirstName] , [LastName]
FROM Employees
WHERE LEN([LastName]) = 5

--10. Rank Employees by Salary
SELECT EmployeeID , FirstName , LastName , Salary 
, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees AS e
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY Salary DESC


--11. Find All Employees with Rank 2
SELECT *
FROM(
	SELECT EmployeeID , FirstName , LastName , Salary 
	, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees AS e
	WHERE [Salary] BETWEEN 10000 AND 50000 
	) AS MyTable
WHERE Rank = 2
ORDER BY Salary DESC

--12. Countries Holding 'A'
USE Geography

SELECT [CountryName] , [ISOCode]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--13. Mix of Peak and River Names
SELECT p.PeakName , r.RiverName , LOWER(CONCAT(p.PeakName , RIGHT(r.RiverName , LEN(r.RiverName) - 1))) AS Mix
FROM Peaks AS p , Rivers AS r
WHERE RIGHT(p.PeakName , 1) = LEFT(R.RiverName , 1)
ORDER BY Mix

--14. Games From 2011 and 2012 Year
USE Diablo

SELECT TOP(50) Name , FORMAT(Start , 'yyyy-MM-dd') AS Start
FROM Games
WHERE DATEPART(YEAR , Start) IN (2011 , 2012)
ORDER BY Start , Name

--15. User Email Providers
SELECT Username , SUBSTRING(Email , CHARINDEX('@' , Email , 1) + 1, LEN(Email) - CHARINDEX('@' , Email , 1)) AS EmailProvider
FROM Users
ORDER BY EmailProvider , Username

--16. Get Users with IPAddress Like Pattern
SELECT Username , IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

--17. Show All Games with Duration
SELECT Name ,
CASE
	WHEN DATEPART(HOUR , Start) >= 0 AND DATEPART(HOUR , Start) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR , Start) >= 12 AND DATEPART(HOUR , Start) < 18 THEN 'Afternoon'
	WHEN DATEPART(HOUR , Start) >= 18 AND DATEPART(HOUR , Start) < 24 THEN 'Evening'
	END AS PartoftheDay ,
CASE
	WHEN Duration <= 3  THEN 'Extra Short'
	WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM Games
ORDER BY Name , Duration , PartoftheDay

--18. Orders Table
CREATE TABLE Orders(
	Id INT PRIMARY KEY NOT NULL,
	ProductName VARCHAR(50) NOT NULL,
	OrderDate DATETIME2 NOT NULL
	)

INSERT INTO Orders (Id , ProductName , OrderDate) VALUES
(1 , 'Butter' , '2016-09-19'),
(2 , 'Milk' , '2016-09-30'),
(3 , 'Cheese' , '2016-09-04'),
(4 , 'Bread' , '2015-12-20'),
(5 , 'Tomatoes	' , '2015-12-30')

SELECT ProductName , OrderDate 
, DATEADD(DAY , 3 , OrderDate) AS PayDue
, DATEADD(MONTH , 1 , OrderDate) AS DeliverDue
FROM Orders