USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spSearchParent-v1.0]    Script Date: 15/04/2018 13:22:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Busca Parientes>
-- =============================================
CREATE PROCEDURE [dbo].[spSearchParent-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@IdTypeDocument int = 0,
	@NumberDocument int = 0,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	BEGIN
		SELECT [IdParent],[Name],[LastName],[IdTypeDocument],[NumberDocument],[Phone],[AlternativePhone],[Email],[idLocationCountry],[idLocationProvince],[idLocationCity],[Address],[Visible]
		FROM [dbo].[Parent]
		WHERE [IdTypeDocument] = @IdTypeDocument AND [NumberDocument] = @NumberDocument
		RETURN (SELECT COUNT(*) FROM [dbo].[Parent] WHERE [IdTypeDocument] = @IdTypeDocument AND [NumberDocument] = @NumberDocument)
	END
END
GO


