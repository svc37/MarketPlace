Create procedure [dbo].[EditProject]  
(  
   @Id int,
   @EditedBy varchar(max),
   @MachineType int,  
   @Quantity int,
   @Material varchar (max),
   @Size varchar (max),
   @Dimensions varchar (max),
   @Tolerance varchar (max),
   @Volume varchar (max)
  
)  
as  
begin  
	Update Projects
	set
	EditedDate = GETDATE(),
	EditedBy = @EditedBy,
    MachineType = @MachineType, 
	Quantity = @Quantity,
	Material = @Material, 
	Size = @Size, 
	Dimensions = @Dimensions, 
	Tolerance = @Tolerance,
	Volume = @Volume
	where ID = @Id
End  