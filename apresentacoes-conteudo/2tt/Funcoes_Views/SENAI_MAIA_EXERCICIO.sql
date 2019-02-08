CREATE DATABASE SENAI_MAIA_VIEW_FUNCTIONS_E_FUNCOES_INTERNAS

CREATE TABLE EDITORAS (
      ID INT IDENTITY PRIMARY KEY 
	  ,NOME VARCHAR (250) NOT NULL
);

INSERT EDITORAS
VALUES ('Dark Side'),('Nerdbooks'),('Abril')

CREATE TABLE AUTORES (
      ID INT IDENTITY PRIMARY KEY 
	  ,NOME VARCHAR (250) NOT NULL
);

INSERT AUTORES
VALUES ('Edgar Allan Poe'),('Rysa Walker'),('Richard W. Charmbers'),('Deive Pazoz e Leonel Caldela')

CREATE TABLE CATEGORIAS (
      ID INT IDENTITY PRIMARY KEY 
	  ,NOME VARCHAR (250) NOT NULL
);

INSERT CATEGORIAS
VALUES ('Ficção'),('Terror'),('Conto')


CREATE TABLE LIVROS (
      ID INT IDENTITY PRIMARY KEY
	  ,NOME VARCHAR (250) NOT NULL
	  ,ID_CATEGORIA INT FOREIGN KEY REFERENCES CATEGORIAS(ID)
	  ,ID_AUTOR INT FOREIGN KEY REFERENCES AUTORES(ID)
	  ,ID_EDITORA INT FOREIGN KEY REFERENCES EDITORAS(ID)
	  ,VALOR INT NOT NULL
	  ,DT_LANCAMENTO DATE NOT NULL  
);

INSERT INTO LIVROS
VALUES ('Livro Ozob Vol. 1', 3, 4, 8, 40.00, '20/04/2016'),
       ('O Rei de Amarelo', 2, 3, 7, 60.00, '14/03/2008'),
	   ('Chronos: Viajantes do Tempo', 1, 2, 7, 40.00, '09/11/2011'),
	   ('Edgar Allan Poe: Medo Clássico Vol. 1', 1, 1, 7, 60.00, '22/01/2014')

SELECT * FROM EDITORAS

SELECT * FROM AUTORES

SELECT * FROM CATEGORIAS

SELECT * FROM LIVROS

------------------------------------------------------

CREATE VIEW vwLivros as 
SELECT NOME, 
VALOR
FROM LIVROS

SELECT * FROM vwLivros where VALOR = 40 

------------------------------------------------------
--SELECIONA O MAIOR VALOR DA COLUNA

SELECT MAX(VALOR)  
FROM LIVROS;  

-- SELECIONA O MENOR VALOR DA COLUNA
SELECT MIN(DT_LANCAMENTO)  
FROM LIVROS;  

-------------------------------------------------
--SOMA TODOS OS VALORES DA COLUNA
SELECT
  sum(VALOR)
FROM
  LIVROS

-----------------------------------------------
--RETORNA A MÉDIA DOS VALORES INSERIDOS NA COLUNA
SELECT
  avg(VALOR)
FROM
  LIVROS

--------------------------------------------------
--RETORNA A QUANTIDADE DE CARACTERES DO CAMPO SELECIONADO
SELECT LEN(NOME) AS Length 
FROM LIVROS  
WHERE ID = 3;

-----------------------------------------------------
-- SUBSTITUI O VALOR DA CADEIA DE CARACTERES ESPECIFICADO POR OUTRO VALOR
SELECT REPLACE('O Rei de Amarelo','Amarelo','Azul');

----------------------------------------------------
--REMOVE OS CARACTERES DE ESPAÇO OU OUTROS CARACTERES ESPECIFICADOS DO INICIO OU FINAL
SELECT TRIM('    Livro Ozob Vol. 1    ') AS Result;

SELECT TRIM( '.,! ' FROM  '    . Livro Ozob Vol. 1  .  ') AS Result;

----------------------------------------------------
--ADICIONA UM VALOR A UM DATEPART ESPECIFICADO DE UM VALOR DATE DE ENTRADA
DECLARE @datetime2 datetime2 = '2016-04-20';  
SELECT 'year', DATEADD(year,1,@datetime2)  

----------------------------------------------------
--RETORNA A DATA ATUAL
SELECT SYSDATETIME()