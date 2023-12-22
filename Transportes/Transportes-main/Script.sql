CREATE DATABASE Transporte_SEQP
GO
USE Transporte_SEQP
GO
CREATE TABLE Usuarios(
	UsuarioID				INT IDENTITY(1,1),
	EmpleadoID				INT UNIQUE,
	Usuario					NVARCHAR(100),
	Clave					NVARCHAR(MAX),

	UsuarioCreacionID		INT,
	FechaCreacion			DATETIME,
	UsuarioModificacionID	INT,
	FechaModicicacion		DATETIME
	CONSTRAINT PK_Usuarios_UsuarioID PRIMARY KEY(UsuarioID)
);
GO

DECLARE @password NVARCHAR(MAX) = '123'
INSERT INTO Usuarios(EmpleadoID, Usuario, Clave, UsuarioCreacionID, FechaCreacion)
VALUES	(1, 'Admin', HASHBYTES('Sha2_512', @password), '1', GETDATE());
GO

ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_UsuarioCreacionID FOREIGN KEY(UsuarioCreacionID) REFERENCES Usuarios(UsuarioID)
GO
ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_UsuarioCModificacionID FOREIGN KEY(UsuarioModificacionID) REFERENCES Usuarios(UsuarioID)
GO

CREATE TABLE EstadosCiviles(
	EstadoCivilID			INT IDENTITY(1,1),
	Descripcion				NVARCHAR(100),
	
	UsuarioCreacionID		INT,
	FechaCreacion			DATETIME,
	UsuarioModificacionID	INT,
	FechaModicicacion		DATETIME
	CONSTRAINT PK_EstadosCiviles_EstadoCivilID											PRIMARY KEY(EstadoCivilID),
	CONSTRAINT FK_EstadosCiviles_UsuarioCreacionID_Usuarios_UsuarioCreacionID			FOREIGN KEY(UsuarioCreacionID)		REFERENCES Usuarios(UsuarioID),
	CONSTRAINT FK_EstadosCiviles_UsuarioModificacionID_Usuarios_UsuarioCModificacionID	FOREIGN KEY(UsuarioModificacionID)	REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE Transportistas(
	TransportistaID			INT IDENTITY(1,1),
	Nombre					NVARCHAR(100),
	Apellido				NVARCHAR(100),
	Identidad				NVARCHAR(50) UNIQUE,
	Telefono				NVARCHAR(50),
	EstadoCivilID			INT,
	TarifaPorKM				DECIMAL(18,2),

	UsuarioCreacionID		INT,
	FechaCreacion			DATETIME,
	UsuarioModificacionID	INT,
	FechaModicicacion		DATETIME
	CONSTRAINT PK_Transportistas_TransportistaID										PRIMARY KEY(TransportistaID),
	CONSTRAINT FK_Transportistas_EstadoCivilID_EstadosCiviles_EstadoCivilID				FOREIGN KEY(EstadoCivilID)			REFERENCES EstadosCiviles(EstadoCivilID),
	CONSTRAINT FK_Transportistas_UsuarioCreacionID_Usuarios_UsuarioCreacionID			FOREIGN KEY(UsuarioCreacionID)		REFERENCES Usuarios(UsuarioID),
	CONSTRAINT FK_Transportistas_UsuarioModificacionID_Usuarios_UsuarioCModificacionID	FOREIGN KEY(UsuarioModificacionID)	REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE Empleados(
	EmpleadoID				INT IDENTITY(1,1),
	Nombre					NVARCHAR(100),
	Apellido				NVARCHAR(100),
	Identidad				NVARCHAR(50) UNIQUE,
	Telefono				NVARCHAR(50),
	EstadoCivilID			INT,

	UsuarioCreacionID		INT,
	FechaCreacion			DATETIME,
	UsuarioModificacionID	INT,
	FechaModicicacion		DATETIME
	CONSTRAINT PK_Empleados_EmpleadoID												PRIMARY KEY(EmpleadoID),
	CONSTRAINT FK_Empleados_EstadoCivilID_EstadosCiviles_EstadoCivilID				FOREIGN KEY(EstadoCivilID)			REFERENCES EstadosCiviles(EstadoCivilID),
	CONSTRAINT FK_Empleados_UsuarioCreacionID_Usuarios_UsuarioCreacionID			FOREIGN KEY(UsuarioCreacionID)		REFERENCES Usuarios(UsuarioID),
	CONSTRAINT FK_Empleados_UsuarioModificacionID_Usuarios_UsuarioCModificacionID	FOREIGN KEY(UsuarioModificacionID)	REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE Sucursales(
	SucursalID				INT IDENTITY(1,1),
	Nombre					NVARCHAR(100),

	UsuarioCreacionID		INT,
	FechaCreacion			DATETIME,
	UsuarioModificacionID	INT,
	FechaModicicacion		DATETIME
	CONSTRAINT PK_Sucursales_SucursalID												PRIMARY KEY(SucursalID),
	CONSTRAINT FK_Sucursales_UsuarioCreacionID_Usuarios_UsuarioCreacionID			FOREIGN KEY(UsuarioCreacionID)		REFERENCES Usuarios(UsuarioID),
	CONSTRAINT FK_Sucursales_UsuarioModificacionID_Usuarios_UsuarioCModificacionID	FOREIGN KEY(UsuarioModificacionID)	REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE SucursalesXEmpleados(
	SucursalXEmpleadoID		INT IDENTITY(1,1),
	EmpleadoID				INT,
	SucursalID				INT,
	Kilometros				DECIMAL(18,2),

	UsuarioCreacionID		INT,
	FechaCreacion			DATETIME,
	UsuarioModificacionID	INT,
	FechaModicicacion		DATETIME
	CONSTRAINT PK_SucursalesXEmpleados_SucursalXEmpleadoID										PRIMARY KEY(SucursalXEmpleadoID),
	CONSTRAINT FK_SucursalesXEmpleados_EmpleadoID_Empleados_EmpleadoID							FOREIGN KEY(EmpleadoID)				REFERENCES Empleados(EmpleadoID),
	CONSTRAINT FK_SucursalesXEmpleados_SucursaleID_Sucursales_SucursaleID						FOREIGN KEY(SucursalID)				REFERENCES Sucursales(SucursalID),
	CONSTRAINT FK_SucursalesXEmpleados_UsuarioCreacionID_Usuarios_UsuarioCreacionID				FOREIGN KEY(UsuarioCreacionID)		REFERENCES Usuarios(UsuarioID),
	CONSTRAINT FK_SucursalesXEmpleados_UsuarioModificacionID_Usuarios_UsuarioCModificacionID	FOREIGN KEY(UsuarioModificacionID)	REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE Viajes(
	ViajeID					INT IDENTITY(1,1),
	TransportistaID			INT,
	FechaViaje				DATETIME,

	UsuarioCreacionID		INT,
	FechaCreacion			DATETIME,
	UsuarioModificacionID	INT,
	FechaModicicacion		DATETIME
	CONSTRAINT PK_Viajes_ViajeID													PRIMARY KEY(ViajeID),
	CONSTRAINT FK_Viajes_TransportistaID_Transportistas_TransportistaID				FOREIGN KEY(TransportistaID)		REFERENCES Transportistas(TransportistaID),
	CONSTRAINT FK_Viajes_UsuarioCreacionID_Usuarios_UsuarioCreacionID				FOREIGN KEY(UsuarioCreacionID)		REFERENCES Usuarios(UsuarioID),
	CONSTRAINT FK_Viajes_UsuarioModificacionID_Usuarios_UsuarioCModificacionID		FOREIGN KEY(UsuarioModificacionID)	REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE ViajesDetalle(
	ViajeDetalleID			INT IDENTITY(1,1),
	ViajeID					INT,
	SucursalXEmpleadoID		INT,
	Kilometros				DECIMAL(18,2),

	UsuarioCreacionID		INT,
	FechaCreacion			DATETIME,
	UsuarioModificacionID	INT,
	FechaModicicacion		DATETIME
	CONSTRAINT PK_ViajesDetalle_ViajeDetalleID													PRIMARY KEY(ViajeDetalleID),
	CONSTRAINT FK_ViajesDetalle_ViajeID_Viajes_ViajeID											FOREIGN KEY(ViajeID)				REFERENCES Viajes(ViajeID),
	CONSTRAINT FK_ViajesDetalle_SucursalXEmpleadoID_SucursalesXEmpleados_SucursalXEmpleadoID	FOREIGN KEY(SucursalXEmpleadoID)	REFERENCES SucursalesXEmpleados(SucursalXEmpleadoID),
	CONSTRAINT FK_ViajesDetalle_UsuarioCreacionID_Usuarios_UsuarioCreacionID					FOREIGN KEY(UsuarioCreacionID)		REFERENCES Usuarios(UsuarioID),
	CONSTRAINT FK_ViajesDetalle_UsuarioModificacionID_Usuarios_UsuarioCModificacionID			FOREIGN KEY(UsuarioModificacionID)	REFERENCES Usuarios(UsuarioID)
);
GO

INSERT INTO EstadosCiviles(Descripcion, UsuarioCreacionID, FechaCreacion)
VALUES	('Casado(a)', 1, GETDATE()),
		('Divorciado(a)', 1, GETDATE()),
		('Soltero(a)', 1, GETDATE()),
		('Viudo(a)', 1, GETDATE()),
		('Union Libre(a)', 1, GETDATE());
GO

INSERT INTO Empleados(Nombre, Apellido, Identidad, Telefono, EstadoCivilID, UsuarioCreacionID, FechaCreacion)
VALUES	('Mauricio', 'Mateo', '0501200501829', '98392834', 3, 1, GETDATE()),
		('Roberto', 'Solis', '0501198412329', '32759182', 1, 1, GETDATE()),
		('Maria', 'Rosales', '1602197003827', '74839239', 1, 1, GETDATE());
GO

INSERT INTO Transportistas(Nombre, Apellido, Identidad, Telefono, EstadoCivilID, TarifaPorKM, UsuarioCreacionID, FechaCreacion)
VALUES	('Julia', 'Ramirez', '0101197709238', '90283947', 2, 20, 1, GETDATE()),
		('Victor', 'Argueta', '1511200098372', '78152637', 1, 25, 1, GETDATE()),
		('Franklin', 'Pacheco', '0501299023894', '99816283', 4, 22, 1, GETDATE());
GO

INSERT INTO Sucursales(Nombre, UsuarioCreacionID, FechaCreacion)
VALUES	('Sucursal Bo. Suyapa', 1, GETDATE()),
		('Sucursal Rio Piedras', 1, GETDATE()),
		('Sucursal El Benque', 1, GETDATE());
GO

INSERT INTO SucursalesXEmpleados(EmpleadoID, SucursalID, Kilometros, UsuarioCreacionID, FechaCreacion)
VALUES	(1, 1, 20, 1, GETDATE()),
		(2, 1, 20, 1, GETDATE()),
		(2, 2, 15, 1, GETDATE()),
		(3, 1, 10, 1, GETDATE());
GO

INSERT INTO Viajes(TransportistaID, FechaViaje, UsuarioCreacionID, FechaCreacion)
VALUES	(1, GETDATE(), 1, GETDATE()),
		(2, GETDATE(), 1, GETDATE());
GO

INSERT INTO ViajesDetalle(ViajeID, SucursalXEmpleadoID, Kilometros, UsuarioCreacionID, FechaCreacion)
VALUES	(1, 1, 20, 1, GETDATE()),
		(1, 4, 10, 1, GETDATE()),
		(2, 3, 15, 1, GETDATE());
GO

ALTER TABLE Usuarios ADD CONSTRAINT FK_Usuarios_EmpleadoID_Empleados_EmpleadoID FOREIGN KEY(EmpleadoID) REFERENCES Empleados(EmpleadoID)



