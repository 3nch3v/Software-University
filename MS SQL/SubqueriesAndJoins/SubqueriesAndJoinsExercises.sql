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

SELECT TOP(5) EmployeeID, FirstName, Salary, d.[Name] AS DepartmentName
	FROM Employees e
		JOIN Departments d ON e.DepartmentID = d.DepartmentID 
			WHERE Salary > 15000
				ORDER BY e.DepartmentID;

--5.	Employees Without Project

SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees e
	    LEFT OUTER JOIN  EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		LEFT OUTER JOIN Projects p ON ep.ProjectID = p.ProjectID
			WHERE p.ProjectID IS NULL	 	
				ORDER BY e.EmployeeID

--6.	Employees Hired After

SELECT FirstName, LastName, HireDate, d.[Name] AS DeptName
	FROM Employees e
		JOIN Departments d ON e.DepartmentID = d.DepartmentID
			WHERE HireDate > '1.1.1999' AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
				ORDER BY e.HireDate

--7.	Employees with Project

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
	FROM Employees e
		JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects p ON ep.ProjectID = p.ProjectID
			WHERE StartDate > '2002-08-13 00:00:00' AND EndDate IS NULL
			ORDER BY e.EmployeeID

--8.	Employee 24

SELECT e.EmployeeID, 
	   e.FirstName, 
		CASE 
			WHEN p.StartDate > '2005-01-01 00:00:00' THEN nULL
			ELSE p.[Name]
		END AS ProjectName
	FROM Employees e
		JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects p ON ep.ProjectID = p.ProjectID
			WHERE e.EmployeeID = 24 

--9.	Employee Manager

SELECT e.EmployeeID, e.FirstName, e.ManagerID, ee.FirstName AS  ManagerName
	FROM Employees e
		 JOIN Employees ee ON e.ManagerID = ee.EmployeeID 
			WHERE e.ManagerID IN (3, 7)
				ORDER BY e.EmployeeID

--10. Employee Summary

SELECT TOP(50) e.EmployeeID, 
			   CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName,
			   CONCAT_WS(' ', ee.FirstName, ee.LastName) AS ManagerName,
			   D.[Name] AS DepartmentName
	FROM Employees e
		 JOIN Employees ee ON e.ManagerID = ee.EmployeeID 
		 JOIN Departments d ON e.DepartmentID = d.DepartmentID
				ORDER BY e.EmployeeID

--11. Min Average Salary

SELECT MIN(a.AverageSalary) AS MinAverageSalary
	FROM 
  (
		SELECT DepartmentID, 
			   AVG(Salary) AS AverageSalary
			FROM Employees
			GROUP BY DepartmentID
  ) AS a


--12. Highest Peaks in Bulgaria

USE Geography;

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks p
		JOIN Mountains m ON m.Id = p.MountainId 
		JOIN MountainsCountries mc ON mc.MountainId = p.MountainId 
	WHERE Elevation > 2835 AND mc.CountryCode = 'BG'
	ORDER BY Elevation DESC

--13. Count Mountain Ranges

SELECT mc.CountryCode, COUNT(CountryCode) AS MountainRanges 
	FROM Mountains m
		JOIN MountainsCountries mc ON m.Id = mc.MountainId
		WHERE mc.CountryCode IN ('BG', 'RU', 'US')
		GROUP BY mc.CountryCode

--14. Countries with Rivers

SELECT TOP(5) CountryName, RiverName
	FROM Countries c
		JOIN Continents co ON co.ContinentCode = c.ContinentCode
		LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
		LEFT JOIN Rivers r ON r.Id = cr.RiverId
			WHERE ContinentName = 'Africa'
				ORDER BY CountryName

--15. *Continents and Currencies

SELECT ContinentCode, CurrencyCode, CurrencyUsage
	FROM
		(
			SELECT ContinentCode, 
			CurrencyCode,
			CurrencyUsage,
			ROW_NUMBER() OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS rn,
			DENSE_RANK () OVER ( PARTITION BY ContinentCode
						ORDER BY CurrencyUsage  DESC
						 ) rank_no 
	  
			FROM
			(
			SELECT c.ContinentCode, cc.CurrencyCode, COUNT(cc.CurrencyCode) AS CurrencyUsage
				FROM Continents c
					JOIN Countries cc ON c.ContinentCode = cc.ContinentCode
				GROUP BY c.ContinentCode, cc.CurrencyCode

		) AS a 
		) AS a
	WHERE rank_no  = 1 AND CurrencyUsage > 1
	ORDER BY ContinentCode, CurrencyUsage DESC

--16. Countries Without Any Mountains

SELECT COUNT(c.CountryCode) AS [Count]
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
		WHERE MountainId IS NULL

--17. Highest Peak and Longest River by Country

SELECT TOP(5) CountryName, HighestPeakElevation, LongestRiverLength
	FROM
(
	SELECT c.CountryName, 
			Elevation AS HighestPeakElevation, 
			r.[Length] AS LongestRiverLength,
			ROW_NUMBER() OVER(PARTITION BY c.CountryName ORDER BY Elevation DESC) rn
	FROM Countries c
		 JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	  	 JOIN Peaks p ON p.MountainId = mc.MountainId
		 JOIN CountriesRivers rc ON rc.CountryCode = c.CountryCode
	  	 JOIN Rivers r ON r.Id = rc.RiverId
			
) AS a
	WHERE rn =1
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

--18. Highest Peak Name and Elevation by Country

SELECT TOP(5) Country, [Highest Peak Name], [Highest Peak Elevation], Mountain
	FROM
	(
		SELECT c.CountryName AS Country,
	   CASE
		WHEN p.PeakName IS NULL THEN '(no highest peak)'
	    ELSE p.PeakName 
	   END AS [Highest Peak Name],

	   CASE
		WHEN p.Elevation IS NULL THEN 0
	    ELSE p.Elevation 
	   END AS [Highest Peak Elevation],

	   CASE
		WHEN m.MountainRange IS NULL THEN '(no mountain)'
	    ELSE m.MountainRange 
	   END AS Mountain,
	   ROW_NUMBER() OVER(PARTITION BY c.CountryName ORDER BY Elevation DESC) rn
	FROM Countries c
		LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Peaks p ON mc.MountainId = p.MountainId
		LEFT JOIN Mountains m ON p.MountainId = m.Id
			
	) AS A
		WHERE rn = 1
		ORDER BY Country, [Highest Peak Elevation] DESC, [Highest Peak Name]