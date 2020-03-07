using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public interface shape
    {
        double getarea();
        bool isLegal();
    }

    public class ShapeFactory
    {
        public shape GetShape(String shapeType, double a = 0.0, double b = 0.0, double c = 0.0)
        {
            if (shapeType == null)
            {
                return null;
            }
            shapeType = shapeType.ToUpper();
            if ("TRIANGLE".Equals(shapeType))
            {
                return new triangle(a, b, c);
            }
            else if ("RECTANGLE".Equals(shapeType))
            {
                return new rectangle(a, b);
            }
            else if ("SQUARE".Equals(shapeType))
            {
                return new square(a);
            }
            return null;
        }
    }

    class triangle : shape
    {
        double trside1, trside2, trside3;
        double trarea;
        
        public triangle()
        {
            trside1 = trside2 = trside3 = 0;
        }

        public triangle(double trside1,double trside2,double trside3)
        {
            this.trside1 = trside1;
            this.trside2 = trside2;
            this.trside3 = trside3;
            if (!isLegal())
            {
                Console.WriteLine("Your trangle's sides is illegal!");
            }
        }

        public double getarea()
        {
            trarea = Math.Sqrt(((trside1 + trside2 + trside3) * (trside1 + trside2 - trside3) * (trside1 - trside2 + trside3) * (trside2 - trside1 + trside3) / 16));
            return trarea; 
        }

        public bool isLegal()
        {
            if (trside1 + trside2 <= trside3 || trside1 + trside3 <= trside2 || trside2 + trside3 <= trside1||trside1<=0||trside2<=0||trside3<=0)
            {
                return false;
            }
            else return true;
        }
    }

    class rectangle : shape
    {
        double rtside1,rtside2;
        double rtarea; 

        public rectangle()
        {
            rtside1 = rtside2 = 0;
        }

        public rectangle(double a1,double a2)
        {
            this.rtside1 = a1;
            this.rtside2 = a2;
            if (!isLegal())
            {
                Console.WriteLine("Your rectangle's sides is illegal!");
            }
         }

        public double getarea()
        {
            rtarea = rtside1 * rtside2;
            return rtarea;
        }

        public bool isLegal()
        {
            if (rtside1 <= 0||rtside2<=0) return false;
            else return true;
        }
    }

    class square : rectangle
    {
        double sqside;
        double sqarea;

        public square():base()
        {
            sqside = 0;
        }

        public square(double sqside) : base(sqside, sqside)
        {
            this.sqside = sqside;
            if (isLegal())
            {
                Console.WriteLine("Your square's side is illegal");
            }
        }

        public new double getarea()
        {
            sqarea = sqside * sqside;
            return sqarea;
        }

        public new bool isLegal()
        {
            if (sqside <= 0) return false;
            else return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] strArr = new string[3] { "RECTANGLE", "SQUARE", "TRIANGLE" };
            ShapeFactory shapeFactory = new ShapeFactory();
            Random ran = new Random();
            int rd = 0;
            int i = 0;
            double sumArea = 0.0;
            double a, b, c;
            while (i < 10)
            {
                rd = ran.Next(0, 3);
                a = ran.Next();
                b = ran.Next();
                c = ran.Next();
                string shapeType = strArr[rd];
                shape shape1 = shapeFactory.GetShape(shapeType, a, b, c);
                if (shape1.getarea() != -1)
                {
                    sumArea += shape1.getarea();
                    i++;
                    Console.Write(shapeType + "面积为");
                    Console.WriteLine(shape1.getarea());
                }
            }
            Console.WriteLine("总面积" + sumArea);
            Console.ReadKey();
        }
    }
}
