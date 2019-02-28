create database InLock_Games_Tarde

create table ESTUDIOS(
	ID int identity primary key 
	,NOME varchar(255) unique not null
);
create table JOGOS(
	ID int identity primary key
	,NOME varchar(255) not null unique
	,DESCRICAO text 
	,DATA_LANCAMENTO datetime not null 
	,VALOR decimal(10,2) not null
	,ID_ESTUDIO int foreign key references ESTUDIOS(ID)
);
create table USUARIOS(
	ID int identity primary key
	,EMAIL varchar(255) not null unique
	,SENHA varchar(255) not null
	,TIPO_USUARIO varchar (255) not null 
);