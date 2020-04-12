using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Multithreading.Interface;

namespace Multithreading
{
    public class MyFactoryThread : IMultihtreadable
    {
        public void Execute(CharFinder finder)
        {
            Thread mainThread = new Thread(finder.CalculateCharCount);
            mainThread.Start(100);

            mainThread = new Thread(finder.CalculateCharCount);
            mainThread.Start(500);

            mainThread = new Thread(finder.CalculateCharCount);
            mainThread.Start(5000);

            mainThread = new Thread(finder.CalculateCharCount);
            mainThread.Start(50000);

            mainThread = new Thread(finder.CalculateCharCount);
            mainThread.Start(500000);

            mainThread.Join();
        }
    }
}
