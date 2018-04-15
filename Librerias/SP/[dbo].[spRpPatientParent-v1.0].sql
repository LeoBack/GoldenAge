USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spRpPatientParent-v1.0]    Script Date: 15/04/2018 13:22:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- DescriptiON:	<Report RpPatientParent>
-- =============================================
CREATE PROCEDURE [dbo].[spRpPatientParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdPatient INT = 0,
	@Visible INT = 1
	AS
BEGIN
	SELECT	CONCAT([Pa].[LastName],', ',[Pa].[Name]) AS 'Nombre',
			[R].[Description] AS 'Relacion',
			CONCAT([Td].[Description],'-',[Pa].[NumberDocument]) AS 'Documento',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locacion',
			[Pa].[Address] AS 'Direccion', [Pa].[Phone] AS 'Telefono', 
			[Pa].[AlternativePhone] AS 'Telefono Alt.', [Pa].[Email] AS 'Correo' 
		FROM  PatientParent AS [Pp] 
		INNER JOIN Patient AS [P] ON [Pp].[IdPatient] = [P].[IdPatient]
		INNER JOIN Parent AS [Pa] ON [Pp].[IdParent] = [Pa].[IdParent]
		INNER JOIN LocationCountry AS [lCu] ON [Pa].[idLocationCountry] = [lCu].[idLocationCountry]
		INNER JOIN LocationProvince AS [lPv] ON [Pa].[idLocationProvince] = [lPv].[idLocationProvince]
		INNER JOIN LocationCity AS [lCy] ON [Pa].[idLocationCity] = [lCy].[idLocationCity]
		INNER JOIN Relationship AS [R] ON [Pp].[IdRelationship] = [R].[IdRelationship]
		INNER JOIN TypeDocument AS [Td] ON [Pa].[IdTypeDocument] = [Td].[IdTypeDocument]
 		WHERE [P].[IdPatient] = @IdPatient AND [Pp].[Visible] = @Visible		
END
GO


