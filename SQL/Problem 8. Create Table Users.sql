USE Minions

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 7372800),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
	)

INSERT INTO [Users] ([Username] , [Password] , [ProfilePicture] , [LastLoginTime] , [IsDeleted]) VALUES
('Putka' , 'putka123' , NULL , '2021-09-18' , 'true'),
('Putka1' , 'putka123' , NULL , '2021-09-18' , 'false'),
('Putka2' , 'putka123' , NULL , '2021-09-18' , 'false'),
('Putka3' , 'putka123' , NULL , '2021-09-18' , 'true'),
('Putka4' , 'putka123' , NULL , '2021-09-18' , 'true')

DROP TABLE [Users]

ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC0798D28C12]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersCompositeIdUsername] PRIMARY KEY ([Id] , [Username])

ALTER TABLE [Users]
ADD CONSTRAINT [CK_PasswordNameLeastFive] CHECK (DATALENGTH([Password]) >= 5)

ALTER TABLE [Users]
DROP CONSTRAINT [DF_LastLoginTime]

ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] DEFAULT GETDATE() FOR [LastLoginTime]

ALTER TABLE [Users]
DROP CONSTRAINT [PK_UsersCompositeIdUsername]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Id] PRIMARY KEY ([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [CK_UsernameIsTreeSymbols] CHECK (DATALENGTH([Username]) >= 3)

