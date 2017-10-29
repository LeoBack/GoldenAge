USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpClinicHistory-v1.0]    Script Date: 28/10/2017 09:56:11 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 21:54>
-- Description:	<Report [spRpClinicHistory-v1.0]>
-- =============================================
ALTER PROCEDURE [dbo].[spRpClinicHistory-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdPatient int = 0,
	@Visible int = 1
	AS
	BEGIN
		select D.Detail as 'Detail', D.[Date] as 'Date',  Concat(Pr.[Name],' ',Pr.[LastName])as'Name',S.[Description] as'Specialty'   
		from Diagnostic as D inner join Patient  as Pa on [D].IdPatient= Pa.IdPatient
						     inner join Professional  as Pr on [D].IdProfessional= Pr.IdProfessional
							 inner join Specialty  as S on [D].IdSpeciality= S.IdSpecialty
		where D.IdPatient=@IdPatient and D.Visible=@Visible
		
	END
	
