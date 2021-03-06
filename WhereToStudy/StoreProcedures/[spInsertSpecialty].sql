USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spInsertSpecialty]    Script Date: 08/28/2018 16:01:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[spInsertSpecialty]
	@pSpecialty_Name nvarchar(50),
	@pSpecialty_OKS nvarchar(50),
	@pSpecialty_Form_Education nvarchar(50),
	@pSpecialty_Description nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
DECLARE @pId int
SET @pId = @@IDENTITY
SET  @pId  = (SELECT MAX(Specialty_ID) FROM  [dbo].Specialties)

INSERT INTO Specialties VALUES(@pSpecialty_Name,
@pSpecialty_OKS,@pSpecialty_Form_Education,@pSpecialty_Description)

END

