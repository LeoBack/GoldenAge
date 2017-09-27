USE [master]
GO
/****** Object:  Database [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]    Script Date: 26/09/2017 07:42:00 p.m. ******/
CREATE DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Default', FILENAME = N'D:\Program Files\Nueva carpeta\MSSQL13.MSSQLSERVER\MSSQL\DATA\Default.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Default_log', FILENAME = N'D:\Program Files\Nueva carpeta\MSSQL13.MSSQLSERVER\MSSQL\DATA\Default_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET ARITHABORT OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET  DISABLE_BROKER 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET  MULTI_USER 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[GetCountPaginasSocialWorks]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[GetPaginasRowNumberSocialWorks]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[GetPaginasSinPaginarSocialWork]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[GetPaginasTOPmayorQueSocialWork]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[GetPaginasTOPmenorQueSocialWork]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmDiagnostic-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
	@Detail date,
	@DiagnosticDate int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDiagnostic],[IdSpeciality],[Detail],[DiagnosticDate],[Visible]
		FROM [dbo].[Diagnostic]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Diagnostic] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDiagnostic],[IdSpeciality],[Detail],[DiagnosticDate],[Visible]
		FROM [dbo].[Diagnostic]
		WHERE [idDiagnostic] = @idDiagnostic AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Diagnostic] WHERE [idDiagnostic] = @idDiagnostic AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Diagnostic ([IdSpeciality],[Detail],[DiagnosticDate],[Visible])
			VALUES (@IdSpeciality,@Detail,@DiagnosticDate,@Visible)
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
			[Detail] = @Detail,
			[DiagnosticDate] = @DiagnosticDate,
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
		SELECT [idDiagnostic] AS 'Id', [Detail] AS 'Value' 
		FROM [dbo].[Diagnostic]
		WHERE [DiagnosticDate] = @DiagnosticDate 
		AND [IdSpeciality] = @IdSpeciality
		AND [Visible] = @Visible
		ORDER BY [Detail] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmGrandfather-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 22:45>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmGrandfather-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdGrandfather int = 0,
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
	@AffiliateNumber int = 0,
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
		SELECT [IdGrandfather],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[IdSocialWork],[AffiliateNumber],[DateAdmission],[EgressDate],[ReasonExit],[Visible]
		FROM [dbo].[Grandfather]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Grandfather] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdGrandfather],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[IdSocialWork],[AffiliateNumber],[DateAdmission],[EgressDate],[ReasonExit],[Visible]
		FROM [dbo].[Grandfather]
		WHERE [IdGrandfather] = @IdGrandfather AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Grandfather] WHERE [IdGrandfather] = @IdGrandfather AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Grandfather ([Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[IdSocialWork],[AffiliateNumber],[DateAdmission],[EgressDate],[ReasonExit],[Visible])
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
			UPDATE [dbo].[Grandfather] 
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
			WHERE [IdGrandfather] = @IdGrandfather
			COMMIT TRANSACTION
			RETURN @IdGrandfather
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
			DELETE FROM [dbo].[Grandfather] WHERE [IdGrandfather] = @IdGrandfather
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
		SELECT [IdGrandfather] AS 'Id', [Name] AS 'Value' 
		FROM [dbo].[Grandfather]
		WHERE [Address] = @Address 
		AND [Name] = @Name
		AND [Visible] = @Visible
		ORDER BY [Name] ASC
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmLocationCity-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLocationCountry-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLocationProvince-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLoguin-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 16:37>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLoguin-v1.0] 
	-- Add the parameters for the stored procedure here
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
		SELECT [IdProfessional] 
		FROM [dbo].[Professional]
		WHERE [User] like @User 
		AND [Password] like @Password
		AND [Visible] = @Visible
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAbmParent-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
	@IdRelationship int = 0,
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
		SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[IdRelationship],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
		FROM [dbo].[Parent]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Parent] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[IdRelationship],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
		FROM [dbo].[Parent]
		WHERE [IdParent] = @IdParent AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Parent] WHERE [IdParent] = @IdParent AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Parent ([Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[IdRelationship],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible])
			VALUES (@Name,@LastName,@IdTypeDocument,@NumberDocument,@Phone,@AlternativePhone,@Email,@IdRelationship,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Visible)
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
			[IdRelationship] = @IdRelationship,
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
/****** Object:  StoredProcedure [dbo].[spAbmPatientParent-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andres>
-- Create date: <2017/09/10 00:30>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
create PROCEDURE [dbo].[spAbmPatientParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idPatientParent int = 0,
	@idPatient int = 0,
	@idParent int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idPatientParent],[idPatient],[idParent],[Visible]
		FROM [dbo].[PatientParent]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientParent] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idPatientParent],[idPatient],[idParent],[Visible]
		FROM [dbo].[PatientParent]
		WHERE [idPatientParent] = @idPatientParent AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[PatientParent] WHERE [idPatientParent] = @idPatientParent AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO PatientParent ([idPatient],[idParent],[Visible])
			VALUES (@idPatient,@idParent,@Visible)
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
/****** Object:  StoredProcedure [dbo].[spAbmPatient-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
	@AffiliateNumber int = 0,
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
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Patient] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[IdSocialWork],[AffiliateNumber],[DateAdmission],[EgressDate],[ReasonExit],[Visible]
		FROM [dbo].[Patient]
		WHERE [IdPatient] = @IdPatient AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Patient] WHERE [IdPatient] = @IdPatient AND [Visible] = @Visible)
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
/****** Object:  StoredProcedure [dbo].[spAbmProfessionalSpeciality-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[ProfessionalSpeciality] WHERE [Visible] = @Visible)
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
/****** Object:  StoredProcedure [dbo].[spAbmProfessional-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 22:45>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
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
	@Admin int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[Admin],[Visible]
		FROM [dbo].[Professional]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Professional] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[Admin],[Visible]
		FROM [dbo].[Professional]
		WHERE [IdProfessional] = @IdProfessional AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Professional] WHERE [IdProfessional] = @IdProfessional AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Professional ([Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[Admin],[Visible])
			VALUES (@Name,@LastName,@ProfessionalRegistration,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Phone,@Mail,@User,@Password,@Admin,@Visible)
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
			[Admin]=@Admin,
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
/****** Object:  StoredProcedure [dbo].[spAbmRelationship-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Relationship] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idRelationship],[Description],[Visible]
		FROM [dbo].[Relationship]
		WHERE [idRelationship] = @idRelationship AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Relationship] WHERE [idRelationship] = @idRelationship AND [Visible] = @Visible )
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
/****** Object:  StoredProcedure [dbo].[spAbmSocialWork-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
	@Address varchar(50) = null,
	@Phone varchar(50) = null,
    @Contact varchar(50) = null,
    @IdLocationCountry int = 0,
    @IdLocationProvince int = 0,
    @IdLocationCity int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idSocialWork],[Name],[Description],[Address],[Phone],[Contact],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Visible]
		FROM [dbo].[SocialWork]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[SocialWork] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idSocialWork],[Name],[Description],[Address],[Phone],[Contact],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Visible]
		FROM [dbo].[SocialWork]
		WHERE [idSocialWork] = @idSocialWork AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[SocialWork] WHERE [idSocialWork] = @idSocialWork AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO SocialWork ([Name],[Description],[Address],[Phone],[Contact],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Visible])
			VALUES (@Name,@Description,@Address,@Phone,@Contact,@IdLocationCountry,@IdLocationProvince,@IdLocationCity,@Visible)
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
			[Address] = @Address,
			[Phone] = @Phone,
			[Contact] = @Contact,
			[IdLocationCountry] = @IdLocationCountry,
			[IdLocationProvince] = @IdLocationProvince,
			[IdLocationCity] = @IdLocationCity,
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
/****** Object:  StoredProcedure [dbo].[spAbmSpecialty-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmTypeDocument-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spListPatient-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
	@AffiliateNumber int = 0,
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
/****** Object:  StoredProcedure [dbo].[spListProfessional-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spListSocialWorks-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
		SELECT [IdSocialWork], [Name]AS 'RAZON SOCIAL',[Address] AS'DIRECCION',[Phone] AS 'TELEFONO',[Contact] AS 'Contacto',[Visible]
		FROM [dbo].[SocialWork]
		WHERE 
		[Name] like +'%'+ @Name +'%'--AND 
		--[Visible] = @Visible
		Order by [Name]
	END

	if(@Name='')
	BEGIN
		SELECT [IdSocialWork], [Name]AS 'RAZON SOCIAL',[Address] AS'DIRECCION',[Phone] AS 'TELEFONO',[Contact] AS 'Contacto',[Visible]
		FROM [dbo].[SocialWork]
		--WHERE 
		--[Name] like +'%'+ @Name +'%'AND 
		--[Visible] = @Visible
		Order by [Name]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spLoguin-v1.0]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
		SELECT [IdProfessional] 
		FROM [dbo].[Professional]
		WHERE [User] like @User 
		AND [Password] like @Password
		AND [Visible] = @Visible
	END
END
GO
/****** Object:  Table [dbo].[Diagnostic]    Script Date: 26/09/2017 07:42:00 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Diagnostic](
	[idDiagnostic] [int] IDENTITY(1,1) NOT NULL,
	[IdSpeciality] [int] NOT NULL,
	[DiagnosticDate] [datetime] NULL,
	[Detail] [varchar](300) NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDiagnostic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationCity]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  Table [dbo].[LocationCountry]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  Table [dbo].[LocationProvince]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  Table [dbo].[Parent]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
	[IdRelationship] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Patient]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
	[Address] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[IdSocialWork] [int] NOT NULL,
	[AffiliateNumber] [int] NOT NULL,
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
/****** Object:  Table [dbo].[PatientParent]    Script Date: 26/09/2017 07:42:00 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientParent](
	[IdPatientParent] [int] IDENTITY(1,1) NOT NULL,
	[IdPatient] [int] NOT NULL,
	[IdParent] [int] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPatientParent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professional]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
	[Mail] [varchar](20) NULL,
	[User] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[Admin] [int] NOT NULL,
	[Visible] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProfessional] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProfessionalSpeciality]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  Table [dbo].[Relationship]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  Table [dbo].[SocialWork]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  Table [dbo].[Specialty]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
/****** Object:  Table [dbo].[TypeDocument]    Script Date: 26/09/2017 07:42:00 p.m. ******/
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
SET IDENTITY_INSERT [dbo].[LocationCity] ON 

GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (1, 1, 1, N'La Plata', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (2, 2, 1, N'San Fernando del Valle de Catamarca', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (3, 3, 1, N'Resistencia', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (4, 4, 1, N'Rawson', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (5, 5, 1, N'Córdoba', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (6, 6, 1, N'Corrientes', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (7, 7, 1, N'Paraná', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (8, 8, 1, N'Formosa', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (9, 9, 1, N'San Salvador de Jujuy', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (10, 10, 1, N'Santa Rosa', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (11, 11, 1, N'La Rioja', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (12, 12, 1, N'Mendoza', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (13, 13, 1, N'Posadas', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (14, 14, 1, N'Neuquén', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (15, 15, 1, N'Viedma', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (16, 16, 1, N'Salta', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (17, 17, 1, N'San Juan', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (18, 18, 1, N'San Luis', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (19, 19, 1, N'Río Gallegos', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (20, 20, 1, N'Santa Fe', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (21, 21, 1, N'Santiago del Estero', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (22, 22, 1, N'Ushuaia', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (23, 23, 1, N'San Miguel de Tucumán', 1)
GO
SET IDENTITY_INSERT [dbo].[LocationCity] OFF
GO
SET IDENTITY_INSERT [dbo].[LocationCountry] ON 

GO
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (1, N'Argentina', 1)
GO
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (2, N'Chile', 1)
GO
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (3, N'Uruguay', 1)
GO
INSERT [dbo].[LocationCountry] ([idLocationCountry], [Description], [Visible]) VALUES (4, N'Paraguay', 1)
GO
SET IDENTITY_INSERT [dbo].[LocationCountry] OFF
GO
SET IDENTITY_INSERT [dbo].[LocationProvince] ON 

GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (1, 1, N'Buenos Aires', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (2, 1, N'Catamarca', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (3, 1, N'Chaco', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (4, 1, N'Chubut', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (5, 1, N'Córdoba', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (6, 1, N'Corrientes', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (7, 1, N'Entre Ríos', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (8, 1, N'Formosa', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (9, 1, N'Jujuy', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (10, 1, N'La Pampa', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (11, 1, N'La Rioja', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (12, 1, N'Mendoza', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (13, 1, N'Misiones', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (14, 1, N'Neuquén', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (15, 1, N'Río Negro', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (16, 1, N'Salta', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (17, 1, N'San Juan', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (18, 1, N'San Luis', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (19, 1, N'Santa Cruz', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (20, 1, N'Santa Fe', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (21, 1, N'Santiago del Estero', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (22, 1, N'Tierra del Fuego', 1)
GO
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (23, 1, N'Tucumán', 1)
GO
SET IDENTITY_INSERT [dbo].[LocationProvince] OFF
GO
SET IDENTITY_INSERT [dbo].[Parent] ON 

GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [IdRelationship], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (1, N'MARCOS ANDRES', N'CARRERAS', 1, N'30660412', N'3513006155', N'3513006155', N'M@M.COM.AR', 1, 1, 1, 1, N'PRINGLES 1218', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [IdRelationship], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (3, N'MAURO EZEQUIEL ', N'CARRERAS', 1, N'23232323', N'22222222', N'222222222', N'M@M.COM.AR', 1, 1, 1, 1, N'COLON 12', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [IdRelationship], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (4, N'XILENIA', N'MARIA', 1, N'34343434', N'232', N'23', N'X@M.COM', 1, 1, 1, 1, N'1', 1)
GO
SET IDENTITY_INSERT [dbo].[Parent] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (1, N'HISLER', N'LLANOS', CAST(0x71010B00 AS Date), 1, 121212, 1, 1, 1, 1, N'AV SANTA ANA 1728', N'0351 4873272', 1, 1, CAST(0x543D0B00 AS Date), NULL, NULL, 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (2, N'ANTONIA', N'TORRES', CAST(0x71010B00 AS Date), 1, 121212, 1, 1, 1, 1, N'AV SANTA ANA 1728', N'0351 4873272', 1, 1, CAST(0x543D0B00 AS Date), NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientParent] ON 

GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [Visible]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [Visible]) VALUES (2, 2, 2, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [Visible]) VALUES (3, 1, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[PatientParent] OFF
GO
SET IDENTITY_INSERT [dbo].[Professional] ON 

GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Admin], [Visible]) VALUES (1, N'TEST', N'TEST', 1, 1, 1, 1, N'TEST', N'12345678', N'TEST@TEST', N'DOC', N'123445', 0, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Admin], [Visible]) VALUES (4, N'A', N'A', 1, 1, 1, 1, N'A', N'12345678', N'TEST@TEST', N'DOC', N'123445', 0, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [Admin], [Visible]) VALUES (5, N'LEO', N'BACK', 1, 1, 1, 1, N'A', N'12345678', N'TEST@TEST', N'Leo', N'le0nard0', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Professional] OFF
GO
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] ON 

GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (2, 1, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (3, 1, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] OFF
GO
SET IDENTITY_INSERT [dbo].[Relationship] ON 

GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (1, N'ESPOSA', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (2, N'ESPOSO', 2)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (3, N'NIETO', 3)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (4, N'HIJO', 4)
GO
SET IDENTITY_INSERT [dbo].[Relationship] OFF
GO
SET IDENTITY_INSERT [dbo].[SocialWork] ON 

GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (1, N'OSITAC', N'TRASNPORTE', 1, 1, 1, N'BALCARSE 525', N'1111111', N'INTERNO', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (2, N'OSPE', N'GENERICA', 1, 1, 1, N'BALCARSE 525', N'1111111', N'INTERNO', 1)
GO
SET IDENTITY_INSERT [dbo].[SocialWork] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialty] ON 

GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (1, N'Traumatologia', 1)
GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (2, N'Fisioterapia', 1)
GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (3, N'Cardiología', 1)
GO
SET IDENTITY_INSERT [dbo].[Specialty] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] ON 

GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (1, N'DNI', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (2, N'PASPORT', 2)
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] OFF
GO
ALTER TABLE [dbo].[Diagnostic] ADD  DEFAULT ((1)) FOR [Visible]
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
ALTER TABLE [dbo].[Professional] ADD  CONSTRAINT [DF_Professional_Admin]  DEFAULT ((0)) FOR [Admin]
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
USE [master]
GO
ALTER DATABASE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF] SET  READ_WRITE 
GO
