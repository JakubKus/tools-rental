EXECUTE (N'CREATE DATABASE "WypozyczalniaElektronarzedzi"')
GO
USE "WypozyczalniaElektronarzedzi"
GO

CREATE TABLE Klienci (
	IDklienta int PRIMARY KEY NOT NULL IDENTITY,
	Imie nvarchar(25) NOT NULL,
	Nazwisko nvarchar(25) NOT NULL
)

CREATE TABLE Wypozyczenia  (
	IDwypozyczenia int PRIMARY KEY NOT NULL IDENTITY,
	IDklienta int NOT NULL,
	DataWypozyczenia date NOT NULL,
	DataZwrotu date NULL,
	Zaliczka float NULL,
	CONSTRAINT "FK_Wypozyczenia_Klienci" FOREIGN KEY ("IDklienta") REFERENCES "dbo"."Klienci" ("IDklienta")
)

CREATE TABLE Kategorie (
	IDkategorii int PRIMARY KEY NOT NULL IDENTITY,
	NazwaKategorii nvarchar(25) NOT NULL,
)

CREATE TABLE Narzedzia (
	IDnarzedzia int PRIMARY KEY NOT NULL IDENTITY,
	IDkategorii int NOT NULL,
	NazwaNarzedzia nvarchar(40) NOT NULL,
	Dostepnosc bit NOT NULL,
	Cena float NOT NULL,
	CONSTRAINT "FK_Narzedzia_Kategorie" FOREIGN KEY ("IDkategorii") REFERENCES "dbo"."Kategorie" ("IDkategorii"),
)

CREATE TABLE PozycjeWypozyczenia (
	IDwypozyczenia int NOT NULL,
	IDnarzedzia int NOT NULL,
	Rabat float NOT NULL,
	CONSTRAINT "FK_PozycjeWypozyczenia_Wypozyczenia" FOREIGN KEY ("IDwypozyczenia") REFERENCES "dbo"."Wypozyczenia" ("IDwypozyczenia"),
	CONSTRAINT "FK_PozycjeWypozyczenia_Narzedzia" FOREIGN KEY ("IDnarzedzia") REFERENCES "dbo"."Narzedzia" ("IDnarzedzia"),
	CONSTRAINT "C_Rabat" CHECK (Rabat >= 0 AND Rabat < 1)
)
