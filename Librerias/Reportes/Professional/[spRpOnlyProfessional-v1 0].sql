USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessional-v1.0]    Script Date: 28/10/2017 08:57:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 20:51>
-- Description:	<Report spRpOnlyProfessional>
-- =============================================
ALTER PROCEDURE [dbo].[spRpOnlyProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdProfessional int = 0,
	@Visible int = 1
	AS
	BEGIN
	--Nombre	Apellido	MP	Direccion	Localidad	Telefono	Mail	Profesional/Speciality	Descripcion					
		SELECT [P].[IdProfessional],
		       Concat([P].[Name],' ',[P].[LastName]) as'Name',[ProfessionalRegistration] AS'ProfessionalRegistration',
			   [P].[Address] AS'Address', Concat([P].[idLocationCountry],' ',[P].[idLocationProvince],' ',[P].[idLocationCity])AS'Location',
			   [P].[Phone] AS'Phone',[P].[Mail] AS'Mail'
		from Professional as P 
		WHERE 
		[P].[IdProfessional] = @IdProfessional and [P].[Visible] = @Visible		
	END
	
