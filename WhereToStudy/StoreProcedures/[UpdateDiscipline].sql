USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[UpdateDiscipline]    Script Date: 08/28/2018 16:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UpdateDiscipline]
	@pId int,
	@pName nvarchar(50),
	@pSemester int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
UPDATE Disciplines
SET Discipline_Name = @pName
	, Discipline_Semester = @pSemester
WHERE 
	Discipline_ID = @pId
END

