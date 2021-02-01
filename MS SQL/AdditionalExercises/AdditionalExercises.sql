USE Diablo;

--1. Number of Users for Email Provider

SELECT [Email Provider], COUNT([Email Provider]) AS [Number Of Users]
	FROM
	(
		SELECT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
			FROM Users
	) AS t
		GROUP BY [Email Provider]
		ORDER BY  [Number Of Users] DESC, [Email Provider]


--Problem 2.	All User in Games

SELECT g.[Name] AS [Game], 
	   gt.[Name] AS [Game Type],
	   u.Username,
	   ug.[Level],
	   ug.Cash,
	   c.[Name] AS [Character]
	FROM UsersGames ug
	JOIN Users u ON ug.UserId = u.Id
	JOIN Characters c ON ug.CharacterId = c.Id
	JOIN Games g ON ug.GameId = g.Id
	JOIN GameTypes gt ON g.GameTypeId = gt.Id
		ORDER BY [Level] DESC, Username, Game


--Problem 3.	Users in Games with Their Items

SELECT u.Username,
       g.[Name] AS Game, 
       COUNT(ugi.ItemId) AS [Items Count], 
	   SUM(i.Price) AS [Items Price]
  FROM Games AS g
	JOIN UsersGames ug ON ug.GameId = g.Id
	JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
    JOIN Items i ON i.Id = ugi.ItemId
	JOIN Users u ON u.Id = ug.UserId
		GROUP BY g.[Name], u.Username
			HAVING COUNT(ugi.ItemId) >= 10
		ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username


--Problem 4.	* User in Games with Their Statistics

SELECT u.Username AS Username,
		g.[Name] AS Game,
		MAX(ch.[Name]) AS Character,
		SUM(sta.Strength) + MAX(gtst.Strength) + MAX(chst.Strength) AS Strength,
		SUM(sta.Defence) + MAX(gtst.Defence) + MAX(chst.Defence) AS Defence,
		SUM(sta.Speed) + MAX(gtst.Speed) + MAX(chst.Speed) AS Speed,
		SUM(sta.Mind) + MAX(gtst.Mind) + MAX(chst.Mind) AS Mind,
		SUM(sta.Luck) + MAX(gtst.Luck) + MAX(chst.Luck) AS Luck
	FROM Users AS u
	JOIN UsersGames AS ug ON u.Id = ug.UserId
	JOIN Games AS g ON ug.GameId = g.Id
	JOIN Characters AS ch ON ug.CharacterId = ch.Id
	JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
    JOIN Items AS i ON ugi.ItemId = i.Id
    JOIN [Statistics] AS sta ON i.StatisticId = sta.Id
    JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
    JOIN [Statistics] AS chst ON ch.StatisticId = chst.Id
    JOIN [Statistics] AS gtst ON gt.BonusStatsId = gtst.Id
		GROUP BY u.Username, g.Name
		ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC


--Problem 5.	All Items with Greater than Average Statistics

SELECT i.[Name],
	   i.Price,
	   i.MinLevel,
	   s.Strength,
	   s.Defence,
	   s.Speed,
	   s.Luck,
	   s.Mind
	FROM Items i
	JOIN [Statistics] s ON i.StatisticId = s.Id
		WHERE s.Mind > (SELECT AVG(Mind) FROM [Statistics]) 
			 AND  s.Luck > (SELECT AVG(Luck) FROM [Statistics])
			 AND s.Speed > (SELECT AVG(Speed) FROM [Statistics])
		ORDER BY i.[Name]


--Problem 6.	Display All Items with Information about Forbidden Game Type

SELECT i.[Name] AS Item,
	   i.Price,
	   i.MinLevel,
	   gt.[Name] AS [Forbidden Game Type]
	FROM Items i
	LEFT JOIN GameTypeForbiddenItems gtf ON i.Id = gtf.ItemId
	LEFT JOIN GameTypes gt ON gtf.GameTypeId = gt.Id
		ORDER BY gt.[Name] DESC, i.[Name] ASC


--Problem 7.	Buy Items for User in Game


DECLARE @AlexUserGameId  INT = (SELECT Id 
									FROM UsersGames
										WHERE GameId = (SELECT Id FROM Games WHERE [Name] = 'Edinburgh') AND
											  UserId = (SELECT Id FROM Users WHERE Username = 'Alex'))

DECLARE @AlexItemsPrice MONEY = (SELECT SUM(Price) 
									FROM Items
										WHERE [Name] IN ('Blackguard', 
														 'Bottomless Potion of Amplification', 
														 'Eye of Etlich (Diablo III)', 
														 'Gem of Efficacious Toxin', 
													     'Golden Gorget of Leoric', 
														 'Hellfire Amulet'))

DECLARE @GameID INT = (Select GameId 
						FROM UsersGames 
						  WHERE Id = @AlexUserGameId)

INSERT UserGameItems
	SELECT Id, @AlexUserGameId
		FROM Items
			WHERE [Name] IN ('Blackguard', 
							 'Bottomless Potion of Amplification', 
							 'Eye of Etlich (Diablo III)', 
						     'Gem of Efficacious Toxin', 
							 'Golden Gorget of Leoric', 
							 'Hellfire Amulet')

UPDATE UsersGames
	SET Cash = Cash - @AlexItemsPrice
		WHERE Id = @AlexUserGameId

SELECT u.Username, 
	   g.Name, 
	   ug.Cash, 
	   i.Name AS [Item Name]
	FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
    JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
    JOIN Items AS i ON i.Id = ugi.ItemId
		WHERE ug.GameId = @GameID
			ORDER BY [Item Name]


--PART II – Queries for Geography Database
--Problem 8.	Peaks and Mountains

USE Geography;

SELECT p.PeakName,
	   m.MountainRange AS Mountain,
	   Elevation
	FROM Mountains m
	JOIN Peaks p ON p.MountainId = m.Id
		ORDER BY Elevation DESC, PeakName


--Problem 9.	Peaks with Their Mountain, Country and Continent

SELECT p.PeakName,
	   m.MountainRange AS Mountain,
	   c.CountryName,
	   co.ContinentName
	FROM Peaks p
	JOIN Mountains m ON p.MountainId = m.Id
	JOIN MountainsCountries mc ON m.Id = mc.MountainId
	JOIN Countries c ON mc.CountryCode = c.CountryCode
	JOIN Continents co ON c.ContinentCode = co.ContinentCode
		ORDER BY p.PeakName, c.CountryName


--Problem 10.	Rivers by Country

SELECT c.CountryName,
	   co.ContinentName,
	   COUNT(r.Id) AS RiversCount,
	   CASE 
			WHEN SUM(r.Length) > 0 THEN SUM(r.Length)
			ELSE 0 
		END AS TotalLength
	FROM Countries c
	LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers r ON cr.RiverId = r.Id
	LEFT JOIN Continents co ON c.ContinentCode = co.ContinentCode
		GROUP BY c.CountryName, co.ContinentName
			ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName


--Problem 11.	Count of Countries by Currency


SELECT cr.CurrencyCode,
	   cr.[Description] AS Currency,
	   COUNT(c.CountryName) AS NumberOfCountries
	FROM Currencies cr
	LEFT JOIN Countries c ON cr.CurrencyCode = c.CurrencyCode
		GROUP BY cr.CurrencyCode, cr.[Description]
			ORDER BY NumberOfCountries DESC, Currency


--Problem 12.	Population and Area by Continent

SELECT co.ContinentName,
	   SUM(c.AreaInSqKm) AS CountriesArea,
	   SUM(CAST(c.Population AS BIGINT)) AS CountriesPopulation
	FROM Continents co
	JOIN Countries c ON co.ContinentCode = c.ContinentCode
		GROUP BY co.ContinentName
			ORDER BY CountriesPopulation DESC


--Problem 13.	Monasteries by Country

CREATE TABLE Monasteries
(
Id INT PRIMARY KEY IDENTITY, 
[Name] VARCHAR(200) NOT NULL,
CountryCode CHAR(2) REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries([Name], CountryCode) 
VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
	ADD IsDeleted BIT NOT NULL
		CONSTRAINT DF_Countries_IsDeleted DEFAULT 0

MERGE INTO Countries c
   USING (
          SELECT c.CountryCode,
				 COUNT(cr.RiverId) AS RiversCount
			FROM Countries c
			JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
				GROUP BY c.CountryCode
				HAVING COUNT(cr.RiverId) > 3
         ) cc
      ON c.CountryCode = cc.CountryCode
WHEN MATCHED THEN
   UPDATE 
      SET IsDeleted = 1;

SELECT m.[Name] AS Monastery,
	   c.CountryName AS Country
	FROM Monasteries m
	JOIN Countries c ON m.CountryCode = c.CountryCode
		WHERE c.IsDeleted = 0
		ORDER BY Monastery


--14. Monasteries by Continents and Countries

UPDATE Countries
	SET CountryName = 'Burma'
		WHERE CountryName = 'Myanmar'
		
INSERT INTO Monasteries
	VALUES('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania')),
		  ('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))


SELECT	co.ContinentName,
		c.CountryName,
		COUNT(m.CountryCode) AS MonasteriesCount
	FROM Countries c
	JOIN Continents co ON c.ContinentCode = co.ContinentCode
	 LEFT JOIN Monasteries m ON c.CountryCode = m.CountryCode
		WHERE c.IsDeleted = 0
		GROUP BY co.ContinentName, c.CountryName
			ORDER BY MonasteriesCount DESC, c.CountryName
