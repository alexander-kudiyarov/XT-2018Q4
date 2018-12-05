using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    internal class VectorGraphicsEditorDemo
    {
        internal static void Main()
        {
            Line line = new Line(2, 2, 2);
            line.Show();
            Console.WriteLine();

            Rectangle rectangle = new Rectangle(3, 3, 3, 3);
            rectangle.Show();
            Console.WriteLine();

            Circle circle = new Circle(4, 4, 4);
            circle.Show();
            Console.WriteLine();

            Round round = new Round(5, 5, 5);
            round.Show();
            Console.WriteLine();

            Ring ring = new Ring(6, 6, 6, 9);
            ring.Show();
        }
    }
}
