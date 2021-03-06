USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSpecialty]    Script Date: 08/28/2018 16:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spUpdateSpecialty]
	@pSpecialty_ID int,
	@pSpecialty_Name nvarchar(50),
	@pSpecialty_OKS nvarchar(50),
	@pSpecialty_Form_Education nvarchar(50),
	@pSpecialty_Description nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
UPDATE Specialties
SET Specialty_Name = @pSpecialty_Name
	, Specialty_OKS = @pSpecialty_OKS
	, Specialty_Form_Education = @pSpecialty_Form_Education
	, Specialty_Description = @pSpecialty_Description
WHERE 
	Specialty_ID = @pSpecialty_ID
END

