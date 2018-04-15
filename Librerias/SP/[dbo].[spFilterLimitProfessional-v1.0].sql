USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitProfessional-v1.0]    Script Date: 15/04/2018 13:18:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 22:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LastName VARCHAR(50) = null,
	@Pag INT = 1,		-- Id actual
	@RowsShow INT = 1,	-- Cantidad de filas a mostrar
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF (@Name = '' AND @LastName = '')                                                            --00
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [P].[Name] ASC) AS RowNum, [P].[IdProfessional], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',  [P].[Phone] AS 'Telefono', [P].[Mail] AS 'Correo',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[P].[Visible]
			FROM [dbo].[Professional] AS [P]
			INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
			--WHERE 
			--[Name] LIKE +'%'+ @Name +'%' AND
			--[LastName] LIKE +'%'+ @LastName +'%' AND 
			--[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	
	IF (@Name = '' AND @LastName != '')															--01                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [P].[Name] ASC) AS RowNum, [P].[IdProfessional], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',  [P].[Phone] AS 'Telefono', [P].[Mail] AS 'Correo',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[P].[Visible]
			FROM [dbo].[Professional] AS [P]
			INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
			WHERE 
			--[Name] LIKE +'%'+ @Name +'%' AND
			[LastName] LIKE +'%'+ @LastName +'%'  
			--[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END 

	IF (@Name != '' AND @LastName = '')															--10                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [P].[Name] ASC) AS RowNum, [P].[IdProfessional], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',  [P].[Phone] AS 'Telefono', [P].[Mail] AS 'Correo',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[P].[Visible]
			FROM [dbo].[Professional] AS [P]
			INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
			WHERE 
			[Name] LIKE +'%'+ @Name +'%' 
			--[LastName] LIKE +'%'+ @LastName +'%' AND 
			--[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	
	IF (@Name != '' AND @LastName != '')															--11                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [P].[Name] ASC) AS RowNum, [P].[IdProfessional], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',  [P].[Phone] AS 'Telefono', [P].[Mail] AS 'Correo',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[P].[Visible]
			FROM [dbo].[Professional] AS [P]
			INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
			WHERE 
			[Name] LIKE +'%'+ @Name +'%' AND
			[LastName] LIKE +'%'+ @LastName +'%' --AND 
			--[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END 
END
GO


