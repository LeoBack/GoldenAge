USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmSocialWork-v1.0]    Script Date: 15/04/2018 13:14:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmSocialWork-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idSocialWork int = 0,
	@Name varchar(50) = null,
	@Description varchar(50) = null,
	@IdIvaType int=0,
	@IdLocationCountry int = 0,
    @IdLocationProvince int = 0,
    @IdLocationCity int = 0,
	@Address varchar(50) = null,
	@Phone varchar(50) = null,
    @Contact varchar(50) = null,
    @Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idSocialWork],[Name],[Description],[IdIvaType],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Address],[Phone],[Contact],[Visible]
		FROM [dbo].[SocialWork]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[SocialWork] )--WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idSocialWork],[Name],[Description],[IdIvaType],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Address],[Phone],[Contact],[Visible]
		FROM [dbo].[SocialWork]
		WHERE [idSocialWork] = @idSocialWork --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[SocialWork] WHERE [idSocialWork] = @idSocialWork )--AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO SocialWork ([Name],[Description],[IdIvaType],[IdLocationCountry],[IdLocationProvince],[IdLocationCity],[Address],[Phone],[Contact],[Visible])
			VALUES (@Name,@Description,@IdIvaType,@IdLocationCountry,@IdLocationProvince,@IdLocationCity,@Address,@Phone,@Contact,@Visible)
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
			UPDATE [dbo].[SocialWork] 
			SET 
			[Name] = @Name,
			[Description] = @Description,
			[IdIvaType]= @IdIvaType,
			[IdLocationCountry] = @IdLocationCountry,
			[IdLocationProvince] = @IdLocationProvince,
			[IdLocationCity] = @IdLocationCity,
			[Address] = @Address,
			[Phone] = @Phone,
			[Contact] = @Contact,
			[Visible] = @Visible
			WHERE [idSocialWork] = @idSocialWork
			COMMIT TRANSACTION
			RETURN @idSocialWork
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
			DELETE FROM [dbo].[SocialWork] WHERE [idSocialWork] = @idSocialWork
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
		SELECT [idSocialWork] AS 'Id', [Name] AS 'Value' 
		FROM [dbo].[SocialWork]
		WHERE 
		--[Address] = @Address 
		--AND [Name] = @Name
		[Visible] = @Visible
		ORDER BY [Description] ASC
	END
END

GO


