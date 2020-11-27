drop database if exists clubfromage;
create database clubfromage;

use clubfromage;

create table Pays(
	id int primary key auto_increment,
    name varchar(100) not null
) engine InnoDB;

create table Fromage(
	id int primary key auto_increment,
    name varchar(100) not null,
    pays_origine_id int,
    durAffinage int,
    histoire longtext,
    recette longtext,
    creation date,
    image varchar(255),
    constraint foreign key (pays_origine_id) references Pays(id) on delete set null
) engine InnoDB;

create table Membre(
	id int primary key auto_increment,
    username varchar(180),
    email varchar(320),
    enabled boolean,
    password varchar(255),
    lastLogin datetime,
    pseudo varchar(30),
    entryDate date
) engine InnoDB;

create table Avis(
	fromageId int,
    membreId int,
    avis varchar(2000),
    stars tinyint,
    primary key (membreId, fromageId),
    constraint foreign key (fromageId) references Fromage(id),
    constraint foreign key (membreId) references Membre(id)
) engine InnoDB;

insert into Pays values (75,'France');
insert into Fromage values (1,'Reblochon',75,12,'Au temps des chevaliers, blablablablablalb.....',
			'Du lait de Haute-Savoie, de la patience et c\'est tout','2020-08-26','reblochon.png');
insert into Fromage values (2,'Comté 18 mois',75,18,'Dans le haut-Jura, blablablablablalb.....',
			'Du lait du Jura, de la patience et c\'est tout','2020-08-26','comte18.png');
insert into Membre values (1,'Josiane Mottier','jo74@yahoo.fr',true,'password',now(),'jo74','2020-08-26');
insert into Membre values (2,'Sylvain Branzin','siss74@gmail.com',true,'password',now(),'siss74','2020-08-26');
insert into Avis values (1,1,'un bon fromage crémeux',5);
insert into Avis values (2,1,'un bon fromage à pate dure',4);
insert into Avis values (1,2,'un excellent fromage crémeux de Manigod!',5);
insert into Avis values (2,2,'moins bon, pas de Manigod',1);

select * from avis;
SELECT Fromage.id as idFromage, Fromage.name as nomFromage, Pays.name as nomPays, DATE_FORMAT(creation, '%d/%m/%Y') AS date_creation_fr,
       Fromage.histoire as histFromage, Fromage.recette as recFromage 
    FROM Fromage JOIN Pays ON Fromage.pays_origine_id = Pays.id ORDER BY date_creation_fr DESC LIMIT 0, 5;
