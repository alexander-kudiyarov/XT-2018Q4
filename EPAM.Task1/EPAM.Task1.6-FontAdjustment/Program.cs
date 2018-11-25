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
            Console.Write("Font property: ");
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
            Console.WriteLine("{0}Enter:{0}\t1: bold{0}\t2: italic{0}\t3: underine{0}\tAnother value for exit", Environment.NewLine);
            try
            {
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
                        Console.WriteLine("Exit");
                        break;
                }
            }
            catch(FormatException exc)
            {
                Console.WriteLine("Exit");
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
