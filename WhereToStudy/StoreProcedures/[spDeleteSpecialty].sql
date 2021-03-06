USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteSpecialty]    Script Date: 08/28/2018 16:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spDeleteSpecialty]
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DELETE FROM Discipline_Skills WHERE Discipline_ID IN
(SELECT Discipline_ID FROM Disciplines WHERE Specialty_ID = @pId)
DELETE FROM Disciplines WHERE Specialty_ID = @pId

DELETE FROM
Specialties
WHERE Specialty_Id = @pId
END

