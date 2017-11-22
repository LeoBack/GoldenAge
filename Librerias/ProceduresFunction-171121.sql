USE [TESIS11]
GO
/****** Object:  UserDefinedFunction [dbo].[CutCustomer]    Script Date: 21/11/2017 22:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/01/22>
-- Description:	<Devuelve el cliente desde un N° de Orden>
-- =============================================
CREATE FUNCTION [dbo].[CutCustomer] 
(
	-- Add the parameters for the function here
	@OrderNumber NVARCHAR(11)
)
RETURNS INT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Customer INT

	-- Add the T-SQL statements to compute the return value here
	SET @Customer = CONVERT (INT, SUBSTRING (@OrderNumber, 1, 4))

	-- Return the result of the function
	RETURN @Customer 

END




GO
/****** Object:  UserDefinedFunction [dbo].[CutNumber]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/01/22>
-- Description:	<Devuelve el Numero desde una Orden>
-- =============================================
CREATE FUNCTION [dbo].[CutNumber]
(
	-- Add the parameters for the function here
	@OrderNumber NVARCHAR(11)
)
RETURNS INT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Number INT

	-- Add the T-SQL statements to compute the return value here
	SET @Number = CONVERT (INT, SUBSTRING (@OrderNumber, 6, 11))

	-- Return the result of the function
	RETURN @Number 

END




GO
/****** Object:  UserDefinedFunction [dbo].[SetOrderNumber]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/01/22>
-- Description:	<Devuelve un Numero de Orden>
-- =============================================
CREATE FUNCTION [dbo].[SetOrderNumber]
(
	-- Add the parameters for the function here
	@idCustomer INT
)
RETURNS CHAR(11)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Number INT
	DECLARE @IdExist INT
	DECLARE @vCodeClient CHAR(4)
	DECLARE @vCodeWork CHAR(6)

	-- Add the T-SQL statements to compute the return value here
	-- CREA
	SET @IdExist = (SELECT MAX([dbo].[CutNumber]([OrderNumber])) FROM [dbo].[WorkOrderCode] 
	WHERE [dbo].[CutCustomer]([OrderNumber]) = @idCustomer)
	-- Existe? Existe ya un codigo generado por otro usuario
	--PRINT @IdExist
				
	IF  @IdExist IS NULL
	BEGIN 
		SET @Number = (SELECT MAX([dbo].[CutNumber]([OrderNumber]))+1 FROM [dbo].[WorkOrder]
		WHERE idCustomer = @idCustomer)
		-- Es nulo: Obtengo el ultimo Id insertado en [WorkOrder]
	END
	ELSE
		SET @Number = @IdExist+1
		-- Al Id existente en [WorkOrderCode] le sumo 1 apra que sea nuevo.
	--PRINT @Number
			
	IF @Number IS NULL
		SET @Number = 1;
		-- Resulta que no Hay Id para generar codigos por ende lo inicio desda aca.

	SET @vCodeClient = RIGHT(REPLICATE('0', 4)+ CAST(@idCustomer AS VARCHAR(4)), 4)
	SET @vCodeWork = RIGHT(REPLICATE('0', 6)+ CAST(@Number AS VARCHAR(6)), 6)

	-- Return the result of the function
	RETURN CONVERT(CHAR, CONCAT(@vCodeClient, '-', @vCodeWork))

END




GO
/****** Object:  StoredProcedure [dbo].[RptCountDevicesCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<TABLA DISPOSITIVOS PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptCountDevicesCustomer-v1.1]
	-- Add the parameters for the stored procedure here
	@idCustomer INT,
	@idDeviceState INT=0,
	@idDeviceType INT=0,
	@Visible INT=1
AS
BEGIN
	DECLARE @DeviceTotal INT
	DECLARE @DeviceShow INT

	IF (@idDeviceState = 0 AND @idDeviceType = 0)
	BEGIN
		SET @DeviceTotal = (SELECT COUNT ([D].[idDevice])
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] on [D].[idCustomer] = [C].[idCustomer]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer)

		SET @DeviceShow = (SELECT COUNT ([D].[idDevice])
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] on [D].[idCustomer] = [C].[idCustomer]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer)
	END
	ELSE IF (@idDeviceState != 0 AND @idDeviceType = 0)
	BEGIN
		SET @DeviceTotal = (SELECT COUNT ([D].[idDevice])
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] on [D].[idCustomer] = [C].[idCustomer]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
			  AND [D].idDeviceState = @idDeviceState)
			

		SET @DeviceShow = (SELECT COUNT ([D].[idDevice])
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] on [D].[idCustomer] = [C].[idCustomer]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
		AND [D].idDeviceState= @idDeviceState)
	END
	ELSE IF (@idDeviceState = 0 AND @idDeviceType != 0)
	BEGIN
		SET @DeviceTotal = (SELECT COUNT ([D].[idDevice])
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] on [D].[idCustomer] = [C].[idCustomer]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
			  AND [D].idDeviceType = @idDeviceType)
			

		SET @DeviceShow = (SELECT COUNT ([D].[idDevice])
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] on [D].[idCustomer] = [C].[idCustomer]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
		AND [D].idDeviceType = @idDeviceType)
	END
	ELSE
	BEGIN
		SET @DeviceTotal = (SELECT COUNT ([D].[idDevice])
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] on [D].[idCustomer] = [C].[idCustomer]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
		AND [D].idDeviceType = @idDeviceType AND [D].idDeviceState = @idDeviceState)
			

		SET @DeviceShow = (SELECT COUNT ([D].[idDevice])
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] on [D].[idCustomer] = [C].[idCustomer]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
		AND [D].idDeviceType = @idDeviceType AND [D].idDeviceState = @idDeviceState)
	END
	
	SELECT @DeviceTotal AS 'AllDevices', @DeviceShow AS 'DevicesShown'
END












GO
/****** Object:  StoredProcedure [dbo].[RptCustomerData-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<TABLA CUSTOMER PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptCustomerData-v1.0]
	-- Add the parameters for the stored procedure here
	@idCustomer int=0,
	@Visible int=1
AS
BEGIN
	SELECT [C].[BusinessName] AS 'BusinessName', 
		   CONCAT([LY].[Description],' (',[LP].[Description],' ',[LC].[Description],') - ',[C].[Home])AS 'Localitation', 
		   [C].[Cuit] AS 'Cuit', 
		   [CT].[Description] AS 'CustomerType', 
		   [I].[Description] AS 'IvaType' 
	FROM [Customer] AS [C] 
	INNER JOIN  [CustomerType] AS [CT] ON [C].[idCustomerType] = [CT].[idCustomerType]
	INNER JOIN [IvaType] AS [I] ON [C].[idIvaType] = [I].[idIvaType]
	INNER JOIN [LocationCountry] AS [LC] ON [C].[idLocationCountry] = [LC].[idLocationCountry] 
	INNER JOIN [LocationProvince] AS [LP] ON [C].[idLocationProvince] = [LP].[idLocationProvince] 
	INNER JOIN [LocationCity] AS [LY] ON [C].[idLocationCity] = [LY].[idLocationCity] 
	WHERE [C].[Visible] = @Visible AND [C].[idCustomer] = @idCustomer
END















GO
/****** Object:  StoredProcedure [dbo].[RptDeviceAccount-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 17:09>
-- DescrModeltion:	<ONLY DEVICE PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptDeviceAccount-v1.0]
	-- Add the parameters for the stored procedure here
	@idDevice int=0,
	@Visible int=1
AS
BEGIN
	SELECT [A].[Name] AS 'AccountName', 
	--CONCAT([A].[idAccount], '-', [A].[Name]) AS 'AccountName', 
	[A].[Password] AS 'Password',
	[A].[Description] AS 'Description'
	FROM Account AS [A]
	INNER JOIN DeviceAccount AS [DA] ON [DA].[idAccount] = [A].[idAccount]
	INNER JOIN Device AS [D] ON [D].[idDevice] = [DA].[idDevice]
	WHERE [D].[idDevice] = @idDevice
	AND [D].[Visible] = @Visible
END














GO
/****** Object:  StoredProcedure [dbo].[RptDeviceHardware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 17:10>
-- DescrModeltion:	<ONLY PURCHASE PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptDeviceHardware-v1.0]
	-- Add the parameters for the stored procedure here
	@idDevice int=0,
	@Visible int=1
AS
BEGIN
	SELECT [H].[Component] AS 'DeviceHardware', 
	--CONCAT([H].[idHardware], '-', [H].[Component] ) AS 'DeviceHardware', 
	[H].[Description] AS 'Description'
	FROM Hardware AS [H]
	INNER JOIN DeviceHardware AS [Dh] ON [Dh].[idHardware] = [H].[idHardware]
	INNER JOIN Device AS [D] ON [D].[idDevice] = [Dh].[idDevice]
	WHERE [D].[idDevice] = @idDevice
	AND [D].[Visible] = @Visible
END












GO
/****** Object:  StoredProcedure [dbo].[RptDevicesCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<TABLA DISPOSITIVOS PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptDevicesCustomer-v1.1]
	-- Add the parameters for the stored procedure here
		@idCustomer INT,
		@idDeviceType INT=0,
		@idDeviceState INT=0,
		@Visible INT=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (@idDeviceState = 0 AND @idDeviceType = 0)
	BEGIN
		SELECT 
		CONCAT ([DTY].[Description], ' - ', [D].Name) AS 'Name', 
		[DS].[Description] AS 'DeviceState',
		[D].[Ip] AS 'Ip',
		[D].[Dns] AS'Dns',
		[D].[Area] AS'Area',
		[D].[Post] AS 'Post',
		FORMAT([D].[DischargeDate], 'dd/MM/yyyy') AS 'DischargeDate',
		CONCAT ([LY].[Description],' (', [LP].[Description], ', ', [LC].[Description], ')') as 'Localitation'
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] ON [D].[idCustomer] = [C].idCustomer
		INNER JOIN [DeviceType] AS [DTY] ON [D].[idDeviceType]= [DTY].[idDeviceType]
		INNER JOIN [DeviceState] AS [DS] ON [D].[idDeviceState] = [DS].[idDeviceState]
		INNER JOIN [LocationCountry] AS [LC] ON [D].[IdLocationCountry] = [LC].[idLocationCountry]
		INNER JOIN [LocationProvince] AS [LP] ON [D].[IdLocationProvince] = [LP].[idLocationProvince]
		INNER JOIN [LocationCity] AS [LY] ON [D].[IdLocationCity] = [LY].[idLocationCity]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
		ORDER BY 1 ASC
	END
	ELSE IF (@idDeviceState != 0 AND @idDeviceType = 0)
	BEGIN
		SELECT 
		CONCAT ([DTY].[Description], ' - ', [D].Name) AS 'Name', 
		[DS].[Description] AS 'DeviceState',
		[D].[Ip] AS 'Ip',
		[D].[Dns] AS'Dns',
		[D].[Area] AS'Area',
		[D].[Post] AS 'Post',
		FORMAT([D].[DischargeDate], 'dd/MM/yyyy') AS 'DischargeDate',
		CONCAT ([LY].[Description],' (', [LP].[Description], ', ', [LC].[Description], ')') as 'Localitation'
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] ON [D].[idCustomer] = [C].idCustomer
		INNER JOIN [DeviceType] AS [DTY] ON [D].[idDeviceType]= [DTY].[idDeviceType]
		INNER JOIN [DeviceState] AS [DS] ON [D].[idDeviceState] = [DS].[idDeviceState]
		INNER JOIN [LocationCountry] AS [LC] ON [D].[IdLocationCountry] = [LC].[idLocationCountry]
		INNER JOIN [LocationProvince] AS [LP] ON [D].[IdLocationProvince] = [LP].[idLocationProvince]
		INNER JOIN [LocationCity] AS [LY] ON [D].[IdLocationCity] = [LY].[idLocationCity]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
		AND [D].[idDeviceState] = @idDeviceState
		ORDER BY 1 ASC
	END
	ELSE IF (@idDeviceState = 0 AND @idDeviceType != 0)
	BEGIN
		SELECT 
		CONCAT ([DTY].[Description], ' - ', [D].Name) AS 'Name', 
		[DS].[Description] AS 'DeviceState',
		[D].[Ip] AS 'Ip',
		[D].[Dns] AS'Dns',
		[D].[Area] AS'Area',
		[D].[Post] AS 'Post',
		FORMAT([D].[DischargeDate], 'dd/MM/yyyy') AS 'DischargeDate',
		CONCAT ([LY].[Description],' (', [LP].[Description], ', ', [LC].[Description], ')') as 'Localitation'
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] ON [D].[idCustomer] = [C].idCustomer
		INNER JOIN [DeviceType] AS [DTY] ON [D].[idDeviceType]= [DTY].[idDeviceType]
		INNER JOIN [DeviceState] AS [DS] ON [D].[idDeviceState] = [DS].[idDeviceState]
		INNER JOIN [LocationCountry] AS [LC] ON [D].[IdLocationCountry] = [LC].[idLocationCountry]
		INNER JOIN [LocationProvince] AS [LP] ON [D].[IdLocationProvince] = [LP].[idLocationProvince]
		INNER JOIN [LocationCity] AS [LY] ON [D].[IdLocationCity] = [LY].[idLocationCity]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
		AND [D].[idDeviceType] = @idDeviceType
		ORDER BY 1 ASC
	END
	ELSE
	BEGIN
		SELECT 
		CONCAT ([DTY].[Description], ' - ', [D].Name) AS 'Name', 
		[DS].[Description] AS 'DeviceState',
		[D].[Ip] AS 'Ip',
		[D].[Dns] AS'Dns',
		[D].[Area] AS'Area',
		[D].[Post] AS 'Post',
		FORMAT([D].[DischargeDate], 'dd/MM/yyyy') AS 'DischargeDate',
		CONCAT ([LY].[Description],' (', [LP].[Description], ', ', [LC].[Description], ')') as 'Localitation'
		FROM  [Device] AS [D] 
		INNER JOIN [Customer] AS [C] ON [D].[idCustomer] = [C].idCustomer
		INNER JOIN [DeviceType] AS [DTY] ON [D].[idDeviceType]= [DTY].[idDeviceType]
		INNER JOIN [DeviceState] AS [DS] ON [D].[idDeviceState] = [DS].[idDeviceState]
		INNER JOIN [LocationCountry] AS [LC] ON [D].[IdLocationCountry] = [LC].[idLocationCountry]
		INNER JOIN [LocationProvince] AS [LP] ON [D].[IdLocationProvince] = [LP].[idLocationProvince]
		INNER JOIN [LocationCity] AS [LY] ON [D].[IdLocationCity] = [LY].[idLocationCity]
		WHERE [D].[Visible] = @Visible AND [D].[idCustomer] = @idCustomer
		AND [D].[idDeviceState] = @idDeviceState
		AND [D].[idDeviceType] = @idDeviceType
		ORDER BY 1 ASC
	END
END












GO
/****** Object:  StoredProcedure [dbo].[RptDeviceSoftware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 17:11>
-- DescrModeltion:	<ONLY PURCHASE PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptDeviceSoftware-v1.0]
	-- Add the parameters for the stored procedure here
	@idDevice int=0,
	@Visible int=1
AS
BEGIN
	SELECT [S].[Name] AS 'DeviceSoftware', 
	--CONCAT([S].[idSoftware],'-', [S].[Name]) AS 'DeviceSoftware', 
	[S].[Description] as 'Description'
	FROM Software AS [S]
	INNER JOIN DeviceSoftware AS [Ds] ON [Ds].[idSoftware] = [S].[idSoftware]
	INNER JOIN Device AS [D] ON [D].[idDevice] = [Ds].[idDevice]
	WHERE [D].[idDevice] = @idDevice
	AND [D].[Visible] = @Visible
END













GO
/****** Object:  StoredProcedure [dbo].[RptDevice-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<TABLA DISPOSITIVOS PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptDevice-v1.1]
	-- Add the parameters for the stored procedure here
	@idDevice int=0,
	@Visible int=1
AS
BEGIN
	SELECT CONCAT ([DTY].[Description], ' - ', [D].Name) AS 'Name', 
	[DS].[Description] AS 'DeviceState',
	[D].[Ip] AS 'Ip',
	[D].[Dns] AS'Dns',
	[D].[Gateway] AS'Gateway',
	[D].[Area] AS'Area',
	[D].[Post] AS 'Post',
	[D].[DischargeDate] AS 'DischargeDate',
	CONCAT ([LY].[Description],' (', [LP].[Description], ', ', [LC].[Description], ')') as 'Localitation'
	FROM  [Device] AS [D] 
	INNER JOIN [DeviceType] AS [DTY] ON [D].[idDeviceType]= [DTY].[idDeviceType]
	INNER JOIN [DeviceState] AS [DS] ON [D].[idDeviceState] = [DS].[idDeviceState]
	INNER JOIN [LocationCountry] AS [LC] ON [D].[IdLocationCountry] = [LC].[idLocationCountry]
	INNER JOIN [LocationProvince] AS [LP] ON [D].[IdLocationProvince] = [LP].[idLocationProvince]
	INNER JOIN [LocationCity] AS [LY] ON [D].[IdLocationCity] = [LY].[idLocationCity]
	WHERE [D].[idDevice] = @idDevice
END































GO
/****** Object:  StoredProcedure [dbo].[RptPurchaseCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<TABLA PURCHASE PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptPurchaseCustomer-v1.1]
	-- Add the parameters for the stored procedure here
	@idCustomer INT,
	@idPurchaseRequestState INT=0,
	@Visible INT=1

AS
IF (@idPurchaseRequestState = 0 )
BEGIN
	SELECT [P].[Reason] AS 'Reason',
	[P].[Budget] AS 'Budget' ,
	FORMAT([P].[Date], 'dd/MM/yyyy') AS 'Date',
	[S].[Description] AS 'Description'
	FROM PurchaseRequest AS [P]
	INNER JOIN Customer AS [C] ON [C].[idCustomer] = [P].[idCustomer]
	INNER JOIN PurchaseRequestState [S] ON [S].[idPurchaseRequestState] = [P].[idPurchaseRequestState]
	WHERE [P].[Visible] = @Visible AND [P].[idCustomer] = @idCustomer
	ORDER BY 1 ASC
END
ELSE
	BEGIN
		SELECT [P].[Reason] AS 'Reason',
		[P].[Budget] AS 'Budget' ,
		FORMAT([P].[Date], 'dd/MM/yyyy') AS 'Date',
		[S].[Description] AS 'Description'
		FROM PurchaseRequest AS [P]
		INNER JOIN Customer AS [C] ON [C].[idCustomer] = [P].[idCustomer]
		INNER JOIN PurchaseRequestState [S] ON [S].[idPurchaseRequestState] = [P].[idPurchaseRequestState]
		WHERE [P].[Visible] = @Visible AND [P].[idCustomer] = @idCustomer
		AND [P].[idPurchaseRequestState] = @idPurchaseRequestState
		ORDER BY 1 ASC
	END













GO
/****** Object:  StoredProcedure [dbo].[RptPurchase-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<ONLY PURCHASE PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptPurchase-v1.0]
	-- Add the parameters for the stored procedure here
	@idPurchaseRequest int=0,
	@Visible int=1
AS
BEGIN
	SELECT [P].[Reason] AS 'Reason',
	[P].[Budget] AS 'Budget' ,
	[P].[Date] AS 'Date', 
	[S].[Description] AS 'Description'
	FROM PurchaseRequest AS [P]
	INNER JOIN Customer AS [C] ON [C].[idCustomer] = [P].[idCustomer]
	INNER JOIN PurchaseRequestState AS [S] ON [S].[idPurchaseRequestState] = [P].[idPurchaseRequestState]
	WHERE [P].[Visible] = @Visible AND [P].[idPurchaseRequest] = @idPurchaseRequest
END














GO
/****** Object:  StoredProcedure [dbo].[RptRaeCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<TABLA RAE PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptRaeCustomer-v1.1]
	-- Add the parameters for the stored procedure here
	@idCustomer INT,
	@idDevice INT=0,
	@idRaeRequestState INT=0,
	@Visible int=1
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (@idDevice = 0 AND @idRaeRequestState = 0)
	BEGIN
		SELECT [D].[Name] AS 'NameDevice',
		--CONCAT ([D].[idDevice] ,' ',[D].[Name]) AS 'NameDevice',
		[R].[Reason] AS 'Reason',
		[S].[Description] AS 'Description',
		FORMAT([R].[Date], 'dd/MM/yyyy') AS 'Date'
		FROM RaeRequest AS [R]
		INNER JOIN Customer AS [C] ON [C].[idCustomer] = [R].[idCustomer]
		INNER JOIN Device AS [D] ON [D].[idDevice] = [R].[idDevice]
		INNER JOIN RaeRequestState AS [S] ON [R].[idRaeRequestState] = [S].[idRaeRequestState]
		WHERE [R].[Visible] = @Visible AND [R].[idCustomer] = @idCustomer
		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice != 0 AND @idRaeRequestState = 0)
	BEGIN
		SELECT [D].[Name] AS 'NameDevice', 
			--CONCAT ([D].[idDevice] ,' ',[D].[Name]) AS 'NameDevice',
			[R].[Reason] AS 'Reason',
			[S].[Description] AS 'Description',
			FORMAT([R].[Date], 'dd/MM/yyyy') AS 'Date'
			FROM RaeRequest AS [R]
			INNER JOIN Customer AS [C] ON [C].[idCustomer] = [R].[idCustomer]
			INNER JOIN Device AS [D] ON [D].[idDevice] = [R].[idDevice]
			INNER JOIN RaeRequestState AS [S] ON [R].[idRaeRequestState] = [S].[idRaeRequestState]
			WHERE [R].[Visible] = @Visible AND [R].[idCustomer] = @idCustomer
			AND [R].[idDevice] = @idDevice
		 ORDER BY 1 ASC
	END
	ELSE IF (@idDevice = 0 AND @idRaeRequestState != 0)
	BEGIN
		SELECT [D].[Name] AS 'NameDevice', 
		    --CONCAT ([D].[idDevice] ,' ',[D].[Name]) AS 'NameDevice',
			[R].[Reason] AS 'Reason',
			[S].[Description] AS 'Description',
			FORMAT([R].[Date], 'dd/MM/yyyy') AS 'Date'
			FROM RaeRequest AS [R]
			INNER JOIN Customer AS [C] ON [C].[idCustomer] = [R].[idCustomer]
			INNER JOIN Device AS [D] ON [D].[idDevice] = [R].[idDevice]
			INNER JOIN RaeRequestState AS [S] ON [R].[idRaeRequestState] = [S].[idRaeRequestState]
			WHERE [R].[Visible] = @Visible AND [R].[idCustomer] = @idCustomer
			AND [R].[idRaeRequestState] = @idRaeRequestState
		ORDER BY 1 ASC
	END
	ELSE
	BEGIN
		SELECT [D].[Name] AS 'NameDevice',
		--CONCAT ([D].[idDevice] ,' ',[D].[Name]) AS 'NameDevice',
		[R].[Reason] AS 'Reason',
		[S].[Description] AS 'Description',
		FORMAT([R].[Date], 'dd/MM/yyyy') AS 'Date'
		FROM RaeRequest AS [R]
		INNER JOIN Customer AS [C] ON [C].[idCustomer] = [R].[idCustomer]
		INNER JOIN Device AS [D] ON [D].[idDevice] = [R].[idDevice]
		INNER JOIN RaeRequestState AS [S] ON [R].[idRaeRequestState] = [S].[idRaeRequestState]
		WHERE [R].[Visible] = @Visible AND [R].[idCustomer] = @idCustomer
		AND [R].[idDevice] = @idDevice
		AND [R].[idRaeRequestState] = @idRaeRequestState
		ORDER BY 1 ASC
	END
END














GO
/****** Object:  StoredProcedure [dbo].[RptRae-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<Only RAE PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptRae-v1.0]
	-- Add the parameters for the stored procedure here
	@idRaeRequest int=0,
	@Visible int=1
AS
BEGIN
	SELECT [D].Name AS 'NameDevice',
	--CONCAT ([D].idDevice ,' ',[D].Name) AS 'NameDevice',
	[R].Reason AS'Reason',
	[S].[Description] AS'Description',
	[R].[Date] AS 'Date'
	FROM RaeRequest AS [R]
	INNER JOIN Customer  AS [C] ON [C].[idCustomer] = [R].[idCustomer]
	INNER JOIN Device AS [D] ON [D].[idDevice] = [R].[idDevice]
	INNER JOIN RaeRequestState AS [S] ON [R].[idRaeRequestState] = [S].[idRaeRequestState]
	WHERE [R].[Visible] = @Visible AND [R].[idRaeRequest] = @idRaeRequest
END















GO
/****** Object:  StoredProcedure [dbo].[RptScheduledTasksCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<TABLA CUSTOMER PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptScheduledTasksCustomer-v1.1]
	@idCustomer INT,
	@idDevice INT=0,
	@idHomeworkType INT=0,
	@Visible INT=1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (@idDevice = 0 AND @idHomeworkType = 0)
	BEGIN
		SELECT 
		[sT].[Description] AS 'NameScheduledTasks',
		[D].Name AS 'NameDevice',
		[hT].[Description] AS 'NameHomeworkType',
		FORMAT([sT].[StartDate],'dd/MM/yyyy') AS 'StartDate',
		FORMAT([sT].[EndDate],'dd/MM/yyyy') AS'EndDate',
		CONCAT ([sT].[Timework], ' Hs') AS 'Timework'
		FROM ScheduledTasks AS sT
		INNER JOIN Device AS D ON [d].[idDevice] = [sT].[idDevice]
		INNER JOIN HomeworkType AS hT ON [hT].[idHomeworkType] = [sT].[idHomeworkType]
		WHERE [sT].[Visible] = @Visible AND [sT].[idCustomer] = @idCustomer
		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice != 0 AND @idHomeworkType = 0)
	BEGIN
		SELECT 
		[sT].[Description] AS 'NameScheduledTasks',
		[D].Name AS 'NameDevice',
		[hT].[Description] AS 'NameHomeworkType',
		FORMAT([sT].[StartDate],'dd/MM/yyyy') AS 'StartDate',
		FORMAT([sT].[EndDate],'dd/MM/yyyy') AS'EndDate',
		CONCAT ([sT].[Timework], ' Hs') AS 'Timework'
		FROM ScheduledTasks AS sT
		INNER JOIN Device AS D ON [d].[idDevice] = [sT].[idDevice]
		INNER JOIN HomeworkType AS hT ON [hT].[idHomeworkType] = [sT].[idHomeworkType]
		WHERE [sT].[Visible] = @Visible AND [sT].[idCustomer] = @idCustomer		
		AND [sT].[idDevice] = @idDevice

		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice = 0 AND @idHomeworkType != 0)
	BEGIN
		SELECT 
		[sT].[Description] AS 'NameScheduledTasks',
		[D].Name AS 'NameDevice',
		[hT].[Description] AS 'NameHomeworkType',
		FORMAT([sT].[StartDate],'dd/MM/yyyy') AS 'StartDate',
		FORMAT([sT].[EndDate],'dd/MM/yyyy') AS'EndDate',
		CONCAT ([sT].[Timework], ' Hs') AS 'Timework'
		FROM ScheduledTasks AS sT
		INNER JOIN Device AS D ON [d].[idDevice] = [sT].[idDevice]
		INNER JOIN HomeworkType AS hT ON [hT].[idHomeworkType] = [sT].[idHomeworkType]
		WHERE [sT].[Visible] = @Visible AND [sT].[idCustomer] = @idCustomer		
		AND [sT].[idHomeworkType] = @idHomeworkType
		ORDER BY 1 ASC
	END
	ELSE
	BEGIN
	SELECT 
		[sT].[Description] AS 'NameScheduledTasks',
		[D].Name AS 'NameDevice',
		[hT].[Description] AS 'NameHomeworkType',
		FORMAT([sT].[StartDate],'dd/MM/yyyy') AS 'StartDate',
		FORMAT([sT].[EndDate],'dd/MM/yyyy') AS'EndDate',
		CONCAT ([sT].[Timework], ' Hs') AS 'Timework'
		FROM ScheduledTasks AS sT
		INNER JOIN Device AS D ON [d].[idDevice] = [sT].[idDevice]
		INNER JOIN HomeworkType AS hT ON [hT].[idHomeworkType] = [sT].[idHomeworkType]
		WHERE [sT].[Visible] = @Visible AND [sT].[idCustomer] = @idCustomer		
		AND [sT].[idDevice] = @idDevice 
		AND [sT].[idHomeworkType] = @idHomeworkType
		ORDER BY 1 ASC
	END
END












GO
/****** Object:  StoredProcedure [dbo].[RptScheduledTasks-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/01 09:25>
-- DescrModeltion:	<TABLA CUSTOMER PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptScheduledTasks-v1.0]
	-- Add the parameters for the stored procedure here
	@idScheduledTasks int=0,
	@Visible int=1
AS
BEGIN
	SELECT 
	--CONCAT([sT].[idScheduledTasks], '-', [sT].[Description]) AS 'NameScheduledTasks',
	--CONCAT([D].[idDevice], '-', [D].[Name]) AS 'NameDevice',
	--CONCAT([hT].[idHomeworkType], '-', [hT].[Description]) AS 'NameHomeworkType',
	[sT].[Description] AS 'NameScheduledTasks',
	[D].[Name] AS 'NameDevice',
	[hT].[Description] AS 'NameHomeworkType',
	FORMAT([sT].[StartDate], 'dd/MM/yyyy') AS 'StartDate',
	FORMAT([sT].[EndDate], 'dd/MM/yyyy') AS 'EndDate',
	[sT].[Timework] AS 'Timework'
	FROM ScheduledTasks sT
	INNER JOIN Device AS D ON [D].[idDevice] = [sT].[idDevice]
	INNER JOIN HomeworkType AS hT ON [hT].[idHomeworkType] = [sT].[idHomeworkType]
	WHERE [sT].[Visible] = @Visible
	AND [sT].[idScheduledTasks] = @idScheduledTasks
END













GO
/****** Object:  StoredProcedure [dbo].[RptWorkOrderCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 16:57>
-- DescrModeltion:	<TABLA WORKORDER PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptWorkOrderCustomer-v1.1]
	-- Add the parameters for the stored procedure here
@idCustomer INT,
	@idDevice INT=0,
	@idTechnical INT=0,
	@Visible INT=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (@idDevice = 0 AND @idTechnical = 0)
	BEGIN
		SELECT 
		--CONCAT([D].[idDevice],' ',[D].[Name]) AS'NameDevice',
		[D].[Name] AS'NameDevice',
		CONCAT([P].[Name],' ',[P].[LastName]) AS 'Technical',
		[S].[Description] AS 'State',
		[O].[OrderNumber] AS'OrderNumber',
		FORMAT([O].[StartDate],'dd/MM/yyyy') AS'StartDate',
		FORMAT([O].[EndDate],'dd/MM/yyyy') AS'EndDate',
		[O].[DescriptiON] AS'DescriptiON'
		FROM WorkOrder AS [O]
		INNER JOIN Device AS [D] ON [D].[idDevice] = [O].[idDevice]
		INNER JOIN Person AS [P] ON [P].[idPerson] = [O].[idTechnical] 
		INNER JOIN WorkOrderState AS [S] ON [S].[idWorkOrderState] = [O].[idWorkOrderState]
		WHERE [O].[Visible] = @Visible AND [O].[idCustomer] = @idCustomer
		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice != 0 AND @idTechnical = 0)
	BEGIN
		SELECT 
		--CONCAT([D].[idDevice],' ',[D].[Name]) AS'NameDevice',
		[D].[Name] AS'NameDevice',
		CONCAT([P].[Name],' ',[P].[LastName]) AS 'Technical',
		[S].[Description] AS 'State',
		[O].[OrderNumber] AS'OrderNumber',
		FORMAT([O].[StartDate],'dd/MM/yyyy') AS'StartDate',
		FORMAT([O].[EndDate],'dd/MM/yyyy') AS'EndDate',
		[O].[DescriptiON] AS'DescriptiON'
		FROM WorkOrder AS [O]
		INNER JOIN Device AS [D] ON [D].[idDevice] = [O].[idDevice]
		INNER JOIN Person AS [P] ON [P].[idPerson] = [O].[idTechnical] 
		INNER JOIN WorkOrderState AS [S] ON [S].[idWorkOrderState] = [O].[idWorkOrderState]
		WHERE [O].[Visible] = @Visible AND [O].[idCustomer] = @idCustomer
		AND [O].[idDevice] = @idDevice
		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice = 0 AND @idTechnical != 0)
	BEGIN
		SELECT 
		--CONCAT([D].[idDevice],' ',[D].[Name]) AS'NameDevice',
		[D].[Name] AS'NameDevice',
		CONCAT([P].[Name],' ',[P].[LastName]) AS 'Technical',
		[S].[Description] AS 'State',
		[O].[OrderNumber] AS'OrderNumber',
		FORMAT([O].[StartDate],'dd/MM/yyyy') AS'StartDate',
		FORMAT([O].[EndDate],'dd/MM/yyyy') AS'EndDate',
		[O].[DescriptiON] AS'DescriptiON'
		FROM WorkOrder AS [O]
		INNER JOIN Device AS [D] ON [D].[idDevice] = [O].[idDevice]
		INNER JOIN Person AS [P] ON [P].[idPerson] = [O].[idTechnical] 
		INNER JOIN WorkOrderState AS [S] ON [S].[idWorkOrderState] = [O].[idWorkOrderState]
		WHERE [O].[Visible] = @Visible AND [O].[idCustomer] = @idCustomer
		AND [O].[idTechnical] = @idTechnical
		ORDER BY 1 ASC
	END
	ELSE
	BEGIN
		SELECT 
		--CONCAT([D].[idDevice],' ',[D].[Name]) AS'NameDevice',
		[D].[Name] AS'NameDevice',
		CONCAT([P].[Name],' ',[P].[LastName]) AS 'Technical',
		[S].[Description] AS 'State',
		[O].[OrderNumber] AS'OrderNumber',
		FORMAT([O].[StartDate],'dd/MM/yyyy') AS'StartDate',
		FORMAT([O].[EndDate],'dd/MM/yyyy') AS'EndDate',
		[O].[DescriptiON] AS'DescriptiON'
		FROM WorkOrder AS [O]
		INNER JOIN Device AS [D] ON [D].[idDevice] = [O].[idDevice]
		INNER JOIN Person AS [P] ON [P].[idPerson] = [O].[idTechnical] 
		INNER JOIN WorkOrderState AS [S] ON [S].[idWorkOrderState] = [O].[idWorkOrderState]
		WHERE [O].[Visible] = @Visible AND [O].[idCustomer] = @idCustomer
		AND [O].[idDevice] = @idDevice 
		AND [O].[idTechnical] = @idTechnical
		ORDER BY 1 ASC
	END
END












GO
/****** Object:  StoredProcedure [dbo].[RptWorkOrder-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 16:53>
-- DescrModeltion:	<TABLA WORKORDER PARA REPORT>
-- =============================================
CREATE PROCEDURE [dbo].[RptWorkOrder-v1.0]
	-- Add the parameters for the stored procedure here
	@idWorkOrder int=0,
	@Visible int=1
AS
BEGIN
SELECT 
	--CONCAT([D].idDevice,' ',[D].Name) AS'NameDevice',
	[D].Name AS'NameDevice',
	CONCAT([P].Name,' ',[P].LastName) AS 'Technical',
	[S].[Description] AS 'State',
	[O].[OrderNumber] AS'OrderNumber',
	[O].[StartDate] AS'StartDate',
	[O].[EndDate] AS'EndDate',
	[O].[Description] AS'Description'
	FROM WorkOrder AS [O]
	INNER JOIN Device AS [D] on [D].[idDevice] = [O].[idDevice]
	INNER JOIN Person AS [P] on [P].[idPerson] = [O].[idTechnical] 
	INNER JOIN WorkOrderState AS [S] on [S].[idWorkOrderState] = [O].[idWorkOrderState]
	WHERE [O].[Visible] = @Visible AND [O].[idWorkOrder] = @idWorkOrder
END














GO
/****** Object:  StoredProcedure [dbo].[spAbmAccount-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/4 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmAccount-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idAccount int=0,
	@idCustomer INT = 0,
	@MultiDevice int=0,
	@Name varchar(50)=null,
	@Password varchar(50)=null,
	@Description varchar(50)=null,
	@Visible int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idAccount],[idCustomer],[Name],[Password],[Visible],[Description],[MultiDevice]
		FROM [dbo].[Account]
		WHERE [Visible]=@Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Account] WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idAccount],[idCustomer],[Name],[Password],[Visible],[Description],[MultiDevice]
		FROM [dbo].[Account]
		WHERE [idAccount] = @idAccount 
		AND [Visible] = @Visible 
		AND [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[Account] 
				WHERE [idAccount] = @idAccount 
				AND [Visible] = @Visible 
				AND [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Account] ([idCustomer],[Name],[Password],[Visible],[Description],[MultiDevice])
			VALUES (@idCustomer,@Name,@Password,@Visible,@Description,@MultiDevice)
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
			UPDATE [dbo].[Account] 
			SET 
			[Name] = @Name,
			[idCustomer] = @idCustomer,
			[Password] = @Password,
			[Visible] = @Visible,
			[Description] = @Description,
			[MultiDevice] = @MultiDevice
			WHERE [idAccount] = @idAccount
			COMMIT TRANSACTION
			RETURN @idAccount
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
			DELETE FROM [dbo].[Account] WHERE [idAccount] = @idAccount
			COMMIT TRANSACTION
			RETURN @idAccount
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 5
	BEGIN
	SELECT [idAccount] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[Account]
	WHERE [Visible] = @Visible
	AND [idCustomer] = @idCustomer
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmCustomerPerson-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmCustomerPerson-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idCustomerPerson int=0,
	@idCustomer int=1,
	@idPerson int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idCustomerPerson],[idCustomer],[idPerson]
		FROM [dbo].[CustomerPerson] 
		WHERE [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[CustomerPerson] WHERE [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idCustomerPerson],[idCustomer],[idPerson]
		FROM [dbo].[CustomerPerson]
		WHERE [idCustomerPerson] = @idCustomerPerson
		RETURN (SELECT COUNT(*) FROM [dbo].[CustomerPerson] WHERE [idCustomerPerson] = @idCustomerPerson)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[CustomerPerson] ([idCustomer],[idPerson])
			VALUES (@idCustomer,@idPerson)
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
			UPDATE [dbo].[CustomerPerson] 
			SET 
			[idCustomer]=@idCustomer,
			[idPerson]=@idPerson		
			WHERE [idCustomerPerson] = @idCustomerPerson
			COMMIT TRANSACTION
			RETURN @idCustomerPerson
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
			DELETE FROM [dbo].[CustomerPerson] WHERE [idCustomerPerson] = @idCustomerPerson
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
	SELECT [idCustomerPerson] AS 'Id',[idPerson] AS 'Value' 
	FROM [dbo].[CustomerPerson]
	WHERE [idCustomer] = @idCustomer
	ORDER BY [idPerson] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmCustomerType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmCustomerType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idCustomerType int = 0,
	@Description varchar(50) = null,
	@Visible int = 1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT CustomerTypements.
	SET NOCOUNT ON;
	-- Insert CustomerTypements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idCustomerType],[Description],[Visible]
		FROM [dbo].[CustomerType]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[CustomerType] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idCustomerType],[Description],[Visible]
		FROM [dbo].[CustomerType]
		WHERE [idCustomerType] = @idCustomerType AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[CustomerType] WHERE [idCustomerType] = @idCustomerType AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[CustomerType] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[CustomerType] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idCustomerType] = @idCustomerType
			COMMIT TRANSACTION
			RETURN @idCustomerType
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
			DELETE FROM [dbo].[CustomerType] WHERE [idCustomerType] = @idCustomerType
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
	SELECT [idCustomerType] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[CustomerType]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmCustomer-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmCustomer-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm INT = 0,
	@idCustomer INT = 0,
	@idLocationCountry int,
	@idLocationProvince int,
	@idLocationCity int,
	@BusinessName VARCHAR(50),
	@FantasyName VARCHAR(50),
	@Cuit varchar(50),
	@Home varchar(50),
	@idIvaType INT,
	@idCustomerType INT,
	@Visible INT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Customerments.
	SET NOCOUNT ON;
	-- Insert Customerments for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idCustomer],[idLocationCountry],[idLocationProvince],[idLocationCity],[BusinessName],[FantasyName],[Cuit],[Home],[idIvaType],[idCustomerType],[Visible]
		FROM [dbo].[Customer]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Customer] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idCustomer],[idLocationCountry],[idLocationProvince],[idLocationCity],[BusinessName],[FantasyName],[Cuit],[Home],[idIvaType],[idCustomerType],[Visible]
		FROM [dbo].[Customer]
		WHERE [idCustomer] = @idCustomer AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Customer] WHERE [idCustomer] = @idCustomer AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Customer] 
			([idLocationCountry],[idLocationProvince],[idLocationCity],[BusinessName],[FantasyName],[Cuit],[Home],[idIvaType],[idCustomerType],[Visible])
			VALUES (@idLocationCountry,@idLocationProvince,@idLocationCity,@BusinessName,@FantasyName,@Cuit,@Home,@idIvaType,@idCustomerType,@Visible)
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
			UPDATE [dbo].[Customer] 
			SET 
			[idLocationCountry]=@idLocationCountry,
			[idLocationProvince]=@idLocationProvince,
			[idLocationCity]=@idLocationCity,
			[BusinessName] = @BusinessName,
			[FantasyName] = @FantasyName,
			[Cuit] = @Cuit,
			[Home]=@Home,
			[idIvaType] = @idIvaType,
			[idCustomerType] = @idCustomerType,
			[Visible] = @Visible
			WHERE [idCustomer] = @idCustomer
			COMMIT TRANSACTION
			RETURN @idCustomer
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
			DELETE FROM [dbo].[Customer] WHERE [idCustomer] = @idCustomer
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
	SELECT [idCustomer] AS 'Id',[BusinessName] AS 'Value' 
	FROM [dbo].[Customer]
	WHERE [Visible] = @Visible
	ORDER BY [BusinessName] ASC
	END
END
















GO
/****** Object:  StoredProcedure [dbo].[spAbmDeviceAccount-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmDeviceAccount-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idDeviceAccount int=0,
	@idDevice int=1,
	@idAccount int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDeviceAccount],[idDevice],[idAccount]
		FROM [dbo].[DeviceAccount] 
		WHERE [idDevice] = @idDevice
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceAccount] WHERE [idDevice] = @idDevice)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDeviceAccount],[idDevice],[idAccount]
		FROM [dbo].[DeviceAccount]
		WHERE [idDeviceAccount] = @idDeviceAccount
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceAccount] WHERE [idDeviceAccount] = @idDeviceAccount)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[DeviceAccount] ([idDevice],[idAccount])
			VALUES (@idDevice,@idAccount)
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
			UPDATE [dbo].[DeviceAccount] 
			SET 
			[idDevice]=@idDevice,
			[idAccount]=@idAccount		
			WHERE [idDeviceAccount] = @idDeviceAccount
			COMMIT TRANSACTION
			RETURN @idDeviceAccount
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
			DELETE FROM [dbo].[DeviceAccount] WHERE [idDeviceAccount] = @idDeviceAccount
			COMMIT TRANSACTION
			RETURN @idDeviceAccount
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 5
	BEGIN
	SELECT [idDeviceAccount] AS 'Id',[idAccount] AS 'Value' 
	FROM [dbo].[DeviceAccount]
	WHERE [idDevice] = @idDevice
	ORDER BY [idAccount] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmDeviceHardware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmDeviceHardware-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idDeviceHardware int=0,
	@idDevice int=1,
	@idHardware int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDeviceHardware],[idDevice],[idHardware]
		FROM [dbo].[DeviceHardware] 
		WHERE [idDevice] = @idDevice
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceHardware] WHERE [idDevice] = @idDevice)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDeviceHardware],[idDevice],[idHardware]
		FROM [dbo].[DeviceHardware]
		WHERE [idDeviceHardware] = @idDeviceHardware
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceHardware] WHERE [idDeviceHardware] = @idDeviceHardware)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[DeviceHardware] ([idDevice],[idHardware])
			VALUES (@idDevice,@idHardware)
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
			UPDATE [dbo].[DeviceHardware] 
			SET 
			[idDevice]=@idDevice,
			[idHardware]=@idHardware		
			WHERE [idDeviceHardware] = @idDeviceHardware
			COMMIT TRANSACTION
			RETURN @idDeviceHardware
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
			DELETE FROM [dbo].[DeviceHardware] WHERE [idDeviceHardware] = @idDeviceHardware
			COMMIT TRANSACTION
			RETURN @idDeviceHardware
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 5
	BEGIN
	SELECT [idDeviceHardware] AS 'Id',[idHardware] AS 'Value' 
	FROM [dbo].[DeviceHardware]
	WHERE [idDevice] = @idDevice
	ORDER BY [idHardware] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmDeviceSoftware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmDeviceSoftware-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idDeviceSoftware int=0,
	@idDevice int=1,
	@idSoftware int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDeviceSoftware],[idDevice],[idSoftware]
		FROM [dbo].[DeviceSoftware] 
		WHERE [idDevice] = @idDevice
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceSoftware] WHERE [idDevice] = @idDevice)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDeviceSoftware],[idDevice],[idSoftware]
		FROM [dbo].[DeviceSoftware]
		WHERE [idDeviceSoftware] = @idDeviceSoftware
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceSoftware] WHERE [idDeviceSoftware] = @idDeviceSoftware)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[DeviceSoftware] ([idDevice],[idSoftware])
			VALUES (@idDevice,@idSoftware)
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
			UPDATE [dbo].[DeviceSoftware] 
			SET 
			[idDevice]=@idDevice,
			[idSoftware]=@idSoftware		
			WHERE [idDeviceSoftware] = @idDeviceSoftware
			COMMIT TRANSACTION
			RETURN @idDeviceSoftware
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
			DELETE FROM [dbo].[DeviceSoftware] WHERE [idDeviceSoftware] = @idDeviceSoftware
			COMMIT TRANSACTION
			RETURN @idDeviceSoftware
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 5
	BEGIN
	SELECT [idDeviceSoftware] AS 'Id',[idSoftware] AS 'Value' 
	FROM [dbo].[DeviceSoftware]
	WHERE [idDevice] = @idDevice
	ORDER BY [idSoftware] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmDeviceState-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmDeviceState-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idDeviceState int=0,
	@Visible int=1,
	@Description varchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDeviceState],[Visible],[Description]
		FROM [dbo].[DeviceState] 
		WHERE [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceState] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDeviceState],[Visible],[Description]
		FROM [dbo].[DeviceState]
		WHERE [idDeviceState] = @idDeviceState
		AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceState] WHERE [idDeviceState] = @idDeviceState AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[DeviceState] ([Visible],[Description])
			VALUES (@Visible,@Description)
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
			UPDATE [dbo].[DeviceState] 
			SET 
			[Visible]=@Visible,
			[Description]=@Description		
			WHERE [idDeviceState] = @idDeviceState
			COMMIT TRANSACTION
			RETURN @idDeviceState
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
			DELETE FROM [dbo].[DeviceState] WHERE [idDeviceState] = @idDeviceState
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
	SELECT [idDeviceState] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[DeviceState]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmDeviceType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmDeviceType-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idDeviceType int=0,
	@Visible int=1,
	@Description varchar(20)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDeviceType],[Visible],[Description]
		FROM [dbo].[DeviceType] 
		WHERE [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceType] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDeviceType],[Visible],[Description]
		FROM [dbo].[DeviceType]
		WHERE [idDeviceType] = @idDeviceType
		AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[DeviceType] WHERE [idDeviceType] = @idDeviceType AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[DeviceType] ([Visible],[Description])
			VALUES (@Visible,@Description)
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
			UPDATE [dbo].[DeviceType] 
			SET 
			[Visible]=@Visible,
			[Description]=@Description		
			WHERE [idDeviceType] = @idDeviceType
			COMMIT TRANSACTION
			RETURN @idDeviceType
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
			DELETE FROM [dbo].[DeviceType] WHERE [idDeviceType] = @idDeviceType
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
	SELECT [idDeviceType] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[DeviceType]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmDevice-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmDevice-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idDevice int=0,
	@idDeviceType int=0,
	@idDeviceState int=0,
	@idCustomer int=0,
	@Name varchar(50)=null,
	@Ip char(15)=null,
	@Dns char(15)=null,
	@Gateway char(15)=null,
	@Area varchar(50)=null,
	@Post varchar(50)=null,
	@IdLocationCountry int=0,
	@idLocationProvince int=0,
	@idLocationCity int=0,
	@DischargeDate datetime=null,
	@Visible int=0,
	@Description TEXT=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDevice],[idDeviceType],[idDeviceState],[idCustomer],[Name],[Ip],
			   [Dns],[Gateway],[Area],[Post],[IdLocationCountry],[idLocationProvince],[idLocationCity],
			   [DischargeDate],[Visible],[Description]
		FROM [dbo].[Device] WHERE [idCustomer] = @idCustomer AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Device] WHERE [idCustomer] = @idCustomer AND [Visible]=@Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDevice],[idDeviceType],[idDeviceState],[idCustomer],[Name],[Ip],
			   [Dns],[Gateway],[Area],[Post],[IdLocationCountry],[idLocationProvince],[idLocationCity],
			   [DischargeDate],[Visible],[Description]
		FROM [dbo].[Device]
		WHERE [idDevice] = @idDevice AND [Visible]=@Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Device] WHERE [idDevice] = @idDevice AND [Visible]=@Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Device] ([idDeviceType],[idDeviceState],[idCustomer],[Name],[Ip],
			   [Dns],[Gateway],[Area],[Post],[IdLocationCountry],[idLocationProvince],[idLocationCity],
			   [DischargeDate],[Visible],[Description])
			VALUES (@idDeviceType,@idDeviceState,@idCustomer,@Name,@Ip,@Dns,@Gateway,@Area,@Post,@idLocationCountry,
				@idLocationProvince,@idLocationCity,@DischargeDate,@Visible,@Description)
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
			UPDATE [dbo].[Device] 
			SET 
			[idDeviceType]=@idDeviceType,
			[idDeviceState]=@idDeviceState,
			[idCustomer]=@idCustomer,
			[Name]=@Name,
			[Ip]=@Ip,
			[Dns]=@Dns,
			[Gateway]=@Gateway,
			[Area]=@Area,
			[Post]=@Post,
			[IdLocationCountry]=@IdLocationCountry,
			[idLocationProvince]=@idLocationProvince,
			[idLocationCity]=@idLocationCity,
			[DischargeDate]=@DischargeDate,
			[Visible]=@Visible,
			[Description]=@Description
			WHERE [idDevice] = @idDevice
			COMMIT TRANSACTION
			RETURN @idDevice
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
			DELETE FROM [dbo].[Device] WHERE [idDevice] = @idDevice
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
	SELECT [idDevice] AS 'Id',[Name] AS 'Value' 
	FROM [dbo].[Device]
	WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer
	ORDER BY [Name] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmDocumentType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Marcos A. Carreras>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmDocumentType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idDocumentType int = 0,
	@Description varchar(50) = null,
	@Visible int = 1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idDocumentType],[Description],[Visible]
		FROM [dbo].[DocumentType]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[DocumentType] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idDocumentType],[Description],[Visible]
		FROM [dbo].[DocumentType]
		WHERE [idDocumentType] = @idDocumentType AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[DocumentType] WHERE [idDocumentType] = @idDocumentType AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[DocumentType] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[DocumentType] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idDocumentType] = @idDocumentType
			COMMIT TRANSACTION
			RETURN @idDocumentType
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
			DELETE FROM [dbo].[DocumentType] WHERE [idDocumentType] = @idDocumentType
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
	SELECT [idDocumentType] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[DocumentType]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmHardware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmHardware-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idHardware int=0,
	@idCustomer INT = 0,
	@Component varchar(50)=null,
	@DatePurchase datetime=null,
	@Warranty int=0,
	@Barcode int=0,
	@Visible int=1,
	@Description varchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idHardware],[idCustomer],[Component],[DatePurchase],[Warranty],[Barcode],[Visible],[Description]
		FROM [dbo].[Hardware] 
		WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[Hardware] 
			WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer AND [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idHardware],[idCustomer],[Component],[DatePurchase],[Warranty],[Barcode],[Visible],[Description]
		FROM [dbo].[Hardware]
		WHERE [idHardware] = @idHardware 
		AND [Visible] = @Visible 
		AND [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[Hardware] 
			WHERE [idHardware] = @idHardware 
			AND [Visible] = @Visible 
			AND [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Hardware] ([idCustomer],[Component],[DatePurchase],[Warranty],[Barcode],[Visible],[Description])
			VALUES (@idCustomer,@Component,@DatePurchase,@Warranty,@Barcode,@Visible,@Description)
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
			UPDATE [dbo].[Hardware] 
			SET 
			[idCustomer] = @idCustomer,
			[Component]=@Component,
			[DatePurchase]=@DatePurchase,
			[Warranty]=@Warranty,
			[Barcode]=@Barcode,
			[Visible]=@Visible,
			[Description]=@Description				
			WHERE [idHardware] = @idHardware
			COMMIT TRANSACTION
			RETURN @idHardware
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
			DELETE FROM [dbo].[Hardware] WHERE [idHardware] = @idHardware
			COMMIT TRANSACTION
			RETURN @idHardware
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 5
	BEGIN
	SELECT [idHardware] AS 'Id',[Component] AS 'Value' 
	FROM [dbo].[Hardware]
	WHERE [Visible] = @Visible
	AND [idCustomer] = @idCustomer
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmHomeworkType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/4 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmHomeworkType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idHomeworkType int=0,
	@Description varchar(50)=null,
	@Visible int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idHomeworkType],[Description],[Visible]
		FROM [dbo].[HomeworkType]
		WHERE [Visible]=@Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[HomeworkType] WHERE [Visible]=@Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idHomeworkType],[Description],[Visible]
		FROM [dbo].[HomeworkType]
		WHERE [idHomeworkType] = @idHomeworkType AND [Visible]=@Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[HomeworkType] WHERE [idHomeworkType] = @idHomeworkType AND [Visible]=@Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[HomeworkType] ([Description],[Visible])
			VALUES (@Description,@Visible)
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
			UPDATE [dbo].[HomeworkType] 
			SET 
			[Visible]=@Visible,
			[Description]=@Description
			WHERE [idHomeworkType]=@idHomeworkType
			COMMIT TRANSACTION
			RETURN @idHomeworkType
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
			DELETE FROM [dbo].[HomeworkType] WHERE [idHomeworkType] = @idHomeworkType
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
	SELECT [idHomeworkType] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[HomeworkType]
	WHERE [Visible]=@Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmIvaType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmIvaType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idIvaType int = 0,
	@Description varchar(50) = null,
	@Visible int = 1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT IvaTypements.
	SET NOCOUNT ON;
	-- Insert IvaTypements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idIvaType],[Description],[Visible]
		FROM [dbo].[IvaType]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[IvaType] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idIvaType],[Description],[Visible]
		FROM [dbo].[IvaType]
		WHERE [idIvaType] = @idIvaType AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[IvaType] WHERE [idIvaType] = @idIvaType AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[IvaType] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[IvaType] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idIvaType] = @idIvaType
			COMMIT TRANSACTION
			RETURN @idIvaType
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
			DELETE FROM [dbo].[IvaType] WHERE [idIvaType] = @idIvaType
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
	SELECT [idIvaType] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[IvaType]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmLocationCity-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLocationCity-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idLocationCity int = 0,
	@idLocationProvince int = 0,
	@idLocationCountry int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idLocationCity],[idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCity]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCity] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idLocationCity],[idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCity]
		WHERE [idLocationCity] = @idLocationCity AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCity] WHERE [idLocationCity] = @idLocationCity AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO LocationCity ([idLocationCountry],[idLocationProvince],[Description])
			VALUES (@idLocationCountry, @idLocationProvince, @Description)
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
			UPDATE [dbo].[LocationCity] 
			SET 
			[idLocationProvince] = @idLocationProvince,
			[idLocationCountry] = @idLocationCountry,
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idLocationCity] = @idLocationCity
			COMMIT TRANSACTION
			RETURN @idLocationCity
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
			DELETE FROM [dbo].[LocationCity] WHERE [idLocationCity] = @idLocationCity
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
		SELECT [idLocationCity] AS 'Id', [Description] AS 'Value' 
		FROM [dbo].[LocationCity]
		WHERE [idLocationCountry] = @idLocationCountry 
		AND [idLocationProvince] = @idLocationProvince
		AND [Visible] = @Visible
		ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmLocationCountry-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLocationCountry-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idLocationCountry int = 0,
	@Description varchar(50) = null,
	@Visible int = 1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCountry]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCountry] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationCountry]
		WHERE [idLocationCountry] = @idLocationCountry AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationCountry] WHERE [idLocationCountry] = @idLocationCountry AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[LocationCountry] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[LocationCountry] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idLocationCountry] = @idLocationCountry
			COMMIT TRANSACTION
			RETURN @idLocationCountry
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
			DELETE FROM [dbo].[LocationCity] WHERE [idLocationCountry] = @idLocationCountry
			DELETE FROM [dbo].[LocationProvince] WHERE [idLocationCountry] = @idLocationCountry
			DELETE FROM [dbo].[LocationCountry] WHERE [idLocationCountry] = @idLocationCountry
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
	SELECT [idLocationCountry] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[LocationCountry]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmLocationProvince-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmLocationProvince-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idLocationProvince int = 0,
	@idLocationCountry int = 0,
	@Description varchar(50) = null,
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationProvince]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationProvince] WHERE [Visible] = @Visible )
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idLocationProvince],[idLocationCountry],[Description],[Visible]
		FROM [dbo].[LocationProvince]
		WHERE [idLocationProvince] = @idLocationProvince AND [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[LocationProvince] WHERE [idLocationProvince] = @idLocationProvince AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[LocationProvince] ([idLocationCountry],[Description])
			VALUES (@idLocationCountry, @Description)
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
			UPDATE [dbo].[LocationProvince] 
			SET 
			[idLocationCountry] = @idLocationCountry,
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idLocationProvince] = @idLocationProvince
			COMMIT TRANSACTION
			RETURN @idLocationProvince
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
			DELETE FROM [dbo].[LocationCity] WHERE [idLocationProvince] = @idLocationProvince
			DELETE FROM [dbo].[LocationProvince] WHERE [idLocationProvince] = @idLocationProvince
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
		SELECT [idLocationProvince] AS 'Id', [Description] AS 'Value' 
		FROM [dbo].[LocationProvince]
		WHERE [idLocationCountry] = @idLocationCountry
		AND [Visible] = @Visible
		ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmPersonState-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPersonState-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idPersonState int=0,
	@Visible int=1,
	@Description varchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idPersonState],[Visible],[Description]
		FROM [dbo].[PersonState] 
		WHERE [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[PersonState] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idPersonState],[Visible],[Description]
		FROM [dbo].[PersonState]
		WHERE [idPersonState] = @idPersonState
		AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[PersonState] WHERE [idPersonState] = @idPersonState AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[PersonState] ([Visible],[Description])
			VALUES (@Visible,@Description)
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
			UPDATE [dbo].[PersonState] 
			SET 
			[Visible]=@Visible,
			[Description]=@Description		
			WHERE [idPersonState] = @idPersonState
			COMMIT TRANSACTION
			RETURN @idPersonState
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
			DELETE FROM [dbo].[PersonState] WHERE [idPersonState] = @idPersonState
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
	SELECT [idPersonState] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[PersonState]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmPersonType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPersonType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idPersonType int = 0,
	@Description varchar(50) = null,
	@Visible int = 1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idPersonType],[Description],[Visible]
		FROM [dbo].[PersonType]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[PersonType] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idPersonType],[Description],[Visible]
		FROM [dbo].[PersonType]
		WHERE [idPersonType] = @idPersonType AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[PersonType] WHERE [idPersonType] = @idPersonType AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[PersonType] ([Description])
			VALUES (@Description)
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
			UPDATE [dbo].[PersonType] 
			SET 
			[Description] = @Description,
			[Visible] = @Visible
			WHERE [idPersonType] = @idPersonType
			COMMIT TRANSACTION
			RETURN @idPersonType
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
			DELETE FROM [dbo].[PersonType] WHERE [idPersonType] = @idPersonType
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
	SELECT [idPersonType] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[PersonType]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmPerson-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/09/18 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPerson-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idPerson int = 0,
	@Code int = 0,
	@idDocumentType int,
	@DocumentNumber VARCHAR(50),
	@idPersonType int,
	@idPersonState int,
	@idLocationCountry int,
	@idLocationProvince int,
	@idLocationCity int,
	@Name varchar(50),
	@LastName varchar(50),
	@Birthdate DATE,
	@sexo int,
	@Neighborhood VARCHAR(50),
	@Street VARCHAR(50),
	@Number int,
	@Floor int,
	@Departament VARCHAR(50),
	@PostalCode VARCHAR(50),
	@CellPhone VARCHAR(50),
	@Landline VARCHAR(50),
	@Password VARCHAR(50),
	@Email VARCHAR(50),
	@Skype VARCHAR(50),
	@Visible int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Personments.
	SET NOCOUNT ON;
	-- Insert Personments for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idPerson],[Code],[idDocumentType],[DocumentNumber],[idPersonType],[idPersonState],[idLocationCountry],[idLocationProvince]
			,[idLocationCity],[Name],[LastName],[Birthdate],[sexo],[Neighborhood],[Street],[Number],[Floor],[Departament]
			,[PostalCode],[CellPhone],[Landline],[Password],[Email],[Skype],[Visible]
		FROM [dbo].[Person]
		WHERE [Visible] = @Visible 
		RETURN (SELECT COUNT(*) FROM [dbo].[Person] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idPerson],[Code],[idDocumentType],[DocumentNumber],[idPersonType],[idPersonState],[idLocationCountry],[idLocationProvince]
			,[idLocationCity],[Name],[LastName],[Birthdate],[sexo],[Neighborhood],[Street],[Number],[Floor],[Departament]
			,[PostalCode],[CellPhone],[Landline],[Password],[Email],[Skype],[Visible]
		FROM [dbo].[Person]
		WHERE [idPerson] = @idPerson AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Person] WHERE [idPerson] = @idPerson AND [Visible] = @Visible )
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Person] 
			([Code],[idDocumentType],[DocumentNumber],[idPersonType],[idPersonState],[idLocationCountry],[idLocationProvince]
			,[idLocationCity],[Name],[LastName],[Birthdate],[sexo],[Neighborhood],[Street],[Number],[Floor],[Departament]
			,[PostalCode],[CellPhone],[Landline],[Password],[Email],[Skype],[Visible])
			VALUES (@Code,@idDocumentType,@DocumentNumber,@idPersonType,@idPersonState,@idLocationCountry,@idLocationProvince
			,@idLocationCity,@Name,@LastName,@Birthdate,@sexo,@Neighborhood,@Street,@Number,@Floor,@Departament,@PostalCode
			,@CellPhone,@Landline,@Password,@Email,@Skype,@Visible)
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
			UPDATE [dbo].[Person] 
			SET 
			[Code] = @Code,
			[idDocumentType] = @idDocumentType,
			[DocumentNumber] = @DocumentNumber,
			[idPersonType] = @idPersonType,
			[idPersonState] = @idPersonState,
			[idLocationCountry] = @idLocationCountry,
			[idLocationProvince] = @idLocationProvince,
			[idLocationCity] = @idLocationCity,
			[Name] = @Name,
			[LastName] = @LastName,
			[Birthdate] = @Birthdate,
			[sexo] = @sexo,
			[Neighborhood] = @Neighborhood,
			[Street] = @Street,
			[Number] = @Number,
			[Floor] = @Floor,
			[Departament] = @Departament,
			[PostalCode] = @PostalCode,
			[CellPhone] = @CellPhone,
			[Landline] = @Landline,
			[Password] = @Password,
			[Email]=@Email,
			[Skype]=@Skype,
			[Visible] = @Visible
			WHERE [idPerson] = @idPerson
			COMMIT TRANSACTION
			RETURN @idPerson
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
			--DELETE FROM [dbo].[Customers] WHERE [idPerson] = @idPerson
			DELETE FROM [dbo].[Person] WHERE [idPerson] = @idPerson
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
	SELECT [idPerson] AS 'Id',[Name] AS 'Value' 
	FROM [dbo].[Person]
	WHERE [Visible] = @Visible
	ORDER BY [Name] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmProviderPerson-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmProviderPerson-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idProviderPerson int=0,
	@idPerson int=1,
	@idProvider int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idProviderPerson],[idPerson],[idProvider]
		FROM [dbo].[ProviderPerson] 
		WHERE [idProvider] = @idProvider
		RETURN (SELECT COUNT(*) FROM [dbo].[ProviderPerson] WHERE [idPerson] = @idPerson)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idProviderPerson],[idPerson],[idProvider]
		FROM [dbo].[ProviderPerson]
		WHERE [idProviderPerson] = @idProviderPerson
		RETURN (SELECT COUNT(*) FROM [dbo].[ProviderPerson] WHERE [idProviderPerson] = @idProviderPerson)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[ProviderPerson] ([idPerson],[idProvider])
			VALUES (@idPerson,@idProvider)
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
			UPDATE [dbo].[ProviderPerson] 
			SET 
			[idPerson]=@idPerson,
			[idProvider]=@idProvider		
			WHERE [idProviderPerson] = @idProviderPerson
			COMMIT TRANSACTION
			RETURN @idProviderPerson
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
			DELETE FROM [dbo].[ProviderPerson] WHERE [idProviderPerson] = @idProviderPerson
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
	SELECT [idProviderPerson] AS 'Id',[idProvider] AS 'Value' 
	FROM [dbo].[ProviderPerson]
	WHERE [idPerson] = @idPerson
	ORDER BY [idProvider] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmProvider-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmProvider-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idProvider int = 0,
	@idLocationCountry int,
	@idLocationProvince int,
	@idLocationCity int,
	@BusinessName varchar(50) = null,
	@FantasyName varchar(50) = null,
	@Cuit varchar(50) = null,
	@Home varchar(50) = null,
	@idIvaType int = 0,
	@Visible int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idProvider],[idLocationCountry],[idLocationProvince],[idLocationCity],[BusinessName],[FantasyName],[Cuit],[Home],[idIvaType],[Visible] 
		FROM [dbo].[Provider]
		WHERE [Visible]=@Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Provider] WHERE [Visible]=@Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idProvider],[idLocationCountry],[idLocationProvince],[idLocationCity],[BusinessName],[FantasyName],[Cuit],[Home],[idIvaType],[Visible] 
		FROM [dbo].[Provider]
		WHERE [idProvider] = @idProvider AND [Visible]=@Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[Provider] WHERE [idProvider] = @idProvider AND [Visible]=@Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Provider] ([idLocationCountry],[idLocationProvince],[idLocationCity],[BusinessName],[FantasyName],[Cuit],[Home],[idIvaType],[Visible] )
			VALUES (@idLocationCountry,@idLocationProvince,@idLocationCity,@BusinessName,@FantasyName,@Cuit,@Home,@idIvaType,@Visible)
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
			UPDATE [dbo].[Provider] 
			SET 
			[idLocationCountry]=@idLocationCountry,
			[idLocationProvince]=@idLocationProvince,
			[idLocationCity]=@idLocationCity,
			[BusinessName]=@BusinessName,
			[FantasyName]=@FantasyName,
			[Cuit]=@Cuit,
			[Home]=@Home,
			[idIvaType]=@idIvaType,
			[Visible] =@Visible
			WHERE [idProvider] = @idProvider
			COMMIT TRANSACTION
			RETURN @idProvider
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
			DELETE FROM [dbo].[Provider] WHERE [idProvider] = @idProvider
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
	SELECT [idProvider] AS 'Id',[BusinessName] AS 'Value' 
	FROM [dbo].[Provider]
	WHERE [Visible]=@Visible
	ORDER BY [BusinessName] ASC
	END
END
















GO
/****** Object:  StoredProcedure [dbo].[spAbmPurchaseRequestState-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
	CREATE PROCEDURE [dbo].[spAbmPurchaseRequestState-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idPurchaseRequestState int=0,
	@Visible int=1,
	@Description varchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idPurchaseRequestState],[Visible],[Description]
		FROM [dbo].[PurchaseRequestState] 
		WHERE [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[PurchaseRequestState] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idPurchaseRequestState],[Visible],[Description]
		FROM [dbo].[PurchaseRequestState]
		WHERE [idPurchaseRequestState] = @idPurchaseRequestState
		AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[PurchaseRequestState] WHERE [idPurchaseRequestState] = @idPurchaseRequestState AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[PurchaseRequestState] ([Visible],[Description])
			VALUES (@Visible,@Description)
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
			UPDATE [dbo].[PurchaseRequestState] 
			SET 
			[Visible]=@Visible,
			[Description]=@Description		
			WHERE [idPurchaseRequestState] = @idPurchaseRequestState
			COMMIT TRANSACTION
			RETURN @idPurchaseRequestState
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
			DELETE FROM [dbo].[PurchaseRequestState] WHERE [idPurchaseRequestState] = @idPurchaseRequestState
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
	SELECT [idPurchaseRequestState] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[PurchaseRequestState]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmPurchaseRequest-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmPurchaseRequest-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idPurchaseRequest int=0,
	@idCustomer int=0,
	@idPurchaseRequestState int=0,
	@Date datetime=null,
	@Reason varchar(50)=0,
	@Budget varchar(50)=0,
	@Description varchar(50)=0,
	@Visible int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idPurchaseRequest],[idCustomer],[idPurchaseRequestState],[Date],[Reason],[Budget],[Description],[Visible]
		FROM [dbo].[PurchaseRequest]
		WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[PurchaseRequest] WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idPurchaseRequest],[idCustomer],[idPurchaseRequestState],[Date],[Reason],[Budget],[Description],[Visible]
		FROM [dbo].[PurchaseRequest]
		WHERE [idPurchaseRequest] = @idPurchaseRequest 
		AND [idCustomer] = @idCustomer 
		AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[PurchaseRequest] 
				WHERE [idPurchaseRequest] = @idPurchaseRequest 
				AND [idCustomer] = @idCustomer 
				AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[PurchaseRequest] ([idCustomer],[idPurchaseRequestState],[Date],[Reason],[Budget],[Description],[Visible])
			VALUES (@idCustomer,@idPurchaseRequestState,@Date,@Reason,@Budget,@Description,@Visible)
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
			UPDATE [dbo].[PurchaseRequest] 
			SET 
			[idCustomer] = @idCustomer,
			[idPurchaseRequestState] = @idPurchaseRequestState,
			[Date] = @Date,
			[Reason] = @Reason,
			[Budget] = @Budget,
			[Description] = @Description,
			[Visible] = @Visible						
			WHERE [idPurchaseRequest] = @idPurchaseRequest
			COMMIT TRANSACTION
			RETURN @idPurchaseRequest
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
			DELETE FROM [dbo].[PurchaseRequest] WHERE [idPurchaseRequest] = @idPurchaseRequest
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
	SELECT [idPurchaseRequest] AS 'Id',[Reason] AS 'Value' 
	FROM [dbo].[PurchaseRequest]
	WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer
	ORDER BY [Reason] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmRaeRequestState-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmRaeRequestState-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idRaeRequestState int=0,
	@Visible int=1,
	@Description varchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idRaeRequestState],[Visible],[Description]
		FROM [dbo].[RaeRequestState] 
		WHERE [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[RaeRequestState] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idRaeRequestState],[Visible],[Description]
		FROM [dbo].[RaeRequestState]
		WHERE [idRaeRequestState] = @idRaeRequestState
		AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[RaeRequestState] WHERE [idRaeRequestState] = @idRaeRequestState AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[RaeRequestState] ([Visible],[Description])
			VALUES (@Visible,@Description)
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
			UPDATE [dbo].[RaeRequestState] 
			SET 
			[Visible]=@Visible,
			[Description]=@Description		
			WHERE [idRaeRequestState] = @idRaeRequestState
			COMMIT TRANSACTION
			RETURN @idRaeRequestState
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
			DELETE FROM [dbo].[RaeRequestState] WHERE [idRaeRequestState] = @idRaeRequestState
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
	SELECT [idRaeRequestState] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[RaeRequestState]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmRaeRequest-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmRaeRequest-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int = 0,
	@idRaeRequest int=0,
	@idDevice int=0,
	@idCustomer int=0,
	@IdRaeRequestState int=0,
	@Reason varchar(50)=0,
	@Date datetime=null,
	@Visible int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idRaeRequest],[idDevice],[idCustomer],[IdRaeRequestState],[Reason],[Date],[Visible]
		FROM [dbo].[RaeRequest]
		WHERE  [Visible] = @Visible
		RETURN (SELECT COUNT(idRaeRequest) FROM [dbo].[RaeRequest]
				WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		IF @idCustomer != 0 AND @idDevice != 0
		BEGIN
			SELECT [idRaeRequest],[idDevice],[idCustomer],[IdRaeRequestState],[Reason],[Date],[Visible]
			FROM [dbo].[RaeRequest]
			WHERE [idCustomer] = @idCustomer AND [idDevice] = @idDevice AND [Visible] = @Visible
			RETURN (SELECT COUNT(idRaeRequest) FROM [dbo].[RaeRequest] 
					WHERE [idCustomer] = @idCustomer AND [idDevice] = @idDevice AND [Visible] = @Visible)
		END
		ELSE
		BEGIN
			SELECT [idRaeRequest],[idDevice],[idCustomer],[IdRaeRequestState],[Reason],[Date],[Visible]
			FROM [dbo].[RaeRequest]
			WHERE [idRaeRequest] = @idRaeRequest AND [Visible] = @Visible
			RETURN (SELECT COUNT(idRaeRequest) FROM [dbo].[RaeRequest] 
					WHERE [idRaeRequest] = @idRaeRequest AND [Visible] = @Visible)
		END
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[RaeRequest] ([idDevice],[idCustomer],[IdRaeRequestState],[Reason],[Date],[Visible])
			VALUES (@idDevice,@idCustomer,@IdRaeRequestState,@Reason,@Date,@Visible)
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
			UPDATE [dbo].[RaeRequest] 
			SET 
			[idDevice]=@idDevice,
			[idCustomer]=@idCustomer,
			[IdRaeRequestState]=@IdRaeRequestState,
			[Reason]=@Reason,
			[Date]=@Date,
			[Visible]=@Visible

												
			WHERE [idRaeRequest] = @idRaeRequest
			COMMIT TRANSACTION
			RETURN @idRaeRequest
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
			DELETE FROM [dbo].[RaeRequest] WHERE [idRaeRequest] = @idRaeRequest
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
	SELECT [idRaeRequest] AS 'Id',[Reason] AS 'Value' 
	FROM [dbo].[RaeRequest]
	WHERE [Visible] = @Visible
	ORDER BY [Reason] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmScheduledTasks-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/4 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmScheduledTasks-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idScheduledTasks int=0,
	@idDevice int=0,
	@idCustomer int=0,
	@Description varchar(50)=null,
	@idHomeworkType int=0,
	@StartDate datetime,
	@EndDate datetime,
	@Timework int,
	@Repeat int=0,
	@Visible int=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idScheduledTasks],[idDevice],[idCustomer],[Description],[idHomeworkType],[StartDate],[EndDate],
				[Timework],[Repeat],[Visible]
		FROM [dbo].[ScheduledTasks]
		WHERE [Visible] = @Visible
		RETURN (SELECT COUNT(idScheduledTasks) FROM [dbo].[ScheduledTasks] 
				WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		IF @idCustomer != 0 AND @idDevice != 0
		BEGIN
			SELECT [idScheduledTasks],[idDevice],[idCustomer],[Description],[idHomeworkType],[StartDate],[EndDate],
					[Timework],[Repeat],[Visible]
			FROM [dbo].[ScheduledTasks]
			WHERE [idCustomer] = @idCustomer AND [idDevice] = @idDevice AND [Visible] = @Visible
			RETURN (SELECT COUNT(idScheduledTasks) FROM [dbo].[ScheduledTasks] 
					WHERE [idCustomer] = @idCustomer AND [idDevice] = @idDevice AND [Visible] = @Visible)
		END
		ELSE
		BEGIN
			SELECT [idScheduledTasks],[idDevice],[idCustomer],[Description],[idHomeworkType],[StartDate],[EndDate],
			[Timework],[Repeat],[Visible]
			FROM [dbo].[ScheduledTasks]
			WHERE [idScheduledTasks] = @idScheduledTasks AND [Visible] = @Visible
			RETURN (SELECT COUNT(idScheduledTasks) FROM [dbo].[ScheduledTasks] 
					WHERE [idScheduledTasks] = @idScheduledTasks AND [Visible] = @Visible)
		END
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[ScheduledTasks] ([idDevice],[idCustomer],[Description],[idHomeworkType],[StartDate],[EndDate],
				[Timework],[Repeat],[Visible])
			VALUES (@idDevice,@idCustomer,@Description,@idHomeworkType,@StartDate,@EndDate,@Timework,@Repeat,@Visible)
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
			UPDATE [dbo].[ScheduledTasks] 
			SET 
			[idDevice]=@idDevice,
			[idCustomer]=@idCustomer,
			[Description]=@Description,
			[idHomeworkType]=@idHomeworkType,
			[StartDate]=@StartDate,
			[EndDate]=@EndDate,
			[Timework]=@Timework,
			[Repeat]=@Repeat,
			[Visible]=@Visible
			WHERE [idScheduledTasks]=@idScheduledTasks
			COMMIT TRANSACTION
			RETURN @idScheduledTasks
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
			DELETE FROM [dbo].[ScheduledTasks] WHERE [idScheduledTasks] = @idScheduledTasks
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
	SELECT [idScheduledTasks] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[ScheduledTasks]
	WHERE [Visible]=@Visible
	ORDER BY [Description] ASC
	END
END
























GO
/****** Object:  StoredProcedure [dbo].[spAbmSoftware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmSoftware-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idSoftware int=0,
	@idCustomer INT = 0,
	@Name varchar(50)=null,
	@DatePurchase datetime=null,
	@License varchar(50)=null,
	@Duration int=0,
	@DateLicense varchar(50)=null,
	@Visible int=1,
	@Description varchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idSoftware],[idCustomer],[Name],[DatePurchase],[License],[Duration],[DateLicense],[Visible],[Description]
		FROM [dbo].[Software]
		WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[Software] 
				WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idSoftware],[idCustomer],[Name],[DatePurchase],[License],[Duration],[DateLicense],[Visible],[Description]
		FROM [dbo].[Software]
		WHERE [idSoftware] = @idSoftware 
		AND [Visible] = @Visible 
		AND [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[Software] 
				WHERE [idSoftware] = @idSoftware 
				AND [Visible] = @Visible
				AND [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[Software] ([Name],[idCustomer],[DatePurchase],[License],[Duration],[DateLicense],[Visible],[Description])
			VALUES (@Name,@idCustomer,@DatePurchase,@License,@Duration,@DateLicense,@Visible,@Description)
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
			UPDATE [dbo].[Software] 
			SET 
			[Name] = @Name,
			[idCustomer] = @idCustomer,
			[DatePurchase] = @DatePurchase,
			[License] = @License,
			[Duration] = @Duration,
			[DateLicense] = @DateLicense,
			[Visible] = @Visible,
			[Description] = @Description								
			WHERE [idSoftware] = @idSoftware
			COMMIT TRANSACTION
			RETURN @idSoftware
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
			DELETE FROM [dbo].[Software] WHERE [idSoftware] = @idSoftware
			COMMIT TRANSACTION
			RETURN @idSoftware
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 5
	BEGIN
	SELECT [idSoftware] AS 'Id',[Name] AS 'Value' 
	FROM [dbo].[Software]
	WHERE [Visible] = @Visible
	AND [idCustomer] = @idCustomer
	ORDER BY [Name] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmWorkOrderEntry-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmWorkOrderEntry-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idWorkOrderEntry int=0,
	@Visible int=1,
	@Description varchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idWorkOrderEntry],[Visible],[Description]
		FROM [dbo].[WorkOrderEntry] 
		WHERE [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[WorkOrderEntry] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idWorkOrderEntry],[Visible],[Description]
		FROM [dbo].[WorkOrderEntry]
		WHERE [idWorkOrderEntry] = @idWorkOrderEntry
		AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[WorkOrderEntry] WHERE [idWorkOrderEntry] = @idWorkOrderEntry AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[WorkOrderEntry] ([Visible],[Description])
			VALUES (@Visible,@Description)
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
			UPDATE [dbo].[WorkOrderEntry] 
			SET 
			[Visible]=@Visible,
			[Description]=@Description		
			WHERE [idWorkOrderEntry] = @idWorkOrderEntry
			COMMIT TRANSACTION
			RETURN @idWorkOrderEntry
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
			DELETE FROM [dbo].[WorkOrderEntry] WHERE [idWorkOrderEntry] = @idWorkOrderEntry
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
	SELECT [idWorkOrderEntry] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[WorkOrderEntry]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmWorkOrderState-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmWorkOrderState-v1.0]
	-- Add the parameters for the stored procedure here
	@Abm int=0,
	@idWorkOrderState int=0,
	@Visible int=1,
	@Description varchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idWorkOrderState],[Visible],[Description]
		FROM [dbo].[WorkOrderState] 
		WHERE [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[WorkOrderState] WHERE [Visible] = @Visible)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idWorkOrderState],[Visible],[Description]
		FROM [dbo].[WorkOrderState]
		WHERE [idWorkOrderState] = @idWorkOrderState
		AND [Visible] = @Visible
		RETURN (SELECT COUNT(*) FROM [dbo].[WorkOrderState] WHERE [idWorkOrderState] = @idWorkOrderState AND [Visible] = @Visible)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[WorkOrderState] ([Visible],[Description])
			VALUES (@Visible,@Description)
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
			UPDATE [dbo].[WorkOrderState] 
			SET 
			[Visible]=@Visible,
			[Description]=@Description		
			WHERE [idWorkOrderState] = @idWorkOrderState
			COMMIT TRANSACTION
			RETURN @idWorkOrderState
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
			DELETE FROM [dbo].[WorkOrderState] WHERE [idWorkOrderState] = @idWorkOrderState
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
	SELECT [idWorkOrderState] AS 'Id',[Description] AS 'Value' 
	FROM [dbo].[WorkOrderState]
	WHERE [Visible] = @Visible
	ORDER BY [Description] ASC
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spAbmWorkOrder-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmWorkOrder-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm INT = 0,
	@idWorkOrder INT=0,
	@idDevice INT=0,	
	@idCustomer INT=0,
	@idTechnical INT=0,
	@idWorkOrderState INT=0,
	@OrderNumber VARCHAR(50),
	@StartDate DATETIME=null,
	@EndDate DATETIME=null,
	@Description VARCHAR(50),
	@Retired INT=0,
	@Visible INT=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 0
	BEGIN
		SELECT [idWorkOrder],[idDevice],[idCustomer],[idTechnical],[idWorkOrderState],[OrderNumber],[StartDate],[EndDate],[Description],[Retired],[Visible]
		FROM [dbo].[WorkOrder] 
		WHERE [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[WorkOrder] WHERE [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idWorkOrder],[idDevice],[idCustomer],[idTechnical],[idWorkOrderState],[OrderNumber],[StartDate],[EndDate],[Description],[Retired],[Visible]
		FROM [dbo].[WorkOrder]
		WHERE [idWorkOrder] = @idWorkOrder
		RETURN (SELECT COUNT(*) FROM [dbo].[WorkOrder] WHERE [idWorkOrder] = @idWorkOrder)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[WorkOrder] ([idDevice],[idCustomer],[idTechnical],[idWorkOrderState],[OrderNumber],[StartDate],[EndDate],[Description],[Retired],[Visible])
			VALUES (@idDevice,@idCustomer,@idTechnical,@idWorkOrderState,@OrderNumber,@StartDate,@EndDate,@Description,@Retired,@Visible)
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
			UPDATE [dbo].[WorkOrder] 
			SET 
			[idDevice]=@idDevice,
			[idCustomer]=@idCustomer,
			[idTechnical]=@idTechnical,
			[idWorkOrderState]=@idWorkOrderState,
			[OrderNumber]=@OrderNumber,
			[StartDate]=@StartDate,
			[EndDate]=@EndDate,
			[Description]=@Description,
			[Retired]=@Retired,
			[Visible]=@Visible											
			WHERE [idWorkOrder] = @idWorkOrder
			COMMIT TRANSACTION
			RETURN @idWorkOrder
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
			DELETE FROM [dbo].[WorkOrder] WHERE [idWorkOrder] = @idWorkOrder
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
	SELECT [idWorkOrder] AS 'Id',[OrderNumber] AS 'Value' 
	FROM [dbo].[WorkOrder]
	WHERE [idCustomer] = @idCustomer
	ORDER BY [OrderNumber] ASC
	END
END



















GO
/****** Object:  StoredProcedure [dbo].[spAbmWorkOrder-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 16:29>
-- DescrModeltion:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spAbmWorkOrder-v1.1] 
	-- Add the parameters for the stored procedure here
	@Abm INT = 0,
	@idWorkOrder INT=0,
	@OrderNumber nvarchar(11), -- (1234-123456)= char 11
	@idDevice INT=0,	
	@idCustomer INT=0,
	@idTechnical INT=0,
	@idWorkOrderState INT=0,
	@idWorkOrderEntry INT=0,
	@StartDate DATETIME=null,
	@EndDate DATETIME=null,
	@Description VARCHAR(600),
	@Retired INT=0,
	@Visible INT=1,
	@idUser INT=0
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	DECLARE @vOrderNumber nvarchar(11)

	IF @Abm = 0
	BEGIN
		SELECT [idWorkOrder],[idDevice],[idUser],[idCustomer],[idTechnical],[idWorkOrderState],[idWorkOrderEntry],[OrderNumber],[StartDate],[EndDate],[Description],[Retired],[Visible]
		FROM [dbo].[WorkOrder] 
		WHERE [idCustomer] = @idCustomer
		RETURN (SELECT COUNT(*) FROM [dbo].[WorkOrder] WHERE [idCustomer] = @idCustomer)
	END
	ELSE IF @Abm = 1
	BEGIN
		SELECT [idWorkOrder],[idDevice],[idUser],[idCustomer],[idTechnical],[idWorkOrderState],[idWorkOrderEntry],[OrderNumber],[StartDate],[EndDate],[Description],[Retired],[Visible]
		FROM [dbo].[WorkOrder]
		WHERE [idWorkOrder] = @idWorkOrder
		RETURN (SELECT COUNT(*) FROM [dbo].[WorkOrder] WHERE [idWorkOrder] = @idWorkOrder)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO [dbo].[WorkOrder] ([idDevice],[idCustomer],[idTechnical],[idWorkOrderState],[idWorkOrderEntry],[idUser],
						[OrderNumber],[StartDate],[EndDate],[Description],[Retired],[Visible])
			VALUES (@idDevice,@idCustomer,@idTechnical,@idWorkOrderState,@idWorkOrderEntry,@idUser,
					@OrderNumber,@StartDate,@EndDate,@Description,@Retired,@Visible)
			-- Elimino el numero de Orden generado  
			DELETE FROM [dbo].[WorkOrderCode] WHERE [OrderNumber] = @OrderNumber
			--			
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
			UPDATE [dbo].[WorkOrder] 
			SET 
			[idDevice]=@idDevice,
			[idCustomer]=@idCustomer,
			[idUser]=@idUser,
			[idTechnical]=@idTechnical,
			[idWorkOrderState]=@idWorkOrderState,
			[idWorkOrderEntry]=@idWorkOrderEntry,
			--[OrderNumber]=@OrderNumber,
			[StartDate]=@StartDate,
			[EndDate]=@EndDate,
			[Description]=@Description,
			[Retired]=@Retired,
			[Visible]=@Visible											
			WHERE [idWorkOrder] = @idWorkOrder
			COMMIT TRANSACTION
			RETURN @idWorkOrder
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
			DELETE FROM [dbo].[WorkOrder] WHERE [idWorkOrder] = @idWorkOrder
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
		SELECT [idWorkOrder] AS 'Id',[OrderNumber] AS 'Value' 
		FROM [dbo].[WorkOrder]
		WHERE [idCustomer] = @idCustomer
		ORDER BY [OrderNumber] ASC
	END
	IF @Abm = -1 
	-- Genera el codigo y lo almacena en la tabla [WorkOrderCode]
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			DECLARE @NumberWorkOrder CHAR(11)

			SET @NumberWorkOrder = (
				SELECT [OrderNumber] FROM [dbo].[WorkOrderCode]
				WHERE [dbo].[CutCustomer]([OrderNumber]) = @idCustomer
			)
			
			IF @NumberWorkOrder IS NULL
			BEGIN
				SET @NumberWorkOrder = [dbo].[SetOrderNumber](@idCustomer)	
				
				INSERT INTO [dbo].[WorkOrderCode] ([idUser],[OrderNumber])
				VALUES (@idUser, @NumberWorkOrder)
				-- Lo guardo en la tabla para que otro usuario no use mi mismo codigo
			END

			SELECT @NumberWorkOrder
			-- Devuelvo el Numero de Orden Generado
			COMMIT TRANSACTION
			RETURN 1
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[INSERT]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
END




GO
/****** Object:  StoredProcedure [dbo].[spListDeviceCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/07/14 11:21>
-- Description:	<Consulta Logueo de usuario.>
-- =============================================
CREATE PROCEDURE [dbo].[spListDeviceCustomer-v1.1]
	-- Add the parameters for the stored procedure here
	@idCustomer INT,
	@idDeviceType INT=0,
	@idDeviceState INT=0,
	@Visible INT=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (@idDeviceState = 0 AND @idDeviceType = 0)
	BEGIN
		SELECT [D].[idDevice] AS 'Id', CONCAT([T].[Description],'-',[D].[Name]) AS 'Value' 
		FROM [dbo].[Device] AS [D]
		INNER JOIN [dbo].[DeviceType] AS [T] ON [D].[idDeviceType] = [T].[idDeviceType]
		WHERE [D].[idCustomer] = @idCustomer AND [D].[Visible] = @Visible
		ORDER BY 1 ASC
	END
	ELSE IF (@idDeviceState != 0 AND @idDeviceType = 0)
	BEGIN
		SELECT [D].[idDevice] AS 'Id', CONCAT([T].[Description],'-',[D].[Name]) AS 'Value' 
		FROM [dbo].[Device] AS [D]
		INNER JOIN [dbo].[DeviceType] AS [T] ON [D].[idDeviceType] = [T].[idDeviceType]
		WHERE [D].[idCustomer] = @idCustomer AND [D].[Visible] = @Visible
		AND [D].[idDeviceState] = @idDeviceState
		ORDER BY 1 ASC
	END
	ELSE IF (@idDeviceState = 0 AND @idDeviceType != 0)
	BEGIN
		SELECT [D].[idDevice] AS 'Id', CONCAT([T].[Description],'-',[D].[Name]) AS 'Value' 
		FROM [dbo].[Device] AS [D]
		INNER JOIN [dbo].[DeviceType] AS [T] ON [D].[idDeviceType] = [T].[idDeviceType]
		WHERE [D].[idCustomer] = @idCustomer AND [D].[Visible] = @Visible
		AND [D].[idDeviceType] = @idDeviceType
		ORDER BY 1 ASC
	END
	ELSE
	BEGIN
	SELECT [D].[idDevice] AS 'Id', CONCAT([T].[Description],'-',[D].[Name]) AS 'Value' 
		FROM [dbo].[Device] AS [D]
		INNER JOIN [dbo].[DeviceType] AS [T] ON [D].[idDeviceType] = [T].[idDeviceType]
		WHERE [D].[idCustomer] = @idCustomer AND [D].[Visible] = @Visible
		AND [D].[idDeviceState] = @idDeviceState AND [D].[idDeviceType] = @idDeviceType
		ORDER BY 1 ASC
	END
END












GO
/****** Object:  StoredProcedure [dbo].[spListNameHardware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/03/03 11:22>
-- Description:	<Listado de solo componentes>
-- =============================================
CREATE PROCEDURE [dbo].[spListNameHardware-v1.0] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SELECT [idHardware] AS 'Id',[Component] AS 'Value' 
	FROM [dbo].[Hardware]
	ORDER BY [Component] ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spListNameSoftware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/03/03 11:22>
-- Description:	<Listado de solo Nombre>
-- =============================================
CREATE PROCEDURE [dbo].[spListNameSoftware-v1.0] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SELECT [idSoftware] AS 'Id',[Name] AS 'Value' 
	FROM [dbo].[Software]
	ORDER BY [Name] ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spListPurchaseRequestCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/07/14 11:21>
-- Description:	<Consulta Logueo de usuario.>
-- =============================================
CREATE PROCEDURE [dbo].[spListPurchaseRequestCustomer-v1.1]
	-- Add the parameters for the stored procedure here
    @idCustomer INT,
	@idPurchaseRequestState INT=0,
	@Visible INT=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (@idPurchaseRequestState != 0 )
	BEGIN
		SELECT [P].[idPurchaseRequest] AS 'Id', CONCAT([T].[Description],'-',[P].[Description]) AS 'Value' 
		FROM [dbo].[PurchaseRequest] AS [P]
		INNER JOIN [dbo].[PurchaseRequestState] AS [T] ON [P].[idPurchaseRequestState] = [T].[idPurchaseRequestState]
		WHERE [P].[idCustomer] = @idCustomer  AND [P].[Visible] = @Visible
		AND [T].[idPurchaseRequestState] = @idPurchaseRequestState
		ORDER BY 1 ASC
	END
	ELSE
	BEGIN
		SELECT [P].[idPurchaseRequest] AS 'Id', CONCAT([T].[Description],'-',[P].[Description]) AS 'Value' 
		FROM [dbo].[PurchaseRequest] AS [P]
		INNER JOIN [dbo].[PurchaseRequestState] AS [T] ON [P].[idPurchaseRequestState] = [T].[idPurchaseRequestState]
		WHERE [P].[idCustomer] = @idCustomer  AND [P].[Visible] = @Visible
		ORDER BY 1 ASC
	END
END












GO
/****** Object:  StoredProcedure [dbo].[spListScheduledTasksCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/07/14 11:21>
-- Description:	<Consulta Logueo de usuario.>
-- =============================================
CREATE PROCEDURE [dbo].[spListScheduledTasksCustomer-v1.1]
	-- Add the parameters for the stored procedure here
	@idCustomer INT,
	@idDevice INT=0,
	@idHomeworkType INT=0,
	@Visible INT=1

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (@idDevice = 0 AND @idHomeworkType = 0)
	BEGIN
		SELECT [S].[idScheduledTasks] AS 'Id', CONCAT([T].[Description],'-',[S].[Description]) AS 'Value' 
		FROM [dbo].[ScheduledTasks] AS [S]
		INNER JOIN [dbo].[HomeworkType] AS [T] ON [S].[idHomeworkType] = [T].[idHomeworkType]
		WHERE [S].[idCustomer] = @idCustomer AND [S].[Visible] = @Visible
		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice != 0 AND @idHomeworkType = 0)
	BEGIN
		SELECT [S].[idScheduledTasks] AS 'Id', CONCAT([T].[Description],'-',[S].[Description]) AS 'Value' 
		FROM [dbo].[ScheduledTasks] AS [S]
		INNER JOIN [dbo].[HomeworkType] AS [T] ON [S].[idHomeworkType] = [T].[idHomeworkType]
		WHERE [S].[idCustomer] = @idCustomer AND [S].[Visible] = @Visible
		AND [S].[idDevice] = @idDevice
		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice = 0 AND @idHomeworkType != 0)
	BEGIN
		SELECT [S].[idScheduledTasks] AS 'Id', CONCAT([T].[Description],'-',[S].[Description]) AS 'Value' 
		FROM [dbo].[ScheduledTasks] AS [S]
		INNER JOIN [dbo].[HomeworkType] AS [T] ON [S].[idHomeworkType] = [T].[idHomeworkType]
		WHERE [S].[idCustomer] = @idCustomer AND [S].[Visible] = @Visible
		AND [S].[idHomeworkType] = @idHomeworkType
		ORDER BY 1 ASC
	END
	ELSE
	BEGIN
	SELECT [S].[idScheduledTasks] AS 'Id', CONCAT([T].[Description],'-',[S].[Description]) AS 'Value' 
		FROM [dbo].[ScheduledTasks] AS [S]
		INNER JOIN [dbo].[HomeworkType] AS [T] ON [S].[idHomeworkType] = [T].[idHomeworkType]
		WHERE [S].[idCustomer] = @idCustomer 
		AND [S].[Visible] = @Visible
		AND [S].[idDevice] = @idDevice 
		AND [S].[idHomeworkType] = @idHomeworkType
		ORDER BY 1 ASC
	END
END














GO
/****** Object:  StoredProcedure [dbo].[spListWorkOrderCustomer-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<CARRERAS MARCOS>
-- Create date: <2015/07/14 11:21>
-- Description:	<Consulta Logueo de usuario.>
-- =============================================
CREATE PROCEDURE [dbo].[spListWorkOrderCustomer-v1.1]
	-- Add the parameters for the stored procedure here
	@idCustomer INT,
	@idDevice INT=0,
	@idTechnical INT=0,
	@Visible INT=1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (@idDevice = 0 AND @idTechnical = 0)
	BEGIN
		SELECT [W].[idWorkOrder] AS 'Id', CONCAT([T].[Description],'-',[W].[OrderNumber]) AS 'Value' 
		FROM [dbo].[WorkOrder] AS [W]
		INNER JOIN [dbo].[WorkOrderState] AS [T] ON [W].[idWorkOrderState] = [T].[idWorkOrderState]
		WHERE [W].[idCustomer] = @idCustomer AND [W].[Visible] = @Visible
		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice != 0 AND @idTechnical = 0)
	BEGIN
		SELECT [W].[idWorkOrder] AS 'Id', CONCAT([T].[Description],'-',[W].[OrderNumber]) AS 'Value' 
		FROM [dbo].[WorkOrder] AS [W]
		INNER JOIN [dbo].[WorkOrderState] AS [T] ON [W].[idWorkOrderState] = [T].[idWorkOrderState]
		WHERE [W].[idCustomer] = @idCustomer AND [W].[Visible] = @Visible
		AND [W].[idDevice] = @idDevice
		ORDER BY 1 ASC
	END
	ELSE IF (@idDevice = 0 AND @idTechnical != 0)
	BEGIN
		SELECT [W].[idWorkOrder] AS 'Id', CONCAT([T].[Description],'-',[W].[OrderNumber]) AS 'Value' 
		FROM [dbo].[WorkOrder] AS [W]
		INNER JOIN [dbo].[WorkOrderState] AS [T] ON [W].[idWorkOrderState] = [T].[idWorkOrderState]
		WHERE [W].[idCustomer] = @idCustomer AND [W].[Visible] = @Visible
		AND [W].[idTechnical] = @idTechnical
		ORDER BY 1 ASC
	END
	ELSE
	BEGIN
	SELECT [W].[idWorkOrder] AS 'Id', CONCAT([T].[Description],'-',[W].[OrderNumber]) AS 'Value' 
		FROM [dbo].[WorkOrder] AS [W]
		INNER JOIN [dbo].[WorkOrderState] AS [T] ON [W].[idWorkOrderState] = [T].[idWorkOrderState]
		WHERE [W].[idCustomer] = @idCustomer 
		AND [W].[Visible] = @Visible
		AND [W].[idDevice] = @idDevice 
		AND [W].[idTechnical] = @idTechnical
		ORDER BY 1 ASC
	END
END












GO
/****** Object:  StoredProcedure [dbo].[spLogin-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2015/07/14 11:21>
-- Description:	<Consulta Logueo de usuario.>
-- =============================================
CREATE PROCEDURE [dbo].[spLogin-v1.0]
	-- Add the parameters for the stored procedure here
	@Name varchar(20) = null,
	@Password varchar(20) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT [idPerson] AS 'IdPerson' 
	FROM  [dbo].[Person]
	WHERE @Name LIKE [dbo].[Person].[Name]
	AND @Password LIKE [dbo].[Person].[Password]
END















GO
/****** Object:  StoredProcedure [dbo].[spTmpWorkOrder-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/4 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spTmpWorkOrder-v1.0] 
	-- Add the parameters for the stored procedure here
	@Abm int=1,
	@idNumberWorkOrder int=0,
	@idUsuario int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Abm = 1
	BEGIN
		SELECT [idNumberWorkOrder],[idUsuario]
		FROM [dbo].[TmpWorkOrder]
		WHERE [idUsuario] = @idUsuario
		RETURN (SELECT COUNT(*) FROM [dbo].[TemporalNumber] WHERE [idUsuario] = @idUsuario)
	END
	ELSE IF @Abm = 2	
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			DECLARE @IdReservado INT
			DECLARE @IdExist INT
			SET @IdExist = (SELECT MAX(idNumberWorkOrder) FROM TmpWorkOrder)
			IF  @IdExist IS NULL
				SET @IdReservado = (SELECT MAX(idWorkOrder)+1 FROM WorkOrder)
			ELSE
				SET @IdReservado = (SELECT MAX(idNumberWorkOrder)+1 FROM TmpWorkOrder)
			IF @IdReservado IS NULL
				SET @IdReservado = 1;
			INSERT INTO [dbo].[TmpWorkOrder] ([idNumberWorkOrder],[idUsuario])
			VALUES (@IdReservado,@idUsuario)
			COMMIT TRANSACTION
			RETURN CONCAT ('OR001-',RIGHT(REPLICATE('0', 6)+ CAST(@IdReservado AS VARCHAR(7)), 6))
			END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[INSERT]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
	ELSE IF @Abm = 4		
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM [dbo].[TmpWorkOrder] WHERE [idUsuario] = @idUsuario
			COMMIT TRANSACTION
			RETURN 1
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT '[DELETE]. Se ha producido un error!'
			RETURN 0
		END CATCH
	END
END















GO
/****** Object:  StoredProcedure [dbo].[spViewAccount-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewAccount-v1.0] 
	-- Add the parameters for the stored procedure here
	@All int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idAccount],[idCustomer],[Name],[Password],[Visible],[Description],[MultiDevice]
	FROM [dbo].[Account]
	WHERE [idAccount] > @Desde
	AND [Visible] = @Visible AND [idCustomer] = @idCustomer

	SET @nCnt = (SELECT COUNT([idAccount]) FROM [dbo].[Account] 
				WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewAccount-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/03/08 14:58>
-- Description:	<Lista Tabla Cuentas>
-- =============================================
CREATE PROCEDURE [dbo].[spViewAccount-v1.1] 
	-- Add the parameters for the stored procedure here
	@All int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	IF @All = 0
	BEGIN
		SELECT TOP (@Cnt) [A].[idAccount],[A].[idCustomer],[A].[Name],[A].[Password],[A].[Visible],
		[A].[Description],[A].[MultiDevice]
		FROM [dbo].[Account] AS [A]
		WHERE [A].[idAccount] > @Desde
		AND [A].[Visible] = @Visible AND [A].[idCustomer] = @idCustomer

		SET @nCnt = (SELECT COUNT([A].[idAccount]) FROM [dbo].[Account] AS [A]
					WHERE [A].[Visible] = @Visible AND [A].[idCustomer] = @idCustomer)
	END
	ELSE
	BEGIN
		IF OBJECT_ID('tempdb..#Temp', N'U') IS NOT NULL 
		BEGIN
			-- Elimino la tabla Temporal
			DROP TABLE #Temp
		END
		ELSE
		BEGIN
			-- Creo tabla temporal
			CREATE TABLE #Temp ([idAccount] int, [idCustomer] int, [Name] varchar(50), [Password] varchar(50), 
			[Visible] int, [Description] varchar(50), [MultiDevice] int)
		END

		-- Agrego a tabla temporal el resultado de la primera consulta
		INSERT #Temp SELECT [A].[idAccount],[A].[idCustomer],[A].[Name],[A].[Password],[A].[Visible],
		[A].[Description],[A].[MultiDevice]
		FROM [dbo].[Account] AS [A]
		WHERE [A].[idAccount] NOT IN (SELECT [D].[idAccount] FROM [dbo].[DeviceAccount] AS [D])
		ORDER BY [A].[idAccount]
		
		-- Agrego a tabla temporal el resultado de la segunda consulta
		INSERT #Temp SELECT [A].[idAccount],[A].[idCustomer],[A].[Name],[A].[Password],[A].[Visible],
		[A].[Description],[A].[MultiDevice]
		FROM [dbo].[Account] AS [A]
		WHERE [A].[MultiDevice] = 1
		ORDER BY [A].[idAccount]

		--SELECT * FROM #Temp
		SELECT TOP (@Cnt) [S].[idAccount],[S].[idCustomer],[S].[Name],[S].[Password],[S].[Visible],
		[S].[Description],[S].[MultiDevice] 
		FROM #Temp AS [S]
		WHERE [S].[idAccount] > @Desde
		AND [S].[Visible] = @Visible 
		AND [S].[idCustomer] = @idCustomer
		ORDER BY [S].[idAccount]

		-- Cuento la cantidad de filas devueltas
		SET @nCnt = (SELECT COUNT(*) FROM #Temp AS [S]
					WHERE [S].[Visible] = @Visible 
					AND [S].[idCustomer] = @idCustomer)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spViewAccount-v1.2]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/03/08 14:58>
-- Description:	<Lista Tabla Cuentas>
-- =============================================
CREATE PROCEDURE [dbo].[spViewAccount-v1.2] 
	-- Add the parameters for the stored procedure here
	@All int=0,
	@Id int=0,			--	@Desde
	@Orden int=1,		--	0=Des 1=Asc 
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	IF @All = 0
	BEGIN
		IF @Orden = 1
		BEGIN
			SELECT TOP (@Cnt) [A].[idAccount],[A].[idCustomer],[A].[Name],[A].[Password],[A].[Visible],
			[A].[Description],[A].[MultiDevice]
			FROM [dbo].[Account] AS [A]
			WHERE [A].[idAccount] > @Id
			AND [A].[Visible] = @Visible AND [A].[idCustomer] = @idCustomer
			ORDER BY [A].[idAccount] ASC

			SET @nCnt = (SELECT COUNT([A].[idAccount]) FROM [dbo].[Account] AS [A]
						WHERE [A].[Visible] = @Visible AND [A].[idCustomer] = @idCustomer)
		END
		ELSE
		BEGIN
			DECLARE @VAR INT
			SET @VAR = (SELECT TOP(10) MIN([idAccount]) FROM [dbo].[Account] WHERE [idAccount] <= @Id)

			SELECT TOP (@Cnt) [A].[idAccount],[A].[idCustomer],[A].[Name],[A].[Password],[A].[Visible],
			[A].[Description],[A].[MultiDevice]
			FROM [dbo].[Account] AS [A]
			WHERE [A].[idAccount] <= @Id
			AND [A].[Visible] = @Visible AND [A].[idCustomer] = @idCustomer
			ORDER BY [A].[idAccount] DESC

			SET @nCnt = (SELECT COUNT([A].[idAccount]) FROM [dbo].[Account] AS [A]
						WHERE [A].[Visible] = @Visible AND [A].[idCustomer] = @idCustomer)
		END
	END
	ELSE
	BEGIN
		IF OBJECT_ID('tempdb..#Temp', N'U') IS NOT NULL 
		BEGIN
			-- Elimino la tabla Temporal
			DROP TABLE #Temp
		END
		ELSE
		BEGIN
			-- Creo tabla temporal
			CREATE TABLE #Temp ([idAccount] int, [idCustomer] int, [Name] varchar(50), [Password] varchar(50), 
			[Visible] int, [Description] varchar(50), [MultiDevice] int)
		END

		-- Agrego a tabla temporal el resultado de la primera consulta
		INSERT #Temp SELECT [A].[idAccount],[A].[idCustomer],[A].[Name],[A].[Password],[A].[Visible],
		[A].[Description],[A].[MultiDevice]
		FROM [dbo].[Account] AS [A]
		WHERE [A].[idAccount] NOT IN (SELECT [D].[idAccount] FROM [dbo].[DeviceAccount] AS [D])
		ORDER BY [A].[idAccount]
		
		-- Agrego a tabla temporal el resultado de la segunda consulta
		INSERT #Temp SELECT [A].[idAccount],[A].[idCustomer],[A].[Name],[A].[Password],[A].[Visible],
		[A].[Description],[A].[MultiDevice]
		FROM [dbo].[Account] AS [A]
		WHERE [A].[MultiDevice] = 1
		ORDER BY [A].[idAccount]

		--SELECT * FROM #Temp
		IF @Orden = 1
		BEGIN
			SELECT TOP (@Cnt) [S].[idAccount],[S].[idCustomer],[S].[Name],[S].[Password],[S].[Visible],
			[S].[Description],[S].[MultiDevice] 
			FROM #Temp AS [S]
			WHERE [S].[idAccount] > @iD
			AND [S].[Visible] = @Visible 
			AND [S].[idCustomer] = @idCustomer
			ORDER BY [S].[idAccount] ASC

			-- Cuento la cantidad de filas devueltas
			SET @nCnt = (SELECT COUNT(*) FROM #Temp AS [S]
						WHERE [S].[Visible] = @Visible 
						AND [S].[idCustomer] = @idCustomer)
		END
		ELSE
		BEGIN
			SELECT TOP (@Cnt) [S].[idAccount],[S].[idCustomer],[S].[Name],[S].[Password],[S].[Visible],
			[S].[Description],[S].[MultiDevice] 
			FROM #Temp AS [S]
			WHERE [S].[idAccount] <= @iD
			AND [S].[Visible] = @Visible 
			AND [S].[idCustomer] = @idCustomer
			ORDER BY [S].[idAccount] DESC

			-- Cuento la cantidad de filas devueltas
			SET @nCnt = (SELECT COUNT(*) FROM #Temp AS [S]
						WHERE [S].[Visible] = @Visible 
						AND [S].[idCustomer] = @idCustomer)
		END
	END
END

--http://www.elguille.info/colabora/NET2006/sqlranger_PaginacionSqlServer.htm
GO
/****** Object:  StoredProcedure [dbo].[spViewCustomerType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewCustomerType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idCustomerType],[Description],[Visible]
	FROM [dbo].[CustomerType]
	WHERE [idCustomerType] > @Desde
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idCustomerType) FROM [dbo].[CustomerType] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewCustomer-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewCustomer-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idCustomer],[BusinessName],[FantasyName],[Cuit],[idIvaType],[idCustomerType],[idLocationCountry],[idLocationProvince]
			,[idLocationCity],[Home],[Visible]
	FROM [dbo].[Customer]
	WHERE [idCustomer] > @Desde 
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idCustomer) FROM [dbo].[Customer] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewDeviceState-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewDeviceState-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	SELECT TOP (@Cnt) [idDeviceState],[Visible],[Description]
	FROM [dbo].[DeviceState]
	WHERE [idDeviceState] > @Desde
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT([idDeviceState]) FROM [dbo].[DeviceState] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewDeviceType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewDeviceType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=1,
	@Desde int=0,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idDeviceType],[Visible],[Description]
	FROM [dbo].[DeviceType]
	WHERE [idDeviceType] > @Desde AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idDeviceType) FROM [dbo].[DeviceType] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewDevice-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewDevice-v1.0]
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=0,
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idDevice],[Visible],[Description]
	FROM [dbo].[Device]
	WHERE [idDevice] > @Desde 
	AND [Visible] = @Visible 
	AND [idCustomer] = @idCustomer

	SET @nCnt = (SELECT COUNT(idDevice) FROM [dbo].[Device] 
				WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewDocumentType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewDocumentType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idDocumentType],[Description],[Visible]
	FROM [dbo].[DocumentType]
	WHERE [idDocumentType] > @Desde 
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idDocumentType) FROM [dbo].[DocumentType] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewHardware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewHardware-v1.0] 
	-- Add the parameters for the stored procedure here
	@All int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	SELECT TOP (@Cnt) [idHardware],[idCustomer],[Component],[DatePurchase],[Warranty],[Barcode],[Visible],[Description]
	FROM [dbo].[Hardware]
	WHERE [idHardware] > @Desde
	AND [Visible] = @Visible AND [idCustomer] = @idCustomer

	SET @nCnt = (SELECT COUNT(idHardware) FROM [dbo].[Hardware] 
			WHERE[Visible] = @Visible AND [idCustomer] = @idCustomer)
END










GO
/****** Object:  StoredProcedure [dbo].[spViewHardware-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/03/08 14:58>
-- Description:	<Lista Tabla Hardware>
-- =============================================
CREATE PROCEDURE [dbo].[spViewHardware-v1.1] 
	-- Add the parameters for the stored procedure here
	@All int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @All = 0
	BEGIN
		SELECT TOP (@Cnt) [idHardware],[idCustomer],[Component],[DatePurchase],[Warranty],[Barcode],[Visible],[Description]
		FROM [dbo].[Hardware]
		WHERE [idHardware] > @Desde
		AND [Visible] = @Visible AND [idCustomer] = @idCustomer

		SET @nCnt = (SELECT COUNT(idHardware) FROM [dbo].[Hardware] 
				WHERE[Visible] = @Visible AND [idCustomer] = @idCustomer)
	END
	ELSE
	BEGIN
		SELECT TOP (@Cnt) [H].[idHardware],[H].[idCustomer],[H].[Component],[H].[DatePurchase],[H].[Warranty],[H].[Barcode],
		[H].[Visible],[H].[Description]
		FROM [dbo].[Hardware] AS [H]
		WHERE [H].[idHardware] > @Desde
		AND [H].[Visible] = @Visible AND [H].[idCustomer] = @idCustomer
		AND [H].[idHardware] NOT IN (SELECT [D].[idHardware] FROM [dbo].[DeviceHardware] AS [D])

		SET @nCnt = (SELECT COUNT([H].[idHardware]) FROM [dbo].[Hardware] AS [H]
				WHERE [H].[Visible] = @Visible AND [H].[idCustomer] = @idCustomer
				AND [H].[idHardware] NOT IN (SELECT [D].[idHardware] FROM [dbo].[DeviceHardware] AS [D]))
	END
END










GO
/****** Object:  StoredProcedure [dbo].[spViewHomeworkType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewHomeworkType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idHomeworkType],[Visible],[Description]
	FROM [dbo].[HomeworkType]
	WHERE [idHomeworkType] > @Desde
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idHomeworkType) FROM [dbo].[HomeworkType] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewInfoDevice-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewInfoDevice-v1.0]
	-- Add the parameters for the stored procedure here
	@idHardware int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT [D].[Name],[DT].[Description] 'DeviceType',[DS].[Description] 'DeviceState',
			[D].[Area],[D].[Post],[D].[Ip],[D].[DischargeDate]
	FROM [Device] AS [D]
	INNER JOIN [DeviceHardware] AS [DH] ON [D].[idDevice] = [DH].[idDevice]
	INNER JOIN [DeviceType] AS [DT] ON [D].[idDeviceType] = [DT].[idDeviceType]
	INNER JOIN [DeviceState] AS [DS] ON [D].[idDeviceState] = [DS].[idDeviceState]
	WHERE [DH].[idHardware] = @idHardware;
END









GO
/****** Object:  StoredProcedure [dbo].[spViewIvaType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewIvaType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idIvaType],[Description],[Visible]
	FROM [dbo].[IvaType]
	WHERE [idIvaType] > @Desde
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT([idIvaType]) FROM [dbo].[IvaType] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewPersonState-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewPersonState-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	SELECT TOP (@Cnt) [idPersonState],[Visible],[Description]
	FROM [dbo].[PersonState]
	WHERE [idPersonState] > @Desde
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT([idPersonState]) FROM [dbo].[PersonState] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewPersonType-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewPersonType-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idPersonType],[Description],[Visible]
	FROM [dbo].[PersonType]
	WHERE [idPersonType] > @Desde
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idPersonType) FROM [dbo].[PersonType] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewPerson-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewPerson-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idPerson],[Code],[idDocumentType],[DocumentNumber],[idPersonType],[idPersonState],[idLocationCountry],[idLocationProvince]
			,[idLocationCity],[Name],[LastName],[Birthdate],[sexo],[Neighborhood],[Street],[Number],[Floor],[Departament]
			,[PostalCode],[CellPhone],[Landline],[Password],[Email],[Skype],[Visible]
		FROM [dbo].[Person]
	WHERE [idPerson] > @Desde 
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idPerson) FROM [dbo].[Person] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewProvider-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewProvider-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idProvider],[BusinessName],[FantasyName],[Cuit],[idIvaType],[idLocationCountry],[idLocationProvince]
			,[idLocationCity],[Home],[Visible] 
	FROM [dbo].[Provider]
	WHERE [idProvider]> @Desde
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idProvider) FROM [dbo].[Provider] 
				WHERE [Visible] = @Visible)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewPurchaseRequest-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewPurchaseRequest-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idPurchaseRequest],[idCustomer],[idPurchaseRequestState],[Date],[Reason],[Budget],[Description],[Visible]
	FROM [dbo].[PurchaseRequest]
	WHERE [idPurchaseRequest] > @Desde 
	AND [Visible] = @Visible
	AND [idCustomer] = @idCustomer

	SET @nCnt = (SELECT COUNT([idPurchaseRequest]) FROM [dbo].[PurchaseRequest] 
				WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer)
END















GO
/****** Object:  StoredProcedure [dbo].[spViewRaeRequest-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewRaeRequest-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idRaeRequest],[idDevice],[idCustomer],[IdRaeRequestState],[Reason],[Date],[Visible]
	FROM [dbo].[RaeRequest]
	WHERE [idRaeRequest] > @Desde 
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT([idRaeRequest]) FROM [dbo].[RaeRequest] 
				WHERE [Visible] = @Visible)
END













GO
/****** Object:  StoredProcedure [dbo].[spViewScheduledTasks-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewScheduledTasks-v1.0] 
	-- Add the parameters for the stored procedure here
	@nMonth DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT [D].Name AS'DISPOSITIVO',
	[C].BusinessName AS'CLIENTE',
	[S].[Description]'DESCRIPCION',
	[H].[Description] AS'TAREA',
	[S].[StartDate] AS'F.INICIO' ,
	[S].[EndDate] AS'F.FIN',
	[S].[Timework] AS'TIEMPO',
	[S].[Repeat] AS'REPROGRAMADA'
	FROM [ScheduledTasks] [S]
	inner join Device [D] ON [D].idDevice=[S].idDevice
	inner join Customer [C] ON [C].idCustomer=[S].idCustomer
	inner join HomeworkType [H] ON [H].idHomeworkType=[S].idHomeworkType
	WHERE DATEPART(MONTH, [StartDate]) = @nMonth
	AND DATEPART(YEAR, [StartDate]) = DATEPART(YEAR, GETDATE())

	--WHERE datepart(day, [StartDate]) BETWEEN datepart(day, DATEADD(day, -7, getDate())) AND  datepart(day, DATEADD(day, 6, getDate()))
	--and datepart(MONTH, [StartDate])=DATEPART(month,getdate())
	--and datepart(YEAR, [StartDate])=DATEPART(year,getdate())
END

--select datepart(day, DATEADD(day, -7, getDate())) 'day -7', datepart(day, DATEADD(day, 7, getDate())) 'day +7'
--	 ,DATEPART(month,getdate()) 'Month',DATEPART(year,getdate()) 'Year'














GO
/****** Object:  StoredProcedure [dbo].[spViewSoftware-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/09/05 09:25>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewSoftware-v1.0] 
	-- Add the parameters for the stored procedure here
	@All int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	SELECT TOP (@Cnt) [idSoftware],[idCustomer],[Name],[DatePurchase],[License],[Duration],[DateLicense],[Visible],[Description]
	FROM [dbo].[Software]
	WHERE [idSoftware] > @Desde
	AND [Visible] = @Visible AND [idCustomer] = @idCustomer

	SET @nCnt = (SELECT COUNT(idSoftware) FROM [dbo].[Software] 
			WHERE [Visible] = @Visible AND [idCustomer] = @idCustomer)
END
















GO
/****** Object:  StoredProcedure [dbo].[spViewSoftware-v1.1]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Back Leonardo>
-- Create date: <2017/03/08 14:58>
-- Description:	<Lista Tabla Hardware>
-- =============================================
CREATE PROCEDURE [dbo].[spViewSoftware-v1.1] 
	-- Add the parameters for the stored procedure here
	@All int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@idCustomer int=0,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @All = 0
	BEGIN
		SELECT TOP (@Cnt) [S].[idSoftware],[S].[idCustomer],[S].[Name],[S].[DatePurchase],[S].[License],[S].[Duration],
		[S].[DateLicense],[S].[Visible],[S].[Description]
		FROM [dbo].[Software] AS [S]
		WHERE [idSoftware] > @Desde
		AND [S].[Visible] = @Visible AND [S].[idCustomer] = @idCustomer

		SET @nCnt = (SELECT COUNT([S].[idSoftware]) FROM [dbo].[Software] AS [S]
				WHERE [S].[Visible] = @Visible AND [S].[idCustomer] = @idCustomer)
	END
	ELSE
	BEGIN
		SELECT TOP (@Cnt) [S].[idSoftware],[S].[idCustomer],[S].[Name],[S].[DatePurchase],[S].[License],[S].[Duration],
		[S].[DateLicense],[S].[Visible],[S].[Description]
		FROM [dbo].[Software] AS [S]
		WHERE [idSoftware] > @Desde
		AND [S].[Visible] = @Visible AND [S].[idCustomer] = @idCustomer
		AND [S].[idSoftware] NOT IN (SELECT [D].[idSoftware] FROM [dbo].[DeviceSoftware] AS [D])

		SET @nCnt = (SELECT COUNT([S].[idSoftware]) FROM [dbo].[Software] AS [S]
				WHERE [S].[Visible] = @Visible AND [S].[idCustomer] = @idCustomer
				AND [S].[idSoftware] NOT IN (SELECT [D].[idSoftware] FROM [dbo].[DeviceSoftware] AS [D]))
	END
END
















GO
/****** Object:  StoredProcedure [dbo].[spViewWorkOrderEntry-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 16:38>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewWorkOrderEntry-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=0,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	SELECT TOP (@Cnt) [idWorkOrderEntry],[Visible],[Description]
	FROM [dbo].[WorkOrderEntry]
	WHERE [idWorkOrderEntry] > @Desde 
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT([idWorkOrderEntry]) FROM [dbo].[WorkOrderEntry] 
				WHERE [Visible] = @Visible)
END














GO
/****** Object:  StoredProcedure [dbo].[spViewWorkOrderState-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 16:38>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewWorkOrderState-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=1,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	SELECT TOP (@Cnt) [idWorkOrderState],[Visible],[Description]
	FROM [dbo].[WorkOrderState]
	WHERE [idWorkOrderState] > @Desde 
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT([idWorkOrderState]) FROM [dbo].[WorkOrderState] 
				WHERE [Visible] = @Visible)
END














GO
/****** Object:  StoredProcedure [dbo].[spViewWorkOrder-v1.0]    Script Date: 21/11/2017 22:49:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carreras Marcos Andrés>
-- Create date: <2016/11/20 16:48>
-- Description:	<Altas, Bajas y Modificaciones>
-- =============================================
CREATE PROCEDURE [dbo].[spViewWorkOrder-v1.0] 
	-- Add the parameters for the stored procedure here
	@Hasta int=0,
	@Desde int=0,
	@Cnt int=0,
	@Visible int=1,
	@nCnt int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets FROM
	-- interfering with SELECT Typements.
	SET NOCOUNT ON;
	-- Insert Typements for procedure here
	SELECT TOP (@Cnt) [idWorkOrder],[idDevice],[idCustomer],[idTechnical],[idWorkOrderState],[idWorkOrderEntry],[OrderNumber],[StartDate],[EndDate],[Description],[Retired],[Visible]
	FROM [dbo].[WorkOrder]
	WHERE [idWorkOrder] > @Desde 
	AND [Visible] = @Visible

	SET @nCnt = (SELECT COUNT(idWorkOrder) FROM [dbo].[WorkOrder] 
				WHERE [Visible] = @Visible)
END














GO
