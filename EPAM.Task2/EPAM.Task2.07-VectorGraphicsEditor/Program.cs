using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    public class Program
    {
        public static void Main()
        {
            Line line = new Line(2, 2, 2);
            Console.WriteLine(line.ToString());

            Rectangle rectangle = new Rectangle(3, 3, 3, 3);
            Console.WriteLine(rectangle.ToString());

            Circle circle = new Circle(4, 4, 4);
            Console.WriteLine(circle.ToString());

            Round round = new Round(5, 5, 5);
            Console.WriteLine(round.ToString());

            Ring ring = new Ring(6, 6, 6, 9);
            Console.WriteLine(ring.ToString());
        }
    }
}
