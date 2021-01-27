USE SoftUni;


--1.	Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees
			WHERE Salary > 35000
END;

EXEC usp_GetEmployeesSalaryAbove35000;


--2.	Employees with Salary Above Number

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Salary DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees
			WHERE Salary >= @Salary
END

EXEC usp_GetEmployeesSalaryAboveNumber @Salary = 48100;


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



		