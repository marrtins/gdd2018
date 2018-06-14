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



insert into mmel.Habitacion(NumeroHabitacion,Piso,idHotel,VistaAlExterior,idTipoHabitacion)
select distinct ot.Habitacion_Numero,ot.Habitacion_Piso,ho.idHotel,ot.Habitacion_Frente,th.idTipoHabitacion 
from gd_esquema.Maestra ot 
inner join mmel.Direccion d on d.calle=ot.Hotel_Calle and d.nroCalle = ot.Hotel_Nro_Calle
inner join mmel.Hotel ho on d.idDireccion=ho.idDireccion
inner join mmel.TipoHabitacion th on th.Descripcion=ot.Habitacion_Tipo_Descripcion


	

--iria esta versio ya q no hay q agregar idhotel creeria
insert into mmel.Regimen(Precio,Habilitado,Descripcion)
select distinct ot.Regimen_Precio,'S',upper(ot.Regimen_Descripcion) from gd_esquema.Maestra ot  --revisar si entran todas habilitadas


insert into MMEL.TipoDocumento(Detalle) values('PASAPORTE')


insert into mmel.Persona(Nombre,Apellido,idTipoDocumento,NroDocumento,Mail,FechaDeNacimiento,idNacionalidad,dirCalle,dirNroCalle,dirIdPais,dirPiso,dirDepto) --ver si nacionalidad va como un string o la tabla id pais(esa es d las direcciones)
select distinct upper(ot.Cliente_Nombre),upper(ot.Cliente_Apellido),1,ot.Cliente_Pasaporte_Nro,ot.Cliente_Mail,
				ot.Cliente_Fecha_Nac,1,ot.Cliente_Dom_Calle,ot.Cliente_Nro_Calle,1,ot.Cliente_Piso,ot.Cliente_Depto
 from gd_esquema.Maestra ot

 

 --ver si estan todos habilitados o que.. supongo q aca una funcion/sp determinara si estan habilitados en base a q sus datos esten todos ok
 --aca estoy agregando la condicion de usuario a todos los clientes q acabo de agregar ( x ahora son los unicos q estan en la tabla persona, x eso agrego todo directo)
 insert into mmel.Usuarios(idPersona)
 select distinct idPersona from mmel.Persona

--aca le doy la condicion de guest a los usuarios recien creados arriba
insert into mmel.UsuariosPorRoles(idRol,idUsuario)
select distinct 3,pe.idPersona from mmel.Rol ro, mmel.Persona pe

 /*insert into mmel.Huesped(idUsuario)
 select distinct us.idUsuario 
 from mmel.Persona pe 
 join mmel.Usuarios us on pe.idPersona=us.idPersona
 join mmel.UsuariosPorRoles upr on us.idUsuario=upr.idUsuario
 join mmel.Rol ro on upr.idRol=ro.idRol
 */
 insert into mmel.Huesped(idPersona,Habilitado)
 select distinct idPersona,'S' from mmel.Persona 


---esta se podria agregar a manopla... todos los hoteles tienen todos los regimenes..
 insert into mmel.RegimenesPorHotel(idRegimen,idHotel)
 select distinct re.idRegimen,ho.idHotel
 from gd_esquema.Maestra ot
 join mmel.Regimen re on ot.Regimen_Descripcion=re.Descripcion
 join mmel.Direccion di on ot.Hotel_Calle=di.calle and ot.Hotel_Nro_Calle=di.nroCalle and di.Ciudad=ot.Hotel_Ciudad
 join mmel.Hotel ho on di.idDireccion=ho.idDireccion


--revisar el usuario q realizo estas reservas ..
insert into mmel.Reserva(FechaDesde,FechaHasta,idHabitacion,idRegimen,idHuesped,CodigoReserva,idHotel) 
select distinct ot.Reserva_Fecha_Inicio,ot.Reserva_Cant_Noches+ot.Reserva_Fecha_Inicio,ha.idHabitacion,re.idRegimen,hu.idHuesped,ot.Reserva_Codigo,ho.idHotel		
from gd_esquema.Maestra ot
inner join mmel.Direccion di on ot.Hotel_Calle=di.calle and ot.Hotel_Nro_Calle=di.nroCalle
inner join mmel.Hotel ho on di.idDireccion=ho.idDireccion
inner join mmel.RegimenesPorHotel rph on rph.idHotel=ho.idHotel
inner join mmel.Regimen re on re.Descripcion=ot.Regimen_Descripcion
inner join mmel.Persona pe on pe.Apellido=ot.Cliente_Apellido and pe.NroDocumento=ot.Cliente_Pasaporte_Nro  
inner join mmel.Usuarios us on us.idPersona=pe.idPersona
inner join mmel.Habitacion ha on ot.Habitacion_Numero=ha.NumeroHabitacion and ho.idHotel=ha.idHotel
inner join mmel.Huesped hu on hu.idPersona = us.idPersona
/*

insert into mmel.ReservaPorHabitacion(idReserva,idHabitacion)
select distinct re.idReserva,ha.idHabitacion from
*/


--hay campos en q fehca inicio y cant noches son nulos , no los pongo pero revisar...
insert into mmel.Estadia (idReserva,FechaCheckIN,FechaCheckOUT)
select distinct re.idReserva,ot.Estadia_Fecha_Inicio,ot.Estadia_Fecha_Inicio+Estadia_Cant_Noches from gd_esquema.Maestra ot
inner join mmel.Reserva re on re.CodigoReserva = ot.Reserva_Codigo
where ot.Estadia_Fecha_Inicio is not null

insert into mmel.Consumible (Costo,Nombre,CodigoConsumible)
select distinct ot.Consumible_Precio,Consumible_Descripcion,Consumible_Codigo from gd_esquema.Maestra ot

insert into mmel.ConsumiblePorEstadia (idConsumible,idEstadia)
select distinct co.idConsumible,es.idEstadia from gd_esquema.Maestra ot
inner join mmel.Consumible co on co.CodigoConsumible = ot.Consumible_Codigo
inner join mmel.Reserva re on re.CodigoReserva=ot.Reserva_Codigo
inner join mmel.Estadia es on es.idReserva=re.idReserva


insert into mmel.Facturacion(FacturaFecha,idEstadia,FactTotal,NroFactura) --falta agregar forma de pago
select distinct ot.Factura_Fecha,es.idEstadia,ot.Factura_Total,ot.Factura_Nro from gd_esquema.Maestra ot 
inner join mmel.Reserva re on re.CodigoReserva = ot.Reserva_Codigo
inner join mmel.Estadia es on es.idReserva=re.idReserva
where ot.Factura_Fecha is not null

--agergo el item q consideramos valor base de habitacion
insert into mmel.ItemFactura(idFactura,idEstadia,itemDescripcion,itemFacturaCantidad,itemFacturaMonto)
select fa.idFactura,fa.idEstadia,'VALOR BASE HABITACION',ot.Item_Factura_Cantidad,ot.Item_Factura_Monto
 from gd_esquema.Maestra ot 
 inner join mmel.Facturacion fa on fa.NroFactura=ot.Factura_Nro where ot.Consumible_Codigo is null and ot.Factura_Fecha is not null 

insert into mmel.ItemFactura(idFactura,idEstadia,itemDescripcion,idConsumible,itemFacturaCantidad,itemFacturaMonto)
select fa.idFactura,fa.idEstadia,'VALOR CONSUMIBLE',co.idConsumible,ot.Item_Factura_Cantidad,ot.Item_Factura_Monto
 from gd_esquema.Maestra ot 
 inner join mmel.Facturacion fa on fa.NroFactura=ot.Factura_Nro
 inner join mmel.Estadia es on es.idEstadia=fa.idEstadia
 inner join mmel.ConsumiblePorEstadia cpe on cpe.idEstadia = es.idEstadia
 inner join mmel.Consumible co on co.idConsumible=cpe.idConsumible
 where ot.Consumible_Codigo is not null and ot.Factura_Fecha is not null 
 go

IF object_id('mmel.AgregarCliente') IS NULL
    EXEC ('create procedure mmel.AgregarCliente as select 1')
GO

alter procedure mmel.AgregarCliente (@nombre varchar(50),@apellido varchar(50),@tipoDocumento varchar(15),@nroDocumento nvarchar(25),@mail varchar(200),@telefono varchar(20),
	@fechaDeNacimiento datetime,@nacionalidad varchar(50),@dirCalle nvarchar(150),@dirNroCalle int ,@pais varchar(150),@dirPiso smallint,@dirDepto char(2),@dirLocalidad nvarchar(150),
	@habilitado char(1),@idNuevo int output,@codigoRet int output)
as
begin
	
	declare @idDirPais int
	declare @idNacionalidad int
	declare @aux int
	declare @idTipoDoc int
	set @idDirPais=1
	set @idNacionalidad=1
	set @idTipoDoc = 1

	--chequeo si ya existe el cliente. 
	set @aux= mmel.existeCliente(@tipoDocumento,@nroDocumento,@mail)
	if(@aux=1)
	begin
		set @idNuevo = -1
		set @codigoRet =1 --ya existe el tipoynro de doc en la bdd
	end
	else if(@aux=2)
	begin
		set @idNuevo = -1
		set @codigoRet =2 --ya existe el mail en la bdd
	end
	else if(@aux=0)
	begin
		insert into mmel.Persona(Telefono,Nombre,Apellido,idTipoDocumento,NroDocumento,Mail,FechaDeNacimiento,idNacionalidad,dirCalle,dirNroCalle,dirIdPais,dirPiso,dirDepto,dirLocalidad)
		values (@telefono,upper(@nombre),upper(@apellido),@idTipoDoc,@nroDocumento,upper(@mail),@fechaDeNacimiento,@idNacionalidad,@dirCalle,@dirNroCalle,@idDirPais,@dirPiso,
				@dirDepto,@dirLocalidad)
		set @idNuevo=SCOPE_IDENTITY()
		insert into mmel.Usuarios(idPersona) values(@idNuevo)
		insert into MMEL.UsuariosPorRoles(idUsuario,idRol)
			select idUsuario,3 from Usuarios where idPersona = @idNuevo
		insert into mmel.Huesped(idPersona,Habilitado) values(@idNuevo,@habilitado)
		set @codigoRet = 0 --se creo ok el cliente
		
	end
end
	
go

IF object_id('mmel.existeCliente') IS NULL
    EXEC ('create function mmel.existeCliente as select 1')
GO

alter function mmel.existeCliente(@tipodoc varchar(15),@nrodoc int,@mail varchar(200))
returns int
as
begin
	
	if exists (SELECT TOP 1 * FROM mmel.Persona, mmel.TipoDocumento ti WHERE NroDocumento=@nrodoc and ti.Detalle = @tipodoc)
	begin return 1 end --existe el nro y tipodoc en la bdd
	if exists(SELECT TOP 1 * FROM mmel.Persona WHERE Mail=@mail)
	begin return 2 end --existe el mail en la bdd
	return 0 --no existe
end
go


IF object_id('mmel.clienteErroneo') IS NULL
    EXEC ('create function mmel.clienteErroneo as select 1')
GO
alter function mmel.clienteErroneo(@idPersona int)
returns int
as
begin
	
	if exists (SELECT distinct  * FROM mmel.Persona p1 inner join mmel.Persona p2 on p1.idPersona =@idPersona and  p1.idPersona <>p2.idPersona and p1.Mail=p2.Mail)
	begin  return 1 end --hay un conflicto con mail duplicado --> dejo uno con ese mail y el otro borro el mail pero no el usuario.
	if exists(SELECT distinct  * FROM mmel.Persona p1 inner join mmel.Persona p2 on p1.idPersona =@idPersona and p1.idPersona <>p2.idPersona and p1.NroDocumento=p2.NroDocumento and p1.idTipoDocumento=p2.idTipoDocumento)
	begin return 2 end --existe el mismo nro de id para cliente c distinto mail. --> unificar todo al mismo mail y elegir nueva direccioncalle y demas
	
	return 0
end
go

alter procedure mmel.esErroneo(@idPersona int,@codigoRet int output)
as
begin
	if exists (SELECT distinct  * FROM mmel.Persona p1 inner join mmel.Persona p2 on p1.idPersona =@idPersona and  p1.idPersona <>p2.idPersona and p1.Mail=p2.Mail)
	begin  set @codigoRet = 1 end --hay un conflicto con mail duplicado --> dejo uno con ese mail y el otro borro el mail pero no el usuario.
	else if exists(SELECT distinct  * FROM mmel.Persona p1 inner join mmel.Persona p2 on p1.idPersona =@idPersona and p1.idPersona <>p2.idPersona and p1.NroDocumento=p2.NroDocumento and p1.idTipoDocumento=p2.idTipoDocumento)
	begin set @codigoRet = 2 end --existe el mismo nro de id para cliente c distinto mail. --> unificar todo al mismo mail y elegir nueva direccioncalle y demas
	else begin set @codigoRet = 0 end
end
go
alter procedure mmel.removerEmail(@idPersona int)
as
begin
	update mmel.Persona
	set Mail=null where idPersona=@idPersona
end
go

alter procedure mmel.removerPasaporte(@idPersona int)
as
begin
	update mmel.Persona
	set NroDocumento=null where idPersona=@idPersona
end



IF object_id('mmel.modificarCliente') IS NULL
    EXEC ('create procedure mmel.modificarCliente as select 1')
GO
alter procedure mmel.modificarCliente(@idPersona int,@nombre varchar(50),@apellido varchar(50),@tipoDocumento varchar(15),@nroDocumento nvarchar(25),@mail varchar(200),@telefono varchar(20),
	@fechaDeNacimiento datetime,@nacionalidad varchar(50),@dirCalle nvarchar(150),@dirNroCalle int ,@pais varchar(150),@dirPiso smallint,@dirDepto char(2),@dirLocalidad nvarchar(150),
	@habilitado char(1),@codigoRet int output)
as
begin
	
	declare @idDirPais int
	declare @idNacionalidad int
	declare @aux int
	declare @idTipoDoc int
	set @idDirPais=1
	set @idNacionalidad=1
	set @idTipoDoc = 1

	set @aux= mmel.existeClienteModif(@tipoDocumento,@nroDocumento,@mail,@idPersona)
	if(@aux=1)
	begin
		set @codigoRet =1 --el mail esta duplicado 
	end
	else if(@aux=2)
	begin
		set @codigoRet =2 --el pasap esta duplicado 
	end
	else if(@aux=0)
	begin
		update mmel.Persona
		set Nombre=@nombre , Apellido=@apellido,idTipoDocumento=@idTipoDoc,NroDocumento=@nroDocumento,Mail=@mail,Telefono=@telefono,FechaDeNacimiento=@fechaDeNacimiento,idNacionalidad=@idNacionalidad,
			dirCalle=@dirCalle, dirNroCalle = @dirNroCalle,dirIdPais = @idDirPais, dirPiso = @dirPiso,dirDepto = @dirDepto,dirLocalidad=@dirLocalidad where idPersona=@idPersona--,Habilitado = @habilitado
		update mmel.Huesped
			set  Habilitado=@habilitado where idPersona=@idPersona
	set @codigoRet  = 0
	end
end


go

create function mmel.existeClienteModif(@tipodoc varchar(15),@nrodoc int,@mail varchar(200),@idp int)
returns int
as
begin
	
	if exists (SELECT TOP 1 * FROM mmel.Persona, mmel.TipoDocumento ti WHERE NroDocumento=@nrodoc and ti.Detalle = @tipodoc and idPersona<>@idp)
	begin return 1 end --existe el nro y tipodoc en la bdd
	if exists(SELECT TOP 1 * FROM mmel.Persona WHERE Mail=@mail and idPersona<>@idp ) 
	begin return 2 end --existe el mail en la bdd
	return 0 --no existe
end
go



alter procedure mmel.borrarCliente(@idCliente int)
as
begin

update mmel.Huesped
set Habilitado ='N' where idPersona=@idCliente
end


