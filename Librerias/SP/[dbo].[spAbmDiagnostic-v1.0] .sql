USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmDiagnostic-v1.0]    Script Date: 15/04/2018 13:10:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmDiagnostic-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idDiagnostic int = 0,
	@IdSpeciality int = 0,
	@IdPatient int = 0,
	@IdProfessional int =0,
	@Detail text,
	@Date datetime,
	@IdDestinationSpeciality int=0,
	@IdDestinationProfessional int=0,
	@DestinationRead int=0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDiagnostic],[IdSpeciality],[IdPatient],[IdProfessional],[Detail],[Date],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible]
		FROM [dbo].[Diagnostic]
		WHERE --[Visible] = @Visible 
		[IdPatient]=@IdPatient 
		RETURN (SELECT COUNT(*) FROM [dbo].[Diagnostic] WHERE [IdPatient]=@IdPatient )--WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDiagnostic],[IdSpeciality],[IdPatient],[IdProfessional],[Detail],[Date],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible]
		FROM [dbo].[Diagnostic]
		WHERE [idDiagnostic] = @idDiagnostic --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Diagnostic] WHERE [idDiagnostic] = @idDiagnostic)-- AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Diagnostic ([IdSpeciality],[IdPatient],[IdProfessional],[Detail],[Date],[IdDestinationSpeciality],[IdDestinationProfessional],[DestinationRead],[Visible])
			VALUES (@IdSpeciality,@IdPatient,@IdProfessional,@Detail,@Date,@IdDestinationSpeciality,@IdDestinationProfessional,@DestinationRead,@Visible)
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
			UPDATE [dbo].[Diagnostic] 
			SET 
			[IdSpeciality] = @IdSpeciality,
			[IdPatient]=@IdPatient,
			[IdProfessional]=@IdProfessional,
			[Detail] = @Detail,
			[Date] = @Date,
			[IdDestinationSpeciality]=@IdDestinationSpeciality,
			[IdDestinationProfessional]=@IdDestinationProfessional,
			[DestinationRead]=@DestinationRead,
			[Visible] = @Visible
			WHERE [idDiagnostic] = @idDiagnostic
			COMMIT TRANSACTION
			RETURN @idDiagnostic
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
			DELETE FROM [dbo].[Diagnostic] WHERE [idDiagnostic] = @idDiagnostic
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
		SELECT [idDiagnostic] AS 'Id', [Date] AS 'Value' 
		FROM [dbo].[Diagnostic]
		WHERE-- [DiagnosticDate] = @DiagnosticDate 
		--AND [IdSpeciality] = @IdSpeciality
		 [Visible] = @Visible
		ORDER BY [Date] ASC
	END
END

GO


