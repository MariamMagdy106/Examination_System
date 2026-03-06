using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Examination_System.Exams
{
    public abstract class Exam :ICloneable,IComparable<Exam>
    {
        public int Time {  get;  }
        public int NumberOfQuestions => Questions.Length;
        
        internal Question[] Questions { get;  }
        internal Dictionary<Question, AnswerList> QuestionAnswerDictionary { get; }

        internal Subject Subject { get;  }


        internal ExamMode Mode { get; set; }
        protected int TotalExamGrade
        {
            get
            {
                int total = 0;
                foreach (var q in Questions)
                    total += q.Marks;
                return total;
            }
        }

        internal Exam(int time, Question[] questions, Subject subject)
        {
            if (time <= 0)
                throw new ArgumentException("Time must be positive.");

            if (questions == null || questions.Length == 0)
                throw new ArgumentException("Questions cannot be null or empty.");

            Time = time;
            Questions = questions;
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            QuestionAnswerDictionary = new Dictionary<Question, AnswerList>();
            Mode = ExamMode.Queued;
        }
        public abstract void ShowExam();

        public virtual void Start() {
            Mode = ExamMode.Starting;
            OnExamStarted(new ExamEventArgs(Subject, this));
        }
        public virtual void Finish() { 
            Mode = ExamMode.Finished;
            int grade = CorrectExam();
            Console.WriteLine($"Exam Finished.");
            Console.WriteLine($"Final Grade = {grade}/{TotalExamGrade}");
        }

        public virtual int CorrectExam() 
        {
            int score = 0;
            foreach (var q in Questions)
            {
                if (QuestionAnswerDictionary.TryGetValue(q, out var ans))
                {
                    if (q.CheckAnswer(ans))
                        score += q.Marks;
                }
            }
            return score;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {Subject.Name}, Time: {Time} mins, Questions: {NumberOfQuestions}, Mode: {Mode}\n";
        }
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Exam other)
                return Time == other.Time && NumberOfQuestions == other.NumberOfQuestions && Subject==other.Subject;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions, Subject);
        }

        public abstract object Clone(); //As I can't return or creating object of abstract Calss
                                        //Also for the need for Deep Copy Not Just Shallow Copy

        public int CompareTo(Exam? other)
        {
            if (other is null)
                return 1;
           
            if(Time.CompareTo(other.Time) == 0)
                    return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
                return Time.CompareTo(other.Time);
            
        }
        public void SaveResultsToFile(string filePath) //Bounus Part
        {
            using (StreamWriter writer = new StreamWriter(filePath, true)) 
            {
                writer.WriteLine("=================================");
                writer.WriteLine($"Exam: {Subject.Name}");
                writer.WriteLine($"Date: {DateTime.Now}");
                writer.WriteLine($"Exam Type: {this.GetType().Name}");
                writer.WriteLine($"Total Marks: {TotalExamGrade}");

                foreach (var q in Questions)
                {
                    writer.WriteLine("----------------------------");
                    writer.WriteLine($"Question: {q.Header}");

                    if (QuestionAnswerDictionary.TryGetValue(q, out var studentAnswer))
                    {
                        writer.WriteLine($"Student Answer:\n{studentAnswer}");
                        if (this is PracticeExam) 
                        {
                            writer.WriteLine($"Correct Answer:\n{q.CorrectAnswer}");
                            writer.WriteLine($"Marks Earned: {(q.CheckAnswer(studentAnswer) ? q.Marks : 0)}");
                        }
                    }
                    else
                    {
                        writer.WriteLine("Student Answer: Not Answered");
                    }
                }
                writer.WriteLine("=================================");
                writer.WriteLine($"Final Grade: {CorrectExam()} / {TotalExamGrade}");
                writer.WriteLine("=================================");
                writer.WriteLine();
            }
        }

        public event EventHandler<ExamEventArgs> ExamStarted;
        protected virtual void OnExamStarted(ExamEventArgs eventArgs)
        {
            ExamStarted?.Invoke(this, eventArgs);
        }
       

    }
}
