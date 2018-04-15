USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmProfessionalSpeciality-v1.0]    Script Date: 15/04/2018 13:14:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andres>
-- Create date: <2017/09/11 13:07>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmProfessionalSpeciality-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idProfessionalSpeciality int = 0,
	@IdProfessional int = 0,
	@IdSpeciality int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idProfessionalSpeciality],[IdProfessional],[IdSpeciality],[Visible]
		FROM [dbo].[ProfessionalSpeciality]
		WHERE [idProfessional] = @idProfessional --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[ProfessionalSpeciality] WHERE [idProfessional] = @idProfessional)-- AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idProfessionalSpeciality],[IdProfessional],[IdSpeciality],[Visible]
		FROM [dbo].[ProfessionalSpeciality]
		WHERE [idProfessionalSpeciality] = @idProfessionalSpeciality AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[ProfessionalSpeciality] WHERE [idProfessionalSpeciality] = @idProfessionalSpeciality AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO ProfessionalSpeciality ([IdProfessional],[IdSpeciality],[Visible])
			VALUES (@IdProfessional,@IdSpeciality,@Visible)
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
			UPDATE [dbo].[ProfessionalSpeciality] 
			SET 
			[IdProfessional] = @IdProfessional,
			[IdSpeciality] = @IdSpeciality,
			[Visible] = @Visible
			WHERE [idProfessionalSpeciality] = @idProfessionalSpeciality
			COMMIT TRANSACTION
			RETURN @idProfessionalSpeciality
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
			DELETE FROM [dbo].[ProfessionalSpeciality] WHERE [idProfessionalSpeciality] = @idProfessionalSpeciality
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
		SELECT [idProfessionalSpeciality] AS 'Id', [Visible] AS 'Value' 
		FROM [dbo].[ProfessionalSpeciality]
		WHERE [IdSpeciality] = @IdSpeciality 
		AND [IdProfessional] = @IdProfessional
		AND [Visible] = @Visible
		ORDER BY [Visible] ASC
	END
END



GO


