USE [DEFAULT04.MDF]

GO
SET IDENTITY_INSERT [dbo].[LocationCOUNTry] ON 
GO
INSERT INTO [DEFAULT04.MDF].[dbo].[LocationCOUNTry] ([idLocationCOUNTry],[Description],[Visible])
SELECT [idLocationCOUNTry],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[LocationCOUNTry]
GO
SELECT COUNT(idLocationCOUNTry)as'[LocationCOUNTry]' from [DEFAULT04.MDF].[dbo].[LocationCOUNTry] 
GO
SET IDENTITY_INSERT [dbo].[LocationCOUNTry] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[LocationProvince] ON 
GO
INSERT INTO [DEFAULT04.MDF].[dbo].[LocationProvince] ([idLocationProvince],[idLocationCOUNTry],[Description],[Visible])
SELECT [idLocationProvince],[idLocationCOUNTry],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[LocationProvince]
GO
SELECT COUNT([idLocationProvince])as'[LocationProvince]' from [DEFAULT04.MDF].[dbo].[LocationProvince]
GO
SET IDENTITY_INSERT [dbo].[LocationProvince] OFF 
GO


GO
SET IDENTITY_INSERT [dbo].[LocationCity] ON 
GO
INSERT INTO [DEFAULT04.MDF].[dbo].[LocationCity] ([idLocationCity],[idLocationProvince],[idLocationCOUNTry],[Description],[Visible])
SELECT [idLocationCity],[idLocationProvince],[idLocationCOUNTry],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[LocationCity]
GO
SELECT COUNT(idLocationCity) as'[LocationCity]' from [DEFAULT04.MDF].[dbo].[LocationCity]
GO
SET IDENTITY_INSERT [dbo].[LocationCity] OFF 
GO

--Auxiliares

GO
SET IDENTITY_INSERT [dbo].[IvaType] ON 
GO
Insert Into [DEFAULT04.MDF].[dbo].[IvaType]([IdIvaType],[Description],[Visible])
SELECT [IdIvaType],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[IvaType] 
GO
SELECT COUNT([IdIvaType]) as'IvaType' from [DEFAULT04.MDF].[dbo].[IvaType]
GO
SET IDENTITY_INSERT [dbo].[IvaType] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[Permission] ON
GO

INSERT INTO [DEFAULT04.MDF].[dbo].[Permission] ([IdPermission],[Description],[Visible])
SELECT [IdPermission],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Permission] 

SELECT COUNT([IdPermission]) as'Permission' from [DEFAULT04.MDF].[dbo].[Permission]
GO
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[Relationship] ON
GO
INSERT INTO [DEFAULT04.MDF].[dbo].[Relationship] ([IdRelationship],[Description],[Visible])
SELECT [IdRelationship],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Relationship] 
GO
SELECT COUNT(IdRelationship)as'Relationship' from [DEFAULT04.MDF].[dbo].[Relationship]
GO
SET IDENTITY_INSERT [dbo].[Relationship] OFF
GO


SET IDENTITY_INSERT [dbo].[TypeDocument]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[TypeDocument] ([IdTypeDocument],[Description],[Visible])
SELECT [IdTypeDocument],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[TypeDocument]

SELECT COUNT([IdTypeDocument])as'TypeDocument' from [DEFAULT04.MDF].[dbo].[TypeDocument]
SET IDENTITY_INSERT [dbo].[TypeDocument]OFF

SET IDENTITY_INSERT [dbo].[TypeParent]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[TypeParent] ([IdTypeParent],[Description],[Visible])
SELECT [IdTypeParent],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[TypeParent]

SELECT COUNT(IdTypeParent)as'TypeParent' from [DEFAULT04.MDF].[dbo].[TypeParent]
SET IDENTITY_INSERT [dbo].[TypeParent]OFF


SET IDENTITY_INSERT [dbo].[Specialty]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Specialty] ([IdSpecialty],[Description],[Visible])
SELECT [IdSpecialty],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Specialty]

SELECT COUNT([IdSpecialty])as'Specialty' from [DEFAULT04.MDF].[dbo].[Specialty]
SET IDENTITY_INSERT [dbo].[Specialty]OFF

--Principales
SET IDENTITY_INSERT [dbo].[SocialWork]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[SocialWork]([IdSocialWork],[Name],[Description],[IdIvaType],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Contact],[Visible])
SELECT [IdSocialWork],[Name],[Description],[IdIvaType],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Contact],[Visible] from [GOLDENAGE-03.MDF].[dbo].[SocialWork]

SELECT COUNT([IdSocialWork])as'SocialWork' from [DEFAULT04.MDF].[dbo].[SocialWork]
SET IDENTITY_INSERT [dbo].[SocialWork]OFF

SET IDENTITY_INSERT [dbo].[Professional]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Professional] ([IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible])
SELECT [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Professional]

SELECT COUNT([IdProfessional])as'Professional' from [DEFAULT04.MDF].[dbo].[Professional]
SET IDENTITY_INSERT [dbo].[Professional]OFF

SET IDENTITY_INSERT [dbo].[Session]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Session]([idSession],[idProfessional],[InitDate],[EndDate])
SELECT [idSession],[idProfessional],[InitDate],[EndDate] from [GOLDENAGE-03.MDF].[dbo].[Session]

SELECT COUNT([idSession])as'Session' from [DEFAULT04.MDF].[dbo].[Session]
SET IDENTITY_INSERT [dbo].[Session]OFF

SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality],[IdProfessional],[IdSpeciality],[Visible])
SELECT [IdProfessionalSpeciality],[IdProfessional],[IdSpeciality],[Visible] from [GOLDENAGE-03.MDF].[dbo].[ProfessionalSpeciality]

SELECT COUNT([IdProfessionalSpeciality])as'ProfessionalSpeciality' from [DEFAULT04.MDF].[dbo].[ProfessionalSpeciality]
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality]OFF

SET IDENTITY_INSERT [dbo].[Parent]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Parent] ([IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Visible])
SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Parent]

SELECT COUNT([IdParent])'Parent' from [DEFAULT04.MDF].[dbo].[Parent]
SET IDENTITY_INSERT [dbo].[Parent]OFF

SET IDENTITY_INSERT [dbo].[Patient]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Patient] ([IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Phone],[DateAdmission],[EgressDate],[ReasonExit],[Visible])
SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Phone],[DateAdmission],[EgressDate],[ReasonExit],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Patient]

SELECT COUNT(IdPatient)as'Patient' from [DEFAULT04.MDF].[dbo].[Patient]
SET IDENTITY_INSERT [dbo].[Patient]OFF

--SET IDENTITY_INSERT [dbo].[PatientSocialWork]ON
--INSERT INTO [DEFAULT04.MDF].[dbo].[PatientSocialWork] ([IdPatientSocialWork],[IdSocialWork],[IdPatient],[AffiliateNumber],[Visible])
--SELECT [IdPatientSocialWork],[IdSocialWork],[IdPatient],[AffiliateNumber],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Patient]
INSERT INTO [DEFAULT04.MDF].[dbo].[PatientSocialWork] ([IdSocialWork],[IdPatient],[AffiliateNumber],[Visible])
SELECT [IdSocialWork],[IdPatient],[AffiliateNumber],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Patient]

SELECT COUNT(IdPatientSocialWork)as'PatientSocialWork' from [DEFAULT04.MDF].[dbo].[PatientSocialWork]

--SELECT COUNT([IdPatientSocialWork]) from [DEFAULT04.MDF].[dbo].[PatientSocialWork]
--SET IDENTITY_INSERT [dbo].[PatientSocialWork]OFF

SET IDENTITY_INSERT [dbo].[PatientParent]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[PatientParent] ([IdPatientParent],[IdPatient],[IdParent],[IdRelationship],[Visible])
SELECT [IdPatientParent],[IdPatient],[IdParent],[IdRelationship],[Visible] from [GOLDENAGE-03.MDF].[dbo].[PatientParent]

SELECT COUNT(IdPatientParent)as'PatientParent' from [DEFAULT04.MDF].[dbo].[PatientParent]
SET IDENTITY_INSERT [dbo].[PatientParent]OFF


SET IDENTITY_INSERT [dbo].[Diagnostic]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Diagnostic] ([idDiagnostic],[IdPatient],[IdSpeciality],[IdProfessional],[Date],[Detail],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible])
SELECT [idDiagnostic],[IdPatient],[IdSpeciality],[IdProfessional],[Date],[Detail],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Diagnostic]

SELECT COUNT([idDiagnostic])as'Diagnostic' from [DEFAULT04.MDF].[dbo].[Diagnostic]
SET IDENTITY_INSERT [dbo].[Diagnostic]OFF
