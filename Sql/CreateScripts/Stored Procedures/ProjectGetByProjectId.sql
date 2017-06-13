USE [MachineShop]
GO

/****** Object:  StoredProcedure [dbo].[CreateBuyer]    Script Date: 12/4/2016 9:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetProjectByProjectId]  
(  
   
  @Id int
  
)  
as  
begin  
   Select * From Projects where ID = @Id  
End  
