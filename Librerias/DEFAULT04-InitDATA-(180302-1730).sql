USE [DEFAULT04.MDF]
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
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (26, 5, 1, N'Cosquin', 1)
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
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (1, N'LEONARDO', N'BACK', N'111222', 1, 5, 5, N'DEAN FUNES', N'+543541625720', N'LEONARDO.BACK@OUTLOOK.COM', N'leo', N'le0nard0', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (2, N'MARCOS ANDRÉS', N'CARRERAS', N'170111', 1, 5, 5, N'PRINGLES 1218 D2', N'+543513006155', N'MARCOSANDRESCARRERAS@GMAIL.COM', N'marcos', N'84m4rc0s17', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Professional] OFF
GO
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] ON 
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (1, 2, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (2, 2, 4, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (3, 1, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (4, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] OFF
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
SET IDENTITY_INSERT [dbo].[Specialty] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] ON 
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (1, N'DNI', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (2, N'CEDULA DE INTENTIDAD', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (3, N'PASPORTE', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (4, N'LIBRETA CIVICA', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (5, N'LIBRETA DE ENRROLAMIENTO', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (6, N'CUIT', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (7, N'CUIL', 1)
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] OFF
GO
SET IDENTITY_INSERT [dbo].[Relationship] ON 
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (1, N'Nieto/a', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (2, N'Hijo/a', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (3, N'Hermano/a', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (4, N'Sobrino/a', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (5, N'Familiar Cercano ', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (6, N'Otros', 1)
GO
SET IDENTITY_INSERT [dbo].[Relationship] OFF
GO
