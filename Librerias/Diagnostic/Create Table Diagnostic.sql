--USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
--GO

/****** Object:  Table [dbo].[Diagnostic]    Script Date: 06/10/2017 10:03:01 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Diagnostic](
	[idDiagnostic] [int] IDENTITY(1,1) NOT NULL,
	[IdPatient][int] NOT NULL,
	[IdSpeciality] [int] NOT NULL,
	[IdProfessional] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Detail] [Text] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDiagnostic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Diagnostic] ADD  DEFAULT ((1)) FOR [Visible]
GO


