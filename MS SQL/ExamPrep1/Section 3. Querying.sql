--===============	Section 3. Querying		===============================

--5.	The "Tr" Planes
SELECT * 
	FROM Planes
	WHERE Name LIKE '%TR%'
	ORDER BY Id, Name, Seats, Range


--6.	Flight Profits

SELECT FlightId,
	   SUM(Price) AS Price
	FROM Tickets
	GROUP BY FlightId
	ORDER BY Price DESC, FlightId


--7.	Passenger Trips

SELECT CONCAT(p.FirstName, ' ', LastName) AS [Full Name],
	   f.Origin,
	   f.Destination
	FROM Passengers p
	JOIN Tickets t ON p.Id = t.PassengerId
	JOIN Flights f ON t.FlightId = f.Id
	ORDER BY [Full Name], f.Origin, f.Destination


--8.	Non Adventures People

SELECT p.FirstName,
	   p.LastName,
	   p.Age
	FROM Passengers p
	LEFT JOIN Tickets t ON p.Id = t.PassengerId
	WHERE t.Id IS NULL
	ORDER BY p.Age DESC, p.FirstName, p.LastName



--9.	Full Info

SELECT CONCAT(p.FirstName, ' ', LastName) AS [Full Name],
		pl.Name AS [Plane Name],
		CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
		lt.Type AS [Luggage Type]
	FROM Passengers p
	JOIN Tickets t ON p.Id = t.PassengerId
	JOIN Flights f ON t.FlightId = f.Id
	JOIN Planes pl ON f.PlaneId = pl.Id
	LEFT JOIN Luggages l ON t.LuggageId = l.Id
	LEFT JOIN LuggageTypes lt ON l.LuggageTypeId = lt.Id
		ORDER BY [Full Name], pl.Name, f.Origin, f.Destination, [Luggage Type]


--10.	PSP

SELECT p.Name,
	   p.Seats,
	   COUNT(t.PassengerId) AS [Passengers Count]
	FROM Planes p
	LEFT JOIN Flights f ON p.Id = f.PlaneId
	LEFT JOIN Tickets T ON f.Id = t.FlightId
	GROUP BY p.Id, p.Name, p.Seats
		ORDER BY [Passengers Count] DESC, p.Name, p.Seats