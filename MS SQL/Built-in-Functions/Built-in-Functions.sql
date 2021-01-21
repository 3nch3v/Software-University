USE SoftUni;

--Problem 1.	Find Names of All Employees by First Name

SELECT FirstName, LastName 
	FROM Employees
		WHERE FirstName LIKE 'SA%';

--Problem 2.	  Find Names of All employees by Last Name 

SELECT FirstName, LastName 
	FROM Employees
		WHERE LastName LIKE '%ei%';

--Problem 3.	Find First Names of All Employees

SELECT FirstName
	FROM Employees
		WHERE DepartmentID IN (3, 10) 
		  AND HireDate BETWEEN '1995-01-01' AND '2005-12-31';

--Problem 4.	Find All Employees Except Engineers

SELECT FirstName, LastName, JobTitle
	FROM Employees
		WHERE NOT (JobTitle LIKE '%engineer%');

--Problem 5.	Find Towns with Name Length

SELECT [Name]
	FROM Towns
		WHERE LEN([Name]) BETWEEN 5 AND 6
			ORDER BY [Name];

--Problem 6.	 Find Towns Starting With

SELECT *
	FROM Towns
		WHERE [Name] LIKE '[MKBE]%'
			ORDER BY [Name]

--Problem 7.	 Find Towns Not Starting With

SELECT *
	FROM Towns
		WHERE NOT ([Name] LIKE '[RBD]%')
			ORDER BY [Name]


--Problem 8.	Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName, HireDate
		FROM Employees
			WHERE HireDate > '2000-12-31'

--Problem 9.	Length of Last Name

SELECT FirstName, LastName
	FROM Employees
		WHERE LEN(LastName) = 5

--10. Rank Employees by Salary

SELECT EmployeeID, 
	   FirstName, 
	   LastName, 
	   Salary,
	   DENSE_RANK () OVER (
				PARTITION BY Salary
				ORDER BY EmployeeID
	   ) [Rank]
FROM
	Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC;

--Problem 11.	Find All Employees with Rank 2 *

WITH TAKERANK2 AS
(
SELECT EmployeeID, 
	   FirstName, 
	   LastName, 
	   Salary,
	   DENSE_RANK () OVER (
				PARTITION BY Salary
				ORDER BY EmployeeID
	   ) [Rank]
FROM
	Employees
		WHERE Salary BETWEEN 10000 AND 50000

)

SELECT * 
	FROM TAKERANK2
		WHERE [Rank] = 2
			ORDER BY Salary DESC;

--Problem 12.	Countries Holding ‘A’ 3 or More Times

USE Geography;

SELECT CountryName, IsoCode
	FROM Countries
	WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A', '')) >= 3
	ORDER BY IsoCode;

--Problem 13.	 Mix of Peak and River Names

SELECT PeakName, Rivers.RiverName, LOWER(CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName) -1))) AS Mix
	FROM Peaks
	JOIN Rivers ON RIGHT(Peaks.PeakName, 1) = LEFT(Rivers.RiverName, 1)
	ORDER BY Mix;

--Problem 14.	Games from 2011 and 2012 year

USE Diablo;

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE [Start] BETWEEN '2011-01-01' AND '2012-12-31'
	ORDER BY [Start], [Name]

--Problem 15.	 User Email Providers

SELECT Username, RIGHT(Email,LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
	FROM Users
		ORDER BY [Email Provider], Username

--Problem 16.	 Get Users with IPAdress Like Pattern

USE Diablo;

SELECT Username, IpAddress
	FROM Users
	 WHERE IpAddress LIKE '[0-9][0-9][0-9].1[0-9]%.[0-9]%.[0-9][0-9][0-9]'
		ORDER BY Username

--Problem 17.	 Show All Games with Duration and Part of the Day

SELECT [Name] AS Game,
	    CASE
		 WHEN CAST([Start] AS TIME) BETWEEN '0:00' AND '11:59' THEN 'Morning'
		 WHEN CAST([Start] AS TIME) BETWEEN '12:00' AND '17:59' THEN 'Afternoon'
		 WHEN CAST([Start] AS TIME) BETWEEN '18:00' AND '23:59' THEN 'Evening'
		END AS [Part of the Day], 
	   CASE
		 WHEN Duration <= 3 THEN 'Extra Short'
		 WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		 WHEN Duration > 6 THEN 'Long'
		 WHEN Duration IS NULL THEN 'Extra Long'
		END AS Duration
	FROM Games
		ORDER BY [Name], Duration, [Part of the Day]

--Problem 18.	Orders Table
