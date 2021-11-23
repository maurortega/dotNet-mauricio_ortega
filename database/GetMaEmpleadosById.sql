USE [DB]
go

CREATE PROCEDURE dbo.GetMaEmpleadosById(
    @id int
)
AS
BEGIN
    DECLARE @l_id int = @id
    SELECT *
      FROM ma_empleados as e
     where id=@id
END
GO

GRANT EXEC ON dbo.GetMaEmpleadosById TO /*dbappuser*/
go