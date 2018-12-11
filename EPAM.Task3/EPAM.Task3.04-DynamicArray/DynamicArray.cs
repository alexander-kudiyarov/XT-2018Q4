using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task3._04_DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        public T[] Array { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    return Array[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"get index = {index}");
                }
            }
        }

        public int Capacity { get; private set; }

        public int Length { get; private set; } = 0;

        public DynamicArray()
        {
            Array = new T[8];
            Capacity = Array.Length;
        }

        public DynamicArray(int capacity)
        {
            Array = new T[capacity];
            Capacity = Array.Length;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            Array = new T[collection.Count()];
            foreach (var item in collection)
            {
                Array[Length] = item;
                Length++;
            }
            Capacity = Array.Length;
        }

        private void Extension(int n)
        {
            T[] tmpArray = new T[Capacity * n];
            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = Array[i];
            }
            Array = tmpArray;
            Capacity = Array.Length;
        }

        public void Add(T obj)
        {
            if (Length == Capacity)
            {
                Extension(2);
            }
            Array[Length] = obj;
            Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            double fullCapacity = Capacity + collection.Count();
            if (fullCapacity > Capacity)
            {
                Extension((int)Math.Ceiling(fullCapacity / Capacity));
            }
            foreach (var item in collection)
            {
                Array[Length] = item;
                Length++;
            }
        }

        public bool Remove(T obj)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i].Equals(obj))
                {
                    for (int j = i; j < Length - 1; j++)
                    {
                        Array[j] = Array[j + 1];
                    }
                    Array[Length - 1] = default(T);
                    Length--;
                    return true;
                }
            }
            return false;
        }

        public bool Insert(int index, T obj)
        {
            if (index >= 0 && index <= Length)
            {
                if (Length == Capacity)
                {
                    Extension(2);
                }
                for (int i = Length; i >= index; i--)
                {
                    if (i == 0)
                    {
                        break;
                    }
                    Array[i] = Array[i - 1];
                }
                Array[index] = obj;
                Length++;
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"insert index = {index}");
            }

        }

        public void DynamicArrayShow()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"{Array[i]} ");
            }
            Console.WriteLine($"{Environment.NewLine}Capacity: {Capacity}" +
                $"{Environment.NewLine}Length:   {Length}{Environment.NewLine}");
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}


