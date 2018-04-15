USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spFilterLimitCountProfesionales-v1.0]    Script Date: 15/04/2018 13:16:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/20 22:40>
-- Description:	<Contador para Lista Paginador>
-- =============================================
CREATE PROCEDURE [dbo].[spFilterLimitCountProfesionales-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LastName VARCHAR(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @rCount INT
	IF (@Name = '' AND @LastName = '')  
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdProfessional]) FROM [dbo].[Professional]
			--WHERE 
			--[Name] LIKE +'%'+ @Name +'%'
			--AND [LastName] LIKE +'%'+ @LastName +'%'
			--AND [Visible] = @Visible
		)
	END

	IF (@Name = '' AND @LastName != '')	
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdProfessional]) FROM [dbo].[Professional]
			WHERE 
			--[Name] LIKE +'%'+ @Name +'%' AND
			[LastName] LIKE +'%'+ @LastName +'%'
			--AND [Visible] = @Visible
		)
	END

	IF (@Name != '' AND @LastName = '')	
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdProfessional]) FROM [dbo].[Professional]
			WHERE 
			[Name] LIKE +'%'+ @Name +'%' 
			--AND [LastName] LIKE +'%'+ @LastName +'%'
			--AND [Visible] = @Visible
		)
	END

	IF (@Name != '' AND @LastName != '')															--11                                                
	BEGIN
		SET @rCount = 
		(
			SELECT COUNT([IdProfessional]) FROM [dbo].[Professional]
			WHERE 
			[Name] LIKE +'%'+ @Name +'%'
			AND [LastName] LIKE +'%'+ @LastName +'%'
			--AND [Visible] = @Visible
		)
	END 

	RETURN @rCount
END
GO


