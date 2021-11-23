USE [DB]
GO

CREATE PROCEDURE dbo.GetMaEmpleadosByIdentDocument(
    @docIdentNumero bigint
)
AS
BEGIN
    declare @l_docIdentNumero bigint=@docIdentNumero

    select emp.*
      from ma_empleados as emp
     where emp.docIdentNumero = @l_docIdentNumero
     order by emp.fech_ins desc

END
GO

GRANT EXEC ON dbo.GetMaEmpleadosByIdentDocument TO /*dbappuser*/
go

/*

exec GetMaEmpleadosByIdentDocument 91489834

*/