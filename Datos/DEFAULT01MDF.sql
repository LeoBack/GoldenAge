USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT01.MDF]
GO
/****** Object:  StoredProcedure [dbo].[GetCountPaginasSocialWorks]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[GetPaginasRowNumberSocialWorks]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[GetPaginasSinPaginarSocialWork]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[GetPaginasTOPmayorQueSocialWork]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[GetPaginasTOPmenorQueSocialWork]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmDiagnostic-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmIvaType-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLocationCity-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLocationCountry-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmLocationProvince-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmParent-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmPatientParent-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmPatient-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmPermission-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmProfessionalSpeciality-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmProfessional-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmRelationship-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmSocialWork-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmSpecialty-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmTypeDocument-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spAbmTypeParent-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spListPatient-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spListProfessional-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spListSocialWorks-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spLoguin-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spRpClinicHistory-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spRpListPatient-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spRpListProfessional-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spRpOnlyPatient-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessionalSpeciality-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spRpOnlyProfessional-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spRpPatientParent-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spSession-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  StoredProcedure [dbo].[spSpecialityProfessional-v1.0]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[Diagnostic]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[IvaType]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[LocationCity]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[LocationCountry]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[LocationProvince]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[Parent]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[Patient]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[PatientParent]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[Permission]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[Professional]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[ProfessionalSpeciality]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[Relationship]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[Session]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[SocialWork]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[Specialty]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[TypeDocument]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
/****** Object:  Table [dbo].[TypeParent]    Script Date: 07/11/2017 09:08:17 p.m. ******/
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
SET IDENTITY_INSERT [dbo].[Diagnostic] ON 

GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (1, 1, 3, 6, CAST(0x0000A80500000000 AS DateTime), N'Primer diagnostico TEST', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (2, 1, 2, 6, CAST(0x0000A80500000000 AS DateTime), N'Segundo diagnostico', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (3, 2, 3, 6, CAST(0x0000A80500000000 AS DateTime), N'Primer Diagnostico', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (4, 2, 2, 6, CAST(0x0000A80500000000 AS DateTime), N'Segundo diagnostico TEST', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (5, 2, 2, 6, CAST(0x0000A80500000000 AS DateTime), N'Tercer Diagnostico', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (6, 2, 3, 6, CAST(0x0000A80500000000 AS DateTime), N'Cuarto', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (7, 2, 4, 20, CAST(0x0000A80700000000 AS DateTime), N'Corte de uña', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (8, 2, 1, 20, CAST(0x0000A81D0155437E AS DateTime), N'Prueba de validaciones

VERIFICAR LOS DEDOS GORDOS DEL PIE IZQ DER', 1, 20, 1, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (9, 2, 2, 20, CAST(0x0000A80700000000 AS DateTime), N'prueba', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (10, 2, 5, 20, CAST(0x0000A80700000000 AS DateTime), N'PRuebas', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (11, 7, 4, 20, CAST(0x0000A81A010C03CA AS DateTime), N'Encarnada', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (12, 7, 4, 20, CAST(0x0000A81A010CDEC7 AS DateTime), N'dedo amputado  ....,,.', 0, 0, 0, 1)
GO
INSERT [dbo].[Diagnostic] ([idDiagnostic], [IdPatient], [IdSpeciality], [IdProfessional], [Date], [Detail], [IdDestinationSpeciality], [IdDestinationProfessional], [DestinationRead], [Visible]) VALUES (13, 2, 5, 20, CAST(0x0000A81F0028AAFA AS DateTime), N'Prueba-
Mensaje A. ', 2, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Diagnostic] OFF
GO
SET IDENTITY_INSERT [dbo].[IvaType] ON 

GO
INSERT [dbo].[IvaType] ([IdIvaType], [Description], [Visible]) VALUES (1, N'Responsable Inscripto', 1)
GO
INSERT [dbo].[IvaType] ([IdIvaType], [Description], [Visible]) VALUES (2, N'Monotributo', 1)
GO
INSERT [dbo].[IvaType] ([IdIvaType], [Description], [Visible]) VALUES (3, N'Exento', 1)
GO
SET IDENTITY_INSERT [dbo].[IvaType] OFF
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
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (24, 5, 1, N'La Calera', 1)
GO
INSERT [dbo].[LocationCity] ([idLocationCity], [idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (25, 24, 2, N'Santiago de Chile', 1)
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
INSERT [dbo].[LocationProvince] ([idLocationProvince], [idLocationCountry], [Description], [Visible]) VALUES (24, 2, N'Region Metropilitana', 1)
GO
SET IDENTITY_INSERT [dbo].[LocationProvince] OFF
GO
SET IDENTITY_INSERT [dbo].[Parent] ON 

GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (1, N'MARCOS', N'ANDRES', 1, N'33000222', N'03514455667', N'000055544433', N'MC@MC.COM', 1, 5, 5, N'IRIGOYEN', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (2, N'BELEN', N'GIURICICH', 1, N'11222333', N'035412233445', N'0987654', N'BL@BL.COM', 1, 1, 1, N'NOSE', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (3, N'NOMBRE', N'APELLIDO', 1, N'11222333', N'009998887765', N'66789', N'A@A.COM', 2, 24, 25, N'BAHIA DE CONCHA', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (4, N'BB', N'B', 1, N'22333444', N'1111122223334', N'', N'', 1, 4, 4, N'QWERT', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (5, N'C', N'CC', 1, N'44555666', N'', N'', N'', 1, 5, 5, N'DENA FUNES', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (6, N'D', N'D', 1, N'1122233', N'', N'', N'', 1, 3, 3, N'ASD', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (7, N'MAURO EDITAR', N'CARRERAS', 1, N'30660412', N'2132435', N'111', N'MAC@MAC.OCM', 1, 5, 24, N'PRINGLES 1218', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (8, N'WWKLSV WS', N'SSSLA', 1, N'345467562', N'', N'', N'MSC@ASFC.COM', 1, 1, 1, N'LKMDB MXBDV2', 1)
GO
INSERT [dbo].[Parent] ([IdParent], [Name], [LastName], [IdTypeDocument], [NumberDocument], [Phone], [AlternativePhone], [Email], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Visible]) VALUES (9, N'WWKLSV WS', N'SSSLA', 1, N'345467562', N'3212321)(-', N'', N'MSC@ASFC.COM', 1, 1, 1, N'LKMDB MXBDV2', 1)
GO
SET IDENTITY_INSERT [dbo].[Parent] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (1, N'HISLER', N'LLANOS', CAST(0xEFD00A00 AS Date), 1, 121212, 1, 1, 1, 1, N'AV SANTA ANA 1728', N'0351 4873272', 1, 10000000, CAST(0x543D0B00 AS Date), CAST(0x593D0B00 AS Date), N'', 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (2, N'ANTONIA', N'TORRES', CAST(0x28D60A00 AS Date), 2, 121212, 0, 1, 3, 3, N'AV SANTA ANA 1728', N'0351 4873272', 1, 12121212, CAST(0x87320B00 AS Date), CAST(0x593D0B00 AS Date), N'', 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (5, N'MEC', N'MAC', CAST(0x753D0B00 AS Date), 1, 30660412, 0, 1, 1, 1, N'', N'', 19, 123456789012345678, CAST(0x753D0B00 AS Date), CAST(0x753D0B00 AS Date), N'', 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (6, N'AS', N'MW', CAST(0x753D0B00 AS Date), 1, 123456098, 0, 1, 1, 1, N'', N'', 19, 12345679012345678, CAST(0x753D0B00 AS Date), CAST(0x753D0B00 AS Date), N'', 1)
GO
INSERT [dbo].[Patient] ([IdPatient], [Name], [LastName], [Birthdate], [IdTypeDocument], [NumberDocument], [Sex], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [IdSocialWork], [AffiliateNumber], [DateAdmission], [EgressDate], [ReasonExit], [Visible]) VALUES (7, N'Z', N'A', CAST(0x753D0B00 AS Date), 1, 21345675, 1, 1, 1, 1, N'', N'324354653', 19, 43202562, CAST(0x753D0B00 AS Date), CAST(0x753D0B00 AS Date), N'', 1)
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientParent] ON 

GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (1, 1, 2, 3, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (2, 2, 1, 3, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (3, 2, 3, 4, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (4, 2, 4, 4, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (5, 2, 5, 3, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (6, 1, 6, 3, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (7, 1, 7, 4, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (8, 7, 8, 1, 1)
GO
INSERT [dbo].[PatientParent] ([IdPatientParent], [IdPatient], [IdParent], [IdRelationship], [Visible]) VALUES (9, 7, 9, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PatientParent] OFF
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 

GO
INSERT [dbo].[Permission] ([IdPermission], [Description], [Visible]) VALUES (1, N'Administrador', 1)
GO
INSERT [dbo].[Permission] ([IdPermission], [Description], [Visible]) VALUES (2, N'Auditor', 1)
GO
INSERT [dbo].[Permission] ([IdPermission], [Description], [Visible]) VALUES (3, N'Usuario', 1)
GO
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
SET IDENTITY_INSERT [dbo].[Professional] ON 

GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (1, N'TEST', N'TEST', 123, 1, 1, 1, N'TEST', N'12345678', N'TEST@TEST.COM', N'test', N'1234', 2, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (4, N'A', N'A', 123456, 1, 1, 1, N'A', N'12345678', N'TEST@TEST', N'A', N'testacesso', 2, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (5, N'C', N'C', 12, 1, 5, 5, N'C', N'3', N'C@C.COM.AR', N'c', N'1234', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (6, N'LEO', N'BACK', 111222, 1, 5, 5, N'DEAN FUNES', N'1', N'TEST@TEST.COM', N'leo', N'le0nard0', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (20, N'MARCOS ANDRÉS', N'CARRERAS', 170111, 1, 5, 5, N'PRINGLES 1218 D2', N'3513006155', N'MARCOSANDRESCARRERAS@GMAIL.COM', N'marcos', N'84m4rc0s17', 1, 1)
GO
INSERT [dbo].[Professional] ([IdProfessional], [Name], [LastName], [ProfessionalRegistration], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Mail], [User], [Password], [idPermission], [Visible]) VALUES (21, N'AAA', N'SSSS', 1245543, 1, 3, 3, N'EQDEQLDKQL  ', N'2300323123', N'MASD@MAD.COM.A', N'aadd222', N'12343232311', 3, 1)
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
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (4, 0, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (5, 20, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (6, 20, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (7, 20, 1, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (8, 20, 4, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (9, 5, 1, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (10, 6, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (11, 6, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (12, 4, 4, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (13, 4, 1, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (18, 20, 5, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (19, 21, 3, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (20, 21, 5, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (21, 21, 2, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (22, 21, 4, 1)
GO
INSERT [dbo].[ProfessionalSpeciality] ([IdProfessionalSpeciality], [IdProfessional], [IdSpeciality], [Visible]) VALUES (23, 21, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[ProfessionalSpeciality] OFF
GO
SET IDENTITY_INSERT [dbo].[Relationship] ON 

GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (1, N'ESPOSA', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (2, N'ESPOSO', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (3, N'NIETO', 1)
GO
INSERT [dbo].[Relationship] ([IdRelationship], [Description], [Visible]) VALUES (4, N'HIJO', 1)
GO
SET IDENTITY_INSERT [dbo].[Relationship] OFF
GO
SET IDENTITY_INSERT [dbo].[Session] ON 

GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (1, 20, CAST(0x0000A81A016DCBBE AS DateTime), CAST(0x0000A81A016EC986 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (2, 20, CAST(0x0000A81D0154F557 AS DateTime), CAST(0x0000A81D0154F7AF AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (3, 20, CAST(0x0000A81F00224496 AS DateTime), CAST(0x0000A81F002BF4EE AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (4, 20, CAST(0x0000A824013800D8 AS DateTime), CAST(0x0000A824013864E0 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (5, 20, CAST(0x0000A824014DC259 AS DateTime), CAST(0x0000A824014DC4B1 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (6, 20, CAST(0x0000A824014E8C1E AS DateTime), CAST(0x0000A824014E8E76 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (7, 20, CAST(0x0000A824014F8427 AS DateTime), CAST(0x0000A824014F867F AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (8, 6, CAST(0x0000A82401514372 AS DateTime), CAST(0x0000A8240151E634 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (9, 20, CAST(0x0000A82401549E95 AS DateTime), CAST(0x0000A8240154A0ED AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (10, 20, CAST(0x0000A82401553056 AS DateTime), CAST(0x0000A824015532AE AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (11, 20, CAST(0x0000A8240156CC77 AS DateTime), CAST(0x0000A82401579439 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (12, 20, CAST(0x0000A82401585403 AS DateTime), CAST(0x0000A8240158B5E4 AS DateTime))
GO
INSERT [dbo].[Session] ([idSession], [idProfessional], [InitDate], [EndDate]) VALUES (13, 20, CAST(0x0000A82401599219 AS DateTime), CAST(0x0000A824015A36B6 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
SET IDENTITY_INSERT [dbo].[SocialWork] ON 

GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (1, N'OSITAC', N'Transporte', 1, 1, 1, 1, N'BALCARCE', N'111111', N'SECRETARIA YANINA', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (3, N'O3S', N'do3', 0, 0, 0, 0, N'DOM3', N'3', N'3', 0)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (4, N'GEA', N'ni idea', 2, 1, 4, 4, N'ASDFSDG', N'', N'', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (5, N'TEST', N'testa', 3, 1, 3, 3, N'TESTD', N'', N'', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (6, N'E', N'r', 3, 1, 1, 1, N'E', N'34', N'ERT', 1)
GO
INSERT [dbo].[SocialWork] ([IdSocialWork], [Name], [Description], [IdIvaType], [idLocationCountry], [idLocationProvince], [idLocationCity], [Address], [Phone], [Contact], [Visible]) VALUES (19, N'TEST', N'asd', 2, 1, 5, 24, N'SLFNL{V', N'67078908', N'7576FHC', 1)
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
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (4, N'Podologia', 1)
GO
INSERT [dbo].[Specialty] ([IdSpecialty], [Description], [Visible]) VALUES (5, N'Enfermeria', 1)
GO
SET IDENTITY_INSERT [dbo].[Specialty] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] ON 

GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (1, N'DNI', 1)
GO
INSERT [dbo].[TypeDocument] ([IdTypeDocument], [Description], [Visible]) VALUES (2, N'PASPORT', 1)
GO
SET IDENTITY_INSERT [dbo].[TypeDocument] OFF
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
