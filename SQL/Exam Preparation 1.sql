CREATE DATABASE Airport

USE Airport

--1. DDL
CREATE TABLE Planes (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
	)

CREATE TABLE Flights (
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes (Id) NOT NULL
	)

CREATE TABLE Passengers (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
	)

CREATE TABLE LuggageTypes (
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
	)

CREATE TABLE Luggages (
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes (Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers (Id) NOT NULL
	)

CREATE TABLE Tickets (
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers (Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights (Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages (Id) NOT NULL,
	Price DECIMAL(18 , 2) NOT NULL,
	)
--2. Insert
INSERT INTO Planes VALUES
('Airbus 336' , 112 , 5132),
('Airbus 330' , 432 , 5325),
('Boeing 369' , 231 , 2355),
('Stelt 297' , 254 , 2143),
('Boeing 338' , 165 , 5111),
('Airbus 558' , 387 , 1342),
('Boeing 128' , 345 , 5541)

INSERT INTO LuggageTypes VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--3. Update
UPDATE Tickets
SET Price = Price * 1.13
WHERE FlightId = (SELECT Id FROM Flights WHERE Destination = 'Carlsbad')

--4. Delete
DELETE FROM Tickets
WHERE FlightId = (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--5. The "Tr" Planes
SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id , [Name] , [Range]

--6. Flight Profits
SELECT F.Id , SUM(T.Price) AS Price
FROM Flights AS F
JOIN Tickets AS T
ON F.Id = T.FlightId
GROUP BY F.Id
ORDER BY SUM(T.Price) DESC, F.Id

--7. Passenger Trips
SELECT CONCAT(P.FirstName , ' ' , P.LastName) AS FullName , F.Origin , F.Destination
FROM Passengers AS P
JOIN Tickets as T
ON P.Id = T.PassångerId
JOIN Flights AS F
ON T.FlightId = F.Id
ORDER BY CONCAT(P.FirstName , ' ' , P.LastName) , F.Origin , F.Destination

--8. Non Adventures People
SELECT P.FirstName , P.LastName , P.Age
FROM Passengers AS P
LEFT JOIN Tickets AS T
ON P.Id = T.PassångerId
WHERE T.Id IS NULL
ORDER BY P.Age DESC, P.FirstName , P.LastName

--9. Full Info
SELECT CONCAT(P.FirstName , ' ' , P.LastName) AS FullName , PL.Name AS PlaneName , CONCAT(F.Origin , ' - ' , F.Destination) AS Trip , LT.Type AS LuggageType
FROM Passengers AS P
JOIN Tickets AS T
ON P.Id = T.PassångerId
JOIN Flights AS F
ON T.FlightId = F.Id
JOIN Planes AS PL
ON F.PlaneId = PL.Id
JOIN Luggages AS L
ON T.LuggageId = L.Id
JOIN LuggageTypes AS LT
ON L.LuggageTypeId = LT.Id
ORDER BY CONCAT(P.FirstName , ' ' , P.LastName) , PL.[Name] , F.Origin , F.Destination , LT.Type

--10. PSP
SELECT PL.[Name] , PL.Seats , COUNT(P.Id) AS PassengersCount
FROM Passengers AS P
JOIN Tickets AS T
ON P.Id = T.PassångerId
JOIN Flights AS F
ON T.FlightId = F.Id
JOIN Planes AS PL
ON F.PlaneId = PL.Id
GROUP BY PL.[Name] , PL.Seats
ORDER BY PassengersCount DESC, PL.[Name] , PL.Seats

--11. Vacation
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @flightValidation INT = (SELECT COUNT(*) FROM Flights WHERE Origin = @origin AND Destination = @destination)
	DECLARE @flightTotalPrice FLOAT = @peopleCount * 
	(SELECT T.Price FROM Flights AS F
	JOIN Tickets AS T ON F.Id = T.FlightId
	WHERE Origin = @origin AND Destination = @destination)
	IF (@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!'
	END
	IF (@flightValidation = 0)
	BEGIN
		RETURN 'Invalid flight!'
	END
	RETURN CONCAT('Total price ' , @flightTotalPrice)
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--12. Wrong Data
CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
	--BEGIN TRANSACTION
	UPDATE Flights
	SET DepartureTime = NULL
	WHERE ArrivalTime > DepartureTime
	UPDATE Flights
	SET ArrivalTime = NULL
	WHERE DepartureTime IS NULL
END

EXEC usp_CancelFlights
ROLLBACK