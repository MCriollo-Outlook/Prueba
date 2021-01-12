USE JuegosOlimpicos

SET IDENTITY_INSERT Deportista ON 
	INSERT Deportista (IdDeportista,IdPais, [Name]) VALUES (1,1, N'Carlos Alviz')
	INSERT Deportista (IdDeportista,IdPais, [Name]) VALUES (2,2, N'Andres Sabogal')
	INSERT Deportista (IdDeportista,IdPais, [Name]) VALUES (3,3, N'Jorge Ortega')
	INSERT Deportista (IdDeportista,IdPais, [Name]) VALUES (4,4, N'Pablo Velasco')
SET IDENTITY_INSERT Deportista OFF

SET IDENTITY_INSERT Pais ON 
	INSERT Pais (IdPais, [Name]) VALUES (1, N'AUS')
	INSERT Pais (IdPais, [Name]) VALUES (2, N'CHN')
	INSERT Pais (IdPais, [Name]) VALUES (3, N'FRA')
	INSERT Pais (IdPais, [Name]) VALUES (4, N'ALE')
SET IDENTITY_INSERT Pais OFF

SET IDENTITY_INSERT Modalidad ON 
	INSERT Modalidad (IdModalidad, [Name]) VALUES (1, N'ARRANQUE')
	INSERT Modalidad (IdModalidad, [Name]) VALUES (2, N'ENVION')
SET IDENTITY_INSERT Modalidad OFF