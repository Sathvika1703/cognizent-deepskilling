using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("====Output====");
        Console.WriteLine("Enter current value:");
        double currentValue = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter annual growth rate (as decimal, e.g. 0.05 for 5%):");
        double growthRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter number of Years:");
        int years = Convert.ToInt32(Console.ReadLine());

        double futureValue = CalculateFutureValue(currentValue, growthRate, years);

        Console.WriteLine($"\nFuture Value after {years} years: {futureValue:F2}");
    }

    static double CalculateFutureValue(double currentValue, double growthRate, int years)
    {
        if (years == 0)
            return currentValue;

        return CalculateFutureValue(currentValue * (1 + growthRate), growthRate, years - 1);
    }
}
