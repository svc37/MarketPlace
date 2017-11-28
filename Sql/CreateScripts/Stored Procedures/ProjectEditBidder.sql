USE [MachineShop]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[EditProjectBidder]  
(  
   @Id int,
   @AcceptedBy varchar(max),
   @SupplierId int  
  )  
as  
begin  
	Update Projects
	set
	AcceptedDate = GETDATE(),
	AcceptedBy = @AcceptedBy,
    SupplierId = @SupplierId 
	
	where ID = @Id
End  