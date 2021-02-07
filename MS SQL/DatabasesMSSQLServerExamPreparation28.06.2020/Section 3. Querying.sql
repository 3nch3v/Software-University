--Section 3. Querying 
--5.	Select all military journeys

SELECT ID, 
	   FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
	   FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
	FROM Journeys
	WHERE Purpose = 'Military'	
		ORDER BY JourneyStart

--6.	Select all pilots

SELECT c.Id,
	   CONCAT(FirstName, ' ', LastName) AS full_name	
	FROM Colonists c
		JOIN TravelCards tc ON c.Id = tc.ColonistId
		WHERE JobDuringJourney = 'Pilot'
		ORDER BY c.Id

--7.	Count colonists

SELECT COUNT(c.Id) AS [count]
	FROM Colonists c
	JOIN TravelCards tc ON c.Id = tc.ColonistId
	JOIN Journeys j ON tc.JourneyId = j.Id
		WHERE j.Purpose = 'technical'

--8.	Select spaceships with pilots younger than 30 years

SELECT s.Name,
	   s.Manufacturer
	FROM Colonists c
	JOIN TravelCards t ON c.Id = t.ColonistId
	JOIN Journeys j ON t.JourneyId = j.Id
	JOIN Spaceships s ON j.SpaceshipId = s.Id
	WHERE t.JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
	ORDER BY s.[Name]

--9.	Select all planets and their journey count

SELECT p.Name,
	   COUNT(p.Id) AS JourneysCount
	FROM Journeys j
	JOIN Spaceports s ON j.DestinationSpaceportId = s.Id
	JOIN Planets p ON s.PlanetId = p.Id
		GROUP BY p.Name
		ORDER BY JourneysCount DESC, p.Name

--10.	Select Second Oldest Important Colonist

SELECT *
	FROM
	(
		SELECT t.JobDuringJourney,
	   CONCAT(c.FirstName, ' ', c.LastName ) AS FullName,
	   DENSE_RANK () OVER (PARTITION BY t.JoBDuringJourney  ORDER BY c.BirthDate ) AS JobRank
	FROM Colonists c
	JOIN TravelCards t ON c.Id = t.ColonistId
	) AS tt
	WHERE JobRank = 2