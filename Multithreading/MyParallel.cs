using Multithreading.Interface;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Multithreading
{
    class MyParallel : IMultithreadable
    {
        public Dictionary<int, Stopwatch> Execute(CharFinder finder)
        {
            Dictionary<int, Stopwatch> stopWatchers = new Dictionary<int, Stopwatch>();

            StartCalculate(finder, stopWatchers, 100);
            StartCalculate(finder, stopWatchers, 500);
            StartCalculate(finder, stopWatchers, 5000);
            StartCalculate(finder, stopWatchers, 50000);
            StartCalculate(finder, stopWatchers, 500000);

            return stopWatchers;
        }

        private void StartCalculate(CharFinder finder, Dictionary<int, Stopwatch> stopWatchers, int arrLength)
        {
            finder.ResetValue();

            string[] strToCalculate = new string[arrLength];
            for (int i = 0; i < arrLength; i++)
            {
                strToCalculate[i] = finder.strArr[i];
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.ForEach<object>(strToCalculate,
                     finder.GetCharCount);
            stopwatch.Stop();
            stopWatchers.Add(arrLength, stopwatch);
        }
    }
}
