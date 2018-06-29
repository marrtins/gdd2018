

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
	[Password] [varbinary](4000) NULL,
	[idPersona] [int] NULL,
	[Activo] [char](1) NULL,
	[Username] [nvarchar](200) NULL,
	[IngresosFallidos] [int] NOT NULL,
 CONSTRAINT [PK_idUsuario] PRIMARY  key(idUsuario )
 )

ALTER TABLE [MMEL].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_IngresosFallidos]  DEFAULT ((0)) FOR [IngresosFallidos]

IF OBJECT_ID('MMEL.HotelBajas', 'U') IS NOT NULL
	DROP TABLE MMEL.HotelBajas;

CREATE TABLE [MMEL].[HotelBajas](
	[idBaja] [int] IDENTITY(1,1) NOT NULL,
	[idHotel] [int] NOT NULL,
	[FechaDesde] [datetime] NOT NULL,
	[FechaHasta] [datetime] NOT NULL,
	[Motivo] [varchar](500) NULL,
CONSTRAINT [PK_idBaja] PRIMARY  key(idBaja)


)
CREATE TABLE [MMEL].[Hotel](
	[idHotel] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [varchar](200) NULL,
	[idDireccion] [int] NULL,
	[Telefono] [varchar](20) NULL,
	[CantidadEstrellas] [int] NULL,
	[FechaDeCreacion] [smalldatetime] NULL,
	[Nombre] [varchar](200) NULL,
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
	Codigo varchar(50) not null,
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
	--idHabitacion int references MMEL.Habitacion(idHabitacion),
	
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
	constraint PK_RPH primary key(idRPH)
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
	--MontoTotal int ,--en la maestra fact total es un nro q nada q ver, cambio montoTotal x fact total para evitar confusiones
	FactTotal int,
	--MontoFinal int,
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
	idUsuarioQueGeneroCancelacion int references MMEL.Usuarios(idUsuario),
	idReserva int references MMEL.Reserva(idReserva)
	constraint PK_idReservaCancelacion primary key(idReservaCancelacion)
	)



GO







--------------------MIGRACION DE DATOS-------




--Migracion de datos


--Tabla Rol
insert into MMEL.Rol values('administrador','S')
insert into MMEL.Rol values('recepcionista','S')
insert into MMEL.Rol values('guest','S')



--Tabla Funcionalidades


SET IDENTITY_INSERT [MMEL].[Funcionalidades] ON 
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (1, N'ABM de Rol', N'rol')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (2, N'Login y Seguridad', N'login')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (3, N'ABM de Usuario', N'usuario')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (4, N'ABM de Hotel', N'hotel')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (5, N'ABM de Cliente', N'cliente')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (6, N'ABM de Habitacion', N'habitacion')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (7, N'ABM de Regimen', N'regimen')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (8, N'ABM de Reserva', N'reservaAbm')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (9, N'Cancelar Reserva', N'reservaCancel')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (10, N'Registrar Estadía', N'estadia')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (11, N'Registrar Consumibles', N'consumible')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (12, N'Facturar Publicaciones', N'facturar')
GO
INSERT [MMEL].[Funcionalidades] ([idFuncionalidad], [Descripcion], [Codigo]) VALUES (13, N'Listado Estadistico', N'estadistico')
GO
SET IDENTITY_INSERT [MMEL].[Funcionalidades] OFF
GO

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
insert into mmel.Persona(Nombre) values('GuestGen')
insert into mmel.Usuarios(Activo,Username,idPersona)values('S','GUEST',1)
insert into mmel.UsuariosPorRoles(idRol,idUsuario) values(3,1)

--el admin
insert into mmel.Persona(Nombre) values('Administrador General')
insert into mmel.Usuarios(Activo,Username,Password,IngresosFallidos,idPersona) values('S','admin',HASHBYTES('SHA2_256','w23e'),0,2)
insert into mmel.UsuariosPorRoles(idRol,idUsuario) values(1,2)

--recepcionsta
insert into mmel.Persona(Nombre) values('Recep Generico')
insert into mmel.Usuarios(Activo,Username,Password,IngresosFallidos,idPersona) values('S','rg',HASHBYTES('SHA2_256','123'),0,3) 


insert into mmel.UsuariosPorRoles(idRol,idUsuario) values(2,3)


insert into mmel.Pais(Nombre) values('ARGENTINA')
insert into mmel.Pais(Nombre) values('BRASIL')
insert into mmel.Pais(Nombre) values('CHILE')
insert into mmel.Pais(Nombre) values('URUGUAY')

insert into MMEL.Direccion(calle,nroCalle,idPais,Ciudad)
select distinct Hotel_Calle,Hotel_Nro_Calle,1,Hotel_Ciudad from gd_esquema.Maestra




insert into mmel.Hotel(idDireccion,CantidadEstrellas,RecargaEstrellas,Nombre)
select
	distinct di.idDireccion,ot.Hotel_CantEstrella,ot.Hotel_Recarga_Estrella,concat(ot.Hotel_Calle,' ',ot.Hotel_Nro_Calle)
	from gd_esquema.Maestra ot
	join mmel.Direccion di on di.calle=ot.Hotel_Calle and di.nroCalle = ot.Hotel_Nro_Calle


---hxu del admin gral

insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,1)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,2)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,3)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,4)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,5)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,6)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,7)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,8)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,9)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,10)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,11)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,12)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,13)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,14)
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(2,15)

--hotel del recep generico
insert into mmel.HotelesPorUsuarios(idUsuario,idHotel) values(3,1)




insert into mmel.TipoHabitacion (idTipoHabitacion,Descripcion,TipoPorcentual)
select
	Habitacion_Tipo_Codigo,
	Habitacion_Tipo_Descripcion,
	Habitacion_Tipo_Porcentual
 from gd_esquema.Maestra
  group by Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual


go



insert into mmel.Habitacion(NumeroHabitacion,Piso,idHotel,VistaAlExterior,idTipoHabitacion,Habilitado)
select distinct ot.Habitacion_Numero,ot.Habitacion_Piso,ho.idHotel,ot.Habitacion_Frente,th.idTipoHabitacion,'S'
from gd_esquema.Maestra ot
inner join mmel.Direccion d on d.calle=ot.Hotel_Calle and d.nroCalle = ot.Hotel_Nro_Calle
inner join mmel.Hotel ho on d.idDireccion=ho.idDireccion
inner join mmel.TipoHabitacion th on th.Descripcion=ot.Habitacion_Tipo_Descripcion




--iria esta versio ya q no hay q agregar idhotel creeria
insert into mmel.Regimen(Precio,Habilitado,Descripcion)
select distinct ot.Regimen_Precio,'S',upper(ot.Regimen_Descripcion) from gd_esquema.Maestra ot  --revisar si entran todas habilitadas


insert into MMEL.TipoDocumento(Detalle) values('PASAPORTE')
insert into MMEL.TipoDocumento(Detalle) values('DNI')
insert into MMEL.TipoDocumento(Detalle) values('CEDULA')


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
--idHabitacion = ha.idHabitacion,
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

insert into mmel.ReservaPorHabitacion(idReserva,idHabitacion) 
select distinct re.idReserva,ha.idHabitacion from gd_esquema.Maestra ot,mmel.Reserva re,mmel.Habitacion ha,mmel.Hotel ho where 
re.CodigoReserva=ot.Reserva_Codigo 
and re.idHotel=ho.idHotel
and ha.idHotel=ho.idHotel
and ha.NumeroHabitacion=ot.Habitacion_Numero

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
where ot.Consumible_Descripcion is not null

insert into mmel.ConsumiblePorEstadia (idConsumible,idEstadia)
select distinct co.idConsumible,es.idEstadia from gd_esquema.Maestra ot
inner join mmel.Consumible co on co.CodigoConsumible = ot.Consumible_Codigo
inner join mmel.Reserva re on re.CodigoReserva=ot.Reserva_Codigo
inner join mmel.Estadia es on es.idReserva=re.idReserva

insert into mmel.FormaDePago(Descripcion) values('TARJETA DE CREDITO')
insert into mmel.FormaDePago(Descripcion) values('TARJETA DE DEBITO')
insert into mmel.FormaDePago(Descripcion) values('EFECTIVO')
insert into mmel.FormaDePago(Descripcion) values('CHEQUE')

insert into mmel.Facturacion(FacturaFecha,idEstadia,FactTotal,NroFactura) --falta agregar forma de pago
select distinct ot.Factura_Fecha,es.idEstadia,ot.Factura_Total,ot.Factura_Nro from gd_esquema.Maestra ot
inner join mmel.Reserva re on re.CodigoReserva = ot.Reserva_Codigo
inner join mmel.Estadia es on es.idReserva=re.idReserva
where ot.Factura_Fecha is not null

--agergo el item q consideramos valor base de habitacion
insert into mmel.ItemFactura(idFactura,idEstadia,itemDescripcion,itemFacturaMonto,itemFacturaCantidad)
select fa.idFactura,fa.idEstadia,'VALOR BASE HABITACION',ot.Item_Factura_Cantidad,ot.Item_Factura_Monto
 from gd_esquema.Maestra ot
 inner join mmel.Facturacion fa on fa.NroFactura=ot.Factura_Nro where ot.Consumible_Codigo is null and ot.Factura_Fecha is not null

insert into mmel.ItemFactura(idFactura,idEstadia,itemDescripcion,idConsumible,itemFacturaMonto,itemFacturaCantidad)
select fa.idFactura,fa.idEstadia,'VALOR CONSUMIBLE',co.idConsumible,ot.Item_Factura_Cantidad,ot.Item_Factura_Monto
 from gd_esquema.Maestra ot
 inner join mmel.Facturacion fa on fa.NroFactura=ot.Factura_Nro
 inner join mmel.Estadia es on es.idEstadia=fa.idEstadia
 inner join mmel.ConsumiblePorEstadia cpe on cpe.idEstadia = es.idEstadia
 inner join mmel.Consumible co on co.idConsumible=cpe.idConsumible
 where ot.Consumible_Codigo is not null and ot.Factura_Fecha is not null


-----fin migracion
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[UsuarioListar]'))
	DROP PROCEDURE [MMEL].UsuarioListar
GO

/****** Object:  StoredProcedure [MMEL].[UsuarioListar]    Script Date: 13/6/2018 22:27:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [MMEL].[UsuarioListar]  
    @Username nvarchar(200),
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@Mail nvarchar(200),
	@NroDocumento int,
	@idTipoDocumento int,
	@idRol int
AS   

    SET NOCOUNT ON;  

    SELECT * 
    FROM MMEL.Usuarios us
    JOIN MMEL.Persona pe on us.idPersona = pe.idPersona
	JOIN MMEL.RolesPorUsuario rpu on us.idUsuario = rpu.idUsuario
	JOIN MMEL.Rol ro on rpu.idRol = ro.idRol
    WHERE (@Username is null or us.Username LIKE '%' + @Username + '%')
            and (@Nombre is null or pe.Nombre LIKE '%' + @Nombre + '%')
            and (@Apellido is null or pe.Apellido LIKE '%' + @Nombre + '%')
            and (@idTipoDocumento is null or pe.idTipoDocumento = @idTipoDocumento)
			and (@NroDocumento is null or pe.NroDocumento = @NroDocumento)
			and (@idRol is null or ro.idRol = @idRol)
			and (@Mail is null or pe.Mail LIKE '%' + @Mail + '%')
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[UsuarioDelete]'))
	DROP PROCEDURE [MMEL].UsuarioDelete
GO

/****** Object:  StoredProcedure [MMEL].[UsuarioDelete]    Script Date: 13/6/2018 22:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[UsuarioDelete] 
    @idUsuario int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [MMEL].[Usuarios]
	SET    [Usuarios].Activo = 'N'
	WHERE  [Usuarios].idUsuario = @idUsuario

	COMMIT
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[UsuarioCrear]'))
	DROP PROCEDURE [MMEL].UsuarioCrear
GO

/****** Object:  StoredProcedure [MMEL].[UsuarioCrear]    Script Date: 13/6/2018 22:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [MMEL].[UsuarioCrear] 
    @idAdmin int,
	@Username nvarchar(200),
	@Password nvarchar(200),
	@idRol int,
	@idHotel int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
    @Mail nvarchar(200),
	@idTipoDocumento int,
	@NroDocumento int,
	@dirIdPais int = NULL,
	@dirCalle nvarchar(150) = NULL,
    @dirNroCalle int = NULL,
	@FechaDeNacimiento datetime,
	@dirDepto char(2) = NULL,
	@dirPiso smallint = NULL,
	@dirLocalidad nvarchar(150) = NULL,
    @Telefono varchar(20) = NULL,
	@Activo char = NULL

AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DECLARE @nombreRol [varchar](50);

	SELECT @nombreRol = Nombre FROM Rol r JOIN UsuariosPorRoles upr on upr.idRol = r.idRol WHERE upr.idUsuario = @idAdmin

	IF @nombreRol != 'administrador'
		THROW 51000, 'El usuario no es administrador', 1;

	INSERT INTO [MMEL].[Persona] ([Nombre], [Apellido], [idTipoDocumento], [NroDocumento], [Mail], [Telefono], [FechaDenacimiento], [dirCalle], [dirNroCalle], [dirIdPais], [dirPiso], [dirDepto], [dirLocalidad])
	SELECT @Nombre, @Apellido, @idTipoDocumento, @NroDocumento, @Mail, @Telefono, @FechaDeNacimiento, @dirCalle, @dirNroCalle, @dirIdPais, @dirPiso, @dirDepto, @dirLocalidad
	
	DECLARE @idPersona int = SCOPE_IDENTITY();

	DECLARE @PasswordHasheada varbinary(4000) = HASHBYTES('SHA2_256', @Password);


	INSERT INTO [MMEL].[Usuarios] ([Username], [Password], [idPersona], [Activo])
	SELECT @Username, @PasswordHasheada, @idPersona, @Activo

	DECLARE @idUsuario int  =  SCOPE_IDENTITY();

	INSERT INTO [MMEL].[UsuariosPorRoles] ([idRol], [idUsuario])
	SELECT @idRol, @idUsuario

	DECLARE @idUPR int = SCOPE_IDENTITY();

	INSERT INTO [MMEL].[HotelesPorUsuarios] ([idUsuario], [idHotel])
    SELECT @idUsuario, @idHotel

	DECLARE @idHPU int = SCOPE_IDENTITY();

               
	COMMIT

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[crearUsuario]'))
	DROP PROCEDURE [MMEL].crearUsuario
GO
create procedure mmel.crearUsuario(   
	@Username nvarchar(200),
	@Password varchar(200),
	@idRol int,
	@idHotel int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
    @Mail nvarchar(200),
	@idTipoDocumento int,
	@NroDocumento int,
	@dirIdPais int = NULL,
	@dirCalle nvarchar(150) = NULL,
    @dirNroCalle int = NULL,
	@FechaDeNacimiento datetime,
	@dirDepto char(2) = NULL,
	@dirPiso smallint = NULL,
	@dirLocalidad nvarchar(150) = NULL,
    @Telefono varchar(20) = NULL,
	@habilitado char = NULL,
	@idNacionalidad int,
	@codigoRet int output)
as
begin
	
	declare @aux int
	declare @idNuevo int
	
	declare @tipoDocumento varchar(15)
	select @tipoDocumento=detalle from mmel.TipoDocumento where idTipoDocumento=@idTipoDocumento


	--chequeo si ya existe el cliente.
	set @aux= mmel.existeUsuario(@tipoDocumento,@nroDocumento,@mail,@Username)
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
	else if(@aux=3)
	begin
		set @idNuevo=-1
		set @codigoRet=3 --existe el username en la bd
	end
	else if(@aux=0)
	begin
		
		
		
		insert into mmel.Persona(Telefono,Nombre,Apellido,idTipoDocumento,NroDocumento,Mail,FechaDeNacimiento,idNacionalidad,dirCalle,dirNroCalle,dirIdPais,dirPiso,dirDepto,dirLocalidad)
		values (@telefono,upper(@nombre),upper(@apellido),@idTipoDocumento,@nroDocumento,upper(@mail),@fechaDeNacimiento,@idNacionalidad,@dirCalle,@dirNroCalle,@dirIdPais,@dirPiso,
				@dirDepto,@dirLocalidad)
		set @idNuevo=SCOPE_IDENTITY()
		
		
		insert into mmel.Usuarios(idPersona,Activo,IngresosFallidos,Password,Username) values(@idNuevo,@habilitado,0,HASHBYTES('SHA2_256',@Password),UPPER(@Username))
		set @idNuevo=SCOPE_IDENTITY() 
		if(@idRol=1)
			insert into mmel.UsuariosPorRoles(idRol,idUsuario) values(1,@idNuevo)
		else
			insert into mmel.UsuariosPorRoles(idRol,idUsuario) values(2,@idNuevo)
		set @codigoRet = 0 --se creo ok el cliente

		if(@idHotel > 0)
		begin
			insert into mmel.HotelesPorUsuarios(idHotel,idUsuario) values(@idHotel,@idNuevo)
		end
	end
end

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[getInfoUsuario]'))
	DROP PROCEDURE [MMEL].getInfoUsuario
GO

create procedure mmel.getInfoUsuario(@nombre varchar(50) output,@apellido varchar(50) output,@tipoid varchar(50) output,@nroDoc varchar(25) output,@fechanac datetime output,@nacionalidad varchar(50) output,@email varchar(200) output,
	@telefono varchar(30) output,@calle varchar(150)output,@nro int output,@piso int output,@dpto char(2)output,@localidad varchar(150)output,@pais varchar(150)output,@activo char(1) output,
	@username varchar(75) output,@rol varchar(30)output,@hotel varchar(200)output,@idUsuario int)
as
begin

	select @nombre = pe.nombre,@apellido=pe.Apellido,@tipoid=td.detalle,@nroDoc=pe.NroDocumento,@fechanac=pe.FechaDeNacimiento,@nacionalidad=p1.Nombre,@email=pe.Mail,
	@telefono=pe.Telefono,@calle=pe.dirCalle,@nro=pe.dirNroCalle,@piso=pe.dirPiso,@dpto=pe.dirDepto,@localidad=pe.dirLocalidad,@pais=p2.Nombre,@activo=us.Activo,@username=us.Username,@rol=ro.Nombre,
	@hotel=ho.Nombre
	 from mmel.Persona pe,mmel.Usuarios us,mmel.Hotel ho,mmel.TipoDocumento td,mmel.Pais p1,mmel.Pais p2,mmel.Rol ro,mmel.UsuariosPorRoles upr,mmel.HotelesPorUsuarios hpu where
	 pe.idPersona=us.idPersona and pe.idTipoDocumento=td.idTipoDocumento and p1.idPais=pe.idNacionalidad and p2.idPais=pe.dirIdPais and upr.idRol=ro.idRol and upr.idUsuario=us.idUsuario and
	 hpu.idHotel=ho.idHotel and hpu.idUsuario=us.idUsuario and us.idUsuario=@idUsuario
end

go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[modificarUsuario]'))
	DROP PROCEDURE [MMEL].modificarUsuario
GO

create procedure mmel.modificarUsuario(
	@Username nvarchar(200),
	@Password varchar(200),
	@idRol int,
	@idHotel int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
    @Mail nvarchar(200),
	@idTipoDocumento int,
	@NroDocumento int,
	@dirIdPais int = NULL,
	@dirCalle nvarchar(150) = NULL,
    @dirNroCalle int = NULL,
	@FechaDeNacimiento datetime,
	@dirDepto char(2) = NULL,
	@dirPiso smallint = NULL,
	@dirLocalidad nvarchar(150) = NULL,
    @Telefono varchar(20) = NULL,
	@habilitado char = NULL,
	@idNacionalidad int,
	@idUsuario int,
	@codigoRet int output
	)
	
as
begin


	declare @aux int
	declare @idNuevo int
	declare @idPersona int
	declare @tipoDocumento varchar(15)
	select @tipoDocumento=detalle from mmel.TipoDocumento where idTipoDocumento=@idTipoDocumento
	select @idPersona=idPersona from mmel.Usuarios where idUsuario=@idUsuario

	--chequeo si ya existe el cliente.
	set @aux= mmel.existeUsuarioMod(@tipoDocumento,@nroDocumento,@mail,@Username,@idUsuario,@idPersona)
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
	else if(@aux=3)
	begin
		set @idNuevo=-1
		set @codigoRet=3 --existe el username en la bd
	end
	else if(@aux=0)
	begin
		update mmel.Persona
		set Telefono=@Telefono,Nombre=@nombre,Apellido=@aux,idTipoDocumento=@idTipoDocumento,NroDocumento=@NroDocumento,Mail=@Mail,FechaDeNacimiento=@FechaDeNacimiento,
		idNacionalidad=@idNacionalidad,dirCalle=@dirCalle,dirNroCalle=@dirNroCalle,dirIdPais=@dirIdPais,dirPiso=@dirPiso,dirDepto=@dirDepto,dirLocalidad=@dirLocalidad
		where idPersona=@idPersona
		

		--upd pw
		update mmel.Usuarios set Activo=@habilitado,Username=UPPER(@Username) where idUsuario=@idUsuario
		
		if(@Password<>'nn22')
		update mmel.usuarios set Password=HASHBYTES('SHA2_256',@Password) where idUsuario=@idUsuario
		
		if(@idRol=1)
			update mmel.UsuariosPorRoles set idRol=1 where idUsuario=@idUsuario
		else
			update mmel.UsuariosPorRoles set idRol=2 where idUsuario=@idUsuario
		set @codigoRet = 0 --se creo ok el cliente

		update mmel.HotelesPorUsuarios set idHotel=@idHotel where idUsuario=@idUsuario

		end
	end

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[UsuarioUpdate]'))
	DROP PROCEDURE [MMEL].UsuarioUpdate
GO

/****** Object:  StoredProcedure [MMEL].[UsuarioUpdate]    Script Date: 13/6/2018 22:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[UsuarioUpdate] 
	@idAdmin int,
	@idUsuario int,
	@Username nvarchar(200),
	@Password nvarchar(200),
	@idRol int,
	@idHotel int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
    @Mail nvarchar(200),
	@idTipoDocumento int,
	@NroDocumento int,
	@dirIdPais int = NULL,
	@dirCalle nvarchar(150) = NULL,
    @dirNroCalle int = NULL,
	@FechaDeNacimiento datetime,
	@dirDepto char(2) = NULL,
	@dirPiso smallint = NULL,
	@dirLocalidad nvarchar(150) = NULL,
    @Telefono varchar(20) = NULL,
	@Activo char = NULL

AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DECLARE @nombreRol [varchar](50);

	SELECT @nombreRol = Nombre FROM Rol r JOIN UsuariosPorRoles upr on upr.idRol = r.idRol WHERE upr.idUsuario = @idAdmin

	IF @nombreRol != 'administrador'
		THROW 51000, 'El usuario no es administrador', 1;
	
	DECLARE @PasswordHasheada varbinary(4000) = HASHBYTES('SHA2_256', @Password);


	UPDATE [MMEL].[Usuarios]
	SET    [Username] = @Username, [Password] = @PasswordHasheada, [Activo] = @Activo
	WHERE  [idUsuario] = @idUsuario

	UPDATE [MMEL].[UsuariosPorRoles]
	SET [idRol] = @idRol
	WHERE [idUsuario] = @idUsuario

	UPDATE [MMEL].[HotelesPorUsuarios]
	SET [idHotel] = @idHotel
	WHERE [idUsuario] = @idUsuario

	DECLARE @idPersona int;
	SELECT @idPersona FROM Usuarios U WHERE U.idUsuario = @idUsuario
	
	UPDATE [MMEL].[Persona]
	SET    [Nombre] = @Nombre, [Apellido] = @Apellido, [idTipoDocumento] = @idTipoDocumento, [NroDocumento] = @NroDocumento, [FechaDenacimiento] = @FechaDeNacimiento, [Mail] = @Mail, [Telefono] = @Telefono, [dirCalle] = @dirCalle, [dirNroCalle] = @dirNroCalle, [dirPiso] = @dirPiso, [dirDepto] = @dirDepto, [dirIdPais] = @dirIdPais, [dirLocalidad] = @dirLocalidad
	WHERE  [idPersona] = @idPersona

	

	SELECT [idUsuario]
	FROM   [MMEL].[Usuarios]
	WHERE  [idUsuario] = @idUsuario

	COMMIT
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[TiposDocumentoListar]'))
	DROP PROCEDURE [MMEL].TiposDocumentoListar
GO

/****** Object:  StoredProcedure [MMEL].[TiposDocumentoListar]    Script Date: 26/6/2018 17:22:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[TiposDocumentoListar]
	@idTipoDocumento int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idTipoDocumento], [detalle]
	FROM   [MMEL].[TipoDocumento]
	WHERE  ([idTipoDocumento] = @idTipoDocumento OR @idTipoDocumento IS NULL)

	COMMIT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesDisponibles]'))
	DROP PROCEDURE [MMEL].HotelesDisponibles
GO

/****** Object:  StoredProcedure [MMEL].[HotelesDisponibles]    Script Date: 26/6/2018 17:22:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [MMEL].[HotelesDisponibles]
	@idHotel int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idHotel], [Nombre]
	FROM   [MMEL].[Hotel]
	WHERE  ([idHotel] = @idHotel OR @idHotel IS NULL)

	COMMIT
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ReservasNoCanceladas]'))
	DROP VIEW [MMEL].[ReservasNoCanceladas]
go

CREATE VIEW [MMEL].[ReservasNoCanceladas]
AS
SELECT        idReserva, idUsuarioQueProcesoReserva, idHotel, FechaDeReserva, FechaDesde, FechaHasta, idRegimen, idHuesped, EstadoReserva, CodigoReserva
FROM            MMEL.Reserva AS r
WHERE        (EstadoReserva <> 'CXR') AND (EstadoReserva <> 'CXC') AND (EstadoReserva <> 'CXNS')
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HabitacionesListar]'))
	DROP PROCEDURE [MMEL].[HabitacionesListar]
go


create PROCEDURE [MMEL].[HabitacionesListar]
	-- Add the parameters for the stored procedure here
	@IdTipoHabitacion int,
    @NumeroHabitacion int,
    @IdHotel varchar(60),
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

	DECLARE @HOTEL int

	
	select @HOTEL = idHotel from mmel.Hotel where Nombre=@IdHotel

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
 (@HOTEL is NULL OR (@HOTEL = hab.IdHotel))  and
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
	DECLARE @ExisteNroHab int
	select @ExisteNroHab = count(NumeroHabitacion) from mmel.Habitacion where NumeroHabitacion=@NumeroHabitacion and idHotel=@IdHotel
	SELECT @ExisteTipoHabitacion = idTipoHabitacion FROM mmel.TipoHabitacion where @IdTipoHabitacion=idTipoHabitacion
	SELECT @ExisteHotel = hot.idHotel FROM mmel.Hotel hot where  @IdHotel = hot.idHotel
	DECLARE @AUX int
	PRINT @ExisteHotel
	PRINT @ExisteTipoHabitacion
	print @AUX
	IF @ExisteHotel != 0 AND @ExisteTipoHabitacion!=0 and @ExisteNroHab=0
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
					@IdHabitacion int,
					--@Descripcion nvarchar(200),
					@MESSAGE int output
   
AS
	BEGIN TRAN
	update [MMEL].[Habitacion] set Habilitado='N'
	--Descripcion=@Descripcion
	 WHERE idHabitacion=@IdHabitacion
		SET @MESSAGE = 1
	COMMIT
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
                   @Habilitado char(1),
				   @IdHabitacion int
				 
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
	 where idHabitacion = @IdHabitacion

	

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

	SELECT f.idFuncionalidad, f.Descripcion, f.Codigo
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
	@RecargaEstrellas int,
	@FechaCreacion smalldatetime
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

INSERT INTO [MMEL].[Hotel] ([Mail], [idDireccion], [Telefono], [CantidadEstrellas],[Nombre],  RecargaEstrellas, FechaDeCreacion )
	SELECT @Mail, @idDireccion, @Telefono, @CantidadEstrellas, @Nombre, @RecargaEstrellas,@FechaCreacion


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


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesDeUsuario]'))
	DROP PROCEDURE [MMEL].HotelesDeUsuario
go

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
	@RecargaEstrellas int
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRAN

UPDATE [MMEL].[Hotel]
	SET    [Mail] = @Mail, [Telefono] = @Telefono, [CantidadEstrellas] = @CantidadEstrellas, [Nombre] = @Nombre,  RecargaEstrellas = @RecargaEstrellas
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

CREATE PROCEDURE [MMEL].[Logear]
	-- Add the parameters for the stored procedure here
	@usuario nvarchar(200),
	@password varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @wrongPasswordReturn int = -1
	DECLARE @blockedReturn int = -2
	DECLARE @noHabilitadoReturn int = -3
	DECLARE @rightPassword varbinary(4000)
	DECLARE @habilitado char(1)

	SELECT @rightPassword = u.Password, @habilitado = u.Activo FROM MMEL.Usuarios u WHERE Username = @usuario

	IF @habilitado = 'N'
		SELECT @noHabilitadoReturn AS id
	ELSE
		IF @rightPassword = HASHBYTES('SHA2_256',@password)
			SELECT idUsuario AS id FROM MMEL.Usuarios WHERE Username = @usuario
		ELSE
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
END

go
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
		
		insert into mmel.Huesped(idPersona,Habilitado) values(@idNuevo,@habilitado)
		set @codigoRet = 0 --se creo ok el cliente

	end
end

go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[existeUsuario]'))
	DROP function [MMEL].existeUsuario
go


create function mmel.existeUsuario(@tipodoc varchar(15),@nrodoc int,@mail varchar(200),@username varchar(200))
returns int
as
begin

	if exists (SELECT TOP 1 * FROM mmel.Persona, mmel.TipoDocumento ti WHERE NroDocumento=@nrodoc and ti.Detalle = @tipodoc)
	begin return 1 end --existe el nro y tipodoc en la bdd
	if exists(SELECT TOP 1 * FROM mmel.Persona WHERE Mail=@mail)
	begin return 2 end --existe el mail en la bdd
	if exists(select top 1 * from mmel.Usuarios where Username=@username)
	begin return 3 end
	return 0 --no existe
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[borrarUsuario]'))
	DROP procedure [MMEL].borrarUsuario
go

create procedure mmel.borrarUsuario(@idUsuario int)
as
begin
	update mmel.Usuarios set Activo='N' where idUsuario=@idUsuario
end


go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[cancelNoShow]'))
	DROP procedure [MMEL].cancelNoShow
go

create procedure mmel.cancelNoShow(@fechaHoy datetime)
as
begin
	update mmel.Reserva 
	set EstadoReserva = 'CXNS'
	
	where FechaDesde < @fechaHoy and idReserva not in(select idReserva from mmel.Estadia)

	delete mmel.ReservaPorHabitacion from mmel.Reserva re
	where mmel.ReservaPorHabitacion.idReserva=re.idReserva and re.idReserva not in(select idReserva from mmel.Estadia) and (re.EstadoReserva='CXNS' or re.EstadoReserva='CPR' or re.EstadoReserva='CPC') 
end
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[existeUsuarioMod]'))
	DROP function [MMEL].existeUsuarioMod
go

create function mmel.existeUsuarioMod(@tipodoc varchar(15),@nrodoc int,@mail varchar(200),@username varchar(200),@idUsuario int,@idPersona int)
returns int
as
begin

	if exists (SELECT TOP 1 * FROM mmel.Persona, mmel.TipoDocumento ti WHERE NroDocumento=@nrodoc and ti.Detalle = @tipodoc  and idPersona<>@idPersona)
	begin return 1 end --existe el nro y tipodoc en la bdd
	if exists(SELECT TOP 1 * FROM mmel.Persona WHERE Mail=@mail and idPersona<>@idPersona)
	begin return 2 end --existe el mail en la bdd
	if exists(select top 1 * from mmel.Usuarios where Username=@username and idUsuario<>@idUsuario)
	begin return 3 end
	return 0 --no existe
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
		join mmel.Reserva r on h.idHotel=r.idHotel  
		join mmel.ReservaPorHabitacion rph on rph.idReserva=r.idReserva and rph.idHabitacion=h.idHabitacion
		WHERE	h.idHotel=@idHotel AND
								(
									( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
									( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
									( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)

								)
		) and idHotel = @idHotel and idTipoHabitacion=@idTipoHab


END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[eliminarHabitaciones]'))
	DROP procedure [MMEL].eliminarHabitaciones
go

create procedure mmel.eliminarHabitaciones(@idReserva int)
as
begin
	delete from mmel.ReservaPorHabitacion where idReserva=@idReserva
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[modificarReserva]'))
	DROP procedure [MMEL].modificarReserva
go

create procedure mmel.modificarReserva(@idReserva int,@fechaDeReserva datetime,@idUsuarioQueReserva int,@fechaDesde datetime,@fechaHasta datetime,@idRegimen int)
as
begin

	
	
	update mmel.Reserva
	set
	idUsuarioQueProcesoReserva=@idUsuarioQueReserva,
	FechaDeReserva=@fechaDeReserva,
	FechaDesde=@fechaDesde,
	FechaHasta=@fechaHasta,
	idRegimen=@idRegimen,
	EstadoReserva='M'
	where idReserva=@idReserva
	
	
	
	
end
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[hotelDispo]'))
	DROP function [MMEL].hotelDispo
go

create  function mmel.hotelDispo(@fechaDesde datetime,@fechaHasta datetime,@idHotel int)
 returns int
 as
 begin
 
	if exists(select idHotel from mmel.Hotel where idHotel not in(select idHotel from mmel.HotelBajas where 
											(FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
											( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
											( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)) and idHotel=@idHotel)
		return 1 
	
	return 0
											
 end
 go
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[hayDisponibilidadMod]'))
	DROP procedure [MMEL].hayDisponibilidadMod
go
create PROCEDURE MMEL.hayDisponibilidadMod(@idReserva int,@fechaDesde datetime, @fechaHasta datetime,@idHotel int,@tipoHabDesc nvarchar(200),@rta int output)
AS
BEGIN

	
	create table mmel.#rp (idReserva int, idHabitacion int)
	insert into mmel.#rp (idReserva,idHabitacion)
	select idReserva,idHabitacion from mmel.ReservaPorHabitacion where idReserva<>@idReserva
	
	declare @idRegimen int
	declare @idTipoHab int
	set @idTipoHab = (select top 1 idTipoHabitacion from mmel.TipoHabitacion where Descripcion=@tipoHabDesc)


	declare @aux int
	set @aux=mmel.hotelDispo(@fechaDesde,@fechaHasta,@idHotel)
	if(@aux=1)
		begin

			if exists(
				select * from mmel.habitacion where idHabitacion not in
					(SELECT h.idHabitacion  FROM MMEL.Habitacion h
					join mmel.Reserva r on h.idHotel=r.idHotel
					join mmel.#rp rph on rph.idReserva=r.idReserva and rph.idHabitacion=h.idHabitacion
					WHERE	h.idHotel=@idHotel AND
											(
												( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
												( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
												( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)

											)
				) and idHotel = @idHotel and idTipoHabitacion=@idTipoHab and Habilitado='S'
			) begin
				select @rta=count(*) from mmel.habitacion where idHabitacion not in
					(SELECT h.idHabitacion  FROM MMEL.Habitacion h
					join mmel.Reserva r on h.idHotel=r.idHotel
					join mmel.#rp rph on rph.idReserva=r.idReserva and rph.idHabitacion=h.idHabitacion
					WHERE	h.idHotel=@idHotel AND
											(
												( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
												( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
												( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)

											)
				) and idHotel = @idHotel and idTipoHabitacion=@idTipoHab and Habilitado='S'
			 end
			else begin set @rta=0 end

			drop table mmel.#rp
		end
		else
		set @rta = 0


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
	declare @aux int
	set @aux=mmel.hotelDispo(@fechaDesde,@fechaHasta,@idHotel)
	if(@aux=1)
		begin
			if exists(
				select * from mmel.habitacion where idHabitacion not in
					(SELECT h.idHabitacion  FROM MMEL.Habitacion h
					join mmel.Reserva r on h.idHotel=r.idHotel
					join mmel.ReservaPorHabitacion rph on rph.idReserva=r.idReserva and rph.idHabitacion=h.idHabitacion
					WHERE	h.idHotel=@idHotel AND
											(
												( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
												( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
												( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)

											)
				) and idHotel = @idHotel and idTipoHabitacion=@idTipoHab and Habilitado='S'
			) begin
				select @rta=count(*) from mmel.habitacion where idHabitacion not in
					(SELECT h.idHabitacion  FROM MMEL.Habitacion h
					join mmel.Reserva r on h.idHotel=r.idHotel
					join mmel.ReservaPorHabitacion rph on rph.idReserva=r.idReserva and rph.idHabitacion=h.idHabitacion
					WHERE	h.idHotel=@idHotel AND
											(
												( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
												( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
												( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)

											)
				) and idHotel = @idHotel and idTipoHabitacion=@idTipoHab and Habilitado='S'
			 end
			else begin set @rta=0 end
		end
		else
		set @rta=0


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


create procedure mmel.reservar(@fechaDeReserva datetime,@idUsuarioQueReserva int,@fechaDesde datetime,@fechaHasta datetime,@idHotel int,@tipoRegimenDesc varchar(100),@idPersona int)
as
begin

	
	declare @idRegimen int
	declare @idHuesped int
	declare @cant int
	declare @idTipoHab int
	declare @codReserva2 int
	
	
	set @idRegimen = (select top 1 idRegimen from mmel.Regimen where Descripcion=@tipoRegimenDesc)
	--set @codReserva = mmel.getCodigoReserva()
	select @codReserva2=max(CodigoReserva)+1 from mmel.Reserva
	set @idHuesped=(select top 1 idHuesped from mmel.Huesped where idPersona=@idPersona)
	
	insert into mmel.Reserva(idUsuarioQueProcesoReserva,idHotel,FechaDeReserva,FechaDesde,FechaHasta,idRegimen,idHuesped,CodigoReserva,EstadoReserva)
	values(@idUsuarioQueReserva,@idHotel,@fechaDeReserva,@fechaDesde,@fechaHasta,@idRegimen,@idHuesped,@codReserva2,'C')
	
	
	
end
go








IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[setearHabitaciones]'))
	DROP procedure [MMEL].setearHabitaciones
go

create procedure mmel.setearHabitaciones(@codigoRes int,@cantHab int,@tipoHabDesc varchar(75),@fechaDesde datetime,@fechaHasta datetime,@idHotel int)
as
begin


	declare @idReserva int
	declare @idTipoHab int
	select @idReserva=idReserva from mmel.Reserva where CodigoReserva=@codigoRes
	select @idTipoHab=idTipoHabitacion from mmel.TipoHabitacion where Descripcion=@tipoHabDesc
	
	
CREATE TABLE mmel.#tt (idHab int,idRes int)
	insert into mmel.#tt(idHab,idRes)
	select top (@cantHab) idHabitacion,@idReserva from mmel.habitacion where idHabitacion not in
				(SELECT h.idHabitacion  FROM MMEL.Habitacion h
				join mmel.Reserva r on h.idHotel=r.idHotel
				join mmel.ReservaPorHabitacion rph on rph.idReserva=r.idReserva and rph.idHabitacion=h.idHabitacion
				WHERE	h.idHotel=@idHotel AND
										(
											( FechaDesde<=@fechaDesde and @fechaDesde<FechaHasta) OR
											( FechaDesde<@fechaHasta and @fechaHasta<=FechaHasta) OR
											( @fechaDesde<=FechaDesde and @fechaHasta>=FechaHasta)

										)
			) and idHotel = @idHotel and idTipoHabitacion=@idTipoHab


	insert into mmel.ReservaPorHabitacion(idHabitacion,idReserva)
	select idHab,idRes from mmel.#tt
	drop table mmel.#tt






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

create procedure mmel.cancelarReserva(@codigoRes int,@motivo varchar(300),@idUsuarioQueCancelo  int,@fecha datetime )
as
begin

	declare @idPersona int
	declare @idReserva int
	--declare @idRol int

	select @idPersona=hu.idPersona,@idReserva=re.idReserva from mmel.Reserva re ,mmel.Huesped hu  where re.CodigoReserva=@codigoRes and hu.idHuesped=re.idHuesped

	--select @idRol = idRol from mmel.Rol where Nombre=@rol

	insert into mmel.CancelacionReserva(Motivo,FechaDeCancelacion,idUsuarioQueGeneroCancelacion,idReserva)
	values(@motivo,@fecha,@idUsuarioQueCancelo,@idReserva)

	

	update mmel.Reserva
	set EstadoReserva =
	case
		when @idUsuarioQueCancelo=1 then 'CPC'
		else  'CPR'
	end
	where CodigoReserva=@codigoRes
	

end
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[existeReserva]'))
	DROP procedure [MMEL].existeReserva
go
create procedure mmel.existeReserva(@codigoRes int, @ret int output,@fechaDesde datetime output,@idHotel int output)
as
begin

	if exists(select * from mmel.Reserva where CodigoReserva=@codigoRes and (EstadoReserva='CO' or EstadoReserva='RINCF'))
		begin
		set @ret=1
		select @fechaDesde=FechaDesde,@idHotel=idHotel from MMEL.Reserva where CodigoReserva=@codigoRes
		end
	else
		begin
		set @ret = 0
		set @idHotel=-1
		select top 1 @fechaDesde=FechaDesde from MMEL.Reserva
		end
end
go



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[puedoCancelar]'))
	DROP procedure [MMEL].puedoCancelar
go
create procedure mmel.puedoCancelar(@codigoRes int, @ret int output,@fechaHoy datetime)
as
begin

	if exists(select * from mmel.Reserva where CodigoReserva=@codigoRes and @fechaHoy<FechaDesde and 
		(EstadoReserva = 'CO' or EstadoReserva = 'MO' or EstadoReserva = 'RINSF'or EstadoReserva = 'RINCF'))
		set @ret=1
	else
		set @ret = 0
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[modificarFactura]'))
	DROP PROCEDURE [MMEL].modificarFactura
go
create procedure mmel.modificarFactura(@idEstadia int,@FactTotal int,@FacturaFecha datetime,@formaDePago varchar(75))
as
begin
	
	declare @idFormaDePago int
	select @idFormaDePago = idFormaDePago from mmel.FormaDePago where Descripcion=@formaDePago
	update  mmel.Facturacion
	set FactTotal=@FactTotal,
	idFormaDePago=@idFormaDePago,
	FacturaFecha=@FacturaFecha
	where idEstadia=@idEstadia
end
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[modificarFormaDePago]'))
	DROP PROCEDURE [MMEL].modificarFormaDePago
go
create procedure mmel.modificarFormaDePago(@idEstadia int,@formaDePago varchar(75))
as
begin
	declare @idFormaDePago int
	select @idFormaDePago = idFormaDePago from mmel.FormaDePago where Descripcion=@formaDePago
	update  mmel.Facturacion
	set 
	idFormaDePago=@idFormaDePago
	
	where idEstadia=@idEstadia
end


go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[agregarItemDto]'))
	DROP PROCEDURE [MMEL].agregarItemDto
go
create procedure mmel.agregarItemDto(@valorDto int,@idEstadia int)
as
begin
	
	declare @idFactura int
	select  @idFactura=idFactura from mmel.ItemFactura where idEstadia=@idEstadia

	insert into mmel.ItemFactura(idEstadia,idFactura,itemDescripcion,itemFacturaCantidad,itemFacturaMonto)
	values(@idEstadia,@idFactura,'DESCUENTO POR REGIMEN',1,@valorDto)
end



go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[actualizarItems]'))
	DROP PROCEDURE [MMEL].actualizarItems
go
create procedure mmel.actualizarItems(@idEstadia int, @nuevoValorVB int ,@nuevoValorCons int,@cantCons int )
as
begin
	update mmel.ItemFactura
	set itemFacturaMonto=@nuevoValorVB
	where idEstadia=@idEstadia and itemDescripcion='VALOR BASE HABITACION'


	update mmel.ItemFactura
	set itemFacturaMonto=@nuevoValorCons,
	itemFacturaCantidad=@cantCons
	where idEstadia=@idEstadia and itemDescripcion='VALOR CONSUMIBLES'
end

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[getFacturaVieja]'))
	DROP PROCEDURE [MMEL].getFacturaVieja
go

create procedure mmel.getFacturaVieja(@valorBase int output,@valorConsumibles int output, @cantidadConsumibles int output ,@idEstadia int,@factTotal int output,@FactFecha datetime output,@NroFactura int output)
as
begin

	select @valorBase=itemFacturaMonto from mmel.ItemFactura where idEstadia = @idEstadia and itemDescripcion='VALOR BASE HABITACION'
	select @cantidadConsumibles = sum(itemFacturaCantidad),@valorConsumibles=sum(itemFacturaMonto) from mmel.ItemFactura where idEstadia=@idEstadia and itemDescripcion='VALOR CONSUMIBLE'
	select @factTotal=FactTotal,@NroFactura=NroFactura,@FactFecha=FacturaFecha from mmel.Facturacion where idEstadia=@idEstadia

end

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[getCanTipo]'))
	DROP function [MMEL].getCanTipo
go

create function mmel.getCanTipo(@idTipo int)
returns int
as begin
	if(@idTipo = 1001)
		return 1
	else if(@idTipo = 1002)
		return 2
	else if(@idTipo = 1003)
		return 3
	else if(@idTipo = 1004)
		return 4
	
		return 5
end
go


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[getCantPersonas]'))
	DROP function [MMEL].getCantPersonas
go
create function mmel.getCantPersonas(@idReserva int)
returns int
as
begin
	declare @aux int
	
	select @aux = sum(mmel.getCanTipo(ha.idTipoHabitacion)) from mmel.ReservaPorHabitacion rph,mmel.Habitacion ha 
	where rph.idReserva=@idReserva and rph.idHabitacion=ha.idHabitacion  
	
	return @aux
end

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[getFacturaNueva]'))
	DROP PROCEDURE [MMEL].getFacturaNueva
go


create procedure mmel.getFacturaNueva (@cantDias int output,@cantPersonas int output,@rPrecio int output,@hcantEst int output,@hrEst int output,@cantDiasUtilizados int output,@cantDiasNoUtilizados int output,@chINEstadia datetime output,@chOUTEstadia datetime output,@valorConsumibles int output,@dtoRegimen int output,@idEstadia int)
as
begin
	declare @idHotel int
	declare @idRegimen int
	
	
	
	declare @cantiDiasReservados int
	declare @startdate datetime
	declare @enddate datetime

	declare @idReserva int
	
	select @idReserva=r.idReserva, @idHotel=r.idHotel,@idRegimen=r.idRegimen,@enddateEST=e.FechaCheckOUT,@startdateEST=e.FechaCheckIN,@enddate=(r.FechaHasta),@startdate=(r.FechaDesde)
		from mmel.Estadia e,mmel.Reserva r,mmel.Habitacion h,mmel.TipoHabitacion th,mmel.ReservaPorHabitacion rph
		where e.idReserva=r.idReserva and e.idEstadia=@idEstadia and rph.idHabitacion=h.idHabitacion and rph.idReserva=r.idReserva
	
	SELECT @cantDias=DATEDIFF(day, @startdate, @enddate);
	set @chINEstadia=@startdateEST
	set @chOUTEstadia=@enddateEST
	set @cantPersonas= mmel.getCantPersonas(@idReserva)

	

	set @cantiDiasReservados=@cantDias
	set @cantDiasUtilizados = DATEDIFF(day, @startdateEST, @enddateEST);
	set @cantDiasNoUtilizados=@cantDias*@cantDiasUtilizados

	select @rPrecio = convert(int,r.Precio),@hrEst =ho.RecargaEstrellas ,@hcantEst= ho.CantidadEstrellas
	from mmel.Regimen r, mmel.hotel ho where ho.idHotel=@idHotel and r.idRegimen=@idRegimen

	select @valorConsumibles = sum(c.costo) from mmel.ConsumiblePorEstadia ce,mmel.consumible c where idEstadia=@idEstadia and ce.idConsumible=c.idConsumible

	--set @valorBaseHab = @valorBaseHab * @cantDias*@cantPersonas

	set @dtoRegimen = case
		when @idRegimen=4 then @valorConsumibles else 0
		end
	 

end

go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[crearFactura]'))
	DROP PROCEDURE [MMEL].crearFactura
go

go
create procedure mmel.crearFactura(@idEstadia int,@FactTotal int,@FacturaFecha datetime,@formaDePago varchar(75))
as
begin
	declare @nroFactura int
	declare @idFormaDePago int
	select @nroFactura = max(NroFactura)+1 from mmel.Facturacion	
	select @idFormaDePago = idFormaDePago from mmel.FormaDePago where Descripcion=@formaDePago
	insert into mmel.Facturacion(idEstadia,FactTotal,NroFactura,FacturaFecha,idFormaDePago)
	values(@idEstadia,@FactTotal,@nroFactura,@FacturaFecha,@idFormaDePago)
end
go


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[actualizarCheckIn]'))
	DROP procedure [MMEL].actualizarCheckIn
go


create procedure mmel.actualizarCheckIn (@idEstadia int, @fechaCheckIn datetime,@iduserQueModifica int,@rta int output)
as
begin
	declare @idRecepQueModifica int
	declare @reschin datetime
	declare @idRes int
	set @idRecepQueModifica=@iduserQueModifica
	select @reschin = re.FechaDesde,@idRes=re.idReserva  from mmel.Reserva re,mmel.Estadia e where e.idReserva=re.idReserva
	if(@reschin=@fechaCheckIn)
		begin
		update mmel.Estadia
		set FechaCheckIN = @fechaCheckIn,
		idRecepcionistaCheckIN=@idRecepQueModifica,
		FechaCheckOUT= case
			when Consistente = 'N' then null else FechaCheckOUT
		end,
		Consistente='S'
		where idEstadia=@idEstadia
		set @rta=1
		end
	else
		set @rta=0

	update mmel.Reserva set EstadoReserva='RCI' where idReserva=@idRes
end

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[realizarCheckIn]'))
	DROP procedure [MMEL].realizarCheckIn
go


create procedure mmel.realizarCheckIn(@codigoRes int, @fechaCheckIn datetime,@idRecepQueModifica int)
as
begin

	
	declare @idReserva int
	
	select @idReserva=idReserva from mmel.Reserva where CodigoReserva=@codigoRes
	insert into mmel.Estadia(FechaCheckIN,idRecepcionistaCheckIN,idReserva,Consistente)
	values(@fechaCheckIn,@idRecepQueModifica,@idReserva,'S')

	update mmel.Reserva
	set EstadoReserva='RCI' where CodigoReserva=@codigoRes
end
go



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[agregarConsumibles]'))
	DROP procedure [MMEL].agregarConsumibles
go


create procedure mmel.agregarConsumibles(@codigoReserva varchar(50),@idConsumible int,@cantidad int,@codigoRet int output,@fechaCheckOut datetime,@idEstadia int output)
as
begin

	
	declare @idReserva int


	if exists(select idEstadia from mmel.Estadia es,mmel.Reserva re 
	where re.idReserva=es.idReserva and re.CodigoReserva=@codigoReserva and EstadoReserva='RF')
	begin

		select @idEstadia = es.idEstadia from mmel.Estadia es,mmel.Reserva re 
	where re.idReserva=es.idReserva and re.CodigoReserva=@codigoReserva


		DECLARE @cnt INT = 0;

		WHILE @cnt < @cantidad
		BEGIN
		   insert into mmel.ConsumiblePorEstadia(idEstadia,idConsumible)
		   values(@idEstadia,@idConsumible)
		   SET @cnt = @cnt + 1
		END
		set @codigoRet=1
	end
	else
		begin
		set @codigoRet=0
		set @idEstadia=0 --no hay habitacion ocupada en esta fecha
		end
end

go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[crearConsumible]'))
	DROP procedure [MMEL].crearConsumible
go

create procedure MMEL.crearConsumible(@nombre varchar(75),@costo int,@codigoRet int output)
as
begin

	if not exists(select Nombre,Costo from mmel.Consumible where Costo=@costo and Nombre=@nombre)
		begin
		declare @codigo int
		select @codigo=max(CodigoConsumible + 1) from mmel.Consumible
		insert into mmel.Consumible(Costo,Nombre,CodigoConsumible)
		values(@costo,@nombre,@codigo)
		set @codigoRet=1
		end
	else
		set @codigoRet=0

end
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[actualizarCheckOut]'))
	DROP procedure [MMEL].actualizarCheckOut
go


create procedure MMEL.actualizarCheckOut (@idEstadia int,@fechaCheckOut datetime,@iduserQueModifica int)
as
begin
	declare @idRecepQueModificaCOUT int
	set @idRecepQueModificaCOUT=@iduserQueModifica
	declare @idRes int
	select @idRes=idReserva from mmel.Estadia where idEstadia=@idEstadia

	update mmel.Estadia
	set FechaCheckOut = @fechaCheckOut,
	idRecepcionistaCheckOUT=@idRecepQueModificaCOUT
	where idEstadia=@idEstadia

	update mmel.Reserva set EstadoReserva='RF' where idReserva=@idRes
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ReservasPorHotelYHabitacion]'))
	DROP VIEW [MMEL].[ReservasPorHotelYHabitacion]
GO

CREATE VIEW [MMEL].[ReservasPorHotelYHabitacion]
AS
SELECT        h.idHabitacion, ho.idHotel, r.idReserva, r.FechaDesde, r.FechaHasta, h.NumeroHabitacion, h.Piso,ho.Nombre,
                         r.EstadoReserva, DATEDIFF(day, r.FechaDesde,r.FechaHasta) as Dias
FROM            MMEL.Habitacion h  INNER JOIN
                         MMEL.Hotel ho ON h.idHotel = ho.idHotel INNER JOIN
						 MMEL.ReservaPorHabitacion rph on rph.idHabitacion = h.idHabitacion JOIN
                        MMEL.Reserva r ON rph.idReserva = r.idReserva 
						 AND ho.idHotel = r.idHotel
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

	select top 5 rhhta.Nombre, rhhta.NumeroHabitacion, rhhta.Piso, count(*) as Cantidad
	from #ReservasPorHotelYHabitacionEnTrimestreEnAnio rhhta
	WHERE rhhta.EstadoReserva = 'RF' -- si la reserva no fue finalizada y facturada la ignoro
	GROUP BY rhhta.Nombre, rhhta.NumeroHabitacion, rhhta.Piso
	ORDER BY Cantidad Desc
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
	select top 5 rhhta.Nombre, rhhta.NumeroHabitacion, rhhta.Piso, SUM(rhhta.Dias) as Cantidad
	from #ReservasPorHotelYHabitacionEnTrimestreEnAnio rhhta
	WHERE rhhta.EstadoReserva = 'RF' -- si la reserva no fue finalizada y facturada la ignoro
	GROUP BY rhhta.Nombre, rhhta.NumeroHabitacion, rhhta.Piso
	ORDER BY Cantidad Desc
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionPais]'))
	DROP VIEW [MMEL].[DireccionPais]
GO

CREATE VIEW [MMEL].[DireccionPais]
AS SELECT d.idDireccion,d.Ciudad,d.calle,d.nroCalle, p.idPais, p.Nombre as NombrePais
FROM MMEL.Direccion d 
JOIN MMEL.Pais p on p.idPais = d.idPais;
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ConsumiblesFacturadosPorHotel]'))
	DROP VIEW [MMEL].[ConsumiblesFacturadosPorHotel]
GO

CREATE VIEW [MMEL].[ConsumiblesFacturadosPorHotel]
AS
SELECT        MMEL.Hotel.idHotel, MMEL.Facturacion.idFactura, MMEL.Facturacion.idEstadia, MMEL.Estadia.idReserva, MMEL.ReservaPorHabitacion.idHabitacion, MMEL.ItemFactura.idItemFactura, MMEL.ItemFactura.itemDescripcion, 
                         MMEL.ItemFactura.idConsumible, MMEL.ItemFactura.itemFacturaCantidad, MMEL.ItemFactura.itemFacturaMonto, MMEL.Facturacion.FacturaFecha, MMEL.Hotel.Nombre
FROM            MMEL.Estadia INNER JOIN
                         MMEL.Facturacion ON MMEL.Estadia.idEstadia = MMEL.Facturacion.idEstadia INNER JOIN
                         MMEL.Reserva ON MMEL.Estadia.idReserva = MMEL.Reserva.idReserva INNER JOIN
						 MMEL.ReservaPorHabitacion on MMEL.ReservaPorHabitacion.idReserva = MMEL.Reserva.idReserva JOIN
                         MMEL.Habitacion ON MMEL.ReservaPorHabitacion.idHabitacion = MMEL.Habitacion.idHabitacion INNER JOIN
                         MMEL.Hotel ON MMEL.Habitacion.idHotel = MMEL.Hotel.idHotel INNER JOIN
                         MMEL.ItemFactura ON MMEL.Estadia.idEstadia = MMEL.ItemFactura.idEstadia AND MMEL.Facturacion.idFactura = MMEL.ItemFactura.idFactura
WHERE        (MMEL.ItemFactura.idConsumible IS NOT NULL)
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesConMayorCantidadDeReservasCanceladas]'))
	DROP PROCEDURE [MMEL].HotelesConMayorCantidadDeReservasCanceladas
GO

GO
CREATE PROCEDURE MMEL.HotelesConMayorCantidadDeReservasCanceladas  @anio int,@trimestre int
as
begin

	if 1 = @trimestre
	begin
		select top 5 hot.idHotel, hot.Nombre,
		COUNT(*) as Cantidad from mmel.CancelacionReserva cr join mmel.reserva r on cr.idReserva = r.idReserva
											 join mmel.ReservaPorHabitacion rph on rph.idReserva = r.idReserva
											 join mmel.Habitacion h on rph.idHabitacion = h.idHabitacion
											 join mmel.Hotel hot on h.idHotel = hot.idHotel
											  where  year(cr.FechaDeCancelacion)= @anio and (month(cr.FechaDeCancelacion) = 1 OR month(cr.FechaDeCancelacion) = 2 OR month(cr.FechaDeCancelacion)=3)
											GROUP BY hot.idHotel, hot.Nombre
											ORDER BY Cantidad DESC

	end
	if 2 = @trimestre
	begin
			select top 5 hot.idHotel, hot.Nombre,
		COUNT(*) as Cantidad from mmel.CancelacionReserva cr join mmel.reserva r on cr.idReserva = r.idReserva
											 join mmel.ReservaPorHabitacion rph on rph.idReserva = r.idReserva
											 join mmel.Habitacion h on rph.idHabitacion = h.idHabitacion
											 join mmel.Hotel hot on h.idHotel = hot.idHotel
											  where  year(cr.FechaDeCancelacion)= @anio and (month(cr.FechaDeCancelacion) = 4 OR month(cr.FechaDeCancelacion) = 5 OR month(cr.FechaDeCancelacion)=6)
											GROUP BY hot.idHotel, hot.Nombre
											ORDER BY Cantidad DESC
	end
	if 3 = @trimestre
	begin
			select top 5 hot.idHotel, hot.Nombre,
		COUNT(*) as Cantidad from mmel.CancelacionReserva cr join mmel.reserva r on cr.idReserva = r.idReserva
											 join mmel.ReservaPorHabitacion rph on rph.idReserva = r.idReserva
											 join mmel.Habitacion h on rph.idHabitacion = h.idHabitacion
											 join mmel.Hotel hot on h.idHotel = hot.idHotel
											  where  year(cr.FechaDeCancelacion)= @anio and (month(cr.FechaDeCancelacion) = 7 OR month(cr.FechaDeCancelacion) = 8 OR month(cr.FechaDeCancelacion)=9)
											GROUP BY hot.idHotel, hot.Nombre
											ORDER BY Cantidad DESC
	end
	if 4 = @trimestre
 	begin
		select top 5 hot.idHotel, hot.Nombre,
		COUNT(*) as Cantidad from mmel.CancelacionReserva cr join mmel.reserva r on cr.idReserva = r.idReserva
											 join mmel.ReservaPorHabitacion rph on rph.idReserva = r.idReserva
											 join mmel.Habitacion h on rph.idHabitacion = h.idHabitacion
											 join mmel.Hotel hot on h.idHotel = hot.idHotel
											  where  year(cr.FechaDeCancelacion)= @anio and (month(cr.FechaDeCancelacion) = 10 OR month(cr.FechaDeCancelacion) = 11 OR month(cr.FechaDeCancelacion)=12)
											GROUP BY hot.idHotel, hot.Nombre
											ORDER BY Cantidad DESC
	end
end
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[FacturasPorCliente]'))
	DROP VIEW [MMEL].[FacturasPorCliente]
GO

CREATE VIEW [MMEL].[FacturasPorCliente]
AS
SELECT        MMEL.Persona.idPersona, MMEL.Reserva.idReserva, MMEL.Facturacion.idFactura, MMEL.Estadia.idEstadia, MMEL.Facturacion.FacturaFecha
FROM            MMEL.Estadia INNER JOIN
                         MMEL.Reserva ON MMEL.Estadia.idReserva = MMEL.Reserva.idReserva INNER JOIN
                         MMEL.Facturacion ON MMEL.Estadia.idEstadia = MMEL.Facturacion.idEstadia INNER JOIN
                         MMEL.Persona ON MMEL.Reserva.idHuesped = MMEL.Persona.idPersona
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ClientesConMayorCantidadDePuntos]'))
	DROP PROCEDURE [MMEL].[ClientesConMayorCantidadDePuntos]
GO

CREATE PROCEDURE [MMEL].[ClientesConMayorCantidadDePuntos]
	-- Add the parameters for the stored procedure here
	@anio int, 
	@trimestre int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
		SET NOCOUNT ON;

	select *
	into #FacturasPorClienteEnAnio
	from MMEL.FacturasPorCliente rhh
	WHERE year(rhh.FacturaFecha) = @anio

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
	into #FacturasPorClienteEnTrimestreEnAnio
	from #FacturasPorClienteEnAnio rhh
	WHERE	(month(rhh.FacturaFecha) = @firstMonth)
			OR (month(rhh.FacturaFecha) = @secondMonth)
			OR (month(rhh.FacturaFecha) = @thirdMonth) -- solo si fueron facturadas en el trimestre			

	SELECT ifa.idFactura, fpcetea.idEstadia, fpcetea.idPersona, ifa.itemFacturaMonto
	into #EstadiasFacturadasPorClienteEnTrimestre
	FROM #FacturasPorClienteEnTrimestreEnAnio  fpcetea
	INNER JOIN  MMEL.ItemFactura AS ifa ON  fpcetea.idFactura = ifa.idFactura
	WHERE  (ifa.itemDescripcion = 'VALOR BASE HABITACION')

	SELECT efpct.idPersona, SUM(efpct.itemFacturaMonto) / 20 as PuntosEstadia
	into #PuntosPorEstadiaPorCliente
	FROM #EstadiasFacturadasPorClienteEnTrimestre efpct
	GROUP BY efpct.idPersona
	ORDER BY PuntosEstadia DESC

	SELECT        fpc.idPersona, SUM(ifa.itemFacturaCantidad * ifa.itemFacturaMonto) / 10 as PuntosConsumibles
	into #PuntosPorConsumiblesPorCliente
	FROM            MMEL.ItemFactura AS ifa INNER JOIN
								#FacturasPorClienteEnTrimestreEnAnio AS fpc ON ifa.idFactura = fpc.idFactura
	WHERE        (ifa.idConsumible IS NOT NULL)
	GROUP BY fpc.idPersona
	ORDER BY PuntosConsumibles DESC

	SELECT top 5 ppe.idPersona, p.Nombre, p.Apellido, ppe.PuntosEstadia + ppc.PuntosConsumibles as Puntos -- Por fin!
	FROM #PuntosPorEstadiaPorCliente ppe
	LEFT JOIN #PuntosPorConsumiblesPorCliente ppc on ppe.idPersona = ppc.idPersona
	JOIN Persona p on ppe.idPersona = p.idPersona
	GROUP BY ppe.idPersona, p.Nombre, p.Apellido, ppe.PuntosEstadia, ppc.PuntosConsumibles
	ORDER BY Puntos DESC

END
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesConMayorCantidadDeConsumiblesFacturados]'))
	DROP PROCEDURE [MMEL].[HotelesConMayorCantidadDeConsumiblesFacturados]
GO

CREATE PROCEDURE [MMEL].[HotelesConMayorCantidadDeConsumiblesFacturados]
	-- Add the parameters for the stored procedure here
	@anio int,
	@trimestre int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	select *
	into #ConsumiblesFacturadosPorHotelEnAnio
	from MMEL.ConsumiblesFacturadosPorHotel cfh
	WHERE year(cfh.FacturaFecha) = @anio

    -- Insert statements for procedure here
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
	into #ConsumiblesFacturadosPorHotelEnAnioEnTrimestre
	from #ConsumiblesFacturadosPorHotelEnAnio rhh
	WHERE	(month(rhh.FacturaFecha) = @firstMonth)
			OR (month(rhh.FacturaFecha) = @secondMonth)
			OR (month(rhh.FacturaFecha) = @thirdMonth)

	select top 5 cfhat.idHotel, cfhat.Nombre, count(*) as Cantidad
	from #ConsumiblesFacturadosPorHotelEnAnioEnTrimestre cfhat
	GROUP BY cfhat.idHotel, cfhat.Nombre
	ORDER BY Cantidad DESC

END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelDarBaja]'))
	DROP PROCEDURE [MMEL].[HotelDarBaja]
GO

CREATE PROCEDURE [MMEL].[HotelDarBaja]
	-- Add the parameters for the stored procedure here
	@idHotel int,
	@FechaInicio datetime,
	@FechaFin datetime,
	@Motivo varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @ReservasEnIntervalo int;

	SELECT @ReservasEnIntervalo = count(*) 
	FROM ReservasNoCanceladas r
	where r.idHotel = @idHotel AND
			(r.FechaDesde <= @FechaFin
			AND r.FechaHasta >= @FechaInicio) -- existe overlap de fechas

	IF @ReservasEnIntervalo > 0
		SELECT -1 as Resultado -- No se puede dar de baja un hotel si hay reservas en el periodo (y por ende si hay huespedes tmb)
	ELSE
		BEGIN
			
			INSERT INTO MMEL.HotelBajas (idHotel,FechaDesde,FechaHasta,Motivo)
			VALUES (@idHotel, @FechaInicio, @FechaFin, @Motivo);

			SELECT SCOPE_IDENTITY() as Resultado
		END


END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DiasDeBajaPorBajaPorHotel]'))
	DROP VIEW [MMEL].[DiasDeBajaPorBajaPorHotel]
GO


CREATE VIEW [MMEL].[DiasDeBajaPorBajaPorHotel]
AS
SELECT        MMEL.Hotel.idHotel, MMEL.Hotel.Nombre, MMEL.HotelBajas.idBaja, DATEDIFF(day, MMEL.HotelBajas.FechaDesde, MMEL.HotelBajas.FechaHasta) AS Dias, MMEL.HotelBajas.FechaDesde, 
                         MMEL.HotelBajas.FechaHasta
FROM            MMEL.Hotel INNER JOIN
                         MMEL.HotelBajas ON MMEL.Hotel.idHotel = MMEL.HotelBajas.idHotel
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesConMayorCantidadDeDiasFueraDeServicio]'))
	DROP PROCEDURE [MMEL].[HotelesConMayorCantidadDeDiasFueraDeServicio]
GO

CREATE PROCEDURE [MMEL].[HotelesConMayorCantidadDeDiasFueraDeServicio]
	@anio int, 
	@trimestre int
AS
BEGIN
	SET NOCOUNT ON;

	select *
	into #DiasDeBajaPorBajaPorHotelPorAnio
	from MMEL.DiasDeBajaPorBajaPorHotel dbbh
	WHERE year(dbbh.FechaDesde) = @anio OR year(dbbh.FechaHasta) = @anio

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
	into #DiasDeBajaPorBajaPorHotelEnTrimestreEnAnio
	from #DiasDeBajaPorBajaPorHotelPorAnio rhh
	WHERE	(month(rhh.FechaDesde) = @firstMonth OR month(rhh.FechaHasta) = @firstMonth)
			OR (month(rhh.FechaDesde) = @secondMonth OR month(rhh.FechaHasta) = @secondMonth)
			OR (month(rhh.FechaDesde) = @thirdMonth OR month(rhh.FechaHasta) = @thirdMonth) -- O bien arrancaron o terminaron en el trimestre, o estan totalmente contenidas (arrancaron Y terminaron)


	select top 5 dbb.idHotel, dbb.Nombre, SUM(dbb.Dias) as Cantidad
	from #DiasDeBajaPorBajaPorHotelEnTrimestreEnAnio dbb
	GROUP BY dbb.idHotel, dbb.Nombre
	ORDER BY Cantidad DESC
END
GO



