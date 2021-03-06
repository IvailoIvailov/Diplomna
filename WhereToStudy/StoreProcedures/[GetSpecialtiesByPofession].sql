USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetSpecialtiesByPofession]    Script Date: 08/28/2018 16:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetSpecialtiesByPofession]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	sp.Specialty_ID,
	sp.Specialty_Name,
	sp.Specialty_OKS,
	sp.Specialty_Form_Education,
	sp.Specialty_Description
FROM 
	Professions prof
	LEFT JOIN Profession_Skills prSkills ON prof.Profession_ID = prSkills.Profession_ID
	LEFT JOIN Skills s ON prSkills.Skills_ID = s.Skills_ID
	LEFT JOIN Discipline_Skills dsSkills ON s.Skills_ID = dsSkills.Skills_ID
	LEFT JOIN Disciplines d ON dsSkills.Discipline_ID = d.Discipline_ID
	LEFT JOIN Specialties sp ON d.Specialty_ID = sp.Specialty_ID
WHERE 
	prof.Profession_ID = @pId
	and sp.Specialty_Name is not null
	GROUP BY sp.Specialty_ID,
	sp.Specialty_Name,
	sp.Specialty_OKS,
	sp.Specialty_Form_Education,
	sp.Specialty_Description
END

