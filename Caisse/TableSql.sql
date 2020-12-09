CREATE TABLE produit (
	id int PRIMARY KEY IDENTITY(1,1),
	titre varchar(1000) not null,
	prix decimal not null,
	stock int not null
);

CREATE TABLE panier(
	id int PRIMARY KEY IDENTITY(1,1),
	total decimal not null
);

CREATE TABLE panier_produit(
	id int PRIMARY KEY IDENTITY(1,1),
	panier_id int not null,
	produit_id int not null
);