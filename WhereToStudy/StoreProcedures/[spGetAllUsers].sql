USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllUsers]    Script Date: 08/28/2018 16:00:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spGetAllUsers]
	@pUserName nvarchar(50),
	@pPassword nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	u.Id,
	u.UserName,
	u.[Password],
	u.Email,
	u.IsAdmin
FROM Users u
END

