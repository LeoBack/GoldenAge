USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessionalSpeciality-v1.0]    Script Date: 28/10/2017 08:57:52 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 20:54>
-- Description:	<Report spRpOnlyProfessionalSpeciality-v1.0>
-- =============================================
ALTER PROCEDURE [dbo].[spRpOnlyProfessionalSpeciality-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdProfessional int = 0,
	@Visible int = 1
	AS
	BEGIN
		select s.[Description] from Specialty S  
		inner Join ProfessionalSpeciality Ps on Ps.IdSpeciality = S.IdSpecialty
		inner Join Professional P on Ps.IdProfessional=P.IdProfessional
		WHERE 
		[P].[IdProfessional] = @IdProfessional and [S].[Visible] = @Visible		
	END
	
