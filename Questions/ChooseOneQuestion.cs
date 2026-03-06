using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System.Questions
{
    internal class ChooseOneQuestion : Question
    {

        public ChooseOneQuestion(string header, string body, int marks, AnswerList answers, AnswerList correctAnswer)
            : base(header, body, marks, answers, correctAnswer)
        {
            if (answers.Count < 2)
                throw new ArgumentException("ChooseOne question must have at least 2 answers.");
        }
        public override bool CheckAnswer(AnswerList studentAnswers)
        {
            if (studentAnswers == null || studentAnswers.Count != 1)
                return false;

            return studentAnswers[0].Equals(CorrectAnswer[0]);
        }

        public override void Display()
        {
            Console.WriteLine($"[Choose one]\n{Header}. {Body}({Marks} marks)");
            Console.WriteLine(Answers);
        }


        public override object Clone()
        { //cloning chain
            return new ChooseOneQuestion(Header, Body, Marks,
             (AnswerList)Answers.Clone(), //Cloning Needed for Deep Copy for Reference Types
             (AnswerList)CorrectAnswer.Clone()
              );

        }


    }
}
