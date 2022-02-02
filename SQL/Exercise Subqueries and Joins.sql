USE SoftUni

--1. Employee Address
SELECT TOP (5) e.EmployeeID , e.JobTitle , e.AddressID , a.AddressText 
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID 
ORDER BY e.AddressID

--2. Addresses with Towns
SELECT TOP (50) e.FirstName , e.LastName , t.Name	 , a.AddressText 
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID 
JOIN Towns AS t
ON t.TownID = a.TownID
ORDER BY e.FirstName , e.LastName

--3. Sales Employees
SELECT e.EmployeeID , e.FirstName , e.LastName , d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

--4. Employee Departments
SELECT TOP (5) e.EmployeeID , e.FirstName , e.Salary , d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

--5. Employees Without Projects
SELECT TOP (3) e.EmployeeID , e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--6. Employees Hired After
SELECT e.FirstName , e.LastName , e.HireDate , d.Name AS DeptName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '01-01-1999' AND d.Name IN ('Sales' , 'Finance')
ORDER BY e.HireDate

--7. Employees With Project
SELECT TOP (5) e.EmployeeID , e.FirstName , p.Name AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE P.StartDate > '08-13-2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8. Employee 24
SELECT e.EmployeeID , e.FirstName , 
CASE
	WHEN DATEPART(YEAR , p.StartDate) >= 2005 THEN NULL
	ELSE p.Name
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--9. Employee Manager
SELECT e.EmployeeID , e.FirstName , e.ManagerID , m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
WHERE m.EmployeeID IN (3 , 7)
ORDER BY e.EmployeeID

--10. Employees Summary
SELECT TOP (50) e.EmployeeID , CONCAT(e.FirstName , ' ' , e.LastName) AS EmployeeName , CONCAT(m.FirstName , ' ' , m.LastName) AS ManagerName , d.Name AS DepartmentName
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT MIN(s.AvgSalary) AS MinAverageSalary FROM
(SELECT AVG(Salary) AS AvgSalary FROM Employees GROUP BY DepartmentID) AS s

--12. Highest Peaks in Bulgaria
USE Geography

SELECT c.CountryCode , m.MountainRange , p.PeakName , p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON m.Id = p.MountainId
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
SELECT c.CountryCode  , COUNT(m.MountainRange) 
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('BG' , 'RU' , 'US')
GROUP BY c.CountryCode 

--14. Countries With or Without Rivers
SELECT TOP (5) c.CountryName , r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15. Continents and Currencies
SELECT *
FROM
(
SELECT ContinentCode , CurrencyCode , COUNT(CurrencyCode) AS CurrencyUsage 
FROM Countries AS cu
GROUP BY ContinentCode , CurrencyCode
HAVING COUNT(CurrencyCode) > 1
) AS s

SELECT OrderedCurrencies.ContinentCode,
	   OrderedCurrencies.CurrencyCode,
	   OrderedCurrencies.CurrencyUsage
  FROM Continents AS c
  JOIN (
	   SELECT ContinentCode AS [ContinentCode],
	   COUNT(CurrencyCode) AS [CurrencyUsage],
	   CurrencyCode as [CurrencyCode],
	   DENSE_RANK() OVER (PARTITION BY ContinentCode
	                      ORDER BY COUNT(CurrencyCode) DESC
						  ) AS [Rank]
	   FROM Countries
	   GROUP BY ContinentCode, CurrencyCode
	   HAVING COUNT(CurrencyCode) > 1
	   )
	   AS OrderedCurrencies
    ON c.ContinentCode = OrderedCurrencies.ContinentCode
 WHERE OrderedCurrencies.Rank = 1

--16. Highest Peak and Longest River by Country
SELECT TOP(5) S.CountryName , S.HighestPeakElevation , S.LongestRiverLength
FROM
(
SELECT C.CountryName 
, MAX(P.Elevation) AS HighestPeakElevation 
, MAX(R.Length) AS LongestRiverLength
, DENSE_RANK() OVER (PARTITION BY C.CountryName ORDER BY MAX(P.Elevation) DESC , MAX(R.Length) DESC) AS [Rank]
FROM Countries AS C
LEFT JOIN CountriesRivers AS CR
ON C.CountryCode = CR.CountryCode
LEFT JOIN Rivers AS R
ON CR.RiverId = R.Id
LEFT JOIN MountainsCountries AS MC
ON C.CountryCode = MC.CountryCode
LEFT JOIN Peaks AS P
ON MC.MountainId = P.MountainId
GROUP BY C.CountryName
) AS S
WHERE S.Rank = 1
ORDER BY S.HighestPeakElevation DESC , S.LongestRiverLength DESC , S.CountryName

--17. Highest Peak and Longest River by Country
SELECT S.Country , S.HighestPeakName , S.HighestPeakElevation , S.Mountain

--, DENSE_RANK() OVER (PARTITION BY S.HighestPeakElevation ORDER BY S.HighestPeakName) AS [Rank1]
FROM
(
SELECT C.CountryName AS Country , 
CASE
	WHEN P.PeakName IS NULL THEN '(no highest peak)'
	ELSE P.PeakName
	END AS HighestPeakName , 
CASE
	WHEN MAX(P.Elevation) IS NULL THEN 0
	ELSE MAX(P.Elevation)
	END AS HighestPeakElevation ,
CASE
	WHEN M.MountainRange IS NULL THEN '(no mountain)'
	ELSE M.MountainRange
	END AS Mountain
, ROW_NUMBER() OVER (ORDER BY C.CountryName) AS [ROW_NUMBER]
, DENSE_RANK() OVER (PARTITION BY C.CountryName ORDER BY MAX(P.Elevation) DESC) AS [Rank]
FROM Countries AS C
LEFT JOIN MountainsCountries AS MC
ON C.CountryCode = MC.CountryCode
LEFT JOIN Mountains AS M
ON MC.MountainId = M.Id
LEFT JOIN Peaks AS P
ON MC.MountainId = P.MountainId
GROUP BY C.CountryName , P.PeakName , M.MountainRange
) AS S
WHERE S.Rank = 1
ORDER BY S.Country , S.HighestPeakName