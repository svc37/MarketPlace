/*
   Friday, January 20, 201710:02:14 PM
   User: 
   Server: SHAUN\SQLEXPRESS
   Database: MachineShop
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
USE [MachineShop]
GO

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Company SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.LogIn
	(
	ID int NOT NULL IDENTITY (1, 1),
	CompanyId int NOT NULL,
	Email varchar(MAX) NOT NULL,
	Password nvarchar(128) NOT NULL,
	Salt nvarchar(128) NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.LogIn ADD CONSTRAINT
	PK_LogIn PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.LogIn ADD CONSTRAINT
	FK_LogIn_Company FOREIGN KEY
	(
	CompanyId
	) REFERENCES dbo.Company
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LogIn SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
