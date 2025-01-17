/*
   Thursday, December 8, 20162:22:52 PM
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
CREATE TABLE dbo.Bids
	(
	ID int IDENTITY(1,1) NOT NULL,
	ProjectId int NOT NULL,
	SupplierId int NOT NULL,
	Price decimal(9, 2) NULL,
	Time varchar(MAX) NULL,
	CreatedDate date NULL,
	CreatedBy varchar(max) NULL,
	AcceptedDate date NULL,
	AcceptedBy varchar(max),
	Comments varchar(max),
	Declined bit null,
	DeclineReason varchar(max) null

	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Bids ADD CONSTRAINT
	PK_Bids PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Bids ADD CONSTRAINT
	FK_Bids_Projects FOREIGN KEY
	(
	ProjectId
	) REFERENCES dbo.Projects
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Bids ADD CONSTRAINT
	FK_Bids_Company FOREIGN KEY
	(
	SupplierId
	) REFERENCES dbo.Company
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Bids SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
