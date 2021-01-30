
--16. Deposit Money

CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY) 
AS
BEGIN
	IF @MoneyAmount > 0
	BEGIN
		UPDATE Accounts
		SET Balance += @MoneyAmount
			WHERE Id = @AccountId
	END
END;


--17.	Withdraw Money

CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY) 
AS
BEGIN
	IF @MoneyAmount > 0
	BEGIN
		UPDATE Accounts
			SET Balance -= @MoneyAmount
				WHERE Id = @AccountId
	END
END;

--18. Money Transfer

CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN 
		IF	@Amount > 0
		BEGIN
			EXECUTE usp_DepositMoney @ReceiverId, @Amount
			EXECUTE usp_WithdrawMoney @SenderId, @Amount
		END
END;


--20. *Massive Shopping

/*SELECT * 
	FROM Users u
	JOIN UsersGames ug ON u.Id = ug.UserId
	JOIN Games g ON ug.GameId = g.Id
	JOIN UserGameItems ugi ON ug.UserId = ugi.UserGameId
	JOIN Items i ON ugi.ItemId = i.Id
		WHERE u.FirstName = 'Stamat' AND g.[Name] = 'Safflower'
*/

--21. Employees with Three Projects

CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
	IF	(SELECT COUNT(ProjectID)
				FROM EmployeesProjects
				WHERE EmployeeID = @emloyeeId
				GROUP BY EmployeeID) >= 3
		BEGIN 
			RAISERROR('The employee has too many projects!', 16 , 1)			
		END
	ELSE
		BEGIN
			INSERT INTO EmployeesProjects
			VALUES (@emloyeeId, @projectID)
		END			
END;


--22. Delete Employees

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY, 
	FirstName VARCHAR(50),  
	LastName VARCHAR(50), 
	MiddleName VARCHAR(50), 
	JobTitle VARCHAR(50), 
	DepartmentId INT, 
	Salary MONEY
) 

CREATE TRIGGER tr_FiredEmployees 
	ON Employees
	AFTER DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees
		(
		FirstName, 
		LastName, 
		MiddleName, 
		JobTitle, 
		DepartmentId, 
		Salary
		)
		SELECT 
			FirstName,
			LastName,
			MiddleName,
			JobTitle,
			DepartmentID,
			Salary
		FROM deleted;	
END

