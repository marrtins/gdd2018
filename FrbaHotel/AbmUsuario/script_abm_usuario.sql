USE GD1C2018
GO
USE [GD1C2018]
GO
/****** Object:  StoredProcedure [MMEL].[UsuarioListar]    Script Date: 13/6/2018 22:27:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [MMEL].[UsuarioListar]  
    @Username nvarchar(200),
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
    @idRol int,
	@TipoDocumento varchar(15),
	@NroDocumento int,
    @Mail nvarchar(200)
AS   

    SET NOCOUNT ON;  

    SELECT * 
    FROM MMEL.Usuario us
    JOIN MMEL.Persona pe on us.idPersona = pe.idPersona
	JOIN MMEL.RolesPorUsuario rpu on us.idUsuario = rpu.idUsuario
	JOIN MMEL.Rol ro on rpu.idRol = ro.idRol
    WHERE (@Username is null or us.Username LIKE '%' + @Username + '%')
            and (@Nombre is null or pe.Nombre LIKE '%' + @Nombre + '%')
            and (@Apellido is null or pe.Apellido LIKE '%' + @Nombre + '%')
            and (@TipoDocumento is null or pe.TipoDocumento = @TipoDocumento)
			and (@NroDocumento is null or pe.NroDocumento = @NroDocumento)
			and (@idRol is null or ro.idRol = @idRol)
			and (@Mail is null or pe.Mail LIKE '%' + @Mail + '%')





USE [GD1C2018]
GO
/****** Object:  StoredProcedure [MMEL].[HotelDelete]    Script Date: 13/6/2018 22:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [MMEL].[UsuarioDelete] 
    @idUsuario int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [MMEL].[Usuario]
	SET    [Usuario].Activo = 'N'
	WHERE  [Usuario].idUsuario = @idUsuario

	COMMIT




USE [GD1C2018]
GO
/****** Object:  StoredProcedure [MMEL].[UsuarioCrear]    Script Date: 13/6/2018 22:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [MMEL].[UsuarioCrear] 
    @idAdmin int,
	@Username nvarchar(200),
	@Password nvarchar(200),
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
    @idRol int,
	@TipoDocumento varchar(15),
	@NroDocumento int,
	@FechaDeNacimiento datetime,
    @Mail nvarchar(200),
    @Telefono varchar(20) = NULL,
	@dirCalle nvarchar(150) = NULL,
    @dirNroCalle int = NULL,
	@dirPiso smallint = NULL,
	@dirDepto char(2) = NULL,
    @dirIdPais int = NULL,
	@Activo char = NULL

AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DECLARE @rol [varchar](50);

	SELECT @rol = Nombre FROM Rol r JOIN UsuariosPorRoles upr on upr.idRol = r.idRol WHERE upr.idUsuario = @idAdmin 
	
	IF @rol != 'administrador'
		THROW 51000, 'El usuario no es administrador', 1; 

	INSERT INTO [MMEL].[Persona] ([Nombre], [Apellido], [TipoDocumento], [NroDocumento], [FechaDenacimiento], [Mail], [Telefono], [dirCalle], [dirNroCalle], [dirPiso], [dirDepto], [dirIdPais])
	SELECT @Nombre, @Apellido, @TipoDocumento, @NroDocumento, @FechaDeNacimiento, @Mail, @Telefono, @dirCalle, @dirNroCalle, @dirPiso, @dirDepto, @dirIdPais
	
	DECLARE @idPersona int = SCOPE_IDENTITY();


	INSERT INTO [MMEL].[Usuario] ([Username], [Password], [idPersona], [idRol], [Activo])
	SELECT @Username, @Password, @idPersona, @idRol, @Activo

	DECLARE @idUsuario int  =  SCOPE_IDENTITY();

	INSERT INTO [MMEL].[HotelesPorUsuarios]
           ([idUsuario]
           ,[idHotel])
     VALUES
			(@idAdmin,
			@idUsuario)

	SELECT SCOPE_IDENTITY() as Id

               
	COMMIT



USE [GD1C2018]
GO
/****** Object:  StoredProcedure [MMEL].[HotelUpdate]    Script Date: 13/6/2018 22:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [MMEL].[UsuarioUpdate] 
	@idAdmin int,
    @idUsuario int,
	@Username nvarchar(200),
	@Password nvarchar(200),
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
    @idRol int,
	@TipoDocumento varchar(15),
	@NroDocumento int,
	@FechaDeNacimiento datetime,
    @Mail nvarchar(200),
    @Telefono varchar(20) = NULL,
	@dirCalle nvarchar(150) = NULL,
    @dirNroCalle int = NULL,
	@dirPiso smallint = NULL,
	@dirDepto char(2) = NULL,
    @dirIdPais int = NULL,
	@Activo char = NULL

AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DECLARE @rol [varchar](50);

	SELECT @rol = Nombre FROM Rol r JOIN UsuariosPorRoles upr on upr.idRol = r.idRol WHERE upr.idUsuario = @idAdmin 
	
	IF @rol != 'administrador'
		THROW 51000, 'El usuario no es administrador', 1; 


	UPDATE [MMEL].[Usuario]
	SET    [Username] = @Username, [Password] = @Password, [idRol] = @idRol, [Activo] = @Activo
	WHERE  [idUsuario] = @idUsuario

	DECLARE @idPersona int;
	SELECT @idPersona FROM Persona P JOIN Usuario U WHERE U.idUsuario = @idUsuario AND U.idPersona = P.idPersona
	
	UPDATE [MMEL].[Persona]
	SET    [Nombre] = @Nombre, [Apellido] = @Apellido, [TipoDocumento] = @TipoDocumento, [NroDocumento] = @NroDocumento, [FechaDenacimiento] = @FechaDeNacimiento, [Mail] = @Mail, [Telefono] = @Telefono, [dirCalle] = @dirCalle, [dirNroCalle] = @dirNroCalle, [dirPiso] = @dirPiso, [dirDepto] = @dirDepto, [dirIdPais] = @dirIdPais
	WHERE  [idPersona] = @idPersona

	SELECT [idUsuario]
	FROM   [MMEL].[Usuario]
	WHERE  [idUsuario] = @idUsuario

	COMMIT


USE [GD1C2018]
GO
/****** Object:  StoredProcedure [MMEL].[RolesListar]    Script Date: 26/6/2018 17:22:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [MMEL].[TiposDocumentoListar] 
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idTipoDocumento], [detalle]
	FROM   [MMEL].[TipoDocumento]

	COMMIT
