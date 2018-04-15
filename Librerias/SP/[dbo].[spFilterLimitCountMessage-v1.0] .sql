USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitCountMessage-v1.0]    Script Date: 15/04/2018 13:16:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 22:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitCountMessage-v1.0] 
	-- Add the parameters for the stored procedure here
	@DestinationRead INT = 1,
	@IdProfessional INT = 0,
	@IdSpeciality INT = 0,
	@Visible INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @rCount INT
	IF (@IdProfessional = 0 AND @IdSpeciality = 0) 		-- 00
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([idDiagnostic]) FROM [dbo].[Diagnostic]
			--WHERE 
			--AND [IdDestinationSpeciality] = @IdSpeciality
			--AND [IdDestinationProfessional] = @IdProfessional
			--AND [Visible] = @Visible
		)
	END

	IF (@IdProfessional = 0 AND @IdSpeciality != 0) 		-- 01
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([idDiagnostic]) FROM [dbo].[Diagnostic]
			WHERE 
			[IdDestinationSpeciality] = @IdSpeciality
			--AND [IdDestinationProfessional] = @IdProfessional
			--AND [Visible] = @Visible
		)
	END

	IF (@IdProfessional != 0 AND @IdSpeciality != 0)		--10
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([idDiagnostic]) FROM [dbo].[Diagnostic]
			WHERE 
			--AND [IdDestinationSpeciality] = @IdSpeciality
			[IdDestinationProfessional] = @IdProfessional
			--AND [Visible] = @Visible
		)
	END

	IF (@IdProfessional != 0 AND @IdSpeciality != 0)		--11                                              
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([idDiagnostic]) FROM [dbo].[Diagnostic]
			WHERE 
			[IdDestinationSpeciality] = @IdSpeciality
			AND [IdDestinationProfessional] = @IdProfessional
			--AND [Visible] = @Visible
		)
	END 
	RETURN @rCount
END
GO


