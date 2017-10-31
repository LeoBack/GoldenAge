USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpPatientParent-v1.0]    Script Date: 28/10/2017 19:52:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 19:52>
-- Description:	<Report RpPatientParent>
-- =============================================
create PROCEDURE [dbo].[spRpPatientParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdPatient int = 0,
	@Visible int=1
	AS
BEGIN
	SELECT Concat(Pa.Name,' ',Pa.LastName) as'Name', 
	R.[Description] as'Relationship',
	Concat(Td.[Description],'-',Pa.NumberDocument) as'NumberDocument',
    Concat([Pa].[idLocationCountry],' ',[Pa].[idLocationProvince],' ',[Pa].[idLocationCity])AS'Location', 
	[Pa].[Address] as'Address', [Pa].Phone as'Phone', [Pa].AlternativePhone as'AlternativePhone',[Pa].Email as'Email' 

		FROM  PatientParent as Pp 
		inner join Patient as P on Pp.IdPatient=P.IdPatient
		inner join Parent Pa on Pp.IdParent=Pa.IdParent
		inner join Relationship R on Pp.IdRelationship = R.IdRelationship 
		inner join TypeDocument as Td on Pa.IdTypeDocument=Td.IdTypeDocument

 		WHERE [P].[IdPatient] = @IdPatient and [Pp].Visible=@Visible		
END
	
