--SELECIONANDO O BANCO DE DADOS AdventureWorks2012
USE AdventureWorks2012;

--AdventureWorks É UMA BASE DE EXEMPLO DISPONIBILIZADO PELA MS
--PARA TUTORIAIS E TESTES DOS USUÁRIOS SEM TER QUE FICAR CRIANDO
--EXEMPLOS DO ZERO

--SCRIPT PARA CLONAR A TABELA Person.Person
--VERIFICA SE A TABELA Person.Person_Teste EXISTE
--CASO EXISTA, A EXCLUI
--ESTE PASSO É IMPORTANTE POIS SÓ É POSSÍVEL CLONAR UMA TABELA
--EM UMA NOVA CASO ESTA NOVA AINDA NÃO EXISTA
IF EXISTS (SELECT * FROM sys.tables 
WHERE OBJECT_ID =  OBJECT_ID('Person.Person_Teste'))
	DROP TABLE Person.Person_Teste;

--BUSCA TODA A ESTRUTURA E DADOS DA TABELA Person.Person
--E CLONA NA TABELA Person.Person_Teste MESMO QUE ESTA NÃO EXISTA
SELECT * INTO Person.Person_Teste FROM Person.Person

--OU SEJA
--PARA CLONAR UMA TABELA NO SQL, BASTA SEGUIR A SINTAXE ABAIXO
--SELECT * INTO NOVA_TABELA FROM TABELA_A_SER_COPIADA

--VERIFICA SE O ÍNDICE Name_Index EXISTE E O EXCLUI, CASO EXISTA
IF EXISTS (SELECT * FROM sys.indexes
WHERE OBJECT_ID = OBJECT_ID('Person.Person_Teste') 
AND name = 'Name_Index')
	DROP INDEX Person.Person_Teste.Name_Index;

--VERIFICA SE O ÍNDICE IX_Person_LastName_FirstName_MiddleName EXISTE
--CASO EXISTA, O EXCLUI
IF EXISTS (SELECT * FROM sys.indexes
WHERE OBJECT_ID = OBJECT_ID('Person.Person_Teste')
AND name = 'IX_Person_LastName_FirstName_MiddleName')
	DROP INDEX Person.Person_Teste.IX_Person_LastName_FirstName_MiddleName;

--HABILITANDO A IMPRESSÃO DE DADOS ESTATÍSTICOS
SET STATISTICS io ON
SET STATISTICS time ON

--HABILITAR O TABLE SCAN PARA EXIBIR AS INFORMAÇÕES ESTATÍSTICAS 
--A CADA CONSULTA E SEU DESEMPENHO (CTRL+M)

-----------------------------------------------------------------------------

-------------------------CONSULTA SEM ÍNDICES--------------------------------

-----------------------------------------------------------------------------

--BUSCANDO O SOBRENOME(LastName) DE UMA PESSOA
--SEM ÍNDICE E ANALISANDO O DESEMPENHO

SELECT * FROM Person.Person_Teste WHERE LastName = 'Brown';

--O RESULTADO CONSISTE EM 92 LINHAS DE UM TOTAL DE 19.972 LINHAS DA TABELA

--VERIFICAR A ABA PLANO DE EXECUÇÃO PRÓXIMA À DE RESULTADOS

--AO POSICIONAR O MOUSE SOBRE A EXECUÇÃO SELEÇÃO, NOTA-SE QUE ESSA QUERY 
--GEROU UM "CUSTO ESTIMADO DE SUBÁRVORE" DE 2,84451
--ISTO REPRESENTA O CUSTO TOTAL DO OTIMIZADOR DO SQL PARA EXECUTAR NÃO SÓ
--ESSA BUSCA MAS TODAS AS OPERAÇÕES DEPENDENTES DELA
--QUANTO MENOR O NÚMERO, MENOR A INTENSIDADE DA EXECUÇÃO PARA O BANCO

-----------------------------------------------------------------------------

----------------CONSULTA COM ÍNDICE NÃO-CLUSTERIZADO-------------------------

-----------------------------------------------------------------------------

--PARA REALIZAR ESTA BUSCA, AGORA ATRAVÉS DE UM ÍNDICE NÃO-CLUSTERIZADO,
--PRIMEIRO É PRECISO CRIAR O ÍNDICE ENVOLVENDO A COLUNA EM QUESTÃO

--CRIANDO O ÍNDICE NÃO-CLUSTERIZADO Name_Index
CREATE NONCLUSTERED INDEX Name_Index
ON	Person.Person_Teste(LastName)

--OU SEJA
--PARA CRIAR UM ÍNDICE NÃO-CLUSTERIZADO BASTA INFORMAR QUE ELE NÃO SERÁ
--CLUSTERIZADO (NONCLUSTERED INDEX) E DAR UM NOME A ELE (Name_Index)
--E APONTAR PARA A TABELA E A COLUNA (Person.Person_Teste(LastName))

--REALIZANDO NOVA CONSULTA NOS MESMOS MOLDES DA ANTERIOR
SELECT * FROM Person.Person_Teste WHERE LastName = 'Brown';

--OBVIAMENTE, SE OBTÉM AS MESMAS 92 LINHAS DE UM TOTAL DE 19.972 LINHAS DA TABELA

--ANALISANDO O RESULTADO DO PLANO DE EXECUÇÃO

--AGORA AO POSICIONAR O MOUSE SOBRE A EXECUÇÃO SELEÇÃO, NOTA-SE QUE ESSA QUERY 
--GEROU UM "CUSTO ESTIMADO DE SUBÁRVORE" DE 0,299353
--UMA REDUÇÃO DE APROXIMADAMENTE 90% DO CUSTO DO OTIMIZADOR
--JÁ ILUSTRA O GANHO EM QUALQUER TIPO DE CONSULTA REALIZADA COM	
--ESSE TIPO DE ÍNDICE

-----------------------------------------------------------------------------

--------------------CONSULTA COM ÍNDICE CLUSTERIZADO-------------------------

-----------------------------------------------------------------------------

--PARA REALIZAR O TESTE COM UM ÍNDICE CLUSTERIZADO, PRIMEIRO É PRECISO
--EXCLUIR O NÃO-CLUSTERIZADO CRIADO ANTERIORMENTE
--E EM SEGUIDA CRIAR UM NOVO ÍNDICE, DESTA VEZ CLUSTERIZADO

--EXCLUINDO O ÍNDICE NÃO-CLUSTERIZADO Name_Index
IF EXISTS (SELECT * FROM sys.indexes 
WHERE OBJECT_ID = OBJECT_ID('Person.Person_Teste')
AND name = 'Name_Index')
	DROP INDEX Person.Person_Teste.Name_Index;

--CRIANDO O ÍNDICE CLUSTERIZADO Name_Index
CREATE CLUSTERED INDEX Name_Index
ON	Person.Person_Teste(LastName);

--OU SEJA
--PARA CRIAR UM ÍNDICE CLUSTERIZADO BASTA INFORMAR QUE ELE SERÁ
--CLUSTERIZADO (CLUSTERED INDEX) E DAR UM NOME A ELE (Name_Index)
--E APONTAR PARA A TABELA E A COLUNA (Person.Person_Teste(LastName))

--REALIZANDO NOVA CONSULTA NOS MESMOS MOLDES DAS ANTERIORES
SELECT * FROM Person.Person_Teste WHERE LastName = 'Brown';

--NOVAMENTE, TEM-SE 92 LINHAS DE UM TOTAL DE 19.972 LINHAS DA TABELA

--ANALISANDO O RESULTADO DO PLANO DE EXECUÇÃO

--AO POSICIONAR O MOUSE SOBRE A EXECUÇÃO SELEÇÃO, NOTA-SE QUE
--O "CUSTO ESTIMADO DE SUBÁRVORE" DESTA VEZ FOI DE 0,0155985!
--COMPARANDO COM A BUSCA SEM ÍNDICE ONDE O CUSTO FOI DE 2,84451
--ISTO REPRESENTA UMA REDUÇÃO DE APROXIMADAMENTE 99,5% (!!!) DO CUSTO DO OTIMIZADOR
--UM ENORME GANHO LEVANDO EM CONTA UMA MASSA EXPRESSIVA DE DADOS




--fonte do teste
--https://www.devmedia.com.br/indices-clusterizados-e-nao-clusterizados-no-sql-server/30288




-----------------------------------------------------------------------------

--------------------------------LINKS ÚTEIS----------------------------------

-----------------------------------------------------------------------------

--como restaurar um banco de dados através de um arquivo .bak
--https://docs.microsoft.com/pt-pt/sql/relational-databases/backup-restore/restore-a-database-backup-using-ssms?view=sql-server-2017

--repositório do github com os arquivos .bak armazenados
--https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks

--tipos de índices
--https://docs.microsoft.com/pt-br/sql/relational-databases/indexes/indexes?view=sql-server-2017

--descrição dos conceitos
--https://docs.microsoft.com/pt-br/sql/relational-databases/indexes/clustered-and-nonclustered-indexes-described?view=sql-server-2017
