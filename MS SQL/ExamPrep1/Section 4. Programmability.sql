--============	Section 4. Programmability	=========================

--11.	Vacation

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @Result VARCHAR(MAX)

	IF @peopleCount <= 0
	BEGIN
		SET @Result = 'Invalid people count!'
		RETURN @Result
	END

	IF (SELECT Origin FROM Flights f JOIN Tickets t ON f.Id = t.FlightId WHERE Origin = @origin) = @origin
		AND (SELECT Destination FROM Flights f JOIN Tickets t ON f.Id = t.FlightId WHERE Destination =	@destination) = @destination
	BEGIN	

		DECLARE @TicketsPrice DECIMAL(18,2) 
			= (SELECT Price 
					FROM Flights f
					JOIN Tickets t ON f.Id = t.FlightId
					WHERE Origin = @origin AND Destination = @destination) 
			 * @peopleCount;

		SET @Result = 'Total price ' + CAST(@TicketsPrice AS VARCHAR(MAX))
		RETURN @Result
	END

	SET @Result =  'Invalid flight!'
	RETURN @Result
END


--12.	Wrong Data

CREATE PROC usp_CancelFlights
AS
UPDATE Flights
	SET DepartureTime = NULL, 
		ArrivalTime = NULL
	WHERE ArrivalTime > DepartureTime
