CREATE DATABASE DB_SistemaViajes
GO
USE DB_SistemaViajes
GO
CREATE SCHEMA Viaj
GO
CREATE SCHEMA Acce
GO
CREATE SCHEMA Rrhh
GO
CREATE SCHEMA Gral
GO

-------------------------------------------------------------------
---------------------------ACCESO----------------------------------
-------------------------------------------------------------------
CREATE TABLE Acce.tbUsuarios(
		usua_Id 					INT IDENTITY(1,1),
		usua_Nombre					NVARCHAR(100) 	NOT NULL,
		usua_Contrasenia			NVARCHAR(MAX) 	NOT NULL,
		empl_Id						INT 			NOT NULL,
		role_Id						INT				NOT NULL,
		usua_EsAdmin				BIT 			NOT NULL,

		usua_UsuarioCreacion 		INT				NOT NULL,
		usua_FechaCreacion 			DATETIME 		NOT NULL,
		usua_UsuarioModificacion	INT				DEFAULT NULL,
		usua_FechaModificacion		DATETIME 		DEFAULT NULL,
		usua_Estado					BIT				DEFAULT 1,
	CONSTRAINT PK_Acce_tbUsuarios_usua_Id 			PRIMARY KEY (usua_Id),
	CONSTRAINT UQ_acce_tbUsuarios_usua_Nombre		UNIQUE(usua_Nombre),
);
GO

CREATE TABLE Acce.tbRoles
(
		role_Id						INT 			IDENTITY(1,1),
		role_Descripcion			NVARCHAR(500),		

		usua_UsuarioCreacion 		INT				NOT NULL,
		role_FechaCreacion 			DATETIME 		NOT NULL,
		usua_UsuarioModificacion	INT				DEFAULT NULL,
		role_FechaModificacion		DATETIME 		DEFAULT NULL,
		role_Estado					BIT				DEFAULT 1,

	CONSTRAINT PK_Acce_tbRoles_role_Id 											PRIMARY KEY (role_Id),
	CONSTRAINT FK_Acce_tbUsuarios_usua_UsuarioCreacion_Acce_tbRoles_usua_Id		FOREIGN KEY (usua_UsuarioCreacion)		REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Acce_tbUsuarios_usua_UsuarioModificacion_Acce_tbRoles_usua_Id FOREIGN KEY (usua_UsuarioModificacion)	REFERENCES Acce.tbUsuarios (usua_Id)

);
GO

CREATE TABLE Acce.tbPantallas(
		pant_Id						INT 			IDENTITY(1,1),
		pant_Nombre					NVARCHAR(150)	NOT NULL,
		pant_Identificador			CHAR(8)			NOT NULL,
		pant_href					NVARCHAR(70)	NOT NULL,

		usua_UsuarioCreacion 		INT				NOT NULL,
		pant_FechaCreacion 			DATETIME 		NOT NULL,
		usua_UsuarioModificacion	INT				DEFAULT NULL,
		pant_FechaModificacion		DATETIME 		DEFAULT NULL,
		pant_Estado					BIT				DEFAULT 1,


	CONSTRAINT PK_Acce_tbPantallas_pant_Id													PRIMARY KEY (pant_Id),
	CONSTRAINT FK_Acce_tbPantallas_pant_usua_UsuarioCreacion_Acce_tbUsuarios_usua_Id 		FOREIGN KEY(usua_UsuarioCreacion) 	   REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Acce_tbPantallas_pant_usua_UsuarioModificacion_Acce_tbUsuarios_usua_Id	FOREIGN KEY(usua_UsuarioModificacion) REFERENCES Acce.tbUsuarios (usua_Id)
);
GO

CREATE TABLE Acce.tbRolesXPantallas(
		ropa_Id						INT	IDENTITY(1,1),
		pant_Id						INT,
		role_Id						INT,

		usua_UsuarioCreacion 		INT				NOT NULL,
		ropa_FechaCreacion 			DATETIME 		NOT NULL,
		usua_UsuarioModificacion	INT				DEFAULT NULL,
		ropa_FechaModificacion		DATETIME 		DEFAULT NULL,
		ropa_Estado					BIT				DEFAULT 1,

	CONSTRAINT PK_Acce_tbRolesXPantallas_ropa_Id PRIMARY KEY (ropa_Id),
	CONSTRAINT UQ_Acce_tbRolesXPantallas_pant_Id_role_Id					UNIQUE(role_Id, pant_Id),
	CONSTRAINT FK_Acce_tbRolesXPantallas_pant_Id_Acce_tbPantallas_pant_Id   FOREIGN KEY(pant_Id) REFERENCES Acce.tbPantallas (pant_Id),
	CONSTRAINT FK_Acce_tbRolesXPantallas_role_Id_Acce_tbRoles_role_Id 		FOREIGN KEY(role_Id) REFERENCES Acce.tbRoles (role_Id),

	CONSTRAINT FK_Acce_tbRolesXPantallas_usua_UsuarioCreacion_Acce_tbUsuarios_usua_Id     FOREIGN KEY(usua_UsuarioCreacion)     REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Acce_tbRolesXPantallas_usua_UsuarioModificacion_Acce_tbUsuarios_usua_Id FOREIGN KEY(usua_UsuarioModificacion) REFERENCES Acce.tbUsuarios (usua_Id),
);
GO

-------------------------------------------------------------------
---------------------------GENERAL---------------------------------
-------------------------------------------------------------------

CREATE TABLE [gral].[tbDepartamentos](
		depa_Id                     INT IDENTITY(1,1),
		depa_Nombre 				NVARCHAR(100)		NOT NULL,
		depa_Codigo  				CHAR(2)				NOT NULL,

		usua_UsuarioCreacion		INT					NOT NULL,
		depa_FechaCreacion			DATETIME			NOT NULL,
		usua_UsuarioModificacion	INT					DEFAULT NULL,
		depa_FechaModificacion		DATETIME			DEFAULT NULL,
		depa_Estado					BIT					NOT NULL DEFAULT(1)
	CONSTRAINT PK_Gral_tbDepartamentos_depa_Id 												PRIMARY KEY(depa_Id),
	CONSTRAINT FK_Gral_tbDepartamentos_Acce_tbUsuarios_usua_UsuarioCreacion_usua_Id  		FOREIGN KEY(usua_UsuarioCreacion) 		REFERENCES Acce.tbUsuarios(usua_Id),
	CONSTRAINT FK_Gral_tbDepartamentos_Acce_tbUsuarios_usua_UsuarioModificacion_usua_Id  	FOREIGN KEY(usua_UsuarioModificacion) 	REFERENCES Acce.tbUsuarios(usua_Id)
);
GO

CREATE TABLE gral.tbMunicipios(
		muni_Id						INT IDENTITY(1,1),
		muni_Nombre					NVARCHAR(80)		NOT NULL,
		muni_Codigo					CHAR(4)				NOT NULL,
		depa_Id						INT					NOT NULL,

		usua_UsuarioCreacion		INT					NOT NULL,
		muni_FechaCreacion			DATETIME			NOT NULL ,
		usua_UsuarioModificacion	INT DEFAULT			NULL,
		muni_FechaModificacion		DATETIME			DEFAULT NULL,
		muni_Estado					BIT					NOT NULL DEFAULT(1)
	CONSTRAINT PK_Gral_tbMunicipios_muni_Id 											PRIMARY KEY(muni_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Gral_tbDepartamentos_depa_Id 						FOREIGN KEY(depa_Id) 					REFERENCES Gral.tbDepartamentos(depa_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Acce_tbUsuarios_usua_UsuarioCreacion_usua_Id  		FOREIGN KEY(usua_UsuarioCreacion) 		REFERENCES Acce.tbUsuarios(usua_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Acce_tbUsuarios_usua_UsuarioModificacion_usua_Id  	FOREIGN KEY(usua_UsuarioModificacion) 	REFERENCES Acce.tbUsuarios(usua_Id)
);
GO

CREATE TABLE Gral.tbCargos(
		carg_Id							INT 			IDENTITY(1,1),
		carg_Nombre 					NVARCHAR(150) 	NOT NULL,

		usua_UsuarioCreacion 			INT				NOT NULL,
		carg_FechaCreacion 				DATETIME 		NOT NULL,
		usua_UsuarioModificacion		INT				DEFAULT NULL,
		carg_FechaModificacion			DATETIME 		DEFAULT NULL,
		carg_Estado						BIT				DEFAULT 1,

	CONSTRAINT PK_Gral_tbCargos_carg_Id 											PRIMARY KEY (carg_Id),
	CONSTRAINT UQ_Gral_tbCargos__carg_Nombre										UNIQUE(carg_Nombre),
	CONSTRAINT FK_Gral_tbCargos_usua_UsuarioCreacion_Acce_tbUsuarios_usua_Id 		FOREIGN KEY(usua_UsuarioCreacion) 		REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Gral_tbCargos_usua_UsuarioModificacion_Acce_tbUsuarios_usua_Id	FOREIGN KEY(usua_UsuarioModificacion)  REFERENCES Acce.tbUsuarios (usua_Id)
);
GO

CREATE TABLE Gral.tbEstadosCiviles(
		eciv_Id						   INT 				IDENTITY(1,1),
		eciv_Nombre 				   NVARCHAR(150) 		NOT NULL,
	   
		usua_UsuarioCreacion 		   INT					NOT NULL,
		eciv_FechaCreacion 			   DATETIME 			NOT NULL,
		usua_UsuarioModificacion	   INT					DEFAULT NULL,
		eciv_FechaModificacion		   DATETIME 			DEFAULT NULL,	
		eciv_Estado					   BIT					DEFAULT 1,
		
	CONSTRAINT PK_Gral_tbEstadosCiviles_eciv_Id PRIMARY KEY (eciv_Id),
	CONSTRAINT UQ_Gral_tbEstadosCiviles_eciv_Nombre UNIQUE(eciv_Nombre),
	CONSTRAINT FK_Gral_tbEstadosCiviles_usua_UsuarioCreacion_Acce_tbUsuarios_usua_Id 	 FOREIGN KEY(usua_UsuarioCreacion)     REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Gral_tbEstadosCiviles_usua_UsuarioModificacion_Acce_tbUsuarios_usua_Id FOREIGN KEY(usua_UsuarioModificacion) REFERENCES Acce.tbUsuarios (usua_Id)
);
GO

-------------------------------------------------------------------
----------------------RECURSOS HUMANOS-----------------------------
-------------------------------------------------------------------

CREATE TABLE Rrhh.tbEmpleados(
		empl_Id							INT 			IDENTITY(1,1),
		empl_Nombres 					NVARCHAR(150)	NOT NULL,
		empl_Apellidos					NVARCHAR(150) 	NOT NULL,
		empl_DNI	 					NVARCHAR(20) 	NOT NULL,
		eciv_Id							INT				NOT NULL,
		empl_Sexo						CHAR(1)			NOT NULL,
		empl_FechaNacimiento			DATE 			NOT NULL,
		empl_Telefono					NVARCHAR(20)	NOT NULL,
		empl_DireccionExacta			NVARCHAR(500)   NOT NULL,
		carg_Id							INT				NOT NULL,
		
		usua_UsuarioCreacion			INT 			NOT NULL,
		empl_FechaCreacion 				DATETIME 		NOT NULL,
		usua_UsuarioModificacion		INT,
		empl_FechaModificacion  		DATETIME,
		empl_Estado						BIT 			NOT NULL DEFAULT 1,

	CONSTRAINT PK_Rrhh_tbEmpleados_emad_Id											PRIMARY KEY (empl_Id),
	CONSTRAINT UQ_Gral_tbEmpleados_empl_DNI											UNIQUE (empl_DNI),
	CONSTRAINT FK_Gral_tbEstadosCiviles_Adua_tbEmpleados_eciv_Id 					FOREIGN KEY (eciv_Id)					REFERENCES Gral.tbEstadosCiviles(eciv_Id),
	CONSTRAINT FK_Gral_tbCargos_Adua_tbasEmpleados_carg_Id 		 					FOREIGN KEY (carg_Id)					REFERENCES Gral.tbCargos(carg_Id),
	CONSTRAINT FK_Acce_tbUsuarios_Gral_tbEmpleados_empl_UsuarioCreacion 			FOREIGN KEY (usua_UsuarioCreacion) 		REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Acce_tbUsuarios_Gral_tbEmpleados_empl_UsuarioModificacion			FOREIGN KEY (usua_UsuarioModificacion)	REFERENCES Acce.tbUsuarios (usua_Id)
)
GO

CREATE TABLE Rrhh.tbTransportista(
		tran_Id							INT IDENTITY(1,1),
		tran_Nombre						NVARCHAR(200)		NOT NULL,
		tran_Apellido					NVARCHAR(200)		NOT NULL,
		tran_Telefono					NVARCHAR(50)		NOT NULL,
		tran_TarifaPorKM				DECIMAL(18,00)		NOT NULL,
		
		usua_UsuarioCreacion			INT					NOT NULL,
		tran_FechaCreacion				DATETIME			NOT NULL,
		usua_UsuarioModificacion 		INT DEFAULT			NULL,
		tran_FechaModificacion			DATETIME DEFAULT	NULL,
		tran_Estado 					BIT					NOT NULL DEFAULT 1,

	CONSTRAINT PK_Rrhh_tbTransportista_tran_Id									PRIMARY KEY(tran_Id),
	CONSTRAINT FK_Rrhh_tbTransportista_Acce_tbUsuarios_usua_UsuarioCreacion		FOREIGN KEY (usua_UsuarioCreacion)     REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Rrhh_tbTransportista_Acce_tbUsuarios_usua_UsuarioModificacion	FOREIGN KEY (usua_UsuarioModificacion) REFERENCES Acce.tbUsuarios (usua_Id),
);
GO

-------------------------------------------------------------------
---------------------------VIAJES----------------------------------
-------------------------------------------------------------------

CREATE TABLE Viaj.tbSucursales(
		sucu_Id							INT IDENTITY(1,1),
		sucu_Nombre						NVARCHAR(200)   NOT NULL,
		muni_Id							INT				NOT NULL,

		usua_UsuarioCreacion			INT             NOT NULL,
		sucu_FechaCreacion				DATETIME        NOT NULL,
		usua_UsuarioModificacion		INT				DEFAULT NULL,
		sucu_FechaModificacion			DATETIME		DEFAULT NULL,
		sucu_Estado						BIT             NOT NULL DEFAULT (1),

	CONSTRAINT PK_Viaj_tbSucursales_sucu_Id                                  PRIMARY KEY(sucu_Id),
	CONSTRAINT FK_Viaj_tbSucursales_Gral_tbMunicipios_muni_Id                FOREIGN KEY(muni_Id)					REFERENCES Gral.tbMunicipios(muni_Id),
	CONSTRAINT FK_Viaj_tbSucursales_Acce_tbUsuarios_usua_UsuarioCreacion     FOREIGN KEY(usua_UsuarioCreacion)		REFERENCES Acce.tbUsuarios(usua_Id),
	CONSTRAINT FK_Viaj_tbSucursales_Acce_tbUsuarios_usua_UsuarioModificacion FOREIGN KEY(usua_UsuarioModificacion)	REFERENCES Acce.tbUsuarios(usua_Id)
);

CREATE TABLE Viaj.tbSucursalesPorEmpleados(
		suem_Id						INT IDENTITY(1,1),
		sucu_Id						INT				NOT NULL,
		empl_Id						INT				NOT NULL,
		suem_Kilometros				INT				NOT NULL,
		suem_Direccion				NVARCHAR(MAX)	NULL,

		usua_UsuarioCreacion 		INT				NOT NULL,
		suem_FechaCreacion 			DATETIME 		NOT NULL,
		usua_UsuarioModificacion	INT				DEFAULT NULL,
		suem_FechaModificacion		DATETIME 		DEFAULT NULL,
		suem_Estado					BIT				DEFAULT 1,

	CONSTRAINT PK_Viaj_tbSucursalesPorEmpleados_suem_Id 											PRIMARY KEY (suem_Id),
	CONSTRAINT FK_Viaj_tbSucursalesPorEmpleados_usua_UsuarioCreacion_Acce_tbUsuarios_usua_Id		FOREIGN KEY (usua_UsuarioCreacion)		REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Viaj_tbSucursalesPorEmpleados_usua_UsuarioModificacion_Acce_tbUsuarios_usua_Id	FOREIGN KEY (usua_UsuarioModificacion)	REFERENCES Acce.tbUsuarios (usua_Id)
);
GO

CREATE TABLE Viaj.tbViajes(
		viaj_Id						INT IDENTITY(1,1),
		viaj_FechaViaje				DATETIME		NOT NULL,
		empl_Id						INT				NOT NULL,
		tran_Id						INT				NOT NULL,

		usua_UsuarioCreacion 		INT				NOT NULL,
		viaj_FechaCreacion 			DATETIME 		NOT NULL,
		usua_UsuarioModificacion	INT				DEFAULT NULL,
		viaj_FechaModificacion		DATETIME 		DEFAULT NULL,
		viaj_Estado					BIT				DEFAULT 1,

	CONSTRAINT PK_Viaj_tbViajes_viaj_Id 											PRIMARY KEY (viaj_Id),
	CONSTRAINT FK_Viaj_tbViajes_usua_UsuarioCreacion_Acce_tbUsuarios_usua_Id		FOREIGN KEY (usua_UsuarioCreacion)		REFERENCES Acce.tbUsuarios (usua_Id),
	CONSTRAINT FK_Viaj_tbViajes_usua_UsuarioModificacion_Acce_tbUsuarios_usua_Id	FOREIGN KEY (usua_UsuarioModificacion)	REFERENCES Acce.tbUsuarios (usua_Id)
);
GO


-----------------------------------------------------------------
-----------------------PROCEDIMIENTOS----------------------------
-----------------------------------------------------------------

CREATE OR ALTER PROCEDURE Acce.UDP_tbUsuarios_InsertUsuario
	@usua_Nombre NVARCHAR(100), 
	@usua_Contrasenia NVARCHAR(MAX), 
	@empl_Id INT, 
	@role_Id INT, 
	@usua_EsAdmin BIT, 
	@usua_UsuarioCreacion INT		
AS
BEGIN
	DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @usua_Contrasenia));

	INSERT acce.tbUsuarios(usua_Nombre, usua_Contrasenia, empl_Id, role_Id, usua_EsAdmin, usua_UsuarioCreacion, usua_FechaCreacion)
	VALUES(@usua_Nombre, @password, @empl_Id, @role_Id, @usua_EsAdmin, @usua_UsuarioCreacion, GETDATE());
END;


GO
EXEC Acce.UDP_tbUsuarios_InsertUsuario 'Sarai', '123', 1, 1, 1, 1;
GO
CREATE OR ALTER PROCEDURE Acce.UDP_IniciarSesion /*'Sarai', '123'*/
	@usua_Nombre			NVARCHAR(150),
	@usua_Contrasenia		NVARCHAR(MAX)
AS
BEGIN
	BEGIN TRY
		DECLARE @contrasenaEncriptada NVARCHAR(MAX)=(SELECT HASHBYTES('SHA2_512', @usua_Contrasenia));

		IF EXISTS (SELECT * 
				   FROM Acce.tbUsuarios 
				   WHERE usua_Nombre = @usua_Nombre 
				   AND usua_Contrasenia = @contrasenaEncriptada
				   AND usua_Estado = 1)
			BEGIN
				SELECT usua_Id,
					   usua_Nombre,
					   usua.empl_Id,
					   CONCAT(empl.empl_Nombres, ' ', empl.empl_Apellidos) AS emplNombreCompleto,
					   usua.role_Id,
					   rol.role_Descripcion,
					   usua_EsAdmin
				FROM Acce.tbUsuarios usua
				LEFT JOIN Acce.tbRoles rol				ON usua.role_Id = rol.role_Id
				LEFT JOIN Rrhh.tbEmpleados empl			ON usua.empl_Id = empl.empl_Id
				WHERE usua_Nombre = @usua_Nombre 
				AND usua_Contrasenia = @contrasenaEncriptada
			END
		ELSE
			BEGIN
				SELECT 0
			END
	END TRY
	BEGIN CATCH
		SELECT 'Error Message: ' + ERROR_MESSAGE()
	END CATCH
END
GO

CREATE OR ALTER PROCEDURE Viaj.UDP_tbSucursalesPorEmpleados_Insertar 
	@sucu_Id				INT, 
	@empl_Id				INT, 
	@suem_Kilometros		INT, 
	@usua_UsuarioCreacion	INT
AS 
BEGIN
	
	BEGIN TRY

		INSERT INTO Viaj.tbSucursalesPorEmpleados(
					sucu_Id, 
					empl_Id, 
					suem_Kilometros, 
					suem_Direccion,
					usua_UsuarioCreacion,
					suem_FechaCreacion)
			VALUES	(@sucu_Id, 
					@empl_Id, 
					@suem_Kilometros, 
					NULL,
					@usua_UsuarioCreacion,
					GETDATE())


			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 'Error Message: ' + ERROR_MESSAGE()
	END CATCH 
END
GO

CREATE OR ALTER PROCEDURE Rrhh.UDP_tbEmpleados_Index
AS 
BEGIN
	
	BEGIN TRY
		SELECT		empl_Id										,
					empl_Nombres								,
					empl_Apellidos								,
					CONCAT(empl_Nombres, ' ', empl_Apellidos)		AS empl_NombreCompleto,
					empl_DNI,
					empl_Telefono					
		FROM		Rrhh.tbEmpleados
		WHERE		empl_Estado = 1
			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 'Error Message: ' + ERROR_MESSAGE()
	END CATCH 
END
GO

CREATE OR ALTER PROCEDURE Acce.UDP_tbPantallas_DibujadoMenu 
	@usua_Id	INT
AS 
BEGIN
	
	BEGIN TRY

		DECLARE @EsAdmin BIT =	(SELECT usua_EsAdmin 
								FROM Acce.tbUsuarios 
								WHERE @usua_Id = @usua_Id)
		IF @EsAdmin = 1
		BEGIN
			SELECT * FROM Acce.tbPantallas
			WHERE pant_Estado = 1
		END
		ELSE IF @EsAdmin = 0
		BEGIN
			SELECT DISTINCT (pant_Nombre),pant_Identificador,pant_href
			FROM					Acce.tbRolesXPantallas RolPant
			INNER JOIN				Acce.tbPantallas Pant
			ON RolPant.pant_Id	=	Pant.pant_Id
			WHERE role_Id		=	(SELECT role_Id 
									FROM Acce.tbUsuarios 
									WHERE usua_Id = @usua_Id)
			AND pant_Estado = 1
		END

			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 'Error Message: ' + ERROR_MESSAGE()
	END CATCH 
END
GO


-----------------------------------------------------------------
---------------------------INSERTS-------------------------------
-----------------------------------------------------------------

---------------------PANTALLAS-------------------------
INSERT INTO [Acce].[tbPantallas]
			(pant_Nombre, pant_Identificador, pant_href, usua_UsuarioCreacion, pant_FechaCreacion)
			VALUES
			--Acceso
			('Usuarios','acce','/Usuarios',1, GETDATE()),
			('Roles','acce','/Roles',1, GETDATE()),
			--Rrhh
			('Empleados','rrhh','/Empleados',1, GETDATE()),
			('Transportistas','rrhh','/Transportista',1, GETDATE()),
			--Viajes
			('Viajes','viaj','/Viajes',1, GETDATE()),
			('Sucursales','viaj','/Sucursales',1, GETDATE()),
			('Reporte','viaj','/Reporte',1, GETDATE());

GO

---------------------ROLES-------------------------
INSERT INTO Acce.tbRoles(role_Descripcion, usua_UsuarioCreacion, role_FechaCreacion)
VALUES	('Gerente de tienda', 1, GETDATE());

INSERT INTO Acce.tbRoles(role_Descripcion, usua_UsuarioCreacion, role_FechaCreacion)
VALUES	('Carga', 1, GETDATE());

GO

---------------------ROLES X PANTALLAS-------------------------
INSERT INTO [Acce].[tbRolesXPantallas] (pant_Id, role_Id, usua_UsuarioCreacion, ropa_FechaCreacion)
VALUES	(1, 1, 1, GETDATE()),
		(2, 1, 1, GETDATE()),
		(3, 1, 1, GETDATE()),
		(4, 1, 1, GETDATE()),
		(5, 1, 1, GETDATE()),
		(6, 1, 1, GETDATE()),
		(7, 1, 1, GETDATE()),
		(8, 1, 1, GETDATE()),
		(9, 1, 1, GETDATE()),
		(10, 1, 1, GETDATE()),
		(11, 1, 1, GETDATE());

--INSERT INTO [Acce].[tbRolesXPantallas] (pant_Id, role_Id, usua_UsuarioCreacion, ropa_FechaCreacion)
--VALUES	(1, 2, 1, GETDATE()),
--		(2, 2, 1, GETDATE()),
--		(3, 2, 1, GETDATE());

---------------------ESTADOS CIVILES-------------------------
GO
INSERT INTO Gral.tbEstadosCiviles (eciv_Nombre, usua_UsuarioCreacion, eciv_Estado, eciv_FechaCreacion, usua_UsuarioModificacion, eciv_FechaModificacion)
VALUES	('Soltero(a)', '1', 1, GETDATE(), NULL, NULL),
		('Casado(a)', '1', 1, GETDATE(), NULL, NULL),
		('Divorciado(a)', '1', 1, GETDATE(), NULL, NULL),
		('Viudo(a)', '1', 1, GETDATE(), NULL, NULL),
		('Union Libre', '1', 1, GETDATE(), NULL, NULL);


---------------------CARGOS-------------------------
INSERT INTO Gral.tbCargos(carg_Nombre, usua_UsuarioCreacion, carg_FechaCreacion)
VALUES	('Representante', 1, GETDATE());

GO

---------------------EMPLEADOS-------------------------
INSERT INTO [Rrhh].[tbEmpleados](empl_Nombres, empl_Apellidos, empl_DNI, eciv_Id, empl_Sexo, empl_FechaNacimiento, empl_Telefono, empl_DireccionExacta, carg_Id, usua_UsuarioCreacion, empl_FechaCreacion)
VALUES	('Sarai', 'Quintanilla', '0501200503559', 1, 'F', '01-30-2005', '33529652', 'El Carmen', 1, 1, GETDATE());

GO

---------------------DEPARTAMENTOS-------------------------
INSERT INTO gral.tbDepartamentos(depa_Codigo, depa_Nombre, depa_Estado, usua_UsuarioCreacion, depa_FechaCreacion, usua_UsuarioModificacion, depa_FechaModificacion)
VALUES	('01','Atlántida', '1', 1, GETDATE(), NULL, NULL),
		('02','Colón', '1', 1, GETDATE(), NULL, NULL),
		('03','Comayagua', '1', 1, GETDATE(), NULL,NULL),
		('04','Copán', '1', 1, GETDATE(), NULL, NULL),
		('05','Cortés', '1', 1, GETDATE(), NULL, NULL),
		('06','Choluteca', '1', 1, GETDATE(), NULL, NULL),
		('07','El Paraíso', '1', 1, GETDATE(), NULL, NULL),
		('08','Francisco Morazán', '1', 1, GETDATE(), NULL, NULL),
		('09','Gracias a Dios', '1', 1, GETDATE(), NULL, NULL),
		('10','Intibucá', '1', 1, GETDATE(), NULL, NULL),
		('11','Islas de la Bahía', '1', 1, GETDATE(), NULL, NULL),
		('12','La Paz', '1', 1, GETDATE(), NULL, NULL),
		('13','Lempira', '1', 1, GETDATE(), NULL,NULL ),
		('14','Ocotepeque', '1', 1, GETDATE(), NULL, NULL),
		('15','Olancho', '1', 1, GETDATE(), NULL, NULL),
		('16','Santa Bárbara', '1', 1, GETDATE(), NULL, NULL),
		('17','Valle', '1', 1, GETDATE(), NULL, NULL),
		('18','Yoro', '1', 1, GETDATE(), NULL, NULL);



GO

---------------------MUNICIPIOS-------------------------
INSERT INTO gral.tbMunicipios(depa_Id, muni_Codigo, muni_Nombre, muni_Estado, usua_UsuarioCreacion, muni_FechaCreacion, usua_UsuarioModificacion, muni_FechaModificacion)
VALUES	('1','0101','La Ceiba', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0102','El Porvenir', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0103','Tela', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0104','Jutiapa', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0105','La Masica', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0106','San Francisco', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0107','Arizona', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0108','Esparta', '1', 1, GETDATE(), NULL, GETDATE()),
	

		('2','0201','Trujillo', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0202','Balfate', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0203','Iriona', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0204','Lim�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0205','Sab�', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0206','Santa Fe', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0207','Santa Rosa de Agu�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0208','Sonaguera', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0209','Tocoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0210','Bonito Oriental', '1', 1, GETDATE(), NULL, GETDATE()),


		('3',		'0301',		'Comayagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0302',		'Ajuterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0303',		'El Rosario', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0304',		'Esqu�as', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0305',		'Humuya', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0306',		'La Libertad', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0307',		'Laman�', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0308',		'La Trinidad', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0309',		'Lejaman�', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0310',		'Me�mbar', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0311',		'Minas de Oro', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0312',		'Ojos de Agua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0313',		'San Jer�nimo', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0314',		'San Jos� de Comayagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0315',		'San Jos� del Potrero', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0316',		'San Luis', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0317',		'San Sebasti�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0318',		'Siguatepeque', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0319',		'Villa de San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0320',		'Las Lajas', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0321',		'Taulab�', '1', 1, GETDATE(), NULL, GETDATE()),


		('4',	'0401','Santa Rosa de Cop�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0402','Caba�as', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0403','Concepci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0404','Cop�n Ruinas', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0405','Corqu�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0406','Cucuyagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0407','Dolores', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0408','Dulce Nombre', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0409','El Para�so', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0410','Florida', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0411','La Jigua', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0412','La Uni�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0413','Nueva Arcadia', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0414','San Agust�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0415','San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0416','San Jer�nimo', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0417','San Jos�', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0418','San Juan de Opoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0419','San Nicol�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0420','San Pedro', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0421','Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0422','Trinidad de Cop�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0423','Veracruz', '1', 1, GETDATE(), NULL, GETDATE()),


		('5',	'0501','San Pedro Sula', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0502','Choloma', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0503','Omoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0504','Pimienta', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0505','Potrerillos', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0506','Puerto Cort�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0507','San Antonio de Cort�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0508','San Francisco de Yojoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0509','San Manuel', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0510','Santa Cruz de Yojoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0511','Villanueva', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0512','La Lima', '1', 1, GETDATE(), NULL, GETDATE()),


		('6',	'0601','Choluteca', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0602','Apacilagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0603','Concepci�n de Mar�a', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0604','Duyure', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0605','El Corpus', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0606','El Triunfo', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0607','Marcovia', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0608','Morolica', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0609','Namasig�e', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0610','Orocuina', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0611','Pespire', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0612','San Antonio de Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0613','San Isidro', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0614','San Jos�', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0615','San Marcos de Col�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0616','Santa Ana de Yusguare', '1', 1, GETDATE(), NULL, GETDATE()),


		('7', '0701', 'Yuscar�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0702', 'Alauca', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0703', 'Danl�', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0704', 'El Para�so', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0705', 'G�inope', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0706', 'Jacaleapa', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0707', 'Liure', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0708', 'Morocel�', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0709', 'Oropol�', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0710', 'Potrerillos', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0711', 'San Antonio de Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0712', 'San Lucas', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0713', 'San Mat�as', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0714', 'Soledad', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0715', 'Teupasenti', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0716', 'Texiguat', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0717', 'Vado Ancho', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0718', 'Yauyupe', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0719', 'Trojes', '1', 1, GETDATE(), NULL, GETDATE()),


		('8', '0801', 'Distrito Central', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0802', 'Alubar�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0803', 'Cedros', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0804', 'Curar�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0805', 'El Porvenir', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0806', 'Guaimaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0807', 'La Libertad', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0808', 'La Venta', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0809', 'Lepaterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0810', 'Maraita', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0811', 'Marale', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0812', 'Nueva Armenia', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0813', 'Ojojona', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0814', 'Orica', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0815', 'Reitoca', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0816', 'Sabanagrande', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0817', 'San Antonio de Oriente', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0818', 'San Buenaventura', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0819', 'San Ignacio', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0820', 'San Juan de Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0821', 'San Miguelito', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0822', 'Santa Ana', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0823', 'Santa Luc�a', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0824', 'Talanga', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0825', 'Tatumbla', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0826', 'Valle de �ngeles', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0827', 'Villa de San Francisco', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0828', 'Vallecillo', '1', 1, GETDATE(), NULL, GETDATE()),
		
		('9', '0901', 'Puerto Lempira', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0902', 'Brus Laguna', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0903', 'Ahuas', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0904', 'Juan Francisco Bulnes', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0905', 'Ram�n Villeda Morales', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0906', 'Wampusirpe', '1', 1, GETDATE(), NULL, GETDATE()),
		
		('10', '1001', 'La Esperanza', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1002', 'Camasca', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1003', 'Colomoncagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1004', 'Concepci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1005', 'Dolores', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1006', 'Intibuc�', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1007', 'Jes�s de Otoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1008', 'Magdalena', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1009', 'Masaguara', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1010', 'San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1011', 'San Isidro', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1012', 'San Juan', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1013', 'San Marcos de la Sierra', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1014', 'San Miguel Guancapla', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1015', 'Santa Luc�a', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1016', 'Yamaranguila', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1017', 'San Francisco de Opalaca', '1', 1, GETDATE(), NULL, GETDATE()),


		('11', '1101', 'Roat�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1102', 'Guanaja', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1103', 'Jos� Santos Guardiola', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1104', 'Utila', '1', 1, GETDATE(), NULL, GETDATE()),


		('12', '1201', 'La Paz', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1202', 'Aguanqueterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1203', 'Caba�as', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1204', 'Cane', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1205', 'Chinacla', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1206', 'Guajiquiro', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1207', 'Lauterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1208', 'Marcala', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1209', 'Mercedes de Oriente', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1210', 'Opatoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1211', 'San Antonio del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1212', 'San Jos�', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1213', 'San Juan', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1214', 'San Pedro de Tutule', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1215', 'Santa Ana', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1216', 'Santa Elena', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1217', 'Santa Mar�a', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1218', 'Santiago de Puringla', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1219', 'Yarula', '1', 1, GETDATE(), NULL, GETDATE()),


		('13', '1301', 'Gracias', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1302', 'Bel�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1303', 'Candelaria', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1304', 'Cololaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1305', 'Erandique', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1306', 'Gualcince', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1307', 'Guarita', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1308', 'La Campa', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1309', 'La Iguala', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1310', 'Las Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1311', 'La Uni�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1312', 'La Virtud', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1313', 'Lepaera', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1314', 'Mapulaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1315', 'Piraera', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1316', 'San Andr�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1317', 'San Francisco', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1318', 'San Juan Guarita', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1319', 'San Manuel Colohete', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1320', 'San Rafael', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1321', 'San Sebasti�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1322', 'Santa Cruz', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1323', 'Talgua', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1324', 'Tambla', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1325', 'Tomal�', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1326', 'Valladolid', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1327', 'Virginia', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1328', 'San Marcos de Caiqu�n', '1', 1, GETDATE(), NULL, GETDATE()),


		('14', '1401', 'Ocotepeque', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1402', 'Bel�n Gualcho', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1403', 'Concepci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1404', 'Dolores Merend�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1405', 'Fraternidad', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1406', 'La Encarnaci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1407', 'La Labor', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1408', 'Lucerna', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1409', 'Mercedes', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1410', 'San Fernando', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1411', 'San Francisco del Valle', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1412', 'San Jorge', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1413', 'San Marcos', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1414', 'Santa Fe', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1415', 'Sensenti', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1416', 'Sinuapa', '1', 1, GETDATE(), NULL, GETDATE()),


		('15', '1501', 'Juticalpa', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1502', 'Campamento', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1503', 'Catacamas', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1504', 'Concordia', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1505', 'Dulce Nombre de Culm�', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1506', 'El Rosario', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1507', 'Esquipulas del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1508', 'Gualaco', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1509', 'Guarizama', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1510', 'Guata', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1511', 'Guayape', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1512', 'Jano', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1513', 'La Uni�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1514', 'Mangulile', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1515', 'Manto', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1516', 'Salam�', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1517', 'San Esteban', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1518', 'San Francisco de Becerra', '1',1, GETDATE(), NULL, GETDATE()),
		('15', '1519', 'San Francisco de la Paz', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1520', 'Santa Mar�a del Real', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1521', 'Silca', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1522', 'Yoc�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1523', 'Patuca', '1', 1, GETDATE(), NULL, GETDATE()),


		('16', '1601' , 'Santa B�rbara', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1602' , 'Arada', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1603' , 'Atima', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1604' , 'Azacualpa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1605' , 'Ceguaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1606' , 'Concepci�n del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1607' , 'Concepci�n del Sur', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1608' , 'Chinda', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1609' , 'El N�spero', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1610' , 'Gualala', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1611' , 'Ilama', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1612' , 'Las Vegas', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1613' , 'Macuelizo', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1614' , 'Naranjito', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1615' , 'Nuevo Celilac', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1616' , 'Nueva Frontera', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1617' , 'Petoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1618' , 'Protecci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1619' , 'Quimist�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1620' , 'San Francisco de Ojuera', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1621' , 'San Jos� de las Colinas', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1622' , 'San Luis', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1623' , 'San Marcos', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1624' , 'San Nicol�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1625' , 'San Pedro Zacapa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1626' , 'San Vicente Centenario', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1627' , 'Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1628' , 'Trinidad', '1', 1, GETDATE(), NULL, GETDATE()),


		('17', '1701', 'Nacaome', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1702', 'Alianza', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1703', 'Amapala', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1704', 'Aramecina', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1705', 'Caridad', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1706', 'Goascor�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1707', 'Langue', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1708', 'San Francisco de Coray', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1709', 'San Lorenzo', '1', 1, GETDATE(), NULL, GETDATE()),


		('18', '1801', 'Yoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1802', 'Arenal', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1803', 'El Negrito', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1804', 'El Progreso', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1805', 'Joc�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1806', 'Morazán', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1807', 'Olanchito', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1808', 'Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1809', 'Sulaco', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1810', 'Victoria', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1811', 'Yorito', '1', 1, GETDATE(), NULL, GETDATE());



---------------------SUCURSALES-------------------------
GO
INSERT INTO Viaj.tbSucursales(sucu_Nombre, muni_Id, usua_UsuarioCreacion, sucu_FechaCreacion)
VALUES	('Sucursal San Fernando', '63', '1', GETDATE()),
		('Sucursal El Pedregal', '63', '1', GETDATE()),
		('Sucursal Plaza Santa Monica', '63', '1', GETDATE()),
		('Sucursal 105 Brigada', '63', '1', GETDATE()),
		('Sucursal Avenida Circunvalacion, Blv Del Sur', '63', '1', GETDATE());


---------------------EMPLEADOS-------------------------
GO
INSERT INTO [Rrhh].[tbEmpleados](empl_Nombres, empl_Apellidos, empl_DNI, eciv_Id, empl_Sexo, empl_FechaNacimiento, empl_Telefono, empl_DireccionExacta, carg_Id, usua_UsuarioCreacion, empl_FechaCreacion)
VALUES	('Mauricio', 'Mateo', '0501200501902', 1, 'M', '01-14-2005', '89283912', 'Col. Santa Martha', 1, 1, GETDATE())
GO
--EXEC Acce.UDP_tbUsuarios_InsertUsuario 'Mateo', '123', 2, 2, 1, 1;
---------------------TRANSPORTISTAS-------------------------
GO

