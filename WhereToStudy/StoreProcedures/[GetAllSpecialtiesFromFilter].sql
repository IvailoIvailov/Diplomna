USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetAllSpecialtiesFromFilter]    Script Date: 08/28/2018 15:59:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllSpecialtiesFromFilter]
	@pOks nvarchar(50),
	@pEducationForm nvarchar(50),
	@pName nvarchar(50)
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
Where
(s.Specialty_OKS = @pOks or @pOks = '-1')
AND (Specialty_Form_Education = @pEducationForm OR @pEducationForm = '-1')
AND (ISNULL(@pName,'') = '' OR Specialty_Name like '%' + @pName + '%')
END

