-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/11/09 17:00>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[StringSex]
(
	@IntSex INT = 0
)
RETURNS VARCHAR(10)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @rVar VARCHAR(10)

	-- Add the T-SQL statements to compute the return value here
	IF (@IntSex = 1)
		SET @rVar = 'Masculino';
	ELSE
		SET @rVar = 'Femenino';

	-- Return the result of the function
	RETURN @rVar

END
GO