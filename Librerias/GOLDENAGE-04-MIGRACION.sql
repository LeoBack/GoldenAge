-- Migracion de GOLDENAGE-03.MDF a GOLDENAGE-04 
USE [GOLDENAGE-04]
-- Localidad COUNTry
GO
SET IDENTITY_INSERT [dbo].[LocationCountry] ON 
GO
INSERT INTO [dbo].[LocationCountry] ([idLocationCountry],[Description],[Visible])
SELECT [idLocationCOUNTry],[Description],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[LocationCountry]
GO
SELECT COUNT(idLocationCountry) AS '[LocationCountry]' 
FROM [dbo].[LocationCountry] 
GO
SET IDENTITY_INSERT [dbo].[LocationCountry] OFF
GO
-- Localidad Province
SET IDENTITY_INSERT [dbo].[LocationProvince] ON 
GO
INSERT INTO [dbo].[LocationProvince] ([idLocationProvince],[idLocationCountry],[Description],[Visible])
SELECT [idLocationProvince],[idLocationCountry],[Description],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[LocationProvince]
GO
SELECT COUNT([idLocationProvince]) AS '[LocationProvince]' 
FROM [dbo].[LocationProvince]
GO
SET IDENTITY_INSERT [dbo].[LocationProvince] OFF 
GO
-- Localidad City
SET IDENTITY_INSERT [dbo].[LocationCity] ON 
GO
INSERT INTO [dbo].[LocationCity] ([idLocationCity],[idLocationProvince],[idLocationCountry],[Description],[Visible])
SELECT [idLocationCity],[idLocationProvince],[idLocationCountry],[Description],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[LocationCity]
GO
SELECT COUNT(idLocationCity) AS '[LocationCity]' 
FROM [dbo].[LocationCity]
GO
SET IDENTITY_INSERT [dbo].[LocationCity] OFF 
GO
-- Auxiliar TypeIva
SET IDENTITY_INSERT [dbo].[IvaType] ON 
GO
INSERT INTO [dbo].[IvaType]([IdIvaType],[Description],[Visible])
SELECT [IdIvaType],[Description],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[IvaType] 
GO
SELECT COUNT([IdIvaType]) AS 'IvaType' 
FROM [dbo].[IvaType]
GO
SET IDENTITY_INSERT [dbo].[IvaType] OFF
GO
-- Auxiliar Permission
SET IDENTITY_INSERT [dbo].[Permission] ON
GO
INSERT INTO [dbo].[Permission] ([IdPermission],[Description],[Visible])
SELECT [IdPermission],[Description],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[Permission] 
GO
SELECT COUNT([IdPermission]) AS 'Permission' 
FROM [dbo].[Permission]
GO
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
-- Auxiliar Relationship
SET IDENTITY_INSERT [dbo].[Relationship] ON
GO
INSERT INTO [dbo].[Relationship] ([IdRelationship],[Description],[Visible])
SELECT [IdRelationship],[Description],[Visible] FROM [GOLDENAGE-03.MDF].[dbo].[Relationship] 
GO
SELECT COUNT(IdRelationship) AS 'Relationship' 
FROM [dbo].[Relationship]
GO
SET IDENTITY_INSERT [dbo].[Relationship] OFF
GO
-- Auxiliar TypeDocument
SET IDENTITY_INSERT [dbo].[TypeDocument] ON
GO
INSERT INTO [dbo].[TypeDocument] ([IdTypeDocument],[Description],[Visible])
SELECT [IdTypeDocument],[Description],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[TypeDocument]
GO
SELECT COUNT([IdTypeDocument]) AS 'TypeDocument' 
FROM [dbo].[TypeDocument]
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] OFF
GO
-- Auxiliar TypeParent
SET IDENTITY_INSERT [dbo].[TypeParent] ON
GO
INSERT INTO [dbo].[TypeParent] ([IdTypeParent],[Description],[Visible])
SELECT [IdTypeParent],[Description],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[TypeParent]
GO
SELECT COUNT(IdTypeParent) AS 'TypeParent' 
FROM [dbo].[TypeParent]
GO
SET IDENTITY_INSERT [dbo].[TypeParent] OFF
GO
-- Auxiliar Specialty
SET IDENTITY_INSERT [dbo].[Specialty] ON
GO
INSERT INTO [dbo].[Specialty] ([IdSpecialty],[Description],[Visible])
SELECT [IdSpecialty],[Description],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[Specialty]
GO
SELECT COUNT([IdSpecialty]) AS 'Specialty' 
FROM [dbo].[Specialty]
GO
SET IDENTITY_INSERT [dbo].[Specialty] OFF
GO
-- Principales SocialWork
SET IDENTITY_INSERT [dbo].[SocialWork] ON
GO
INSERT INTO [dbo].[SocialWork]([IdSocialWork],[Name],[Description],[IdIvaType],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Contact],[Visible])
SELECT [IdSocialWork],[Name],[Description],[IdIvaType],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Contact],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[SocialWork]
GO
SELECT COUNT([IdSocialWork]) AS 'SocialWork' 
FROM [dbo].[SocialWork]
GO
SET IDENTITY_INSERT [dbo].[SocialWork] OFF
GO
-- Principales Professional
SET IDENTITY_INSERT [dbo].[Professional] ON
go
INSERT INTO [dbo].[Professional] ([IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible])
SELECT [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCOUNTry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[Professional]
GO
SELECT COUNT([IdProfessional]) AS 'Professional' 
FROM [dbo].[Professional]
GO
SET IDENTITY_INSERT [dbo].[Professional]OFF
GO
-- Principales Session
SET IDENTITY_INSERT [dbo].[Session] ON
GO
INSERT INTO [dbo].[Session]([idSession],[idProfessional],[InitDate],[EndDate])
SELECT [idSession],[idProfessional],[InitDate],[EndDate] FROM [GOLDENAGE-03.MDF].[dbo].[Session]
GO
SELECT COUNT([idSession]) AS 'Session' FROM [dbo].[Session]
GO
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
-- Principales ProfessionalSpeciality
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] ON
GO
INSERT INTO [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality],[IdProfessional],[IdSpeciality],[Visible])
SELECT [IdProfessionalSpeciality],[IdProfessional],[IdSpeciality],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[ProfessionalSpeciality]
GO
SELECT COUNT([IdProfessionalSpeciality]) AS 'ProfessionalSpeciality' FROM [ProfessionalSpeciality]
GO
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality]OFF
GO
-- Principales Parent
SET IDENTITY_INSERT [dbo].[Parent] ON
GO
INSERT INTO [dbo].[Parent] ([IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible])
SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[Parent]
GO
SELECT COUNT([IdParent])'Parent' FROM [dbo].[Parent]
GO
SET IDENTITY_INSERT [dbo].[Parent] OFF
GO
-- Principales Patient
SET IDENTITY_INSERT [dbo].[Patient] ON
GO
INSERT INTO [dbo].[Patient] ([IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Visible])
SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[Patient]
GO
SELECT COUNT(IdPatient) AS 'Patient' FROM [dbo].[Patient]
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
-- Principales PatientSocialWork
--SET IDENTITY_INSERT [dbo].[PatientSocialWork] ON
--GO
--INSERT INTO [dbo].[PatientSocialWork] ([IdPatientSocialWork],[IdSocialWork],[IdPatient],[AffiliateNumber],[Visible])
--SELECT [IdPatientSocialWork],[IdSocialWork],[IdPatient],[AffiliateNumber],[Visible] 
--FROM [GOLDENAGE-03.MDF].[dbo].[Patient]
INSERT INTO [dbo].[PatientSocialWork] ([IdSocialWork],[IdPatient],[AffiliateNumber],[Visible])
SELECT [IdSocialWork],[IdPatient],[AffiliateNumber],[Visible] FROM [GOLDENAGE-03.MDF].[dbo].[Patient]
GO
SELECT COUNT(IdPatientSocialWork) AS 'PatientSocialWork' FROM [dbo].[PatientSocialWork]
--GO
--SET IDENTITY_INSERT [dbo].[PatientSocialWork] OFF
GO
-- Principales PatientParent
SET IDENTITY_INSERT [dbo].[PatientParent] ON
GO
INSERT INTO [dbo].[PatientParent] ([IdPatientParent],[IdPatient],[IdParent],[IdRelationship],[Visible])
SELECT [IdPatientParent],[IdPatient],[IdParent],[IdRelationship],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[PatientParent]
GO
SELECT COUNT(IdPatientParent) AS 'PatientParent' FROM [dbo].[PatientParent]
GO
SET IDENTITY_INSERT [dbo].[PatientParent] OFF
GO
-- Principales PatientState
--SET IDENTITY_INSERT [dbo].[PatientState] ON
--GO
--INSERT INTO [dbo].[PatientState] ([IdPatientState],[IdPatient],[Description],[date],[State],[Visible])
--SELECT [IdPatientState],[IdPatient],[Description],[date],[State],[Visible] 
--FROM [GOLDENAGE-03.MDF].[dbo].[PatientState]
INSERT INTO [dbo].[PatientState] ([IdPatient],[Description],[date],[State],[Visible])
SELECT [IdPatient],[ReasonExit],[DateAdmission],1,[Visible] FROM [GOLDENAGE-03.MDF].[dbo].[Patient]
GO
SELECT COUNT(IdPatientState) AS 'PatientState' FROM [dbo].[PatientState]
--GO
--SET IDENTITY_INSERT [dbo].[PatientState] OFF
GO
-- Principales Diagnostic
SET IDENTITY_INSERT [dbo].[Diagnostic] ON
GO
INSERT INTO [dbo].[Diagnostic] ([idDiagnostic],[IdPatient],[IdSpeciality],[IdProfessional],[Date],[Detail],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible])
SELECT [idDiagnostic],[IdPatient],[IdSpeciality],[IdProfessional],[Date],[Detail],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible] 
FROM [GOLDENAGE-03.MDF].[dbo].[Diagnostic]
GO
SELECT COUNT([idDiagnostic]) AS 'Diagnostic' 
FROM [dbo].[Diagnostic]
GO
SET IDENTITY_INSERT [dbo].[Diagnostic] OFF
GO