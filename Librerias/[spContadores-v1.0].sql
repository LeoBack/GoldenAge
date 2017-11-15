USE [DEFAULT02.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spListDiagnostic-v1.0]    Script Date: 14/11/2017 21:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/14 17:00>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spContadores-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdProfessional INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @cMessage INT
	SET @cMessage = (SELECT COUNT([idDiagnostic]) 
					FROM [Diagnostic] 
					WHERE [DestinationRead] = 1
					AND [Visible] = 1
					AND [IdDestinationProfessional] = @idProfessional)

	DECLARE @cProfessional INT
	SET @cProfessional = (SELECT COUNT([idProfessional]) 
					FROM [Professional] 
					WHERE [Visible] = 1)

	DECLARE @cPatient INT
	SET @cPatient = (SELECT COUNT([idPatient]) 
					FROM [Patient] 
					WHERE [Visible] = 1)

	DECLARE @cSocialWork INT
	SET @cSocialWork = (SELECT COUNT([idSocialWork]) 
					FROM [SocialWork] 
					WHERE [Visible] = 1)

	SELECT @cMessage AS 'cMessage', @cPatient AS 'cPatient', @cProfessional AS 'cProfessional', @cSocialWork AS 'cSocialWorks'

END