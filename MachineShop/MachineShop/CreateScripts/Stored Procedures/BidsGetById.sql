USE [MachineShop]
GO

/****** Object:  StoredProcedure [dbo].[GetBidsById]    Script Date: 02/03/2017 9:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetBidsById]  
(  
   
  @BidId int
  
)  
as  
begin  
   Select * From Bids where ID = @BidId 
End  
