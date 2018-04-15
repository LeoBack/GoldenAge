USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spRpListProfessional-v1.0]    Script Date: 15/04/2018 13:20:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Report spRpListProfessional-v1.0>
-- =============================================
CREATE PROCEDURE [dbo].[spRpListProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50) = null,
	@LAStName VARCHAR(50) = null,
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	 
	IF(@Name = '' AND @LastName = '')                                                            --00
	BEGIN
		SELECT	CONCAT([LastName],', ', [Name]) AS 'Nombre', 
				[ProfessionalRegistration] AS 'N. Matricula',
				[Phone] AS 'Telefono', [Mail] AS 'Correo'
		FROM [dbo].[Professional]
		WHERE 
		--[Name] LIKE +'%'+ @Name +'%' AND
		--[LastName] LIKE +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		ORDER BY [Name]
	END
	
	IF(@Name = '' AND @LastName != '')															--01                                                
	BEGIN
		SELECT	CONCAT([LastName],', ', [Name]) AS 'Nombre', 
				[ProfessionalRegistration] AS 'N. Matricula',
				[Phone] AS 'Telefono', [Mail] AS 'Correo'
		FROM [dbo].[Professional]
		WHERE 
		--[Name] LIKE +'%'+ @Name +'%' AND
		[LastName] LIKE +'%'+ @LastName +'%'  AND
		[Visible] = @Visible
		ORDER BY [Name]
	END 


	IF(@Name != '' AND @LastName = '')															--10                                                
	BEGIN
		SELECT	CONCAT([LastName],', ', [Name]) AS 'Nombre', 
				[ProfessionalRegistration] AS 'N. Matricula',
				[Phone] AS 'Phone', [Mail] AS 'Correo'
		FROM [dbo].[Professional]
		WHERE 
		[Name] LIKE +'%'+ @Name +'%' AND
		--[LastName] LIKE +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		ORDER BY [Name]
	END
	
	IF(@Name != '' and @LastName != '')															--11                                                
	BEGIN
		SELECT	CONCAT([LastName],', ', [Name]) AS 'Nombre', 
				[ProfessionalRegistration] AS 'N. Matricula',
				[Phone] AS 'Telefono', [Mail] AS 'Correo'
		FROM [dbo].[Professional]
		WHERE 
		[Name] LIKE +'%'+ @Name +'%' AND
		[LastName] LIKE +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		ORDER BY [Name]
	END
END
GO


