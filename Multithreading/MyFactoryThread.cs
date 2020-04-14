using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Multithreading.Interface;

namespace Multithreading
{
    public class MyFactoryThread : IMultithreadable
    {
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
            Stopwatch stopwatch = new Stopwatch();

            finder.ResetValue();

            stopwatch.Start();
            for (int j = 0; j < arrLength; j++)
            {
                new Thread(finder.GetCharCount).Start(finder.strArr[j]);
            }
            stopwatch.Stop();
            stopwatchers.Add(arrLength, stopwatch);
        }
    }
}
