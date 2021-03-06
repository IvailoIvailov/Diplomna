USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateUser]    Script Date: 08/28/2018 16:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[spUpdateUser]
	@pId int,
	@pUserName nvarchar(50),
	@pPassword nvarchar(max),
	@pEmail nvarchar(50),
	@pIsAdmin bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
UPDATE Users
SET UserName = @pUserName
	, [Password] = @pPassword
	, [Email] = @pEmail
	, IsAdmin = @pIsAdmin
WHERE 
	Id = @pId
END

