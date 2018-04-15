USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitCountPatient-v1.1]    Script Date: 15/04/2018 13:16:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2018/02/08 16:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
create PROCEDURE [dbo].[spFilterLimitCountPatient-v1.1] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@AffiliateNumber varchar(50) = null,
	@NumberDocument int =0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @rCount INT
	IF (@Name='' AND @LastName='' AND @NumberDocument=0)		-- 000
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			--WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			--[NumberDocument] = @NumberDocument AND
			--[Visible] = @Visible
		)
	END

	IF (@Name='' AND @LastName='' AND @NumberDocument!=0)		--001
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND 
			[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END

	IF (@Name='' AND @LastName!='' AND @NumberDocument=0)		--010
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' --AND 
			--[NumberDocument] = @NumberDocument AND
			--[Visible] = @Visible
		)
	END

	IF (@Name='' AND @LastName!='' AND @NumberDocument!=0)		--011                                                
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			--[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' AND
			[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name!='' AND @LastName!='' AND @NumberDocument=0)		--100                                               
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' --AND 
			--[LastName] like +'%'+@LastName+'%' --AND 
			--[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name!='' AND @LastName!='' AND @NumberDocument!=0)		--101 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			--[LastName] like +'%'+@LastName+'%' AND
			[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name!='' AND @LastName!='' AND @NumberDocument=0)		--110 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' --AND 
			--[AffiliateNumber] like +'%'+ @AffiliateNumber+'%' --AND 
			--[NumberDocument] = @NumberDocument AND
			--[Visible] = @Visible
		)
	END 

	IF (@Name='' AND @LastName!='' AND @NumberDocument!=0)		--111 
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdPatient]) FROM [dbo].[Patient]
			WHERE 
			[Name] like +'%'+@Name+'%' AND 
			[LastName] like +'%'+@LastName+'%' AND 
			[NumberDocument] = @NumberDocument --AND
			--[Visible] = @Visible
		)
	END 
	RETURN @rCount
END
GO


