USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetProfessionSkills]    Script Date: 08/28/2018 15:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetProfessionSkills]
	@professionId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	s.Skills_ID,
	s.Skills_Name
FROM Professions p
LEFT JOIN Profession_Skills ps ON p.Profession_ID = ps.Profession_ID
LEFT JOIN Skills s ON ps.Skills_ID = s.Skills_ID
Where p.Profession_ID = @professionId
END

