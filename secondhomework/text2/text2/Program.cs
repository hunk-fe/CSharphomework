using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text2
{
    class Program
    {
        static void Main(string[] args)
        {

            int length;
            int[] a1;

            Console.Write("请输入数组数字个数：");
            try
            {
                length = Convert.ToInt32(Console.ReadLine());
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

            if (length < 0)
            {
                Console.WriteLine("请输入一个正整数");
            }
            else
            {
                a1 = new int[length];

                for (int i = 0; i < length; i++)
                {
                    Console.Write("请输入一个数字：");
                    try
                    {
                        a1[i] = Convert.ToInt32(Console.ReadLine());
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
                }
                maxmin(a1);
                avarage(a1);
                sum(a1);
            }
        }

        public static void maxmin(int[] a)
        {
            int max = a[0];
            int min = a[0];
            for(int i = 1; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
                else if (a[i] < min) min = a[i];
            }
            Console.WriteLine("该数组的最大最小值分别是："+max + " " + min);
        }

        public static void avarage(int[] a)
        {
            int add = a[0];
            double avarage = 0.0; 
            for(int i = 1; i <a.Length; i++)
            {
                add += a[i];
            }
            avarage = (double)add / a.Length;
            Console.WriteLine("该数组的平均数为：" + avarage);
        }

        public static void sum(int[] a)
        {
            int sum = a[0];
            for(int i = 1; i < a.Length; i++)
            {
                sum += a[i];
            }
            Console.WriteLine("该数组的和为：" + sum); 
        }
    }
 }
