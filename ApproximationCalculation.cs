using System.Diagnostics;
namespace ApproximationCalculation
{

    using System;

    class Program
    {
        static void Main()
        {
            double epsilonPi = 1e-6;
            double piApprox = ApproximatePi(epsilonPi);
            Console.WriteLine($"Approximated value of π: {piApprox}");
            double x = Math.PI / 4;
            double epsilonSin = 1e-6;
            double sinApprox = ApproximateSin(x, epsilonSin);
            Console.WriteLine($"Approximated value of sin({x}): {sinApprox}");
        }

        static double ApproximatePi(double epsilon)
        {
            double sum = 0.0;
            int n = 0;
            double term;

            do
            {
                term = Math.Pow(-1, n) / (2 * n + 1);
                sum += term;
                n++;
            } while (Math.Abs(term) >= epsilon);

            return sum * 4;
        }

        static double ApproximateSin(double x, double epsilon)
        {
            double sum = 0.0;
            int n = 0;
            double term;

            do
            {
                term = Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / Factorial(2 * n + 1);
                sum += term;
                n++;
            } while (Math.Abs(term) >= epsilon);

            return sum;
        }

        static double Factorial(int n)
        {
            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }