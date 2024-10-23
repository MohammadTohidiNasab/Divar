USE [DivarDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertComment]    Script Date: 10/23/2024 10:43:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_InsertComment]
    @Body NVARCHAR(400),
    @CreatedDate DATETIME
AS
BEGIN
    INSERT INTO Comments (Body, CreatedDate)
    VALUES (@Body, @CreatedDate)
END