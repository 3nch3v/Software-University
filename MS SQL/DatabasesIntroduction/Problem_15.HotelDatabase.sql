CREATE DATABASE Hotel 

USE Hotel 

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO Employees (FirstName, LastName, Title)
	VALUES ('A', 'B', 'C'),
		   ('E', 'R', 'T'),
	       ('O', 'N', 'Y');


CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	PhoneNumber INT,
	EmergencyName VARCHAR(50),
	EmergencyNumber INT,
	Notes VARCHAR(MAX)
);

INSERT INTO Customers (AccountNumber, FirstName, LastName)
	VALUES (1, '1', '2'),
		   (2, '3', '4'),
	       (3, '5', '6');

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(50) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus)
	VALUES ('FREE'),
	       ('CLOSED'),
	       ('BUSY');
	       
CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(50) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType)
	VALUES ('SIGLE'),
	       ('DOUBLE'),
	       ('TRIPLE');

CREATE TABLE BedTypes
(
	BedType NVARCHAR(50) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes (BedType)
	VALUES ('SINGLEBED'),
	       ('DOUBLEBED'),
	       ('SPECIALBED');

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL NOT NULL,
	RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
	VALUES (213, 'SIGLE', 'SINGLEBED', 20, 'FREE'),
		   (333, 'SIGLE', 'SINGLEBED', 20, 'FREE'),
		   (444, 'SIGLE', 'SINGLEBED', 20, 'FREE');

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(18,2) NOT NULL,
	TaxRate DECIMAL(18,2) NOT NULL,
	TaxAmount DECIMAL(18,2) NOT NULL,
	PaymentTotal DECIMAL(18,2) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber,FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
	VALUES (1, GETDATE(), 1, '2020-01-01', '2020-01-05', 5, 1000, 20, 200, 12000.12),
		   (1, GETDATE(), 1, '2020-01-01', '2020-01-05', 5, 1000, 20, 200, 12000.12),
		   (1, GETDATE(), 1, '2020-01-01', '2020-01-05', 5, 1000, 20, 200, 12000.12);

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(18,2),
	PhoneCharge DECIMAL(18,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber)
	VALUES (1, '2020-01-01', 1, 333),
	(1, '2020-01-01', 1, 333),
	(1, '2020-01-01', 1, 333);