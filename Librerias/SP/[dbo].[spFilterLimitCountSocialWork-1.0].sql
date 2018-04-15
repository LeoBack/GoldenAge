USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitCountSocialWork-1.0]    Script Date: 15/04/2018 13:17:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 18:00>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitCountSocialWork-1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = '',
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @rCount INT
	if(@Name!='')
	BEGIN
		SET @rCount = (SELECT COUNT([IdSocialWork]) FROM [dbo].[SocialWork]
		WHERE [Name] like +'%'+ @Name +'%'
		--AND [Visible] = @Visible
		)
	END

	if(@Name='')
	BEGIN
		SET @rCount = (SELECT COUNT([IdSocialWork]) FROM [dbo].[SocialWork]
		--WHERE
		--AND [Name] like +'%'+ @Name +'%' 
		--AND [Visible] = @Visible
		)
	END
	RETURN @rCount
END
GO


