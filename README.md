# CRUDFarmacia

CRUD de empleados y estatus.


Script de Microsoft SQL Server
---------------------------------------------------------------------------------------------------------------------------------------------

create database DBFarmacia
GO
use DBFarmacia
GO

create table Estatus
(
Id int primary key identity,
Nombre varchar(50) not null
)

create table Empleado
(
Id int primary key identity,
Nombre nvarchar(100) not null,
Apellido nvarchar(100) not null,
Telefono varchar(20) not null,
Correo nvarchar(100) not null,
Estatus int foreign key references Estatus(Id)
)

insert into Estatus values('Activo'), ('Inactivo')

insert into Empleado values('Diego', 'Mendez', '809-111-2222', 'diego@farmacia.com', 1)
insert into Empleado values('Francisco', 'Carvajal', '809-222-3333', 'francisco@farmacia.com', 2)
insert into Empleado values('Maira', 'Medina', '809-555-2323', 'maira@farmacia.com', 1)

---------------------------------------------------------------------------------------------------------------------------------------------
