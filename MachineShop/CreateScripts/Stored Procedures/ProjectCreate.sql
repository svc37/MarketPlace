USE [MachineShop]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateProject]  
(  
   
   @CompanyId int,
   @SupplierId int = null,
   @FileName varchar (max),
   @CreatedBy varchar (max) = null,  
   @MachineType int,  
   @Quantity int,
   @Material int,
   @Dimensions varchar (max),
   @ProjectName varchar(max)

)  
as  
begin  
   Insert into Projects values(@CompanyId, @SupplierId, @FileName, GETDATE(), @CreatedBy, NULL, Null, @MachineType, @Quantity, @Material, @Dimensions, null, null, @ProjectName )  
End  