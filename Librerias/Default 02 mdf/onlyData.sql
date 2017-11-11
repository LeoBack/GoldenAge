USE [DEFAULT02.MDF]
GO
SET IDENTITY_INSERT [dbo].[Diagnostic] ON 

GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (1, 1, 3, 6, CAST(0x0000A80500000000 AS DateTime), N'Primer diagnostico TEST', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (2, 1, 2, 6, CAST(0x0000A80500000000 AS DateTime), N'Segundo diagnostico', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (3, 2, 3, 6, CAST(0x0000A80500000000 AS DateTime), N'Primer Diagnostico', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (4, 2, 2, 6, CAST(0x0000A80500000000 AS DateTime), N'Segundo diagnostico TEST', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (5, 2, 2, 6, CAST(0x0000A80500000000 AS DateTime), N'Tercer Diagnostico', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (6, 2, 3, 6, CAST(0x0000A80500000000 AS DateTime), N'Cuarto', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (7, 2, 4, 20, CAST(0x0000A80700000000 AS DateTime), N'Corte de uña', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (8, 2, 1, 20, CAST(0x0000A81D0155437E AS DateTime), N'Prueba de validaciones

VERIFICAR LOS DEDOS GORDOS DEL PIE IZQ DER', 1, 20, 1, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (9, 2, 2, 20, CAST(0x0000A80700000000 AS DateTime), N'prueba', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (10, 2, 5, 20, CAST(0x0000A80700000000 AS DateTime), N'PRuebas', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (11, 7, 4, 20, CAST(0x0000A81A010C03CA AS DateTime), N'Encarnada', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (12, 7, 4, 20, CAST(0x0000A81A010CDEC7 AS DateTime), N'dedo amputado  ....,,.', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (13, 2, 5, 20, CAST(0x0000A81F0028AAFA AS DateTime), N'Prueba-
Mensaje A. ', 2, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Diagnostic] OFF
GO
SET IDENTITY_INSERT [dbo].[IvaType] ON 

GO
INSERT [dbo].[IvaType] ([IdIvaType], [Description], [Visible]) VALUES (1, N'Responsable Inscripto', 1)
GO
INSERT [dbo].[IvaType] ([IdIvaType], [Description], [Visible]) VALUES (2, N'Monotributo', 1)
GO
INSERT [dbo].[IvaType] ([IdIvaType], [Description], [Visible]) VALUES (3, N'Exento', 1)
GO
SET IDENTITY_INSERT [dbo].[IvaType] OFF
GO
SET IDENTITY_INSERT [dbo].[LocationCity] ON 

GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (1, 1, 1, N'La Plata', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (2, 2, 1, N'San Fernando del Valle de Catamarca', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (3, 3, 1, N'Resistencia', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (4, 4, 1, N'Rawson', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (5, 5, 1, N'Córdoba', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (6, 6, 1, N'Corrientes', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (7, 7, 1, N'Paraná', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (8, 8, 1, N'Formosa', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (9, 9, 1, N'San Salvador de Jujuy', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (10, 10, 1, N'Santa Rosa', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (11, 11, 1, N'La Rioja', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (12, 12, 1, N'Mendoza', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (13, 13, 1, N'Posadas', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (14, 14, 1, N'Neuquén', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (15, 15, 1, N'Viedma', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (16, 16, 1, N'Salta', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (17, 17, 1, N'San Juan', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (18, 18, 1, N'San Luis', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (19, 19, 1, N'Río Gallegos', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (20, 20, 1, N'Santa Fe', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (21, 21, 1, N'Santiago del Estero', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (22, 22, 1, N'Ushuaia', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (23, 23, 1, N'San Miguel de Tucumán', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (24, 5, 1, N'La Calera', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (25, 24, 2, N'Santiago de Chile', 1)
GO
SET IDENTITY_INSERT [dbo].[LocationCity] OFF
GO
SET IDENTITY_INSERT [dbo].[LocationCountry] ON 

GO
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (1, N'Argentina', 1)
GO
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (2, N'Chile', 1)
GO
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (3, N'Uruguay', 1)
GO
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (4, N'Paraguay', 1)
GO
SET IDENTITY_INSERT [dbo].[LocationCountry] OFF
GO
SET IDENTITY_INSERT [dbo].[LocationProvince] ON 

GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (1, 1, N'Buenos Aires', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (2, 1, N'Catamarca', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (3, 1, N'Chaco', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (4, 1, N'Chubut', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (5, 1, N'Córdoba', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (6, 1, N'Corrientes', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (7, 1, N'Entre Ríos', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (8, 1, N'Formosa', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (9, 1, N'Jujuy', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (10, 1, N'La Pampa', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (11, 1, N'La Rioja', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (12, 1, N'Mendoza', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (13, 1, N'Misiones', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (14, 1, N'Neuquén', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (15, 1, N'Río Negro', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (16, 1, N'Salta', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (17, 1, N'San Juan', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (18, 1, N'San Luis', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (19, 1, N'Santa Cruz', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (20, 1, N'Santa Fe', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (21, 1, N'Santiago del Estero', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (22, 1, N'Tierra del Fuego', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (23, 1, N'Tucumán', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (24, 2, N'Region Metropilitana', 1)
GO
SET IDENTITY_INSERT [dbo].[LocationProvince] OFF
GO
SET IDENTITY_INSERT [dbo].[Parent] ON 

GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (1, N'MARCOS', N'ANDRES', 1, N'33000222', N'03514455667', N'000055544433', N'MC@MC.COM', 1, 5, 5, N'IRIGOYEN', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (2, N'BELEN', N'GIURICICH', 1, N'11222333', N'035412233445', N'0987654', N'BL@BL.COM', 1, 1, 1, N'NOSE', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (3, N'NOMBRE', N'APELLIDO', 1, N'11222333', N'009998887765', N'66789', N'A@A.COM', 2, 24, 25, N'BAHIA DE CONCHA', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (4, N'BB', N'B', 1, N'22333444', N'1111122223334', N'', N'', 1, 4, 4, N'QWERT', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (5, N'C', N'CC', 1, N'44555666', N'', N'', N'', 1, 5, 5, N'DENA FUNES', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (6, N'D', N'D', 1, N'1122233', N'', N'', N'', 1, 3, 3, N'ASD', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (7, N'MAURO EDITAR', N'CARRERAS', 1, N'30660412', N'2132435', N'111', N'MAC@MAC.OCM', 1, 5, 24, N'PRINGLES 1218', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (8, N'WWKLSV WS', N'SSSLA', 1, N'345467562', N'', N'', N'MSC@ASFC.COM', 1, 1, 1, N'LKMDB MXBDV2', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (9, N'WWKLSV WS', N'SSSLA', 1, N'345467562', N'3212321)(-', N'', N'MSC@ASFC.COM', 1, 1, 1, N'LKMDB MXBDV2', 1)
GO
SET IDENTITY_INSERT [dbo].[Parent] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (1, N'HISLER', N'LLANOS', CAST(0xEFD00A00 AS Date), 1, 121212, 1, 1, 1, 1, N'AV SANTA ANA 1728', N'0351 4873272', 1, 10000000, CAST(0x543D0B00 AS Date), CAST(0x593D0B00 AS Date), N'', 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (2, N'ANTONIA', N'TORRES', CAST(0x28D60A00 AS Date), 2, 121212, 0, 1, 3, 3, N'AV SANTA ANA 1728', N'0351 4873272', 1, 12121212, CAST(0x87320B00 AS Date), CAST(0x593D0B00 AS Date), N'', 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (5, N'MEC', N'MAC', CAST(0x753D0B00 AS Date), 1, 30660412, 0, 1, 1, 1, N'', N'', 19, 123456789012345678, CAST(0x753D0B00 AS Date), CAST(0x753D0B00 AS Date), N'', 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (6, N'AS', N'MW', CAST(0x753D0B00 AS Date), 1, 123456098, 0, 1, 1, 1, N'', N'', 19, 12345679012345678, CAST(0x753D0B00 AS Date), CAST(0x753D0B00 AS Date), N'', 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (7, N'Z', N'A', CAST(0x753D0B00 AS Date), 1, 21345675, 1, 1, 1, 1, N'', N'324354653', 19, 43202562, CAST(0x753D0B00 AS Date), CAST(0x753D0B00 AS Date), N'', 1)
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientParent] ON 

GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (1, 1, 2, 3, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (2, 2, 1, 3, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (3, 2, 3, 4, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (4, 2, 4, 4, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (5, 2, 5, 3, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (6, 1, 6, 3, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (7, 1, 7, 4, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (8, 7, 8, 1, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (9, 7, 9, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PatientParent] OFF
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 

GO
INSERT [dbo].[Permission] ([IdPermission], [Description], [Visible]) VALUES (1, N'Administrador', 1)
GO
INSERT [dbo].[Permission] ([IdPermission], [Description], [Visible]) VALUES (2, N'Auditor', 1)
GO
INSERT [dbo].[Permission] ([IdPermission], [Description], [Visible]) VALUES (3, N'Usuario', 1)
GO
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
SET IDENTITY_INSERT [dbo].[Professional] ON 

GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (1, N'TEST', N'TEST', 123, 1, 1, 1, N'TEST', N'12345678', N'TEST@TEST.COM', N'test', N'1234', 2, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (4, N'A', N'A', 123456, 1, 1, 1, N'A', N'12345678', N'TEST@TEST', N'A', N'testacesso', 2, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (5, N'C', N'C', 12, 1, 5, 5, N'C', N'3', N'C@C.COM.AR', N'c', N'1234', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (6, N'LEO', N'BACK', 111222, 1, 5, 5, N'DEAN FUNES', N'1', N'TEST@TEST.COM', N'leo', N'le0nard0', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (20, N'MARCOS ANDRÉS', N'CARRERAS', 170111, 1, 5, 5, N'PRINGLES 1218 D2', N'3513006155', N'MARCOSANDRESCARRERAS@GMAIL.COM', N'marcos', N'84m4rc0s17', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (21, N'AAA', N'SSSS', 1245543, 1, 3, 3, N'EQDEQLDKQL  ', N'2300323123', N'MASD@MAD.COM.A', N'aadd222', N'12343232311', 3, 1)
GO
SET IDENTITY_INSERT [dbo].[Professional] OFF
GO
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] ON 

GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (2, 1, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (3, 1, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (4, 0, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (5, 20, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (6, 20, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (7, 20, 1, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (8, 20, 4, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (9, 5, 1, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (10, 6, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (11, 6, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (12, 4, 4, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (13, 4, 1, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (18, 20, 5, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (19, 21, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (20, 21, 5, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (21, 21, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (22, 21, 4, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (23, 21, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] OFF
GO
SET IDENTITY_INSERT [dbo].[Relationship] ON 

GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (1, N'ESPOSA', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (2, N'ESPOSO', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (3, N'NIETO', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (4, N'HIJO', 1)
GO
SET IDENTITY_INSERT [dbo].[Relationship] OFF
GO
SET IDENTITY_INSERT [dbo].[Session] ON 

GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (1, 20, CAST(0x0000A81A016DCBBE AS DateTime), CAST(0x0000A81A016EC986 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (2, 20, CAST(0x0000A81D0154F557 AS DateTime), CAST(0x0000A81D0154F7AF AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (3, 20, CAST(0x0000A81F00224496 AS DateTime), CAST(0x0000A81F002BF4EE AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (4, 20, CAST(0x0000A824013800D8 AS DateTime), CAST(0x0000A824013864E0 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (5, 20, CAST(0x0000A824014DC259 AS DateTime), CAST(0x0000A824014DC4B1 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (6, 20, CAST(0x0000A824014E8C1E AS DateTime), CAST(0x0000A824014E8E76 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (7, 20, CAST(0x0000A824014F8427 AS DateTime), CAST(0x0000A824014F867F AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (8, 6, CAST(0x0000A82401514372 AS DateTime), CAST(0x0000A8240151E634 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (9, 20, CAST(0x0000A82401549E95 AS DateTime), CAST(0x0000A8240154A0ED AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (10, 20, CAST(0x0000A82401553056 AS DateTime), CAST(0x0000A824015532AE AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (11, 20, CAST(0x0000A8240156CC77 AS DateTime), CAST(0x0000A82401579439 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (12, 20, CAST(0x0000A82401585403 AS DateTime), CAST(0x0000A8240158B5E4 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (13, 20, CAST(0x0000A82401599219 AS DateTime), CAST(0x0000A824015A36B6 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (14, 20, CAST(0x0000A824017A1165 AS DateTime), CAST(0x0000A824017A255C AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (15, 20, CAST(0x0000A8250099A468 AS DateTime), CAST(0x0000A825013CB939 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
SET IDENTITY_INSERT [dbo].[SocialWork] ON 

GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (1, N'OSITAC', N'Transporte', 1, 1, 1, 1, N'BALCARCE', N'111111', N'SECRETARIA YANINA', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (3, N'O3S', N'do3', 0, 0, 0, 0, N'DOM3', N'3', N'3', 0)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (4, N'GEA', N'ni idea', 2, 1, 4, 4, N'ASDFSDG', N'', N'', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (5, N'TEST', N'testa', 3, 1, 3, 3, N'TESTD', N'', N'', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (6, N'E', N'r', 3, 1, 1, 1, N'E', N'34', N'ERT', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (19, N'TEST', N'asd', 2, 1, 5, 24, N'SLFNL{V', N'67078908', N'7576FHC', 1)
GO
SET IDENTITY_INSERT [dbo].[SocialWork] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialty] ON 

GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (1, N'Traumatologia', 1)
GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (2, N'Fisioterapia', 1)
GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (3, N'Cardiología', 1)
GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (4, N'Podologia', 1)
GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (5, N'Enfermeria', 1)
GO
SET IDENTITY_INSERT [dbo].[Specialty] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] ON 

GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (1, N'DNI', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (2, N'PASPORT', 1)
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] OFF
GO
