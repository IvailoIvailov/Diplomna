USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteSkill]    Script Date: 08/28/2018 16:00:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spDeleteSkill]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DELETE FROM
Discipline_Skills
WHERE Skills_ID = @pId
END

