--==================	Section 2. DML	===============================
--2.	Insert

INSERT INTO Clients
	VALUES  ('Teri', 'Ennaco', '570-889-5187'),
			('Merlyn', 'Lawler', '201-588-7810'),
			('Georgene', 'Montezuma', '925-615-5185'),
			('Jettie', 'Mconnell', '908-802-3564'),
			('Lemuel', 'Latzke', '631-748-6479'),
			('Melodie', 'Knipp', '805-690-1682'),
			('Candida', 'Corbley', '908-275-8357')
			
INSERT INTO Parts
	VALUES  ('WP8182119', 'Door Boot Seal', 117.86, 2, NULL), 
			('W10780048', 'Suspension Rod', 42.81, 1, NULL), 
			('W10841140', 'Silicone Adhesive', 6.77, 4, NULL), 
			('WPY055980', 'High Temperature Adhesive', 13.94, 3, NULL)

--3.	Update

UPDATE Jobs
	SET MechanicId = 3
	WHERE Status = 'Pending'

UPDATE Jobs
	SET Status = 'In Progress'
	WHERE MechanicId = 3 AND Status = 'Pending'

--4.	Delete

SELECT *
	FROM Orders
	WHERE OrderId = 19;

DELETE OrderParts
	WHERE OrderId = 19

DELETE ORDERS
	WHERE OrderId = 19