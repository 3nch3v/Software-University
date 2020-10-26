using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;
        private int capacity;
        public Classroom(int capacity)
        {

            this.data = new List<Student>();
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public int Count => this.data.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.data.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                this.data.RemoveAll(s => s.FirstName == firstName && s.LastName == lastName);

                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            bool areThereStudents = false;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in this.data)
            {
                if (student.Subject == subject)
                {
                    areThereStudents = true;
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }

            if (areThereStudents)
            {
                return sb.ToString().Trim();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            Student currStudent = this.data.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            return currStudent;
        }
    }
}
