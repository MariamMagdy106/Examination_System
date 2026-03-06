using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Examination_System.Questions
{
    internal class QuestionList : List<Question>
    {
        private readonly string filePath;

        public QuestionList(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be empty.");

            filePath = fileName;

            
        }

        public new void Add(Question question) //New Here Is Optional
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            base.Add(question);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Logged At: {DateTime.Now}");
                    writer.WriteLine(question.ToString());
                    writer.WriteLine($"Correct Answer:\n{question.CorrectAnswer}"); // Logs questions with Its Correct Answers

                    writer.WriteLine("=================================");
                    writer.WriteLine();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error while writing to file:");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
