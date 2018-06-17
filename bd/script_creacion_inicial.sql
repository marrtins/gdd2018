

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
GO

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

CREATE TABLE [MMEL].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Contraseña] [varchar](75) NULL,
	[idPersona] [int] NULL,
	[Activo] [char](1) NULL,
	[Username] [nvarchar](200) NULL,
	[IngresosFallidos] [int] NOT NULL,
 CONSTRAINT [PK_idUsuario] PRIMARY  key(idUsuario )
 )
GO
ALTER TABLE [MMEL].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_IngresosFallidos]  DEFAULT ((0)) FOR [IngresosFallidos]
GO

CREATE TABLE [MMEL].[Hotel](
	[idHotel] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [varchar](200) NULL,
	[idDireccion] [int] NULL,
	[Telefono] [varchar](20) NULL,
	[CantidadEstrellas] [int] NULL,
	[FechaDeCreacion] [smalldatetime] NULL,
	[Nombre] [varchar](200) NULL,
	[Inhabilitado] [bit] NULL,
 
 CONSTRAINT [PK_idHotel] PRIMARY  key(idHotel ))

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
	constraint PK_idHabitacion primary key(idHabitacion)
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


/*
--Hoteles con mayor cantidad de reservas canceladas
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
										   join mmel.consumiblesporestaida cpr on e.idEstadia = cpr.idEstadia
									       join mmel.consumible c on cpr.idConsumible = c.idConsumible
										   where year(f.FacturaFecha) = @Año and (month(f.FacturaFecha) = 1 OR month(f.FacturaFecha) = 2 or month(f.FacturaFecha) = 3)
	end
	if '2ºTrimestre (1º de Abril ~ 30 de Junio)' = @Trimestre
	begin
	select top 5 * from mmel.Facturacion f join mmel.Estadia e on f.idEstadia = e.idEstadia
										   join mmel.consumiblesporestaida cpr on e.idEstadia = cpr.idEstadia
									       join mmel.consumible c on cpr.idConsumible = c.idConsumible
										   where year(f.FacturaFecha) = @Año and (month(f.FacturaFecha) = 4 OR month(f.FacturaFecha) = 5 or month(f.FacturaFecha) = 6)
	end
	if '3ºTrimestre (1º de Julio ~ 30 de Septiembre)' = @Trimestre
	begin
	select top 5 * from mmel.Facturacion f join mmel.Estadia e on f.idEstadia = e.idEstadia
										   join mmel.consumiblesporestaida cpr on e.idEstadia = cpr.idEstadia
									       join mmel.consumible c on cpr.idConsumible = c.idConsumible
										   where year(f.FacturaFecha) = @Año and (month(f.FacturaFecha) = 7 OR month(f.FacturaFecha) = 8 or month(f.FacturaFecha) = 9)
	end	
	if '4ºTrimestre (1º de Octubre ~ 31 de Diciembre)' = @Trimestre
 	begin
	select top 5 * from mmel.Facturacion f join mmel.Estadia e on f.idEstadia = e.idEstadia
										   join mmel.consumiblesporestaida cpr on e.idEstadia = cpr.idEstadia
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















