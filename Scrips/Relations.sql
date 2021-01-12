USE JuegosOlimpicos

ALTER TABLE Pais ADD CONSTRAINT PK_IdPais PRIMARY KEY(IdPais)

ALTER TABLE Modalidad ADD CONSTRAINT PK_IdModalidad PRIMARY KEY(IdModalidad)

ALTER TABLE Deportista ADD CONSTRAINT PK_IdDeportista PRIMARY KEY(IdDeportista)
ALTER TABLE Deportista ADD CONSTRAINT FK_IdPais_Deportista_Pais FOREIGN KEY (IdPais) REFERENCES Pais(IdPais) 

ALTER TABLE DeportistaModalidad ADD CONSTRAINT PK_IdDeportistaModalidad PRIMARY KEY(IdDeportistaModalidad)
ALTER TABLE DeportistaModalidad ADD CONSTRAINT FK_IdDeportista_DeportistaModalidad_Deportista FOREIGN KEY (IdDeportista) REFERENCES Deportista(IdDeportista)
ALTER TABLE DeportistaModalidad ADD CONSTRAINT FK_IdModalidad_DeportistaModalidad_Modalidad FOREIGN KEY (IdModalidad) REFERENCES Modalidad(IdModalidad)