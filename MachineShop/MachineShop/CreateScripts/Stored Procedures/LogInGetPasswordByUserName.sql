USE [MachineShop]
GO

/****** Object:  StoredProcedure [dbo].[CreateBuyer]    Script Date: 12/4/2016 9:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetPasswordByUserName]  
(  
   
  @Email varchar(max)
  
)  
as  
begin  
   Select [Password], Salt From [LogIn] where Email = @Email  
End  
