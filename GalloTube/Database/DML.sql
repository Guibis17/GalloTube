USE GalloTubeDb;

INSERT INTO Tag(Id, Name) VALUES
(1, '#Animes'),
(2, '#Games'),
(3, '#Estudos'),
(4, '#Filmes'),
(5, '#Séries'),
(6, '#Comédia'),
(7, '#Desenhoanimado'),
(8,'#Música'),
(9,'#Exercíciosfísicos'),
(10,'#Terror'),
(11,'#Futebol'),
(12,'#Esporte'),
(13,'#Pegadinha'),
(14,'#Humor');
INSERT INTO Video VALUES
( 1, 'Haaland faz hat-trick, também dá assistência, e Manchester City goleia o Fulham pela Premier League', 'Todo o esporte AO VIVO da ESPN disponível também no Star+! Assine já!', "2023-090-02 00:21:21", 11, '\\img\\1.jpg', 'https://www.youtube.com/watch?v=1OcJWGO688w');

INSERT INTO Video VALUES
( 2, 'ASSISTI O PRIMEIRO EPISÓDIO DO LIVE ACTION DE ONE PIECE NA NETFLIX [Sem Spoilers]', 'One Piece finalmente saiu! Ficou incrível ou é flop? Bora conferir um review completo sobre o primeiro episódio! Vem comigo que eu vou te dizer o que achei, quais pontos acertaram, onde erraram e se vale a pena assistir! Será que vale a pena ou mais uma vez vão errar numa adaptação de anime? Finalmente a série de One Piece saiu e ainda continua dividindo opiniões do público. Tem gente por aí que amou, outros fãs já não curtiram tanto. Mas uma coisa é certa, por mais que você não tenha gostado da série, não tem como negar que ela é bem feita e que o elenco tá incrível! Nesse vídeo nós vamos fazer um review sem spoiler do primeiro episódio, é pra não ter spoiler mesmo, mas vou falar de algumas ligações que a série trouxe e que já mostra como que a Netflix vai conseguir colocar mais de mil episódios de anime em uma série live action sem perder a essência da obra original, ou pelo menos tentar! ', "2023-08-31 00:05:21", 1, '\\img\\2.jpg', 'https://www.youtube.com/watch?v=qYlqkK6Ia9U');

INSERT INTO Video VALUES
( 3, 'Oppenheimer | Official Trailer', 'Oppenheimer - Only In Theaters 7 21 23 Written and directed by Christopher Nolan, Oppenheimer is an IMAX®-shot epic thriller that thrusts audiences into the pulse-pounding paradox of the enigmatic man who must risk destroying the world in order to save it. ', "2022-12-18 00:05:21", 4, '\\img\\3.jpg', 'https://www.youtube.com/watch?v=bK6ldnjE3Y0');

INSERT INTO VideoTag VALUES
( 1, 14);