USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmPatientSocialWork-v1.0]    Script Date: 15/04/2018 13:13:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/07 11:15>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPatientSocialWork-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdPatientSocialWork int = 0,
	@IdSocialWork int = 0,
	@IdPatient int = 0,
	@AffiliateNumber varchar(50) = null,
    @Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdPatientSocialWork],[IdSocialWork],[IdPatient],[AffiliateNumber],[Visible]
		FROM [dbo].[PatientSocialWork]
		WHERE [IdPatient] = @IdPatient 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientSocialWork] WHERE [IdPatient] = @IdPatient )
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdPatientSocialWork],[IdSocialWork],[IdPatient],[AffiliateNumber],[Visible]
		FROM [dbo].[PatientSocialWork]
		WHERE [idSocialWork] = @idSocialWork --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientSocialWork] WHERE [idPatientSocialWork] = @idPatientSocialWork )--AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO PatientSocialWork ([IdSocialWork],[IdPatient],[AffiliateNumber])
			VALUES (@IdSocialWork,@IdPatient,@AffiliateNumber)
			COMMIT TRANSACTION
			RETURN @@identity
			END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[INSERT]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 3	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			UPDATE [dbo].[PatientSocialWork] 
			SET 
			[IdPatient] = @IdPatient,
			[IdSocialWork] = @IdSocialWork,
			[AffiliateNumber] = @AffiliateNumber,
			[Visible] = @Visible
			WHERE [idPatientSocialWork] = @idPatientSocialWork
			COMMIT TRANSACTION
			RETURN @idSocialWork
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[UPDATE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 4	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM [dbo].[PatientSocialWork] WHERE [idPatientSocialWork] = @idPatientSocialWork
			COMMIT TRANSACTION
			RETURN 1
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 5	
	BEGIN
		SELECT [idPatientSocialWork] AS 'Id', [AffiliateNumber] AS 'Value' 
		FROM [dbo].[PatientSocialWork]
		WHERE 
		--[Address] = @Address 
		--AND [Name] = @Name
		[Visible] = @Visible
		ORDER BY [AffiliateNumber] ASC
	END
END

GO


