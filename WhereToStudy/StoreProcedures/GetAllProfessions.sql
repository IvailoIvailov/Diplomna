USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetAllProfessions]    Script Date: 08/28/2018 15:58:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[GetAllProfessions]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT 
Profession_ID,
Profession_Name	

FROM Professions
END

