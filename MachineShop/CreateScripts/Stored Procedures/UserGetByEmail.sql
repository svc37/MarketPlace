USE [MachineShop]
GO

/****** Object:  StoredProcedure [dbo].[CreateBuyer]    Script Date: 1/23/2017  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetUserByEmail]  
(  
   
  @Email varchar(MAX)
  
)  
as  
begin  
   Select * From Users where Email = @Email
End  

