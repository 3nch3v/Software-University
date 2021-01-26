USE Gringotts;

SELECT *
	FROM WizzardDeposits

--1. Records’ Count

SELECT COUNT(Id) AS [Count]
	FROM WizzardDeposits

--2. Longest Magic Wand

SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits

--3. Longest Magic Wand Per Deposit Groups

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
		GROUP BY DepositGroup

--4. * Smallest Deposit Group Per Magic Wand Size

SELECT TOP(2) DepositGroup
	FROM WizzardDeposits
		GROUP BY DepositGroup
			ORDER BY AVG(MagicWandSize)

--5. Deposits Sum

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
		GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
		WHERE MagicWandCreator = 'Ollivander family'
			GROUP BY DepositGroup

--7. Deposits Filter
			 
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
		WHERE MagicWandCreator = 'Ollivander family'
			GROUP BY DepositGroup
				HAVING SUM(DepositAmount)< 150000
					ORDER BY TotalSum DESC

--8.  Deposit Charge

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
		GROUP BY DepositGroup, MagicWandCreator
		ORDER BY MagicWandCreator, DepositGroup

--9. Age Groups

SELECT AgeGroup, COUNT(AgeGroup) AS WizardCount
	FROM
		(
		SELECT 
			CASE
				WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
				WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
				WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
				WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
				WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
				WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
				ELSE '[61+]'
			END AS AgeGroup
		FROM WizzardDeposits
		) AS a
		GROUP BY AgeGroup


--10. First Letter

SELECT DISTINCT  LEFT(FirstName, 1) AS FirstLetter
	FROM WizzardDeposits
		WHERE DepositGroup = 'Troll Chest'
			GROUP BY FirstName
				ORDER BY FirstLetter


--11. Average Interest 

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
		WHERE DepositStartDate > '01/01/1985'
			GROUP BY DepositGroup, IsDepositExpired
				ORDER BY DepositGroup DESC, IsDepositExpired


--12. * Rich Wizard, Poor Wizard

SELECT SUM([Difference]) AS SumDifference
	FROM 
	(
		SELECT *, [Host Wizard Deposit] - [Guest Wizard Deposit] AS [Difference]
		FROM
		(
			SELECT Id,
			   FirstName AS [Host Wizard],
			   DepositAmount AS [Host Wizard Deposit],
			   LEAD(FirstName, 1) OVER (
				ORDER BY Id
				) AS [Guest Wizard],
			   LEAD(DepositAmount, 1) OVER (
				ORDER BY Id
				) AS [Guest Wizard Deposit]
			FROM 
				WizzardDeposits
		) AS a
	) AS a


--13. Departments Total Salaries
USE SoftUni;

SELECT DepartmentID, SUM(Salary) AS TotalSalary
	FROM Employees
		GROUP BY DepartmentID
			ORDER BY DepartmentID


--14. Employees Minimum Salaries

SELECT DepartmentID, MIN(Salary) AS MinimumSalary
	FROM Employees
		WHERE DepartmentID IN (2, 5 ,7) AND HireDate > '01/01/2000'
			GROUP BY DepartmentID
				ORDER BY DepartmentID


--15. Employees Average Salaries

SELECT *
	INTO #TEMP
	FROM Employees
		WHERE Salary > 30000

UPDATE #TEMP 
	SET SALARY += 5000
		WHERE DepartmentID = 1

DELETE FROM #TEMP WHERE ManagerID = 42;

SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM #TEMP
		GROUP BY DepartmentID


--16. Employees Maximum Salaries

SELECT DepartmentID, MaxSalary
	FROM
	(
	 SELECT DepartmentID, MAX(Salary) AS MaxSalary	
		FROM Employees
			GROUP BY DepartmentID
	) AS a
		WHERE MaxSalary < 30000 OR MaxSalary > 70000


--17. Employees Count Salaries

SELECT COUNT(EmployeeID) AS [Count]
	FROM Employees
		WHERE ManagerID IS NULL
	
	
--18. *3rd Highest Salary

SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary
	FROM
	(
		SELECT DepartmentID, 
			   Salary,
		       DENSE_RANK() OVER ( 
					PARTITION BY DepartmentID
					ORDER BY Salary DESC) AS SalaryRank
			FROM Employees	
	) AS a
		WHERE SalaryRank = 3


WITH SalaryRank 
	AS(SELECT DepartmentID,
              Salary,
              DENSE_RANK() OVER(
				PARTITION BY DepartmentID 
				ORDER BY Salary DESC) AS [Rank]
			FROM Employees)

SELECT DISTINCT DepartmentID,
				Salary AS ThirdHighestSalary
	FROM SalaryRank
		WHERE [Rank] = 3
		

--19. **Salary Challenge

SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
	FROM Employees e 
			WHERE Salary > (SELECT AVG(Salary)
							FROM Employees
							WHERE DepartmentID = e.DepartmentID
							GROUP BY DepartmentID)	
				ORDER BY DepartmentID;
