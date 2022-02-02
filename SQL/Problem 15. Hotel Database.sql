CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY NOT NULL,
	[FirstName] VARCHAR(10) NOT NULL,
	[LastName] VARCHAR(10) NOT NULL,
	[Title] VARCHAR(20) NOT NULL,
	[Notes] VARCHAR(50)
    )

CREATE TABLE [Customers](
	[AccountNumber] INT PRIMARY KEY NOT NULL,
	[FirstName] VARCHAR(10) NOT NULL,
	[LastName] VARCHAR(10) NOT NULL,
	[PhoneNumber] INT NOT NULL,
	[EmergencyName] VARCHAR(20) NOT NULL,
	[EmergencyNumber] INT NOT NULL,
	[Notes] VARCHAR(50)
	)

CREATE TABLE [RoomStatus](
	[RoomStatus] VARCHAR(10) PRIMARY KEY NOT NULL,
	[Notes] VARCHAR(50)
	)

CREATE TABLE [RoomTypes](
	[RoomType] VARCHAR(10) PRIMARY KEY NOT NULL,
	[Notes] VARCHAR(50)
	)

CREATE TABLE [BedTypes](
	[BedType] VARCHAR(10) PRIMARY KEY NOT NULL,
	[Notes] VARCHAR(50)
	)

CREATE TABLE [Rooms](
	[RoomNumber] INT PRIMARY KEY NOT NULL,
	[RoomType] VARCHAR(10) FOREIGN KEY REFERENCES [RoomTypes] ([RoomType]) NOT NULL,
	[BedType] VARCHAR(10) FOREIGN KEY REFERENCES [BedTypes] ([BedType]) NOT NULL,
	[Rate] INT NOT NULL,
	[RoomStatus] VARCHAR(10) FOREIGN KEY REFERENCES [RoomStatus] ([RoomStatus]) NOT NULL,
	[Notes] VARCHAR(50)
    )

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers] ([AccountNumber]) NOT NULL,
	[FirstDateOccupied] DATETIME2 NOT NULL,
	[LastDateOccupied] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmountCharged] INT NOT NULL,
	[TaxRate] INT NOT NULL,
	[TaxAmount] INT NOT NULL,
	[PaymentTotal] INT NOT NULL,
	[Notes] VARCHAR(50)
    )

CREATE TABLE [Occupancies](
	[Id] INT PRIMARY KEY NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[DateOccupied] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers] ([AccountNumber]) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms] ([RoomNumber]) NOT NULL,
	[RateApplied] VARCHAR(10) NOT NULL,
	[PhoneCharge] INT NOT NULL,
	[Notes] VARCHAR(50)
    )

INSERT INTO [Employees] ([Id] , [FirstName] , [LastName] , [Title] , [Notes]) VALUES
(1 , 'PESHO' , 'PESHOV' , 'T' , NULL),
(2 , 'PESHO' , 'PESHOV' , 'T' , NULL),
(3 , 'PESHO' , 'PESHOV' , 'T' , NULL)

INSERT INTO [Customers] ([AccountNumber] , [FirstName] , [LastName] , [PhoneNumber] , [EmergencyName] , [EmergencyNumber] , [Notes]) VALUES
(123 , 'PUTKO' , 'KURO' , 1234 , 'PESHO' , 6969 , NULL),
(1234 , 'PUTKO' , 'KURO' , 1234 , 'PESHO' , 6969 , NULL),
(12345 , 'PUTKO' , 'KURO' , 1234 , 'PESHO' , 6969 , NULL)

INSERT INTO [RoomStatus] ([RoomStatus] , [Notes]) VALUES
('GOOD' , NULL),
('BAD' , NULL),
('FUCKED' , NULL)

INSERT INTO [RoomTypes] ([RoomType] , [Notes]) VALUES
('GOOD' , NULL),
('BAD' , NULL),
('FUCKED' , NULL)

INSERT INTO [BedTypes] ([BedType] , [Notes]) VALUES
('GOOD' , NULL),
('BAD' , NULL),
('FUCKED' , NULL)

INSERT INTO [Rooms] ([RoomNumber] , [RoomType] , [BedType] , [Rate] , [RoomStatus] , [Notes]) VALUES
(1 , 'GOOD' , 'BAD' , 5 , 'FUCKED' , NULL),
(2 , 'BAD' , 'BAD' , 5 , 'FUCKED' , NULL),
(3 , 'GOOD' , 'GOOD' , 5 , 'FUCKED' , NULL)

INSERT INTO [Payments] ([Id] , [EmployeeId] , [AccountNumber] , [FirstDateOccupied], [LastDateOccupied] , [TotalDays] , [AmountCharged] , [TaxRate] , [TaxAmount] , [PaymentTotal] , [Notes]) VALUES
(1 , 2 , 123 , '2021-09-18' , '2077-09-18' , 20000 , 9999 , 10 , 1000 , 1000000 , NULL),
(2 , 3 , 1234 , '2021-09-18' , '2077-09-18' , 20000 , 9999 , 10 , 1000 , 1000000 , NULL),
(3 , 1 , 12345 , '2021-09-18' , '2077-09-18' , 20000 , 9999 , 10 , 1000 , 1000000 , NULL)

INSERT INTO [Occupancies] ([Id] , [EmployeeId] , [DateOccupied] , [AccountNumber] , [RoomNumber] , [RateApplied] , [PhoneCharge] , [Notes]) VALUES
(1 , 2 , '2021-09-18' , 1234 , 1 , 'YES' , 100000 , NULL),
(2 , 3 , '2021-09-18' , 123 , 1 , 'YES' , 100000 , NULL),
(3 , 1 , '2021-09-18' , 12345 , 3 , 'YES' , 100000 , NULL)

--Problem 23. Decrease Tax Rate
UPDATE [Payments] SET [TaxRate] = ([TaxRate] * 97) / 100
SELECT [TaxRate] FROM [Payments]

--Problem 24. Delete All Records
DELETE FROM [Occupancies]