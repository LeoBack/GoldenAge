USE [GOLDENAGE-03.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmPatientState-v1.0]    Script Date: 14/04/2018 13:20:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/07 11:15>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPatientState-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdPatientState int = 0,
	@IdPatient int = 0,
	@Description varchar(50) = null,
	@Date datetime,
    @State int = 1,
    @Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdPatientState],[IdPatient],[Description],[Date],[State],[Visible]
		FROM [dbo].[PatientState]
		WHERE [IdPatient] = @IdPatient 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientState] WHERE [IdPatient] = @IdPatient )
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdPatientState],[IdPatient],[Description],[Date],[State],[Visible]
		FROM [dbo].[PatientState]
		WHERE [IdPatientState] = @IdPatientState --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientState] WHERE [IdPatientState] = @IdPatientState )--AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO PatientState ([IdPatient],[Description],[Date],[State])
			VALUES (@IdPatient,@Description,@Date,@State)
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
			UPDATE [dbo].[PatientState] 
			SET 
			[IdPatient] = @IdPatient,
			[Description] = @Description,
			[Date] = @Date,
			[State] = @State,
			[Visible] = @Visible
			WHERE [idPatientState] = @idPatientState
			COMMIT TRANSACTION
			RETURN @idPatientState
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
			DELETE FROM [dbo].[PatientState] WHERE [idPatientState] = @idPatientState
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
		SELECT [idPatientState] AS 'Id', [Date] AS 'Value' 
		FROM [dbo].[PatientState]
		WHERE 
		--[Address] = @Address 
		--AND [Name] = @Name
		[Visible] = @Visible
		ORDER BY [Date] ASC
	END
END

GO


