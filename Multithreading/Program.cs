using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Multithreading.Interface;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            CharFinder charFinder = new CharFinder();

            Console.WriteLine("Thread class\n");
            IMultihtreadable multihtreadable = new MyFactoryThread();
            multihtreadable.Execute(charFinder);

            Console.WriteLine("\nTasks\n");
            multihtreadable = new MyFactoryTask();
            multihtreadable.Execute(charFinder);

            Console.WriteLine("\nParallel class\n");
            multihtreadable = new MyParallel();
            multihtreadable.Execute(charFinder);

            Console.WriteLine("\nasync / await\n");
            multihtreadable = new MyAsync();
            multihtreadable.Execute(charFinder);

            Console.ReadLine();
        }
    }
}
