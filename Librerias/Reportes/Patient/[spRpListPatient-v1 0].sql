USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpListPatient-v1.0]    Script Date: 28/10/2017 05:34:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/10/28 18:15>
-- Description:	<ReportListPatient>
-- =============================================
Create PROCEDURE [dbo].[spRpListPatient-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@AffiliateNumber int = 0,
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