USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSkill]    Script Date: 08/28/2018 16:01:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[spUpdateSkill]
@pId int,
	@pName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
UPDATE Skills
SET Skills_Name = @pName
WHERE 
	Skills_ID = @pId
END

