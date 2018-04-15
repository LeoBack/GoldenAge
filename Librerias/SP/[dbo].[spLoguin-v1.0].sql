USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spLoguin-v1.0]    Script Date: 15/04/2018 13:18:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 16:37>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spLoguin-v1.0] 
	-- Add the parameters for the stored procedure here
	@Status int = 1,  --> Session: 0 Cerrar - 1 Abrir
	@User varchar(50) = null,
	@Password varchar(50) = null,
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
				INSERT INTO [dbo].[Session] (IdProfessional, InitDate, EndDate) VALUES (@Id, GETDATE(), DATEADD(ss, 2, GETDATE()))
			END

			SELECT @Id
		END
		--ELSE
		--BEGIN
		--	UPDATE [dbo].[Session] SET EndDate = GETDATE() WHERE idProfessional 
		--END
	END
END


GO


