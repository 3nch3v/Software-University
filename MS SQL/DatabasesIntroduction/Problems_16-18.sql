CREATE DATABASE SoftUni;

USE SoftUni;

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL
);

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(100),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
);

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL
);


CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	MiddleName NVARCHAR(100),
	LastName NVARCHAR(100) NOT NULL,
	JobTitle NVARCHAR(100) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME2 NOT NULL,
	Salary DECIMAL NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
);

INSERT INTO Towns
	VALUES ('Sofia'),
		   ('Plovdiv'),
		   ('Varna'),
		   ('Burgas');

INSERT INTO Departments
	VALUES ('Engineering'),
		   ('Sales'),
		   ('Marketing'),
		   ('Software Development'),
		   ('Quality Assurance');

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
	VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00, NULL),
		   ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1,'03/02/2004', 4000.00, NULL),
		   ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25, NULL),
		   ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00, NULL),
	       ('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88, NULL);

		