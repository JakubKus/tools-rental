USE "WypozyczalniaElektronarzedzi"
GO

CREATE TRIGGER przywrocDostepnoscPoUsunieciuPozycji
ON PozycjeWypozyczenia
AFTER DELETE
AS
BEGIN
	UPDATE Narzedzia
	SET Dostepnosc = 1
	FROM deleted
	WHERE Narzedzia.IDnarzedzia = deleted.IDnarzedzia
END
