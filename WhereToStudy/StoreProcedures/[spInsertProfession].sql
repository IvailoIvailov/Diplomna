USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spInsertProfession]    Script Date: 08/28/2018 16:01:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[spInsertProfession]
	@pProfession_Name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

INSERT INTO Professions VALUES(@pProfession_Name)

END

