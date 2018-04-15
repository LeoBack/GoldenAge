/****** Object:  StoredProcedure [dbo].[spAbmPatient-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
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
	@AffiliateNumber varchar(50) = null,
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
/****** Object:  StoredProcedure [dbo].[spAbmPatient-v1.1]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/07 11:15>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPatient-v1.1] 
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
		SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[DateAdmission],[EgressDate],[ReasonExit],[Visible]
		FROM [dbo].[Patient]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Patient]) --WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdPatient],[Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[DateAdmission],[EgressDate],[ReasonExit],[Visible]
		FROM [dbo].[Patient]
		WHERE [IdPatient] = @IdPatient --AND 
		--[Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Patient] WHERE [IdPatient] = @IdPatient)-- AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Patient ([Name],[LastName],[Birthdate],[IdTypeDocument],[NumberDocument],[Sex],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[DateAdmission],[EgressDate],[ReasonExit],[Visible])
			VALUES (@Name,@LastName,@Birthdate,@IdTypeDocument,@NumberDocument,@Sex,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Phone,@DateAdmission,@EgressDate,@ReasonExit,@Visible)
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
/****** Object:  StoredProcedure [dbo].[spFilterLimitCountPatient-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 22:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitCountPatient-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@AffiliateNumber varchar(50) = null,
	@IdSocialWork int =0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @rCount INT
	IF (@Name='' AND @LastName='' AND @AffiliateNumber='' AND @IdSocialWork=0)		-- 0000
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			--WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			--[IdSocialWork] = @IdSocialWork AND
			--[Visible] = @Visible
		)
	END

	IF (@Name='' AND @LastName='' AND @AffiliateNumber='' AND @IdSocialWork!=0)		--0001
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END

	IF (@Name='' AND @LastName='' AND @AffiliateNumber!='' AND @IdSocialWork=0)		--0010
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' --AND 
			--[IdSocialWork] = @IdSocialWork AND
			--[Visible] = @Visible
		)
	END

	IF (@Name='' AND @LastName='' AND @AffiliateNumber!='' AND @IdSocialWork!=0)	--0011                                                
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name='' AND @LastName!='' AND @AffiliateNumber='' AND @IdSocialWork=0)		--0100                                               
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' --AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			--[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name='' AND @LastName!='' AND @AffiliateNumber='' AND @IdSocialWork!=0)	--0101 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' --AND 
			[LastName] like +'%'+@LastName+'%' AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name='' AND @LastName!='' AND @AffiliateNumber!='' AND @IdSocialWork=0)	--0110 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' --AND 
			[LastName] like +'%'+@LastName+'%' AND 
			[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' --AND 
			--[IdSocialWork] = @IdSocialWork AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name='' AND @LastName!='' AND @AffiliateNumber!='' AND @IdSocialWork!=0)	--0111 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' --AND 
			[LastName] like +'%'+@LastName+'%' AND 
			[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END 
	--
	IF (@Name!='' AND @LastName='' AND @AffiliateNumber='' AND @IdSocialWork=0)		-- 1000
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' --AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			--[IdSocialWork] = @IdSocialWork AND
			--[Visible] = @Visible
		)
	END

	IF (@Name!='' AND @LastName='' AND @AffiliateNumber='' AND @IdSocialWork!=0)		--1001
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END

	IF (@Name!='' AND @LastName='' AND @AffiliateNumber!='' AND @IdSocialWork=0)		--1010
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' --AND 
			--[IdSocialWork] = @IdSocialWork AND
			--[Visible] = @Visible
		)
	END

	IF (@Name!='' AND @LastName='' AND @AffiliateNumber!='' AND @IdSocialWork!=0)	--1011                                                
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name!='' AND @LastName!='' AND @AffiliateNumber='' AND @IdSocialWork=0)		--1100                                               
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' --AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			--[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name!='' AND @LastName!='' AND @AffiliateNumber='' AND @IdSocialWork!=0)	--1101 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name!='' AND @LastName!='' AND @AffiliateNumber!='' AND @IdSocialWork=0)	--1110 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' AND 
			[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' --AND 
			--[IdSocialWork] = @IdSocialWork AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name!='' AND @LastName!='' AND @AffiliateNumber!='' AND @IdSocialWork!=0)	--1111 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' AND 
			[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[IdSocialWork] = @IdSocialWork --AND
			--[Visible] = @Visible
		)
	END 
	RETURN @rCount
END
GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitPatient-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 22:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitPatient-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@AffiliateNumber varchar(50) = null,
	@IdSocialWork int =0,
	@Pag INT = 1,		-- Id actual
	@RowsShow INT = 1,	-- Cantidad de filas a mostrar
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF (@Name='' AND @LastName='' AND @AffiliateNumber='' AND @IdSocialWork=0)     --0000
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			--WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			--[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			--[P].[IdSocialWork] = @IdSocialWork AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF(@Name='' AND @LastName='' AND @AffiliateNumber='' AND @IdSocialWork!=0)    --0001 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			--[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[P].[IdSocialWork] = @IdSocialWork --AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF (@Name='' AND @LastName='' AND @AffiliateNumber!='' AND @IdSocialWork=0)    --0010 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' --AND 
			--[P].[IdSocialWork] = @IdSocialWork AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF(@Name='' AND @LastName='' AND @AffiliateNumber!='' AND @IdSocialWork!=0)	 --0011 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    [Ty].[Description] AS 'Tipo Documento',[So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[P].[IdSocialWork] = @IdSocialWork --AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF(@Name='' AND @LastName!='' AND @AffiliateNumber='' AND @IdSocialWork=0)	 --0100 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible]  
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' --AND 
			--[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			--[P].[IdSocialWork] = @IdSocialWork AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF(@Name!='' AND @LastName='' AND @AffiliateNumber='' AND @IdSocialWork=0)	 --1000 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			[P].[Name] like +'%'+@Name+'%' --AND 
			--[P].[LastName] like +'%'+@LastName+'%' AND 
			--[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			--[P].[IdSocialWork] = @IdSocialWork AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF(@Name='' AND @LastName!='' AND @AffiliateNumber='' AND @IdSocialWork!=0)   --0101 
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' AND 
			--[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[P].[IdSocialWork] = @IdSocialWork --AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF(@Name='' AND @LastName!='' AND @AffiliateNumber!='' AND @IdSocialWork=0)   --0110
	BEGIN 
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' AND 
			[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' --AND 
			--[P].[IdSocialWork] = @IdSocialWork AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF(@Name='' AND @LastName!='' AND @AffiliateNumber!='' AND @IdSocialWork!=0)  --0111
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			--[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' AND 
			[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[P].[IdSocialWork] = @IdSocialWork --AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END

	IF(@Name!='' AND @LastName!='' AND @AffiliateNumber!='' AND @IdSocialWork!=0)  --0111
	BEGIN
		SELECT * FROM 
		(
			SELECT ROW_NUMBER() OVER (ORDER BY [LastName] ASC) AS RowNum, [P].[IdPatient], 
			CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
			[P].[Birthdate] AS'Cumpleaños',
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', [So].[Name] AS 'Obra Social',
	        [P].[AffiliateNumber] AS'Numero de Afiliado', [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible]  
			FROM [dbo].[Patient] AS [P] 
			INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument]=[Ty].[IdTypeDocument]
			INNER JOIN [dbo].[SocialWork] AS So ON [P].[IdSocialWork]=[So].[IdSocialWork]
			WHERE 
			[P].[Name] like +'%'+@Name+'%' AND 
			[P].[LastName] like +'%'+@LastName+'%' AND 
			[P].[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' AND 
			[P].[IdSocialWork] = @IdSocialWork --AND
			--[P].[Visible] = @Visible
		) AS ResultadoPaginado
		WHERE RowNum BETWEEN (@Pag - 1) * @RowsShow + 1 AND @Pag * @RowsShow
	END
	
END

GO
/****** Object:  StoredProcedure [dbo].[spFilterLimitPatient-v1.1]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/07 14:39>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitPatient-v1.1] 
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
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento',
	        [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
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
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento',
	        [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
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
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento',
	        [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
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
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento',
	        [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
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
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento',
	        [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible]  
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
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento',
	        [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
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
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento',
	        [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
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
		    CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento',
	        [P].[DateAdmission] AS 'F. de Ingreso',
			[P].[EgressDate] AS'Fecha de Alta' ,[P].[ReasonExit] AS 'Motivo de Egreso', [P].[Visible] 
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
/****** Object:  StoredProcedure [dbo].[spRpListPatient-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<ReportListPatient>
-- =============================================
CREATE PROCEDURE [dbo].[spRpListPatient-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LastName VARCHAR(50) = null,
	@AffiliateNumber INT = 0,
	@IdSocialWork INT =0,
	@Visible INT =1
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF(@Name = '' AND @LastName = '' AND @AffiliateNumber = 0 AND @IdSocialWork = 0)     --0000
	BEGIN	
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name = '' AND @LastName = '' AND @AffiliateNumber = 0 AND @IdSocialWork != 0)    --0001 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name = '' AND @LastName = '' AND @AffiliateNumber != 0 AND @IdSocialWork = 0)    --0010 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name = '' AND @LastName = '' AND @AffiliateNumber != 0 AND @IdSocialWork != 0)	 --0011 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name = '' AND @LastName != '' AND @AffiliateNumber = 0 AND @IdSocialWork = 0)	 --0100 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name != '' AND @LastName = '' AND @AffiliateNumber = 0 AND @IdSocialWork = 0)	 --1000 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND
		--[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name = '' AND @LastName != '' AND @AffiliateNumber = 0 AND @IdSocialWork != 0)   --0101 
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND
		[P].[LastName] like +'%'+@LastName+'%' AND 
		--[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name = '' AND @LastName != '' AND @AffiliateNumber != 0 AND @IdSocialWork = 0)   --0110
	BEGIN 
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND
		--[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name = '' AND @LastName != '' AND @AffiliateNumber != 0 AND @IdSocialWork != 0)  --0111
	BEGIN
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		--[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END

	IF(@Name != '' AND @LastName != '' AND @AffiliateNumber != 0 AND @IdSocialWork != 0)  --0111
	BEGIN
		SELECT CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre',
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
			   [P].[AffiliateNumber] AS 'N. Afiliado', [So].[Name] AS 'Obra Social',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso' , [P].[ReasonExit] AS 'Motivo egreso' 
		FROM [dbo].[Patient] AS [P] 
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE 
		[P].[Name] like +'%'+@Name+'%' AND 
		[P].[LastName] like +'%'+@LastName+'%' AND 
		[P].[AffiliateNumber] = @AffiliateNumber AND 
		[P].[IdSocialWork] = @IdSocialWork AND
		[P].[Visible] = @Visible
		ORDER BY [P].[Name]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spRpOnlyPatient-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report RpOnlyPatient>
-- =============================================
CREATE PROCEDURE [dbo].[spRpOnlyPatient-v1.0] 
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
			   [P].[Phone] AS 'Telefono',
			   [AffiliateNumber] AS 'N. Afiliado',
			   [So].[Name] AS 'Obra Social',
			   [DateAdmission] AS 'Ingreso',
			   [EgressDate] AS 'Egreso',
			   [ReasonExit] AS 'Motivo egreso'
		FROM [dbo].[Patient] AS [P]
		INNER JOIN LocationCountry AS [lCu] ON [P].[idLocationCountry] = [lCu].[idLocationCountry]
		INNER JOIN LocationProvince AS [lPv] ON [P].[idLocationProvince] = [lPv].[idLocationProvince]
		INNER JOIN LocationCity AS [lCy] ON [P].[idLocationCity] = [lCy].[idLocationCity]
		INNER JOIN [dbo].[TypeDocument] AS [Ty] ON  [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
		INNER JOIN [dbo].[SocialWork] AS [So] ON  [P].[IdSocialWork] = [So].[IdSocialWork]
		WHERE [P].[IdPatient] = @IdPatient
	END
GO
/****** Object:  StoredProcedure [dbo].[spSearchParent-v1.0]    Script Date: 15/04/2018 0:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Busca Parientes>
-- =============================================
CREATE PROCEDURE [dbo].[spSearchParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdTypeDocument int = 0,
	@NumberDocument int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	BEGIN
		SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
		FROM [dbo].[Parent]
		WHERE [IdTypeDocument] = @IdTypeDocument AND [NumberDocument] = @NumberDocument
		RETURN (SELECT COUNT(*) FROM [dbo].[Parent] WHERE [IdTypeDocument] = @IdTypeDocument AND [NumberDocument] = @NumberDocument)
	END
END
GO