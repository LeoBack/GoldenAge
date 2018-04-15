USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessionalSpeciality-v1.0]    Script Date: 15/04/2018 13:21:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report spRpOnlyProfessionalSpeciality-v1.0>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyProfessionalSpeciality-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdProfessional INT = 0,
	@Visible INT = 1
	AS
	BEGIN
		SELECT [S].[Description]
		FROM Specialty AS [S]  
		INNER JOIN ProfessionalSpeciality AS [Ps] ON [Ps].[IdSpeciality] = [S].[IdSpecialty]
		INNER JOIN Professional AS [P] ON [Ps].[IdProfessional] = [P].[IdProfessional]
		WHERE [P].[IdProfessional] = @IdProfessional AND [S].[Visible] = @Visible		
	END
GO


