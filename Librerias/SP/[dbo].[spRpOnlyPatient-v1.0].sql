USE [GOLDENAGE-03.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spRpOnlyPatient-v1.0]    Script Date: 15/04/2018 13:30:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report RpOnlyPatient>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyPatient-v1.0] 
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
			   [AffiliateNumber] AS 'N. Afiliado',
			   [So].[Name] AS 'Obra Social',
			   [DateAdmission] AS 'Ingreso',
			   [EgressDate] AS 'Egreso',
			   [ReasonExit] AS 'Motivo egreso'
		FROM [dbo].[Patient] AS [P]
		INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
		INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
		INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE [P].[IdPatient] = @IdPatient
	END
GO


