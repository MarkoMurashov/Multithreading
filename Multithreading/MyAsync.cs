using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Multithreading
{
    public class MyAsync
    {
        public async Task<Dictionary<int, Stopwatch>> Execute(CharFinder finder)
        {
            Dictionary<int, Stopwatch> stopwatchers = new Dictionary<int, Stopwatch>();

            await StartCalculate(finder, stopwatchers, 100);
            await StartCalculate(finder, stopwatchers, 500);
            await StartCalculate(finder, stopwatchers, 5000);
            await StartCalculate(finder, stopwatchers, 50000);
            await StartCalculate(finder, stopwatchers, 500000);

            return stopwatchers;
        }

        private async Task StartCalculate(CharFinder finder, Dictionary<int, Stopwatch> stopwatchers, int arrLength)
        {
            finder.ResetValue();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < arrLength; i++)
            {
                await finder.GetCharCountAsync(finder.strArr[i]);
            }
            stopwatch.Stop();
            stopwatchers.Add(arrLength, stopwatch);
        }

    }
}
