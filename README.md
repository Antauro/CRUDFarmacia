# CRUDFarmacia

CRUD de empleados y estatus.


Script de Microsoft SQL Server:

create database DBFarmacia<br/>
GO<br/>
use DBFarmacia<br/>
GO<br/>

create table Estatus<br/>
(<br/>
Id int primary key identity,<br/>
Nombre varchar(50) not null<br/>
)<br/>

create table Empleado<br/>
(<br/>
Id int primary key identity,<br/>
Nombre nvarchar(100) not null,<br/>
Apellido nvarchar(100) not null,<br/>
Telefono varchar(20) not null,<br/>
Correo nvarchar(100) not null,<br/>
Estatus int foreign key references Estatus(Id)<br/>
)<br/>

insert into Estatus values('Activo'), ('Inactivo')<br/>

insert into Empleado values('Diego', 'Mendez', '809-111-2222', 'diego@farmacia.com', 1)<br/>
insert into Empleado values('Francisco', 'Carvajal', '809-222-3333', 'francisco@farmacia.com', 2)<br/>
insert into Empleado values('Maira', 'Medina', '809-555-2323', 'maira@farmacia.com', 1)<br/>
