using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie10_1__Console
{
    class Program
    {
        // Рекурсивная функция для вычисления n-го члена последовательности
        static double CalculateB(int n)
        {
            if (n == 1)
            {
                return 5;
            }

            //b(n+1) = b(n) / (n^2 + n + 1)
            return CalculateB (n - 1) / (Math.Pow(n - 1, 2) + (n - 1) + 1);
        }
        static void KeyProtect(out int x)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out x) && x > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введены неверные значения. Попробуйте еще раз:");
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("Введите номер члена последовательности n:");
            int n;
            KeyProtect(out n);

            double result = CalculateB(n);
            Console.WriteLine($"b{n} = {result}");
            Console.ReadKey();
        }
    }
}
