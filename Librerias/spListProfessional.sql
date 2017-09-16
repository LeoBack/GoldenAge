USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spListProfessional-v1.0]    Script Date: 16/09/2017 07:56:01 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 17:36>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spListProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(20) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	if(@Name!='')
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[Phone]
		FROM [dbo].[Professional]
		WHERE [Name] like +'%'+ @Name +'%'
		AND [Visible] = @Visible
		Order by [Name]
	END
	if(@Name='')
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[Phone]
		FROM [dbo].[Professional]
		WHERE 
		--[Name] like +'%'+ @Name +'%' AND 
		[Visible] = @Visible
		Order by [Name]
	END
END