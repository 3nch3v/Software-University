--==================	Section 3. Querying (40 pts)	===================================
--5. Teen Students

SELECT FirstName,
	   LastName,
	   Age
	FROM Students
	WHERE Age >= 12
	ORDER BY FirstName, LastName


--6. Students Teachers

SELECT s.FirstName,
	   s.LastName,
	   COUNT(s.Id) AS TeachersCount
	FROM Students s
	JOIN StudentsTeachers st ON s.Id = st.StudentId
	GROUP BY s.Id, s.FirstName, s.LastName
	ORDER BY s.LastName


--7. Students to Go

SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name]
	FROM Students s
	LEFT JOIN StudentsExams se ON s.Id = se.StudentId
		WHERE se.Grade IS NULL
		ORDER BY [Full Name]

--8. Top Students

SELECT TOP(10) s.FirstName,
			   s.LastName,
			   CONVERT(DECIMAL(3,2), AVG(se.Grade)) AS Grade
	FROM Students s
	JOIN StudentsExams se ON s.Id = se.StudentId
	GROUP BY s.Id, s.FirstName, s.LastName
	ORDER BY Grade DESC, s.FirstName, s.LastName


--9. Not So In The Studying


SELECT CONCAT(s.FirstName, ' ', ISNULL(s.MiddleName + ' ', ''), s.LastName) AS [Full Name]
	FROM Students s
	LEFT JOIN StudentsSubjects ss ON s.Id = ss.StudentId
	WHERE ss.SubjectId IS NULL
	ORDER BY [Full Name]



--10. Average Grade per Subject

SELECT s.Name,
	   AVG(ss.Grade) AS AverageGrade
	FROM Subjects s
	JOIN StudentsSubjects ss ON s.Id = ss.SubjectId
	GROUP BY s.Name, s.Id
	ORDER BY s.Id