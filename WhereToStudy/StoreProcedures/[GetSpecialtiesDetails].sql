USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetSpecialtiesDetails]    Script Date: 08/28/2018 16:00:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetSpecialtiesDetails]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	s.Specialty_ID,
	s.Specialty_Name,
	d.Discipline_ID,
	d.Discipline_Name,
	d.Discipline_Semester
FROM Specialties s
LEFT JOIN Disciplines d on s.Specialty_ID = d.Specialty_ID

Where s.Specialty_ID = @pId
END

