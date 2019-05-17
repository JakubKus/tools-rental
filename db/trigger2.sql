USE "WypozyczalniaElektronarzedzi"
GO

CREATE TRIGGER przywrocDostepnoscPoZwrocie
ON Wypozyczenia
FOR UPDATE
AS
BEGIN
	UPDATE Narzedzia
	SET Dostepnosc = 1
	FROM inserted
		JOIN PozycjeWypozyczenia ON inserted.IDwypozyczenia = PozycjeWypozyczenia.IDwypozyczenia
	WHERE PozycjeWypozyczenia.IDnarzedzia = Narzedzia.IDnarzedzia
END
