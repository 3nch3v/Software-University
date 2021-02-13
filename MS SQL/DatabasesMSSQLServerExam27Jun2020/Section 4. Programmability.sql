--==============	Section 4. Programmability	==============================

--11.	Place Order

CREATE PROCEDURE usp_PlaceOrder (@JobId INT, @SerialNumber VARCHAR(50), @Qty INT)
AS
BEGIN TRANSACTION

	IF (SELECT FinishDate FROM Jobs WHERE JobId = @JobId) IS NOT NULL
		THROW 50011, 'This job is not active!', 1;
	ELSE IF @Qty <= 0
		THROW 50012, 'Part quantity must be more than zero!', 1;
	ELSE IF NOT EXISTS(SELECT JobId FROM Jobs WHERE JobId = @JobId)
		THROW 50013, 'Job not found!', 1;
	ELSE IF NOT EXISTS(SELECT SerialNumber FROM Parts WHERE SerialNumber = @SerialNumber)
		THROW 50014, 'Part not found!', 1;

	DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber);

	DECLARE @OrderId INT = (SELECT o.OrderId 
								FROM Orders o
								JOIN OrderParts op ON o.OrderId = op.OrderId
								WHERE PartId = @PartId AND JobId = @JobId);	

	IF @OrderId IS NOT NULL 
		AND (SELECT o.IssueDate 
				FROM Orders o
				JOIN OrderParts op ON o.OrderId = op.OrderId
				WHERE PartId = @PartId AND JobId = @JobId) IS NULL 
		BEGIN
			IF EXISTS(SELECT OrderId FROM OrderParts WHERE PartId = @PartId AND OrderId = @OrderId)
				BEGIN
				UPDATE OrderParts
					SET Quantity += @Qty
						WHERE PartId = @PartId AND OrderId = @OrderId
				END
			ELSE 
				BEGIN
				INSERT INTO OrderParts
					VALUES (@OrderId, @PartId, @Qty)
				END
		END

	ELSE 
		BEGIN
			INSERT INTO Orders
				VALUES (@JobId, NULL, 0)

			INSERT INTO OrderParts
				VALUES ((SELECT TOP(1) OrderId FROM Orders ORDER BY OrderId DESC) , @PartId, @Qty)
		END
COMMIT




--12.	Cost Of Order

CREATE FUNCTION udf_GetCost (@JobId INT)
RETURNS DECIMAL(18,2)
AS 
BEGIN
	DECLARE @Result DECIMAL(18,2) = (SELECT CASE
		WHEN Result IS NULL THEN 0
		ELSE Result END AS Result
	FROM
	(
		SELECT j.JobId AS Id,
			   SUM(oP.Quantity * p.Price) AS Result
			FROM Jobs j
			LEFT JOIN Orders o ON j.JobId = o.JobId
			LEFT JOIN OrderParts op ON o.OrderId = op.OrderId
			LEFT JOIN Parts p ON op.PartId = p.PartId
			GROUP BY j.JobId
	) t
	WHERE Id = @JobId)

	RETURN @Result
END