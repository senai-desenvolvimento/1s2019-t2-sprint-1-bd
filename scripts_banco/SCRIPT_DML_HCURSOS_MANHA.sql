USE SENAI_HCURSOS_TARDE

INSERT INTO CATEGORIAS VALUES 
	('DESIGN')
	, ('MARKETING')
	, ('INFORMÁTICA')
	, ('DESENVOLVIMENTO')
	, ('GESTAO');

SELECT * FROM CATEGORIAS;

INSERT INTO ALUNOS 
	VALUES ('GABRIEL')
			, ('JOAO')
			, ('GABRIELA');

INSERT INTO PROFESSORES (NOME)
	VALUES ('FERNANDO')
			, ('HELENA')
			, ('ROBERTO')
			, ('RAQUEL');

SELECT * FROM CATEGORIAS ORDER BY ID
SELECT * FROM PROFESSORES ORDER BY ID

INSERT INTO CURSOS (NOME, TITULO, ID_CATEGORIA, ID_PROFESSOR) 
VALUES				('SQL', 'SQL BÁSICO - PARTE 1', 4, 1),
					('SQL', 'SQL BÁSICO - PARTE 2', 4, 1),
					('JAVA', 'JAVA BÁSICO - PARTE 2', 4, 2),
					('REACT', 'REACT NATIVE - PARTE 1', 4, 2),
					('GESTÃO', 'GESTÃO DE PESSOAS', 5, 3);

SELECT * FROM CURSOS;

-- Retorna os dados das tabelas Cursos e Professores relacionando 
-- Id_Professor da tabela Cursos ao Id da tabela Professores
select * from	
	Cursos,	Professores 
where	
	Cursos.Id_Professor	= Professores.Id

-----------------------------------------------------------------
SELECT 
	*
FROM	
	-- intersecção entre as colunas Cursos e Professores
	CURSOS INNER JOIN PROFESSORES 
ON	
	CURSOS.ID_PROFESSOR	= PROFESSORES.ID
AND -- WHERE
	CURSOS.NOME LIKE '%s%'


-------------------------------------
SELECT 
	* 
FROM	
	-- intersecção entre as tabelas Cursos e Professores
	-- retornando os professores(tabela da direita) mesmo não tendo cursos
	CURSOS RIGHT JOIN PROFESSORES 
ON	
	CURSOS.ID_PROFESSOR	= PROFESSORES.ID

--------------------------------------------------------------------------
-- C = TABELA CURSOS
-- P = TABELA PROFESSORES
SELECT 
	 C.NOME AS NOME_CURSO
	,TITULO
	,P.NOME AS NOME_PROFESSOR
FROM	
	-- intersecção entre as tabelas Cursos e Professores
	-- retornando os cursos(tabela da esquerda) mesmo não tendo professores
	CURSOS C LEFT JOIN PROFESSORES P
ON	
	C.ID_PROFESSOR	= P.ID






SELECT NOME AS NOME_CURSO, TITULO FROM CURSOS

--Retorna o nome e a quantidade de cursos agrupando pelo nome
SELECT NOME, COUNT(NOME) AS QUANTIDADE_CURSOS FROM CURSOS GROUP BY NOME 

--Retorna todos os cursos e seus respectivos professores através do relacionamento
-- usando Where, não recomendado
SELECT * FROM
CURSOS, CATEGORIAS
WHERE
CURSOS.ID_CATEGORIA = CATEGORIAS.ID

SELECT * FROM
CURSOS, PROFESSORES
WHERE
CURSOS.ID_PROFESSOR = PROFESSORES.ID

--------------------------------------------------------------------------------
-- Joins
--Retorna todos os cursos e seus respectivos professores através do relacionamento
-- usando JOIN, recomendado
SELECT * FROM
	CURSOS INNER JOIN PROFESSORES
ON
	CURSOS.ID_PROFESSOR = PROFESSORES.ID

SELECT * FROM PROFESSORES
--Retorna todos os cursos e seus respectivos professores através do relacionamento
-- usando JOIN e abreviação/alias das tabelas, recomendado
-- C = CURSOS
-- P = PROFESSSORES
SELECT 
	C.TITULO AS TITULO_CURSO, 
	C.NOME AS NOME_CURSO, 
	P.NOME AS NOME_PROFESSOR FROM
CURSOS C JOIN PROFESSORES P
ON
C.ID_PROFESSOR = P.ID
AND P.NOME LIKE '%O%' -- faz um filtro na query pelo nome

-- Retorna todos os cursos e professores mesmo o professor não tendo nenhum 
-- curso vinculado a ele
SELECT * FROM
	CURSOS RIGHT JOIN PROFESSORES
ON
	CURSOS.ID_PROFESSOR = PROFESSORES.ID

-- Retorna todos os cursos e professores mesmo o professor não tendo nenhum 
-- curso vinculado a ele
SELECT * FROM
	CURSOS LEFT JOIN PROFESSORES
ON
	CURSOS.ID_PROFESSOR = PROFESSORES.ID

SELECT * FROM
	PROFESSORES LEFT JOIN CURSOS
ON
	PROFESSORES.ID = CURSOS.ID_PROFESSOR
