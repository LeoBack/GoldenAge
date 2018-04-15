USE [DEFAULT-04.MDF]
GO

/****** Object:  StoredProcedure [dbo].[spSpecialityProfessional-v1.0]    Script Date: 15/04/2018 13:23:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2017/10/31 19:22>
-- Description:	<Report [spSpecialityProfessional-v1.0]>
-- =============================================
CREATE PROCEDURE [dbo].[spSpecialityProfessional-v1.0] 
	-- Add the parameters for the stored procedure here
	@IdSpeciality int = 0,
	@Visible int = 1
	AS
	BEGIN
		if(@IdSpeciality!=0)
		Begin
			SELECT [P].[IdProfessional] AS 'Id', CONCAT([P].[LastName] ,', ',[P].[Name]) AS 'Value'  
			FROM Professional [P] INNER JOIN  ProfessionalSpeciality [Ps] on [P].IdProfessional=[Ps].IdProfessional
						  INNER JOIN  Specialty [S] on [Ps].IdSpeciality=[S].IdSpecialty
			WHERE IdSpeciality=@IdSpeciality  and [Ps].Visible=@Visible
			order by(2)
		end
		else
		begin
			SELECT [P].[IdProfessional] AS 'Id', CONCAT([P].[LastName] ,', ',[P].[Name]) AS 'Value' 
			FROM Professional [P]
			WHERE [P].Visible=@Visible
			order by(2)
		end
	END
	


GO


