USE Minions

CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) UNIQUE NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH ([Picture]) <= 16000000),
	[Height] FLOAT(2),
	[Weight] FLOAT(2),
	[Gender] CHAR NOT NULL,
	CHECK ([Gender] = 'f' OR [Gender] = 'm'),
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
	)
	
INSERT INTO [People] ([Name] , [Picture] , [Height] , [Weight] , [Gender] , [Birthdate] , [Biography]) VALUES
('Pesho' , NULL , 1.3 , 5.6 , 'm' , '2021-09-18' , NULL),
('Koko' , NULL , 1.3 , 5.6 , 'f' , '2021-09-18' , NULL),
('Misho' , NULL , 1.3 , 5.6 , 'f' , '2021-09-18' , NULL),
('Jojo' , NULL , 1.3 , 5.6 , 'm' , '2021-09-18' , NULL),
('Dido' , NULL , 1.3 , 5.6 , 'f' , '2021-09-18' , NULL)