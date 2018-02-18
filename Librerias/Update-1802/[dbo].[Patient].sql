USE [DEFAULT02.MDF]
GO

/****** Object:  Table [dbo].[Patient]    Script Date: 07/02/2018 10:52:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patient](
	[IdPatient] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Birthdate] [date] NULL,
	[IdTypeDocument] [int] NULL,
	[NumberDocument] [int] NULL,
	[Sex] [int] NOT NULL,
	[idLocationCountry] [int] NOT NULL,
	[idLocationProvince] [int] NOT NULL,
	[idLocationCity] [int] NOT NULL,
	[Address] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[DateAdmission] [date] NOT NULL,
	[EgressDate] [date] NULL,
	[ReasonExit] [varchar](300) NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPatient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Patient] ADD  DEFAULT ((0)) FOR [Sex]
GO

ALTER TABLE [dbo].[Patient] ADD  DEFAULT ((1)) FOR [Visible]
GO


