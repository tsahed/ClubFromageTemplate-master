drop database if exists dsfootamericain;
create database dsfootamericain;
use dsfootamericain;

create table Pays(
	id int primary key,
    nom varchar(50)
) engine InnoDB;

create table Poste(
	id int primary key,
    nom varchar(50),
    escouade int
)engine InnoDB;

create table Equipe(
	id int primary key,
    nom varchar(50),
    dateCreation date
)engine InnoDB;

create table Joueur(
	id int primary key,
    nom varchar(50),
    dateEntree date,
    dateNaissance date,
    pays int,
    poste int,
    equipe int,
    foreign key (pays) references Pays(id),
    foreign key (poste) references Poste(id),
    foreign key (equipe) references Equipe(id)
)engine InnoDB;

insert into Pays values (1,'France'),
						(2,'USA'),
                        (3,'Espagne');
insert into Poste values (1,'Quaterback',1),
						(2,'Allier',2),
                        (3,'Avant',3);
insert into Equipe values (1,'49ers','1900-05-04'),
						(2,'Partiots','1845-09-06'),
                        (3,'Nuggets','1956-06-21');
insert into Joueur values (1,'Alain Ducret','2020-04-05','1978-10-19',1,1,1),
						(2,'Lebron James','2019-03-12','1987-06-06',2,2,2),
                        (3,'Raphael Nadal','2008-06-06','1986-05-06',3,3,3);
                        
	
