using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task3._01_Lost
{
    public class Lost
    {
        private LinkedList<int> circle = new LinkedList<int>();

        public Lost(int n)
        {
            if (n < 1)
            {
                throw new FormatException($"N should be positive integer number");
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    this.circle.AddLast(i);
                }
            }
        }

        public void ClearCircle()
        {
            LinkedListNode<int> current = this.circle.First;
            while (this.circle.Count > 1)
            {
                this.circle.Remove(current.Next ?? this.circle.First);
                current = current.Next ?? this.circle.First;
            }
        }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            foreach (var n in this.circle)
            {
                temp.Append($"{n} ");
            }

            return temp.ToString().Trim();
        }
    }
}
