
--Création de TABLE
CREATE TABLE personne (id int PRIMARY KEY IDENTITY(1,1), nom varchar(120) NOT NULL, prenom varchar(50) NOT NULL);

--Supprimer une TABLE
DROP TABLE personne;

--Modification d'une TABLE
--Ajouter une column
ALTER TABLE personne ADD telephone varchar(10) NOT NULL;

--Supprimer une column
ALTER TABLE personne DROP COLUMN telephone;

--ALTER TABLE peronne RENAME COLUMN telephone to phone
--Uniquement pour SQL SERVER
EXEC sp_rename 'personne.telephone', 'phone', 'COLUMN'; 

--Ajouter des données dans une table
INSERT INTO personne (nom, prenom, telephone) values ('abadi', 'ihab', '0606060606');
INSERT INTO personne (nom, prenom, telephone) values ('toto', 'tata', '0606060606');

--Pour supprimer des données dans une table
--DELETE FROM personne
--DELETE FROM personne WHERE id = 4;
--DELETE FROM personne WHERE nom = 'abadi';
--DELETE FROM personne WHERE nom = 'abadi' AND prenom='ihab';
--DELETE FROM personne WHERE nom = 'abadi' OR nom='toto';

--Pour modifier des données dans une table

--UPDATE personne set nom = 'coucou', prenom = 'ttttt';
UPDATE personne set telephone='0707070707' where id=8;

--SELECTION
SELECT * FROM personne;
SELECT id, nom, prenom, telephone from personne;

-- AS permet d'ajouter un alias à une colonne uniquement à la réponse de la requete
--SELECT id as personneId, nom, prenom, telephone from personne;
--SELECT * FROM personne where id <> 8 AND id<>10;
--SELECT * FROM personne where nom = 'abadi'
--SELECT * FROM personne where nom like 'aba%'
--SELECT * FROM personne where nom like '%aba'
--SELECT * FROM personne where nom like '%t%'

--Les relations entre tables

--Creer une table adresse (id, adresse, ville, codePostal, personne_id)
CREATE TABLE adresse (
id int PRIMARY KEY IDENTITY(1,1),
adresse VARCHAR(2000) NOT NULL,
ville varchar(200) NOT NULL,
code_postal varchar(5) NOT NULL,
personne_id int NOT NULL
)

--INSERT INTO adresse (adresse, ville, code_postal, personne_id) 
--values ('lille', 'lille', '59000', 10)
--INSERT INTO adresse (adresse, ville, code_postal, personne_id) 
--values ('lille', 'paris', '75000', 10)

--Jointure
--inner join
SELECT * FROM personne inner join adresse on personne.id = adresse.personne_id
SELECT p.id, p.nom, p.prenom, p.telephone, a.adresse, a.ville, a.code_postal FROM personne as p inner join adresse as a on p.id = a.personne_id where p.id = 10
--LEFT OR RIGHT JOIN

SELECT * FROM adresse right join personne on personne.id = adresse.personne_id
---<=>
SELECT * FROM personne left join adresse on personne.id = adresse.personne_id

--Correction exercice 1

CREATE TABLE  Chambre (
num_chambre int PRIMARY key IDENTITY (10,1),
prix decimal,
nbre_lit int,
nbre_pers int,
confort varchar(50),
equi varchar(50)
)

CREATE TABLE Client(
num_client int PRIMARY key IDENTITY(1000,1),
nom varchar(50),
prenom varchar(50),
adresse varchar(50)
)

CREATE TABLE reservation(
id int PRIMARY KEY IDENTITY(1,1),
idChambre int,
idClient int,
date_arr datetime,
date_dep datetime
)

insert into Chambre (prix, nbre_lit, nbre_pers, confort, equi) values 
(80,1,2,'wc', 'non'), 
(100,2,2,'douche', 'non'), 
(180,3,3,'bain', 'tv');
insert into reservation (idClient, idChambre, date_arr, date_dep) values 
(1,2, '2004-02-09', '2004-02-21'), 
(2,1,'2005-06-30', null);
insert into Client (nom, prenom, adresse) values 
('Denez','Desmond','Marseille'), 
('Noua','Ghislaine','Paris');

--Q1
SELECT num_chambre from Chambre where equi = 'TV' OR confort = 'TV';

--Q2
SELECT num_chambre, nbre_pers from Chambre;
SELECT num_chambre, nbre_pers from Chambre order by prix ASC;
SELECT TOP 2 num_chambre, nbre_pers from Chambre order by prix ASC;
--Q3
SELECT SUM(nbre_pers) as capacite from Chambre;

--Q4
SELECT prix/nbre_pers as prix_personne, num_chambre FROM Chambre where equi = 'TV';

--Q5
SELECT idClient, idChambre FROM reservation where 
date_arr <= '2004-02-09' and (date_dep > '2004-02-09' OR date_dep is null);

--Q6
SELECT num_chambre FROM Chambre where prix <= 80 OR (prix <= 120 AND confort = 'bain')

--Q7
SELECT nom, prenom, adresse FROM client where nom like 'd%'

--Q8
SELECT COUNT(num_chambre) as nombreChambres FROM Chambre WHERE prix >= 85 and prix <= 120;

--Q9
SELECT  c.nom, r.date_arr FROM client as c 
inner join reservation as r on c.num_client = r.idClient 
where r.date_dep is NULL;

--Requetes imbriquées

SELECT num_chambre from Chambre where prix >= (SELECT AVG(prix) from Chambre)

--Correction EX2

--Q1
SELECT TOP 10 * FROM villes_france_free order by ville_population_2012 desc

--Q2
SELECT TOP 50 * FROM villes_france_free order by ville_surface ASC

--Q3
SELECT * from departement where departement_code like '97%'

--Q4
SELECT TOP 10 v.ville_nom, d.departement_nom from villes_france_free as v 
left join departement as d on v.ville_departement = d.departement_code 
order by v.ville_population_2012 desc;

--Q5
SELECT v.ville_departement, d.departement_nom, COUNT(*) as nombre_ville
FROM villes_france_free as v left join departement as d on v.ville_departement = d.departement_code
GROUP BY v.ville_departement, d.departement_nom ORDER BY nombre_ville DESC;

--Q6
SELECT TOP 10 d.departement_nom, v.ville_departement, SUM(v.ville_surface) as surface
FROM villes_france_free as v left join departement as d on v.ville_departement = d.departement_code
GROUP BY v.ville_departement, d.departement_nom ORDER BY surface DESC;

--Q7
SELECT COUNT(*) FROM villes_france_free where ville_nom like 'SAINT%';

--Q8
SELECT ville_nom, COUNT(*) as nombre_fois from villes_france_free 
group by ville_nom order by nombre_fois desc;

--Q9
SELECT * FROM villes_france_free 
where ville_surface > (SELECT AVG(ville_surface) FROM villes_france_free);

--Q10
SELECT ville_departement, SUM(ville_population_2012) as population_2012 from villes_france_free
group by ville_departement HAVING SUM(ville_population_2012) > 2000000

--Q11
UPDATE villes_france_free set ville_nom = REPLACE(ville_nom,'-', ' ')
where ville_nom like 'SAINT-%';

