USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetSpecialtySkills]    Script Date: 08/28/2018 16:00:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetSpecialtySkills]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	s.Skills_ID,
	s.Skills_Name
FROM Specialties sp
LEFT JOIN Disciplines d On sp.Specialty_ID = d.Specialty_ID
LEFT JOIN Discipline_Skills ds ON d.Discipline_ID = ds.Discipline_ID
LEFT JOIN Skills s ON ds.Skills_ID = s.Skills_ID
Where sp.Specialty_ID = @pId
AND ISNULL(Skills_Name ,'') != ''
END

