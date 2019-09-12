create database T_AutoPecas

use T_AutoPecas

create table Pecas
(
	IdPeca int primary key identity
	,CodigoDaPeca varchar (20) not null unique 
	,Descricao varchar (255) not null 
	,Peso decimal 
	,PreçoDoCusto money
	,PreçoDaVenda money
	,IdFornecedor int foreign key references Fornecedores (IdFornecedor) 
);

create table Fornecedores 
(
	IdFornecedor int primary key identity
	,CNPJ varchar (18) not null unique
	,RazaoSocial varchar (255) not null
	,NomeFantasia varchar (255) not null
	,Endereco varchar (255) not null unique
	,IdUsuario int foreign key references Usuarios (IdUsuario)
);

create table Usuarios
(
	IdUsuario int primary key identity
	,Email varchar(255) not null unique
	,Senha varchar (30) not null
	,Permissao varchar(255) not null
);

select * from Usuarios

insert