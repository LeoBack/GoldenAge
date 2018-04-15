USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spRpOnlyPatient-v1.1]    Script Date: 15/04/2018 13:21:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/08 21:18>
-- Description:	<Report RpOnlyPatient>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyPatient-v1.1] 
	-- Add the parameters for the stored procedure here
	@IdPatient INT = 0
	AS
	BEGIN
		SELECT [P].[IdPatient] AS 'Id',
		       CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			   [Birthdate] AS 'Fecha Nacimiento',
			   CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [dbo].[StringSex]([Sex]) AS 'Sexo',
			   CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locacion',
			   [P].[Address] AS 'Direccion',
			   [P].[Phone] AS 'Telefono',
			   [DateAdmission] AS 'Ingreso',
			   [EgressDate] AS 'Egreso',
			   [ReasonExit] AS 'Motivo egreso'
		FROM [dbo].[Patient] AS [P]
		INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
		INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
		INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE [P].[IdPatient] = @IdPatient
	END
GO


