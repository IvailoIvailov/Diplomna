USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetDiscipline]    Script Date: 08/28/2018 15:59:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetDiscipline]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	d.Discipline_ID,
	d.Specialty_ID,
	d.Discipline_Name,
	d.Discipline_Semester
FROM Disciplines d
Where d.Discipline_ID = @pId
END

