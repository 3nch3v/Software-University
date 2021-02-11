--===================	Section 4. Programmability (20 pts)	================================

--11. Exam Grades

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(MAX)
AS 
BEGIN
	DECLARE @Msg NVARCHAR(MAX);
	DECLARE @CurrStudentId INT = (SELECT Id FROM Students WHERE Id = @studentId)

	IF @CurrStudentId IS NULL
	BEGIN
		 SET @Msg = 'The student with provided id does not exist in the school!'
		 RETURN @Msg;
	END	 

	IF @grade > 6
	BEGIN
	SET @Msg =  'Grade cannot be above 6.00!'
	RETURN  @Msg;
	END

	DECLARE @GradesCount INT = (SELECT COUNT(se.Grade) 
									FROM Students s
									JOIN StudentsExams se ON s.Id = se.StudentId
									WHERE Id = @studentId AND se.Grade BETWEEN @grade AND (@grade + 0.5));

	DECLARE @FirstName NVARCHAR(50) = (SELECT FirstName FROM Students WHERE Id = @studentId);

	 SET @Msg =  CONCAT('You have to update ', CAST(@GradesCount AS NVARCHAR(MAX)) , ' grades for the student ', @FirstName);
	 RETURN  @Msg;
END


--12. Exclude from school

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @CurrStudentId INT = (SELECT Id FROM Students WHERE Id = @studentId)

	IF @CurrStudentId IS NULL
		THROW 50001, 'This school has no student with the provided id!', 1;

	DELETE FROM StudentsExams
		WHERE StudentId = @StudentId
	DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId
	DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId
	DELETE FROM Students
		WHERE Id = @StudentId
END

EXEC usp_ExcludeFromSchool 301

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students
