USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
ALTER TABLE [dbo].[Professional] DROP CONSTRAINT [DF__Professio__Visib__1BC821DD]
GO
ALTER TABLE [dbo].[Professional] DROP CONSTRAINT [DF_Professional_idPermission]
GO
/****** Object:  Table [dbo].[Professional]    Script Date: 21/10/2017 21:12:23 ******/
DROP TABLE [dbo].[Professional]
GO
/****** Object:  Table [dbo].[Professional]    Script Date: 21/10/2017 21:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professional](
	[IdProfessional] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[ProfessionalRegistration] [int] NULL,
	[idLocationCountry] [int] NOT NULL,
	[idLocationProvince] [int] NOT NULL,
	[idLocationCity] [int] NOT NULL,
	[Address] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Mail] [varchar](50) NULL,
	[User] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[idPermission] [int] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProfessional] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Professional] ON 
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (1, N'TEST', N'TEST', 144333, 1, 1, 1, N'TEST', N'12345678', N'TEST@TEST.COM', N'test', N'testtest', 2, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (4, N'A', N'A', 123456, 1, 1, 1, N'A', N'12345678', N'TEST@TEST', N'A', N'testacesso', 2, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (5, N'C', N'C', 111221, 1, 5, 5, N'C', N'3', N'C@C.COM.AR', N'c', N'12345678', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (6, N'LEO', N'BACK', 111222, 1, 5, 5, N'DEAN FUNES', N'1', N'TEST@TEST.COM', N'leo', N'le0nard0', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (20, N'MARCOS ANDRÉS', N'CARRERAS', 170111, 1, 5, 5, N'PRINGLES 1218 D2', N'3513006155', N'MARCOSANDRESCARRERAS@GMAIL.COM', N'marcos', N'84m4rc0s17', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Professional] OFF
GO
ALTER TABLE [dbo].[Professional] ADD  CONSTRAINT [DF_Professional_idPermission]  DEFAULT ((0)) FOR [idPermission]
GO
ALTER TABLE [dbo].[Professional] ADD  DEFAULT ((1)) FOR [Visible]
GO
