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





insert into mmel.Persona(Nombre,Apellido,TipoDocumento,NroDocumento,Mail,FechaDeNacimiento,Nacionalidad,dirCalle,dirNroCalle,dirIdPais,dirPiso,dirDepto) --ver si nacionalidad va como un string o la tabla id pais(esa es d las direcciones)
select distinct upper(ot.Cliente_Nombre),upper(ot.Cliente_Apellido),'PASAPORTE',ot.Cliente_Pasaporte_Nro,ot.Cliente_Mail,
				ot.Cliente_Fecha_Nac,ot.Cliente_Nacionalidad,ot.Cliente_Dom_Calle,ot.Cliente_Nro_Calle,1,ot.Cliente_Piso,ot.Cliente_Depto
 from gd_esquema.Maestra ot

 --ver si estan todos habilitados o que.. supongo q aca una funcion/sp determinara si estan habilitados en base a q sus datos esten todos ok
 --aca estoy agregando la condicion de usuario a todos los clientes q acabo de agregar ( x ahora son los unicos q estan en la tabla persona, x eso agrego todo directo)
 insert into mmel.Usuarios(idPersona)
 select distinct idPersona from mmel.Persona

--aca le doy la condicion de guest a los usuarios recien creados arriba
insert into mmel.UsuariosPorRoles(idRol,idUsuario)
select distinct 3,pe.idPersona from mmel.Rol ro, mmel.Persona pe

 insert into mmel.Huesped(idUsuario)
 select distinct us.idUsuario 
 from mmel.Persona pe 
 join mmel.Usuarios us on pe.idPersona=us.idPersona
 join mmel.UsuariosPorRoles upr on us.idUsuario=upr.idUsuario
 join mmel.Rol ro on upr.idRol=ro.idRol


 /*Create Table [MMEL].[RegimenesPorHotel](
	idRPH int identity(1,1) not null, --cambiar nombre en der
	idRegimen int references MMEL.Regimen(idRegimen),
	idHotel int references MMEL.Hotel(idHotel),
	constraint PK_idRPH primary key(idRPH)
	)*/

---esta se podria agregar a manopla... todos los hoteles tienen todos los regimenes..
 insert into mmel.RegimenesPorHotel(idRegimen,idHotel)
 select distinct re.idRegimen,ho.idHotel
 from gd_esquema.Maestra ot
 join mmel.Regimen re on ot.Regimen_Descripcion=re.Descripcion
 join mmel.Direccion di on ot.Hotel_Calle=di.calle and ot.Hotel_Nro_Calle=di.nroCalle and di.Ciudad=ot.Hotel_Ciudad
 join mmel.Hotel ho on di.idDireccion=ho.idDireccion


--revisar el usuario q realizo estas reservas ..
insert into mmel.Reserva(FechaDesde,FechaHasta,idHabitacion,idRegimen,idHuesped,CodigoReserva) 
select distinct ot.Reserva_Fecha_Inicio,ot.Reserva_Cant_Noches+ot.Reserva_Fecha_Inicio,ha.idHabitacion,re.idRegimen,hu.idHuesped,ot.Reserva_Codigo		
from gd_esquema.Maestra ot
inner join mmel.Direccion di on ot.Hotel_Calle=di.calle and ot.Hotel_Nro_Calle=di.nroCalle
inner join mmel.Hotel ho on di.idDireccion=ho.idDireccion
inner join mmel.RegimenesPorHotel rph on rph.idHotel=ho.idHotel
inner join mmel.Regimen re on re.Descripcion=ot.Regimen_Descripcion
inner join mmel.Persona pe on pe.Apellido=ot.Cliente_Apellido and pe.NroDocumento=ot.Cliente_Pasaporte_Nro  
inner join mmel.Usuarios us on us.idPersona=pe.idPersona
inner join mmel.Habitacion ha on ot.Habitacion_Numero=ha.NumeroHabitacion and ho.idHotel=ha.idHotel
inner join mmel.Huesped hu on hu.idUsuario = us.idUsuario







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


/*
insert into mmel.Facturacion(FacturaFecha,idEstadia,MontoTotal,NroFactura)
select distinct ot.Factura_Fecha,es.idEstadia,ot.Factura_Total,ot.Factura_Nro from gd_esquema.Maestra ot 
inner join mmel.Reserva re on re.CodigoReserva = ot.Reserva_Codigo
inner join mmel.Estadia es on es.idReserva=re.idReserva
*/
