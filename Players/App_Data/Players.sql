﻿CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(10) NOT NULL, 
    [DOB] DATETIME NOT NULL, 
    [Position] NCHAR(10) NOT NULL, 
    [Club] NCHAR(10) NOT NULL
)
