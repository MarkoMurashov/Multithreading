using System.Collections.Generic;
using System.Diagnostics;

namespace Multithreading.Interface
{
    public interface IMultithreadable
    {
        Dictionary<int, Stopwatch> Execute(CharFinder finder);
    }
}
