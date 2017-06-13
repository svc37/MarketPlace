use [MachineShop]
go
Create procedure [dbo].[EditProject]  
(  

   @Id int,
   @CompanyId int,
   @SupplierId int = null,
   @FileName varchar (max),
   @CreatedBy varchar (max) = null,  
   @MachineType int,  
   @Quantity int,
   @Material varchar (max),
   @Dimensions varchar (max),
   @ProjectName varchar (max)
  
)  
as  
begin  
	Update Projects
	set
	CompanyId = @CompanyId,
	SupplierId = @SupplierId,
    [FileName] = @FileName, 
	CreatedBy = @CreatedBy,
	MachineType = @MachineType, 
	Quantity = @Quantity, 
	Material = @Material, 
	Dimensions = @Dimensions,
	ProjectName = @ProjectName
	

	where ID = @Id
End  