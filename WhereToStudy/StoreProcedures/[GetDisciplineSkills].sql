USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetDisciplineSkills]    Script Date: 08/28/2018 15:59:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetDisciplineSkills]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	s.Skills_ID,
	s.Skills_Name
FROM Disciplines d
LEFT JOIN Discipline_Skills ds ON d.Discipline_ID = ds.Discipline_ID
LEFT JOIN Skills s ON ds.Skills_ID = s.Skills_ID
Where d.Discipline_ID = @pId
END

