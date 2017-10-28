USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyPatient-v1.0]    Script Date: 28/10/2017 06:21:35 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 18:39>
-- Description:	<Report RpOnlyPatient>
-- =============================================
create PROCEDURE [dbo].[spRpOnlyPatient-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdPatient int = 0
	AS
	BEGIN
	--Nombre	Apellido	Tipo	Dni	FechaNac	sexo	Localidad	Domicilio	Telefono	NroAfiliado	ObraSocial	Fingreso	Fegreso	Motivo
		SELECT [P].[IdPatient],
		       Concat([P].[Name],' ',[P].[LastName]) as'Name',[Birthdate] AS'Birthdate',
			   Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',[Sex] AS'Sex',
			   Concat([P].[idLocationCountry],' ',[P].[idLocationProvince],' ',[P].[idLocationCity])AS'Location',
			   [P].[Address] AS'Address',[P].[Phone] AS'Phone',[AffiliateNumber] AS'AffiliateNumber',[So].[Name] as'SocialWork',
			   [DateAdmission]AS'DateAdmission',[EgressDate] AS'EgressDate',[ReasonExit] AS'ReasonExit'
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]

		WHERE [P].[IdPatient] = @IdPatient		
	END
	
