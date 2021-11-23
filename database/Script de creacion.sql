USE [DB]
GO

CREATE TABLE tb_areas (
     id int not null
    ,nombre varchar(128) not null
    ,fechaIns datetime constraint tb_areas_df01 default(getdate())
-- CONSTRAINTS
    ,constraint tb_areas_pk
     primary key(id)
     --Evita duplicidad en nombres, lo que seria confuso para reportes
    ,constraint tb_areas_uk01
     unique(nombre)
     --Evita que por espacios a derecha o izquierda se ingresen valores que representan el mismo nombre
    ,constraint tb_areas_chk01
      check(nombre = ltrim(rtrim(nombre)))
)
go

create table tb_subareas (
     id int not null
    ,idArea int not null
    ,nombre varchar(128) not null
    ,fechaIns datetime constraint tb_subareas_df01 default(getdate())
    --
-- CONSTRAINTS
    ,constraint tb_subareas_pk
     primary key(id)
    ,constraint tb_subareas_fk
     foreign key(idArea)
     references tb_subareas(id)
     --Evita duplicidad en nombres dentro de la misma area, lo que seria confuso para reportes
    ,constraint tb_subareas_uk01
     unique (idArea,nombre)
    ,constraint tb_subareas_chk01
      check(nombre = ltrim(rtrim(nombre)))
)
go

create index tb_subareas_idx01
on tb_subareas(idArea)
go

create table tb_tipo_documento_ident (
     simbolo char(2) not null
    ,nombre varchar(64)
    ,fechaIns datetime constraint tb_fechaIns_df01 default(getdate())
    ,constraint tb_tipo_documento_ident_pk
     primary key(simbolo)
    ,constraint tb_tipo_documento_ident_chk01
     check(simbolo=ltrim(rtrim(simbolo)) and simbolo<>'')
)
go

create table ma_empleados (
     id int identity not null
    ,docIdentTipo char(2) not null
    ,docIdentNumero bigint not null
    ,nombre1 varchar(64) not null
    ,nombre2 varchar(64) not null   --no nula para evitar que se ingresen por error datos incompletos
    ,apellido1 varchar(64) not null
    ,apellido2 varchar(64) not null --no nula para evitar que se ingresen por error datos incompletos
    ,idSubArea int not null
    ,fech_ins datetime constraint ma_empleados_df01 default(getdate())
-- CONSTRAINTS
    ,constraint ma_empleados_pk
     primary key(id)
    ,constraint ma_empleados_uk01
     unique (docIdentNumero, docIdentTipo)
    ,constraint ma_empleados_fk01
     foreign key (idSubArea)
     references tb_SubAreas(id)
    --primer nombre no debe ser vacio y sin espacios a derecha ni izquierda
    ,constraint ma_empleados_chk01
     check (nombre1=ltrim(rtrim(nombre1)) and nombre1<>'')
    --primer apellido no debe ser vacio y sin espacios a derecha ni izquierda
    ,constraint ma_empleados_chk02
     check (apellido1=ltrim(rtrim(apellido1)) and apellido1<>'')
    ,constraint ma_empleados_chk03
     check (nombre2=ltrim(rtrim(nombre2)))
    ,constraint ma_empleados_chk04
     check (apellido2=ltrim(rtrim(apellido2)))
    ,constraint ma_empleados_chk05
     check (docIdentNumero>0)
    ,constraint ma_empleados_fk02
     foreign key (docIdentTipo)
     references tb_tipo_documento_ident(simbolo)
)
go

create index ma_empleados_idx01
on ma_empleados(nombre1)
go
create index ma_empleados_idx02
on ma_empleados(nombre2)
go
create index ma_empleados_idx03
on ma_empleados(apellido1)
go
create index ma_empleados_idx04
on ma_empleados(apellido2)
go
--
create index ma_empleados_idx05
on ma_empleados(idSubArea)
go
