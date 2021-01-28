USE SoftUni;

--1.	Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees
			WHERE Salary > 35000
END;


--2.	Employees with Salary Above Number

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Salary DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees
			WHERE Salary >= @Salary
END


--3.	Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith @StartingLater VARCHAR(50) 
AS
BEGIN
	DECLARE @Lenght INT = LEN(@StartingLater)
	SELECT [Name]
		FROM Towns
				WHERE LEFT([Name], @Lenght) = @StartingLater
END;



--4.	Employees from Town

CREATE PROCEDURE usp_GetEmployeesFromTown @Town VARCHAR(50) 
AS 
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON t.TownID = a.TownID
			WHERE t.[Name] = @Town
END


--5.	Salary Level Function

CREATE FUNCTION  ufn_GetSalaryLevel (@salary DECIMAL(18,4)) 
	RETURNS VARCHAR(50)
AS
BEGIN
	RETURN
		CASE 
			WHEN @salary < 30000 THEN 'Low'
			WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
			WHEN @salary > 50000 THEN 'High'
		END
END


--6.	Employees by Salary Level

CREATE PROCEDURE usp_EmployeesBySalaryLevel @Level VARCHAR(10)
AS 
BEGIN
	SELECT FirstName, LastName
		FROM
		(
			SELECT FirstName, 
				   LastName,
			       [dbo].[ufn_GetSalaryLevel](Salary) AS [LEVEL]
			FROM Employees		
		) AS a
		WHERE [LEVEL] = @Level
END


--7.	Define Function

CREATE FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
     DECLARE @Counter INT = 1;
     DECLARE @CurrChar CHAR;

     WHILE (@Counter <= LEN(@word))
     BEGIN
          SET @CurrChar = SUBSTRING(@word, @Counter, 1);

          IF (CHARINDEX(@CurrChar, @setOfLetters) > 0)
             SET @Counter += 1;
          ELSE
             RETURN 0;
     END
     RETURN 1;
END


--8.	* Delete Employees and Departments



--09. Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName)
		FROM AccountHolders
END



--10.	People with Balance Higher Than

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Money MONEY)
AS
BEGIN
	SELECT FirstName, LastName
		FROM
		(
			SELECT DISTINCT h.FirstName, 
							h.LastName, 
							SUM(a.Balance) AS Balance
			FROM AccountHolders h
				JOIN Accounts a ON h.Id = a.AccountHolderId
				GROUP BY h.FirstName, h.LastName
		) AS A
		WHERE Balance > @Money
			ORDER BY FirstName, LastName
END



--11.	Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @YearlyInterest FLOAT, @Years INT)
RETURNS MONEY
AS
BEGIN
	RETURN @sum * POWER(1 + @YearlyInterest, @Years)
END;


--12.	Calculating Interest

CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT)
AS
BEGIN
	SELECT a.Id AS [Account Id], 
	   h.FirstName AS [First Name], 
       h.LastName AS [Last Name], 
	   a.Balance AS [Current Balance],
	   [dbo].[ufn_CalculateFutureValue](a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders h
		JOIN Accounts a ON h.Id = a.AccountHolderId
			WHERE a.Id = @AccountId
END
