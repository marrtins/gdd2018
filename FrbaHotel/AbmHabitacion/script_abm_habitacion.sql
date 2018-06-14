USE GD1C2018
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