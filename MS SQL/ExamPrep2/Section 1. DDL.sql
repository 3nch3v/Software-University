--=====================	Section 1. DDL	=============================================

CREATE DATABASE School;
USE School;

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK (Age BETWEEN 5 AND 100 AND Age > 0),
	[Address] NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL CHECK (Lessons > 0)
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL REFERENCES Students(Id),
	SubjectId INT NOT NULL REFERENCES Subjects(Id),
	Grade DECIMAL(3,2) NOT NULL CHECK (Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	Date DATETIME,
	SubjectId INT NOT NULL REFERENCES Subjects(Id),

)

CREATE TABLE StudentsExams
(
	StudentId INT NOT NULL REFERENCES Students(Id),
	ExamId INT NOT NULL REFERENCES Exams(Id),
	Grade DECIMAL(3,2) NOT NULL CHECK (Grade BETWEEN 2 AND 6),
	CONSTRAINT c_StudentsExamsPrimaryKey PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT NOT NULL REFERENCES Subjects(Id)
)


CREATE TABLE StudentsTeachers
(
	StudentId INT NOT NULL REFERENCES Students(Id),
	TeacherId INT NOT NULL REFERENCES Teachers(Id),
	CONSTRAINT c_StudentsTeachersPrimaryKey PRIMARY KEY (StudentId, TeacherId)
)

