using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Examination_System.Questions
{
    internal class TrueFalseQuestion : Question
    {

        public TrueFalseQuestion(string header, string body, int marks, AnswerList answers, AnswerList correctAnswer)
            : base(header, body, marks, answers, correctAnswer)
        {
            if (answers.Count != 2)
                throw new ArgumentException("True/False question must have exactly 2 answers.");
        }

        public override void Display()
        {
            Console.WriteLine($"[True/False]\n{Header}. {Body} ({Marks} marks)");
            Console.WriteLine(Answers);
        }

        public override bool CheckAnswer(AnswerList studentAnswers)
        {
            if (studentAnswers == null || studentAnswers.Count != 1)
                return false;

            return studentAnswers[0].Equals(CorrectAnswer[0]);
        }


        public override object Clone() { //cloning chain
            return new TrueFalseQuestion(  Header, Body, Marks,
             (AnswerList)Answers.Clone(), //Cloning Needed for Deep Copy for Reference Types
             (AnswerList)CorrectAnswer.Clone()
              );

        }


    }
}
