USE SoftUni; 

--1.	Employee Address

SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY AddressID

--2.	Addresses with Towns

SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS Town, A.AddressText
	FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns AS t ON a.TownID = t.TownID
			ORDER BY FirstName, LastName

--3.	Sales Employee

SELECT EmployeeID, FirstName, LastName, d.[Name] AS DepartmentName
	FROM Employees e
		JOIN Departments d ON e.DepartmentID = d.DepartmentID 
			WHERE d.[Name] = 'Sales'
				ORDER BY EmployeeID

--4.	Employee Departments



