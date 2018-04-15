USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmProfessional-v1.0]    Script Date: 15/04/2018 13:14:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAbmProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdProfessional int = 0,
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@ProfessionalRegistration varchar(50) = null,
	@idLocationCountry int = 0,
    @idLocationProvince int = 0,
    @idLocationCity int = 0,
	@Address varchar(50) = null,
	@Phone varchar(50) = null,
    @Mail varchar(50) = null,
	@User varchar(50) = null,
	@Password varchar(50) = null,
	@idPermission int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible]
		FROM [dbo].[Professional]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Professional])-- WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible]
		FROM [dbo].[Professional]
		WHERE [IdProfessional] = @IdProfessional --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Professional] WHERE [IdProfessional] = @IdProfessional) --AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Professional ([Name],[LastName],[ProfessionalRegistration],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Phone],[Mail],[User],[Password],[idPermission],[Visible])
			VALUES (@Name,@LastName,@ProfessionalRegistration,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Phone,@Mail,@User,@Password,@idPermission,@Visible)
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
			UPDATE [dbo].[Professional] 
			SET 
			[Name] = @Name,
		    [LastName] = @LastName,
			[ProfessionalRegistration] = @ProfessionalRegistration,
			[idLocationCountry] = @idLocationCountry,
			[idLocationProvince] = @idLocationProvince,
			[idLocationCity] = @idLocationCity,
			[Address] = @Address,
			[Phone] = @Phone,
			[Mail] = @Mail,
			[User] = @User,
			[Password] = @Password,
			[idPermission]=@idPermission,
			[Visible] = @Visible
			WHERE [IdProfessional] = @IdProfessional
			COMMIT TRANSACTION
			RETURN @IdProfessional
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
			DELETE FROM [dbo].[Professional] WHERE [IdProfessional] = @IdProfessional
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
		SELECT [IdProfessional] AS 'Id', [Name] AS 'Value' 
		FROM [dbo].[Professional]
		WHERE 
		[Visible] = @Visible
		ORDER BY [Name] ASC
	END
END


GO


