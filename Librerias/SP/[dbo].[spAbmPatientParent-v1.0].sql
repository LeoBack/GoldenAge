USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmPatientParent-v1.0]    Script Date: 15/04/2018 13:12:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andres>
-- Create date: <2017/09/10 00:30>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPatientParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idPatientParent int = 0,
	@idPatient int = 0,
	@idParent int = 0,
	@IdRelationship int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idPatientParent],[idPatient],[idParent],[IdRelationship],[Visible]
		FROM [dbo].[PatientParent]
		WHERE [idPatient] = @idPatient--[Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientParent] WHERE [idPatient] = @idPatient) --[Visible] = @Visible )
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idPatientParent],[idPatient],[idParent],[IdRelationship],[Visible]
		FROM [dbo].[PatientParent]
		WHERE [idPatientParent] = @idPatientParent --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientParent] WHERE [idPatientParent] = @idPatientParent)-- AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO PatientParent ([idPatient],[idParent],[IdRelationship],[Visible])
			VALUES (@idPatient,@idParent,@IdRelationship,@Visible)
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
			UPDATE [dbo].[PatientParent] 
			SET 
			[idPatient] = @idPatient,
			[idParent] = @idParent,
			[IdRelationship] = @IdRelationship,
			[Visible] = @Visible
			WHERE [idPatientParent] = @idPatientParent
			COMMIT TRANSACTION
			RETURN @idPatientParent
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
			DELETE FROM [dbo].[PatientParent] WHERE [idPatientParent] = @idPatientParent
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
		SELECT [idPatientParent] AS 'Id', [Visible] AS 'Value' 
		FROM [dbo].[PatientParent]
		WHERE [idParent] = @idParent 
		AND [idPatient] = @idPatient
		AND [Visible] = @Visible
		ORDER BY [Visible] ASC
	END
END


GO


