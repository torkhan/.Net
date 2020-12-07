--Table Hotel
CREATE TABLE hotel(
	id int PRIMARY KEY IDENTITY(1,1),
	nom varchar(100) not null,
	adresse varchar(1000) not null,
	telephone varchar(10) not null,
);

--Table Client
CREATE TABLE client(
	id int PRIMARY KEY IDENTITY(1,1),
	nom varchar(100) not null,
	prenom varchar(100) not null,
	telephone varchar(10) not null,
);

--Table chambre
CREATE TABLE chambre(
	id int PRIMARY KEY IDENTITY(1,1),
	numero int not null,
	hotel_id int not null,
	capacite int not null,
	statut varchar(100),
	tarif decimal,
);

--Table Reservation
CREATE TABLE reservation(
	id int PRIMARY KEY IDENTITY(1,1),
	numero int not null,
	client_id int not null,
	hotel_id int not null,
	total decimal,
	statut varchar(100)
);

--Table reservation_chambre
CREATE TABLE reservation_chambre(
	id int PRIMARY KEY IDENTITY(1,1),
	reservation_id int not null,
	chambre_id int not null,
);