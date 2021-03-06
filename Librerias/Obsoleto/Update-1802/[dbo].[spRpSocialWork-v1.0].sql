USE [DEFAULT02.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpClinicHistory-v1.0]    Script Date: 08/02/2018 21:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/08 21:07>
-- Description:	<Report spRpSocialWork>
-- =============================================
CREATE PROCEDURE [dbo].[spRpSocialWork-v1.0] 
	-- Add the parameters for the stored procedure here
	@Id INT = 0,
	@Visible INT = 1
	AS
	BEGIN
		SELECT [S].[Name] AS 'Obra Social', [P].[AffiliateNumber] AS 'N. Afiliado'
		FROM [dbo].[SocialWork] AS S 
		INNER JOIN [dbo].[PatientSocialWork] AS P ON [S].[IdSocialWork] = [P].[IdSocialWork]
		WHERE [P].[IdPatient] = @Id AND [S].[Visible] = @Visible
		ORDER BY 1
END