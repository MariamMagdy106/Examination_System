using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System.Exams
{
    public class FinalExam : Exam
    {
        internal FinalExam(int time, Question[] questions, Subject subject) : base(time, questions, subject)
        {
        }

        public override void ShowExam() //should I Show Student Grade or not?
        {
            Console.WriteLine($"--- Final Exam: {Subject.Name} ---"); 
            foreach (var q in Questions)
            {
                q.Display();

                if (QuestionAnswerDictionary.TryGetValue(q, out var answer))
                    Console.WriteLine($"Your Answer:\n{answer}");
                else
                    Console.WriteLine("Your Answer: Not answered");

                Console.WriteLine("---------------------------------");
            }

        }

        public override object Clone()
        {
            var clonedQuestions = new Question[Questions.Length];
            for (int i = 0; i < Questions.Length; i++)
                clonedQuestions[i] = (Question)Questions[i].Clone(); //The reason Why I Implement Iclonable For Questin Class
            return new FinalExam(Time, clonedQuestions, Subject);
        }

    }
}
