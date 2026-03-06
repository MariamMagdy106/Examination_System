using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System.Exams
{
    public class ExamEventArgs : EventArgs
    {
       public Subject Subject { get; }
       public Exam Exam { get; }
       public ExamEventArgs(Subject subject, Exam exam)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Exam = exam ?? throw new ArgumentNullException(nameof(exam));
        }
    }
}
