USE [DEFAULT02.MDF]
GO

/****** Object:  Table [dbo].[SocialWork]    Script Date: 07/02/2018 10:52:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PatientSocialWork](
	[IdPatientSocialWork] [int] IDENTITY(1,1) NOT NULL,
	[IdSocialWork] [int] NOT NULL,
	[IdPatient] [int] NOT NULL,
	[AffiliateNumber] [varchar](50) NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPatientSocialWork] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PatientSocialWork] ADD  DEFAULT ((1)) FOR [Visible]
GO


