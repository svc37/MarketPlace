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
   @Size varchar (max),
   @Dimensions varchar (max),
   @Tolerance varchar (max),
   @Volume varchar (max),
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
	Size = @Size,
	Dimensions = @Dimensions,
	Tolerance = @Tolerance,
	Volume = @Volume,
	ProjectName = @ProjectName
	

	where ID = @Id
End  