using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2_4__Console
{
    internal class Program
    {
        static void Main()
        {
            double x = 0.10;
            double epsilon = 0.00005;
            double sum = 0;
            double term = x;
            int n = 0;


            while (term >= epsilon)
            {
                sum += term;
                n++;
                term *= (2 * n - 1) * Math.Pow(x, 2) / (2 * n + 1);

            }

            sum *= 2;
            double leftSide = Math.Log((1 + x) / (1 - x));
            Console.WriteLine($"Сумма ряда с точностью 0.5 * 10^-4: {sum:F4} ");
            Console.WriteLine($"Значение ln((1 + x)/(1 - x)): {leftSide:F4} ");
            Console.WriteLine("Количество слагаемых: " + n);
            Console.ReadKey();
        }
    }
}
