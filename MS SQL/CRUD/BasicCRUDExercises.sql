USE SoftUni

SELECT * FROM Departments;

SELECT [Name] FROM Departments;

SELECT FirstName, LastName, Salary 
	FROM Employees;

SELECT FirstName, MiddleName, LastName 
	FROM Employees;

SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
	FROM Employees;

SELECT DISTINCT Salary FROM Employees;

SELECT * FROM Employees
	WHERE JobTitle = 'Sales Representative';
	
SELECT FirstName, LastName, JobTitle FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000;

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS 'Full Name' 
	FROM Employees
	WHERE Salary IN (25000, 14000, 12500,23600);

SELECT FirstName, LastName
	FROM Employees
	WHERE ManagerID IS NULL;

SELECT FirstName, LastName, Salary
	FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC;
	

SELECT TOP(5) FirstName, LastName
	FROM Employees
	ORDER BY Salary DESC

SELECT FirstName, LastName
	FROM Employees
	WHERE DepartmentID != 4;


SELECT *
	FROM Employees
	ORDER BY Salary DESC, 
			FirstName, 
			LastName DESC, 
			MiddleName;

CREATE VIEW V_EmployeesSalaries AS
	SELECT FirstName, LastName, Salary
		FROM Employees;

SELECT * FROM V_EmployeesSalaries;

CREATE VIEW V_EmployeeNameJobTitle  AS 
	SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], JobTitle
		FROM Employees;

SELECT DISTINCT JobTitle
	FROM Employees;

SELECT TOP(10) *
	FROM Projects
	ORDER BY StartDate, [Name];

SELECT TOP(7) FirstName, LastName, HireDate
	FROM Employees
	ORDER BY HireDate DESC;

SELECT * FROM Employees;
SELECT * FROM Departments;


UPDATE Employees
	SET Salary *= 1.12
	WHERE DepartmentID IN (1, 2, 4, 11);


UPDATE Employees
	SET Salary *= 1.12
	JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
	WHERE Departments.[Name] IN ('Engineering','Tool Design', 'Marketing', 'Information Services');

UPDATE Employees
	SET Salary *= 1.12
	FROM Employees
		JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
    WHERE Departments.[Name] IN ('Engineering','Tool Design', 'Marketing', 'Information Services');

SELECT Salary FROM Employees;



USE Geography;

SELECT PeakName FROM Peaks
	ORDER BY PeakName ASC;

SELECT TOP(30) CountryName, [Population]
	FROM Countries
	WHERE ContinentCode = 'EU'
		ORDER BY [Population] DESC;

SELECT CountryName, 
	   CountryCode, 
	   CASE 
		  WHEN CurrencyCode = 'EUR' THEN 'Euro'
		  ELSE'Not Euro'
	   END AS Currency
	FROM Countries
	ORDER BY CountryName ASC;



USE Diablo;

SELECT [Name]
	FROM Characters
	ORDER BY [Name] ASC;
