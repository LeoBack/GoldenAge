SELECT [P].[IdPatient], 
CONCAT([P].[LastName],', ',[P].[Name]) AS 'Nombre', [P].[Birthdate] AS'Cumpleaños',
CONCAT([Ty].[Description],' - ',[P].[NumberDocument]) AS 'Documento', 
[Ps].[Date] AS 'Fecha Ingreso', [Ps].[Description] AS 'Descripcion', [P].[Visible] 
FROM [dbo].[Patient] AS [P] 
INNER JOIN [dbo].[TypeDocument] AS Ty ON [P].[IdTypeDocument] = [Ty].[IdTypeDocument]
INNER JOIN [dbo].[PatientState] AS Ps ON [P].[IdPatient] = [Ps].[IdPatient]
WHERE [Ps].[State] != 0

--
declare @IdParent int set @IdParent = 18 --ingreso y egreso: 9,14,1,12
declare @State int
declare @Egreso datetime
declare @Ingreso datetime

set @State = 1
set @Ingreso =(select max([Date]) as 'State 1' from PatientState
			where [state] = @State and [IdPatient] = @IdParent)

set @State = 0
set @Egreso = (select max([Date]) as 'State 0' from PatientState
			where [state] = @State and [IdPatient] = @IdParent)

select @Ingreso as 'I', @Egreso as 'E'

if @Ingreso < @Egreso
begin
	select 'Bien'
end
else
begin
	Select 'Mal'
end