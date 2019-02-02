using System;

namespace EPAM.Task1._6_FontAdjustment
{
    public class FontAdjustment
    {
        private bool bold = false;
        private bool italic = false;
        private bool underline = false;

        public void Format()
        {
            Console.Write("Font property: ");
            if (this.bold)
            {
                Console.Write("Bold ");
            }

            if (this.italic)
            {
                Console.Write("Italic ");
            }

            if (this.underline)
            {
                Console.Write("Underline ");
            }

            if (!this.bold && !this.italic && !this.underline)
            {
                Console.Write("None");
            }

            Console.WriteLine("{0}Enter:{0}\t1: bold{0}\t2: italic{0}\t3: underine{0}\tAnother value for exit", Environment.NewLine);
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        this.bold = !this.bold;
                        this.Format();
                        break;

                    case 2:
                        this.italic = !this.italic;
                        this.Format();
                        break;

                    case 3:
                        this.underline = !this.underline;
                        this.Format();
                        break;

                    default:
                        Console.WriteLine("Exit");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Exit");
            }
        }
    }

    public class FontAdjustmentDemo
    {
        public static void Main()
        {
            FontAdjustment ob = new FontAdjustment();
            ob.Format();
        }
    }
}