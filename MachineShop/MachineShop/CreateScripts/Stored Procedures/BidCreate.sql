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
   --@CreatedDate Date = null,
   @CreatedBy varchar (max) = null, 
   @AcceptedDate date = null,
   @AcceptedBy varchar (max) = null,
   @Comments varchar (max) = null,
   @DeclineReason varchar(max) = null,
   @Declined bit = 0
   )  
as  
begin  
   Insert into Bids values(@ProjectId, @SupplierId, @Price, @Time, GETDATE(), @CreatedBy, @AcceptedBy, @AcceptedDate, @Comments, @DeclineReason, @Declined)  
End  