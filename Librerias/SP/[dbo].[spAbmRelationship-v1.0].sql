USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmRelationship-v1.0]    Script Date: 15/04/2018 13:14:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmRelationship-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idRelationship int = 0,
	@Description varchar(50) = null,
	@Visible int = 1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idRelationship],[Description],[Visible]
		FROM [dbo].[Relationship]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Relationship]) --WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idRelationship],[Description],[Visible]
		FROM [dbo].[Relationship]
		WHERE [idRelationship] = @idRelationship --AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Relationship] WHERE [idRelationship] = @idRelationship)-- AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Relationship] ([Description])
			VALUES (@Description)
			COMMIT TRANSACTION
			RETURN @@identity
			END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[INSERT]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 3	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			UPDATE [dbo].[Relationship] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idRelationship] = @idRelationship
			COMMIT TRANSACTION
			RETURN @idRelationship
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[UPDATE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 4	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM [dbo].[Relationship] WHERE [idRelationship] = @idRelationship
			COMMIT TRANSACTION
			RETURN 1
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 5
	BEGIN
	SELECT [idRelationship] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[Relationship]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END


GO


