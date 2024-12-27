using System;

namespace part1A1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Console.WriteLine($"S1 = {CalculateS1(n):F6}");
                Console.WriteLine($"S2 = {CalculateS2(n):F6}");
                Console.WriteLine($"S5 = {CalculateS5(n):F6}");
                Console.WriteLine($"S6 = {CalculateS6(n):F6}");
                Console.WriteLine($"S7 = {CalculateS7(n):F6}");
            }
            else
            {
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }

        static double CalculateS1(int n)
        {
            double S1 = 0;
            for (int i = 1; i <= n; i++)
            {
                double sumOfSquares = 0;
                for (int j = 1; j <= i; j++)
                {
                    sumOfSquares += Math.Pow(j, 2);
                }
                S1 += Math.Pow(-1, i + 1) / sumOfSquares;
            }
            return S1;
        }

        static double CalculateS2(int n)
        {
            double S2 = 1;
            for (int i = 1; i <= n; i++)
            {
                S2 += Math.Pow(-2, i) / Factorial(i);
            }
            return S2;
        }

        static double CalculateS5(int n)
        {
            double S5 = 0;
            for (int i = 1; i <= n; i++)
            {
                S5 += Math.Pow(-1, i + 1) / (2 * i);
            }
            return S5;
        }

        static double CalculateS6(int n)
        {
            double S6 = 0;
            for (int i = 1; i <= n; i++)
            {
                double sum = 0;
                for (int j = 1; j <= i; j++)
                {
                    sum += j;
                }
                S6 += Math.Pow(-1, i + 1) / sum;
            }
            return S6;
        }

        static double CalculateS7(int n)
        {
            double S7 = 1;
            for (int i = 1; i <= n; i++)
            {
                S7 += Math.Pow(2, i) / Factorial(i);
            }
            return S7;
        }

        static double Factorial(int num)
        {
            double result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}