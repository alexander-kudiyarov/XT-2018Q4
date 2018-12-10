using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task3._02_WordFrequency
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                string text = $"War is peace. Freedom is slavery. Ignorance is strength.";
                Console.WriteLine(text);
                WordFrequency ob = new WordFrequency(text);
                ob.FillDictionary();
                ob.ShowDictionary();
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
