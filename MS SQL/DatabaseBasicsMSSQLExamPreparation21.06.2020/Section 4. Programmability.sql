
--====================	Section 4. Programmability	====================================================


--11. Available Room

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(200)
AS 
BEGIN 
	DECLARE @msg VARCHAR(200);

    DECLARE @RoomsBooked TABLE (Id INT)

    INSERT INTO @RoomsBooked
        SELECT DISTINCT r.Id 
			FROM Rooms r
			LEFT JOIN Trips t ON t.RoomId = r.Id
				 WHERE r.HotelId = @HotelId 
						AND @Date BETWEEN t.ArrivalDate AND t.ReturnDate 
						AND t.CancelDate IS NULL
 
    DECLARE @FreeRooms TABLE (Id INT, Price MONEY, [Type] VARCHAR(20), Beds INT, TotalPrice MONEY)

    INSERT INTO @FreeRooms
        SELECT TOP(1) r.Id, 
					  r.Price, 
					  r.[Type], 
					  r.Beds, 
					  (h.BaseRate + r.Price) * @People AS TotalPrice
			FROM Rooms r
			LEFT JOIN Hotels h ON r.HotelId = h.Id
				WHERE r.HotelId = @HotelId 
					  AND r.Beds >= @People 
					  AND r.Id NOT IN (SELECT Id FROM @RoomsBooked)
				ORDER BY TotalPrice DESC
 
    DECLARE @AvailableRooms INT = (SELECT COUNT(*)  FROM @FreeRooms)
    IF (@AvailableRooms < 1)
        BEGIN
            SET @msg = 'No rooms available'
			RETURN @msg
        END
															
    SET @msg = (SELECT CONCAT('Room ', Id, ': ', [Type],' (', Beds, ' beds) - $', TotalPrice) FROM @FreeRooms)
    RETURN @msg
END



--12. Switch Room

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TripInfo TABLE (Id INT, RoomId INT, Beds INT, HotelId INT)

	INSERT INTO @TripInfo
		SELECT t.Id,
			   t.RoomId,
			   r.Beds,
			   r.HotelId
		FROM Trips t
		JOIN Rooms r ON t.RoomId = r.Id
			WHERE t.Id = @TripId
	
	DECLARE @Persons INT = (SELECT COUNT(*)
								FROM Accounts a
								JOIN AccountsTrips atr ON a.Id = atr.AccountId
								JOIN Trips t ON atr.TripId = t.Id
									WHERE t.Id = @TripId)

	IF @TargetRoomId NOT IN (SELECT Id 
					FROM Rooms
					WHERE HotelId = (SELECT HotelId FROM @TripInfo))
		 THROW 50001, 'Target room is in another hotel!', 1;
	
	IF @Persons > (SELECT Beds 
					 FROM Rooms
						WHERE HotelId = (SELECT HotelId FROM @TripInfo) AND Id = @TargetRoomId)
		 THROW 50002, 'Not enough beds in target room!', 1;
	
	UPDATE Trips
		SET RoomId = @TargetRoomId
			WHERE Id = @TripId