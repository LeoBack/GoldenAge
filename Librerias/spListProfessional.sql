USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spListProfessional-v1.0]    Script Date: 24/09/2017 07:11:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/09/16 17:36>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spListProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@Desde int=1,
	@Hasta int=1,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	 
	if(@Name='' and @LastName='')                                                            --00
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[Phone],[Visible]
		FROM [dbo].[Professional]
		--WHERE 
		--[Name] like +'%'+ @Name +'%' AND
		--[LastName] like +'%'+ @LastName +'%' AND 
		--[Visible] = @Visible
		Order by [Name]
	END
	
	if(@Name='' and @LastName!='')															--01                                                
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[Phone],[Visible]
		FROM [dbo].[Professional]
		WHERE 
		--[Name] like +'%'+ @Name +'%' AND
		[LastName] like +'%'+ @LastName +'%'  
		--[Visible] = @Visible
		Order by [Name]
	END 


	if(@Name!='' and @LastName='')															--10                                                
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[Phone],[Visible]
		FROM [dbo].[Professional]
		WHERE 
		[Name] like +'%'+ @Name +'%' 
		--[LastName] like +'%'+ @LastName +'%' AND 
		--[Visible] = @Visible
		Order by [Name]
	END
	
	if(@Name!='' and @LastName!='')															--11                                                
	BEGIN
		SELECT [IdProfessional],[Name],[LastName],[Phone],[Visible]
		FROM [dbo].[Professional]
		WHERE 
		[Name] like +'%'+ @Name +'%' AND
		[LastName] like +'%'+ @LastName +'%' --AND 
		--[Visible] = @Visible
		Order by [Name]
	END 
	 
	
END