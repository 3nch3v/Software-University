--Section 4. Programmability
--11.	Get Colonists Count

CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT 
AS
BEGIN
	DECLARE @Count INT = (SELECT COUNT(c.Id) AS [Count]
							FROM Colonists c
							JOIN TravelCards t ON c.Id = t.ColonistId
							JOIN Journeys j ON t.JourneyId = j.Id
							JOIN Spaceports sp ON j.DestinationSpaceportId = sp.Id
							JOIN Planets p ON sp.PlanetId = p.Id
								WHERE p.Name = @PlanetName)
	RETURN @Count
END



--12.	Change Journey Purpose

CREATE PROCEDURE usp_ChangeJourneyPurpose (@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN

IF EXISTS (SELECT Id FROM Journeys WHERE Id = @JourneyId)
BEGIN

	IF (SELECT Purpose FROM Journeys WHERE Id = @JourneyId) = @NewPurpose
	THROW 50002, 'You cannot change the purpose!', 1;

	UPDATE Journeys
	SET Purpose = @NewPurpose
		WHERE Id = @JourneyId
END
ELSE 
	THROW 50001, 'The journey does not exist!', 1;
END


EXEC usp_ChangeJourneyPurpose 1, 'Technical'
SELECT Purpose FROM Journeys
ORDER BY Id





