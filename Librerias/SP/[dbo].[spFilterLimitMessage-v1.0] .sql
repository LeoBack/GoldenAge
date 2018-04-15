USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitMessage-v1.0]    Script Date: 15/04/2018 13:17:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
--- Author:		<Back Leonardo>
-- Create date: <2017/11/20 18:00>
-- Description:	<Lista con paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitMessage-v1.0] 
	-- Add the parameters for the stored procedure here
	@DestinationRead INT = 1,
	@IdProfessional INT = 0,
	@IdSpeciality INT = 0,
	@Pag INT = 1,		-- Id actual
	@RowsShow INT = 1,	-- Cantidad de filAS a mostrar
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	 
	IF (@IdProfessional = 0 AND @IdSpeciality = 0)                                                            --00
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [D].[Date] ASC) AS RowNum, [D].[idDiagnostic], [D].[Date] AS 'Fecha',
			CONCAT([Pr].[LAStName],', ', [Pr].[Name]) AS 'Enviado por',
			[S].[Description] AS 'Especialidad',
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[Visible]
			FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			--AND [D].[IdDestinationSpeciality] = @IdSpeciality
			--AND [D].[IdDestinationProfessional] = @IdProfessional
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	
	IF (@IdProfessional = 0 AND @IdSpeciality != 0) 															--01                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [D].[Date] ASC) AS RowNum, [D].[idDiagnostic], [D].[Date] AS 'Fecha',
			CONCAT([Pr].[LAStName],', ', [Pr].[Name]) AS 'Enviado por',
			[S].[Description] AS 'Especialidad',
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[Visible]
			FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			AND [D].[IdDestinationSpeciality] = @IdSpeciality
			--AND [D].[IdDestinationProfessional] = @IdProfessional
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END 

	IF (@IdProfessional != 0 AND @IdSpeciality = 0) 														--10                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [D].[Date] ASC) AS RowNum, [D].[idDiagnostic], [D].[Date] AS 'Fecha',
			CONCAT([Pr].[LAStName],', ', [Pr].[Name]) AS 'Enviado por',
			[S].[Description] AS 'Especialidad',
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[Visible]
			FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			--AND [D].[IdDestinationSpeciality] = @IdSpeciality
			AND [D].[IdDestinationProfessional] = @IdProfessional
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	
	IF (@IdProfessional != 0 AND @IdSpeciality != 0) 														--11                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [D].[Date] ASC) AS RowNum, [D].[idDiagnostic], [D].[Date] AS 'Fecha',
			CONCAT([Pr].[LAStName],', ', [Pr].[Name]) AS 'Enviado por',
			[S].[Description] AS 'Especialidad',
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[Visible]
			FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			AND [D].[IdDestinationSpeciality] = @IdSpeciality
			AND [D].[IdDestinationProfessional] = @IdProfessional
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END 
END
GO


