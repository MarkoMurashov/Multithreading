using System;
using Multithreading.Interface;

namespace Multithreading
{
    class Program
    {
        static void Main()
        {
            CharFinder charFinder = new CharFinder();
            StopwatchAnalyzer analyzer = new StopwatchAnalyzer();

            Console.WriteLine("Thread class\n");
            IMultithreadable multithreadable = new MyFactoryThread();
            analyzer.Analyze(multithreadable.Execute(charFinder));

            Console.WriteLine("\nTasks\n");
            multithreadable = new MyFactoryTask();
            analyzer.Analyze(multithreadable.Execute(charFinder));

            Console.WriteLine("\nParallel class\n");
            multithreadable = new MyParallel();
            analyzer.Analyze(multithreadable.Execute(charFinder));

            Console.WriteLine("\nasync / await\n");
            MyAsync myAsync = new MyAsync();
            analyzer.Analyze(myAsync.Execute(charFinder).Result);

            Console.ReadLine();
        }

    }
}
