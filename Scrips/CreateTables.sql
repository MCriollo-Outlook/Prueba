CREATE DATABASE JuegosOlimpicos
USE JuegosOlimpicos
CREATE TABLE Deportista(
	IdDeportista		INT NOT NULL IDENTITY(1,1),
	IdPais				INT NOT NULL,
	[Name]				Varchar(100),
)

CREATE TABLE Pais(
	IdPais			INT NOT NULL IDENTITY(1,1),
	[Name]			Varchar(100),
)

CREATE TABLE Modalidad(
	IdModalidad			INT NOT NULL IDENTITY(1,1),
	[Name]				Varchar(100),
)

CREATE TABLE DeportistaModalidad(
	IdDeportistaModalidad		INT NOT NULL IDENTITY(1,1),
	IdDeportista				INT NOT NULL,
	IdModalidad					INT NOT NULL,
	Peso						INT
)