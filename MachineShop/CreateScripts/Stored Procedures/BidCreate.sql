USE [MachineShop]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateBid]  
(  
   
   @ProjectId int,
   @SupplierId int,
   @Price decimal(9,2),  
   @Time varchar (max), 
   @QualityLevel varchar (max) = null,
   --@CreatedDate Date = null,
   @CreatedBy varchar (max) = null, 
   @AcceptedDate date = null,
   @AcceptedBy varchar (max) = null
   )  
as  
begin  
   Insert into Bids values(@ProjectId, @SupplierId, @Price, @Time, @QualityLevel, GETDATE(), @CreatedBy, @AcceptedBy, @AcceptedDate)  
End  