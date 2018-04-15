USE [GOLDENAGE-03.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spRpListPatient-v1.0]    Script Date: 15/04/2018 13:29:52 ******/
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


