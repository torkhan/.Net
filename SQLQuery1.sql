CREATE TABLE client(id int PRIMARY KEY IDENTITY(1,1), nom varchar(100) NOT NULL, prenom varchar(100) NOT NULL, telephone varchar(10) NOT NULL) 


CREATE TABLE Compte(
	id int PRIMARY KEY IDENTITY(1,1),
	solde decimal not null,
	client_id int not null,
);

CREATE TABLE Operation(
	id int PRIMARY KEY IDENTITY(1,1),
	compte_id int not null,
	date_operation datetime,
	montant decimal not null
);

--CREATE TABLE CompteEpargne(
--	id int PRIMARY KEY IDENTITY(1,1),
--	compte_id int,
--	taux decimal,
--	);

