using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1=new int[99];
            int[] isSuShu = new int[99];
            int a1num = 2;

            for(int i = 0; i < a1.Length; i++)
            {
                a1[i] = a1num;
                isSuShu[i] = 1;
                a1num++;
            }

            for (int i = 0; i < a1.Length; i++)
            {
                if (isSuShu[i] == 1)
                {
                    for (int k = 2; k * a1[i] <= 100; k++) {
                        int y = k * a1[i];
                        isSuShu[y-2] = 0;
                    }
                }
            }

            Console.Write("2到100的素数有：");
            for (int i = 0; i < isSuShu.Length; i++)
                if (isSuShu[i] == 1)
                    Console.Write(a1[i]+" ");
            Console.ReadKey();
        }
    }
}
