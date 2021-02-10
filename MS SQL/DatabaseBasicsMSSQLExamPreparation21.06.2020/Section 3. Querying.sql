--===================================         Section 3. Querying	=================================================

--5. EEE-Mails

SELECT a.FirstName,
		a.LastName,
		FORMAT(a.BirthDate, 'MM-dd-yyyy'),
		c.Name AS Hometown,
		a.Email
	FROM Accounts a
	JOIN Cities c ON a.CityId = c.Id
	WHERE Email LIKE 'e%'
	ORDER BY c.Name



--6. City Statistics

SELECT c.Name,
	   COUNT(c.Id) AS Hotels
	FROM Cities c
	JOIN Hotels h ON c.Id = h.CityId
	GROUP BY c.Name
	ORDER BY Hotels DESC, c.Name



--7. Longest and Shortest Trips

SELECT AccountId,
		FullName,
		MAX(DaysCount) AS LongestTrip,
		MIN(DaysCount) AS ShortestTrip
	FROM
	(
		SELECT a.Id AS AccountId,
	   CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
	   DATEDIFF(DAY, tt.ArrivalDate, tt.ReturnDate) AS DaysCount
	FROM Accounts a
	JOIN AccountsTrips t ON a.Id = t.AccountId
	JOIN Trips tt ON t.TripId = tt.Id
		WHERE a.MiddleName IS NULL AND tt.CancelDate IS NULL
	) AS S
		GROUP BY AccountId, FullName
		ORDER BY LongestTrip DESC, ShortestTrip


--8. Metropolis

SELECT TOP(10) c.Id,
		c.Name AS City,
		c.CountryCode AS Country,
		COUNT(c.Id) AS Accounts
	FROM Cities c
	JOIN Accounts a ON c.Id = a.CityId
	GROUP BY c.Id, c.Name, c.CountryCode
	ORDER BY Accounts DESC


--9. Romantic Getaways

SELECT a.Id,
	   a.Email,
	   c.Name AS City,
	   COUNT(a.Id) AS Trips
	FROM Accounts a
	JOIN Cities c ON a.CityId = c.Id
	JOIN AccountsTrips atr ON a.Id = atr.AccountId
	JOIN Trips t ON atr.TripId = t.Id
	JOIN Rooms r ON t.RoomId = r.Id
	JOIN Hotels h ON r.HotelId = h.Id
	JOIN Cities cc ON h.CityId = cc.Id
		WHERE c.Name = cc.Name
		GROUP BY a.Id, a.Email, c.Name
		ORDER BY Trips DESC, a.Id



--10. GDPR Violation

SELECT *
	FROM Accounts a
	JOIN Cities c ON a.CityId = c.Id
	JOIN AccountsTrips atr ON a.Id = atr.AccountId
	JOIN Trips t ON atr.TripId = t.Id
	JOIN Rooms r ON t.RoomId = r.Id
	JOIN Hotels h ON r.HotelId = h.Id
	JOIN Cities cc ON h.CityId = cc.Id

SELECT t.Id,
	   CONCAT(a.FirstName, ' ', CASE WHEN a.MiddleName IS NULL THEN ''
								     ELSE a.MiddleName + ' ' END, a.LastName) AS [Full Name],
	   c.[Name] AS [From],
	   cc.[Name] AS [To],
	   CASE 
		 WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		 ELSE CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS VARCHAR) + ' days' END AS Duration  
	FROM Accounts a
	JOIN Cities c ON a.CityId = c.Id
	JOIN AccountsTrips atr ON a.Id = atr.AccountId
	JOIN Trips t ON atr.TripId = t.Id
	JOIN Rooms r ON t.RoomId = r.Id
	JOIN Hotels h ON r.HotelId = h.Id
	JOIN Cities cc ON h.CityId = cc.Id
		ORDER BY [Full Name], t.Id