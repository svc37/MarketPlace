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

