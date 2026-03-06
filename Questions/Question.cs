using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Examination_System.Questions
{
    internal abstract class Question : ICloneable //needed when Cloning Questions Array
    {
        public string Header { get; set; }
        public string Body  { get; set; }
        public int Marks {  get; set; }
        public AnswerList Answers { get; set; }
        public AnswerList CorrectAnswer     { get; }
        public Question(string header, string body, int marks, AnswerList answers, AnswerList correctAnswer)
        {
            if (string.IsNullOrWhiteSpace(header))
                throw new ArgumentException("Header cannot be empty.");
            if (string.IsNullOrWhiteSpace(body))
                throw new ArgumentException("Body cannot be empty.");
            if (marks <= 0)
                throw new ArgumentException("Marks must be greater than 0.");
            if (answers == null || answers.Count == 0)
                throw new ArgumentException("Answers cannot be empty.");
       

            Header = header;
            Body = body;
            Marks = marks;
            Answers = answers;  //will see later if i would need cloning or not
            CorrectAnswer = correctAnswer ?? throw new ArgumentNullException(nameof(correctAnswer));
        }


        public abstract void Display();
        public abstract bool CheckAnswer(AnswerList studentAnswers);

        public override string ToString() 
        {
            string str = "Mark";
            if (Marks > 1) str = "Marks";
            return $"{Header}. {Body} ({Marks} {str}) \nAnswers:\n{Answers}";
        }
      
        public override bool Equals(object? obj)
        {
             if (obj is not Question Q || obj==null)
                return false;

            return Header == Q.Header &&
                   Body == Q.Body &&
                   Marks == Q.Marks &&
                   CorrectAnswer.Equals(Q.CorrectAnswer);


        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Body, Marks,CorrectAnswer);
        }

        public abstract object Clone();
      
    }
}
