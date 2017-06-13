use [MachineShop]
go
Create procedure [dbo].[EditBid]  
(  
	@Id int,
   @ProjectId int,
   @SupplierId int,
   @Price decimal(9,2),  
   @Time varchar (max), 
   --@CreatedDate Date = null,
   @CreatedBy varchar (max) = null, 
   @AcceptedDate date = null,
   @AcceptedBy varchar (max) = null,
   @Comments varchar (max) = null,
   @DeclineReason varchar (max) = null,
   @Declined bit = 0
  
)  
as  
begin  
	Update Bids
	set
	ProjectId = @ProjectId,
	SupplierId = @SupplierId,
    Price = @Price, 
	Time = @Time,
	CreatedBy = @CreatedBy, 
	AcceptedDate = @AcceptedDate, 
	AcceptedBy = @AcceptedBy,
	Comments = @Comments,
	DeclineReason = @DeclineReason,
	Declined = @Declined

	where ID = @Id
End  