create database T_ShirtStore

use T_ShirtStore


------- DDL ------
create table Usuarios 
(
	IdUsuario int primary key identity 
	,Email varchar(255) unique not null
	,Senha varchar(30) not null
	,IdPerfil int foreign key references Perfis (IdPerfil)
)

create table Perfis
(
	IdPerfil int primary key identity
	,Perfil varchar(255) 
)

create table Empresas 
(
	IdEmpresa int primary key identity
	,NomeEmpresa varchar(255) not null
	,IdUsuario int foreign key references Usuarios (IdUsuario)
	,IdCamiseta int foreign key references Camisetas (IdCamiseta)
)

create table Camisetas
(
	IdCamiseta int primary key identity
	,Descriçao varchar (255) not null
)

create table Tamanhos
(
	IdTamanho int primary key identity
	,Tamanho varchar(5) not null
)

create table Cores
(
	IdCores int primary key identity
	,Cor varchar(255)
)

create table Estoques
(
	IdEstoque int primary key identity
	,Unidades varchar (255) not null
	,IdCamiseta int foreign key references Camisetas (IdCamiseta)
	,IdTamanho int foreign key references Tamanhos (IdTamanho)
	,IdCores int foreign key references Cores (IdCores)
)

Por exemplo: um usuário com email empresa@email.com e senha 123456, com perfil de Gerente, é da empresa 'Khelf' 
que cadastra uma camiseta com descrição 'Khelf, nunca nem comprei.'
e possui os tamanhos P nas cores Azul (3 unidades) e Roxa (2 unidades), tamanho G na cor Preta (1 unidade) e M na cor cinza (0 - nenhuma unidade).

-------- DQL ---------
insert into Tamanhos (Tamanho) values ('PP'), ('P'), ('M'), ('G'), ('GG')

insert into Cores (Cor) values ('Branco'), ('Preto'), ('Verde'), ('Vermelha') ,('Azul'), ('Roxo'), ('Cinza')

insert into Perfis (Perfil) values ('Gerente'),('Atendente') 

insert into Camisetas (Descriçao) values ('Khelf, nunca comprei'), ('Adida, muito boa')

insert into Empresas (NomeEmpresa, IdUsuario, IdCamiseta) values ('Khelf', 1, 1 ),
																 ('Adidas', 2, 2);

insert into Usuarios (Email, Senha, IdPerfil) values ('gerent@gerent.com', '123456', 1), ('atend@atend.com','654321',2)

insert into Estoques (Unidades, IdCamiseta, IdTamanho, IdCores) values ('5', '1', '2', '3'),
																	   ('7', '1', '2', '2'),
																	   ('3','1', '4', '2')
																	   

select * from Usuarios

select * from Perfis
select * from Empresas
select * from Camisetas
select * from Cores
select * from Tamanhos
select * from Estoques

------- DQL -------

select Usuarios.Email, Perfis.Perfil
from Usuarios
join Perfis
on Usuarios.IdPerfil = Perfis.IdPerfil

select Camisetas.Descriçao, Empresas.NomeEmpresa
from Camisetas
join Empresas
on Camisetas.IdCamiseta = Empresas.IdCamiseta
