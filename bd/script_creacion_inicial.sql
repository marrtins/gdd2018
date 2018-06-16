

Use GD1C2018

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


IF NOT EXISTS ( SELECT  * FROM    sys.schemas  WHERE   name = N'MMEL' ) 
		EXEC('CREATE SCHEMA [MMEL] AUTHORIZATION [gdHotel2018]');
go



Create Table [MMEL].[Pais](
	idPais int identity(1,1) not null,
	Nombre nvarchar(50) not null,
	constraint PK_idPais Primary Key(idPais)
	)


Create Table [MMEL].[Direccion](
	idDireccion int identity(1,1) not null,
	calle nvarchar(150),
	nroCalle int , --AGREGAR EN DER! --VERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRr
	idPais int references MMEL.Pais(idPais),
	--Piso smallint,
	--Depto char(2),
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

create table [MMEL].[Usuarios](
	idUsuario int identity(1,1) not null,
	Contraseña varchar(75),
	idPersona int references MMEL.Persona(idPersona),
	Activo char(1),
	constraint PK_idUsuario primary key(idUsuario)
	)
Create Table [MMEL].[Hotel](
	idHotel int identity(1,1) not null,
	Mail varchar(200),
	idDireccion int references MMEL.Direccion(idDireccion),
	Telefono varchar(20) ,
	CantidadEstrellas int , --CAMBIAR EN DER!!!!! no es cant estadias
	--Ciudad varchar(50) not null,--sacar de aca, tiene q ir en la tabla direccion
	--idPais int references MMEL.Pais(idPais), --sacar de aca, tiene q ir en la tabla direccion
	RecargaEstrellas int , ----AGGREGAR EN DER!!!!!!!!! VER ESTOOOOOOOOOOOOOOOOO
	FechaDeCreacion smalldatetime , ---AGREGAR EN DER!!!!!!!!! 
	constraint PK_idHotel primary key(idHotel)
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
	EstadoReserva char(1) ,
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
ALTER PROCEDURE [MMEL].[HabitacionesListar]
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

GO
ALTER PROCEDURE [MMEL].[HabitacionesAlta]
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


GO
ALTER PROCEDURE [MMEL].[HabitacionesBaja]
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
	 @NumeroHabitacion = [NumeroHabitacion] AND @IdHotel=[idHotel] AND  @Piso= [Piso] AND @VistaAlExterior= [VistaAlExterior] 
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
ALTER PROCEDURE [MMEL].[HabitacionesModificar]
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























