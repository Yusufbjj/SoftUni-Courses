using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<Student> students = this.students.Where(s => s.Subject == subject);

            if (students.Any())
            {
                sb.AppendLine($"Subject: {subject}");

                sb.AppendLine($"Students:");

                foreach (Student student in students)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

            }
            else
            {
                return "No students enrolled for the subject";
            }

            return sb.ToString().TrimEnd();

        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}