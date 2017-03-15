﻿create table Retenciones(
RetencionId int identity(1,1) primary key,
Descripcion varchar(100),
Valor float
);

create table TiposEmails(
TipoId int identity(1,1) primary key,
Descripcion varchar(100)
);

create table Empleados(
EmpleadoId int identity(1,1) primary key,
Nombres varchar(80),
FechaNacimiento date,
Sueldo float,
RetencionId int,
Retenciones varchar(255)
);

create table EmpleadosRetenciones(
Id int identity(1,1) primary key,
EmpleadoId int,
RetencionId int
);

create table EmpleadosEmails(
Id int identity(1,1) primary key,
EmpleadoId int,
TipoId int,
Email varchar(255)
);