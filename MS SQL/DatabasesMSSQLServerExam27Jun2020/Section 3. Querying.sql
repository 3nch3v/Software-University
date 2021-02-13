--=================	Section 3. Querying	======================
--5.	Mechanic Assignments

SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
	   j.Status,
	   j.IssueDate
	FROM Mechanics m
	JOIN Jobs j ON m.MechanicId = j.MechanicId
	ORDER BY m.MechanicId, j.IssueDate, j.JobId


--6.	Current Clients

SELECT c.FirstName + ' ' + c.LastName AS Client,
		DATEDIFF(DAY , j.IssueDate, '2017-04-24') AS [Days going],
		Status
	FROM Clients c
	JOIN Jobs j ON c.ClientId = j.ClientId
	WHERE Status <> 'Finished'
	ORDER BY [Days going] DESC, c.ClientId


--7.	Mechanic Performance

SELECT  m.FirstName + ' ' + m.LastName AS Mechanic,
		AVG(DATEDIFF(DAY , j.IssueDate, j.FinishDate))
	FROM Mechanics m
	JOIN Jobs j ON m.MechanicId = j.MechanicId
	WHERE FinishDate IS NOT NULL
	GROUP BY m.MechanicId, m.FirstName, m.LastName
	ORDER BY m.MechanicId


--8.	Available Mechanics

DECLARE @NotAvailableM TABLE (Id INT)

INSERT INTO @NotAvailableM
	SELECT MechanicId
		FROM Jobs
		WHERE [Status] <> 'Finished' AND MechanicId IS NOT NULL
		GROUP BY MechanicId
		
		
SELECT Available
	FROM
	(
	SELECT DISTINCT m.FirstName + ' ' + m.LastName AS Available,
		   m.MechanicId
	FROM Mechanics m
	LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId
		WHERE j.Status IS NULL OR m.MechanicId NOT IN (SELECT Id FROM @NotAvailableM )
		
	) t
	ORDER BY MechanicId


-- 9.	Past Expenses

SELECT JobId,
		CASE 
			WHEN Total IS NULL THEN 0.00
			ELSE Total END AS Total
	FROM
	(
		SELECT JobId,
		SUM(Total) AS Total
	FROM
	(
		SELECT j.JobId,
			   (op.Quantity * p.Price)  AS Total
			FROM Jobs j
			LEFT JOIN Orders o ON j.JobId = o.JobId
			LEFT JOIN OrderParts op ON o.OrderId = op.OrderId
			LEFT JOIN Parts p ON op.PartId = p.PartId
			WHERE FinishDate IS NOT NULL		
	) S
GROUP BY JobId
	) A
	ORDER BY Total DESC, JobId


--10.	Missing Parts

DECLARE @IncomingsParts TABLE (Id INT, Qty INT) 
INSERT INTO @IncomingsParts
	SELECT op.PartId,
		   op.Quantity
	FROM Orders o
	JOIN OrderParts op ON o.OrderId = op.OrderId
	WHERE Delivered = 0

SELECT *
	FROM
	(
		SELECT pn.PartId,
			   p.Description,
			   pn.Quantity AS Required,
			   p.StockQty AS [In Stock],
			   CASE 
				 WHEN pn.PartId IN (SELECT Id FROM @IncomingsParts) THEN (SELECT Qty FROM @IncomingsParts WHERE Id = pn.PartId)
				 ELSE 0 END
				 AS Ordered
			FROM Jobs j
			JOIN PartsNeeded pn ON J.JobId = pn.JobId
			JOIN Parts p ON pn.PartId = p.PartId
			WHERE j.FinishDate IS NULL AND pn.Quantity > p.StockQty
	
	) t
	WHERE Required >  [In Stock] + Ordered
	ORDER BY PartId