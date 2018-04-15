USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmTypeDocument-v1.0]    Script Date: 15/04/2018 13:15:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 23:29>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmTypeDocument-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idTypeDocument int = 0,
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
		SELECT [idTypeDocument],[Description],[Visible]
		FROM [dbo].[TypeDocument]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[TypeDocument] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idTypeDocument],[Description],[Visible]
		FROM [dbo].[TypeDocument]
		WHERE [idTypeDocument] = @idTypeDocument AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[TypeDocument] WHERE [idTypeDocument] = @idTypeDocument AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[TypeDocument] ([Description])
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
			UPDATE [dbo].[TypeDocument] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idTypeDocument] = @idTypeDocument
			COMMIT TRANSACTION
			RETURN @idTypeDocument
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
			DELETE FROM [dbo].[TypeDocument] WHERE [idTypeDocument] = @idTypeDocument
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
	SELECT [idTypeDocument] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[TypeDocument]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END

GO


