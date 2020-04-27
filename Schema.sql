DROP DATABASE IF EXISTS OrmPerf
GO

CREATE DATABASE OrmPerf
GO

USE OrmPerf
GO

CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	
	CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[Town] [nvarchar](50) NOT NULL,

	CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Address_Contact] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact]([Id])
)
GO


DECLARE @cnt INT = 0
DECLARE @contactId INT

WHILE @cnt < 10
BEGIN
   INSERT INTO Contact (Name) VALUES (CONCAT('Name ', @cnt))
   SET @contactId = SCOPE_IDENTITY()
   INSERT INTO Address (ContactId, Town) VALUES (@contactId, CONCAT('Town ', @cnt))

   SET @cnt = @cnt + 1;
END