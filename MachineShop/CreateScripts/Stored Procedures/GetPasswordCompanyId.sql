USE [MachineShop]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetPasswordCompanyId]  
(  
   
  @Email varchar(max)
  
)  
as  
begin  
   Select CompanyId From [LogIn] where Email = @Email 
End  
