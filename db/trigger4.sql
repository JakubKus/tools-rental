USE "WypozyczalniaElektronarzedzi"
GO

CREATE TRIGGER usunPozycjeWypozyczen
ON Wypozyczenia
AFTER DELETE
AS
BEGIN
	DELETE FROM PozycjeWypozyczenia
	FROM deleted
	WHERE PozycjeWypozyczenia.IDwypozyczenia = deleted.IDwypozyczenia
END
