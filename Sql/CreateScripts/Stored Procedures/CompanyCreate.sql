USE [MachineShop]
GO

/****** Object:  StoredProcedure [dbo].[CreateBuyer]    Script Date: 12/4/2016 9:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[CreateCompany]  
(  
   
   @CompanyName varchar (max),
   @StreetAddress varchar (max),
   @StreetAddress2 varchar (max) = null,  
   @City varchar (max),  
   @State varchar (max),
   @ZipCode varchar (10),
   @Phone varchar (20),
   @tableId int OUTPUT

)  
as  
begin  
   Insert into Company values(@CompanyName, @StreetAddress, @StreetAddress2, @City, @State, @ZipCode, @Phone, GETDATE(), null, null )  
   SELECT @tableId = SCOPE_IDENTITY()
End  

