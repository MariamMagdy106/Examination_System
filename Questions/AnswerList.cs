using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System.Questions
{
    internal class AnswerList :ICloneable
    {
        private Answer[] Answers;
        public int Count { get; private set; }

        public AnswerList(int InitialCapacity =4)
        {
            if (InitialCapacity <= 0) InitialCapacity = 4;
            Answers = new Answer[InitialCapacity];
            Count = 0;
        }
        public void Add(Answer answer)
        {
            if (answer == null)
            {
                Console.WriteLine("Answer shouldn't Be Null");
                return;
            }
            if (Count == Answers.Length)
            {
                Array.Resize(ref Answers, Answers.Length * 2);
            }
            Answers[Count++] = answer;
        }

        public Answer GetById(int id)
        {
            for (int i = 0; i < Count; i++)
                if (Answers[i].Id == id)
                    return Answers[i];

            return  null; 

        }
        public Answer this [int index]{
            get {
                if (index < 0 || index >= Count) return new Answer(-1, "NO Found! Out of Boundry");
                return Answers[index];
            }
            set {

                if (index < 0 || index >=Count) throw new IndexOutOfRangeException();
                Answers[index] = value;
            }
        }

        public Answer[] GetAll()
        {
            Answer[] result = new Answer[Count];
            Array.Copy(Answers, result, Count);
            return result;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                sb.AppendLine(Answers[i].ToString());
            }
            return sb.ToString();
        }

        public object Clone() //Needed for Clone Chain
        {
            AnswerList newList = new AnswerList(Count);

            for (int i = 0; i < Count; i++)
                newList.Add((Answer)Answers[i].Clone());

            return newList;
        }




    }
}
