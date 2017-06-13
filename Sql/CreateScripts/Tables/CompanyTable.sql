/*
   Thursday, December 8
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
CREATE TABLE dbo.Company
	(
	ID int IDENTITY(1,1) NOT NULL,
	CompanyName varchar(MAX) NULL,
	StreetAddress varchar(MAX) NULL,
	StreetAddress2 varchar(MAX) NULL,
	City varchar(MAX) NULL,
	State varchar(MAX) NULL,
	ZipCode varchar(10) NULL,
	Phone varchar(20) NULL,
	CreatedDate date NOT NULL,
	LastEdit date NULL,
	EditedBy varchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Company ADD CONSTRAINT
	PK_Company PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Company SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
