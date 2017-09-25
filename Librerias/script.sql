USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
SET IDENTITY_INSERT [dbo].[Grandfather] ON 

INSERT [dbo].[Grandfather] ([IdGrandFather], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (2, N'Hisler', N'Llanos', CAST(0xA4D60A00 AS Date), 1, 23322, 1, 1, 1, 1, N'Santa Ana 1728', N'351487933', 1, 11, CAST(0x493C0B00 AS Date), CAST(0xD2580B00 AS Date), N'-', 1)
SET IDENTITY_INSERT [dbo].[Grandfather] OFF
SET IDENTITY_INSERT [dbo].[GrandFatherParent] ON 

INSERT [dbo].[GrandFatherParent] ([IdGrandFatherParent], [IdGrandFather], [IdParent], [Visible]) VALUES (1, 1, 1, 1)
INSERT [dbo].[GrandFatherParent] ([IdGrandFatherParent], [IdGrandFather], [IdParent], [Visible]) VALUES (2, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[GrandFatherParent] OFF
SET IDENTITY_INSERT [dbo].[LocationCity] ON 

INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (1, 1, 1, N'La Plata', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (2, 2, 1, N'San Fernando del Valle de Catamarca', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (3, 3, 1, N'Resistencia', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (4, 4, 1, N'Rawson', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (5, 5, 1, N'Córdoba', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (6, 6, 1, N'Corrientes', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (7, 7, 1, N'Paraná', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (8, 8, 1, N'Formosa', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (9, 9, 1, N'San Salvador de Jujuy', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (10, 10, 1, N'Santa Rosa', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (11, 11, 1, N'La Rioja', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (12, 12, 1, N'Mendoza', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (13, 13, 1, N'Posadas', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (14, 14, 1, N'Neuquén', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (15, 15, 1, N'Viedma', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (16, 16, 1, N'Salta', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (17, 17, 1, N'San Juan', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (18, 18, 1, N'San Luis', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (19, 19, 1, N'Río Gallegos', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (20, 20, 1, N'Santa Fe', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (21, 21, 1, N'Santiago del Estero', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (22, 22, 1, N'Ushuaia', 1)
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (23, 23, 1, N'San Miguel de Tucumán', 1)
SET IDENTITY_INSERT [dbo].[LocationCity] OFF
SET IDENTITY_INSERT [dbo].[LocationCountry] ON 

INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (1, N'Argentina', 1)
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (2, N'Chile', 1)
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (3, N'Uruguay', 1)
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (4, N'Paraguay', 1)
SET IDENTITY_INSERT [dbo].[LocationCountry] OFF
SET IDENTITY_INSERT [dbo].[LocationProvince] ON 

INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (1, 1, N'Buenos Aires', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (2, 1, N'Catamarca', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (3, 1, N'Chaco', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (4, 1, N'Chubut', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (5, 1, N'Córdoba', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (6, 1, N'Corrientes', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (7, 1, N'Entre Ríos', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (8, 1, N'Formosa', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (9, 1, N'Jujuy', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (10, 1, N'La Pampa', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (11, 1, N'La Rioja', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (12, 1, N'Mendoza', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (13, 1, N'Misiones', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (14, 1, N'Neuquén', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (15, 1, N'Río Negro', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (16, 1, N'Salta', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (17, 1, N'San Juan', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (18, 1, N'San Luis', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (19, 1, N'Santa Cruz', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (20, 1, N'Santa Fe', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (21, 1, N'Santiago del Estero', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (22, 1, N'Tierra del Fuego', 1)
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (23, 1, N'Tucumán', 1)
SET IDENTITY_INSERT [dbo].[LocationProvince] OFF
SET IDENTITY_INSERT [dbo].[Parent] ON 

INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [IdRelationship], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (1, N'MARCOS ANDRES', N'CARRERAS', 1, N'30660412', N'3513006155', N'3513006155', N'M@M.COM.AR', 1, 1, 1, 1, N'PRINGLES 1218', 1)
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [IdRelationship], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (3, N'MAURO EZEQUIEL ', N'CARRERAS', 1, N'23232323', N'22222222', N'222222222', N'M@M.COM.AR', 1, 1, 1, 1, N'COLON 12', 1)
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [IdRelationship], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (4, N'XILENIA', N'MARIA', 1, N'34343434', N'232', N'23', N'X@M.COM', 1, 1, 1, 1, N'1', 1)
SET IDENTITY_INSERT [dbo].[Parent] OFF
SET IDENTITY_INSERT [dbo].[Professional] ON 

INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (1, 1, N'NombreDoc', N'ApellidoDoc', 1, 1, 1, N'CalleDoc', N'3513333333', N'prueba@doc.com.ar', N'doc', N'd0c', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (2, 1, N'NOMBREDOC2', N'APEDOC2', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (3, 1, N'NOMBREDOC3', N'APEDOC3', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (4, 1, N'NOMBREDOC2', N'APEDOC2', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (5, 1, N'NOMBREDOC2', N'APEDOC2', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (6, 1, N'NOMBREDOC2', N'APEDOC2', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (7, 1, N'NOMBREDOC2', N'APEDOC2', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (8, 1, N'NOMBREDOC2', N'APEDOC2', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (9, 1, N'NOMBREDOC2', N'APEDOC2', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
INSERT [dbo].[Professional] ([IdProfessional], [ProfessionalRegistration], [Name], [LastName], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Visible]) VALUES (10, 1, N'NOMBREDOC2', N'APEDOC2', 1, 1, 1, N'DOC2', N'121212', N'DOC2@Q.COM.AR', N'DOC2', N'D0C2', 1)
SET IDENTITY_INSERT [dbo].[Professional] OFF
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] ON 

INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (1, 1, 1, 1)
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (2, 1, 2, 1)
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (3, 1, 3, 1)
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] OFF
SET IDENTITY_INSERT [dbo].[Relationship] ON 

INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (1, N'ESPOSA', 1)
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (2, N'ESPOSO', 2)
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (3, N'NIETO', 3)
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (4, N'HIJO', 4)
SET IDENTITY_INSERT [dbo].[Relationship] OFF
SET IDENTITY_INSERT [dbo].[SocialWork] ON 

INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [AlternativePhone], [Visible]) VALUES (1, N'OSITAC', N'TRANSPOSTISTAS', 1, 1, 1, N'BALCARCE 45', N'333333', N'333333', 1)
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [AlternativePhone], [Visible]) VALUES (2, N'OBRA SOC 3', N'OBRA SOC 3', 1, 5, 5, N'DIR 3', N'0351333333', N'0351333333', 1)
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [AlternativePhone], [Visible]) VALUES (3, N'OBRA4', N'DIR 4', 1, 5, 5, N'DIR OBRA CUATRO', N'4', N'4', 1)
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [AlternativePhone], [Visible]) VALUES (4, N'OBRA 5', N'obra 5', 1, 2, 2, N'obra 5', N'5', N'5', 1)
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [AlternativePhone], [Visible]) VALUES (5, N'OBRA 6', N'obra 6', 1, 3, 3, N'DIR 6', N'6', N'6', 1)
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [AlternativePhone], [Visible]) VALUES (6, N'OBRA 7', N'obra 7', 1, 3, 3, N'DIR obra 7', N'7', N'7', 1)
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [AlternativePhone], [Visible]) VALUES (7, N'OBRA 8', N'obra 8', 1, 3, 3, N'DIR8', N'8', N'8', 1)
SET IDENTITY_INSERT [dbo].[SocialWork] OFF
SET IDENTITY_INSERT [dbo].[Specialty] ON 

INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (1, N'Traumatologia', 1)
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (2, N'Fisioterapia', 1)
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (3, N'Cardiología', 1)
SET IDENTITY_INSERT [dbo].[Specialty] OFF
SET IDENTITY_INSERT [dbo].[TypeDocument] ON 

INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (1, N'DNI', 1)
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (2, N'PASPORT', 2)
SET IDENTITY_INSERT [dbo].[TypeDocument] OFF
