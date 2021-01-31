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


