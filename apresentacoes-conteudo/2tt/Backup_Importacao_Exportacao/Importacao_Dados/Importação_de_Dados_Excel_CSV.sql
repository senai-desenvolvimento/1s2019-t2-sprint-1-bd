--Inserção de dados - SQL

bulk insert personagens
from 'C:\db\Personagens_hroads.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);

select * from PERSONAGENS -- Lista todos os registros da tabela personagens

truncate table personagens -- Apaga todos os registros da tabela