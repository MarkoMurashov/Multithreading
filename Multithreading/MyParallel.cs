using Multithreading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class MyParallel : IMultihtreadable
    {
        public void Execute(CharFinder finder)
        {
            Parallel.ForEach<object>(new List<object>() { 100, 500, 5000, 50000, 500000 },
                     finder.CalculateCharCount);
        }
    }
}
