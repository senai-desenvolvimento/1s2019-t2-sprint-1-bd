--Inserir dados .csv

use TESTE_IMPORTACAO_HROADS_TARDES;

--Importar dados do .csv Excel
bulk insert PERSONAGENS
from 'C:\Users\33747821839\Desktop\senai_hroads_sprint1_bd\Nova_Planilha_HROADS_Personagens.csv'
with(
	format = 'csv',
	firstrow = 2,
	fieldterminator = ';',
	rowterminator = '\n'
);