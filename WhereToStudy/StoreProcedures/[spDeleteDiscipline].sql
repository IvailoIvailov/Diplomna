USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteDiscipline]    Script Date: 08/28/2018 16:00:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spDeleteDiscipline]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DELETE FROM Discipline_Skills WHERE Discipline_ID = @pId

DELETE FROM
Disciplines
WHERE Discipline_ID = @pId
END

