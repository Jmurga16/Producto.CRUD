CREATE DATABASE Experis 
GO

USE Experis
GO

--TABLA Producto
CREATE TABLE Producto(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    Nombre VARCHAR(MAX),
	Precio DECIMAL(9,2),
	Stock INT,
	FechaRegistro DATETIME	
)
GO
