USE [GOLDENAGE-04]
GO
/****** Object:  UserDefinedFunction [dbo].[StringSex]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[StringSex]
(
	@IntSex INT = 0
)
RETURNS VARCHAR(10)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @rVar VARCHAR(10)

	-- Add the T-SQL statements to compute the return value here
	IF (@IntSex = 1)
		SET @rVar = 'Masculino';
	ELSE
		SET @rVar = 'Femenino';

	-- Return the result of the function
	RETURN @rVar

END
GO
/****** Object:  StoredProcedure [dbo].[spAbmDiagnostic-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmIvaType-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmIvaType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idIvaType int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idIvaType],[Description],[Visible]
		FROM [dbo].[IvaType]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[IvaType] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idIvaType],[Description],[Visible]
		FROM [dbo].[IvaType]
		WHERE [idIvaType] = @idIvaType AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[IvaType] WHERE [idIvaType] = @idIvaType AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[IvaType] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[IvaType] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idIvaType] = @idIvaType
			COMMIT TRANSACTION
			RETURN @idIvaType
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
			DELETE FROM [dbo].[IvaType] WHERE [idIvaType] = @idIvaType
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
	SELECT [idIvaType] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[IvaType]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmLocationCity-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLocationCity-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idLocationCity int = 0,
	@idLocationProvince int = 0,
	@idLocationCountry int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idLocationCity],[idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCity]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCity] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idLocationCity],[idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCity]
		WHERE [idLocationCity] = @idLocationCity AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCity] WHERE [idLocationCity] = @idLocationCity AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO LocationCity ([idLocationCountry],[idLocationProvince],[Description])
			VALUES (@idLocationCountry, @idLocationProvince, @Description)
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
			UPDATE [dbo].[LocationCity] 
			SET 
			[idLocationProvince] = @idLocationProvince,
			[idLocationCountry] = @idLocationCountry,
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idLocationCity] = @idLocationCity
			COMMIT TRANSACTION
			RETURN @idLocationCity
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
			DELETE FROM [dbo].[LocationCity] WHERE [idLocationCity] = @idLocationCity
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
		SELECT [idLocationCity] AS 'Id', [Description] AS 'Value' 
		FROM [dbo].[LocationCity]
		WHERE [idLocationCountry] = @idLocationCountry 
		AND [idLocationProvince] = @idLocationProvince
		AND [Visible] = @Visible
		ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmLocationCountry-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLocationCountry-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idLocationCountry int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCountry]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCountry] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCountry]
		WHERE [idLocationCountry] = @idLocationCountry AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCountry] WHERE [idLocationCountry] = @idLocationCountry AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[LocationCountry] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[LocationCountry] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idLocationCountry] = @idLocationCountry
			COMMIT TRANSACTION
			RETURN @idLocationCountry
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
			DELETE FROM [dbo].[LocationCity] WHERE [idLocationCountry] = @idLocationCountry
			DELETE FROM [dbo].[LocationProvince] WHERE [idLocationCountry] = @idLocationCountry
			DELETE FROM [dbo].[LocationCountry] WHERE [idLocationCountry] = @idLocationCountry
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
	SELECT [idLocationCountry] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[LocationCountry]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmLocationProvince-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLocationProvince-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idLocationProvince int = 0,
	@idLocationCountry int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationProvince]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationProvince] WHERE [Visible] = @Visible )
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationProvince]
		WHERE [idLocationProvince] = @idLocationProvince AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationProvince] WHERE [idLocationProvince] = @idLocationProvince AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[LocationProvince] ([idLocationCountry],[Description])
			VALUES (@idLocationCountry, @Description)
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
			UPDATE [dbo].[LocationProvince] 
			SET 
			[idLocationCountry] = @idLocationCountry,
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idLocationProvince] = @idLocationProvince
			COMMIT TRANSACTION
			RETURN @idLocationProvince
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
			DELETE FROM [dbo].[LocationCity] WHERE [idLocationProvince] = @idLocationProvince
			DELETE FROM [dbo].[LocationProvince] WHERE [idLocationProvince] = @idLocationProvince
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
		SELECT [idLocationProvince] AS 'Id', [Description] AS 'Value' 
		FROM [dbo].[LocationProvince]
		WHERE [idLocationCountry] = @idLocationCountry
		AND [Visible] = @Visible
		ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmParent-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/21 19:52>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm INT = 0,
	@IdParent INT = 0,
	@Name VARCHAR(50) = NULL,
	@LastName VARCHAR(50) = NULL,
	@IdTypeDocument INT = 0,
	@NumberDocument INT = 0,
	@Phone VARCHAR(50) = NULL,
    @AlternativePhone VARCHAR(50) = NULL,
	@Email VARCHAR(50) = NULL,
	@IdLocationCountry INT = 0,
    @IdLocationProvince INT = 0,
    @IdLocationCity INT = 0,
	@Address VARCHAR(50) = NULL,
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- Interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		IF @IdTypeDocument != 0 AND @NumberDocument != 0
		BEGIN
			SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
			FROM [dbo].[Parent]
			WHERE [IdTypeDocument] = @IdTypeDocument
			AND [NumberDocument] = @NumberDocument
			--AND [Visible] = @Visible
			RETURN (SELECT COUNT(*) FROM [dbo].[Parent] WHERE [IdTypeDocument] = @IdTypeDocument AND [NumberDocument] = @NumberDocument) --AND [Visible] = @Visible)
		END
		ELSE
		BEGIN
			SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
			FROM [dbo].[Parent]
			--WHERE [Visible] = @Visible 
			RETURN (SELECT COUNT(*) FROM [dbo].[Parent]) --WHERE [Visible] = @Visible)
		END
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
		FROM [dbo].[Parent]
		WHERE [IdParent] = @IdParent --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Parent] WHERE [IdParent] = @IdParent) --AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Parent ([Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible])
			VALUES (@Name,@LastName,@IdTypeDocument,@NumberDocument,@Phone,@AlternativePhone,@Email,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Visible)
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
			UPDATE [dbo].[Parent] 
			SET 
			[Name] = @Name,
		    [LastName] = @LastName,
			[IdTypeDocument] = @IdTypeDocument,
			[NumberDocument] = @NumberDocument,
			[Phone] = @Phone,
			[AlternativePhone] = @AlternativePhone,
			[Email] = @Email,
			[IdLocationCountry] = @IdLocationCountry,
			[IdLocationProvince] = @IdLocationProvince,
			[IdLocationCity] = @IdLocationCity,
			[Address] = @Address,
			[Visible] = @Visible
			WHERE [IdParent] = @IdParent
			COMMIT TRANSACTION
			RETURN @IdParent
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
			DELETE FROM [dbo].[Parent] WHERE [IdParent] = @IdParent
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
		SELECT [IdParent] AS 'Id', [Name] AS 'Value' 
		FROM [dbo].[Parent]
		WHERE [Address] = @Address 
		AND [Name] = @Name
		AND [Visible] = @Visible
		ORDER BY [Name] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmPatientParent-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmPatientSocialWork-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
		WHERE [idPatientSocialWork] = @idPatientSocialWork --AND [Visible] = @Visible 
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
/****** Object:  StoredProcedure [dbo].[spAbmPatientState-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmPatient-v1.2]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/04/14 11:15>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPatient-v1.2] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdPatient int = 0,
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@Birthdate datetime ,
	@IdTypeDocument int =0,
    @NumberDocument int=0,
	@Sex int = 0,
	@idLocationCountry int = 0,
    @idLocationProvince int = 0,
    @idLocationCity int = 0,
	@Address varchar(50) = null,
	@Phone varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Visible]
		FROM [dbo].[Patient]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Patient]) --WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Visible]
		FROM [dbo].[Patient]
		WHERE [IdPatient] = @IdPatient --AND 
		--[Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Patient] WHERE [IdPatient] = @IdPatient)-- AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Patient ([Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Visible])
			VALUES (@Name,@LastName,@Birthdate,@IdTypeDocument,@NumberDocument,@Sex,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Phone,@Visible)
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
			UPDATE [dbo].[Patient] 
			SET 
			[Name] = @Name,
		    [LastName] = @LastName,
			[Birthdate] = @Birthdate,
			[IdTypeDocument] = @IdTypeDocument,
			[NumberDocument] = @NumberDocument,
			[Sex] = @Sex,
			[idLocationCountry] = @idLocationCountry,
			[idLocationProvince] = @idLocationProvince,
			[idLocationCity] = @idLocationCity,
			[Address] = @Address,
			[Phone] = @Phone,
			[Visible] = @Visible
			WHERE [IdPatient] = @IdPatient
			COMMIT TRANSACTION
			RETURN @IdPatient
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
			DELETE FROM [dbo].[Patient] WHERE [IdPatient] = @IdPatient
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
		SELECT [IdPatient] AS 'Id', [Name] AS 'Value' 
		FROM [dbo].[Patient]
		WHERE [Visible] = @Visible
		ORDER BY [Name] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmPermission-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPermission-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idPermission int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idPermission],[Description],[Visible]
		FROM [dbo].[Permission]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Permission] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idPermission],[Description],[Visible]
		FROM [dbo].[Permission]
		WHERE [idPermission] = @idPermission AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Permission] WHERE [idPermission] = @idPermission AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Permission] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[Permission] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idPermission] = @idPermission
			COMMIT TRANSACTION
			RETURN @idPermission
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
			DELETE FROM [dbo].[Permission] WHERE [idPermission] = @idPermission
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
	SELECT [idPermission] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[Permission]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmProfessionalSpeciality-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmProfessional-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAbmProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdProfessional int = 0,
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@ProfessionalRegistration varchar(50) = null,
	@idLocationCountry int = 0,
    @idLocationProvince int = 0,
    @idLocationCity int = 0,
	@Address varchar(50) = null,
	@Phone varchar(50) = null,
    @Mail varchar(50) = null,
	@User varchar(50) = null,
	@Password varchar(50) = null,
	@idPermission int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible]
		FROM [dbo].[Professional]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Professional])-- WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible]
		FROM [dbo].[Professional]
		WHERE [IdProfessional] = @IdProfessional --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Professional] WHERE [IdProfessional] = @IdProfessional) --AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Professional ([Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible])
			VALUES (@Name,@LastName,@ProfessionalRegistration,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Phone,@Mail,@User,@Password,@idPermission,@Visible)
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
			UPDATE [dbo].[Professional] 
			SET 
			[Name] = @Name,
		    [LastName] = @LastName,
			[ProfessionalRegistration] = @ProfessionalRegistration,
			[idLocationCountry] = @idLocationCountry,
			[idLocationProvince] = @idLocationProvince,
			[idLocationCity] = @idLocationCity,
			[Address] = @Address,
			[Phone] = @Phone,
			[Mail] = @Mail,
			[User] = @User,
			[Password] = @Password,
			[idPermission]=@idPermission,
			[Visible] = @Visible
			WHERE [IdProfessional] = @IdProfessional
			COMMIT TRANSACTION
			RETURN @IdProfessional
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
			DELETE FROM [dbo].[Professional] WHERE [IdProfessional] = @IdProfessional
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
		SELECT [IdProfessional] AS 'Id', [Name] AS 'Value' 
		FROM [dbo].[Professional]
		WHERE 
		[Visible] = @Visible
		ORDER BY [Name] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmRelationship-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmRelationship-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idRelationship int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idRelationship],[Description],[Visible]
		FROM [dbo].[Relationship]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Relationship]) --WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idRelationship],[Description],[Visible]
		FROM [dbo].[Relationship]
		WHERE [idRelationship] = @idRelationship --AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Relationship] WHERE [idRelationship] = @idRelationship)-- AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Relationship] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[Relationship] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idRelationship] = @idRelationship
			COMMIT TRANSACTION
			RETURN @idRelationship
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
			DELETE FROM [dbo].[Relationship] WHERE [idRelationship] = @idRelationship
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
	SELECT [idRelationship] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[Relationship]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmSocialWork-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmSocialWork-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idSocialWork int = 0,
	@Name varchar(50) = null,
	@Description varchar(50) = null,
	@IdIvaType int=0,
	@IdLocationCountry int = 0,
    @IdLocationProvince int = 0,
    @IdLocationCity int = 0,
	@Address varchar(50) = null,
	@Phone varchar(50) = null,
    @Contact varchar(50) = null,
    @Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idSocialWork],[Name],[Description],[IdIvaType],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Address],[Phone],[Contact],[Visible]
		FROM [dbo].[SocialWork]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[SocialWork] )--WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idSocialWork],[Name],[Description],[IdIvaType],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Address],[Phone],[Contact],[Visible]
		FROM [dbo].[SocialWork]
		WHERE [idSocialWork] = @idSocialWork --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[SocialWork] WHERE [idSocialWork] = @idSocialWork )--AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO SocialWork ([Name],[Description],[IdIvaType],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Address],[Phone],[Contact],[Visible])
			VALUES (@Name,@Description,@IdIvaType,@IdLocationCountry,@IdLocationProvince,@IdLocationCity,@Address,@Phone,@Contact,@Visible)
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
			UPDATE [dbo].[SocialWork] 
			SET 
			[Name] = @Name,
			[Description] = @Description,
			[IdIvaType]= @IdIvaType,
			[IdLocationCountry] = @IdLocationCountry,
			[IdLocationProvince] = @IdLocationProvince,
			[IdLocationCity] = @IdLocationCity,
			[Address] = @Address,
			[Phone] = @Phone,
			[Contact] = @Contact,
			[Visible] = @Visible
			WHERE [idSocialWork] = @idSocialWork
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
			DELETE FROM [dbo].[SocialWork] WHERE [idSocialWork] = @idSocialWork
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
		SELECT [idSocialWork] AS 'Id', [Name] AS 'Value' 
		FROM [dbo].[SocialWork]
		WHERE 
		--[Address] = @Address 
		--AND [Name] = @Name
		[Visible] = @Visible
		ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmSpecialty-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmSpecialty-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idSpecialty int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idSpecialty],[Description],[Visible]
		FROM [dbo].[Specialty]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Specialty] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idSpecialty],[Description],[Visible]
		FROM [dbo].[Specialty]
		WHERE [idSpecialty] = @idSpecialty AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Specialty] WHERE [idSpecialty] = @idSpecialty AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Specialty] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[Specialty] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idSpecialty] = @idSpecialty
			COMMIT TRANSACTION
			RETURN @idSpecialty
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
			DELETE FROM [dbo].[Specialty] WHERE [idSpecialty] = @idSpecialty
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
	SELECT [idSpecialty] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[Specialty]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmTypeDocument-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmTypeDocument-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idTypeDocument int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idTypeDocument],[Description],[Visible]
		FROM [dbo].[TypeDocument]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[TypeDocument] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idTypeDocument],[Description],[Visible]
		FROM [dbo].[TypeDocument]
		WHERE [idTypeDocument] = @idTypeDocument AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[TypeDocument] WHERE [idTypeDocument] = @idTypeDocument AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[TypeDocument] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[TypeDocument] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idTypeDocument] = @idTypeDocument
			COMMIT TRANSACTION
			RETURN @idTypeDocument
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
			DELETE FROM [dbo].[TypeDocument] WHERE [idTypeDocument] = @idTypeDocument
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
	SELECT [idTypeDocument] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[TypeDocument]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmTypeParent-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmTypeParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idTypeParent int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idTypeParent],[Description],[Visible]
		FROM [dbo].[TypeParent]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[TypeParent] )--WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idTypeParent],[Description],[Visible]
		FROM [dbo].[TypeParent]
		WHERE [idTypeParent] = @idTypeParent --AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[TypeParent] WHERE [idTypeParent] = @idTypeParent)-- AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[TypeParent] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[TypeParent] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idTypeParent] = @idTypeParent
			COMMIT TRANSACTION
			RETURN @idTypeParent
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
			DELETE FROM [dbo].[TypeParent] WHERE [idTypeParent] = @idTypeParent
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
	SELECT [idTypeParent] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[TypeParent]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spContadores-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitCountMessage-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
/****** Object:  StoredProcedure [dbo].[spFilterLimitCountPatient-v1.1]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/08 16:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
create PROCEDURE [dbo].[spFilterLimitCountPatient-v1.1] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@AffiliateNumber varchar(50) = null,
	@NumberDocument int =0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @rCount INT
	IF (@Name='' AND @LastName='' AND @NumberDocument=0)		-- 000
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			--WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			--[NumberDocument] = @NumberDocument AND
			--[Visible] = @Visible
		)
	END
	IF (@Name='' AND @LastName='' AND @NumberDocument!=0)		--001
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END
	IF (@Name='' AND @LastName!='' AND @NumberDocument=0)		--010
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' --AND 
			--[NumberDocument] = @NumberDocument AND
			--[Visible] = @Visible
		)
	END
	IF (@Name='' AND @LastName!='' AND @NumberDocument!=0)		--011                                                
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' AND
			[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END 
	IF (@Name!='' AND @LastName!='' AND @NumberDocument=0)		--100                                               
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' --AND 
			--[LastName] like +'%'+@LastName+'%' --AND 
			--[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END 
	IF (@Name!='' AND @LastName!='' AND @NumberDocument!=0)		--101 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND
			[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END 
	IF (@Name!='' AND @LastName!='' AND @NumberDocument=0)		--110 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' --AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' --AND 
			--[NumberDocument] = @NumberDocument AND
			--[Visible] = @Visible
		)
	END 
	IF (@Name='' AND @LastName!='' AND @NumberDocument!=0)		--111 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' AND 
			[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END 
	RETURN @rCount
END
GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitCountProfesionales-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 22:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitCountProfesionales-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LastName VARCHAR(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @rCount INT
	IF (@Name = '' AND @LastName = '')  
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdProfessional]) FROM [dbo].[Professional]
			--WHERE 
			--[Name] LIKE +'%'+ @Name +'%'
			--AND [LastName] LIKE +'%'+ @LastName +'%'
			--AND [Visible] = @Visible
		)
	END
	IF (@Name = '' AND @LastName != '')	
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdProfessional]) FROM [dbo].[Professional]
			WHERE 
			--[Name] LIKE +'%'+ @Name +'%' AND
			[LastName] LIKE +'%'+ @LastName +'%'
			--AND [Visible] = @Visible
		)
	END
	IF (@Name != '' AND @LastName = '')	
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdProfessional]) FROM [dbo].[Professional]
			WHERE 
			[Name] LIKE +'%'+ @Name +'%' 
			--AND [LastName] LIKE +'%'+ @LastName +'%'
			--AND [Visible] = @Visible
		)
	END
	IF (@Name != '' AND @LastName != '')															--11                                                
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdProfessional]) FROM [dbo].[Professional]
			WHERE 
			[Name] LIKE +'%'+ @Name +'%'
			AND [LastName] LIKE +'%'+ @LastName +'%'
			--AND [Visible] = @Visible
		)
	END 
	RETURN @rCount
END
GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitCountSocialWork-1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 18:00>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitCountSocialWork-1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = '',
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @rCount INT
	if(@Name!='')
	BEGIN
		SET @rCount = (SELECT COUNT([IdSocialWork]) FROM [dbo].[SocialWork]
		WHERE [Name] like +'%'+ @Name +'%'
		--AND [Visible] = @Visible
		)
	END
	if(@Name='')
	BEGIN
		SET @rCount = (SELECT COUNT([IdSocialWork]) FROM [dbo].[SocialWork]
		--WHERE
		--AND [Name] like +'%'+ @Name +'%' 
		--AND [Visible] = @Visible
		)
	END
	RETURN @rCount
END
GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitMessage-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--- Author:		<Back Leonardo>
-- Create date: <2017/11/20 18:00>
-- Description:	<Lista con paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitMessage-v1.0] 
	-- Add the parameters for the stored procedure here
	@DestinationRead INT = 1,
	@IdProfessional INT = 0,
	@IdSpeciality INT = 0,
	@Pag INT = 1,		-- Id actual
	@RowsShow INT = 1,	-- Cantidad de filAS a mostrar
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF (@IdProfessional = 0 AND @IdSpeciality = 0)                                                            --00
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [D].[Date] ASC) AS RowNum, [D].[idDiagnostic], [D].[Date] AS 'Fecha',
			CONCAT([Pr].[LAStName],', ', [Pr].[Name]) AS 'Enviado por',
			[S].[Description] AS 'Especialidad',
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[Visible]
			FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			--AND [D].[IdDestinationSpeciality] = @IdSpeciality
			--AND [D].[IdDestinationProfessional] = @IdProfessional
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF (@IdProfessional = 0 AND @IdSpeciality != 0) 															--01                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [D].[Date] ASC) AS RowNum, [D].[idDiagnostic], [D].[Date] AS 'Fecha',
			CONCAT([Pr].[LAStName],', ', [Pr].[Name]) AS 'Enviado por',
			[S].[Description] AS 'Especialidad',
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[Visible]
			FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			AND [D].[IdDestinationSpeciality] = @IdSpeciality
			--AND [D].[IdDestinationProfessional] = @IdProfessional
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END 
	IF (@IdProfessional != 0 AND @IdSpeciality = 0) 														--10                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [D].[Date] ASC) AS RowNum, [D].[idDiagnostic], [D].[Date] AS 'Fecha',
			CONCAT([Pr].[LAStName],', ', [Pr].[Name]) AS 'Enviado por',
			[S].[Description] AS 'Especialidad',
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[Visible]
			FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			--AND [D].[IdDestinationSpeciality] = @IdSpeciality
			AND [D].[IdDestinationProfessional] = @IdProfessional
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF (@IdProfessional != 0 AND @IdSpeciality != 0) 														--11                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [D].[Date] ASC) AS RowNum, [D].[idDiagnostic], [D].[Date] AS 'Fecha',
			CONCAT([Pr].[LAStName],', ', [Pr].[Name]) AS 'Enviado por',
			[S].[Description] AS 'Especialidad',
			(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
			[D].[Visible]
			FROM Diagnostic AS [D]
			INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
			INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[DestinationRead] = @DestinationRead 
			AND [D].[Visible] = @Visible
			AND [D].[IdDestinationSpeciality] = @IdSpeciality
			AND [D].[IdDestinationProfessional] = @IdProfessional
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END 
END
GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitPatient-v1.2]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/07 14:39>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitPatient-v1.2] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@NumberDocument int =0,
	@Pag INT = 1,		-- Id actual
	@RowsShow INT = 1,	-- Cantidad de filas a mostrar
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF (@Name='' AND @LastName='' AND @NumberDocument =0)     --000
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
			--WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			--[P].[NumberDocument] = @NumberDocument AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF(@Name='' AND @LastName='' AND @NumberDocument !=0)    --001 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			--[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[P].[NumberDocument] = @NumberDocument  --AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF (@Name='' AND @LastName!='' AND @NumberDocument=0)    --010 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' --AND 
			--[P].[NumberDocument] = @NumberDocument AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF(@Name='' AND @LastName!='' AND @NumberDocument!=0)	 --011 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' AND 
			[P].[NumberDocument] = @NumberDocument--AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF(@Name!='' AND @LastName='' AND @NumberDocument=0)	 --100 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
			INNER JOIN [dbo].[PatientSocialWork] AS Psw ON [P].[IdPatient] = [Psw].[IdPatient]
			WHERE 
			[P].[Name] like +'%'+@Name+'%' --AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			--[P].[NumberDocument] = @NumberDocument AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF(@Name!='' AND @LastName='' AND @NumberDocument!=0)	 --101 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
			WHERE 
			[P].[Name] like +'%'+@Name+'%' AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			[P].[NumberDocument] = @NumberDocument --AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF(@Name!='' AND @LastName!='' AND @NumberDocument=0)   --110 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
			WHERE 
			[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' --AND 
			--[P].[NumberDocument] = @NumberDocument AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF(@Name='' AND @LastName!='' AND @NumberDocument=0)   --111
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
			WHERE 
			[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' AND 
			[P].[NumberDocument] = @NumberDocument --AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitProfessional-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 22:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LastName VARCHAR(50) = null,
	@Pag INT = 1,		-- Id actual
	@RowsShow INT = 1,	-- Cantidad de filas a mostrar
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF (@Name = '' AND @LastName = '')                                                            --00
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [P].[Name] ASC) AS RowNum, [P].[IdProfessional], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',  [P].[Phone] AS 'Telefono', [P].[Mail] AS 'Correo',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[P].[Visible]
			FROM [dbo].[Professional] AS [P]
			INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
			--WHERE 
			--[Name] LIKE +'%'+ @Name +'%' AND
			--[LastName] LIKE +'%'+ @LastName +'%' AND 
			--[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF (@Name = '' AND @LastName != '')															--01                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [P].[Name] ASC) AS RowNum, [P].[IdProfessional], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',  [P].[Phone] AS 'Telefono', [P].[Mail] AS 'Correo',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[P].[Visible]
			FROM [dbo].[Professional] AS [P]
			INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
			WHERE 
			--[Name] LIKE +'%'+ @Name +'%' AND
			[LastName] LIKE +'%'+ @LastName +'%'  
			--[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END 
	IF (@Name != '' AND @LastName = '')															--10                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [P].[Name] ASC) AS RowNum, [P].[IdProfessional], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',  [P].[Phone] AS 'Telefono', [P].[Mail] AS 'Correo',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[P].[Visible]
			FROM [dbo].[Professional] AS [P]
			INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
			WHERE 
			[Name] LIKE +'%'+ @Name +'%' 
			--[LastName] LIKE +'%'+ @LastName +'%' AND 
			--[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF (@Name != '' AND @LastName != '')															--11                                                
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [P].[Name] ASC) AS RowNum, [P].[IdProfessional], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombres',  [P].[Phone] AS 'Telefono', [P].[Mail] AS 'Correo',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[P].[Visible]
			FROM [dbo].[Professional] AS [P]
			INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
			WHERE 
			[Name] LIKE +'%'+ @Name +'%' AND
			[LastName] LIKE +'%'+ @LastName +'%' --AND 
			--[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END 
END
GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitSocialWorks-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 18:00>
-- Description:	<Lista con paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitSocialWorks-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@Pag INT = 1,		-- Id actual
	@RowsShow INT = 1,	-- Cantidad de filAS a mostrar
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF (@Name!='')
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [S].[Name] ASC) AS RowNum, [S].[IdSocialWork],
			[S].[Name] AS 'Razon Social', [S].[Description] AS 'Descripción', [S].[Phone] AS 'Telefono',[S].[Contact] AS 'Contacto', 
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[S].[Address] AS 'Direccion', [S].[Visible]
			FROM [dbo].[SocialWork] AS [S]
			INNER JOIN LocationCountry AS [lCu] ON [S].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [S].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [S].[idLocationCity] = [lCy].[idLocationCity]
			WHERE [S].[Name] LIKE +'%'+ @Name +'%'
			--AND [Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	IF (@Name='')
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [S].[Name] ASC) AS RowNum, [S].[IdSocialWork],
			[S].[Name] AS 'Razon Social', [S].[Description] AS 'Descripción', [S].[Phone] AS 'Telefono',[S].[Contact] AS 'Contacto', 
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locación', 
			[S].[Address] AS 'Direccion', [S].[Visible]
			FROM [dbo].[SocialWork] AS [S]
			INNER JOIN LocationCountry AS [lCu] ON [S].[idLocationCountry] = [lCu].[idLocationCountry]
			INNER JOIN LocationProvince AS [lPv] ON [S].[idLocationProvince] = [lPv].[idLocationProvince]
			INNER JOIN LocationCity AS [lCy] ON [S].[idLocationCity] = [lCy].[idLocationCity]
			--WHERE [Name] LIKE +'%'+ @Name +'%'
			--AND [Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spLoguin-v1.0]    Script Date: 15/04/2018 12:46:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 16:37>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spLoguin-v1.0] 
	-- Add the parameters for the stored procedure here
	@Status int = 1,  --> Session: 0 Cerrar - 1 Abrir
	@User varchar(50) = null,
	@Password varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	BEGIN
	IF @Status = 1
		BEGIN
			DECLARE @Id INT
			SET @Id = (SELECT [IdProfessional] FROM [dbo].[Professional]
			WHERE [User] like @User 
			AND [Password] like @Password
			AND [Visible] = @Visible)
			IF @Id != 0
			BEGIN
				INSERT INTO [dbo].[Session] (IdProfessional, InitDate, EndDate) VALUES (@Id, GETDATE(), DATEADD(ss, 2, GETDATE()))
			END
			SELECT @Id
		END
		--ELSE
		--BEGIN
		--	UPDATE [dbo].[Session] SET EndDate = GETDATE() WHERE idProfessional 
		--END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spRpClinicHistory-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report spRpClinicHistory>
-- =============================================
CREATE PROCEDURE [dbo].[spRpClinicHistory-v1.0] 
	-- Add the parameters for the stored procedure here
	@Id INT = 0,
	@Only INT = 1,  -- 1= Un Diagnostico / 2= Todos los diagnosticos
	@Visible INT = 1
	AS
	BEGIN
	IF (@Only = 2)
		BEGIN	
			SELECT [D].[idDiagnostic], [S].[Description] AS 'Especialidad',
				CONCAT([Pr].[LastName],', ', [Pr].[Name]) AS 'Profesional', 
				[D].[Detail] AS 'Detalle', [D].[Date] as 'Fecha',    
				(SELECT CONCAT([Prd].[LastName],', ', [Prd].[Name]) FROM Professional AS [Prd] WHERE [D].[IdDestinationProfessional] = [Prd].[IdProfessional])  AS 'Profesional Destino',
				[d].[IdDestinationProfessional],
				(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
				[D].[IdDestinationSpeciality]
			FROM Diagnostic AS [D]
				INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
				INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[IdPatient] = @Id AND [D].[Visible] = @Visible
			--WHERE [D].[IdPatient] = 2 --AND [D].[Visible] = @Visible
			ORDER BY 'FECHA'
		END
	ELSE
		BEGIN
			SELECT [D].[idDiagnostic], [S].[Description] AS 'Especialidad',
				CONCAT([Pr].[LastName],', ', [Pr].[Name]) AS 'Profesional', 
				[D].[Detail] AS 'Detalle', [D].[Date] as 'Fecha',    
				(SELECT CONCAT([Prd].[LastName],', ', [Prd].[Name]) FROM Professional AS [Prd] WHERE [D].[IdDestinationProfessional] = [Prd].[IdProfessional])  AS 'Profesional Destino',
				[D].[IdDestinationProfessional],
				(SELECT [Sd].[Description] FROM Specialty AS [Sd] WHERE [D].[IdDestinationProfessional] = [Sd].[IdSpecialty])  AS 'Especialidad Destino',
				[d].[IdDestinationSpeciality]
			FROM Diagnostic AS [D]
				INNER JOIN Professional AS [Pr] ON [D].[IdProfessional] = [Pr].[IdProfessional]
				INNER JOIN Specialty AS [S] ON [D].[IdSpeciality] = [S].[IdSpecialty]
			WHERE [D].[idDiagnostic] = @Id AND [D].[Visible] = @Visible
			ORDER BY 'FECHA'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spRpListPatient-v1.2]    Script Date: 15/04/2018 12:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/08 21:30>
-- Description:	<ReportListPatient>
-- =============================================
CREATE PROCEDURE [dbo].[spRpListPatient-v1.2] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LastName VARCHAR(50) = null,
	@NumberDocument INT =0,
	@Visible INT =1
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF(@Name = '' AND @LastName = '' AND @NumberDocument = 0)     --000
	BEGIN	
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento'
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[NumberDocument] = @NumberDocument AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
	IF(@Name = '' AND @LastName = '' AND @NumberDocument != 0)    --001 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento'
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[NumberDocument] = @NumberDocument AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
	IF(@Name = '' AND @LastName != '' AND @NumberDocument = 0)    --010
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento'
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[NumberDocument] = @NumberDocument AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
	IF(@Name = '' AND @LastName != '' AND @NumberDocument != 0)	 --011 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento'
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[NumberDocument] = @NumberDocument AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
	IF(@Name != '' AND @LastName = '' AND @NumberDocument = 0)	 --100 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento'
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[NumberDocument] = @NumberDocument AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
	IF(@Name != '' AND @LastName = '' AND @NumberDocument != 0)	 --101 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento'
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[NumberDocument] = @NumberDocument AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
	IF(@Name != '' AND @LastName != '' AND @NumberDocument = 0)   --110 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento'
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[NumberDocument] = @NumberDocument AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
	IF(@Name != '' AND @LastName != '' AND @NumberDocument != 0)   --111
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento'
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[NumberDocument] = @NumberDocument AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spRpListProfessional-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report spRpListProfessional-v1.0>
-- =============================================
CREATE PROCEDURE [dbo].[spRpListProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LAStName VARCHAR(50) = null,
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF(@Name = '' AND @LastName = '')                                                            --00
	BEGIN
		SELECT	CONCAT([LastName],', ', [Name]) AS 'Nombre', 
				[ProfessionalRegistration] AS 'N. Matricula',
				[Phone] AS 'Telefono', [Mail] AS 'Correo'
		FROM [dbo].[Professional]
		WHERE 
		--[Name] LIKE +'%'+ @Name +'%' AND
		--[LastName] LIKE +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		ORDER BY [Name]
	END
	IF(@Name = '' AND @LastName != '')															--01                                                
	BEGIN
		SELECT	CONCAT([LastName],', ', [Name]) AS 'Nombre', 
				[ProfessionalRegistration] AS 'N. Matricula',
				[Phone] AS 'Telefono', [Mail] AS 'Correo'
		FROM [dbo].[Professional]
		WHERE 
		--[Name] LIKE +'%'+ @Name +'%' AND
		[LastName] LIKE +'%'+ @LastName +'%'  AND
		[Visible] = @Visible
		ORDER BY [Name]
	END 
	IF(@Name != '' AND @LastName = '')															--10                                                
	BEGIN
		SELECT	CONCAT([LastName],', ', [Name]) AS 'Nombre', 
				[ProfessionalRegistration] AS 'N. Matricula',
				[Phone] AS 'Phone', [Mail] AS 'Correo'
		FROM [dbo].[Professional]
		WHERE 
		[Name] LIKE +'%'+ @Name +'%' AND
		--[LastName] LIKE +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		ORDER BY [Name]
	END
	IF(@Name != '' and @LastName != '')															--11                                                
	BEGIN
		SELECT	CONCAT([LastName],', ', [Name]) AS 'Nombre', 
				[ProfessionalRegistration] AS 'N. Matricula',
				[Phone] AS 'Telefono', [Mail] AS 'Correo'
		FROM [dbo].[Professional]
		WHERE 
		[Name] LIKE +'%'+ @Name +'%' AND
		[LastName] LIKE +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		ORDER BY [Name]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyPatient-v1.1]    Script Date: 15/04/2018 13:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/08 21:18>
-- Description:	<Report RpOnlyPatient>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyPatient-v1.1] 
	-- Add the parameters for the stored procedure here
	@IdPatient INT = 0
	AS
	BEGIN
		SELECT [P].[IdPatient] AS 'Id',
		       CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			   [Birthdate] AS 'Fecha Nacimiento',
			   CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [dbo].[StringSex]([Sex]) AS 'Sexo',
			   CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locacion',
			   [P].[Address] AS 'Direccion',
			   [P].[Phone] AS 'Telefono'
		FROM [dbo].[Patient] AS [P]
		INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
		INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
		INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		WHERE [P].[IdPatient] = @IdPatient
	END
GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessionalSpeciality-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessional-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report spRpOnlyProfessional>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdProfessional INT = 0,
	@Visible INT = 1
	AS
	BEGIN				
		SELECT	[P].[IdProfessional] AS 'Id',
				CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
				[ProfessionalRegistration] AS 'Registro Profesional', 
				CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locacion',
				[P].[Address] AS 'Direccion',
				[P].[Phone] AS 'Telefono',
				[P].[Mail] AS 'Correo'
		FROM Professional AS [P]
		INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
		INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
		INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
		WHERE [P].[IdProfessional] = @IdProfessional AND [P].[Visible] = @Visible
	END
GO
/****** Object:  StoredProcedure [dbo].[spRpPatientParent-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- DescriptiON:	<Report RpPatientParent>
-- =============================================
CREATE PROCEDURE [dbo].[spRpPatientParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdPatient INT = 0,
	@Visible INT = 1
	AS
BEGIN
	SELECT	CONCAT([Pa].[LastName],', ',[Pa].[Name]) AS 'Nombre',
			[R].[Description] AS 'Relacion',
			CONCAT([Td].[Description],'-',[Pa].[NumberDocument]) AS 'Documento',
			CONCAT('(',[lCu].[Description],', ',[lPv].[Description],') ',[lCy].[Description]) AS 'Locacion',
			[Pa].[Address] AS 'Direccion', [Pa].[Phone] AS 'Telefono', 
			[Pa].[AlternativePhone] AS 'Telefono Alt.', [Pa].[Email] AS 'Correo' 
		FROM  PatientParent AS [Pp] 
		INNER JOIN Patient AS [P] ON [Pp].[IdPatient] = [P].[IdPatient]
		INNER JOIN Parent AS [Pa] ON [Pp].[IdParent] = [Pa].[IdParent]
		INNER JOIN LocationCountry AS [lCu] ON [Pa].[idLocationCountry] = [lCu].[idLocationCountry]
		INNER JOIN LocationProvince AS [lPv] ON [Pa].[idLocationProvince] = [lPv].[idLocationProvince]
		INNER JOIN LocationCity AS [lCy] ON [Pa].[idLocationCity] = [lCy].[idLocationCity]
		INNER JOIN Relationship AS [R] ON [Pp].[IdRelationship] = [R].[IdRelationship]
		INNER JOIN TypeDocument AS [Td] ON [Pa].[IdTypeDocument] = [Td].[IdTypeDocument]
 		WHERE [P].[IdPatient] = @IdPatient AND [Pp].[Visible] = @Visible		
END
GO
/****** Object:  StoredProcedure [dbo].[spSession-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 16:37>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
create PROCEDURE [dbo].[spSession-v1.0] 
	-- Add the parameters for the stored procedure here
	@Status int = 1,  --> Session: 1 Abrir - 2 IdProfecional - 3 Cerrar
	@User varchar(50) = null,
	@Password varchar(50) = null,
	@IdSession int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	BEGIN
	IF @Status = 1
		BEGIN
			DECLARE @Id INT

			SET @Id = (SELECT [IdProfessional] FROM [dbo].[Professional]
			WHERE [User] like @User 
			AND [Password] like @Password
			AND [Visible] = @Visible)
			IF @Id != 0
			BEGIN
				BEGIN TRANSACTION
				BEGIN TRY
					INSERT INTO [dbo].[Session] (IdProfessional, InitDate, EndDate) VALUES (@Id, GETDATE(), DATEADD(ss, 2, GETDATE()))
				COMMIT TRANSACTION
				RETURN @@identity
				END TRY
				BEGIN CATCH
				ROLLBACK TRANSACTION
					PRINT '[INSERT]. Se ha producido un error!'
					RETURN 0
				END CATCH
			END
			ELSE
			BEGIN
				RETURN 0
			END
		END
		ELSE IF @Status = 2
		BEGIN
			RETURN (SELECT idProfessional FROM [dbo].[Session] WHERE idSession = @IdSession)
		END
		ELSE IF @Status = 3
		BEGIN
			BEGIN TRANSACTION
			BEGIN TRY
				UPDATE [dbo].[Session] 
				SET EndDate = GETDATE() 
				WHERE idSession = @IdSession
				COMMIT TRANSACTION
				RETURN @IdSession
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				PRINT '[UPDATE]. Se ha producido un error!'
				RETURN 0
			END CATCH
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spSpecialityProfessional-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/31 19:22>
-- Description:	<Report [spSpecialityProfessional-v1.0]>
-- =============================================
CREATE PROCEDURE [dbo].[spSpecialityProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdSpeciality int = 0,
	@Visible int = 1
	AS
	BEGIN
		IF(@IdSpeciality!=0)
		BEGIN
			SELECT [P].[IdProfessional] AS 'Id', CONCAT([P].[LastName] ,', ',[P].[Name]) AS 'Value'  
			FROM Professional [P] INNER JOIN  ProfessionalSpeciality [Ps] ON [P].IdProfessional=[Ps].IdProfessional
						  INNER JOIN  Specialty [S] ON [Ps].IdSpeciality=[S].IdSpecialty
			WHERE IdSpeciality=@IdSpeciality  AND [Ps].Visible=@Visible
			ORDER BY(2)
		END
		ELSE
		BEGIN
			SELECT [P].[IdProfessional] AS 'Id', CONCAT([P].[LastName] ,', ',[P].[Name]) AS 'Value' 
			FROM Professional [P]
			WHERE [P].Visible=@Visible
			ORDER BY(2)
		END
	END
GO