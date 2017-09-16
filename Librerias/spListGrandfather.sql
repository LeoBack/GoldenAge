USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spListGrandfather-v1.0]    Script Date: 16/09/2017 07:56:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 18:07>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spListGrandfather-v1.0] 
	-- Add the parameters for the stored procedure here
	@LastName varchar(20) = null,
	@AffiliateNumber int = 0,
	@IdSocialWork int =0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	if(@LastName='' and @AffiliateNumber=0 and @IdSocialWork=0)     --000
	BEGIN
		SELECT [G].[IdGrandFather], [G].[Name], [G].[LastName], [G].[LastName],[Ty].[Description],[So].[Name],
	           [G].[AffiliateNumber], [G].[DateAdmission],[G].[EgressDate] 
		FROM [dbo].[Grandfather] [G],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[G].[LastName] like +'%'+@LastName+'%' AND 
		--[G].[AffiliateNumber] = @AffiliateNumber AND 
		--[G].[IdSocialWork] = @IdSocialWork AND
		[G].[Visible] = @Visible

		And [G].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [G].[IdSocialWork]=[So].[IdSocialWork]
		Order by [G].[LastName]
	END
	if(@LastName='' and @AffiliateNumber=0 and @IdSocialWork!=0)    --001 
	BEGIN 
		SELECT [G].[IdGrandFather], [G].[Name], [G].[LastName], [G].[LastName],[Ty].[Description],[So].[Name],
	           [G].[AffiliateNumber], [G].[DateAdmission],[G].[EgressDate] 
		FROM [dbo].[Grandfather] [G],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[G].[LastName] like +'%'+@LastName+'%' AND 
		--[G].[AffiliateNumber] = @AffiliateNumber AND 
		[G].[IdSocialWork] = @IdSocialWork AND
		[G].[Visible] = @Visible

		And [G].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [G].[IdSocialWork]=[So].[IdSocialWork]
		Order by [G].[LastName]
	END
	if(@LastName='' and @AffiliateNumber!=0 and @IdSocialWork=0)    --010 
	BEGIN 
		SELECT [G].[IdGrandFather], [G].[Name], [G].[LastName], [G].[LastName],[Ty].[Description],[So].[Name],
	           [G].[AffiliateNumber], [G].[DateAdmission],[G].[EgressDate] 
		FROM [dbo].[Grandfather] [G],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[G].[LastName] like +'%'+@LastName+'%' AND 
		[G].[AffiliateNumber] = @AffiliateNumber AND 
		--[G].[IdSocialWork] = @IdSocialWork AND
		[G].[Visible] = @Visible

		And [G].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [G].[IdSocialWork]=[So].[IdSocialWork]
		Order by [G].[LastName]
	END
	if(@LastName='' and @AffiliateNumber!=0 and @IdSocialWork!=0)   --011 
	BEGIN 
		SELECT [G].[IdGrandFather], [G].[Name], [G].[LastName], [G].[LastName],[Ty].[Description],[So].[Name],
	           [G].[AffiliateNumber], [G].[DateAdmission],[G].[EgressDate] 
		FROM [dbo].[Grandfather] [G],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		--[G].[LastName] like +'%'+@LastName+'%' AND 
		[G].[AffiliateNumber] = @AffiliateNumber AND 
		[G].[IdSocialWork] = @IdSocialWork AND
		[G].[Visible] = @Visible

		And [G].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [G].[IdSocialWork]=[So].[IdSocialWork]
		Order by [G].[LastName]
	END
	if(@LastName!='' and @AffiliateNumber=0 and @IdSocialWork=0)    --100 
	BEGIN 
		SELECT [G].[IdGrandFather], [G].[Name], [G].[LastName], [G].[LastName],[Ty].[Description],[So].[Name],
	           [G].[AffiliateNumber], [G].[DateAdmission],[G].[EgressDate] 
		FROM [dbo].[Grandfather] [G],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		[G].[LastName] like +'%'+@LastName+'%' AND 
		--[G].[AffiliateNumber] = @AffiliateNumber AND 
		--[G].[IdSocialWork] = @IdSocialWork AND
		[G].[Visible] = @Visible

		And [G].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [G].[IdSocialWork]=[So].[IdSocialWork]
		Order by [G].[LastName]
	END
	if(@LastName!='' and @AffiliateNumber=0 and @IdSocialWork!=0)   --101 
	BEGIN 
		SELECT [G].[IdGrandFather], [G].[Name], [G].[LastName], [G].[LastName],[Ty].[Description],[So].[Name],
	           [G].[AffiliateNumber], [G].[DateAdmission],[G].[EgressDate] 
		FROM [dbo].[Grandfather] [G],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		[G].[LastName] like +'%'+@LastName+'%' AND 
		--[G].[AffiliateNumber] = @AffiliateNumber AND 
		[G].[IdSocialWork] = @IdSocialWork AND
		[G].[Visible] = @Visible

		And [G].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [G].[IdSocialWork]=[So].[IdSocialWork]
		Order by [G].[LastName]
	END
	if(@LastName!='' and @AffiliateNumber!=0 and @IdSocialWork=0)   --110
	BEGIN 
		SELECT [G].[IdGrandFather], [G].[Name], [G].[LastName], [G].[LastName],[Ty].[Description],[So].[Name],
	           [G].[AffiliateNumber], [G].[DateAdmission],[G].[EgressDate] 
		FROM [dbo].[Grandfather] [G],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		[G].[LastName] like +'%'+@LastName+'%' AND 
		[G].[AffiliateNumber] = @AffiliateNumber AND 
		--[G].[IdSocialWork] = @IdSocialWork AND
		[G].[Visible] = @Visible

		And [G].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [G].[IdSocialWork]=[So].[IdSocialWork]
		Order by [G].[LastName]
	END
	if(@LastName!='' and @AffiliateNumber!=0 and @IdSocialWork!=0)  --111
	BEGIN
		SELECT [G].[IdGrandFather], [G].[Name], [G].[LastName], [G].[LastName],[Ty].[Description],[So].[Name],
	           [G].[AffiliateNumber], [G].[DateAdmission],[G].[EgressDate] 
		FROM [dbo].[Grandfather] [G],[dbo].[TypeDocument] Ty, [dbo].[SocialWork] So  
		WHERE 
		[G].[LastName] like +'%'+@LastName+'%' AND 
		[G].[AffiliateNumber] = @AffiliateNumber AND 
		[G].[IdSocialWork] = @IdSocialWork AND
		[G].[Visible] = @Visible

		And [G].[IdTypeDocument]=[Ty].[IdTypeDocument]
		And [G].[IdSocialWork]=[So].[IdSocialWork]
		Order by [G].[LastName]
	END
	
END