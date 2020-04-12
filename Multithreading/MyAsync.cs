using Multithreading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    public class MyAsync : IMultihtreadable
    {
        public async void Execute(CharFinder finder)
        {
            await finder.CalculateCharCountAsync(100);
            await finder.CalculateCharCountAsync(500);
            await finder.CalculateCharCountAsync(5000);
            await finder.CalculateCharCountAsync(50000);
            await finder.CalculateCharCountAsync(500000);
        }

    }
}
