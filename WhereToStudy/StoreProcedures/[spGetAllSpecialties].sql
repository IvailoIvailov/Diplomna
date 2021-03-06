USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllSpecialties]    Script Date: 08/28/2018 16:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spGetAllSpecialties]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	s.Specialty_ID,
	s.Specialty_Name,
	s.Specialty_OKS,
	s.Specialty_Form_Education,
	s.Specialty_Description
FROM Specialties s
END
