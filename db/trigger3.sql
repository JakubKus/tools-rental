USE "WypozyczalniaElektronarzedzi"
GO

CREATE TRIGGER usunDostepnoscPoWypozyczeniu
ON PozycjeWypozyczenia
FOR INSERT
AS
BEGIN
	UPDATE Narzedzia
	SET Dostepnosc = 0
	FROM inserted
		JOIN PozycjeWypozyczenia ON inserted.IDnarzedzia=PozycjeWypozyczenia.IDnarzedzia
		JOIN Wypozyczenia ON PozycjeWypozyczenia.IDwypozyczenia = Wypozyczenia.IDwypozyczenia
	WHERE Wypozyczenia.DataZwrotu IS NULL
		AND inserted.IDnarzedzia = Narzedzia.IDnarzedzia
END
