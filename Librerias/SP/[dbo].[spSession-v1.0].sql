USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spSession-v1.0]    Script Date: 15/04/2018 13:22:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 16:37>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
create PROCEDURE [dbo].[spSession-v1.0] 
	-- Add the parameters for the stored procedure here
	@Status int = 1,  --> Session: 1 Abrir - 2 IdProfecional - 3 Cerrar
	@User varchar(50) = null,
	@Password varchar(50) = null,
	@IdSession int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	BEGIN
	IF @Status = 1
		BEGIN
			DECLARE @Id INT

			SET @Id = (SELECT [IdProfessional] FROM [dbo].[Professional]
			WHERE [User] like @User 
			AND [Password] like @Password
			AND [Visible] = @Visible)

			IF @Id != 0
			BEGIN
				BEGIN TRANSACTION
				BEGIN TRY
					INSERT INTO [dbo].[Session] (IdProfessional, InitDate, EndDate) VALUES (@Id, GETDATE(), DATEADD(ss, 2, GETDATE()))
				COMMIT TRANSACTION
				RETURN @@identity
				END TRY
				BEGIN CATCH
				ROLLBACK TRANSACTION
					PRINT '[INSERT]. Se ha producido un error!'
					RETURN 0
				END CATCH
			END
			ELSE
			BEGIN
				RETURN 0
			END
		END
		ELSE IF @Status = 2
		BEGIN
			RETURN (SELECT idProfessional FROM [dbo].[Session] WHERE idSession = @IdSession)
		END
		ELSE IF @Status = 3
		BEGIN
			BEGIN TRANSACTION
			BEGIN TRY
				UPDATE [dbo].[Session] 
				SET EndDate = GETDATE() 
				WHERE idSession = @IdSession
				COMMIT TRANSACTION
				RETURN @IdSession
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				PRINT '[UPDATE]. Se ha producido un error!'
				RETURN 0
			END CATCH
		END
	END
END


GO


