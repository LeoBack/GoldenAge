USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmLocationProvince-v1.0]    Script Date: 15/04/2018 13:12:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLocationProvince-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idLocationProvince int = 0,
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
		SELECT [idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationProvince]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationProvince] WHERE [Visible] = @Visible )
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationProvince]
		WHERE [idLocationProvince] = @idLocationProvince AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationProvince] WHERE [idLocationProvince] = @idLocationProvince AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[LocationProvince] ([idLocationCountry],[Description])
			VALUES (@idLocationCountry, @Description)
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
			UPDATE [dbo].[LocationProvince] 
			SET 
			[idLocationCountry] = @idLocationCountry,
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idLocationProvince] = @idLocationProvince
			COMMIT TRANSACTION
			RETURN @idLocationProvince
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
			DELETE FROM [dbo].[LocationCity] WHERE [idLocationProvince] = @idLocationProvince
			DELETE FROM [dbo].[LocationProvince] WHERE [idLocationProvince] = @idLocationProvince
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
		SELECT [idLocationProvince] AS 'Id', [Description] AS 'Value' 
		FROM [dbo].[LocationProvince]
		WHERE [idLocationCountry] = @idLocationCountry
		AND [Visible] = @Visible
		ORDER BY [Description] ASC
	END
END

GO


