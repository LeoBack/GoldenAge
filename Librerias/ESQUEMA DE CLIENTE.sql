use master
create database [GOLDENAGE-01.MDF]
go

USE [GOLDENAGE-01.MDF]
GO
/****** Object:  StoredProcedure [dbo].[GetCountPaginasSocialWorks]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetCountPaginasSocialWorks]
AS
   SET NOCOUNT ON;

   SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

   DECLARE @CUANTOS INT;

   SELECT @CUANTOS=COUNT(*)
   FROM dbo.SocialWork 

   RETURN @CUANTOS;



GO
/****** Object:  StoredProcedure [dbo].[GetPaginasRowNumberSocialWorks]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- *********************************************
-- ***  Crear Procedimientos Almacenados     ***
-- *********************************************
CREATE PROCEDURE [dbo].[GetPaginasRowNumberSocialWorks]
   @NUM_PAGINA   INT
   ,@TAM_PAGINA   INT
AS
   SET NOCOUNT ON;

   SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

   WITH DRV_TBL AS 
   (
      SELECT 
         ROW_NUMBER() OVER (ORDER BY PAG.Name DESC) AS rownum
         ,PAG.*
      FROM dbo.SocialWork AS PAG
   )

   SELECT * FROM DRV_TBL 
   WHERE ROWNUM BETWEEN (@NUM_PAGINA*@TAM_PAGINA)-@TAM_PAGINA+1 AND (@NUM_PAGINA*@TAM_PAGINA)



GO
/****** Object:  StoredProcedure [dbo].[GetPaginasSinPaginarSocialWork]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPaginasSinPaginarSocialWork]
AS
   SET NOCOUNT ON;

   SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

   SELECT PAG.*
   FROM dbo.SocialWork AS PAG



GO
/****** Object:  StoredProcedure [dbo].[GetPaginasTOPmayorQueSocialWork]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPaginasTOPmayorQueSocialWork]
   @MAYOR_QUE        int 
   ,@TAM_PAGINA   INT
AS
   SET NOCOUNT ON;

   SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

   SELECT *
   FROM 
   (
	   SELECT TOP (@TAM_PAGINA) * 
	   FROM dbo.SocialWork AS PAG
	   WHERE (IdSocialWork>@MAYOR_QUE OR @MAYOR_QUE IS NULL)
	   ORDER BY nAME
   ) AS DRV_TBL
   ORDER BY nAME DESC



GO
/****** Object:  StoredProcedure [dbo].[GetPaginasTOPmenorQueSocialWork]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPaginasTOPmenorQueSocialWork]
   @MENOR_QUE         INT
   ,@TAM_PAGINA   INT
AS
   SET NOCOUNT ON;

   SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

   SELECT TOP (@TAM_PAGINA) * 
   FROM dbo.SocialWork AS PAG
   WHERE (IdSocialWork<@MENOR_QUE OR @MENOR_QUE IS NULL)
   ORDER BY NAME DESC



GO
/****** Object:  StoredProcedure [dbo].[spAbmDiagnostic-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmIvaType-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLocationCity-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLocationCountry-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLocationProvince-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmParent-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 10:05>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdParent int = 0,
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@IdTypeDocument int = 0,
	@NumberDocument int = 0,
	@Phone varchar(50) = null,
    @AlternativePhone varchar(50) = null,
	@Email varchar(50) = null,
	@IdLocationCountry int = 0,
    @IdLocationProvince int = 0,
    @IdLocationCity int = 0,
	@Address varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
		FROM [dbo].[Parent]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Parent]) --WHERE [Visible] = @Visible)
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
/****** Object:  StoredProcedure [dbo].[spAbmPatientParent-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmPatient-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 22:45>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPatient-v1.0] 
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
    @IdSocialWork int = 0,
	@AffiliateNumber bigint = 0,
	@DateAdmission datetime ,
	@EgressDate datetime ,
	@ReasonExit varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[IdSocialWork],[AffiliateNumber],[DateAdmission],[EgressDate],[ReasonExit],[Visible]
		FROM [dbo].[Patient]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Patient]) --WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[IdSocialWork],[AffiliateNumber],[DateAdmission],[EgressDate],[ReasonExit],[Visible]
		FROM [dbo].[Patient]
		WHERE [IdPatient] = @IdPatient --AND 
		--[Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Patient] WHERE [IdPatient] = @IdPatient)-- AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Patient ([Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[IdSocialWork],[AffiliateNumber],[DateAdmission],[EgressDate],[ReasonExit],[Visible])
			VALUES (@Name,@LastName,@Birthdate,@IdTypeDocument,@NumberDocument,@Sex,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Phone,@IdSocialWork,@AffiliateNumber,@DateAdmission,@EgressDate,@ReasonExit,@Visible)
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
			[IdSocialWork] = @IdSocialWork,
			[AffiliateNumber] = @AffiliateNumber,
			[DateAdmission] = @DateAdmission,
			[EgressDate] = @EgressDate,
			[ReasonExit] = @ReasonExit,
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
/****** Object:  StoredProcedure [dbo].[spAbmPermission-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmProfessionalSpeciality-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmProfessional-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
	@ProfessionalRegistration int = 0,
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
/****** Object:  StoredProcedure [dbo].[spAbmRelationship-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmSocialWork-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
		SELECT [idSocialWork] AS 'Id', [Description] AS 'Value' 
		FROM [dbo].[SocialWork]
		WHERE 
		--[Address] = @Address 
		--AND [Name] = @Name
		[Visible] = @Visible
		ORDER BY [Description] ASC
	END
END

GO
/****** Object:  StoredProcedure [dbo].[spAbmSpecialty-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmTypeDocument-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmTypeParent-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spListPatient-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 18:07>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spListPatient-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@AffiliateNumber bigint = 0,
	@IdSocialWork int =0,
	@Desde int=0,
	@Hasta int=0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	if(@Name='' and @LastName='' and @AffiliateNumber=0 and @IdSocialWork=0)     --0000
	BEGIN
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible

		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	if(@Name='' and @LastName='' and @AffiliateNumber=0 and @IdSocialWork!=0)    --0001 
	BEGIN 
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		[P].[IdTypeDocument]=[Ty].[IdTypeDocument]  
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	if(@Name='' and @LastName='' and @AffiliateNumber!=0 and @IdSocialWork=0)    --0010 
	BEGIN 
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	if(@Name='' and @LastName='' and @AffiliateNumber!=0 and @IdSocialWork!=0)	 --0011 
	BEGIN 
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	if(@Name='' and @LastName!='' and @AffiliateNumber=0 and @IdSocialWork=0)	 --0100 
	BEGIN 
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	if(@Name!='' and @LastName='' and @AffiliateNumber=0 and @IdSocialWork=0)	 --1000 
	BEGIN 
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END

	if(@Name='' and @LastName!='' and @AffiliateNumber=0 and @IdSocialWork!=0)   --0101 
	BEGIN 
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND
		[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	if(@Name='' and @LastName!='' and @AffiliateNumber!=0 and @IdSocialWork=0)   --0110
	BEGIN 
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	if(@Name='' and @LastName!='' and @AffiliateNumber!=0 and @IdSocialWork!=0)  --0111
	BEGIN
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	if(@Name!='' and @LastName!='' and @AffiliateNumber!=0 and @IdSocialWork!=0)  --0111
	BEGIN
		SELECT [P].[IdPatient], [P].[Name] AS 'Nombre', [P].[LastName] AS'Apellido', [P].[Birthdate] AS'Cumpleaños',
		       [Ty].[Description] as 'Tipo Documento',[So].[Name] as'Obra Social',
	           [P].[AffiliateNumber] as'Numero de Afiliado', [P].[DateAdmission] as'F. de Ingreso',[P].[EgressDate] as'Fecha de Alta' ,[P].[ReasonExit] as'Motivo de Egreso',[P].[Visible] 
		FROM [dbo].[Patient] [P],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		--[P].[Visible] = @Visible
		--And
		 [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [P].[IdSocialWork]=[So].[IdSocialWork]
		Order by [P].[LastName]
	END
	
END

GO
/****** Object:  StoredProcedure [dbo].[spListProfessional-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 17:36>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spListProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@Desde int=1,
	@Hasta int=1,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	 
	if(@Name='' and @LastName='')                                                            --00
	BEGIN
		SELECT [IdProfessional],[Name] as'Nombre',[LastName] as'Apellido',[Phone] as'Telefono',[Visible]
		FROM [dbo].[Professional]
		--WHERE 
		--[Name] like +'%'+ @Name +'%' AND
		--[LastName] like +'%'+ @LastName +'%' AND 
		--[Visible] = @Visible
		Order by [Name]
	END
	
	if(@Name='' and @LastName!='')															--01                                                
	BEGIN
		SELECT [IdProfessional],[Name] as'Nombre',[LastName] as'Apellido',[Phone] as'Telefono',[Visible]
		FROM [dbo].[Professional]
		WHERE 
		--[Name] like +'%'+ @Name +'%' AND
		[LastName] like +'%'+ @LastName +'%'  
		--[Visible] = @Visible
		Order by [Name]
	END 


	if(@Name!='' and @LastName='')															--10                                                
	BEGIN
		SELECT [IdProfessional],[Name] as'Nombre',[LastName] as'Apellido',[Phone] as'Telefono',[Visible]
		FROM [dbo].[Professional]
		WHERE 
		[Name] like +'%'+ @Name +'%' 
		--[LastName] like +'%'+ @LastName +'%' AND 
		--[Visible] = @Visible
		Order by [Name]
	END
	
	if(@Name!='' and @LastName!='')															--11                                                
	BEGIN
		SELECT [IdProfessional],[Name] as'Nombre',[LastName] as'Apellido',[Phone] as'Telefono',[Visible]
		FROM [dbo].[Professional]
		WHERE 
		[Name] like +'%'+ @Name +'%' AND
		[LastName] like +'%'+ @LastName +'%' --AND 
		--[Visible] = @Visible
		Order by [Name]
	END 
	 
	
END

GO
/****** Object:  StoredProcedure [dbo].[spListSocialWorks-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 17:36>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spListSocialWorks-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@Desde int=1,
	@Hasta int=1,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	if(@Name!='')
	BEGIN
		SELECT [IdSocialWork], [Name]AS 'RAZON SOCIAL',[Address] AS'DIRECCION',[Phone] AS 'TELEFONO',[Contact] AS 'CONTACTO',[Visible]
		FROM [dbo].[SocialWork]
		WHERE 
		[Name] like +'%'+ @Name +'%'--AND 
		--[Visible] = @Visible
		Order by [Name]
	END

	if(@Name='')
	BEGIN
		SELECT [IdSocialWork], [Name]AS 'RAZON SOCIAL',[Address] AS'DIRECCION',[Phone] AS 'TELEFONO',[Contact] AS 'CONTACTO',[Visible]
		FROM [dbo].[SocialWork]
		--WHERE 
		--[Name] like +'%'+ @Name +'%'AND 
		--[Visible] = @Visible
		Order by [Name]
	END
END

GO
/****** Object:  StoredProcedure [dbo].[spLoguin-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
				INSERT INTO [dbo].[Login] (IdProfessional, InitDate, EndDate) VALUES (@Id, GETDATE(), DATEADD(ss, 2, GETDATE()))
			END

			SELECT @Id
		END
		--ELSE
		--BEGIN
		--	UPDATE [dbo].[Login] SET EndDate = GETDATE() WHERE idProfessional 
		--END
	END
END


GO
/****** Object:  StoredProcedure [dbo].[spRpClinicHistory-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 21:54>
-- Description:	<Report [spRpClinicHistory-v1.0]>
-- =============================================
CREATE PROCEDURE [dbo].[spRpClinicHistory-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdPatient int = 0,
	@Visible int = 1
	AS
	BEGIN
		select D.Detail as 'Detail', D.[Date] as 'Date',  Concat(Pr.[Name],' ',Pr.[LastName])as'Name',S.[Description] as'Specialty'   
		from Diagnostic as D inner join Patient  as Pa on [D].IdPatient= Pa.IdPatient
						     inner join Professional  as Pr on [D].IdProfessional= Pr.IdProfessional
							 inner join Specialty  as S on [D].IdSpeciality= S.IdSpecialty
		where D.IdPatient=@IdPatient and D.Visible=@Visible
		
	END
	


GO
/****** Object:  StoredProcedure [dbo].[spRpListPatient-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/10/28 18:15>
-- Description:	<ReportListPatient>
-- =============================================
CREATE PROCEDURE [dbo].[spRpListPatient-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@AffiliateNumber bigint = 0,
	@IdSocialWork int =0,
	@Visible int =1
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	if(@Name='' and @LastName='' and @AffiliateNumber=0 and @IdSocialWork=0)     --0000
	BEGIN
	
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		Order by [P].[Name]
	END
	if(@Name='' and @LastName='' and @AffiliateNumber=0 and @IdSocialWork!=0)    --0001 
	BEGIN 
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]

		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork 		And
		[P].[Visible] = @Visible
		
		Order by [P].[Name]
	END
	if(@Name='' and @LastName='' and @AffiliateNumber!=0 and @IdSocialWork=0)    --0010 
	BEGIN 
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber And
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		--And
		Order by [P].[Name]
	END
	if(@Name='' and @LastName='' and @AffiliateNumber!=0 and @IdSocialWork!=0)	 --0011 
	BEGIN 
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork And
		[P].[Visible] = @Visible
		--And
		 Order by [P].[Name]
	END
	if(@Name='' and @LastName!='' and @AffiliateNumber=0 and @IdSocialWork=0)	 --0100 
	BEGIN 
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' And
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		--And
		 
		Order by [P].[Name]
	END
	if(@Name!='' and @LastName='' and @AffiliateNumber=0 and @IdSocialWork=0)	 --1000 
	BEGIN 
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]
		WHERE 
		[P].[Name] like +'%'+@Name+'%' And
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		--And
		 Order by [P].[Name]
	END

	if(@Name='' and @LastName!='' and @AffiliateNumber=0 and @IdSocialWork!=0)   --0101 
	BEGIN 
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND
		[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork And
		[P].[Visible] = @Visible
		--And
		 
		Order by [P].[Name]
	END
	if(@Name='' and @LastName!='' and @AffiliateNumber!=0 and @IdSocialWork=0)   --0110
	BEGIN 
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]  
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber And
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		--And
		 
		Order by [P].[Name]
	END
	if(@Name='' and @LastName!='' and @AffiliateNumber!=0 and @IdSocialWork!=0)  --0111
	BEGIN
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork And
		[P].[Visible] = @Visible
		--And
		Order by [P].[Name]
	END
	if(@Name!='' and @LastName!='' and @AffiliateNumber!=0 and @IdSocialWork!=0)  --0111
	BEGIN
		SELECT Concat([P].[Name],' ',[P].[LastName]) as'Name',
		       Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',
			   [P].[AffiliateNumber] as'AffiliateNumber', [So].[Name] as'SocialWork',
	           [P].[DateAdmission] as'DateAdmission',[P].[EgressDate] as'EgressDate' ,[P].[ReasonExit] as'ReasonExit' 
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork And
		[P].[Visible] = @Visible
		--And
		 
		Order by [P].[Name]
	END
	
END

GO
/****** Object:  StoredProcedure [dbo].[spRpListProfessional-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/10/28 20:10>
-- Description:	<Report spRpListProfessional-v1.0>
-- =============================================
CREATE PROCEDURE [dbo].[spRpListProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	 
	if(@Name='' and @LastName='')                                                            --00
	BEGIN
		SELECT Concat([Name],' ',[LastName])as 'Name', [ProfessionalRegistration] as'ProfessionalRegistration',
		[Phone] as'Phone', [Mail] as 'Mail'
		FROM [dbo].[Professional]
		WHERE 
		--[Name] like +'%'+ @Name +'%' AND
		--[LastName] like +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		Order by [Name]
	END
	
	if(@Name='' and @LastName!='')															--01                                                
	BEGIN
		SELECT Concat([Name],' ',[LastName])as 'Name', [ProfessionalRegistration] as'ProfessionalRegistration',
		[Phone] as'Phone', [Mail] as 'Mail'
		FROM [dbo].[Professional]
		WHERE 
		--[Name] like +'%'+ @Name +'%' AND
		[LastName] like +'%'+ @LastName +'%'  and
		[Visible] = @Visible
		Order by [Name]
	END 


	if(@Name!='' and @LastName='')															--10                                                
	BEGIN
		SELECT Concat([Name],' ',[LastName])as 'Name', [ProfessionalRegistration] as'ProfessionalRegistration',
		[Phone] as'Phone', [Mail] as 'Mail'
		FROM [dbo].[Professional]
		WHERE 
		[Name] like +'%'+ @Name +'%' and
		--[LastName] like +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		Order by [Name]
	END
	
	if(@Name!='' and @LastName!='')															--11                                                
	BEGIN
		SELECT Concat([Name],' ',[LastName])as 'Name', [ProfessionalRegistration] as'ProfessionalRegistration',
		[Phone] as'Phone', [Mail] as 'Mail'
		FROM [dbo].[Professional]
		WHERE 
		[Name] like +'%'+ @Name +'%' AND
		[LastName] like +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		Order by [Name]
	END 
	 
	
END

GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyPatient-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 18:39>
-- Description:	<Report RpOnlyPatient>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyPatient-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdPatient int = 0
	AS
	BEGIN
	--Nombre	Apellido	Tipo	Dni	FechaNac	sexo	Localidad	Domicilio	Telefono	NroAfiliado	ObraSocial	Fingreso	Fegreso	Motivo
		SELECT [P].[IdPatient],
		       Concat([P].[Name],' ',[P].[LastName]) as'Name',[Birthdate] AS'Birthdate',
			   Concat([Ty].[Description],'',[P].[NumberDocument] )as 'Document',[Sex] AS'Sex',
			   Concat([P].[idLocationCountry],' ',[P].[idLocationProvince],' ',[P].[idLocationCity])AS'Location',
			   [P].[Address] AS'Address',[P].[Phone] AS'Phone',[AffiliateNumber] AS'AffiliateNumber',[So].[Name] as'SocialWork',
			   [DateAdmission]AS'DateAdmission',[EgressDate] AS'EgressDate',[ReasonExit] AS'ReasonExit'
		FROM [dbo].[Patient] [P] inner join [dbo].[TypeDocument] Ty on  [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
								 inner join	[dbo].[SocialWork] So on  [P].[IdSocialWork]=[So].[IdSocialWork]

		WHERE [P].[IdPatient] = @IdPatient		
	END
	


GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessionalSpeciality-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 20:54>
-- Description:	<Report spRpOnlyProfessionalSpeciality-v1.0>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyProfessionalSpeciality-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdProfessional int = 0,
	@Visible int = 1
	AS
	BEGIN
		select s.[Description] from Specialty S  
		inner Join ProfessionalSpeciality Ps on Ps.IdSpeciality = S.IdSpecialty
		inner Join Professional P on Ps.IdProfessional=P.IdProfessional
		WHERE 
		[P].[IdProfessional] = @IdProfessional and [S].[Visible] = @Visible		
	END
	


GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessional-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 20:51>
-- Description:	<Report spRpOnlyProfessional>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdProfessional int = 0,
	@Visible int = 1
	AS
	BEGIN
	--Nombre	Apellido	MP	Direccion	Localidad	Telefono	Mail	Profesional/Speciality	Descripcion					
		SELECT [P].[IdProfessional],
		       Concat([P].[Name],' ',[P].[LastName]) as'Name',[ProfessionalRegistration] AS'ProfessionalRegistration',
			   [P].[Address] AS'Address', Concat([P].[idLocationCountry],' ',[P].[idLocationProvince],' ',[P].[idLocationCity])AS'Location',
			   [P].[Phone] AS'Phone',[P].[Mail] AS'Mail'
		from Professional as P 
		WHERE 
		[P].[IdProfessional] = @IdProfessional and [P].[Visible] = @Visible		
	END
	


GO
/****** Object:  StoredProcedure [dbo].[spRpPatientParent-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/28 19:52>
-- Description:	<Report RpPatientParent>
-- =============================================
create PROCEDURE [dbo].[spRpPatientParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdPatient int = 0,
	@Visible int=1
	AS
BEGIN
	SELECT Concat(Pa.Name,' ',Pa.LastName) as'Name', 
	R.[Description] as'Relationship',
	Concat(Td.[Description],'-',Pa.NumberDocument) as'NumberDocument',
    Concat([Pa].[idLocationCountry],' ',[Pa].[idLocationProvince],' ',[Pa].[idLocationCity])AS'Location', 
	[Pa].[Address] as'Address', [Pa].Phone as'Phone', [Pa].AlternativePhone as'AlternativePhone',[Pa].Email as'Email' 

		FROM  PatientParent as Pp 
		inner join Patient as P on Pp.IdPatient=P.IdPatient
		inner join Parent Pa on Pp.IdParent=Pa.IdParent
		inner join Relationship R on Pp.IdRelationship = R.IdRelationship 
		inner join TypeDocument as Td on Pa.IdTypeDocument=Td.IdTypeDocument

 		WHERE [P].[IdPatient] = @IdPatient and [Pp].Visible=@Visible		
END
	


GO
/****** Object:  StoredProcedure [dbo].[spSession-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spSpecialityProfessional-v1.0]    Script Date: 07/11/2017 09:20:39 p.m. ******/
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
		if(@IdSpeciality!=0)
		Begin
			SELECT [P].[IdProfessional] AS 'Id', CONCAT([P].[LastName] ,', ',[P].[Name]) AS 'Value'  
			FROM Professional [P] INNER JOIN  ProfessionalSpeciality [Ps] on [P].IdProfessional=[Ps].IdProfessional
						  INNER JOIN  Specialty [S] on [Ps].IdSpeciality=[S].IdSpecialty
			WHERE IdSpeciality=@IdSpeciality  and [Ps].Visible=@Visible
			order by(2)
		end
		else
		begin
			SELECT [P].[IdProfessional] AS 'Id', CONCAT([P].[LastName] ,', ',[P].[Name]) AS 'Value' 
			FROM Professional [P]
			WHERE [P].Visible=@Visible
			order by(2)
		end
	END
	


GO
/****** Object:  Table [dbo].[Diagnostic]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diagnostic](
	[idDiagnostic] [int] IDENTITY(1,1) NOT NULL,
	[IdPatient] [int] NOT NULL,
	[IdSpeciality] [int] NOT NULL,
	[IdProfessional] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Detail] [text] NOT NULL,
	[IdDestinationSpeciality] [int] NOT NULL,
	[IdDestinationProfessional] [int] NOT NULL,
	[DestinationRead] [int] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDiagnostic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IvaType]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IvaType](
	[IdIvaType] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIvaType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationCity]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationCity](
	[idLocationCity] [int] IDENTITY(1,1) NOT NULL,
	[idLocationProvince] [int] NOT NULL,
	[idLocationCountry] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLocationCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationCountry]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationCountry](
	[idLocationCountry] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLocationCountry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationProvince]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationProvince](
	[idLocationProvince] [int] IDENTITY(1,1) NOT NULL,
	[idLocationCountry] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLocationProvince] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parent](
	[IdParent] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[IdTypeDocument] [int] NOT NULL,
	[NumberDocument] [varchar](20) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[AlternativePhone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[idLocationCountry] [int] NOT NULL,
	[idLocationProvince] [int] NOT NULL,
	[idLocationCity] [int] NOT NULL,
	[Address] [varchar](50) NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdParent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patient](
	[IdPatient] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Birthdate] [date] NULL,
	[IdTypeDocument] [int] NULL,
	[NumberDocument] [int] NULL,
	[Sex] [int] NOT NULL,
	[idLocationCountry] [int] NOT NULL,
	[idLocationProvince] [int] NOT NULL,
	[idLocationCity] [int] NOT NULL,
	[Address] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[IdSocialWork] [int] NOT NULL,
	[AffiliateNumber] [bigint] NOT NULL,
	[DateAdmission] [date] NOT NULL,
	[EgressDate] [date] NULL,
	[ReasonExit] [varchar](300) NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPatient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientParent]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientParent](
	[IdPatientParent] [int] IDENTITY(1,1) NOT NULL,
	[IdPatient] [int] NOT NULL,
	[IdParent] [int] NOT NULL,
	[IdRelationship] [int] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPatientParent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permission]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permission](
	[IdPermission] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Professional]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Professional](
	[IdProfessional] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[ProfessionalRegistration] [int] NULL,
	[idLocationCountry] [int] NOT NULL,
	[idLocationProvince] [int] NOT NULL,
	[idLocationCity] [int] NOT NULL,
	[Address] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Mail] [varchar](50) NULL,
	[User] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[idPermission] [int] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProfessional] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProfessionalSpeciality]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessionalSpeciality](
	[IdProfessionalSpeciality] [int] IDENTITY(1,1) NOT NULL,
	[IdProfessional] [int] NOT NULL,
	[IdSpeciality] [int] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProfessionalSpeciality] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Relationship]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Relationship](
	[IdRelationship] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRelationship] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Session]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[idSession] [int] IDENTITY(1,1) NOT NULL,
	[idProfessional] [int] NOT NULL,
	[InitDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[idSession] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SocialWork]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SocialWork](
	[IdSocialWork] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[IdIvaType] [int] NULL,
	[idLocationCountry] [int] NULL,
	[idLocationProvince] [int] NULL,
	[idLocationCity] [int] NULL,
	[Address] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[Contact] [varchar](50) NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSocialWork] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Specialty]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Specialty](
	[IdSpecialty] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSpecialty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeDocument]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeDocument](
	[IdTypeDocument] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTypeDocument] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeParent]    Script Date: 07/11/2017 09:20:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeParent](
	[IdTypeParent] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Visible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTypeParent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Diagnostic] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[IvaType] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[LocationCity] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[LocationCountry] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[LocationProvince] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Parent] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Patient] ADD  DEFAULT ((0)) FOR [Sex]
GO
ALTER TABLE [dbo].[Patient] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[PatientParent] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Permission] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Professional] ADD  CONSTRAINT [DF_Professional_idPermission]  DEFAULT ((0)) FOR [idPermission]
GO
ALTER TABLE [dbo].[Professional] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[ProfessionalSpeciality] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Relationship] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[SocialWork] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Specialty] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[TypeDocument] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[TypeParent] ADD  DEFAULT ((1)) FOR [Visible]
GO
