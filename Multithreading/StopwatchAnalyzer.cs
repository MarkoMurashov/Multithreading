using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Multithreading
{
    public class StopwatchAnalyzer
    {
        public void Analyze(Dictionary<int, Stopwatch> stopwatchDict)
        {
            foreach(var stopwatch in stopwatchDict)
            {
                Console.WriteLine("Done for the length {0} with {1} ms", stopwatch.Key, stopwatch.Value.ElapsedMilliseconds);
            }
        }
    }
}
