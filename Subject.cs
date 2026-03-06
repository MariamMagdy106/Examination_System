using System;
using System.Collections.Generic;
using System.Text;
using Examination_System.Exams;

namespace Examination_System
{
    public class Subject
    {
        public string Name { get; set; }
        private Student[] EnrolledStudents;
        
        private int count;

        public Subject(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Subject name cannot be empty.");

            Name = name;
            EnrolledStudents = new Student[4];
            count = 0;
        }

        public void Enroll(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (count == EnrolledStudents.Length)
                Array.Resize(ref EnrolledStudents, EnrolledStudents.Length * 2);

            EnrolledStudents[count++] = student;
        }

        public Student[] GetStudents()
        {
            Student[] result = new Student[count];
            Array.Copy(EnrolledStudents, result, count);
            return result;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public void NotifyStudents(Exam exam) //Subscription 
        {
            for (int i = 0; i < count; i++)
            {
                exam.ExamStarted += EnrolledStudents[i].OnExamStarted;
            }
        }
    }
}
