CREATE DATABASE Exercises;

USE Exercises;

--01. One-To-One Relationship

CREATE TABLE Persons
(
	PersonID INT,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL NOT NULL,
	PassportID INT
);

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber NVARCHAR(50) NOT NULL,
);

INSERT INTO Persons (PersonID , FirstName, Salary, PassportID)
	VALUES (1, 'Roberto', 43300.00, 102),
		   (2, 'Tom', 56100.00, 103),
		   (3, 'Yana', 60200.00, 101);

INSERT INTO Passports (PassportID, PassportNumber)
	VALUES (101, 'N34FG21B'),
		   (102, 'K65LO4R7'),
		   (103, 'ZE657QP2');

ALTER TABLE Persons
	ALTER COLUMN PersonID INT NOT NULL

ALTER TABLE Persons
	ADD PRIMARY KEY (PersonID);

ALTER TABLE Persons
	ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID);

--02. One-To-Many Relationship

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATETIME2 NOT NULL,
	
);

INSERT INTO Manufacturers ([Name], EstablishedOn)
	VALUES ('BMW', '07/03/1916'),
		   ('Tesla', '01/01/2003'),
		   ('Lada', '01/05/1966');

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL,
	FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
);

INSERT INTO Models (ModelID, [Name], ManufacturerID)
	VALUES  (101, 'X1', 1),
			(102, 'i6', 1),
			(103, 'Model S', 2),
			(104, 'Model X', 2),
			(105, 'Model 3', 2),
			(106, 'Nova', 3);

--Problem 3.	Many-To-Many Relationship

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
);

INSERT INTO Students
	VALUES ('Mila'),
			('Toni'),
			('Ron');

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL
);

INSERT INTO Exams
	VALUES ('SpringMVC'),
			('Neo4j'),
			('Oracle 11g');

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL 
	CONSTRAINT PK_StudentsExamsCompKey PRIMARY KEY (StudentID, ExamID)
);

ALTER TABLE StudentsExams
	ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID);

ALTER TABLE StudentsExams
	ADD FOREIGN KEY (ExamID) REFERENCES Exams(ExamID);

INSERT INTO StudentsExams
	VALUES (1, 101),
		   (1, 102),
		   (2, 101),
		   (3, 103),
		   (2, 102),
		   (2, 103);

--Problem 4.	Self-Referencing 