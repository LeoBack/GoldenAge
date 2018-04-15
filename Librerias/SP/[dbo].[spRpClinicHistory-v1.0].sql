USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spRpClinicHistory-v1.0]    Script Date: 15/04/2018 13:20:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report spRpClinicHistory>
-- =============================================
CREATE PROCEDURE [dbo].[spRpClinicHistory-v1.0] 
	-- Add the parameters for the stored procedure here
	@Id INT = 0,
	@Only INT = 1,  -- 1= Un Diagnostico / 2= Todos los diagnosticos
	@Visible INT = 1
	AS
	BEGIN
	IF (@Only = 2)
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
			WHERE [D].[IdPatient] = @Id AND [D].[Visible] = @Visible
			--WHERE [D].[IdPatient] = 2 --AND [D].[Visible] = @Visible
			ORDER BY 'FECHA'
		END
	ELSE
		BEGIN
			SELECT [D].[idDiagnostic], [S].[Description] AS 'Especialidad',
				CONCAT([Pr].[LastName],', ', [Pr].[Name]) AS 'Profesional', 
				[D].[Detail] AS 'Detalle', [D].[Date] as 'Fecha',    
				(SELECT CONCAT([Prd].[LastName],', ', [Prd].[Name]) FROM Professional AS [Prd] WHERE [D].[IdDestinationProfessional] = [Prd].[IdProfessional])  AS 'Profesional Destino',
				[D].[IdDestinationProfessional],
				(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
				[d].[IdDestinationSpeciality]
			FROM Diagnostic AS [D]
				INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
				INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[idDiagnostic] = @Id AND [D].[Visible] = @Visible
			ORDER BY 'FECHA'
	END
END
GO


