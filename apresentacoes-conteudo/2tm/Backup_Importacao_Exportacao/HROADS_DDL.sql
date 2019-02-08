create database TESTE_IMPORTACAO_HROADS_TARDE;

use TESTE_IMPORTACAO_HROADS_TARDE;

create table CLASSES (
	ID int identity primary key
	,NOME varchar(250) not null unique
);

create table TIPOS_HABILIDADES (
	ID int identity primary key
	,NOME varchar(250) not null unique
);

create table HABILIDADES (
	ID int identity primary key
	,NOME varchar(250) not null 
	,ID_TIPO_HABILIDADE int foreign key references TIPOS_HABILIDADES(ID)
);

create table PERSONAGENS (
	ID int identity primary key
	,NOME varchar(250) not null unique
	,ID_CLASSE int foreign key references CLASSES(ID)
	,CAPACIDADE_MAX_VIDA int not null
	,CAPACIDADE_MAX_MANA int not null
	,DATA_ATUALIZACAO date not null 
	,DATA_CRIACAO date not null
);

create table CLASSE_HABILIDADES (
	ID_CLASSE int foreign key references CLASSES(ID)
	,ID_HABILIDADE int foreign key references HABILIDADES(ID)
);

insert into CLASSES
	values ('Barão')