USE [GOLDENAGE-03.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitCountPatient-v1.0]    Script Date: 15/04/2018 13:28:13 ******/
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


