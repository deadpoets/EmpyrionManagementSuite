--// ############################################################
--// Empyrion Management Suite MS-SQL Server Table Schema Build
--// 11/23/2016 by MorpheusZero (dylanlegendre09@gmail.com) - Initial Build
--//
--// NOTICE: This is to be used to generate a new database schema
--// from scratch on MS SQL Server only. Changes may be necessary
--// to make it work for ORACLE, MySQL, or other RDMS.
--// #############################################################

--// Users of the system tied to a login for gaining access to online only features.
CREATE TABLE [ems_Users]
(
	ID INT NOT NULL IDENTITY(101, 1) PRIMARY KEY,
	CreateDate DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	LastEditDate DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	InActive BIT NOT NULL DEFAULT(0),
	Email NVARCHAR(100) NOT NULL,
	PasswordHash NVARCHAR(512) NOT NULL,
	Salt NVARCHAR(512) NOT NULL,
	SecurityAuthToken CHAR(5) NOT NULL,
	Verified BIT NOT NULL DEFAULT(0),
	LastLoginDate DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	Banned BIT NOT NULL DEFAULT(0),
	BanDays INT NOT NULL DEFAULT(0),
	DisplayName NVARCHAR(50) NOT NULL,
	Reputation INT NOT NULL DEFAULT(0)
)
GO

--// A global banlist header created by users for sharing to other server owners.
CREATE TABLE [ems_Banlist]
(
	ID INT NOT NULL IDENTITY(101, 1) PRIMARY KEY,
	CreateDate DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	LastEditDate DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	InActive BIT NOT NULL DEFAULT(0),
	OwnerID INT NOT NULL,
	OwnerURL NVARCHAR(256) NULL,
	IsPublic BIT NOT NULL DEFAULT(0),
	Reputation INT NOT NULL DEFAULT(0)
)
GO

--// A banned and/or flagged user tied to a banlist header.
CREATE TABLE [ems_Banlist_Players]
(
	ID INT NOT NULL IDENTITY(101, 1) PRIMARY KEY,
	CreateDate DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	LastEditDate DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	InActive BIT NOT NULL DEFAULT(0),
	BanlistID INT NOT NULL,
	SteamUsername NVARCHAR(256) NOT NULL,
	SteamID NVARCHAR(256) NOT NULL,
	Details NVARCHAR(512) NOT NULL,
	IsBanned BIT DEFAULT(1) NOT NULL
)
GO



