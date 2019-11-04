CREATE DATABASE T_Roman;

USE T_Roman;

create table Professores(
	IdProfessor int primary key identity not null
	,Nome varchar(255) not null unique
	,Senha varchar(255) not null
);


create table Projetos(
	IdProjeto int primary key identity not null
	,Nome varchar(255) not null unique
	,Descricao text not null
);

create table Temas(
	IdTema int identity primary key not null
	,Nome varchar(255) not null unique
	,IdProjeto int foreign key references Projetos(IdProjeto)
);

/*(insert into Professores (Nome, Senha)
values ('Helena','123456')

select * from Professores;

insert into Projetos (Nome,Descricao)
values('projeto de Controle de Estoque','o projeto funcionará da seguinte forma...')

select * from Projetos;

insert into Temas (Nome)
values ('Gestão')

select * from Temas;
*/