USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitPatient-v1.1]    Script Date: 15/04/2018 13:17:46 ******/
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


