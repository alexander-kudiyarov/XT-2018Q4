using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task3._04_DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        private int capacity;

        public DynamicArray()
        {
            this.Array = new T[8];
            this.Capacity = this.Array.Length;
        }

        public DynamicArray(int capacity)
        {
            this.Array = new T[capacity];
            this.Capacity = this.Array.Length;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            this.Array = new T[collection.Count()];
            foreach (var item in collection)
            {
                this.Array[this.Length] = item;
                this.Length++;
            }

            this.Capacity = this.Array.Length;
        }

        public DynamicArray(T[] arrayClone, int capacityClone, int lengthClone)
        {
            this.Array = arrayClone;
            this.Capacity = capacityClone;
            this.Length = lengthClone;
        }

        public T[] Array { get; private set; }

        public int Length { get; private set; } = 0;

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < this.capacity)
                {
                    this.capacity = value;
                    if (this.Length > value)
                    {
                        this.Length = value;
                    }
                }
                else
                {
                    this.capacity = value;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.Length)
                {
                    return this.Array[index];
                }
                else
                {
                    if (index < 0 && index > this.Length * -1)
                    {
                        return this.Array[this.Length + index];
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException($"'get' wrong index = {index}");
                    }
                }
            }
        }

        public void Add(T obj)
        {
            if (this.Length == this.Capacity)
            {
                this.Extension(2);
            }

            this.Array[this.Length] = obj;
            this.Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            double fullCapacity = this.Capacity + collection.Count();
            if (fullCapacity > this.Capacity)
            {
                this.Extension((int)Math.Ceiling(fullCapacity / this.Capacity));
            }

            foreach (var item in collection)
            {
                this.Array[this.Length] = item;
                this.Length++;
            }
        }

        public bool Remove(T obj)
        {
            for (int i = 0; i < this.Array.Length; i++)
            {
                if (this.Array[i].Equals(obj))
                {
                    for (int j = i; j < this.Length - 1; j++)
                    {
                        this.Array[j] = this.Array[j + 1];
                    }

                    this.Array[this.Length - 1] = default(T);
                    this.Length--;
                    return true;
                }
            }

            return false;
        }

        public bool Insert(int index, T obj)
        {
            if (index >= 0 && index <= this.Length)
            {
                if (this.Length == this.Capacity)
                {
                    this.Extension(2);
                }

                for (int i = this.Length; i >= index; i--)
                {
                    if (i == 0)
                    {
                        break;
                    }

                    this.Array[i] = this.Array[i - 1];
                }

                this.Array[index] = obj;
                this.Length++;
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Insert() wrong index: {index}");
            }
        }

        public void DynamicArrayShow()
        {
            for (int i = 0; i < this.Length; i++)
            {
                Console.Write($"{Array[i]} ");
            }

            Console.WriteLine($"{Environment.NewLine}Capacity: {Capacity}" +
                $"{Environment.NewLine}Length:   {Length}{Environment.NewLine}");
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)this.GetEnumerator();
        }

        public object Clone()
        {
            return new DynamicArray<T>(this.Array, this.Capacity, this.Length);
        }

        public T[] ToArray()
        {
            T[] simpleArray = new T[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                simpleArray[i] = this.Array[i];
            }

            return simpleArray;
        }

        private void Extension(int n)
        {
            T[] tmpArray = new T[this.Capacity * n];
            for (int i = 0; i < this.Length; i++)
            {
                tmpArray[i] = this.Array[i];
            }

            this.Array = tmpArray;
            this.Capacity = this.Array.Length;
        }
    }
}
