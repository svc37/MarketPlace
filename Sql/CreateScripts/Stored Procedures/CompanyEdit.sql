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