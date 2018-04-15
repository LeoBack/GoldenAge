USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spRpListPatient-v1.1]    Script Date: 15/04/2018 13:20:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/08 21:30>
-- Description:	<ReportListPatient>
-- =============================================
create PROCEDURE [dbo].[spRpListPatient-v1.1] 
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
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso', 
			   [P].[ReasonExit] AS 'Motivo egreso' 
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
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso', 
			   [P].[ReasonExit] AS 'Motivo egreso' 
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
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso', 
			   [P].[ReasonExit] AS 'Motivo egreso' 
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
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso', 
			   [P].[ReasonExit] AS 'Motivo egreso' 
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
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso', 
			   [P].[ReasonExit] AS 'Motivo egreso' 
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
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso', 
			   [P].[ReasonExit] AS 'Motivo egreso' 
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
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso', 
			   [P].[ReasonExit] AS 'Motivo egreso' 
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
		       CONCAT([Ty].[Description],' ',[P].[NumberDocument] ) AS 'Documento',
	           [P].[DateAdmission] AS 'Ingreso', [P].[EgressDate] AS 'Egreso', 
			   [P].[ReasonExit] AS 'Motivo egreso' 
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


