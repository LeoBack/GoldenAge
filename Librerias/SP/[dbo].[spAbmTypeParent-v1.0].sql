USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmTypeParent-v1.0]    Script Date: 15/04/2018 13:16:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andr�s>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmTypeParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idTypeParent int = 0,
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
		SELECT [idTypeParent],[Description],[Visible]
		FROM [dbo].[TypeParent]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[TypeParent] )--WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idTypeParent],[Description],[Visible]
		FROM [dbo].[TypeParent]
		WHERE [idTypeParent] = @idTypeParent --AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[TypeParent] WHERE [idTypeParent] = @idTypeParent)-- AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[TypeParent] ([Description])
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
			UPDATE [dbo].[TypeParent] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idTypeParent] = @idTypeParent
			COMMIT TRANSACTION
			RETURN @idTypeParent
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
			DELETE FROM [dbo].[TypeParent] WHERE [idTypeParent] = @idTypeParent
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
	SELECT [idTypeParent] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[TypeParent]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END


GO


