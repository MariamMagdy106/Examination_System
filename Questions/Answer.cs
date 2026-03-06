using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System.Questions
{
    internal class Answer : IComparable<Answer>, ICloneable
    {
        public int Id { get; set; }
        private string Text { get; set;}

        public Answer(int id, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Answer text cannot be empty.");

            Id = id;
            Text = text;
        }
        public override string ToString() 
        {
            return $"{Id}. {Text}";
        }

        public int CompareTo(Answer? other)
        {
            if (other == null) return 1;
            return Id.CompareTo(other.Id);
        }
        public override bool Equals(object? obj)
        {
            if(obj==null || !(obj is Answer Ans)) return false ;
            return (Id.CompareTo(Ans.Id) == 0) && (Text.CompareTo(Ans.Text) == 0) ;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text,Id);
        }

        public object Clone() //needed For Cloning Chain
        {
            return new Answer(Id, Text);
        }
    }
}
