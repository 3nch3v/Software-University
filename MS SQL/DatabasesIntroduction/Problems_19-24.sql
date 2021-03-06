SELECT * FROM Towns
SELECT * FROM Departments 
SELECT * FROM Employees 


SELECT * FROM Towns
	ORDER BY [Name] ASC;
SELECT * FROM Departments 
	ORDER BY [Name] ASC;
SELECT * FROM Employees 
	ORDER BY Salary DESC;


SELECT [Name] FROM Towns
	ORDER BY [Name] ASC;
SELECT [Name] FROM Departments 
	ORDER BY [Name] ASC;
SELECT FirstName, LastName, JobTitle, Salary FROM Employees 
	ORDER BY Salary DESC;


UPDATE Employees
	SET Salary *= 1.10;
SELECT Salary FROM Employees;


UPDATE Payments 
	SET TaxRate *= 0.97;
SELECT TaxRate FROM Payments;


DELETE Occupancies;