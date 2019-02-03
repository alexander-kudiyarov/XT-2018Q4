using System.Text;

namespace EPAM.Task2._04_MyString
{
    public class MyString
    {
        public MyString(string input)
        {
            this.Array = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                this.Array[i] = input[i];
            }
        }

        public MyString(char[] input)
        {
            this.Array = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                this.Array[i] = input[i];
            }
        }

        public MyString(int input)
        {
            string temp = input.ToString();
            this.Array = new char[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                this.Array[i] = temp[i];
            }
        }

        public MyString()
        {
            this.Array = null;
        }

        public int Length
        {
            get => this.Array.Length;
        }

        private char[] Array { get; set; }

        private char this[int index]
        {
            get => this.Array[index];
            set => this.Array[index] = value;
        }

        public static int Compare(MyString str1, MyString str2)
        {
            int tmp = str1.Length <= str2.Length ? str1.Length : str2.Length;
            for (int i = 0; i < tmp; i++)
            {
                if (str1[i] == str2[i])
                {
                    continue;
                }
                else
                {
                    if (str1[i] < str2[i])
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }

            if (str1.Length == str2.Length)
            {
                return 0;
            }
            else
            {
                if (str1.Length < str2.Length)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public static bool operator !=(MyString str1, MyString str2)
        {
            {
                if (Compare(str1, str2) != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static MyString operator +(MyString str1, MyString str2)
        {
            MyString result = new MyString
            {
                Array = new char[str1.Length + str2.Length]
            };
            for (int i = 0; i < str1.Length; i++)
            {
                result[i] = str1[i];
            }

            for (int i = 0; i < str2.Length; i++)
            {
                result[i + str1.Length] = str2[i];
            }

            return result;
        }

        public static bool operator ==(MyString str1, MyString str2)
        {
            if (Compare(str1, str2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            var temp = new StringBuilder();
            foreach (var ch in this.Array)
            {
                temp.Append(ch);
            }

            return temp.ToString();
        }

        internal int IndexOf(char value)
        {
            for (int i = 0; i < this.Array.Length; i++)
            {
                if (this.Array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        internal char[] ToCharArray()
        {
            return this.Array;
        }

        internal MyString ToMyString(char[] input)
        {
            MyString result = new MyString(input);
            return result;
        }
    }
}