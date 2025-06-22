using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();

        Console.WriteLine("Enter your first message:");
        string msg1 = Console.ReadLine();
        logger1.Log(msg1);

        Logger logger2 = Logger.GetInstance();

        Console.WriteLine("Enter your second message:");
        string msg2 = Console.ReadLine();
        logger2.Log(msg2);

        if (logger1 == logger2)
        {
            Console.WriteLine("Both refer to the same instance.");
        }
        else
        {
            Console.WriteLine("Different instances exist! Singleton failed.");
        }
    }
}
