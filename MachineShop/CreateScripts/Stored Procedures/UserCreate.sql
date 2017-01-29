Create procedure [dbo].[CreateUser]  
(  
   
   @CompanyName varchar (max),
   @StreetAddress varchar (max),
   @StreetAddress2 varchar (max) = null,  
   @City varchar (max),  
   @State varchar (max),
   @ZipCode varchar (10),
   @Email varchar (max),
   @Phone varchar (20)
  

)  
as  
begin  
   Insert into Users values(@CompanyName, @StreetAddress, @StreetAddress2, @City, @State, @ZipCode, @Email, @Phone, GETDATE(), null, null )  
End  