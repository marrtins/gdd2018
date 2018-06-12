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
	WHERE   @Piso= piso and
@VistaAlExterior =VistaAlExterior  and
 @NumeroHabitacion =  hab.NumeroHabitacion and
 @IdHotel = hab.IdHotel  
END
GO
ALTER PROCEDURE [MMEL].[HabitacionesAlta]
@IdTipoHabitacion int,
                   @NumeroHabitacion int,
                    @IdHotel int,
                   @Piso int,
                   @VistaAlExterior char(1),
                   @Descripcion nvarchar(80),
                   @Habilitado bit = null
AS
SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
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
GO


GO
ALTER PROCEDURE [MMEL].[HabitacionesBaja]
@IdTipoHabitacion int,
                   @NumeroHabitacion int,
                    @IdHotel int,
                   @Piso int,
                   @VistaAlExterior char(1),
                   @Habilitado bit = null
AS
SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	DELETE FROM [MMEL].[Habitacion] WHERE  @IdTipoHabitacion = [idTipoHabitacion] AND 
	 @NumeroHabitacion = [NumeroHabitacion] AND @IdHotel=[idHotel] AND  @Piso= [Piso] AND @VistaAlExterior= [VistaAlExterior] AND @Habilitado =[Habilitado])
	
               
	COMMIT
GO
ALTER PROCEDURE [MMEL].[HabitacionesModificar]
@IdTipoHabitacion int,
                   @NumeroHabitacion int,
                    @IdHotel int,
                   @Piso int,
                   @VistaAlExterior char(1),
                   @Descripcion nvarchar(80),
                   @Habilitado bit = null
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