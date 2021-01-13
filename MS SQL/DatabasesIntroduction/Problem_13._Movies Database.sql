/* Problem 13.	Movies Database
Using SQL queries create Movies database with the following entities:
•	Directors (Id, DirectorName, Notes)
•	Genres (Id, GenreName, Notes)
•	Categories (Id, CategoryName, Notes)
•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
Set most appropriate data types for each column. Set primary key to each table. Populate each table with exactly 5 records. 
Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB. */

CREATE DATABASE Movies

CREATE TABLE Directors 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
CREATE TABLE Genres
(
	Id INT PRIMARY KEY NOT NULL,
	GenreName NVARCHAR(10),
	Notes NVARCHAR(MAX)
)
CREATE TABLE Categories
(
	Id INT PRIMARY KEY NOT NULL,
	CategoryName NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATETIME2 NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL(4,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes)
	VALUES ('JAMES CAMERON', 'James Cameron is the director Michael Bay wishes he was.'), 
		   ('MARTIN SCORSESE', NULL),
		   ('Quentin Tarantino', 'You will not find a more spontaneous director than Quentin Tarantino in this list or in Hollywood.'),
		   ('ALFRED HITCHCOCK', NULL),
		   ('TIM BURTON', NULL)

INSERT INTO Genres (Id, GenreName, Notes)
	VALUES (1, 'Action', NULL),
		   (2, 'Crime', NULL),
		   (3, 'Drama', NULL),
		   (4, 'Mystery', NULL),
		   (5, 'Thriller', NULL)

INSERT INTO Categories (Id, CategoryName, Notes)
	VALUES (1, 'A', NULL),
		   (2, 'B', NULL),
		   (3, 'C', NULL),
		   (4, 'D', NULL),
		   (5, 'E', NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating)
	VALUES ('1ST_FILM', 1, '2020-11-09', '01:33:10', 1, 1, 5.9),
		   ('2ND_FILM', 2, '2000-01-19', '03:53:00', 2, 3, 9.9),
	       ('3TD_FILM', 4, '2019-02-15', '01:22:30', 4, 5, 7.8),
	       ('4TH_FILM', 5, '2011-03-02', '04:37:50', 3, 4, 6.3),
	       ('5TH_FILM', 3, '2003-06-22', '02:33:10', 5, 2, 1.1)