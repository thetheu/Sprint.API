USE T_RoteiroFilmes

SELECT * FROM Filmes
SELECT * FROM Generos

DELETE FROM Filmes

SELECT Filmes.IdFilme,Titulo , Generos.* 
FROM Filmes
JOIN Generos
ON filmes.IdGenero =  Generos.IdGenero Where IdFilme = 6


INSERT INTO Filmes (Titulo, IdGenero) VALUES ('BLA1', 3)
											,('BLA23', 2)