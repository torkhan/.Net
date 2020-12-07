--Création des tables
CREATE TABLE chambre (num_chambre int PRIMARY KEY IDENTITY (10,1) ,prix int, nbre_lits int, nbre_pers int, confort varchar(50), equ varchar(50));
CREATE TABLE client (num_client int PRIMARY KEY IDENTITY (1000,1), nom varchar(100), prenom varchar(100), adresse varchar(50));
CREATE TABLE reservation (id int PRIMARY KEY IDENTITY (1,1), chambre_num_chambre int, client_num_client int, date_arr date, date_dep date);
drop table reservation
drop table client
drop table chambre

--Remplir les tables
INSERT INTO chambre ( num_chambre,prix,nbre_lits, nbre_pers, confort,equ) values (10, 80, 01, 02, 'WC',NULL);
INSERT INTO chambre (num_chambre,prix,nbre_lits, nbre_pers, confort,equ) values (20,100,02,02,'douche',NULL);
INSERT INTO chambre (num_chambre,prix,nbre_lits, nbre_pers, confort,equ) values (25,180,03,03,'Bain','tv');


INSERT INTO client (num_client,nom,prenom,adresse) values (1000,'Denez','Desmond', 'Marseille');
INSERT INTO client (num_client,nom,prenom,adresse) values (1001,'Noua','Ghuslaine', 'Paris');

INSERT INTO reservation (chambre_num_chambre,client_num_client, date_arr, date_dep) values (1000,20,'2004/02/09','2004/02/21');
INSERT INTO reservation (chambre_num_chambre,client_num_client, date_arr, date_dep) values (1001,10,'2005/06/30',NULL);

--Requêtes
SELECT * FROM chambre where equ='tv';
SELECT num_chambre, nbre_pers FROM chambre;
SELECT Sum(nbre_pers) FROM chambre;
SELECT prix/nbre_pers FROM chambre where equ='tv';
--SELECT chambre_num_chambre, client_num_client FROM reservation where date_arr <='09/02/2004' AND date_dep > '09/02/2004';
SELECT Num_Chambre FROM Chambre where Prix <= '80' OR (Confort='Bain' And Prix <='120') ;
SELECT nom FROM client where nom like'D%';

