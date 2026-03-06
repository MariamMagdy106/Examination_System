using Examination_System.Exams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    public class Student
    {
        public int Id { get;  }
        public string Name { get; }

        public Student(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");

            Id = id;
            Name = name;
    }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
        public void OnExamStarted(object sender, ExamEventArgs eventArgs) { //callBack method at Publisher
            Console.WriteLine($"Student {Name} Notified: Exam has started.\n{eventArgs.Exam}.\n\n");
        }
    }
}
