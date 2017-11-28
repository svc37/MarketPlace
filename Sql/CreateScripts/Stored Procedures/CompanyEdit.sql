USE [MachineShop]
GO

/****** Object:  StoredProcedure [dbo].[CreateBuyer]    Script Date: 12/4/2016 9:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[EditCompany]  
(  
   @Id int,
   @CompanyName varchar (max),
   @StreetAddress varchar (max),
   @StreetAddress2 varchar  (max) = null,
   @City varchar (max),  
   @State varchar (max),
   @ZipCode varchar (10),
   --@Email varchar (max),
   @Phone varchar (20),
   @EditedBy varchar(max)
  

)  
as  
begin  
	Update Company
	set
	CompanyName = @CompanyName, 
	StreetAddress = @StreetAddress,
	StreetAddress2 = @StreetAddress2,
    City = @City, 
	[State] = @State,
	ZipCode = @ZipCode, 
	Phone = @Phone, 
	LastEdit = GETDATE(),
	EditedBy = @EditedBy
	where ID = @Id
End  