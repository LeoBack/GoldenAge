USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmLocationCountry-v1.0]    Script Date: 15/04/2018 13:11:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLocationCountry-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idLocationCountry int = 0,
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
		SELECT [idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCountry]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCountry] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCountry]
		WHERE [idLocationCountry] = @idLocationCountry AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCountry] WHERE [idLocationCountry] = @idLocationCountry AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[LocationCountry] ([Description])
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
			UPDATE [dbo].[LocationCountry] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idLocationCountry] = @idLocationCountry
			COMMIT TRANSACTION
			RETURN @idLocationCountry
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
			DELETE FROM [dbo].[LocationCity] WHERE [idLocationCountry] = @idLocationCountry
			DELETE FROM [dbo].[LocationProvince] WHERE [idLocationCountry] = @idLocationCountry
			DELETE FROM [dbo].[LocationCountry] WHERE [idLocationCountry] = @idLocationCountry
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
	SELECT [idLocationCountry] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[LocationCountry]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END

GO


