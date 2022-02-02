CREATE DATABASE CigarShop

USE CigarShop

--1. DDL
CREATE TABLE Sizes (
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL,
	CHECK ([Length] BETWEEN 10 AND 25),
	RingRange DECIMAL(10 , 2) NOT NULL,
	CHECK (RingRange BETWEEN 1.5 AND 7.5)
	)

CREATE TABLE Tastes (
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
	)

CREATE TABLE Brands (
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX),
	)

CREATE TABLE Cigars (
	Id INT IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands (Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes (Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes (Id) NOT NULL,
	PRIMARY KEY (Id),
	PriceForSingleCigar DECIMAL NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
	)

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
	)

CREATE TABLE Clients (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses (Id) NOT NULL
	)

CREATE TABLE ClientsCigars (
	ClientId INT FOREIGN KEY REFERENCES Clients (Id) NOT NULL,
	CigarId INT FOREIGN KEY REFERENCES Cigars (Id) NOT NULL,
	PRIMARY KEY (ClientId , CigarId)
	)

--2. Insert
INSERT INTO Cigars (CigarName , BrandId , TastId , SizeId , PriceForSingleCigar , ImageURL) VALUES
('COHIBA ROBUSTO' , 9 , 1 , 5 , 15.50 , 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I' , 9 , 1 , 10 , 410.00 , 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE' , 14 , 5 , 11 , 7.50 , 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN' , 14 , 4 , 15 , 32.00 , 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES' , 2 , 3 , 8 , 85.21 , 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses VALUES
('Sofia' , 'Bulgaria' , '18 Bul. Vasil levski' , '1000'),
('Athens' , 'Greece' , '4342 McDonald Avenue' , '10435'),
('Zagreb' , 'Croatia' , '4333 Lauren Drive' , '10000')

--3. Update
UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar * 1.2 
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--4. Delete
ROLLBACK

DELETE FROM ClientsCigars
WHERE ClientId IN (SELECT ClientId FROM Clients WHERE AddressId IN (SELECT AddressId FROM Addresses WHERE Country LIKE 'C%'))

DELETE FROM Clients
WHERE AddressId IN (SELECT AddressId FROM Addresses WHERE Country LIKE 'C%')

DELETE FROM Addresses
WHERE Country LIKE 'C%'

--5. Cigars by Price
SELECT CigarName , PriceForSingleCigar , ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar , CigarName DESC

--6. Cigars by Taste
SELECT C.Id , C.CigarName , C.PriceForSingleCigar , T.TasteType , T.TasteStrength
FROM Cigars AS C
JOIN Tastes AS T
ON C.TastId = T.Id
WHERE TastId IN (2 , 3)
ORDER BY C.PriceForSingleCigar DESC

--7. Clients without Cigars
SELECT C.Id , CONCAT(C.FirstName , ' ' , C.LastName) AS ClientName , C.Email
FROM Clients AS C
LEFT JOIN ClientsCigars AS CC
ON C.Id = CC.ClientId
WHERE CC.CigarId IS NULL
ORDER BY ClientName

--8. First 5 Cigars
SELECT TOP 5 C.CigarName , C.PriceForSingleCigar , C.ImageURL
FROM Cigars AS C
JOIN Sizes AS S
ON C.SizeId = S.Id
WHERE (S.[Length] >= 12 AND C.CigarName LIKE '%CI%') OR (C.PriceForSingleCigar > 50 AND S.RingRange > 2.55) OR (S.[Length] >= 12 AND C.CigarName LIKE '%CI%' AND C.PriceForSingleCigar > 50 AND S.RingRange > 2.55)
ORDER BY C.CigarName , C.PriceForSingleCigar DESC
--9. Clients with ZIP Codes
SELECT S.FullName , S.Country , S.ZIP , CONCAT('$' , S.CigarPrice)
FROM
(
SELECT CONCAT(C.FirstName , ' ' , C.LastName) AS FullName , A.Country , A.ZIP , CI.PriceForSingleCigar AS CigarPrice
, DENSE_RANK() OVER(PARTITION BY CONCAT(C.FirstName , ' ' , C.FirstName) ORDER BY CI.PriceForSingleCigar DESC) AS [RANK]
FROM Clients AS C
JOIN Addresses AS A
ON C.AddressId = A.Id
JOIN ClientsCigars AS CC
ON C.Id = CC.ClientId
JOIN Cigars AS CI
ON CC.CigarId = CI.Id
WHERE A.ZIP NOT LIKE '%[^0-9]%'
GROUP BY C.FirstName ,  C.LastName , A.Country  , A.ZIP , CI.PriceForSingleCigar
) AS S
WHERE S.[RANK] = 1
ORDER BY S.FullName

--10. Cigars by Size
SELECT *
FROM
(
SELECT C.LastName , AVG(S.[Length]) AS CiagrLength , CEILING(AVG(S.RingRange)) AS CiagrRingRange
FROM Clients AS C
JOIN ClientsCigars AS CC
ON C.Id = CC.ClientId
JOIN Cigars AS CI
ON CC.CigarId = CI.Id
JOIN Sizes AS S
ON CI.SizeId = S.Id
GROUP BY C.LastName
) AS S
ORDER BY S.CiagrLength DESC

--11. Client with Cigars
CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
	RETURN (SELECT 
	CASE
		WHEN COUNT(CC.CigarId) IS NULL THEN 0
		ELSE COUNT(CC.CigarId)
		END
	FROM Clients AS C
	LEFT JOIN ClientsCigars AS CC
	ON C.Id = CC.ClientId
	WHERE C.FirstName = ''
	--GROUP BY C.FirstName
	)
END

SELECT dbo.udf_ClientWithCigars('Betty')
--12. Search for Cigar with Specific Taste
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
SELECT C.CigarName , CONCAT('$' , C.PriceForSingleCigar) AS Price , T.TasteType , B.BrandName , CONCAT(S.[Length] , ' cm') AS CigarLength , CONCAT(S.RingRange , ' cm') AS CigarRingRange
FROM Cigars AS C
JOIN Tastes AS T
ON C.TastId = T.Id
JOIN Sizes AS S
ON C.SizeId = S.Id
JOIN Brands AS B
ON C.BrandId = B.Id
WHERE T.TasteType = @taste
ORDER BY CigarLength , CigarRingRange DESC
END

EXEC usp_SearchByTaste 'Woody'