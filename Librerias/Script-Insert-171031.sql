USE [GOLDENAGE-00.MDF]
GO
/****** Object:  Table [dbo].[IvaType]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IvaType](
	[IdIvaType] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIvaType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocationCity]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationCity](
	[idLocationCity] [int] IDENTITY(1,1) NOT NULL,
	[idLocationProvince] [int] NOT NULL,
	[idLocationCountry] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLocationCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocationCountry]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationCountry](
	[idLocationCountry] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLocationCountry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocationProvince]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationProvince](
	[idLocationProvince] [int] IDENTITY(1,1) NOT NULL,
	[idLocationCountry] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLocationProvince] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[IdPermission] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professional]    Script Date: 31/10/2017 21:42:12 ******/
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
/****** Object:  Table [dbo].[Relationship]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relationship](
	[IdRelationship] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRelationship] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialWork]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialWork](
	[IdSocialWork] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[IdIvaType] [int] NULL,
	[idLocationCountry] [int] NULL,
	[idLocationProvince] [int] NULL,
	[idLocationCity] [int] NULL,
	[Address] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[Contact] [varchar](50) NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSocialWork] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialty]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialty](
	[IdSpecialty] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSpecialty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeDocument]    Script Date: 31/10/2017 21:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeDocument](
	[IdTypeDocument] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTypeDocument] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IvaType] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[LocationCity] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[LocationCountry] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[LocationProvince] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Permission] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Professional] ADD  CONSTRAINT [DF_Professional_idPermission]  DEFAULT ((0)) FOR [idPermission]
GO
ALTER TABLE [dbo].[Professional] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Relationship] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[SocialWork] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Specialty] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[TypeDocument] ADD  DEFAULT ((1)) FOR [Visible]
GO
