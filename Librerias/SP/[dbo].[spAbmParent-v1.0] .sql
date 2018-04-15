USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spAbmParent-v1.0]    Script Date: 15/04/2018 13:12:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/21 19:52>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm INT = 0,
	@IdParent INT = 0,
	@Name VARCHAR(50) = NULL,
	@LastName VARCHAR(50) = NULL,
	@IdTypeDocument INT = 0,
	@NumberDocument INT = 0,
	@Phone VARCHAR(50) = NULL,
    @AlternativePhone VARCHAR(50) = NULL,
	@Email VARCHAR(50) = NULL,
	@IdLocationCountry INT = 0,
    @IdLocationProvince INT = 0,
    @IdLocationCity INT = 0,
	@Address VARCHAR(50) = NULL,
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- Interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		IF @IdTypeDocument != 0 AND @NumberDocument != 0
		BEGIN
			SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
			FROM [dbo].[Parent]
			WHERE [IdTypeDocument] = @IdTypeDocument
			AND [NumberDocument] = @NumberDocument
			--AND [Visible] = @Visible
			RETURN (SELECT COUNT(*) FROM [dbo].[Parent] WHERE [IdTypeDocument] = @IdTypeDocument AND [NumberDocument] = @NumberDocument) --AND [Visible] = @Visible)
		END
		ELSE
		BEGIN
			SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
			FROM [dbo].[Parent]
			--WHERE [Visible] = @Visible 
			RETURN (SELECT COUNT(*) FROM [dbo].[Parent]) --WHERE [Visible] = @Visible)
		END
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
GO


