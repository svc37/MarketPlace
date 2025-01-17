/*
   Thursday, December 8, 20162:09:59 PM
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

CREATE TABLE dbo.Projects
	(
	ID int NOT NULL IDENTITY (1, 1),
	CompanyId int NOT NULL,
	SupplierId int NULL,
	[FileName] varchar(MAX) NOT NULL,
	CreatedDate date NOT NULL,
	CreatedBy varchar(MAX) NOT NULL,
	EditedDate date NULL,
	EditedBy varchar(MAX) NULL,
	MachineType int NOT NULL,
	Quantity int NULL,
	Material int NOT NULL,
	Dimensions varchar(MAX) NULL, --might need to break this down in to 3 fields.  Hiding in the UI for now. 
	AcceptedBy varchar(max) NULL,
	AcceptedDate date NULL,
	ProjectName varchar(max) NULL

	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Projects ADD CONSTRAINT
	PK_Projects PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Projects ADD CONSTRAINT
	FK_Projects_Company FOREIGN KEY
	(
	CompanyId
	) REFERENCES dbo.Company
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Projects ADD CONSTRAINT
	FK_Projects_Company1 FOREIGN KEY
	(
	SupplierId
	) REFERENCES dbo.Company
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Projects SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
