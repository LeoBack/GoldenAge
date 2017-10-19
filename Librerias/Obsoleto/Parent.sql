USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO

/****** Object:  Table [dbo].[Parent]    Script Date: 08/10/2017 18:08:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parent](
	[IdParent] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[IdTypeDocument] [int] NOT NULL,
	[NumberDocument] [varchar](20) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[AlternativePhone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[idLocationCountry] [int] NOT NULL,
	[idLocationProvince] [int] NOT NULL,
	[idLocationCity] [int] NOT NULL,
	[Address] [varchar](50) NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdParent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Parent] ADD  DEFAULT ((1)) FOR [Visible]
GO


