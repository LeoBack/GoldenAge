USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmPatientAccess-v1.0]    Script Date: 15/04/2018 13:12:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/03/02 17:28>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPatientAccess-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdPatientAccess int = 0,
	@IdPatient int = 0,
	@IE int = 0,
	@Date date = null,
	@Reason varchar(300) = null,
	@Visible int = 1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdPatientAccess],[IdPatient],[IE],[Date],[Reason],[Visible]
		FROM [dbo].[PatientAccess]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientAccess] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdPatientAccess],[IdPatient],[IE],[Date],[Reason],[Visible]
		FROM [dbo].[PatientAccess]
		WHERE [IdPatientAccess] = @IdPatientAccess AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientAccess] WHERE [IdPatientAccess] = @IdPatientAccess AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[PatientAccess] ([IdPatient],[IE],[Date],[Reason])
			VALUES (@IdPatient, @IE, @Date, @Reason)
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
			UPDATE [dbo].[PatientAccess] 
			SET 
			[IdPatient] = @IdPatient,
			[IE] = @IE,
			[Date] = @Date,
			[Reason] = @Reason,
			[Visible] = @Visible
			WHERE [IdPatientAccess] = @IdPatientAccess
			COMMIT TRANSACTION
			RETURN @IdPatientAccess
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
			DELETE FROM [dbo].[PatientAccess] WHERE [IdPatientAccess] = @IdPatientAccess
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
	SELECT [IdPatientAccess] AS 'Id',[IdPatient] AS 'Value' 
	FROM [dbo].[PatientAccess]
	WHERE [Visible] = @Visible
	ORDER BY [IdPatient] ASC
	END
END


GO


