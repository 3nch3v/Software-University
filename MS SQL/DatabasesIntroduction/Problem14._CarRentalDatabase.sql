/*
Problem 14.	Car Rental Database
Using SQL queries create CarRental database with the following entities:
•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
•	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
Set most appropriate data types for each column. Set primary key to each table. Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.
*/

CREATE DATABASE CarRental;
USE CarRental;

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL NOT NULL,
	WeeklyRate DECIMAL NOT NULL,
	MonthlyRate DECIMAL NOT NULL,
	WeekendRate DECIMAL NOT NULL
);

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
	VALUES ('A', 10, 60, 200, 25),
		   ('B', 11, 61, 201, 26),
		   ('C', 12, 62, 202, 27);

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(8) NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(50),
	Available BIT NOT NULL
);

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
	VALUES ('CT2020BA', 'McLaren', 'F1', '2020-01-01', 1, 2, 1),
		   ('CO1224AA', 'Ferarri', 'Enzo', '1987-05-12', 2, NULL, 0),
		   ('BA2020CF', 'Opek', 'Vectra', '2011-11-30', 3, 5, 1);

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(50),
);

INSERT INTO Employees (FirstName, LastName, Title)
	VALUES ('Bobo', 'Bob', 'Manager'),
		   ('Ivan', 'Enchev', 'WH'),
		   ('It', 'Ity', 'BigBoss');

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(50),
);


INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode)
	VALUES (12312313, 'Bob Arn', '101 Street', 'NY', 209303),
		   (342435335, 'Miro Miro', 'ruppert-Mayer-Str. 44', 'Munich', 81795),
		   (657878879, 'Muster Mann', 'Str.', '22', 10000);


CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel DECIMAL NOT NULL,
	KilometrageStart DECIMAL NOT NULL,
	KilometrageEnd DECIMAL NOT NULL,
	TotalKilometrage DECIMAL NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL NOT NULL,
	TaxRate DECIMAL NOT NULL,
	OrderStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus)
	VALUES (1, 1, 3, 45.5, 0, 100, 100, '2020-01-01', '2020-01-03', 2, 20, 2.5, 'done'),
		   (2, 2, 1, 60, 100, 200, 200, '2020-01-01', '2020-01-03', 2, 20, 2.5, 'done'),
		   (3, 3, 2, 50, 200, 300, 300, '2020-01-01', '2020-01-03', 2, 20, 2.5, 'done');

