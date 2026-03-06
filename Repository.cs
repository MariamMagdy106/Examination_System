using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    public class Repository<T> where T : ICloneable, IComparable<T>
    {
        private T[] items;
        private int count;

        public Repository(int capacity = 10)
        {
            items = new T[capacity];
            count = 0;
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            if (count == items.Length)
                Resize();

            items[count++] = item;
        }

        public void Remove(T item)
        {
            if (item == null)
                return;

            int index = -1;

            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return;

            for (int i = index; i < count - 1; i++)
                items[i] = items[i + 1];

            items[count - 1] = default;
            count--;
        }

        public void Sort()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) > 0)
                    {
                        T temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }
        }

        public T[] GetAll()
        {
            T[] result = new T[count];

            for (int i = 0; i < count; i++)
                result[i] = (T)items[i].Clone();

            return result;
        }

        private void Resize()
        {
            T[] newArr = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
                newArr[i] = items[i];

            items = newArr;
        }
    }
}
