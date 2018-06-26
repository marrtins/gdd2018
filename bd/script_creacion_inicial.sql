

Use GD1C2018

IF NOT EXISTS ( SELECT  * FROM    sys.schemas  WHERE   name = N'MMEL' ) 
		EXEC('CREATE SCHEMA [MMEL] AUTHORIZATION [gdHotel2018]');
go
------------------ELIMINO LAS TABLAS SI YA EXISTEN PARA VOLVER A CREARLAS -------------- 
IF OBJECT_ID('MMEL.FacturacionPorEstadia', 'U') IS NOT NULL 
	DROP TABLE MMEL.FacturacionPorEstadia;
 
IF OBJECT_ID('MMEL.ConsumiblePorEstadia', 'U') IS NOT NULL 
	drop table MMEL.ConsumiblePorEstadia	

IF OBJECT_ID('MMEL.RolesPorFuncionalidades', 'U') IS NOT NULL 
	drop table MMEL.RolesPorFuncionalidades

IF OBJECT_ID('MMEL.UsuariosPorRoles', 'U') IS NOT NULL 
	drop table MMEL.UsuariosPorRoles

IF OBJECT_ID('MMEL.HotelesPorUsuarios', 'U') IS NOT NULL 
	drop table MMEL.HotelesPorUsuarios

IF OBJECT_ID('MMEL.RegimenesPorHotel', 'U') IS NOT NULL 
	drop table MMEL.RegimenesPorHotel

IF OBJECT_ID('MMEL.Funcionalidades', 'U') IS NOT NULL 
	drop table MMEL.Funcionalidades

IF OBJECT_ID('MMEL.CancelacionReserva', 'U') IS NOT NULL 
	drop table MMEL.CancelacionReserva
IF OBJECT_ID('MMEL.ReservaPorHabitacion', 'U') IS NOT NULL 
	drop table MMEL.ReservaPorHabitacion
	

IF OBJECT_ID('MMEL.Item', 'U') IS NOT NULL 
	drop table MMEL.Item
IF OBJECT_ID('MMEL.ItemFactura', 'U') IS NOT NULL 
	drop table MMEL.ItemFactura

IF OBJECT_ID('MMEL.Consumible', 'U') IS NOT NULL	
	drop table MMEL.Consumible

IF OBJECT_ID('MMEL.Facturacion', 'U') IS NOT NULL 
	drop table MMEL.Facturacion

IF OBJECT_ID('MMEL.FormaDePago', 'U') IS NOT NULL 
	drop table MMEL.FormaDePago

IF OBJECT_ID('MMEL.Estadia', 'U') IS NOT NULL 
	drop table MMEL.Estadia

IF OBJECT_ID('MMEL.Reserva', 'U') IS NOT NULL 
	drop table MMEL.Reserva

IF OBJECT_ID('MMEL.Huesped', 'U') IS NOT NULL 
	drop table MMEL.Huesped

IF OBJECT_ID('MMEL.Rol', 'U') IS NOT NULL 
	drop table MMEL.Rol

IF OBJECT_ID('MMEL.Usuarios', 'U') IS NOT NULL 
	drop table MMEL.Usuarios

IF OBJECT_ID('MMEL.PersonasInconsistentes', 'U') IS NOT NULL 
	drop table MMEL.PersonasInconsistentes


IF OBJECT_ID('MMEL.Persona', 'U') IS NOT NULL 
	drop table MMEL.Persona


IF OBJECT_ID('MMEL.TipoDocumento', 'U') IS NOT NULL 
	drop table MMEL.TipoDocumento

IF OBJECT_ID('MMEL.Regimen', 'U') IS NOT NULL 
	drop table MMEL.Regimen

IF OBJECT_ID('MMEL.Habitacion', 'U') IS NOT NULL 
	drop table MMEL.Habitacion

IF OBJECT_ID('MMEL.TipoHabitacion', 'U') IS NOT NULL 
	drop table MMEL.TipoHabitacion

IF OBJECT_ID('MMEL.Hotel', 'U') IS NOT NULL 
	drop table MMEL.Hotel

IF OBJECT_ID('MMEL.Direccion', 'U') IS NOT NULL 
	drop table MMEL.Direccion

IF OBJECT_ID('MMEL.Pais', 'U') IS NOT NULL 
	drop table MMEL.Pais
IF OBJECT_ID('MMEL.[Constantes]', 'U') IS NOT NULL 
	drop table MMEL.[Constantes]



IF TYPE_ID('MMEL.IdList') IS NULL
CREATE TYPE [MMEL].[IdList] AS TABLE(
	[Id] [int] NULL
)


Create Table [MMEL].[Pais](
	idPais int identity(1,1) not null,
	Nombre nvarchar(50) not null,
	constraint PK_idPais Primary Key(idPais)
	)

CREATE TABLE [MMEL].[Constantes](
	[id] [int] NULL,
	[AplicadoNombre] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Valor] [nvarchar](100) NULL
) ON [PRIMARY]


Create Table [MMEL].[Direccion](
	idDireccion int identity(1,1) not null,
	calle nvarchar(150),
	nroCalle int , --AGREGAR EN DER! 
	idPais int references MMEL.Pais(idPais),
	Ciudad nvarchar(150), ---AGREGAR EN EL DER
	constraint  PK_idDireccion PRIMARY KEY(idDireccion)
	)

create Table [MMEL].[TipoDocumento](
		idTipoDocumento int identity(1,1) not null,
		detalle varchar(30),
		constraint PK_idTipoDocumento primary key(idTipoDocumento)
	)

create Table [MMEL].[Persona](
	idPersona int identity(1,1) not null,
	Nombre varchar(50) ,
	Apellido varchar(50) ,
	--TipoDocumento varchar(15) , --duda aca
	idTipoDocumento int references MMEL.TipoDocumento(idTipoDocumento),
	NroDocumento varchar(25) ,
	Mail varchar(200) ,
	Telefono varchar(20) ,
	--idDireccion int references  MMEL.Direccion(idDireccion), --volar esto
	FechaDeNacimiento datetime ,
	idNacionalidad int references MMEL.Pais(idPais), --cambio aca, antes era un varchar ahora el idPais
	-----------------cambios------------------------
	dirCalle nvarchar(150),
	dirNroCalle int , --AGREGAR EN DER! --VERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRr
	dirIdPais int references MMEL.Pais(idPais), --agregar en der 
	dirPiso smallint,--agregar en der
	dirDepto char(2),---agergar ender
	dirLocalidad nvarchar(150), ---AGREGAR EN EL DER
	
	constraint PK_idPersona primary key(idPersona)
	)
CREATE TABLE [MMEL].[PersonasInconsistentes](
	idPI int identity(1,1) not null,
	idPersona int references MMEL.Persona(idPersona),
	Mail varchar(200),
	NroDocumento varchar(25),
	constraint PK_idPI primary key(idPI)
)

CREATE TABLE [MMEL].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Contraseña] [varchar](75) NULL,
	[idPersona] [int] NULL,
	[Activo] [char](1) NULL,
	[Username] [nvarchar](200) NULL,
	[IngresosFallidos] [int] NOT NULL,
 CONSTRAINT [PK_idUsuario] PRIMARY  key(idUsuario )
 )

ALTER TABLE [MMEL].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_IngresosFallidos]  DEFAULT ((0)) FOR [IngresosFallidos]


CREATE TABLE [MMEL].[Hotel](
	[idHotel] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [varchar](200) NULL,
	[idDireccion] [int] NULL,
	[Telefono] [varchar](20) NULL,
	[CantidadEstrellas] [int] NULL,
	[FechaDeCreacion] [smalldatetime] NULL,
	[Nombre] [varchar](200) NULL,
	[Inhabilitado] [bit] NULL,
	[RecargaEstrellas] int,
	CONSTRAINT [PK_idHotel] PRIMARY  key(idHotel )
 )

Create Table [MMEL].[Regimen](
	idRegimen int identity(1,1) not null,
	Precio decimal(10,2) not null,
	Habilitado char(1) not null,
	Descripcion varchar(200) not null,
	--idHotel int references MMEL.Hotel(idHotel), --No tendria q ir aca 
	constraint PK_idRegimen primary key(idRegimen)
	)
Create Table [MMEL].[RegimenesPorHotel](
	idRPH int identity(1,1) not null, --cambiar nombre en der
	idRegimen int references MMEL.Regimen(idRegimen),
	idHotel int references MMEL.Hotel(idHotel),
	constraint PK_idRPH primary key(idRPH)
	)
Create Table [MMEL].[HotelesPorUsuarios](
	idHPU int identity(1,1) not null, --cambiar nombre en der
	idUsuario int references MMEL.Usuarios(idUsuario),
	idHotel int references MMEL.Hotel(idHotel),
	constraint PK_idHPU primary key(idHPU)

	)

Create Table [MMEL].[Rol](
	idRol int identity(1,1) not null,
	Nombre varchar(50) not null,
	Activo char(1) not null,
	constraint PK_idRol primary key(idRol)
)
Create Table [MMEL].[UsuariosPorRoles](
	idUPR int identity(1,1) not null, --cambiar en der x nombre mas expresivo
	idRol int references MMEL.Rol(idRol),
	idUsuario int references MMEL.Usuarios(idUsuario),
	constraint PK_idUPR primary key(idUPR)
	)
Create Table [MMEL].[Funcionalidades](
	idFuncionalidad int identity(1,1) not null,
	Descripcion varchar(50) not null,
	constraint PK_idFuncionalidad primary key(idFuncionalidad)
	)
Create Table [MMEL].[RolesPorFuncionalidades](
	idRPF int identity(1,1) not null, --cambiar nombre en der
	idFuncionalidad int references MMEL.Funcionalidades(idFuncionalidad),
	idRol int references MMEL.Rol(idRol)
	constraint PK_idRPF primary key(idRPF)
)
Create Table [MMEL].[TipoHabitacion](
	idTipoHabitacion int not null,
	Descripcion nvarchar(200) not null,
	TipoPorcentual decimal (4,2) ,
	constraint PK_idTipoHabitacion primary key(idTipoHabitacion)
	)

Create Table [MMEL].[Habitacion](
	idHabitacion int identity(1,1) not null,
	NumeroHabitacion int,
	Piso smallint ,
	idHotel int references MMEL.Hotel(idHotel),
	VistaAlExterior char(1) ,
	idTipoHabitacion int references MMEL.TipoHabitacion(idTipoHabitacion),
	Descripcion varchar(200),
	Habilitado char(1) ,
	constraint PK_idHabitacion primary key(idHabitacion)
	)

Create Table [MMEL].[Huesped](
	idHuesped int identity(1,1) not null,
	Habilitado char(1) ,
	Reservo char(1) ,
	--idUsuario int references MMEL.Usuarios(idUsuario), ----------REVISAR ESTOOOOOOOOO!! 
	idPersona int references MMEL.Persona(idPersona),
	constraint PK_idHuesped primary key(idHuesped)
	)
Create Table [MMEL].[Reserva](
	idReserva int identity(1,1) not null,
	--idRol int references MMEL.Rol(idRol),--cambiar esto, tiene q ir el id de quien realizo la reserva
	idUsuarioQueProcesoReserva int references MMEL.Usuarios(idUsuario), --agregar al der 
	idHotel int references MMEL.Hotel(idHotel),
	FechaDeReserva datetime ,
	FechaDesde datetime ,
	FechaHasta datetime ,
	idHabitacion int references MMEL.Habitacion(idHabitacion),
	idRegimen int references MMEL.Regimen(idRegimen),
	idHuesped int references MMEL.Huesped(idHuesped),
	EstadoReserva char(6) ,
	CodigoReserva int ,
	constraint PK_idReserva primary key(idReserva)
	)

	Create Table [MMEL].[ReservaPorHabitacion](
	idRPH int identity(1,1) not null,
	idReserva int references MMEL.Reserva(idReserva),
	idHabitacion int references MMEL.Habitacion(idHabitacion),
	constraint PK_RPH primary key(idHabitacion)
	)

Create Table [MMEL].[Estadia](
	idEstadia int identity(1,1) not null,
	idReserva int references MMEL.Reserva(idReserva),
	FechaCheckIN datetime ,
	FechaCheckOUT datetime ,
	idRecepcionistaCheckIN int references MMEL.Usuarios(idUsuario), 
	idRecepcionistaCheckOUT int references MMEL.Usuarios(idUsuario), --revisar estos 2 si son fk a usuario y en ese caso cambiar el nombre en el der
	Consistente char(1),
	constraint PK_idEstadia primary key(idEstadia)
	)
Create Table [MMEL].[Consumible](
	idConsumible int identity(1,1) not null,
	Costo int ,
	--idEstadia int references MMEL.Estadia(idEstadia), --esto no deberia ir aca
	--idHabitacion int references MMEL.Habitacion(idHabitacion), --esto tmp deberia ir aca 
	Nombre varchar(75) ,
	CodigoConsumible int,
	constraint PK_idConsumible primary key(idConsumible)
	)
Create Table [MMEL].[ConsumiblePorEstadia](
	idCPE int identity(1,1) not null, --cambiar nombre en der
	idEstadia int references MMEL.Reserva(idReserva), --cambiar en der
	idConsumible int references MMEL.Consumible(idConsumible),
	constraint PK_idCPE primary key(idCPE)
	)
Create Table [MMEL].[FormaDePago](
	idFormaDePago int identity(1,1) not null, --cambiar nombre en der
	Descripcion varchar(50) not null,
	constraint PK_idFormaDePago primary key(idFormaDePago)
	)

Create Table [MMEL].[Facturacion](
	idFactura int identity(1,1) not null,
	idFormaDePago int references MMEL.FormaDePago(idFormaDePago), --cambiar nombre en el der
	idEstadia int references MMEL.Estadia(idEstadia),
	MontoTotal int ,--en la maestra fact total es un nro q nada q ver, cambio montoTotal x fact total para evitar confusiones
	FactTotal int,
	MontoFinal int,
	NroFactura int , --REVISARRRRRRRRRRRRRR agregado al der 
	FacturaFecha smalldatetime ,
	constraint PK_idFactura primary key(idFactura)
	)


Create table [MMEL].[ItemFactura](
	idItemFactura int identity(1,1) not null,
	idFactura int references MMEL.Facturacion(idFactura), --revisar esto en el der dice (nullable)
	idEstadia int references MMEL.Estadia(idEstadia),
	itemDescripcion nvarchar(200),
	idConsumible int references MMEL.Consumible(idconsumible),
	itemFacturaCantidad smallint, --esto en la maestra es el precio del item ..
	itemFacturaMonto int, --esto en la maestra es 1.00 para todos..
	constraint PK_idItem primary key(idItemFactura)
	)
Create Table [MMEL].[CancelacionReserva](
	idReservaCancelacion int identity(1,1) not null,
	Motivo varchar(300) not null,
	FechaDeCancelacion datetime not null,
	idPersona int references MMEL.Persona(idPersona),
	idRol int references MMEL.Rol(idRol),
	idReserva int references MMEL.Reserva(idReserva)
	constraint PK_idReservaCancelacion primary key(idReservaCancelacion)
	)

Create Table [MMEL].[FacturacionPorEstadia](
	idFPE int identity(1,1) not null, --cambiar nombre en der
	idEstadia int references MMEL.Estadia(idEstadia),
	idFacturacion int references MMEL.Facturacion(idFactura),
	constraint PK_idFPE primary key(idFPE)
	)


GO








--------------------MIGRACION DE DATOS-------



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

--agrego el rol guest 
insert into mmel.Usuarios(Activo)values('S')
insert into mmel.UsuariosPorRoles(idRol,idUsuario) values(3,1)


insert into mmel.Pais values('ARGENTINA')

insert into MMEL.Direccion(calle,nroCalle,idPais,Ciudad)
select distinct Hotel_Calle,Hotel_Nro_Calle,1,Hotel_Ciudad from gd_esquema.Maestra




insert into mmel.Hotel(idDireccion,CantidadEstrellas,RecargaEstrellas,Nombre)
select 
	distinct di.idDireccion,ot.Hotel_CantEstrella,ot.Hotel_Recarga_Estrella,concat(ot.Hotel_Calle,' ',ot.Hotel_Nro_Calle)
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

 insert into MMEL.PersonasInconsistentes(idPersona,Mail,NroDocumento)
select  distinct p1.idPersona,p1.Mail,p1.NroDocumento from mmel.Persona p1, mmel.Persona p2 where 
(p1.Mail=p2.Mail and p1.idPersona<>p2.idPersona ) order by  p1.Mail

insert into MMEL.PersonasInconsistentes(idPersona,Mail,NroDocumento)
select  distinct p1.idPersona,p1.Mail,p1.NroDocumento from mmel.Persona p1, mmel.Persona p2 where 
(p1.idPersona<>p2.idPersona and p1.NroDocumento=p2.NroDocumento ) order by p1.NroDocumento

 /*--ver si estan todos habilitados o que.. supongo q aca una funcion/sp determinara si estan habilitados en base a q sus datos esten todos ok
 --aca estoy agregando la condicion de usuario a todos los clientes q acabo de agregar ( x ahora son los unicos q estan en la tabla persona, x eso agrego todo directo)
 insert into mmel.Usuarios(idPersona)
 select distinct idPersona from mmel.Persona

--aca le doy la condicion de guest a los usuarios recien creados arriba
insert into mmel.UsuariosPorRoles(idRol,idUsuario)
select distinct 3,pe.idPersona from mmel.Rol ro, mmel.Persona pe
*/
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


/*--revisar el usuario q realizo estas reservas ..
insert into mmel.Reserva(FechaDesde,FechaHasta,idHabitacion,idRegimen,idHuesped,CodigoReserva,idHotel) 
select distinct ot.Reserva_Fecha_Inicio,ot.Reserva_Cant_Noches+ot.Reserva_Fecha_Inicio,ha.idHabitacion,re.idRegimen,hu.idHuesped,ot.Reserva_Codigo,ho.idHotel		
from gd_esquema.Maestra ot
inner join mmel.Direccion di on ot.Hotel_Calle=di.calle and ot.Hotel_Nro_Calle=di.nroCalle
inner join mmel.Hotel ho on di.idDireccion=ho.idDireccion
inner join mmel.RegimenesPorHotel rph on rph.idHotel=ho.idHotel
inner join mmel.Regimen re on re.Descripcion=ot.Regimen_Descripcion
inner join mmel.Persona pe on pe.Apellido=ot.Cliente_Apellido and pe.NroDocumento=ot.Cliente_Pasaporte_Nro  
--inner join mmel.Usuarios us on us.idPersona=pe.idPersona
inner join mmel.Habitacion ha on ot.Habitacion_Numero=ha.NumeroHabitacion and ho.idHotel=ha.idHotel
inner join mmel.Huesped hu on hu.idPersona = pe.idPersona
*/
/*

insert into mmel.ReservaPorHabitacion(idReserva,idHabitacion)
select distinct re.idReserva,ha.idHabitacion from
*/

insert into mmel.Reserva(CodigoReserva,EstadoReserva)
select distinct ot.Reserva_Codigo,'CO' from gd_esquema.Maestra ot
where Reserva_Fecha_Inicio > GETDATE() and Estadia_Fecha_Inicio is null and ot.Reserva_Codigo not in( select distinct ot2.Reserva_Codigo from gd_esquema.Maestra ot2 where ot2.Factura_Nro is not null ) 


insert into mmel.Reserva(CodigoReserva,EstadoReserva)
select distinct ot.Reserva_Codigo,'CXNS' from gd_esquema.Maestra ot
where Reserva_Fecha_Inicio < GETDATE() and Estadia_Fecha_Inicio is null and ot.Reserva_Codigo not in( select distinct ot2.Reserva_Codigo from gd_esquema.Maestra ot2 where ot2.Factura_Nro is not null )

insert into mmel.Reserva(CodigoReserva,EstadoReserva)
select distinct ot.Reserva_Codigo,'RCI' from gd_esquema.Maestra ot
where Estadia_Fecha_Inicio < GETDATE() and (Estadia_Fecha_Inicio+Estadia_Cant_Noches+1)>GETDATE() and ot.Reserva_Codigo not in( select distinct ot2.Reserva_Codigo from gd_esquema.Maestra ot2 where ot2.Factura_Nro is not null )

insert into mmel.Reserva(CodigoReserva,EstadoReserva)
select distinct  ot.Reserva_Codigo,'RCICF' from gd_esquema.Maestra ot
where Estadia_Fecha_Inicio < GETDATE() and (Estadia_Fecha_Inicio+Estadia_Cant_Noches+1)>GETDATE() and ot.Reserva_Codigo  in( select distinct ot2.Reserva_Codigo from gd_esquema.Maestra ot2 where ot2.Factura_Nro is not null )

insert into mmel.Reserva(CodigoReserva,EstadoReserva)
select distinct ot.Reserva_Codigo,'RINCF' from gd_esquema.Maestra ot
where (Estadia_Fecha_Inicio)>GETDATE() and ot.Reserva_Codigo  in( select distinct ot2.Reserva_Codigo from gd_esquema.Maestra ot2 where ot2.Factura_Nro is not null ) order by Reserva_Codigo


insert into mmel.Reserva(CodigoReserva,EstadoReserva)
select distinct ot.Reserva_Codigo,'RF' from gd_esquema.Maestra ot
where (Estadia_Fecha_Inicio+Estadia_Cant_Noches+1)<GETDATE() and ot.Reserva_Codigo  in( select distinct ot2.Reserva_Codigo from gd_esquema.Maestra ot2 where ot2.Factura_Nro is not null )

update mmel.Reserva 
set 
FechaDesde = ot1.Reserva_Fecha_Inicio,
FechaHasta=ot1.Reserva_Fecha_Inicio+ot1.Reserva_Cant_Noches,
idHabitacion = ha.idHabitacion,
idRegimen=re.idRegimen,
idHuesped=pe.idPersona,
idHotel = ho.idHotel
from gd_esquema.Maestra ot1,mmel.Hotel ho,mmel.Direccion di,mmel.Habitacion ha,mmel.Regimen re,mmel.Persona pe
where ho.idDireccion=di.idDireccion 
and di.calle=ot1.Hotel_Calle
and di.nroCalle = ot1.Hotel_Nro_Calle
and ha.idHotel=ho.idHotel
and ot1.Regimen_Descripcion = re.Descripcion
and CodigoReserva=ot1.Reserva_Codigo
and ot1.Habitacion_Numero = ha.NumeroHabitacion
and pe.Apellido=ot1.Cliente_Apellido
and pe.NroDocumento=ot1.Cliente_Pasaporte_Nro
and pe.Mail=ot1.Cliente_Mail



--hay campos en q fehca inicio y cant noches son nulos , no los pongo pero revisar...
insert into mmel.Estadia (idReserva,FechaCheckIN,FechaCheckOUT)
select distinct re.idReserva,ot.Estadia_Fecha_Inicio,ot.Estadia_Fecha_Inicio+Estadia_Cant_Noches from gd_esquema.Maestra ot
inner join mmel.Reserva re on re.CodigoReserva = ot.Reserva_Codigo
where ot.Estadia_Fecha_Inicio is not null


update mmel.Estadia
set Consistente = case
when FechaCheckIN < getdate() and FechaCheckOUT < getdate () then 'S'
when FechaCheckIN > getdate() or FechaCheckOUT > GETDATE() then 'N'
end


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


-----------------FIN MIGRACION-------------



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HabitacionesListar]'))
	DROP PROCEDURE [MMEL].[HabitacionesListar]
go

create PROCEDURE [MMEL].[HabitacionesListar]
	-- Add the parameters for the stored procedure here
	@IdTipoHabitacion int,
    @NumeroHabitacion int,
    @IdHotel int,
    @Piso int,
    @VistaAlExterior char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	PRINT @IdTipoHabitacion
	PRINT @NumeroHabitacion
	PRINT @IdHotel
	PRINT @Piso
	PRINT @VistaAlExterior
	SELECT idHabitacion,
	[NumeroHabitacion],
	[Piso],
	hab.[idHotel],
	[VistaAlExterior],
	hab.[idTipoHabitacion],
	Descripcion,
	Habilitado
	FROM [MMEL].[Habitacion] hab   
	
	WHERE   
 (@Piso is NULL OR (@Piso = piso))and
  (@VistaAlExterior is NULL OR           (@VistaAlExterior = VistaAlExterior))and
 (@NumeroHabitacion is NULL OR (@NumeroHabitacion = hab.NumeroHabitacion)) and
 (@IdHotel is NULL OR (@IdHotel = hab.IdHotel))  and
(@IdTipoHabitacion is NULL OR( @IdTipoHabitacion = hab.idTipoHabitacion))
END

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HabitacionesAlta]'))
	DROP PROCEDURE [MMEL].[HabitacionesAlta]
go



create PROCEDURE [MMEL].[HabitacionesAlta]
					@IdTipoHabitacion int,
                    @NumeroHabitacion int,
                    @IdHotel int,
                    @Piso int,
                    @VistaAlExterior char(1),
                    @Descripcion nvarchar(80),
                    @Habilitado char(1),
					@MESSAGE int OUTPUT
AS
    SET NOCOUNT ON 
	SET XACT_ABORT ON  
	DECLARE @ExisteHotel int
	DECLARE @ExisteTipoHabitacion int
	SELECT @ExisteTipoHabitacion = idTipoHabitacion FROM mmel.TipoHabitacion where @IdTipoHabitacion=idTipoHabitacion
	SELECT @ExisteHotel = hot.idHotel FROM mmel.Hotel hot where @IdHotel = hot.idHotel
	DECLARE @AUX int
	PRINT @ExisteHotel
	PRINT @ExisteTipoHabitacion
	print @AUX
	IF @ExisteHotel != 0 AND @ExisteTipoHabitacion!=0  
	BEGIN
		if NOT exists (SELECT idHabitacion FROM mmel.Habitacion where @IdTipoHabitacion = [idTipoHabitacion] AND 
	 @NumeroHabitacion = [NumeroHabitacion] AND 
	 @IdHotel=[idHotel] AND  
	 @Piso= [Piso] AND 
	 @VistaAlExterior= [VistaAlExterior] AND
	 @Habilitado = [Habilitado] AND
	 @Descripcion = [Descripcion])
	 BEGIN
	SET @MESSAGE = 1
	PRINT @MESSAGE
	BEGIN TRAN
	INSERT INTO [MMEL].[Habitacion] ([idTipoHabitacion], [NumeroHabitacion],[idHotel], [Piso],[VistaAlExterior],[Descripcion],[Habilitado])
	SELECT @IdTipoHabitacion,
                   @NumeroHabitacion ,
                   @IdHotel ,
                   @Piso ,
                   @VistaAlExterior ,
                   @Descripcion ,
                   @Habilitado 
	COMMIT
	END
	ELSE
	BEGIN
	SET @MESSAGE = 0
	PRINT @MESSAGE
	END
	END
	ELSE
	BEGIN
	SET @MESSAGE = 0
	PRINT @MESSAGE
	END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HabitacionesBaja]'))
	DROP PROCEDURE [MMEL].[HabitacionesBaja]


GO
create PROCEDURE [MMEL].[HabitacionesBaja]
					@IdTipoHabitacion int,
                    @NumeroHabitacion int,
                    @IdHotel int,
                    @Piso int,
                    @VistaAlExterior char(1),
				@MESSAGE int OUTPUT
					
AS
SET NOCOUNT ON 
	SET XACT_ABORT ON  
	DECLARE @HabitacionABorrar int
	SELECT  @HabitacionABorrar=h.idHabitacion FROM [MMEL].[Habitacion] h join [MMEL].[Reserva] r on h.idHabitacion=r.idHabitacion where @IdTipoHabitacion = [idTipoHabitacion] AND 
	 @NumeroHabitacion = [NumeroHabitacion] AND @IdHotel=h.[idHotel] AND  @Piso= [Piso] AND @VistaAlExterior= [VistaAlExterior]  --le agregue h a idHotel xq no andaba.. calculoq  esta bien
	PRINT @HabitacionABorrar 
	
	IF @HabitacionABorrar = NULL
	BEGIN
	BEGIN TRAN
	DELETE FROM [MMEL].[Habitacion] WHERE  @IdTipoHabitacion = [idTipoHabitacion] AND 
	 @NumeroHabitacion = [NumeroHabitacion] AND @IdHotel=[idHotel] AND  @Piso= [Piso] AND @VistaAlExterior= [VistaAlExterior] 
		SET @MESSAGE = 1
	COMMIT
	END
	ELSE
	BEGIN
	SET @MESSAGE = 0
	print @MESSAGE

	END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HabitacionesModificar]'))
	DROP PROCEDURE [MMEL].[HabitacionesModificar]

go


create PROCEDURE [MMEL].[HabitacionesModificar]
@IdTipoHabitacion int,
                   @NumeroHabitacion int,
                    @IdHotel int,
                   @Piso int,
                   @VistaAlExterior char(1),
                   @Descripcion nvarchar(80),
                   @Habilitado char(1)
AS
SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	UPDATE  [MMEL].[Habitacion]  
	SET [idTipoHabitacion] =  @IdTipoHabitacion , 
	 [NumeroHabitacion] = @NumeroHabitacion  ,
	 [idHotel] =  @IdHotel , 
	 [Piso] = @Piso,
	 [VistaAlExterior]= @VistaAlExterior,
	 [Descripcion] = @Descripcion,
	 [Habilitado] = @Habilitado
	
               
	COMMIT
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionDelete]'))
	DROP PROCEDURE [MMEL].DireccionDelete

go


/****** Object:  StoredProcedure [MMEL].[DireccionDelete]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[DireccionDelete] 
    @idDireccion int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [MMEL].[Direccion]
	WHERE  [idDireccion] = @idDireccion

	COMMIT
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionInsert]'))
	DROP PROCEDURE [MMEL].DireccionInsert
go

/****** Object:  StoredProcedure [MMEL].[DireccionInsert]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[DireccionInsert] 
    @calle nvarchar(150) = NULL,
    @nroCalle int = NULL,
    @idPais int = NULL,
    @Ciudad nvarchar(150) = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [MMEL].[Direccion] ([calle], [nroCalle], [idPais], [Ciudad])
	SELECT @calle, @nroCalle, @idPais, @Ciudad
	
	SELECT [idDireccion], [calle], [nroCalle], [idPais], [Ciudad]
	FROM   [MMEL].[Direccion]
	WHERE  [idDireccion] = SCOPE_IDENTITY()
               
	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionSelect]'))
	DROP PROCEDURE [MMEL].DireccionSelect
go


/****** Object:  StoredProcedure [MMEL].[DireccionSelect]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[DireccionSelect] 
    @idDireccion int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idDireccion], [calle], [nroCalle], [idPais], [Ciudad] 
	FROM   [MMEL].[Direccion] 
	WHERE  ([idDireccion] = @idDireccion OR @idDireccion IS NULL) 

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionUpdate]'))
	DROP PROCEDURE [MMEL].DireccionUpdate
go

/****** Object:  StoredProcedure [MMEL].[DireccionUpdate]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[DireccionUpdate] 
    @idDireccion int,
    @calle nvarchar(150) = NULL,
    @nroCalle int = NULL,
    @idPais int = NULL,
    @Ciudad nvarchar(150) = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [MMEL].[Direccion]
	SET    [calle] = @calle, [nroCalle] = @nroCalle, [idPais] = @idPais, [Ciudad] = @Ciudad
	WHERE  [idDireccion] = @idDireccion
	
	SELECT [idDireccion], [calle], [nroCalle], [idPais], [Ciudad]
	FROM   [MMEL].[Direccion]
	WHERE  [idDireccion] = @idDireccion	

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[FuncionalidadesDeRol]'))
	DROP PROCEDURE [MMEL].FuncionalidadesDeRol
go

/****** Object:  StoredProcedure [MMEL].[FuncionalidadesDeRol]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[FuncionalidadesDeRol] 
	@idRol int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT f.idFuncionalidad, f.Descripcion
	FROM   [MMEL].[RolesPorFuncionalidades] rpf
	JOIN   [Funcionalidades] f on f.idFuncionalidad = rpf.idFuncionalidad
	WHERE @idRol = rpf.idRol

	COMMIT
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[FuncionalidadesListar]'))
	DROP PROCEDURE [MMEL].FuncionalidadesListar
go

/****** Object:  StoredProcedure [MMEL].[FuncionalidadesListar]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [MMEL].[FuncionalidadesListar] 
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idFuncionalidad], [Descripcion] 
	FROM   [MMEL].[Funcionalidades] 

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelCrear]'))
	DROP PROCEDURE [MMEL].HotelCrear
go

/****** Object:  StoredProcedure [MMEL].[HotelCrear]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [MMEL].[HotelCrear] 
    @Mail varchar(200),
    @calle varchar(200),
	@nrocalle int,
	@idPais int,
	@ciudad varchar(200),
    @Telefono varchar(20),
    @CantidadEstrellas int,
    @Nombre varchar(100),
	@idAdmin int,
    @Inhabilitado bit = NULL

AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	INSERT INTO [MMEL].[Direccion] ([calle], [nroCalle], [idPais], [Ciudad])
	SELECT @calle, @nroCalle, @idPais, @Ciudad
	
	DECLARE @idDireccion int = SCOPE_IDENTITY();

	DECLARE @rol [varchar](50);

	SELECT @rol = Nombre FROM Rol r JOIN UsuariosPorRoles upr on upr.idRol = r.idRol WHERE upr.idUsuario = @idAdmin 
	
	IF @rol != 'administrador'
		THROW 51000, 'El usuario no es administrador', 1; 

	INSERT INTO [MMEL].[Hotel] ([Mail], [idDireccion], [Telefono], [CantidadEstrellas], [FechaDeCreacion], [Nombre], [Inhabilitado] )
	SELECT @Mail, @idDireccion, @Telefono, @CantidadEstrellas, GETDATE(), @Nombre, @Inhabilitado
	

	DECLARE @idHotel int  =  SCOPE_IDENTITY();

	INSERT INTO [MMEL].[HotelesPorUsuarios]
           ([idUsuario]
           ,[idHotel])
     VALUES
			(@idAdmin,
			@idHotel)

	SELECT SCOPE_IDENTITY() as Id

               
	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelDelete]'))
	DROP PROCEDURE [MMEL].HotelDelete
go

/****** Object:  StoredProcedure [MMEL].[HotelDelete]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[HotelDelete] 
    @idHotel int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [MMEL].[Hotel]
	SET    [Hotel].Inhabilitado = 1
	WHERE  [idHotel] = @idHotel

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesDeUsuario]'))
	DROP PROCEDURE [MMEL].HotelesDeUsuario
go


/****** Object:  StoredProcedure [MMEL].[HotelesDeUsuario]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[HotelesDeUsuario] 
    @idUsuario int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT h.idHotel, h.Nombre
	FROM   [MMEL].[HotelesPorUsuarios] hpu
	JOIN	[MMEL].[Hotel] h ON h.idHotel =  hpu.idHotel
	WHERE  (@idUsuario = hpu.idUsuario) 

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelListar]'))
	DROP PROCEDURE [MMEL].HotelListar
go


/****** Object:  StoredProcedure [MMEL].[HotelListar]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [MMEL].[HotelListar]  
    @Nombre nvarchar(50),   
    @CantidadEstrellas int,
    @Ciudad nvarchar(150),
    @idPais int
AS   

    SET NOCOUNT ON;  

    SELECT * 
    FROM MMEL.Hotel ho
    LEFT JOIN MMEL.DireccionPais dir on ho.idDireccion = dir.idDireccion
    WHERE (@Nombre is null or Nombre LIKE '%' + @Nombre + '%')
            and (@CantidadEstrellas is null or ho.CantidadEstrellas = @CantidadEstrellas)
            and (@Ciudad is null or dir.Ciudad LIKE '%' + @Ciudad + '%')
            and (@idPais = 0 or dir.idPais = @idPais)


GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelUpdate]'))
	DROP PROCEDURE [MMEL].HotelUpdate
go

/****** Object:  StoredProcedure [MMEL].[HotelUpdate]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[HotelUpdate] 
    @idHotel int,
    @Mail varchar(200) = NULL,
    @idDireccion int = NULL,
    @Telefono varchar(20) = NULL,
	@calle nvarchar(150) = NULL,
    @nroCalle int = NULL,
    @idPais int = NULL,
    @Ciudad nvarchar(150) = NULL,
    @CantidadEstrellas int = NULL,
    @Nombre varchar(100) = NULL,
    @Inhabilitado bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [MMEL].[Hotel]
	SET    [Mail] = @Mail, [Telefono] = @Telefono, [CantidadEstrellas] = @CantidadEstrellas, [Nombre] = @Nombre, [Inhabilitado] = @Inhabilitado
	WHERE  [idHotel] = @idHotel
	
	UPDATE [MMEL].[Direccion]
	SET    [calle] = @calle, [nroCalle] = @nroCalle, [idPais] = @idPais, [Ciudad] = @Ciudad
	WHERE  [idDireccion] = @idDireccion

	SELECT [idHotel]
	FROM   [MMEL].[Hotel]
	WHERE  [idHotel] = @idHotel	

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Logear]'))
	DROP PROCEDURE [MMEL].Logear
go

/****** Object:  StoredProcedure [MMEL].[Logear]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MMEL].[Logear]
	-- Add the parameters for the stored procedure here
	@usuario nvarchar(200),
	@contrasenia nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @wrongPasswordReturn int = -1
	DECLARE @blockedReturn int = -2
	DECLARE @noHabilitadoReturn int = -3
	DECLARE @rightPassword nvarchar(200)
	DECLARE @habilitado char(1)

	SELECT @rightPassword = Contraseña, @habilitado = Activo FROM MMEL.Usuarios WHERE Username = @usuario

	IF @habilitado = 'N'
		SELECT @noHabilitadoReturn AS id
	ELSE
		IF @rightPassword != @contrasenia
			BEGIN 
		
				DECLARE @ingresosFallidos int   
				UPDATE MMEL.Usuarios SET [IngresosFallidos] = [IngresosFallidos] + 1 WHERE Username = @usuario
				SELECT @ingresosFallidos = [IngresosFallidos] FROM MMEL.Usuarios WHERE Username = @usuario

				IF @ingresosFallidos = 3
					BEGIN
						UPDATE MMEL.Usuarios SET [Activo] = 'N' WHERE Username = @usuario -- Deshabilito al usuario
						SELECT @blockedReturn AS id	
					END
				ELSE
					SELECT @wrongPasswordReturn AS id
			END
		ELSE
			SELECT idUsuario AS id FROM MMEL.Usuarios WHERE Username = @usuario
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[PaisListar]'))
	DROP PROCEDURE [MMEL].PaisListar
go



/****** Object:  StoredProcedure [MMEL].[PaisListar]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[PaisListar]
    @idPais int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idPais], [Nombre] 
	FROM   [MMEL].[Pais] 
	WHERE  ([idPais] = @idPais OR @idPais IS NULL) 

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RolCrear]'))
	DROP PROCEDURE [MMEL].RolCrear
go

/****** Object:  StoredProcedure [MMEL].[RolCrear]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[RolCrear] 
    @Nombre varchar(50),
	@funcionalidades_ids IdList READONLY,
    @Activo char(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [MMEL].[Rol] ([Nombre], [Activo])
	SELECT @Nombre, @Activo
	
	DECLARE @idRol int = SCOPE_IDENTITY();

	DECLARE @FuncionalidadId int

	DECLARE CURSOR_FUNCIONALIDADES CURSOR 
	  LOCAL STATIC READ_ONLY FORWARD_ONLY
	FOR 
	SELECT DISTINCT Id 
	FROM @funcionalidades_ids

	OPEN CURSOR_FUNCIONALIDADES
	FETCH NEXT FROM CURSOR_FUNCIONALIDADES INTO @FuncionalidadId
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		--Do something with Id here
		INSERT INTO MMEL.RolesPorFuncionalidades (idRol,idFuncionalidad)
		VALUES (@idRol,@FuncionalidadId)

		FETCH NEXT FROM CURSOR_FUNCIONALIDADES INTO @FuncionalidadId
	END
	CLOSE CURSOR_FUNCIONALIDADES
	DEALLOCATE CURSOR_FUNCIONALIDADES

	-- Begin Return Select <- do not remove
	SELECT [idRol], [Nombre], [Activo]
	FROM   [MMEL].[Rol]
	WHERE  [idRol] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RolesDeUsuario]'))
	DROP PROCEDURE [MMEL].RolesDeUsuario
go

/****** Object:  StoredProcedure [MMEL].[RolesDeUsuario]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MMEL].[RolesDeUsuario]
	-- Add the parameters for the stored procedure here
	@idUsuario int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [idUsuario]
      ,[Username]
      ,[idRol]
      ,[Nombre]
	 FROM [MMEL].[RolesPorUsuario]
	 WHERE idUsuario = @idUsuario
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RolesListar]'))
	DROP PROCEDURE [MMEL].RolesListar
go

/****** Object:  StoredProcedure [MMEL].[RolesListar]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[RolesListar] 
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idRol], [Nombre], [Activo] 
	FROM   [MMEL].[Rol] 

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RolModificar]'))
	DROP PROCEDURE [MMEL].RolModificar
go

/****** Object:  StoredProcedure [MMEL].[RolModificar]    Script Date: 16/6/2018 16:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[RolModificar] 
    @idRol int,
    @Nombre varchar(50),
	@funcionalidades_ids IdList READONLY,
    @Activo char(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [MMEL].[Rol]
	SET    [Nombre] = @Nombre, [Activo] = @Activo
	WHERE  [idRol] = @idRol
	
	DELETE FROM MMEL.RolesPorFuncionalidades
	WHERE idRol = @idRol

	DECLARE @FuncionalidadId int

	DECLARE CURSOR_FUNCIONALIDADES CURSOR 
	  LOCAL STATIC READ_ONLY FORWARD_ONLY
	FOR 
	SELECT DISTINCT Id 
	FROM @funcionalidades_ids

	OPEN CURSOR_FUNCIONALIDADES
	FETCH NEXT FROM CURSOR_FUNCIONALIDADES INTO @FuncionalidadId
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		--Do something with Id here
		INSERT INTO MMEL.RolesPorFuncionalidades (idRol,idFuncionalidad)
		VALUES (@idRol,@FuncionalidadId)

		FETCH NEXT FROM CURSOR_FUNCIONALIDADES INTO @FuncionalidadId
	END
	CLOSE CURSOR_FUNCIONALIDADES
	DEALLOCATE CURSOR_FUNCIONALIDADES

	-- Begin Return Select <- do not remove
	SELECT [idRol], [Nombre], [Activo]
	FROM   [MMEL].[Rol]
	WHERE  [idRol] = @idRol	
	-- End Return Select <- do not remove

	COMMIT
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[MMEL].[RolesPorUsuario]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [MMEL].[RolesPorUsuario]
AS
SELECT        MMEL.Usuarios.idUsuario, MMEL.Usuarios.Username, MMEL.Rol.idRol, MMEL.Rol.Nombre
FROM            MMEL.Rol INNER JOIN
                         MMEL.UsuariosPorRoles ON MMEL.Rol.idRol = MMEL.UsuariosPorRoles.idRol INNER JOIN
                         MMEL.Usuarios ON MMEL.UsuariosPorRoles.idUsuario = MMEL.Usuarios.idUsuario
' 
GO









IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[AgregarCliente]'))
	DROP PROCEDURE [MMEL].AgregarCliente
go

create procedure mmel.AgregarCliente (@nombre varchar(50),@apellido varchar(50),@tipoDocumento varchar(15),@nroDocumento nvarchar(25),@mail varchar(200),@telefono varchar(20),
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


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[existeCliente]'))
	DROP function [MMEL].existeCliente
go


create function mmel.existeCliente(@tipodoc varchar(15),@nrodoc int,@mail varchar(200))
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


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[clienteErroneo]'))
	DROP function [MMEL].clienteErroneo
go
create function mmel.clienteErroneo(@idPersona int)
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


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[esErroneo]'))
	DROP procedure [MMEL].esErroneo
go

create procedure mmel.esErroneo(@idPersona int,@codigoRet int output)
as
begin
	if exists (SELECT distinct  * FROM mmel.Persona p1 inner join mmel.Persona p2 on p1.idPersona =@idPersona and  p1.idPersona <>p2.idPersona and p1.Mail=p2.Mail)
	begin  set @codigoRet = 1 end --hay un conflicto con mail duplicado --> dejo uno con ese mail y el otro borro el mail pero no el usuario.
	else if exists(SELECT distinct  * FROM mmel.Persona p1 inner join mmel.Persona p2 on p1.idPersona =@idPersona and p1.idPersona <>p2.idPersona and p1.NroDocumento=p2.NroDocumento and p1.idTipoDocumento=p2.idTipoDocumento)
	begin set @codigoRet = 2 end --existe el mismo nro de id para cliente c distinto mail. --> unificar todo al mismo mail y elegir nueva direccioncalle y demas
	else begin set @codigoRet = 0 end
end
go


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[removerEmail]'))
	DROP procedure [MMEL].removerEmail
go



create procedure mmel.removerEmail(@idPersona int)

as
begin
	update mmel.Persona
	set Mail=null where idPersona=@idPersona
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[removerPasaporte]'))
	DROP procedure [MMEL].removerPasaporte
go




create procedure mmel.removerPasaporte(@idPersona int)
as
begin
	update mmel.Persona
	set NroDocumento=null where idPersona=@idPersona
end

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[modificarCliente]'))
	DROP procedure [MMEL].modificarCliente
go

create procedure mmel.modificarCliente(@idPersona int,@nombre varchar(50),@apellido varchar(50),@tipoDocumento varchar(15),@nroDocumento nvarchar(25),@mail varchar(200),@telefono varchar(20),
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[existeClienteModif]'))
	DROP function [MMEL].existeClienteModif
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[borrarCliente]'))
	DROP procedure [MMEL].borrarCliente
go


create procedure mmel.borrarCliente(@idCliente int)
as
begin
	update mmel.Huesped
	set Habilitado ='N' where idPersona=@idCliente
end


go


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[obtenerDisponibilidad]'))
	DROP procedure [MMEL].obtenerDisponibilidad
go




create PROCEDURE MMEL.obtenerDisponibilidad(@fechaDesde datetime, @fechaHasta datetime,@idHotel int,@tipoHabDesc nvarchar(200))
AS
BEGIN
    
	declare @idRegimen int
	declare @idTipoHab int
	set @idTipoHab = (select top 1 idTipoHabitacion from mmel.TipoHabitacion where Descripcion=@tipoHabDesc)

		select * from mmel.habitacion where idHabitacion not in 
		(SELECT h.idHabitacion  FROM MMEL.Habitacion h
		join mmel.Reserva r on h.idHotel=r.idHotel and h.idHabitacion=r.idHabitacion
		WHERE	h.idHotel=@idHotel AND					
								(	
									( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
									( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
									( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)
						
								) 
		) and idHotel = @idHotel and idTipoHabitacion=@idTipoHab

	
END
GO	

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[hayDisponibilidad]'))
	DROP procedure [MMEL].hayDisponibilidad
go



create PROCEDURE MMEL.hayDisponibilidad(@fechaDesde datetime, @fechaHasta datetime,@idHotel int,@tipoHabDesc nvarchar(200),@rta int output)
AS
BEGIN
    
	declare @idRegimen int
	declare @idTipoHab int
	set @idTipoHab = (select top 1 idTipoHabitacion from mmel.TipoHabitacion where Descripcion=@tipoHabDesc)

		if exists(
			select * from mmel.habitacion where idHabitacion not in 
				(SELECT h.idHabitacion  FROM MMEL.Habitacion h
				join mmel.Reserva r on h.idHotel=r.idHotel and h.idHabitacion=r.idHabitacion
				WHERE	h.idHotel=@idHotel AND					
										(	
											( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
											( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
											( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)
						
										) 
			) and idHotel = @idHotel and idTipoHabitacion=@idTipoHab
		) begin set @rta = 1 end
		else begin set @rta=0 end


	
END
GO		

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[identificarClienteMail]'))
	DROP procedure [MMEL].identificarClienteMail
go


create procedure mmel.identificarClienteMail(@mail varchar(200), @codigoRet int output)
as
begin
	select count(*) from mmel.Persona p,mmel.Huesped hu where p.Mail=@mail and hu.Habilitado='S' and p.idPersona=hu.idPersona
	IF @@ROWCOUNT = 1 
	BEGIN 
		set @codigoRet = 1
	end
	else if @@ROWCOUNT>1
	begin
		set @codigoRet=2
	end
	else 
	begin
		set @codigoRet=0
	end
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[identificarClienteIdent]'))
	DROP procedure [MMEL].identificarClienteIdent
go



create procedure mmel.identificarClienteIdent(@tipoId varchar(30),@nroId varchar(25), @codigoRet int output)
as
begin
	select count(*) from mmel.Persona p,mmel.Huesped hu,mmel.TipoDocumento td where p.NroDocumento=@nroId and td.detalle = @tipoId and p.idPersona=hu.idPersona and hu.Habilitado='S'
	IF @@ROWCOUNT = 1 
	BEGIN 
		set @codigoRet = 1
	end
	else if @@ROWCOUNT>1
	begin
		set @codigoRet=2
	end
	else 
	begin
		set @codigoRet=0
	end
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[getCodigoReserva]'))
	DROP function [MMEL].getCodigoReserva
go


create function mmel.getCodigoReserva()
returns int
as
begin
	declare @codret int
	set @codret = (select (max(CodigoReserva)+1) from mmel.Reserva)
	return @codret
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[reservar]'))
	DROP procedure [MMEL].reservar
go


create procedure mmel.reservar(@fechaDeReserva datetime,@idUsuarioQueReserva int,@fechaDesde datetime,@fechaHasta datetime,@idHotel int,@tipoHabDesc varchar(100),@tipoRegimenDesc varchar(100),@idPersona int, @codReserva int output)
as
begin
	
	declare @idHabitacion int
	declare @idRegimen int
	declare @idHuesped int
	
	declare @idTipoHab int
	set @idUsuarioQueReserva = 1 --todo
	set @idTipoHab = (select top 1 idTipoHabitacion from mmel.TipoHabitacion where Descripcion=@tipoHabDesc)
	set @idRegimen = (select top 1 idRegimen from mmel.Regimen where Descripcion=@tipoRegimenDesc)
	set @codReserva = mmel.getCodigoReserva()
	set @idHuesped=(select top 1 idHuesped from mmel.Huesped where idPersona=@idPersona)
	set @idHabitacion = 
		(select top 1 idHabitacion from mmel.habitacion where idHabitacion not in 
				(SELECT h.idHabitacion  FROM MMEL.Habitacion h
					join mmel.Reserva r on h.idHotel=r.idHotel and h.idHabitacion=r.idHabitacion
					WHERE	h.idHotel=@idHotel AND					
						(	
							( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
							( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
							( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)
						) 
				)
				and idHotel = @idHotel and idTipoHabitacion=@idTipoHab
		)

	insert into mmel.Reserva(idUsuarioQueProcesoReserva,idHotel,FechaDeReserva,FechaDesde,FechaHasta,idHabitacion,idRegimen,idHuesped,CodigoReserva,EstadoReserva)
	values(@idUsuarioQueReserva,@idHotel,@fechaDeReserva,@fechaDesde,@fechaHasta,@idHabitacion,@idRegimen,@idHuesped,@codReserva,'C')
	
	
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[resolverInconsistencia]'))
	DROP procedure [MMEL].resolverInconsistencia
go



create procedure mmel.resolverInconsistencia(@idPersona int)
as
begin
	
	declare @mail varchar(200)
	declare @nroDoc varchar(25)

	(select @mail=mail,@nroDoc=NroDocumento from mmel.Persona where idPersona=@idPersona)
	
	update mmel.Persona
	set Mail = null  where idPersona <> @idPersona and mail=@mail
	update mmel.Persona
	set nroDocumento=null where idPersona <> @idPersona and nroDocumento=@nroDoc 

	update mmel.PersonasInconsistentes
	set Mail = null  where idPersona <> @idPersona and mail=@mail
	update mmel.PersonasInconsistentes
	set nroDocumento=null where idPersona <> @idPersona and nroDocumento=@nroDoc 

end

go


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[cancelarReserva]'))
	DROP procedure [MMEL].cancelarReserva
go

create procedure mmel.cancelarReserva(@codigoRes int,@motivo varchar(300),@idRol int,@fecha datetime,@cancelPor int )
as
begin
	
	declare @idPersona int
	declare @idReserva int
	--declare @idRol int
	
	select @idPersona=hu.idPersona,@idReserva=re.idReserva from mmel.Reserva re ,mmel.Huesped hu  where re.CodigoReserva=@codigoRes and hu.idHuesped=re.idHuesped
	
	--select @idRol = idRol from mmel.Rol where Nombre=@rol

	insert into mmel.CancelacionReserva(Motivo,FechaDeCancelacion,idPersona,idReserva,idRol)
	values(@motivo,@fecha,@idPersona,@idReserva,@idRol)

	--si @cancelPor = 1 -> cancelo recep ; =2 cancel cliente

	update mmel.Reserva
	set EstadoReserva = 
	case 
		when @cancelPor=1 then 'C'
		when @cancelPor=2 then 'D'
	end
	where CodigoReserva=@codigoRes
	--estados de reserva : a->correcta  ; b->modificada;c->cancel x recep;d->cancel x cliente ; e->cancel x no show  ;  f->res c ingreso

end
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[existeReserva]'))
	DROP procedure [MMEL].existeReserva
go
create procedure mmel.existeReserva(@codigoRes int, @ret int output)
as
begin
	
	if exists(select * from mmel.Reserva where CodigoReserva=@codigoRes)
		set @ret=1 
	else 
		set @ret = 0
end
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[actualizarCheckIn]'))
	DROP procedure [MMEL].actualizarCheckIn
go

create procedure actualizarCheckIn (@idEstadia int, @fechaCheckIn datetime,@userQueModifica varchar(200))
as
begin
	declare @idRecepQueModifica int
	set @idRecepQueModifica=3 --cambiar!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
	update mmel.Estadia
	set FechaCheckIN = @fechaCheckIn,
	idRecepcionistaCheckIN=@idRecepQueModifica,
	FechaCheckOUT= case
		when Consistente = 'N' then null else FechaCheckOUT 
	end,
	Consistente='S'
	where idEstadia=@idEstadia
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[realizarCheckIn]'))
	DROP procedure [MMEL].realizarCheckIn
go

create procedure realizarCheckIn(@codigoRes int, @fechaCheckIn datetime,@userQueModifica varchar(200))
as
begin
	
	declare @idRecepQueModifica int
	declare @idReserva int
	set @idRecepQueModifica=3 --cambiar!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
	select @idReserva=idReserva from mmel.Reserva where CodigoReserva=@codigoRes
	insert into mmel.Estadia(FechaCheckIN,idRecepcionistaCheckIN,idReserva,Consistente)
	values(@fechaCheckIn,@idRecepQueModifica,@idReserva,'S')
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[actualizarCheckOut]'))
	DROP procedure [MMEL].actualizarCheckOut
go


create procedure actualizarCheckOut (@idEstadia int,@fechaCheckOut datetime,@userQueModifica varchar(200))
as
begin
	declare @idRecepQueModificaCOUT int
	set @idRecepQueModificaCOUT=3 --cambiar!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
	

	update mmel.Estadia
	set FechaCheckOut = @fechaCheckOut,
	idRecepcionistaCheckOUT=@idRecepQueModificaCOUT
	where idEstadia=@idEstadia
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ReservasPorHotelYHabitacion]'))
	DROP VIEW [MMEL].[ReservasPorHotelYHabitacion]
GO

CREATE VIEW [MMEL].[ReservasPorHotelYHabitacion]
AS
SELECT        MMEL.Habitacion.idHabitacion, MMEL.Hotel.idHotel, MMEL.Reserva.idReserva, MMEL.Reserva.FechaDesde, MMEL.Reserva.FechaHasta, MMEL.Habitacion.NumeroHabitacion, MMEL.Habitacion.Piso, MMEL.Hotel.Nombre, 
                         MMEL.Reserva.EstadoReserva, DATEDIFF(day, MMEL.Reserva.FechaDesde,MMEL.Reserva.FechaHasta) as Dias
FROM            MMEL.Habitacion INNER JOIN
                         MMEL.Hotel ON MMEL.Habitacion.idHotel = MMEL.Hotel.idHotel INNER JOIN
                         MMEL.Reserva ON MMEL.Habitacion.idHabitacion = MMEL.Reserva.idHabitacion AND MMEL.Hotel.idHotel = MMEL.Reserva.idHotel
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HabitacionesConMayorCantidadDeVecesOcupadas]'))
	DROP PROCEDURE [MMEL].[HabitacionesConMayorCantidadDeVecesOcupadas]
GO

CREATE PROCEDURE [MMEL].[HabitacionesConMayorCantidadDeVecesOcupadas]
	@anio int, 
	@trimestre int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select *
	into #ReservasPorHotelYHabitacionEnAnio
	from MMEL.ReservasPorHotelYHabitacion rhh
	WHERE year(rhh.FechaDesde) = @anio OR year(rhh.FechaHasta) = @anio -- Contenidas en el anio

	DECLARE @firstMonth int;

	IF @trimestre = 1
		SET @firstMonth = 1;
	ELSE IF @trimestre = 2
		SET @firstMonth = 4;
	ELSE IF @trimestre = 3
		SET @firstMonth = 7;

	DECLARE @secondMonth int;
	DECLARE @thirdMonth int;

	SET @secondMonth = @firstMonth + 1;
	SET @thirdMonth = @firstMonth + 2;
	
	select *
	into #ReservasPorHotelYHabitacionEnTrimestreEnAnio
	from #ReservasPorHotelYHabitacionEnAnio rhh
	WHERE	(month(rhh.FechaDesde) = @firstMonth OR month(rhh.FechaHasta) = @firstMonth)
			OR (month(rhh.FechaDesde) = @secondMonth OR month(rhh.FechaHasta) = @secondMonth)
			OR (month(rhh.FechaDesde) = @thirdMonth OR month(rhh.FechaHasta) = @thirdMonth) -- O bien arrancaron o terminaron en el trimestre, o estan totalmente contenidas (arrancaron Y terminaron)
			 
	select rhhta.Nombre, rhhta.NumeroHabitacion, rhhta.Piso, count(*) as Veces
	from #ReservasPorHotelYHabitacionEnTrimestreEnAnio rhhta
	WHERE rhhta.EstadoReserva = 'RF' -- si la reserva no fue finalizada y facturada la ignoro
	GROUP BY rhhta.Nombre, rhhta.NumeroHabitacion, rhhta.Piso

END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HabitacionesConMayorCantidadDeDiasOcupadas]'))
	DROP PROCEDURE [MMEL].[HabitacionesConMayorCantidadDeDiasOcupadas]
GO

CREATE PROCEDURE [MMEL].[HabitacionesConMayorCantidadDeDiasOcupadas]
	@anio int, 
	@trimestre int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select *
	into #ReservasPorHotelYHabitacionEnAnio
	from MMEL.ReservasPorHotelYHabitacion rhh
	WHERE year(rhh.FechaDesde) = @anio OR year(rhh.FechaHasta) = @anio -- Contenidas en el anio

	DECLARE @firstMonth int;

	IF @trimestre = 1
		SET @firstMonth = 1;
	ELSE IF @trimestre = 2
		SET @firstMonth = 4;
	ELSE IF @trimestre = 3
		SET @firstMonth = 7;
	ELSE IF @trimestre = 4
		SET @firstMonth = 10;

	DECLARE @secondMonth int;
	DECLARE @thirdMonth int;

	SET @secondMonth = @firstMonth + 1;
	SET @thirdMonth = @firstMonth + 2;
	
	select *
	into #ReservasPorHotelYHabitacionEnTrimestreEnAnio
	from #ReservasPorHotelYHabitacionEnAnio rhh
	WHERE	(month(rhh.FechaDesde) = @firstMonth OR month(rhh.FechaHasta) = @firstMonth)
			OR (month(rhh.FechaDesde) = @secondMonth OR month(rhh.FechaHasta) = @secondMonth)
			OR (month(rhh.FechaDesde) = @thirdMonth OR month(rhh.FechaHasta) = @thirdMonth) -- O bien arrancaron o terminaron en el trimestre, o estan totalmente contenidas (arrancaron Y terminaron)
			
    -- Insert statements for procedure here
	select rhhta.Nombre, rhhta.NumeroHabitacion, rhhta.Piso, SUM(rhhta.Dias) as Dias
	from #ReservasPorHotelYHabitacionEnTrimestreEnAnio rhhta
	WHERE rhhta.EstadoReserva = 'RF' -- si la reserva no fue finalizada y facturada la ignoro
	GROUP BY rhhta.Nombre, rhhta.NumeroHabitacion, rhhta.Piso
END
GO



/*
GO
CREATE PROCEDURE MMEL.TOP5_1 @Año int,@Trimestre varchar(80)
as
begin
	
	if '1ºTrimestre (1º de Enero ~ 31 de Marzo)' = @Trimestre
	begin
		select top 5 count(cr.FechaDeCancelacion) from mmel.CancelacionReserva cr join mmel.reserva r on cr.idReserva = r.idReserva 
											 join mmel.Habitacion h on r.idHabitacion = h.idHabitacion
											 join mmel.Hotel hot on h.idHotel = hot.idHotel
											 where  year(cr.FechaDeCancelacion)= @Año and (month(cr.FechaDeCancelacion) = 1 OR month(cr.FechaDeCancelacion) = 2 OR month(cr.FechaDeCancelacion)=3)
	end
	if '2ºTrimestre (1º de Abril ~ 30 de Junio)' = @Trimestre
	begin
	select top 5 count(cr.FechaDeCancelacion) from mmel.CancelacionReserva cr join mmel.reserva r on cr.idReserva = r.idReserva 
											 join mmel.Habitacion h on r.idHabitacion = h.idHabitacion
											 join mmel.Hotel hot on h.idHotel = hot.idHotel
											 where year(cr.FechaDeCancelacion)= @Año and (month(cr.FechaDeCancelacion) = 4 OR month(cr.FechaDeCancelacion) = 5 OR month(cr.FechaDeCancelacion)=6)
	end
	if '3ºTrimestre (1º de Julio ~ 30 de Septiembre)' = @Trimestre
	begin
	select top 5 count(cr.FechaDeCancelacion) from mmel.CancelacionReserva cr join mmel.reserva r on cr.idReserva = r.idReserva 
											 join mmel.Habitacion h on r.idHabitacion = h.idHabitacion
											 join mmel.Hotel hot on h.idHotel = hot.idHotel
											 where year(cr.FechaDeCancelacion)= @Año and (month(cr.FechaDeCancelacion) = 7 OR month(cr.FechaDeCancelacion) = 8 OR month(cr.FechaDeCancelacion)=9)
	end	
	if '4ºTrimestre (1º de Octubre ~ 31 de Diciembre)' = @Trimestre
 	begin
	select top 5 count(cr.FechaDeCancelacion) from mmel.CancelacionReserva cr join mmel.reserva r on cr.idReserva = r.idReserva 
											 join mmel.Habitacion h on r.idHabitacion = h.idHabitacion
											 join mmel.Hotel hot on h.idHotel = hot.idHotel
											 where year(cr.FechaDeCancelacion)= @Año and (month(cr.FechaDeCancelacion) = 10 OR month(cr.FechaDeCancelacion) = 11 OR month(cr.FechaDeCancelacion)=12)
	end   
end


--Hoteles con mayor cantidad de consumibles facturados
GO
CREATE PROCEDURE MMEL.TOP5_2 @Año int,@Trimestre varchar(80)
as
begin

if '1ºTrimestre (1º de Enero ~ 31 de Marzo)' = @Trimestre
	begin
	select top 5 * from mmel.Facturacion f join mmel.Estadia e on f.idEstadia = e.idEstadia
										   join mmel.ConsumiblePorEstadia cpr on e.idEstadia = cpr.idEstadia
									       join mmel.consumible c on cpr.idConsumible = c.idConsumible
										   where year(f.FacturaFecha) = @Año and (month(f.FacturaFecha) = 1 OR month(f.FacturaFecha) = 2 or month(f.FacturaFecha) = 3)
	end
	if '2ºTrimestre (1º de Abril ~ 30 de Junio)' = @Trimestre
	begin
	select top 5 * from mmel.Facturacion f join mmel.Estadia e on f.idEstadia = e.idEstadia
										   join mmel.ConsumiblePorEstadia cpr on e.idEstadia = cpr.idEstadia
									       join mmel.consumible c on cpr.idConsumible = c.idConsumible
										   where year(f.FacturaFecha) = @Año and (month(f.FacturaFecha) = 4 OR month(f.FacturaFecha) = 5 or month(f.FacturaFecha) = 6)
	end
	if '3ºTrimestre (1º de Julio ~ 30 de Septiembre)' = @Trimestre
	begin
	select top 5 * from mmel.Facturacion f join mmel.Estadia e on f.idEstadia = e.idEstadia
										   join mmel.ConsumiblePorEstadia cpr on e.idEstadia = cpr.idEstadia
									       join mmel.consumible c on cpr.idConsumible = c.idConsumible
										   where year(f.FacturaFecha) = @Año and (month(f.FacturaFecha) = 7 OR month(f.FacturaFecha) = 8 or month(f.FacturaFecha) = 9)
	end	
	if '4ºTrimestre (1º de Octubre ~ 31 de Diciembre)' = @Trimestre
 	begin
	select top 5 * from mmel.Facturacion f join mmel.Estadia e on f.idEstadia = e.idEstadia
										   join mmel.ConsumiblePorEstadia cpr on e.idEstadia = cpr.idEstadia
									       join mmel.consumible c on cpr.idConsumible = c.idConsumible
										   where year(f.FacturaFecha) = @Año and (month(f.FacturaFecha) = 10 OR month(f.FacturaFecha) = 11 or month(f.FacturaFecha) = 12)
	end   

end


--Hoteles con mayor cantidad de dias fuera de servicio
GO
CREATE PROCEDURE MMEL.TOP5_3 @Año int,@Trimestre varchar(80)
as
begin


if '1ºTrimestre (1º de Enero ~ 31 de Marzo)' = @Trimestre
	begin

	end
	if '2ºTrimestre (1º de Abril ~ 30 de Junio)' = @Trimestre
	begin
	
	end
	if '3ºTrimestre (1º de Julio ~ 30 de Septiembre)' = @Trimestre
	begin
	
	end	
	if '4ºTrimestre (1º de Octubre ~ 31 de Diciembre)' = @Trimestre
 	begin
	
	end   
end


--Habitaciones con mayor cantidad de dias y veces que fueron ocupadas
GO
CREATE PROCEDURE MMEL.TOP5_4 @Año int,@Trimestre varchar(80)
as
begin

if '1ºTrimestre (1º de Enero ~ 31 de Marzo)' = @Trimestre
	begin
	select top 5 SUM(DATEDIFF(DAY, e.FechaCheckIN, e.FechaCheckOUT)) 'Días',
		COUNT(1) 'Veces' from mmel.estadia e join mmel.reserva r on e.idReserva = r.idReserva
	         where year(e.FechaCheckIN)=@Año and year(e.FechaCheckOUT)=@Año and (
				   month(e.FechaCheckIN) = 1 OR month(e.FechaCheckOUT) = 1 OR
			       month(e.FechaCheckIN) = 2 OR month(e.FechaCheckOUT) = 2 OR
				   month(e.FechaCheckIN) = 3 OR month(e.FechaCheckOUT) = 3
			 )

	end
	if '2ºTrimestre (1º de Abril ~ 30 de Junio)' = @Trimestre
	begin
		select top 5 * from mmel.estadia e join mmel.reserva r on e.idReserva = r.idReserva
	         where year(e.FechaCheckIN)=@Año and year(e.FechaCheckOUT)=@Año and (
				   month(e.FechaCheckIN) = 4 OR month(e.FechaCheckOUT) = 4
			       month(e.FechaCheckIN) = 5 OR month(e.FechaCheckOUT) = 5
				   month(e.FechaCheckIN) = 6 OR month(e.FechaCheckOUT) = 6
			 )
	end
	if '3ºTrimestre (1º de Julio ~ 30 de Septiembre)' = @Trimestre
	begin
		select top 5 * from mmel.estadia e join mmel.reserva r on e.idReserva = r.idReserva
	         where year(e.FechaCheckIN)=@Año and year(e.FechaCheckOUT)=@Año and (
				   month(e.FechaCheckIN) = 7 OR month(e.FechaCheckOUT) = 7 OR
			       month(e.FechaCheckIN) = 8 OR month(e.FechaCheckOUT) = 8 OR
				   month(e.FechaCheckIN) = 9 OR month(e.FechaCheckOUT) = 9
			 )
	end	
	if '4ºTrimestre (1º de Octubre ~ 31 de Diciembre)' = @Trimestre
 	begin
		select top 5 * from mmel.estadia e join mmel.reserva r on e.idReserva = r.idReserva
	         where year(e.FechaCheckIN)=@Año and year(e.FechaCheckOUT)=@Año and (
				   month(e.FechaCheckIN) = 1 OR month(e.FechaCheckOUT) = 1 OR
			       month(e.FechaCheckIN) = 2 OR month(e.FechaCheckOUT) = 2 OR
				   month(e.FechaCheckIN) = 3 OR month(e.FechaCheckOUT) = 3
			 )
	end   

end


--Cliente con mayor cantidad de puntos
GO
CREATE PROCEDURE MMEL.TOP5_5 @Año int,@Trimestre varchar(80)
as
begin

if '1ºTrimestre (1º de Enero ~ 31 de Marzo)' = @Trimestre
	begin
		
	end
	if '2ºTrimestre (1º de Abril ~ 30 de Junio)' = @Trimestre
	begin
	
	end
	if '3ºTrimestre (1º de Julio ~ 30 de Septiembre)' = @Trimestre
	begin
	
	end	
	if '4ºTrimestre (1º de Octubre ~ 31 de Diciembre)' = @Trimestre
 	begin
	
	end   

end

*/















