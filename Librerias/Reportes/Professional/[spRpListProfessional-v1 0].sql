USE [C:\USERS\MARCOS\DOCUMENTS\GITHUB\GOLDENAGE\DATOS\DEFAULT.MDF]
GO
/****** Object:  StoredProcedure [dbo].[spRpListProfessional-v1.0]    Script Date: 28/10/2017 08:10:32 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marcos Carreras>
-- Create date: <2017/10/28 20:10>
-- Description:	<Report spRpListProfessional-v1.0>
-- =============================================
CREATE PROCEDURE [dbo].[spRpListProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50) = null,
	@LastName varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	 
	if(@Name='' and @LastName='')                                                            --00
	BEGIN
		SELECT Concat([Name],' ',[LastName])as 'Name', [ProfessionalRegistration] as'ProfessionalRegistration',
		[Phone] as'Phone', [Mail] as 'Mail'
		FROM [dbo].[Professional]
		WHERE 
		--[Name] like +'%'+ @Name +'%' AND
		--[LastName] like +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		Order by [Name]
	END
	
	if(@Name='' and @LastName!='')															--01                                                
	BEGIN
		SELECT Concat([Name],' ',[LastName])as 'Name', [ProfessionalRegistration] as'ProfessionalRegistration',
		[Phone] as'Phone', [Mail] as 'Mail'
		FROM [dbo].[Professional]
		WHERE 
		--[Name] like +'%'+ @Name +'%' AND
		[LastName] like +'%'+ @LastName +'%'  and
		[Visible] = @Visible
		Order by [Name]
	END 


	if(@Name!='' and @LastName='')															--10                                                
	BEGIN
		SELECT Concat([Name],' ',[LastName])as 'Name', [ProfessionalRegistration] as'ProfessionalRegistration',
		[Phone] as'Phone', [Mail] as 'Mail'
		FROM [dbo].[Professional]
		WHERE 
		[Name] like +'%'+ @Name +'%' and
		--[LastName] like +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		Order by [Name]
	END
	
	if(@Name!='' and @LastName!='')															--11                                                
	BEGIN
		SELECT Concat([Name],' ',[LastName])as 'Name', [ProfessionalRegistration] as'ProfessionalRegistration',
		[Phone] as'Phone', [Mail] as 'Mail'
		FROM [dbo].[Professional]
		WHERE 
		[Name] like +'%'+ @Name +'%' AND
		[LastName] like +'%'+ @LastName +'%' AND 
		[Visible] = @Visible
		Order by [Name]
	END 
	 
	
END