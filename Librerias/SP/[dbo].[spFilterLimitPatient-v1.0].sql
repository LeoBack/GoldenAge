USE [GOLDENAGE-03.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitPatient-v1.0]    Script Date: 15/04/2018 13:28:53 ******/
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


