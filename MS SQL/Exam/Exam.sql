CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
)


CREATE TABLE RepositoriesContributors
(
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id),
	CONSTRAINT pk_PrimaryKey PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL REFERENCES Users(Id),
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	Message VARCHAR(255) NOT NULL,
	IssueId INT NOT NULL REFERENCES Issues(Id),
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id),
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT NOT NULL REFERENCES Commits(Id),
)


INSERT INTO Files
	VALUES ('Trade.idk', 2598.0, 1 ,1),
	       ('menu.net', 9238.31, 2 ,2),
	       ('Administrate.soshy', 1246.93, 3 ,3),
	       ('Controller.php', 7353.15, 4 ,4),
	       ('Find.java', 9957.86, 5 ,5),
	       ('Controller.json', 14034.87, 3 ,6),
	       ('Operate.xix', 7662.92, 7 ,7)



INSERT INTO Issues
	VALUES ('Critical Problem with HomeController.cs file', 'open', 1, 4),
	('Typo fix in Judge.html', 'open', 4, 3),
	('Implement documentation for UsersService.cs', 'closed', 8, 2),
	('Unreachable code in Index.cs', 'open', 9, 8)


UPDATE Issues
SET IssueStatus = 'closed'
	WHERE AssigneeId = 6



DELETE FROM RepositoriesContributors WHERE RepositoryId = (SELECT Id FROM Repositories WHERE Name = 'Softuni-Teamwork')
DELETE FROM Issues WHERE RepositoryId = (SELECT Id FROM Repositories WHERE Name = 'Softuni-Teamwork')

DELETE FROM Files WHERE CommitId IN (SELECT Id FROM Commits WHERE RepositoryId = (SELECT Id FROM Repositories WHERE Name = 'Softuni-Teamwork'))

DELETE FROM Commits WHERE RepositoryId = (SELECT Id FROM Repositories WHERE Name = 'Softuni-Teamwork')

DELETE FROM Repositories WHERE Name = 'Softuni-Teamwork'




SELECT Id,
	Message,
	RepositoryId,
	ContributorId
	FROM Commits
	ORDER BY Id, Message, RepositoryId, ContributorId 


SELECT Id,
	Name,
	Size
	FROM Files
	WHERE Size > 1000 AND Name LIKE '%html%'
	ORDER BY Size DESC, Id, Name


SELECT i.Id,
	 CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
	FROM Issues i
	JOIN Users u ON i.AssigneeId = u.Id
	ORDER BY i.Id DESC, i.AssigneeId



SELECT Id,
	   Name,
	   CONCAT(SIZE, 'KB')
	FROM Files f
	WHERE f.Id NOT IN (SELECT ParentId FROM FILES WHERE ParentId IS NOT NULL)
	ORDER BY Id, Name, Size DESC


SELECT TOP(5) r.Id,
		R.Name,
		COUNT(c.Id) AS Commits
	FROM RepositoriesContributors rc
	JOIN Repositories r ON rc.RepositoryId = r.Id
	JOIN Commits c ON r.Id = c.RepositoryId
	GROUP BY r.Id, R.Name
	ORDER BY Commits DESC, r.Id, r.Name


SELECT u.Username,
	   AVG(f.Size) AS Size
	FROM Users u
	JOIN Commits c ON u.Id = c.ContributorId
	JOIN Files f ON c.Id = f.CommitId
	GROUP BY u.Username
	ORDER BY AVG(f.Size) DESC, u.Username

--

CREATE FUNCTION udf_AllUserCommits (@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @Count INT =  (SELECT COUNT(c.Id) 
							 FROM Commits c
							 JOIN Users u ON c.ContributorId = u.Id
							 WHERE u.Username = @username)
	RETURN @Count
END


--

CREATE PROCEDURE usp_SearchForFiles (@fileExtension VARCHAR(100)) 
AS
	SELECT Id,
			Name,
			CONCAT(Size, 'KB') AS Size
		FROM FILES
		WHERE Name LIKE ('%' + @fileExtension)
		ORDER BY Id, Name, Size DESC