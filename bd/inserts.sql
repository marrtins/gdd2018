--Migracion de datos


--Tabla Rol
insert into MMEL.Rol values('administrador','S')
insert into MMEL.Rol values('recepcionista','S')
insert into MMEL.Rol values('guest','S')

--Tabla Funcionalidades


INSERT INTO MMEL.Funcionalidades VALUES('ABM de Rol')
INSERT INTO MMEL.Funcionalidades VALUES('Login y Seguridad')
INSERT INTO MMEL.Funcionalidades VALUES('ABM de Usuario')
INSERT INTO MMEL.Funcionalidades VALUES('ABM de Hotel')
INSERT INTO MMEL.Funcionalidades VALUES('ABM de Cliente')
INSERT INTO MMEL.Funcionalidades VALUES('ABM de Habitacion')
INSERT INTO MMEL.Funcionalidades VALUES('ABM de Regimen')
INSERT INTO MMEL.Funcionalidades VALUES('ABM de Reserva')
INSERT INTO MMEL.Funcionalidades VALUES('Cancelar Reserva')
INSERT INTO MMEL.Funcionalidades VALUES('Registrar Estadía')
INSERT INTO MMEL.Funcionalidades VALUES('Registrar Consumibles')
INSERT INTO MMEL.Funcionalidades VALUES('Facturar Publicaciones')
INSERT INTO MMEL.Funcionalidades VALUES('Listado Estadistico')


--Rol x Funcionalidades (funcionalidad,rol)

--para el rol de admin: 
insert into mmel.RolesPorFuncionalidades values(1,1) --abm rol
insert into mmel.RolesPorFuncionalidades values(2,1) --login y se
insert into mmel.RolesPorFuncionalidades values(3,1) --abm user
insert into mmel.RolesPorFuncionalidades values(5,1) --abm hotel
insert into mmel.RolesPorFuncionalidades values(6,1) --ab, habi
insert into mmel.RolesPorFuncionalidades values(7,1) --ab, regimen
insert into mmel.RolesPorFuncionalidades values(13,1) --list estadistico

--para el recepcionista
insert into mmel.RolesPorFuncionalidades values(2,2) --login y seg
insert into mmel.RolesPorFuncionalidades values(4,2) --cliente
insert into mmel.RolesPorFuncionalidades values(8,2) --ab, rese
insert into mmel.RolesPorFuncionalidades values(9,2) --cancela rese
insert into mmel.RolesPorFuncionalidades values(10,2) --regis estadia
insert into mmel.RolesPorFuncionalidades values(11,2) --regis consu
insert into mmel.RolesPorFuncionalidades values(12,2) --fact estadia

--para el guest 
insert into mmel.RolesPorFuncionalidades values(8,3) --abm rese
insert into mmel.RolesPorFuncionalidades values(9,3) --cancelar rese




insert into mmel.Pais values('ARGENTINA')

insert into MMEL.Direccion(calle,nroCalle,idPais,Ciudad)
select distinct Hotel_Calle,Hotel_Nro_Calle,1,Hotel_Ciudad from gd_esquema.Maestra
go

alter function MMEL.getidDireccion(@calle nvarchar(150) ,@nroCalle int ,@ciudad varchar(150))
returns int
as
begin
return (select idDireccion from MMEL.Direccion where @calle=calle and @nroCalle=nroCalle and @ciudad = ciudad)
end
go

/*insert into MMEL.Hotel (idDireccion,CantidadEstrellas,RecargaEstrellas) --hayq  ver si la fecha de creacion la pasamos gcomo getdate o direco null
select distinct 
	MMEL.getidDireccion(Hotel_Calle,Hotel_Nro_Calle,Hotel_Ciudad) as idDireccion,
	Hotel_CantEstrella,
	Hotel_Recarga_Estrella
	from gd_esquema.Maestra
*/
insert into mmel.Hotel(idDireccion,CantidadEstrellas,RecargaEstrellas)
select 
	distinct di.idDireccion,ot.Hotel_CantEstrella,ot.Hotel_Recarga_Estrella
	from gd_esquema.Maestra ot
	join mmel.Direccion di on di.calle=ot.Hotel_Calle and di.nroCalle = ot.Hotel_Nro_Calle
	


insert into mmel.TipoHabitacion (idTipoHabitacion,Descripcion,TipoPorcentual)
select 
	Habitacion_Tipo_Codigo,
	Habitacion_Tipo_Descripcion,
	Habitacion_Tipo_Porcentual
 from gd_esquema.Maestra
  group by Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual


go
alter function MMEL.getidHotel(@calle nvarchar(150) ,@nroCalle int ,@ciudad varchar(150))
returns int
as
begin
return (select h.idHotel from MMEL.Hotel h,MMEL.Direccion d where h.idDireccion=d.idDireccion and @calle=d.calle and @nroCalle=d.nroCalle and @ciudad = d.ciudad )
end
go

go
alter function MMEL.getidTipoHabitacion(@descripcion nvarchar(200))
returns int
as
begin
return (select idTipoHabitacion from MMEL.TipoHabitacion where @descripcion=Descripcion)
end
go


/*insert into mmel.Habitacion(NumeroHabitacion,Piso,idHotel,VistaAlExterior,idTipoHabitacion)
select distinct Habitacion_Numero,Habitacion_Piso,mmel.getidHotel(Hotel_Calle,Hotel_Nro_Calle,Hotel_Ciudad),Habitacion_Frente,mmel.getidTipoHabitacion(Habitacion_Tipo_Descripcion) from gd_esquema.Maestra
*/
insert into mmel.Habitacion(NumeroHabitacion,Piso,idHotel,VistaAlExterior,idTipoHabitacion)
select distinct ot.Habitacion_Numero,ot.Habitacion_Piso,ho.idHotel,ot.Habitacion_Frente,th.idTipoHabitacion 
from gd_esquema.Maestra ot 
inner join mmel.Direccion d on d.calle=ot.Hotel_Calle and d.nroCalle = ot.Hotel_Nro_Calle
inner join mmel.Hotel ho on d.idDireccion=ho.idDireccion
inner join mmel.TipoHabitacion th on th.Descripcion=ot.Habitacion_Tipo_Descripcion



/*insert into mmel.Regimen(Precio,Habilitado,Descripcion,idHotel)
select distinct ot.Regimen_Precio,'S',ot.Regimen_Descripcion,ho.idHotel from gd_esquema.Maestra ot  --revisar si entran todas habilitadas
inner join mmel.Direccion di on ot.Hotel_Calle=di.calle and ot.Hotel_Nro_Calle=di.nroCalle
inner join mmel.Hotel ho on di.idDireccion=ho.idDireccion
*/

--iria esta versio ya q no hay q agregar idhotel creeria
insert into mmel.Regimen(Precio,Habilitado,Descripcion)
select distinct ot.Regimen_Precio,'S',upper(ot.Regimen_Descripcion) from gd_esquema.Maestra ot  --revisar si entran todas habilitadas





insert into mmel.Persona(Nombre,Apellido,TipoDocumento,NroDocumento,Mail,FechaDeNacimiento,Nacionalidad)
select distinct upper(ot.Cliente_Nombre),upper(ot.Cliente_Apellido),'PASAPORTE',ot.Cliente_Pasaporte_Nro,ot.Cliente_Mail,
				ot.Cliente_Fecha_Nac,ot.Cliente_Nacionalidad
 from gd_esquema.Maestra ot

insert into MMEL.Direccion(calle,nroCalle,idPais,Piso,Depto)
select distinct ot.Cliente_Dom_Calle,ot.Cliente_Nro_Calle,1,ot.Cliente_Piso,ot.Cliente_Depto from gd_esquema.Maestra ot
inner join mmel.Persona pe on pe.Mail=ot.Cliente_Mail
go



	