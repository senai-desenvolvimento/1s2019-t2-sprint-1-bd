create database TESTE_TARDE;

use TESTE_TARDE;

create table TESTE (
	ID int identity primary key 
	,NOME varchar(250) not null
);

insert into TESTE(NOME)
values ('Ariel')

select * from TESTE2;

create table TESTE2 (
	ID int identity primary key 
	,RUA varchar(250) not null
);

insert into TESTE2(RUA)
values ('Errei2')