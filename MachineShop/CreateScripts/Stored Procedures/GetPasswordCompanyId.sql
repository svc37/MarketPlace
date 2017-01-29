USE [MachineShop]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetPasswordCompanyId]  
(  
   
  @UserName varchar(max)
  
)  
as  
begin  
   Select UserId From [LogIn] where UserName = @UserName  
End  
