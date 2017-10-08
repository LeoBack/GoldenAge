USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spAbmParent-v1.0]    Script Date: 08/10/2017 18:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/09/09 10:05>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
ALTER PROCEDURE [dbo].[spAbmParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdParent int = 0,
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@IdTypeDocument int = 0,
	@NumberDocument int = 0,
	@Phone varchar(50) = null,
    @AlternativePhone varchar(50) = null,
	@Email varchar(50) = null,
	@IdLocationCountry int = 0,
    @IdLocationProvince int = 0,
    @IdLocationCity int = 0,
	@Address varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
		FROM [dbo].[Parent]
		--WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Parent]) --WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
		FROM [dbo].[Parent]
		WHERE [IdParent] = @IdParent --AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Parent] WHERE [IdParent] = @IdParent) --AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Parent ([Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible])
			VALUES (@Name,@LastName,@IdTypeDocument,@NumberDocument,@Phone,@AlternativePhone,@Email,@idLocationCountry,@idLocationProvince,@idLocationCity,@Address,@Visible)
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
			UPDATE [dbo].[Parent] 
			SET 
			[Name] = @Name,
		    [LastName] = @LastName,
			[IdTypeDocument] = @IdTypeDocument,
			[NumberDocument] = @NumberDocument,
			[Phone] = @Phone,
			[AlternativePhone] = @AlternativePhone,
			[Email] = @Email,
			[IdLocationCountry] = @IdLocationCountry,
			[IdLocationProvince] = @IdLocationProvince,
			[IdLocationCity] = @IdLocationCity,
			[Address] = @Address,
			[Visible] = @Visible
			WHERE [IdParent] = @IdParent
			COMMIT TRANSACTION
			RETURN @IdParent
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
			DELETE FROM [dbo].[Parent] WHERE [IdParent] = @IdParent
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
		SELECT [IdParent] AS 'Id', [Name] AS 'Value' 
		FROM [dbo].[Parent]
		WHERE [Address] = @Address 
		AND [Name] = @Name
		AND [Visible] = @Visible
		ORDER BY [Name] ASC
	END
END
