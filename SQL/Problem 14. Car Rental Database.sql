CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY NOT NULL,
	[CategoryName] VARCHAR(20) NOT NULL,
	[DailyRate] INT NOT NULL,
	[WeeklyRate] INT NOT NULL,
	[MonthlyRate] INT NOT NULL,
	[WeekendRate] INT NOT NULL
    )

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY NOT NULL,
	[PlateNumber] INT NOT NULL,
	[Manufacturer] VARCHAR(20) NOT NULL,
	[Model] VARCHAR(20) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories] ([Id]),
	[Doors] INT NOT NULL,
	[Picture] VARBINARY,
	[Condition] VARCHAR(20) NOT NULL,
	[Available] VARCHAR(10) NOT NULL
    )

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY NOT NULL,
	[FirstName] VARCHAR(10) NOT NULL,
	[LastName] VARCHAR(10) NOT NULL,
	[Title] VARCHAR(20) NOT NULL,
	[Notes] VARCHAR(50)
    )

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY NOT NULL,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] VARCHAR(20) NOT NULL,
	[Address] VARCHAR(50) NOT NULL,
	[City] VARCHAR(20) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] VARCHAR(50)
    )

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers] ([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars] ([Id]) NOT NULL,
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] VARCHAR(20),
	[TaxRate] INT NOT NULL,
	[OrderStatus] VARCHAR(20) NOT NULL,
	[Notes] VARCHAR(50)
    )

INSERT INTO [Categories] ([Id] , [CategoryName] , [DailyRate] , [WeeklyRate] , [MonthlyRate] , [WeekendRate] ) VALUES
(1 , 'K' , 10 , 10 , 10 , 10),
(2 , 'K' , 10 , 10 , 10 , 10),
(3 , 'K' , 10 , 10 , 10 , 10)

INSERT INTO [Cars] ([Id] , [PlateNumber] , [Manufacturer] , [Model] , [CarYear] , [CategoryId] , [Doors] , [Picture] , [Condition] , [Available]) VALUES
(1 , 10 , 'KOKO' , 'HONDA' , 1988 , 3 , 10 , NULL , 'GOOD' , 'YES'),
(2 , 10 , 'KOKO' , 'HONDA' , 1988 , 3 , 10 , NULL , 'GOOD' , 'YES'),
(3 , 10 , 'KOKO' , 'HONDA' , 1988 , 3 , 10 , NULL , 'GOOD' , 'YES')

INSERT INTO [Employees] ([Id] , [FirstName] , [LastName] , [Title] , [Notes]) VALUES
(1 , 'KOKO' , 'LOKO' , 'T' , NULL),
(2 , 'KOKO' , 'LOKO' , 'T' , NULL),
(3 , 'KOKO' , 'LOKO' , 'T' , NULL)

INSERT INTO [Customers] ([Id] , [DriverLicenceNumber] , [FullName] , [Address] , [City] , [ZIPCode] , [Notes]) VALUES
(1 , 1234 , 'PISHKOLAPACH' , 'NA MAIKA TI PUTKATA' , 'AZERBAIJAN' , 6969 , NULL),
(2 , 1234 , 'PISHKOLAPACH' , 'NA MAIKA TI PUTKATA' , 'AZERBAIJAN' , 6969 , NULL),
(3 , 1234 , 'PISHKOLAPACH' , 'NA MAIKA TI PUTKATA' , 'AZERBAIJAN' , 6969 , NULL)

INSERT INTO [RentalOrders] ([Id] , [EmployeeId] , [CustomerId] , [CarId] , [TankLevel] , [KilometrageStart] , [KilometrageEnd] , [TotalKilometrage] , [StartDate] ,	[EndDate] ,	[TotalDays] , [RateApplied] , [TaxRate] , [OrderStatus] , [Notes]) VALUES
(1 , 3 , 2 , 3 , 100 , 0 , 300 , 200 , '2021-09-18' , '2070-09-18' , 10000 , 'NO' , 10 , 'GOOD' , NULL),
(2 , 3 , 2 , 3 , 100 , 0 , 300 , 200 , '2021-09-18' , '2070-09-18' , 10000 , 'NO' , 10 , 'GOOD' , NULL),
(3 , 3 , 2 , 3 , 100 , 0 , 300 , 200 , '2021-09-18' , '2070-09-18' , 10000 , 'NO' , 10 , 'GOOD' , NULL)

DROP TABLE [RentalOrders]
DROP TABLE [Customers]
DROP TABLE [Employees]
DROP TABLE [Cars]
DROP TABLE [Categories]