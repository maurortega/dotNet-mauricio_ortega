USE [DB]
GO

insert into tb_tipo_documento_ident(simbolo,nombre)
values ('CC','Cedula de ciudadania')
      ,('TI','Tarjeta de Identidad')
;

insert into tb_areas(id,nombre)
values (1,'Produccion')
      ,(2,'Diseño')
      ,(3,'Comercial')
      ,(4,'Administrativo')
      ,(5,'Logistica')
;

insert into tb_subareas(id,idArea,nombre)
values (1,1,'Ensablaje')
      ,(2,1,'Control de Calidad')
      --
      ,(3,4,'Contabilidad')
      ,(4,4,'Compras')
      ,(5,4,'Recursos Humanos')
go

/*
select * from tb_subareas
/*