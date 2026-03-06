using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System.Exams
{
    public class PracticeExam : Exam
    {
        internal PracticeExam(int time, Question[] questions, Subject subject) : base(time, questions, subject)
        {
        }

        public override object Clone()
        {
            var clonedQuestions = new Question[Questions.Length];
            for (int i = 0; i < Questions.Length; i++)
                clonedQuestions[i] = (Question)Questions[i].Clone(); //The reason Why I Implement Iclonable For Questin Class
            return new PracticeExam(Time, clonedQuestions, Subject);
        }

        public override void ShowExam()
        {
            Console.WriteLine(this.ToString());
            foreach (var q in Questions)
            {
                q.Display();

                if (QuestionAnswerDictionary.TryGetValue(q, out var answer))
                Console.WriteLine($"Your Answer:\n{answer}");
                else
                    Console.WriteLine("Your Answer: Not answered");

                Console.WriteLine($"Correct Answer:\n{q.CorrectAnswer}");
                Console.WriteLine("---------------------------------");
            }

        }

      
    }
}
