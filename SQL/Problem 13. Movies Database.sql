CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY NOT NULL,
	[DirectorName] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(50)
	)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY NOT NULL,
	[GenreName] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(50)
	)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY NOT NULL,
	[CategoryName] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(50)
	)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY NOT NULL,
	[Title] NVARCHAR(20) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors] (Id) NOT NULL,
	[CopyrightYear] DATETIME2,
	[Length] FLOAT NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres] (Id) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories] (Id) NOT NULL,
	[Rating] INT,
	[Notes] NVARCHAR(50)
	)

INSERT INTO [Directors] ([Id] , [DirectorName] , [Notes]) VALUES
(1 , 'Pesho' , Null),
(2 , 'Koko' , Null),
(3 , 'Moko' , Null),
(4 , 'Joko' , Null),
(5 , 'Loko' , Null)

INSERT INTO [Genres] ([Id] , [GenreName] , [Notes]) VALUES
(1 , 'book' , Null),
(2 , 'book' , Null),
(3 , 'book' , Null),
(4 , 'book' , Null),
(5 , 'book' , Null)

INSERT INTO [Categories] ([Id] , [CategoryName] , [Notes]) VALUES
(1 , 'C1' , Null),
(2 , 'C1' , Null),
(3 , 'C1' , Null),
(4 , 'C1' , Null),
(5 , 'C1' , Null)

INSERT INTO [Movies] ([Id] , [Title] , [DirectorId] , [CopyrightYear] , [Length] , [GenreId] , [CategoryId] , [Rating] , [Notes]) VALUES
(1 , 'T' , 1 , NULL , 60 , 3 , 5 , 5 , NULL),
(2 , 'T' , 2 , NULL , 60 , 4 , 5 , 3 , NULL),
(3 , 'T' , 4 , NULL , 60 , 4 , 4 , 5 , NULL),
(4 , 'T' , 5 , NULL , 60 , 5 , 5 , 1 , NULL),
(5 , 'T' , 3 , NULL , 60 , 1 , 3 , 5 , NULL)

DROP TABLE [Categories]
DROP TABLE [Genres]
DROP TABLE [Directors]
DROP TABLE [Movies]