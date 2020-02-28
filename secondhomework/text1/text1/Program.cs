using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text1
{
    class Program
    {


        static void Main(string[] args)
        {
            while (true)
            {
                int data;
                Console.WriteLine("请输入一个正整数：");
                try
                {
                    data = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("输入错误，请输入整数");
                    Console.ReadKey();
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("输入错误，数据过大");
                    Console.ReadKey();
                    return;
                }

                if (data == 0 || data == 1)
                {
                    Console.WriteLine(data + "没有素数因子");
                }
                else if (data < 0)
                {
                    Console.WriteLine("请输入正整数");
                }
                else
                {
                    Console.Write("它的素数因子有：");
                    int dev = 2;
                    while (data != 1)
                    {
                        if (data % dev == 0)
                        {
                            Console.Write(dev + " ");
                            while (data % dev == 0)
                            {
                                data /= dev;
                            }
                        }
                        dev++;
                    }
                }
            }
        }
    }
}
