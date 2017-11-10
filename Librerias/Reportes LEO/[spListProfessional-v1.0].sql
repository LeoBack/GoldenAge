USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spListProfessional-v1.0]    Script Date: 09/11/2017 12:34:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 17:36>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
ALTER PROCEDURE [dbo].[spListProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LastName VARCHAR(50) = null,
	@Desde INT = 1,
	@Hasta INT = 1,
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	 
	if(@Name = '' AND @LastName = '')                                                            --00
	BEGIN
		SELECT [IdProfessional], [Name] AS 'Nombre',[LastName] AS 'Apellido', [Phone] AS 'Telefono', [Visible]
		FROM [dbo].[Professional]
		--WHERE 
		--[Name] LIKE +'%'+ @Name +'%' AND
		--[LastName] LIKE +'%'+ @LastName +'%' AND 
		--[Visible] = @Visible
		ORDER BY [Name]
	END
	
	if(@Name = '' AND @LastName != '')															--01                                                
	BEGIN
		SELECT [IdProfessional], [Name] AS 'Nombre',[LastName] AS 'Apellido', [Phone] AS 'Telefono', [Visible]
		FROM [dbo].[Professional]
		WHERE 
		--[Name] LIKE +'%'+ @Name +'%' AND
		[LastName] LIKE +'%'+ @LastName +'%'  
		--[Visible] = @Visible
		ORDER BY [Name]
	END 

	if(@Name != '' AND @LastName = '')															--10                                                
	BEGIN
		SELECT [IdProfessional], [Name] AS 'Nombre',[LastName] AS 'Apellido', [Phone] AS 'Telefono', [Visible]
		FROM [dbo].[Professional]
		WHERE 
		[Name] LIKE +'%'+ @Name +'%' 
		--[LastName] LIKE +'%'+ @LastName +'%' AND 
		--[Visible] = @Visible
		ORDER BY [Name]
	END
	
	if(@Name != '' AND @LastName != '')															--11                                                
	BEGIN
		SELECT [IdProfessional], [Name] AS 'Nombre',[LastName] AS 'Apellido', [Phone] AS 'Telefono', [Visible]
		FROM [dbo].[Professional]
		WHERE 
		[Name] LIKE +'%'+ @Name +'%' AND
		[LastName] LIKE +'%'+ @LastName +'%' --AND 
		--[Visible] = @Visible
		ORDER BY [Name]
	END 
END