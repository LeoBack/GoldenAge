USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitSocialWorks-v1.0]    Script Date: 15/04/2018 13:18:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 18:00>
-- Description:	<Lista con paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitSocialWorks-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@Pag INT = 1,		-- Id actual
	@RowsShow INT = 1,	-- Cantidad de filAS a mostrar
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF (@Name!='')
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [S].[Name] ASC) AS RowNum, [S].[IdSocialWork],
			[S].[Name] AS 'Razon Social', [S].[Description] AS 'Descripción', [S].[Phone] AS 'Telefono',[S].[Contact] AS 'Contacto', 
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[S].[Address] AS 'Direccion', [S].[Visible]
			FROM [dbo].[SocialWork] AS [S]
			INNER JOIN LocationCountry AS [lCu] ON [S].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [S].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [S].[idLocationCity] = [lCy].[idLocationCity]
			WHERE [S].[Name] LIKE +'%'+ @Name +'%'
			--AND [Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF (@Name='')
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [S].[Name] ASC) AS RowNum, [S].[IdSocialWork],
			[S].[Name] AS 'Razon Social', [S].[Description] AS 'Descripción', [S].[Phone] AS 'Telefono',[S].[Contact] AS 'Contacto', 
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[S].[Address] AS 'Direccion', [S].[Visible]
			FROM [dbo].[SocialWork] AS [S]
			INNER JOIN LocationCountry AS [lCu] ON [S].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [S].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [S].[idLocationCity] = [lCy].[idLocationCity]
			--WHERE [Name] LIKE +'%'+ @Name +'%'
			--AND [Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
END
GO


