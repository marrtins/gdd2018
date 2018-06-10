USE [GD1C2018]
GO
/****** Object:  StoredProcedure [MMEL].[RolesDeUsuario]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[RolesDeUsuario]
GO
/****** Object:  StoredProcedure [MMEL].[PaisListar]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[PaisListar]
GO
/****** Object:  StoredProcedure [MMEL].[Logear]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[Logear]
GO
/****** Object:  StoredProcedure [MMEL].[HotelUpdate]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[HotelUpdate]
GO
/****** Object:  StoredProcedure [MMEL].[HotelListar]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[HotelListar]
GO
/****** Object:  StoredProcedure [MMEL].[HotelDelete]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[HotelDelete]
GO
/****** Object:  StoredProcedure [MMEL].[HotelCrear]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[HotelCrear]
GO
/****** Object:  StoredProcedure [MMEL].[DireccionUpdate]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[DireccionUpdate]
GO
/****** Object:  StoredProcedure [MMEL].[DireccionSelect]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[DireccionSelect]
GO
/****** Object:  StoredProcedure [MMEL].[DireccionInsert]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[DireccionInsert]
GO
/****** Object:  StoredProcedure [MMEL].[DireccionDelete]    Script Date: 9/6/2018 22:37:21 ******/
DROP PROCEDURE IF EXISTS [MMEL].[DireccionDelete]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[UsuariosPorRoles]') AND type in (N'U'))
ALTER TABLE [MMEL].[UsuariosPorRoles] DROP CONSTRAINT IF EXISTS [FK__UsuariosP__idUsu__2BFE89A6]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[UsuariosPorRoles]') AND type in (N'U'))
ALTER TABLE [MMEL].[UsuariosPorRoles] DROP CONSTRAINT IF EXISTS [FK__UsuariosP__idRol__2B0A656D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Usuarios]') AND type in (N'U'))
ALTER TABLE [MMEL].[Usuarios] DROP CONSTRAINT IF EXISTS [FK__Usuarios__idPers__19DFD96B]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RolesPorFuncionalidades]') AND type in (N'U'))
ALTER TABLE [MMEL].[RolesPorFuncionalidades] DROP CONSTRAINT IF EXISTS [FK__RolesPorF__idRol__31B762FC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RolesPorFuncionalidades]') AND type in (N'U'))
ALTER TABLE [MMEL].[RolesPorFuncionalidades] DROP CONSTRAINT IF EXISTS [FK__RolesPorF__idFun__30C33EC3]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Reserva]') AND type in (N'U'))
ALTER TABLE [MMEL].[Reserva] DROP CONSTRAINT IF EXISTS [FK__Reserva__idUsuar__3D2915A8]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Reserva]') AND type in (N'U'))
ALTER TABLE [MMEL].[Reserva] DROP CONSTRAINT IF EXISTS [FK__Reserva__idRegim__3F115E1A]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Reserva]') AND type in (N'U'))
ALTER TABLE [MMEL].[Reserva] DROP CONSTRAINT IF EXISTS [FK__Reserva__idHuesp__40058253]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Reserva]') AND type in (N'U'))
ALTER TABLE [MMEL].[Reserva] DROP CONSTRAINT IF EXISTS [FK__Reserva__idHabit__3E1D39E1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RegimenesPorHotel]') AND type in (N'U'))
ALTER TABLE [MMEL].[RegimenesPorHotel] DROP CONSTRAINT IF EXISTS [FK__Regimenes__idReg__2180FB33]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RegimenesPorHotel]') AND type in (N'U'))
ALTER TABLE [MMEL].[RegimenesPorHotel] DROP CONSTRAINT IF EXISTS [FK__Regimenes__idHot__22751F6C]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Persona]') AND type in (N'U'))
ALTER TABLE [MMEL].[Persona] DROP CONSTRAINT IF EXISTS [FK__Persona__dirIdPa__17036CC0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ItemFactura]') AND type in (N'U'))
ALTER TABLE [MMEL].[ItemFactura] DROP CONSTRAINT IF EXISTS [FK__ItemFactu__idFac__531856C7]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ItemFactura]') AND type in (N'U'))
ALTER TABLE [MMEL].[ItemFactura] DROP CONSTRAINT IF EXISTS [FK__ItemFactu__idEst__540C7B00]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ItemFactura]') AND type in (N'U'))
ALTER TABLE [MMEL].[ItemFactura] DROP CONSTRAINT IF EXISTS [FK__ItemFactu__idCon__55009F39]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Huesped]') AND type in (N'U'))
ALTER TABLE [MMEL].[Huesped] DROP CONSTRAINT IF EXISTS [FK__Huesped__idUsuar__3A4CA8FD]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesPorUsuarios]') AND type in (N'U'))
ALTER TABLE [MMEL].[HotelesPorUsuarios] DROP CONSTRAINT IF EXISTS [FK__HotelesPo__idUsu__25518C17]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesPorUsuarios]') AND type in (N'U'))
ALTER TABLE [MMEL].[HotelesPorUsuarios] DROP CONSTRAINT IF EXISTS [FK__HotelesPo__idHot__2645B050]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Hotel]') AND type in (N'U'))
ALTER TABLE [MMEL].[Hotel] DROP CONSTRAINT IF EXISTS [FK__Hotel__idDirecci__1CBC4616]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Habitacion]') AND type in (N'U'))
ALTER TABLE [MMEL].[Habitacion] DROP CONSTRAINT IF EXISTS [FK__Habitacio__idTip__37703C52]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Habitacion]') AND type in (N'U'))
ALTER TABLE [MMEL].[Habitacion] DROP CONSTRAINT IF EXISTS [FK__Habitacio__idHot__367C1819]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[FacturacionPorEstadia]') AND type in (N'U'))
ALTER TABLE [MMEL].[FacturacionPorEstadia] DROP CONSTRAINT IF EXISTS [FK__Facturaci__idFac__5CA1C101]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[FacturacionPorEstadia]') AND type in (N'U'))
ALTER TABLE [MMEL].[FacturacionPorEstadia] DROP CONSTRAINT IF EXISTS [FK__Facturaci__idEst__5BAD9CC8]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Facturacion]') AND type in (N'U'))
ALTER TABLE [MMEL].[Facturacion] DROP CONSTRAINT IF EXISTS [FK__Facturaci__idFor__4F47C5E3]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Facturacion]') AND type in (N'U'))
ALTER TABLE [MMEL].[Facturacion] DROP CONSTRAINT IF EXISTS [FK__Facturaci__idEst__503BEA1C]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Estadia]') AND type in (N'U'))
ALTER TABLE [MMEL].[Estadia] DROP CONSTRAINT IF EXISTS [FK__Estadia__idReser__42E1EEFE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Estadia]') AND type in (N'U'))
ALTER TABLE [MMEL].[Estadia] DROP CONSTRAINT IF EXISTS [FK__Estadia__idRecep__44CA3770]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Estadia]') AND type in (N'U'))
ALTER TABLE [MMEL].[Estadia] DROP CONSTRAINT IF EXISTS [FK__Estadia__idRecep__43D61337]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Direccion]') AND type in (N'U'))
ALTER TABLE [MMEL].[Direccion] DROP CONSTRAINT IF EXISTS [FK__Direccion__idPai__14270015]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ConsumiblePorEstadia]') AND type in (N'U'))
ALTER TABLE [MMEL].[ConsumiblePorEstadia] DROP CONSTRAINT IF EXISTS [FK__Consumibl__idEst__498EEC8D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ConsumiblePorEstadia]') AND type in (N'U'))
ALTER TABLE [MMEL].[ConsumiblePorEstadia] DROP CONSTRAINT IF EXISTS [FK__Consumibl__idCon__4A8310C6]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[CancelacionReserva]') AND type in (N'U'))
ALTER TABLE [MMEL].[CancelacionReserva] DROP CONSTRAINT IF EXISTS [FK__Cancelaci__idRol__58D1301D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[CancelacionReserva]') AND type in (N'U'))
ALTER TABLE [MMEL].[CancelacionReserva] DROP CONSTRAINT IF EXISTS [FK__Cancelaci__idPer__57DD0BE4]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Usuarios]') AND type in (N'U'))
ALTER TABLE [MMEL].[Usuarios] DROP CONSTRAINT IF EXISTS [DF_Usuarios_IngresosFallidos]
GO
/****** Object:  Table [MMEL].[TipoHabitacion]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[TipoHabitacion]
GO
/****** Object:  Table [MMEL].[RolesPorFuncionalidades]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[RolesPorFuncionalidades]
GO
/****** Object:  Table [MMEL].[Reserva]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Reserva]
GO
/****** Object:  Table [MMEL].[RegimenesPorHotel]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[RegimenesPorHotel]
GO
/****** Object:  Table [MMEL].[Regimen]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Regimen]
GO
/****** Object:  Table [MMEL].[Persona]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Persona]
GO
/****** Object:  Table [MMEL].[ItemFactura]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[ItemFactura]
GO
/****** Object:  Table [MMEL].[Huesped]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Huesped]
GO
/****** Object:  Table [MMEL].[HotelesPorUsuarios]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[HotelesPorUsuarios]
GO
/****** Object:  Table [MMEL].[Hotel]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Hotel]
GO
/****** Object:  Table [MMEL].[Habitacion]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Habitacion]
GO
/****** Object:  Table [MMEL].[Funcionalidades]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Funcionalidades]
GO
/****** Object:  Table [MMEL].[FormaDePago]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[FormaDePago]
GO
/****** Object:  Table [MMEL].[FacturacionPorEstadia]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[FacturacionPorEstadia]
GO
/****** Object:  Table [MMEL].[Facturacion]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Facturacion]
GO
/****** Object:  Table [MMEL].[Estadia]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Estadia]
GO
/****** Object:  Table [MMEL].[ConsumiblePorEstadia]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[ConsumiblePorEstadia]
GO
/****** Object:  Table [MMEL].[Consumible]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Consumible]
GO
/****** Object:  Table [MMEL].[Constantes]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Constantes]
GO
/****** Object:  Table [MMEL].[CancelacionReserva]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[CancelacionReserva]
GO
/****** Object:  View [MMEL].[RolesPorUsuario]    Script Date: 9/6/2018 22:37:21 ******/
DROP VIEW IF EXISTS [MMEL].[RolesPorUsuario]
GO
/****** Object:  Table [MMEL].[UsuariosPorRoles]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[UsuariosPorRoles]
GO
/****** Object:  Table [MMEL].[Rol]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Rol]
GO
/****** Object:  Table [MMEL].[Usuarios]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Usuarios]
GO
/****** Object:  View [MMEL].[DireccionPais]    Script Date: 9/6/2018 22:37:21 ******/
DROP VIEW IF EXISTS [MMEL].[DireccionPais]
GO
/****** Object:  Table [MMEL].[Direccion]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Direccion]
GO
/****** Object:  Table [MMEL].[Pais]    Script Date: 9/6/2018 22:37:21 ******/
DROP TABLE IF EXISTS [MMEL].[Pais]
GO
/****** Object:  Schema [MMEL]    Script Date: 9/6/2018 22:37:21 ******/
DROP SCHEMA IF EXISTS [MMEL]
GO
USE [master]
GO
/****** Object:  Database [GD1C2018]    Script Date: 9/6/2018 22:37:21 ******/
DROP DATABASE IF EXISTS [GD1C2018]
GO
/****** Object:  Database [GD1C2018]    Script Date: 9/6/2018 22:37:21 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'GD1C2018')
BEGIN
CREATE DATABASE [GD1C2018]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tpgdd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\tpgdd.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tpgdd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\tpgdd_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END
GO
ALTER DATABASE [GD1C2018] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GD1C2018].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GD1C2018] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GD1C2018] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GD1C2018] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GD1C2018] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GD1C2018] SET ARITHABORT OFF 
GO
ALTER DATABASE [GD1C2018] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GD1C2018] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GD1C2018] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GD1C2018] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GD1C2018] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GD1C2018] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GD1C2018] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GD1C2018] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GD1C2018] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GD1C2018] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GD1C2018] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GD1C2018] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GD1C2018] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GD1C2018] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GD1C2018] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GD1C2018] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GD1C2018] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GD1C2018] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GD1C2018] SET  MULTI_USER 
GO
ALTER DATABASE [GD1C2018] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GD1C2018] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GD1C2018] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GD1C2018] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GD1C2018] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GD1C2018] SET QUERY_STORE = OFF
GO
USE [GD1C2018]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [GD1C2018]
GO
/****** Object:  Schema [MMEL]    Script Date: 9/6/2018 22:37:21 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'MMEL')
EXEC sys.sp_executesql N'CREATE SCHEMA [MMEL]'
GO
/****** Object:  Table [MMEL].[Pais]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Pais]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Pais](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_idPais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Direccion]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Direccion]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Direccion](
	[idDireccion] [int] IDENTITY(1,1) NOT NULL,
	[calle] [nvarchar](150) NULL,
	[nroCalle] [int] NULL,
	[idPais] [int] NULL,
	[Ciudad] [nvarchar](150) NULL,
 CONSTRAINT [PK_idDireccion] PRIMARY KEY CLUSTERED 
(
	[idDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [MMEL].[DireccionPais]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionPais]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [MMEL].[DireccionPais]
AS SELECT d.idDireccion,d.Ciudad,d.calle,d.nroCalle, p.idPais, p.Nombre as NombrePais
FROM MMEL.Direccion d 
JOIN MMEL.Pais p on p.idPais = d.idPais;
' 
GO
/****** Object:  Table [MMEL].[Usuarios]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Contraseña] [varchar](75) NULL,
	[idPersona] [int] NULL,
	[Activo] [char](1) NULL,
	[Username] [nvarchar](200) NULL,
	[IngresosFallidos] [int] NOT NULL,
 CONSTRAINT [PK_idUsuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Rol]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Rol]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Rol](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [char](1) NOT NULL,
 CONSTRAINT [PK_idRol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[UsuariosPorRoles]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[UsuariosPorRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[UsuariosPorRoles](
	[idUPR] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_idUPR] PRIMARY KEY CLUSTERED 
(
	[idUPR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [MMEL].[RolesPorUsuario]    Script Date: 9/6/2018 22:37:21 ******/
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
/****** Object:  Table [MMEL].[CancelacionReserva]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[CancelacionReserva]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[CancelacionReserva](
	[idReservaCancelacion] [int] IDENTITY(1,1) NOT NULL,
	[Motivo] [varchar](300) NOT NULL,
	[FechaDeCancelacion] [datetime] NOT NULL,
	[idPersona] [int] NULL,
	[idRol] [int] NULL,
 CONSTRAINT [PK_idReservaCancelacion] PRIMARY KEY CLUSTERED 
(
	[idReservaCancelacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Constantes]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Constantes]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Constantes](
	[id] [int] NULL,
	[AplicadoNombre] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Valor] [nvarchar](100) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Consumible]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Consumible]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Consumible](
	[idConsumible] [int] IDENTITY(1,1) NOT NULL,
	[Costo] [int] NULL,
	[Nombre] [varchar](75) NULL,
	[CodigoConsumible] [int] NULL,
 CONSTRAINT [PK_idConsumible] PRIMARY KEY CLUSTERED 
(
	[idConsumible] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[ConsumiblePorEstadia]    Script Date: 9/6/2018 22:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ConsumiblePorEstadia]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[ConsumiblePorEstadia](
	[idCPE] [int] IDENTITY(1,1) NOT NULL,
	[idEstadia] [int] NULL,
	[idConsumible] [int] NULL,
 CONSTRAINT [PK_idCPE] PRIMARY KEY CLUSTERED 
(
	[idCPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Estadia]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Estadia]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Estadia](
	[idEstadia] [int] IDENTITY(1,1) NOT NULL,
	[idReserva] [int] NULL,
	[FechaCheckIN] [datetime] NULL,
	[FechaCheckOUT] [datetime] NULL,
	[idRecepcionistaCheckIN] [int] NULL,
	[idRecepcionistaCheckOUT] [int] NULL,
 CONSTRAINT [PK_idEstadia] PRIMARY KEY CLUSTERED 
(
	[idEstadia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Facturacion]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Facturacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Facturacion](
	[idFactura] [int] IDENTITY(1,1) NOT NULL,
	[idFormaDePago] [int] NULL,
	[idEstadia] [int] NULL,
	[MontoTotal] [int] NULL,
	[FactTotal] [int] NULL,
	[MontoFinal] [int] NULL,
	[NroFactura] [int] NULL,
	[FacturaFecha] [smalldatetime] NULL,
 CONSTRAINT [PK_idFactura] PRIMARY KEY CLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[FacturacionPorEstadia]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[FacturacionPorEstadia]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[FacturacionPorEstadia](
	[idFPE] [int] IDENTITY(1,1) NOT NULL,
	[idEstadia] [int] NULL,
	[idFacturacion] [int] NULL,
 CONSTRAINT [PK_idFPE] PRIMARY KEY CLUSTERED 
(
	[idFPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[FormaDePago]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[FormaDePago]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[FormaDePago](
	[idFormaDePago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_idFormaDePago] PRIMARY KEY CLUSTERED 
(
	[idFormaDePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Funcionalidades]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Funcionalidades]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Funcionalidades](
	[idFuncionalidad] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_idFuncionalidad] PRIMARY KEY CLUSTERED 
(
	[idFuncionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Habitacion]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Habitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Habitacion](
	[idHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[NumeroHabitacion] [int] NULL,
	[Piso] [smallint] NULL,
	[idHotel] [int] NULL,
	[VistaAlExterior] [char](1) NULL,
	[idTipoHabitacion] [int] NULL,
	[Descripcion] [varchar](200) NULL,
	[Habilitado] [char](1) NULL,
 CONSTRAINT [PK_idHabitacion] PRIMARY KEY CLUSTERED 
(
	[idHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Hotel]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Hotel]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Hotel](
	[idHotel] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [varchar](200) NULL,
	[idDireccion] [int] NULL,
	[Telefono] [varchar](20) NULL,
	[CantidadEstrellas] [int] NULL,
	[FechaDeCreacion] [smalldatetime] NULL,
	[Nombre] [varchar](200) NULL,
	[Inhabilitado] [bit] NULL,
 CONSTRAINT [PK_idHotel] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[HotelesPorUsuarios]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelesPorUsuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[HotelesPorUsuarios](
	[idHPU] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idHotel] [int] NULL,
 CONSTRAINT [PK_idHPU] PRIMARY KEY CLUSTERED 
(
	[idHPU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Huesped]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Huesped]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Huesped](
	[idHuesped] [int] IDENTITY(1,1) NOT NULL,
	[Habilitado] [char](1) NULL,
	[Reservo] [char](1) NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_idHuesped] PRIMARY KEY CLUSTERED 
(
	[idHuesped] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[ItemFactura]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[ItemFactura]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[ItemFactura](
	[idItemFactura] [int] IDENTITY(1,1) NOT NULL,
	[idFactura] [int] NULL,
	[idEstadia] [int] NULL,
	[itemDescripcion] [nvarchar](200) NULL,
	[idConsumible] [int] NULL,
	[itemFacturaCantidad] [smallint] NULL,
	[itemFacturaMonto] [int] NULL,
 CONSTRAINT [PK_idItem] PRIMARY KEY CLUSTERED 
(
	[idItemFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Persona]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Persona]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[TipoDocumento] [varchar](15) NULL,
	[NroDocumento] [int] NULL,
	[Mail] [varchar](200) NULL,
	[Telefono] [varchar](20) NULL,
	[FechaDeNacimiento] [datetime] NULL,
	[Nacionalidad] [varchar](50) NULL,
	[dirCalle] [nvarchar](150) NULL,
	[dirNroCalle] [int] NULL,
	[dirIdPais] [int] NULL,
	[dirPiso] [smallint] NULL,
	[dirDepto] [char](2) NULL,
	[dirLocalidad] [nvarchar](150) NULL,
 CONSTRAINT [PK_idPersona] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Regimen]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Regimen]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Regimen](
	[idRegimen] [int] IDENTITY(1,1) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Habilitado] [char](1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_idRegimen] PRIMARY KEY CLUSTERED 
(
	[idRegimen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[RegimenesPorHotel]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RegimenesPorHotel]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[RegimenesPorHotel](
	[idRPH] [int] IDENTITY(1,1) NOT NULL,
	[idRegimen] [int] NULL,
	[idHotel] [int] NULL,
 CONSTRAINT [PK_idRPH] PRIMARY KEY CLUSTERED 
(
	[idRPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[Reserva]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Reserva]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[Reserva](
	[idReserva] [int] IDENTITY(1,1) NOT NULL,
	[idUsuarioQueProcesoReserva] [int] NULL,
	[FechaDeReserva] [datetime] NULL,
	[FechaDesde] [datetime] NULL,
	[FechaHasta] [datetime] NULL,
	[idHabitacion] [int] NULL,
	[idRegimen] [int] NULL,
	[idHuesped] [int] NULL,
	[EstadoReserva] [char](1) NULL,
	[CodigoReserva] [int] NULL,
 CONSTRAINT [PK_idReserva] PRIMARY KEY CLUSTERED 
(
	[idReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[RolesPorFuncionalidades]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RolesPorFuncionalidades]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[RolesPorFuncionalidades](
	[idRPF] [int] IDENTITY(1,1) NOT NULL,
	[idFuncionalidad] [int] NULL,
	[idRol] [int] NULL,
 CONSTRAINT [PK_idRPF] PRIMARY KEY CLUSTERED 
(
	[idRPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [MMEL].[TipoHabitacion]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[TipoHabitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [MMEL].[TipoHabitacion](
	[idTipoHabitacion] [int] NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[TipoPorcentual] [decimal](4, 2) NULL,
 CONSTRAINT [PK_idTipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[idTipoHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DF_Usuarios_IngresosFallidos]') AND type = 'D')
BEGIN
ALTER TABLE [MMEL].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_IngresosFallidos]  DEFAULT ((0)) FOR [IngresosFallidos]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Cancelaci__idPer__57DD0BE4]') AND parent_object_id = OBJECT_ID(N'[MMEL].[CancelacionReserva]'))
ALTER TABLE [MMEL].[CancelacionReserva]  WITH CHECK ADD FOREIGN KEY([idPersona])
REFERENCES [MMEL].[Persona] ([idPersona])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Cancelaci__idRol__58D1301D]') AND parent_object_id = OBJECT_ID(N'[MMEL].[CancelacionReserva]'))
ALTER TABLE [MMEL].[CancelacionReserva]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [MMEL].[Rol] ([idRol])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Consumibl__idCon__4A8310C6]') AND parent_object_id = OBJECT_ID(N'[MMEL].[ConsumiblePorEstadia]'))
ALTER TABLE [MMEL].[ConsumiblePorEstadia]  WITH CHECK ADD FOREIGN KEY([idConsumible])
REFERENCES [MMEL].[Consumible] ([idConsumible])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Consumibl__idEst__498EEC8D]') AND parent_object_id = OBJECT_ID(N'[MMEL].[ConsumiblePorEstadia]'))
ALTER TABLE [MMEL].[ConsumiblePorEstadia]  WITH CHECK ADD FOREIGN KEY([idEstadia])
REFERENCES [MMEL].[Reserva] ([idReserva])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Direccion__idPai__14270015]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Direccion]'))
ALTER TABLE [MMEL].[Direccion]  WITH CHECK ADD FOREIGN KEY([idPais])
REFERENCES [MMEL].[Pais] ([idPais])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Estadia__idRecep__43D61337]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Estadia]'))
ALTER TABLE [MMEL].[Estadia]  WITH CHECK ADD FOREIGN KEY([idRecepcionistaCheckIN])
REFERENCES [MMEL].[Usuarios] ([idUsuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Estadia__idRecep__44CA3770]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Estadia]'))
ALTER TABLE [MMEL].[Estadia]  WITH CHECK ADD FOREIGN KEY([idRecepcionistaCheckOUT])
REFERENCES [MMEL].[Usuarios] ([idUsuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Estadia__idReser__42E1EEFE]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Estadia]'))
ALTER TABLE [MMEL].[Estadia]  WITH CHECK ADD FOREIGN KEY([idReserva])
REFERENCES [MMEL].[Reserva] ([idReserva])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Facturaci__idEst__503BEA1C]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Facturacion]'))
ALTER TABLE [MMEL].[Facturacion]  WITH CHECK ADD FOREIGN KEY([idEstadia])
REFERENCES [MMEL].[Estadia] ([idEstadia])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Facturaci__idFor__4F47C5E3]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Facturacion]'))
ALTER TABLE [MMEL].[Facturacion]  WITH CHECK ADD FOREIGN KEY([idFormaDePago])
REFERENCES [MMEL].[FormaDePago] ([idFormaDePago])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Facturaci__idEst__5BAD9CC8]') AND parent_object_id = OBJECT_ID(N'[MMEL].[FacturacionPorEstadia]'))
ALTER TABLE [MMEL].[FacturacionPorEstadia]  WITH CHECK ADD FOREIGN KEY([idEstadia])
REFERENCES [MMEL].[Estadia] ([idEstadia])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Facturaci__idFac__5CA1C101]') AND parent_object_id = OBJECT_ID(N'[MMEL].[FacturacionPorEstadia]'))
ALTER TABLE [MMEL].[FacturacionPorEstadia]  WITH CHECK ADD FOREIGN KEY([idFacturacion])
REFERENCES [MMEL].[Facturacion] ([idFactura])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Habitacio__idHot__367C1819]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Habitacion]'))
ALTER TABLE [MMEL].[Habitacion]  WITH CHECK ADD FOREIGN KEY([idHotel])
REFERENCES [MMEL].[Hotel] ([idHotel])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Habitacio__idTip__37703C52]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Habitacion]'))
ALTER TABLE [MMEL].[Habitacion]  WITH CHECK ADD FOREIGN KEY([idTipoHabitacion])
REFERENCES [MMEL].[TipoHabitacion] ([idTipoHabitacion])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Hotel__idDirecci__1CBC4616]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Hotel]'))
ALTER TABLE [MMEL].[Hotel]  WITH CHECK ADD FOREIGN KEY([idDireccion])
REFERENCES [MMEL].[Direccion] ([idDireccion])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__HotelesPo__idHot__2645B050]') AND parent_object_id = OBJECT_ID(N'[MMEL].[HotelesPorUsuarios]'))
ALTER TABLE [MMEL].[HotelesPorUsuarios]  WITH CHECK ADD FOREIGN KEY([idHotel])
REFERENCES [MMEL].[Hotel] ([idHotel])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__HotelesPo__idUsu__25518C17]') AND parent_object_id = OBJECT_ID(N'[MMEL].[HotelesPorUsuarios]'))
ALTER TABLE [MMEL].[HotelesPorUsuarios]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [MMEL].[Usuarios] ([idUsuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Huesped__idUsuar__3A4CA8FD]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Huesped]'))
ALTER TABLE [MMEL].[Huesped]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [MMEL].[Usuarios] ([idUsuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__ItemFactu__idCon__55009F39]') AND parent_object_id = OBJECT_ID(N'[MMEL].[ItemFactura]'))
ALTER TABLE [MMEL].[ItemFactura]  WITH CHECK ADD FOREIGN KEY([idConsumible])
REFERENCES [MMEL].[Consumible] ([idConsumible])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__ItemFactu__idEst__540C7B00]') AND parent_object_id = OBJECT_ID(N'[MMEL].[ItemFactura]'))
ALTER TABLE [MMEL].[ItemFactura]  WITH CHECK ADD FOREIGN KEY([idEstadia])
REFERENCES [MMEL].[Estadia] ([idEstadia])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__ItemFactu__idFac__531856C7]') AND parent_object_id = OBJECT_ID(N'[MMEL].[ItemFactura]'))
ALTER TABLE [MMEL].[ItemFactura]  WITH CHECK ADD FOREIGN KEY([idFactura])
REFERENCES [MMEL].[Facturacion] ([idFactura])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Persona__dirIdPa__17036CC0]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Persona]'))
ALTER TABLE [MMEL].[Persona]  WITH CHECK ADD FOREIGN KEY([dirIdPais])
REFERENCES [MMEL].[Pais] ([idPais])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Regimenes__idHot__22751F6C]') AND parent_object_id = OBJECT_ID(N'[MMEL].[RegimenesPorHotel]'))
ALTER TABLE [MMEL].[RegimenesPorHotel]  WITH CHECK ADD FOREIGN KEY([idHotel])
REFERENCES [MMEL].[Hotel] ([idHotel])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Regimenes__idReg__2180FB33]') AND parent_object_id = OBJECT_ID(N'[MMEL].[RegimenesPorHotel]'))
ALTER TABLE [MMEL].[RegimenesPorHotel]  WITH CHECK ADD FOREIGN KEY([idRegimen])
REFERENCES [MMEL].[Regimen] ([idRegimen])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Reserva__idHabit__3E1D39E1]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Reserva]'))
ALTER TABLE [MMEL].[Reserva]  WITH CHECK ADD FOREIGN KEY([idHabitacion])
REFERENCES [MMEL].[Habitacion] ([idHabitacion])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Reserva__idHuesp__40058253]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Reserva]'))
ALTER TABLE [MMEL].[Reserva]  WITH CHECK ADD FOREIGN KEY([idHuesped])
REFERENCES [MMEL].[Huesped] ([idHuesped])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Reserva__idRegim__3F115E1A]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Reserva]'))
ALTER TABLE [MMEL].[Reserva]  WITH CHECK ADD FOREIGN KEY([idRegimen])
REFERENCES [MMEL].[Regimen] ([idRegimen])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Reserva__idUsuar__3D2915A8]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Reserva]'))
ALTER TABLE [MMEL].[Reserva]  WITH CHECK ADD FOREIGN KEY([idUsuarioQueProcesoReserva])
REFERENCES [MMEL].[Usuarios] ([idUsuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__RolesPorF__idFun__30C33EC3]') AND parent_object_id = OBJECT_ID(N'[MMEL].[RolesPorFuncionalidades]'))
ALTER TABLE [MMEL].[RolesPorFuncionalidades]  WITH CHECK ADD FOREIGN KEY([idFuncionalidad])
REFERENCES [MMEL].[Funcionalidades] ([idFuncionalidad])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__RolesPorF__idRol__31B762FC]') AND parent_object_id = OBJECT_ID(N'[MMEL].[RolesPorFuncionalidades]'))
ALTER TABLE [MMEL].[RolesPorFuncionalidades]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [MMEL].[Rol] ([idRol])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__Usuarios__idPers__19DFD96B]') AND parent_object_id = OBJECT_ID(N'[MMEL].[Usuarios]'))
ALTER TABLE [MMEL].[Usuarios]  WITH CHECK ADD FOREIGN KEY([idPersona])
REFERENCES [MMEL].[Persona] ([idPersona])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__UsuariosP__idRol__2B0A656D]') AND parent_object_id = OBJECT_ID(N'[MMEL].[UsuariosPorRoles]'))
ALTER TABLE [MMEL].[UsuariosPorRoles]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [MMEL].[Rol] ([idRol])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[MMEL].[FK__UsuariosP__idUsu__2BFE89A6]') AND parent_object_id = OBJECT_ID(N'[MMEL].[UsuariosPorRoles]'))
ALTER TABLE [MMEL].[UsuariosPorRoles]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [MMEL].[Usuarios] ([idUsuario])
GO
/****** Object:  StoredProcedure [MMEL].[DireccionDelete]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[DireccionDelete] AS' 
END
GO
ALTER PROC [MMEL].[DireccionDelete] 
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
/****** Object:  StoredProcedure [MMEL].[DireccionInsert]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[DireccionInsert] AS' 
END
GO
ALTER PROC [MMEL].[DireccionInsert] 
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
/****** Object:  StoredProcedure [MMEL].[DireccionSelect]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[DireccionSelect] AS' 
END
GO
ALTER PROC [MMEL].[DireccionSelect] 
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
/****** Object:  StoredProcedure [MMEL].[DireccionUpdate]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[DireccionUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[DireccionUpdate] AS' 
END
GO
ALTER PROC [MMEL].[DireccionUpdate] 
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
/****** Object:  StoredProcedure [MMEL].[HotelCrear]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelCrear]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[HotelCrear] AS' 
END
GO

ALTER PROC [MMEL].[HotelCrear] 
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
/****** Object:  StoredProcedure [MMEL].[HotelDelete]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[HotelDelete] AS' 
END
GO
ALTER PROC [MMEL].[HotelDelete] 
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
/****** Object:  StoredProcedure [MMEL].[HotelListar]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelListar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[HotelListar] AS' 
END
GO
ALTER PROCEDURE [MMEL].[HotelListar]  
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
/****** Object:  StoredProcedure [MMEL].[HotelUpdate]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[HotelUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[HotelUpdate] AS' 
END
GO
ALTER PROC [MMEL].[HotelUpdate] 
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
/****** Object:  StoredProcedure [MMEL].[Logear]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[Logear]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[Logear] AS' 
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [MMEL].[Logear]
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
/****** Object:  StoredProcedure [MMEL].[PaisListar]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[PaisListar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[PaisListar] AS' 
END
GO
ALTER PROC [MMEL].[PaisListar]
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
/****** Object:  StoredProcedure [MMEL].[RolesDeUsuario]    Script Date: 9/6/2018 22:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MMEL].[RolesDeUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [MMEL].[RolesDeUsuario] AS' 
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [MMEL].[RolesDeUsuario]
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
USE [master]
GO
ALTER DATABASE [GD1C2018] SET  READ_WRITE 
GO
