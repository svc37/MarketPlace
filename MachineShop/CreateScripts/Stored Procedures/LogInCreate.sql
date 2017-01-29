USE [MachineShop]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateLogIn]  
(  
   
   @CompanyId int,
   @UserName varchar (max) = null,  
   @Password nvarchar(128),  
   @Salt nvarchar(128)
  

)  
as  
begin  
   Insert into LogIn values(@CompanyId, @UserName, @Password, @Salt )  
End  