USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteProfession]    Script Date: 08/28/2018 16:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spDeleteProfession]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DELETE FROM
Professions
WHERE Profession_ID = @pId
END

