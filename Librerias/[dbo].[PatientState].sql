USE [GOLDENAGE-03.MDF]
GO

/****** Object:  Table [dbo].[PatientSocialWork]    Script Date: 14/04/2018 11:26:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PatientState](
	[IdPatientState] [int] IDENTITY(1,1) NOT NULL,
	[IdPatient] [int] NOT NULL,
	[Description] [varchar] (250) NOT NULL,
	[Date] [datetime] NOT NULL,
	[State] [int] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPatientState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PatientState] ADD  DEFAULT ((1)) FOR [Visible]
GO


