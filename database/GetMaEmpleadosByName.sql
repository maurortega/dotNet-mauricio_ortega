USE [DB]
GO

CREATE PROCEDURE dbo.GetMaEmpleadosByName(
    @palabras varchar(max)
)
AS
BEGIN
    declare @RC int

    declare @TblPalabras as table (
         palabra varchar(max),
         like_exp varchar(max)
    )

    ;with 
     c1 as (select distinct ltrim(rtrim(spl.value)) as palabra
              from string_split(@palabras,' ') as spl
             where spl.value<>'')
    insert into @TblPalabras(palabra,like_exp)
    select c1.palabra,'%'+c1.palabra+'%'
      from c1
    set @RC = @@ROWCOUNT

    if @RC>0
    begin
        ;with
         c1 as (select emp.id,count(1) as matches
                  from @TblPalabras as p
                      ,ma_empleados as emp
                 where emp.apellido1 like p.like_exp
                    or emp.apellido2 like p.like_exp
                    or emp.nombre1 like p.like_exp
                    or emp.nombre2 like p.like_exp
                 group by emp.id)
        select emp.*
          from ma_empleados as emp
               inner join c1
               on c1.id = emp.id
        order by c1.matches desc --Mas coincidencias
                ,emp.fech_ins    --Mas reciente
    end
    else
    begin
        -- Sin palabras no hay resultados
        select top 0 emp.*
          from ma_empleados as emp
    end

END
GO

GRANT EXEC ON dbo.GetMaEmpleadosByName TO /*dbappuser*/
go

/*

exec GetMaEmpleadosByName 'JAVIER HORTUA'

*/