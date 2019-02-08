use HROADS_IMPORT_EXPORT;

insert into CLASSES	(NOME)
	values			('Bárbaro'),
					('Cruzado'),
					('Caçadora de Demônios'),
					('Monge'),
					('Necromante'),
					('Feiticeiro'),
					('Arcanista')


insert into TIPOS_HABILIDADES	(NOME)
	values						('Ataque'),
								('Defesa'),
								('Cura'),
								('Magia')

insert into HABILIDADES (NOME, ID_TIPO_HABILIDADE)
	values				('Lança Mortal', 1),
						('Escudo SUpremo', 2),
						('Recuperar Vida', 3)

update HABILIDADES set NOME = 'Escudo Supremo' where ID = 2 -- Corrige o nome da habilidade Escudo Supremo

insert into CLASSE_HABILIDADES	(ID_CLASSE, ID_HABILIDADE)
	values						(1,1),
								(1, 2),
								(2, 2),
								(3, 1),
								(4, 3),
								(4, 2),
								--Necromancer--Comeca sem habilidades
								(6, 3)
								--Arcanista--Comeca sem habilidades

/*
insert into PERSONAGENS	(NOME, ID_CLASSE, CAPACIDADE_MAX_VIDA, CAPACIDADE_MAX_MANA, DATA_ATUALIZACAO, DATA_CRIACAO)
	values				('DeuBug', 1, 100, 80, GETDATE(), '18/01/2019'),
						('BitBug', 4, 70, 100, GETDATE(), '17/03/2016'),
						('Fer8', 7, 75, 60, GETDATE(), '18/03/2016')

update PERSONAGENS set NOME = 'Fer7' where ID = 3 --Troca o nome do personagem para Fer7
update CLASSES set NOME = 'Necromancer' where ID = 5 --Troca o nome da classe para Necromancer
*/