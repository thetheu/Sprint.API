create database T_Ekpis

use T_Ekpis

create table Usuarios 
(
	IdUsuario int primary key identity
	,Email varchar(255) not null unique
	,Senha varchar(30) not null
	,Permissao varchar (255) not null
);

create table Funcionarios
(
	IdFuncionario int primary key identity
	,Nome varchar (255) not null
	,CPF varchar(20) not null unique
	,DataNascimento date not null
	,Salario money
	,IdDepartamento int foreign key references Departamentos (IdDepartamento)
	,IdCargo int foreign key references Cargos (IdCargo)
	,IdUsuario int foreign key references Usuarios (IdUsuario) 
);

create table Departamentos
(
	IdDepartamento int primary key identity
	,Nome varchar(255) not null 
);

create table Cargos 
(
	IdCargo int primary key identity
	,Nome varchar (255) not null
	,Ativo bit not null
);

insert into Cargos (Nome, Ativo) values ('Advogado Trabalhista', 1)
select * from Cargos

insert into Departamentos (Nome) values ('Jurídico')
select * from Departamentos

insert into Usuarios (Email, Senha, Permissao) values ('jorge@.com', '987654', 'ADMINISTRADOR')
													  ,('elisete@.com', '1234', 'COMUM')
select * from Usuarios

insert into Funcionarios(Nome, CPF, DataNascimento, Salario, IdDepartamento, IdCargo, IdUsuario) values ('Jorge', '171.246.758-12', '04/07/1974', '15.000', 1, 1, 1)
																						,('Elisete', '475.037.738-47', '03/12/1947', '165.000', 1, 1, 2)
select * from Funcionarios

insert into Usuarios (Email, Senha, Permissao) values ('sheyla@.com', 'lala', 'COMUM')