CREATE DATABASE [SoftUni]

USE [SoftUni]

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(20) NOT NULL
	)

CREATE TABLE [Addresses](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[AddressText] VARCHAR(50) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns] ([Id]) NOT NULL,
	)

CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(20) NOT NULL
	)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] VARCHAR(20) NOT NULL,
	[MiddleName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[JobTitle] VARCHAR(20) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments] ([Id]) NOT NULL,
	[HireDate] DATETIME2 NOT NULL,
	[Salary] FLOAT(2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses] ([Id]) NOT NULL
	)

INSERT INTO [Towns] ([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Addresses] ([AddressText] , [TownId]) VALUES
('KUR1' , 1),
('KUR2' , 4),
('KUR3' , 2),
('KUR4' , 3)

INSERT INTO [Departments] ([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees] ([FirstName] , [MiddleName] , [LastName] , [JobTitle] , [DepartmentId] , [HireDate] , [Salary] , [AddressId]) VALUES
('Ivan' , 'Ivanov' , 'Ivanov' , '.NET Developer' , 4 , '2013/02/01' , 3500.00 , 1),
('Petar' , 'Petrov' , 'Petrov' , 'Senior Engineer' , 1 , '2004/03/02' , 4000.00 , 4),
('Maria' , 'Petrova' , 'Ivanova' , 'Intern' , 5 , '2016/08/28' , 525.25 , 3),
('Georgi' , 'Teziev' , 'Ivanov' , 'CEO' , 2 , '2007/12/09' , 3000.00 , 4),
('Peter' , 'Pan' , 'Pan' , 'Intern' , 3 , '2016/08/28' , 599.88 , 2)

--Problem 19. Basic Select All Fields
SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

--Problem 20. Basic Select All Fields and Order Them
SELECT * FROM [Towns] ORDER BY [Name]
SELECT * FROM [Departments] ORDER BY [Name]
SELECT * FROM [Employees] ORDER BY [Salary] DESC

--Problem 21. Basic Select Some Fields
SELECT [Name] FROM [Towns] ORDER BY [Name]
SELECT [Name] FROM [Departments] ORDER BY [Name]
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] ORDER BY [Salary] DESC

--Problem 22. Increase Employees Salary
UPDATE [Employees] SET [Salary] = ([Salary]*110)/100
SELECT [Salary] FROM [Employees]

DROP TABLE [Employees]
DROP TABLE [Addresses]
DROP TABLE [Departments]
DROP TABLE [Towns]