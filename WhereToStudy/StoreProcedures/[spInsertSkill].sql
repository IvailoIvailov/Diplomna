USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spInsertSkill]    Script Date: 08/28/2018 16:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[spInsertSkill]
	@pSkill_Name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

INSERT INTO Skills VALUES(@pSkill_Name)

END

