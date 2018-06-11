USE GD1C2018
GO
ALTER PROCEDURE [MMEL].[HabitacionesListar]
	-- Add the parameters for the stored procedure here
	@IdTipoHabitacion int,
    @NumeroHabitacion int,
    @IdHotel int,
    @Piso int,
    @VistaAlExterior char(1),
    @Habilitado char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT hab.[idTipoHabitacion],
	[NumeroHabitacion],
	hab.[idHotel],
	[Piso],
	[VistaAlExterior],
	[Habilitado]
	FROM [MMEL].[Habitacion] hab JOIN [MMEL].[Hotel] hot on hot.idHotel = @IdHotel 
								 JOIN [MMEL].[TipoHabitacion] tipoHab on hab.idTipoHabitacion = @IdTipoHabitacion
	WHERE  hab.piso = @Piso 
	and	   hab.VistaAlExterior = @VistaAlExterior
	and    hab.Habilitado = @Habilitado
	and	   hab.NumeroHabitacion = @NumeroHabitacion
    
	
END
