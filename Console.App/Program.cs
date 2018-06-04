using Calculator.Implementation;
using Calculator.Library;
using Custom.IoC;
using System.Diagnostics;
using System;

namespace Custom.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Register< ICalculator, NormalCalculator> ();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var concreteCalculator = container.GetInstance<ICalculator>();
            stopwatch.Stop();

            var time = stopwatch.ElapsedMilliseconds;
            var sum = concreteCalculator.sum(1, 2);
            Console.WriteLine("Sum is : "+sum+" time : "+time);
            Console.ReadLine();
        }
    }
}
