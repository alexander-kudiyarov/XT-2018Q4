using System.Linq;
using System.Text;

namespace EPAM.Task1._12_CharDoubler
{
    public static class CharDoubler
    {
        public static string Build(string str1, string str2)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < str1.Length; i++)
            {
                result.Append(str1[i]);
                if (str2.Contains(str1[i]))
                {
                    result.Append(str1[i]);
                }
            }

            return result.ToString();
        }
    }
}