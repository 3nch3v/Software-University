--==========================	Section 2. DML	==================================

-- 2. Insert
INSERT INTO Teachers
 VALUES ('Ruthanne', 'Bamb' , '84948 Mesta Junction', '3105500146',	6),
		('Gerrard', 'Lowin' , '370 Talisman Plaza', '3324874824',	2),
		('Merrile', 'Lambdin' , '81 Dahle Plaza', '4373065154',	5),
		('Bert', 'Ivie' , '2 Gateway Circle', '4409584510',	4)

INSERT INTO Subjects
 VALUES ('Geometry', 	12),
		('Health', 	10),
		('Drama', 	7),
		('Sports', 	9)


--3. Update

SELECT * 
	FROM StudentsSubjects
	WHERE SubjectId IN (1, 2) AND Grade >= 5.5

UPDATE StudentsSubjects
	SET Grade = 6
	WHERE SubjectId IN (1, 2) AND Grade >= 5.5

-- 4. Delete

DELETE FROM StudentsTeachers
	WHERE TeacherId IN ( SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
	WHERE Phone LIKE '%72%'

SELECT *
	FROM Teachers
		WHERE Phone LIKE '%72%'
