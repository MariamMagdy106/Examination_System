using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace Examination_System.Questions
{
    internal class ChooseAllQuestion : Question
    {

        public ChooseAllQuestion(string header, string body, int marks,
                                 AnswerList answers, AnswerList correctAnswers)
            : base(header, body, marks, answers, correctAnswers)
        {
            if (correctAnswers == null || correctAnswers.Count == 0)
                throw new ArgumentException("Must provide correct answers.");

            
        }

        public override void Display() 
        {
            Console.WriteLine($"[Choose All The Correct Answer] \n{Header}. {Body} ({Marks} marks)");
            Console.WriteLine(Answers);
        }

        public override bool CheckAnswer(AnswerList studentAnswers)
        {
            if (studentAnswers == null || studentAnswers.Count != CorrectAnswer.Count)
                return false;

      

            for(int i=0; i<CorrectAnswer.Count; i++)
            {
                bool found = false;

                for (int j=0; j<studentAnswers.Count;j++)
                {
                    if (CorrectAnswer[i].Equals(studentAnswers[j]))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    return false;
            }

            return true;
        }


        public override object Clone()
        { //cloning chain
            return new ChooseAllQuestion(Header, Body, Marks,
             (AnswerList)Answers.Clone(), //Cloning Needed for Deep Copy for Reference Types
             (AnswerList)CorrectAnswer.Clone()
              );

        }


    }
}
