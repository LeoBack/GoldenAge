USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessional-v1.0]    Script Date: 09/11/2017 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report spRpOnlyProfessional>
-- =============================================
ALTER PROCEDURE [dbo].[spRpOnlyProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdProfessional INT = 0,
	@Visible INT = 1
	AS
	BEGIN				
		SELECT	[P].[IdProfessional] AS 'Id',
				CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',
				[ProfessionalRegistration] AS 'Registro Profesional', 
				CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locacion',
				[P].[Address] AS 'Direccion',
				[P].[Phone] AS 'Telefono',
				[P].[Mail] AS 'Correo'
		FROM Professional AS [P]
		INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
		INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
		INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
		WHERE [P].[IdProfessional] = @IdProfessional AND [P].[Visible] = @Visible
	END