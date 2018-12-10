using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task3._02_WordFrequency
{
    public class WordFrequency
    {
        private Dictionary<string, int> counter = new Dictionary<string, int>();

        private char[] separators = { ' ', '.' };

        public WordFrequency(string input)
        {
            if (input == string.Empty)
            {
                throw new ArgumentException($"Input string souldn't be empty");
            }
            else
            {
                this.Words = input.ToLower().Split(this.separators);
            }
        }

        private string[] Words { get; }

        public void FillDictionary()
        {
            foreach (string str in this.Words)
            {
                if (this.counter.ContainsKey(str))
                {
                    this.counter[str]++;
                }
                else
                {
                    if (str != string.Empty)
                    {
                        this.counter.Add(str, 1);
                    }
                }
            }
        }

        public void ShowDictionary()
        {
            foreach (var x in this.counter)
            {
                Console.Write($"Word:  {x.Key}{Environment.NewLine}" +
                              $"Count: {x.Value}{Environment.NewLine}");
                Console.WriteLine();
            }
        }
    }
}
