using Multithreading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    public class MyFactoryTask: IMultihtreadable
    {
        public void Execute(CharFinder finder)
        {
            Task[] tasks = new Task[5]
            {
                new Task(() => finder.CalculateCharCount(100)),
                new Task(() => finder.CalculateCharCount(500)),
                new Task(() => finder.CalculateCharCount(5000)),
                new Task(() => finder.CalculateCharCount(50000)),
                new Task(() => finder.CalculateCharCount(500000))
            };


            foreach (var t in tasks)
                t.Start();

            Task.WaitAll(tasks);
        }
    }
}
