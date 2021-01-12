CREATE DATABASE Minions;
USE Minions ;

CREATE TABLE Minions 
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age SMALLINT NOT NULL
);

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
);

ALTER TABLE Minions
	ADD TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id);

ALTER TABLE Minions ALTER COLUMN Age INT NULL;
SET IDENTITY_INSERT  Minions  ON ;

INSERT INTO Towns (Id, [Name])
	VALUES (1, 'Sofia');

INSERT INTO Towns (Id, [Name])
	VALUES (2, 'Plovdiv');

INSERT INTO Towns (Id, [Name])
	VALUES (3, 'Varna');

INSERT INTO Minions (Id, [Name], Age, TownId)
	VALUES (1, 'Kevin', 22, 1);

INSERT INTO Minions (Id, [Name], Age, TownId)
	VALUES (2, 'Bob', 15, 3);

INSERT INTO Minions (Id, [Name], TownId)
	VALUES (3, 'Steward', 2);

INSERT INTO Minions (Id, [Name], Age, TownId)
	VALUES (5, 'Pesho', 32, 1);

DELETE Minions;

DROP TABLE Minions;
DROP TABLE Towns;

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
);

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate, Biography)
	VALUES ('Ivan', 1.75, 87.5, 'm', '1987-03-30', 'My bio');

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate)
	VALUES ('Pesho', 1.85, 187.5, 'm', '1999-03-15');

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate, Biography)
	VALUES ('It', 1.35, 87.5, 'm', '1955-09-03', 'xo-xo-xo');

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate)
	VALUES ('Hitman', 1.67, 55.5, 'f', '1997-01-01');

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate)
	VALUES ('Bunny', 0.75, 567.58, 'f', '2020-01-01');


CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
);

INSERT INTO Users (Username, [Password], LastLoginTime, IsDeleted)
	VALUES ('Ivan', '123456', '2020-01-12 21:26:03', '0');
INSERT INTO Users (Username, [Password], LastLoginTime, IsDeleted)
	VALUES ('X-Man', '9999999999', '2019-11-11 01:26:03', '1');
INSERT INTO Users (Username, [Password], LastLoginTime, IsDeleted)
	VALUES ('Spider', 'daSe32ed$#%f', GETDATE(), '0');
INSERT INTO Users (Username, [Password], LastLoginTime, IsDeleted)
	VALUES ('BBB', '@#$dfsd23', '2019-03-02 11:06:09', '1');
INSERT INTO Users (Username, [Password], LastLoginTime, IsDeleted)
	VALUES ('AAA', 'ldfFFDS34@Es12', '2015-09-22 22:22:22', '0');


ALTER TABLE Users DROP CONSTRAINT [PK__Users__3214EC07FEA11A7F];

ALTER TABLE Users ADD CONSTRAINT PK_Userspk PRIMARY KEY (Id, Username);

ALTER TABLE Users ADD CONSTRAINT CHK_PasswordMinLength CHECK (LEN([Password]) >= 5)

ALTER TABLE Users 
	ADD CONSTRAINT DK_SetCurrDatetimeByDefault 
		DEFAULT GETDATE() FOR LastLoginTime;

INSERT INTO Users (Username, [Password], IsDeleted)
	VALUES ('AAA', 'ldfFFDS34@Es12', '0');