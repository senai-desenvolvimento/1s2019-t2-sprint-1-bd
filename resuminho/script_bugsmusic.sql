CREATE DATABASE BUGSMUSIC;

USE BUGSMUSIC;

-- DDL - LINGUAGEM DE DEFINIÇÃO DE DADOS

CREATE TABLE NOME_TABELA (
	-- COLUNA	TIPO_DADOS		CARACTERÍSTICAS		CHAVE
		ID		INT				IDENTITY			PRIMARY KEY
		,NOME	VARCHAR(200)	UNIQUE NOT NULL
);

CREATE TABLE ALBUNS (
	-- COLUNA	TIPO_DADOS		CARACTERÍSTICAS		CHAVE
	ID			INT				IDENTITY			PRIMARY KEY
	,NOME		VARCHAR(200)	NOT NULL
);

CREATE TABLE MUSICAS (
	-- COLUNA	TIPO_DADOS		CARACTERÍSTICAS		CHAVE
	ID			INT				IDENTITY			PRIMARY KEY
	,NOME		VARCHAR(200)	NOT NULL
	,ID_ALBUM	INT				NOT NULL			FOREIGN KEY REFERENCES ALBUNS(ID)
);

-- ADICIONANDO UMA NOVA COLUNA NA TABELA DE MUSICAS

ALTER TABLE MUSICAS
ADD DURACAO FLOAT

-- DML - LINGUAGEM DE MANIPULAÇÃO DE DADOS

-- INSERT INTO TABELA (COLUNA1, COLUNA2, COLUNA3) VALUES (VALOR1, VALOR2, VALOR3) 
INSERT INTO ALBUNS (NOME) VALUES ('ALBUM1');
INSERT INTO ALBUNS (NOME) VALUES ('ALBUM2'), ('ALBUM3');

INSERT INTO MUSICAS (NOME, ID_ALBUM) VALUES ('MUSICA1', 1);
INSERT INTO MUSICAS (NOME, ID_ALBUM) VALUES ('MUSICA1', 2); 

-- UPDATE TABELA SET VALOR = 'NOVOVALOR' WHERE CONDICAO = SUACONDICAO
UPDATE ALBUNS SET NOME = 'ALBUM1 - RENOMEADO' WHERE ID = 1;

-- DELETE FROM TABELA WHERE CONDICAO = SUACONDICAO
DELETE FROM ALBUNS WHERE ID = 3;

-- DQL - LINGUAGEM DE CONSULTA DE DADOS

-- SELECT COLUNAS FROM TABELA
SELECT * FROM ALBUNS;
SELECT NOME FROM ALBUNS;
SELECT * FROM ALBUNS WHERE ID = 1;
SELECT * FROM ALBUNS WHERE ID > 1;
-- OR, AND, >, <, >=, <=, WHERE, COUNT, GROUP BY, MAX, MIN, AVG

-- JUNCOES
-- SELECT * FROM PRIMEIRA_TABELA TIPO_JUNCAO SEGUNDA_TABELA ON PRIMEIRA_TABELA.IDENTIFICADOR = SEGUNDA_TABELA.IDENTIFICADOR
SELECT * FROM ALBUNS INNER JOIN MUSICAS ON ALBUNS.ID = MUSICAS.ID_ALBUM;