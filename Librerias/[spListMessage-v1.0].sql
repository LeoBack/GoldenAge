USE [DEFAULT02.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spListProfessional-v1.0]    Script Date: 14/11/2017 20:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spListMessage-v1.0] 
	-- Add the parameters for the stored procedure here
	@DestinationRead INT = 1,
	@IdProfessional INT = 0,
	@IdSpeciality INT = 0,
	@Visible INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	 
	IF (@IdProfessional = 0 AND @IdSpeciality = 0)                                                            --00
	BEGIN
		SELECT [D].[idDiagnostic], [S].[Description] AS 'Especialidad',
			CONCAT([Pr].[LastName],', ', [Pr].[Name]) AS 'Profesional', 
			[D].[Detail] AS 'Detalle', [D].[Date] as 'Fecha',    
			(SELECT CONCAT([Prd].[LastName],', ', [Prd].[Name]) FROM Professional AS [Prd] WHERE [D].[IdDestinationProfessional] = [Prd].[IdProfessional])  AS 'Profesional Destino',
			[d].[IdDestinationProfessional],
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[IdDestinationSpeciality]
		FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
		WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			--AND [D].[IdDestinationSpeciality] = @IdSpeciality
			--AND [D].[IdDestinationProfessional] = @IdProfessional
		ORDER BY 'FECHA'
	END
	
	IF (@IdProfessional = 0 AND @IdSpeciality != 0) 															--01                                                
	BEGIN
		SELECT [D].[idDiagnostic], [S].[Description] AS 'Especialidad',
			CONCAT([Pr].[LastName],', ', [Pr].[Name]) AS 'Profesional', 
			[D].[Detail] AS 'Detalle', [D].[Date] as 'Fecha',    
			(SELECT CONCAT([Prd].[LastName],', ', [Prd].[Name]) FROM Professional AS [Prd] WHERE [D].[IdDestinationProfessional] = [Prd].[IdProfessional])  AS 'Profesional Destino',
			[d].[IdDestinationProfessional],
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[IdDestinationSpeciality]
		FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
		WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			AND [D].[IdDestinationSpeciality] = @IdSpeciality
			--AND [D].[IdDestinationProfessional] = @IdProfessional
		ORDER BY 'FECHA'
	END 

	IF (@IdProfessional != 0 AND @IdSpeciality = 0) 														--10                                                
	BEGIN
		SELECT [D].[idDiagnostic], [S].[Description] AS 'Especialidad',
			CONCAT([Pr].[LastName],', ', [Pr].[Name]) AS 'Profesional', 
			[D].[Detail] AS 'Detalle', [D].[Date] as 'Fecha',    
			(SELECT CONCAT([Prd].[LastName],', ', [Prd].[Name]) FROM Professional AS [Prd] WHERE [D].[IdDestinationProfessional] = [Prd].[IdProfessional])  AS 'Profesional Destino',
			[d].[IdDestinationProfessional],
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[IdDestinationSpeciality]
		FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
		WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			--AND [D].[IdDestinationSpeciality] = @IdSpeciality
			AND [D].[IdDestinationProfessional] = @IdProfessional
		ORDER BY 'FECHA'
	END
	
	IF (@IdProfessional != 0 AND @IdSpeciality != 0) 														--11                                                
	BEGIN
		SELECT [D].[idDiagnostic], [S].[Description] AS 'Especialidad',
			CONCAT([Pr].[LastName],', ', [Pr].[Name]) AS 'Profesional', 
			[D].[Detail] AS 'Detalle', [D].[Date] as 'Fecha',    
			(SELECT CONCAT([Prd].[LastName],', ', [Prd].[Name]) FROM Professional AS [Prd] WHERE [D].[IdDestinationProfessional] = [Prd].[IdProfessional])  AS 'Profesional Destino',
			[d].[IdDestinationProfessional],
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[IdDestinationSpeciality]
		FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
		WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			AND [D].[IdDestinationSpeciality] = @IdSpeciality
			AND [D].[IdDestinationProfessional] = @IdProfessional
		ORDER BY 'FECHA'
	END 
END