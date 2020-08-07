USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spInsertUser]    Script Date: 08/28/2018 16:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[spInsertUser]
	@pUserName nvarchar(50),
	@pPassword nvarchar(50),
	@pEmail nvarchar(50),
	@pIsAdmin bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO Users VALUES(@pUserName,@pPassword,@pEmail,@pIsAdmin)

END

