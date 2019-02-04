--Insere um novo registro na linha passando as colunas e valores
INSERT INTO CATEGORIAS(NOME)
VALUES ('Desenvolvimento')

--Insere um novo registro pela ordem das colunas
INSERT INTO CATEGORIAS 
VALUES ('Informática')

--Insere vários registro em uma única instrução insert passando as colunas e valores
INSERT INTO CATEGORIAS(NOME)
VALUES ('Design'),('Marketing')

------------------------------------------------------------------------------------

--Lista todos os registros e campos da tabela Categorias
SELECT * FROM CATEGORIAS

-- Lista todos os registros somente o campo NOME da tabela Categorias
SELECT NOME AS LARANJA FROM CATEGORIAS

-- Lista todos os registros com todos os campos da tabela Categorias
-- Ordena pelo campo ID em ordem crescente
SELECT * FROM CATEGORIAS ORDER BY ID ASC
-- Ordena pelo campo Nome em ordem decresente
SELECT * FROM CATEGORIAS ORDER BY NOME DESC

-- Lista todos os registros com todos os campos da tabela Categorias 
-- filtrando pelo Id
SELECT * FROM CATEGORIAS WHERE ID = 7

-- Lista todos os registros com todos os campos da tabela Categorias 
-- filtrando pelo Id = 
SELECT * FROM CATEGORIAS WHERE ID = 7 AND ID = 1

SELECT * FROM CATEGORIAS WHERE ID = 7 OR ID = 1

SELECT * FROM CATEGORIAS WHERE NOME LIKE '%e%'

SELECT * FROM CATEGORIAS WHERE NOME LIKE 'd%'

SELECT * FROM CATEGORIAS WHERE NOME LIKE '%n'

SELECT * FROM CATEGORIAS WHERE ID >= 2

SELECT * FROM CATEGORIAS WHERE ID > 2 AND ID < 7

SELECT * FROM CATEGORIAS WHERE ID BETWEEN 3 AND 6 

SELECT * FROM CATEGORIAS WHERE ID = 3 OR ID = 4 OR ID =7
SELECT * FROM CATEGORIAS WHERE ID IN(3,4,7)

SELECT TOP 2 * FROM CATEGORIAS
SELECT TOP 2 * FROM CATEGORIAS ORDER BY ID DESC

SELECT COUNT(*) AS QUANTIDADE_TOTAL_REGISTROS FROM CATEGORIAS

SELECT * FROM CATEGORIAS WHERE NOT ID = 3
SELECT * FROM CATEGORIAS WHERE ID <> 3

------------------------------------------------------------------------

UPDATE CATEGORIAS  SET NOME = 'Desenvolvimento de Sistemas' WHERE ID = 1

------------------------------------------------------------------------

DELETE FROM CATEGORIAS WHERE ID = 7