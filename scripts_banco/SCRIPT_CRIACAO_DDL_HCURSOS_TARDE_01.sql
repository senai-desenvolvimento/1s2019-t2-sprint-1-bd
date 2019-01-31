CREATE DATABASE SENAI_HCURSOS_TARDE;

USE SENAI_HCURSOS_TARDE;

CREATE TABLE CATEGORIAS (
	ID INT IDENTITY PRIMARY KEY
	,NOME VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE PROFESSORES (
	ID INT IDENTITY PRIMARY KEY
	,NOME VARCHAR(250) NOT NULL
);

CREATE TABLE ALUNOS (
	ID INT IDENTITY PRIMARY KEY
	,NOME VARCHAR(250) NOT NULL
);

CREATE TABLE CURSOS (
	ID INT IDENTITY PRIMARY KEY
	,NOME VARCHAR(250) NOT NULL
	,TITULO VARCHAR(250) NOT NULL
	,ID_PROFESSOR INT FOREIGN KEY REFERENCES PROFESSORES(ID) NOT NULL 
	,ID_CATEGORIA INT FOREIGN KEY REFERENCES CATEGORIAS(ID) NOT NULL 
)

CREATE TABLE CURSOS_ALUNOS (
	ID_CURSO INT FOREIGN KEY REFERENCES CURSOS(ID) NOT NULL
	, ID_ALUNO INT FOREIGN KEY REFERENCES ALUNOS(ID) NOT NULL
);

