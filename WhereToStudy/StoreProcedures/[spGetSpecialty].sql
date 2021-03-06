USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spGetSpecialty]    Script Date: 08/28/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spGetSpecialty]
	@pId int
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
Where s.Specialty_ID = @pId
END

