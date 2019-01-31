--Lista os dados de uma tabela, retorna todas as colunas
SELECT * FROM CATEGORIAS

--Lista os dados de uma tabela informando quais as colunas
SELECT NOME, ID FROM CATEGORIAS

--Lista os dados de uma tabela filtrando/where pelo id
SELECT * FROM CATEGORIAS WHERE ID = 1

--Lista os dados de uma tabela ordenando pelo Id
-- Asc - Crescente
-- Desc - Decrescente
SELECT * FROM CATEGORIAS ORDER BY ID asc

--Retorna as linhas na tabela Categoria que tenham o Id 1 ou 3
SELECT * FROM CATEGORIAS WHERE ID = 1 OR ID = 3

--Retorna as linhas na tabela Categoria que tenham o Id 1 e 3
--Neste caso não existe uma linha que tenha o id 1 e o id 3
SELECT * FROM CATEGORIAS WHERE ID = 1 AND ID = 3

--Retorna as linhas na tabela Categoria que tenha o Id = 4 e o nome = design
SELECT * FROM CATEGORIAS WHERE ID = 4 AND NOME = 'DESIGN' 

--Lista todas as categorias que contenha E no nome
SELECT * FROM CATEGORIAS WHERE NOME LIKE '%E%'

--Lista todas as categorias que contenha I no inicio
SELECT * FROM CATEGORIAS WHERE NOME LIKE 'I%'

--Lista todas as categoria que contenha A no final
SELECT * FROM CATEGORIAS WHERE NOME LIKE '%A'

--Lista todas as categoria onde o ID seja maior ou igual a 1
-- >, >=, <, <=
SELECT * FROM CATEGORIAS WHERE ID >= 1

-- Retorna a quantidade total de registros da tabela Categorias
-- AS nome_coluna - altera o nome da coluna na visualização
SELECT COUNT(*) AS QUANTIDADE_REGISTROS FROM CATEGORIAS

-- Retorna a quantidade de registros informado no Top
SELECT TOP 1 * FROM CATEGORIAS

-- Retorna os registros que tem o id entre 2 e 5
-- O between trabalha com >= e <=
SELECT * FROM CATEGORIAS WHERE ID BETWEEN 2 AND 5

--Retorna todas as categorias menos o Id = 1
SELECT * FROM CATEGORIAS WHERE NOT ID = 1

--Retorna todas as categoria onde o id seja igual a 1, 3 e 4
SELECT * FROM CATEGORIAS WHERE ID = 1 OR ID =3 OR ID = 4
SELECT * FROM CATEGORIAS WHERE ID IN(1,3,4) and NOME IN('Design', 'Informática')

--Update - Altera os dados de uma tabela,
--Set -define o(s) campo(s) que desejo altera 'coluna' = 'valor'
--where - define os registros que eu desejo alterar
UPDATE CATEGORIAS SET NOME = 'Desenvolvimento de Sistemas' 
WHERE ID = 1

--Deleta o resgitro da tabela
--where - define os registros que eu desejo deletar
DELETE FROM CATEGORIAS WHERE ID = 5




