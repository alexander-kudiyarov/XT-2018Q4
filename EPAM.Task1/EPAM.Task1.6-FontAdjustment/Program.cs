using System;

namespace EPAM.Task1._6_FontAdjustment
{
    class FontAdjustment
    {
        bool bold = false;
        bool italic = false;
        bool underline = false;

        public void Format()
        {
            Console.Write("Параметры надписи: ");
            if (bold)
            {
                Console.Write("Bold ");
            }
            if (italic)
            {
                Console.Write("Italic ");
            }
            if (underline)
            {
                Console.Write("Underline ");
            }
            if (!bold && !italic && !underline)
            {
                Console.Write("None");
            }
            Console.WriteLine("\nВведите:\n\t1: bold\n\t2: italic\n\t3: underine");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    bold = !bold;
                    Format();
                    break;
                case 2:
                    italic = !italic;
                    Format();
                    break;
                case 3:
                    underline = !underline;
                    Format();
                    break;
                default:
                    break;
            }

        }

    }
    class FontAdjustmentDemo
    {
        static void Main()
        {
            FontAdjustment ob = new FontAdjustment();
            ob.Format();
        }
    }
}