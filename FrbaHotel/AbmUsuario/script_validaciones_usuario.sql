USE [GD1C2018]
GO
/****** Object:  UserDefinedFunction [MMEL].[existeUsuario]    Script Date: 28/6/2018 18:47:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [MMEL].[existeUsuario](
	
	@idTipoDocumento int, 
	@nroDocumento int,
	@Mail nvarchar(200),
	@Username nvarchar(200)
	)
RETURNS int

AS
BEGIN

	IF EXISTS (
		SELECT TOP 1 * 
		FROM MMEL.Usuarios U JOIN MMEL.Persona P ON U.idPersona = P.idPersona
		WHERE P.idTipoDocumento = @idTipoDocumento AND P.NroDocumento = @nroDocumento) 
	BEGIN 
		RETURN 1 -- Ya existe la combinación de Tipo y Número de documento en la BDD.
	END

	IF EXISTS (
		SELECT TOP 1 * 
		FROM MMEL.Usuarios U JOIN Persona P ON U.idPersona = P.idPersona
		WHERE P.Mail = @Mail)
	BEGIN 
		RETURN 2 -- Ya existe el Mail en la BDD.
	END
	IF EXISTS (
		SELECT TOP 1 * 
		FROM MMEL.Usuarios U
		WHERE U.Username = @Username) -- Ya existe el Username en la BDD.
	BEGIN 
		RETURN 3 -- Ya existe un usuario con ese Username en la BDD.
	END

	RETURN 0 -- No existe un usuario con ninguno de esos atributos en la BDD.
END