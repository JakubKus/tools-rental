USE "WypozyczalniaElektronarzedzi"
GO

INSERT INTO Klienci (Imie, Nazwisko)
VALUES
	('Jakub', 'Kus'),
	('Jan', 'Kowalski'),
	('Damian', 'Orlos'),
	('Piotr', 'Gutkowski'),
	('Michal', 'Kubrynski'),
	('Bartlomiej', 'Pilimon'),
	('Witold', 'Szydlo'),
	('Igor', 'Dzialowy')

INSERT INTO Kategorie (NazwaKategorii)
VALUES
	('frezarki'),
	('lutownice'),
	('spawarki'),
	('szlifierki'),
	('tokarki'),
	('wiertarki'),
	('wkretarki')

INSERT INTO Narzedzia (NazwaNarzedzia, IDkategorii, Cena, Dostepnosc) VALUES
('frezarka do metalu', 1, 500, 1),
('frezarka do metalu', 1, 500, 1),
('frezarka do metalu', 1, 500, 1),
('frezarka do krawedzi', 1, 50, 1),
('frezarka do krawedzi', 1, 50, 1),
('frezarka do krawedzi', 1, 50, 1),
('frezarka do glazury', 1, 50, 1),
('frezarka do glazury', 1, 50, 1),
('lutownica transformatorowa', 2, 10, 1),
('lutownica transformatorowa', 2, 10, 1),
('lutownica transformatorowa', 2, 10, 1),
('lutownica grzalkowa', 2, 15, 1),
('lutownica grzalkowa', 2, 15, 1),
('lutownica grzalkowa', 2, 15, 1),
('spawarka do plastiku', 3, 20, 1),
('spawarka do plastiku', 3, 20, 1),
('spawarka swiatlowodowa', 3, 500, 1),
('spawarka swiatlowodowa', 3, 500, 1),
('spawarka transformatorowa', 3, 40, 1),
('spawarka transformatorowa', 3, 40, 1),
('spawarka transformatorowa', 3, 40, 1),
('szlifierka katowa', 4, 15, 1),
('szlifierka katowa', 4, 15, 1),
('szlifierka katowa', 4, 15, 1),
('szlifierka katowa', 4, 15, 1),
('szlifierka prosta', 4, 10, 1),
('szlifierka prosta', 4, 10, 1),
('tokarka tarczowa', 5, 6500, 1),
('tokarka tarczowa', 5, 6500, 1),
('tokarka rewolwerowa', 5, 160, 1),
('tokarka rewolwerowa', 5, 160, 1),
('wiertarka stolowa', 6, 25, 1),
('wiertarka stolowa', 6, 25, 1),
('wiertarka stolowa', 6, 25, 1),
('wiertarka stolowa', 6, 25, 1),
('wiertarka udarowa', 6, 15, 1),
('wiertarka udarowa', 6, 15, 1),
('wiertarka udarowa', 6, 15, 1),
('wiertarka katowa', 6, 30, 1),
('wiertarka katowa', 6, 30, 1),
('wkretarka udarowa', 7, 25, 1),
('wkretarka udarowa', 7, 25, 1),
('wkretarka udarowa', 7, 25, 1),
('wkretarka udarowa', 7, 25, 1),
('wkretarka do plyt gipsowo-kartonowych', 7, 15, 1),
('wkretarka do plyt gipsowo-kartonowych', 7, 15, 1)

INSERT INTO Wypozyczenia(IDklienta, DataWypozyczenia, Zaliczka) VALUES
(1, CONVERT (date, GETDATE()), 30),
(2, CONVERT (date, GETDATE()), 50),
(3, CONVERT (date, GETDATE()), 100)

INSERT INTO PozycjeWypozyczenia(IDwypozyczenia, IDnarzedzia, Rabat) VALUES
(1, 4, 0.05),
(1, 12, 0),
(1, 19, 0),
(2, 9, 0),
(2, 30, 0.1),
(3, 1, 0.2)
