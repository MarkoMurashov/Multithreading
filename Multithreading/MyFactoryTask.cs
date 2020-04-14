using Multithreading.Interface;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Multithreading
{
    public class MyFactoryTask: IMultithreadable
    {
        static object locker = new object();

        public Dictionary<int, Stopwatch> Execute(CharFinder finder)
        {
            Dictionary<int, Stopwatch> stopwatchers = new Dictionary<int, Stopwatch>();

            StartCalculate(finder, stopwatchers, 100);
            StartCalculate(finder, stopwatchers, 500);
            StartCalculate(finder, stopwatchers, 5000);
            StartCalculate(finder, stopwatchers, 50000);
            StartCalculate(finder, stopwatchers, 500000);

            return stopwatchers;
        }

        private void StartCalculate(CharFinder finder, Dictionary<int, Stopwatch> stopwatchers, int arrLength)
        {
            finder.ResetValue();

            string[] strToCalculate = new string[arrLength];
            for (int i = 0; i < arrLength; i++)
            {
                strToCalculate[i] = finder.strArr[i];
            }

            Stopwatch stopwatch = new Stopwatch();
            List<Task> tasks = new List<Task>();

            foreach (var s in strToCalculate)
            {
                tasks.Add(new Task(() => finder.GetCharCount(s)));
            }

            stopwatch.Start();
            foreach (var t in tasks)
            {
                t.Start();
            }

            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();
            stopwatchers.Add(arrLength, stopwatch);
        }
    }
}
