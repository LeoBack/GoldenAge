USE [DEFAULT04.MDF]

GO
SET IDENTITY_INSERT [dbo].[LocationCountry] ON 
GO
INSERT INTO [DEFAULT04.MDF].[dbo].[LocationCountry] ([idLocationCountry],[Description],[Visible])
select [idLocationCountry],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[LocationCountry]
GO
select count(idLocationCountry)as'[LocationCountry]' from [DEFAULT04.MDF].[dbo].[LocationCountry] 
GO
SET IDENTITY_INSERT [dbo].[LocationCountry] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[LocationProvince] ON 
GO
INSERT INTO [DEFAULT04.MDF].[dbo].[LocationProvince] ([idLocationProvince],[idLocationCountry],[Description],[Visible])
select [idLocationProvince],[idLocationCountry],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[LocationProvince]
GO
select count([idLocationProvince])as'[LocationProvince]' from [DEFAULT04.MDF].[dbo].[LocationProvince]
GO
SET IDENTITY_INSERT [dbo].[LocationProvince] OFF 
GO


GO
SET IDENTITY_INSERT [dbo].[LocationCity] ON 
GO
INSERT INTO [DEFAULT04.MDF].[dbo].[LocationCity] ([idLocationCity],[idLocationProvince],[idLocationCountry],[Description],[Visible])
select [idLocationCity],[idLocationProvince],[idLocationCountry],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[LocationCity]
GO
select COUNT(idLocationCity) as'[LocationCity]' from [DEFAULT04.MDF].[dbo].[LocationCity]
GO
SET IDENTITY_INSERT [dbo].[LocationCity] OFF 
GO

--Auxiliares

GO
SET IDENTITY_INSERT [dbo].[IvaType] ON 
GO
Insert Into [DEFAULT04.MDF].[dbo].[IvaType]([IdIvaType],[Description],[Visible])
select [IdIvaType],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[IvaType] 
GO
select COUNT([IdIvaType]) as'IvaType' from [DEFAULT04.MDF].[dbo].[IvaType]
GO
SET IDENTITY_INSERT [dbo].[IvaType] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[Permission] ON
GO

INSERT INTO [DEFAULT04.MDF].[dbo].[Permission] ([IdPermission],[Description],[Visible])
select [IdPermission],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Permission] 

select COUNT([IdPermission]) as'Permission' from [DEFAULT04.MDF].[dbo].[Permission]
GO
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[Relationship] ON
GO
INSERT INTO [DEFAULT04.MDF].[dbo].[Relationship] ([IdRelationship],[Description],[Visible])
select [IdRelationship],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Relationship] 
GO
select COUNT(IdRelationship)as'Relationship' from [DEFAULT04.MDF].[dbo].[Relationship]
GO
SET IDENTITY_INSERT [dbo].[Relationship] OFF
GO


SET IDENTITY_INSERT [dbo].[TypeDocument]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[TypeDocument] ([IdTypeDocument],[Description],[Visible])
select [IdTypeDocument],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[TypeDocument]

select COUNT([IdTypeDocument])as'TypeDocument' from [DEFAULT04.MDF].[dbo].[TypeDocument]
SET IDENTITY_INSERT [dbo].[TypeDocument]OFF

SET IDENTITY_INSERT [dbo].[TypeParent]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[TypeParent] ([IdTypeParent],[Description],[Visible])
select [IdTypeParent],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[TypeParent]

select COUNT(IdTypeParent)as'TypeParent' from [DEFAULT04.MDF].[dbo].[TypeParent]
SET IDENTITY_INSERT [dbo].[TypeParent]OFF


SET IDENTITY_INSERT [dbo].[Specialty]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Specialty] ([IdSpecialty],[Description],[Visible])
select [IdSpecialty],[Description],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Specialty]

select COUNT([IdSpecialty])as'Specialty' from [DEFAULT04.MDF].[dbo].[Specialty]
SET IDENTITY_INSERT [dbo].[Specialty]OFF

--Principales
SET IDENTITY_INSERT [dbo].[SocialWork]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[SocialWork]([IdSocialWork],[Name],[Description],[IdIvaType],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Contact],[Visible])
select [IdSocialWork],[Name],[Description],[IdIvaType],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Contact],[Visible] from [GOLDENAGE-03.MDF].[dbo].[SocialWork]

select COUNT([IdSocialWork])as'SocialWork' from [DEFAULT04.MDF].[dbo].[SocialWork]
SET IDENTITY_INSERT [dbo].[SocialWork]OFF

SET IDENTITY_INSERT [dbo].[Professional]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Professional] ([IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible])
select [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Professional]

select COUNT([IdProfessional])as'Professional' from [DEFAULT04.MDF].[dbo].[Professional]
SET IDENTITY_INSERT [dbo].[Professional]OFF

SET IDENTITY_INSERT [dbo].[Session]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Session]([idSession],[idProfessional],[InitDate],[EndDate])
select [idSession],[idProfessional],[InitDate],[EndDate] from [GOLDENAGE-03.MDF].[dbo].[Session]

select count([idSession])as'Session' from [DEFAULT04.MDF].[dbo].[Session]
SET IDENTITY_INSERT [dbo].[Session]OFF

SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality],[IdProfessional],[IdSpeciality],[Visible])
select [IdProfessionalSpeciality],[IdProfessional],[IdSpeciality],[Visible] from [GOLDENAGE-03.MDF].[dbo].[ProfessionalSpeciality]

select count([IdProfessionalSpeciality])as'ProfessionalSpeciality' from [DEFAULT04.MDF].[dbo].[ProfessionalSpeciality]
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality]OFF

SET IDENTITY_INSERT [dbo].[Parent]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Parent] ([IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible])
select [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Parent]

select count([IdParent])'Parent' from [DEFAULT04.MDF].[dbo].[Parent]
SET IDENTITY_INSERT [dbo].[Parent]OFF

SET IDENTITY_INSERT [dbo].[Patient]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Patient] ([IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[DateAdmission],[EgressDate],[ReasonExit],[Visible])
select [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[DateAdmission],[EgressDate],[ReasonExit],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Patient]

select count(IdPatient)as'Patient' from [DEFAULT04.MDF].[dbo].[Patient]
SET IDENTITY_INSERT [dbo].[Patient]OFF

--SET IDENTITY_INSERT [dbo].[PatientSocialWork]ON
--INSERT INTO [DEFAULT04.MDF].[dbo].[PatientSocialWork] ([IdPatientSocialWork],[IdSocialWork],[IdPatient],[AffiliateNumber],[Visible])
--select [IdPatientSocialWork],[IdSocialWork],[IdPatient],[AffiliateNumber],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Patient]
INSERT INTO [DEFAULT04.MDF].[dbo].[PatientSocialWork] ([IdSocialWork],[IdPatient],[AffiliateNumber],[Visible])
select [IdSocialWork],[IdPatient],[AffiliateNumber],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Patient]

select count(IdPatientSocialWork)as'PatientSocialWork' from [DEFAULT04.MDF].[dbo].[PatientSocialWork]

--select count([IdPatientSocialWork]) from [DEFAULT04.MDF].[dbo].[PatientSocialWork]
--SET IDENTITY_INSERT [dbo].[PatientSocialWork]OFF

SET IDENTITY_INSERT [dbo].[PatientParent]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[PatientParent] ([IdPatientParent],[IdPatient],[IdParent],[IdRelationship],[Visible])
select [IdPatientParent],[IdPatient],[IdParent],[IdRelationship],[Visible] from [GOLDENAGE-03.MDF].[dbo].[PatientParent]

select count(IdPatientParent)as'PatientParent' from [DEFAULT04.MDF].[dbo].[PatientParent]
SET IDENTITY_INSERT [dbo].[PatientParent]OFF


SET IDENTITY_INSERT [dbo].[Diagnostic]ON
INSERT INTO [DEFAULT04.MDF].[dbo].[Diagnostic] ([idDiagnostic],[IdPatient],[IdSpeciality],[IdProfessional],[Date],[Detail],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible])
select [idDiagnostic],[IdPatient],[IdSpeciality],[IdProfessional],[Date],[Detail],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible] from [GOLDENAGE-03.MDF].[dbo].[Diagnostic]

select count([idDiagnostic])as'Diagnostic' from [DEFAULT04.MDF].[dbo].[Diagnostic]
SET IDENTITY_INSERT [dbo].[Diagnostic]OFF
