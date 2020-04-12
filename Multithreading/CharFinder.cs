using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    public class CharFinder
    {
        #region const

        private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly int arrLength = 500000;

        #endregion

        #region fields

        private Random random;
        private Dictionary<char, int> result;
        private string[] strArr;

        #endregion

        #region c-tors

        public CharFinder()
        {
            random = new Random();
            result = new Dictionary<char, int>();
            strArr = new string[arrLength];

            InitializeDictionary();
            InitializeStrArray();


        }

        #endregion

        #region methods

        private string GetRandomString(int length, string chars)
        {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void InitializeDictionary()
        {
            foreach (char c in chars)
            {
                result.Add(c, 0);
            }
        }

        private void InitializeStrArray()
        {
            for (int i = 0; i < arrLength; i++)
            {
                strArr[i] = GetRandomString(1000, chars);
            }
        }

        private void ResetValue()
        {
            foreach (char c in chars)
            {
                result[c] = 0;
            }
        }

        private void GetCharCount(string s)
        {
            foreach (char c in s)
            {
                result[c]++;
            }
        }

        public void CalculateCharCount(object arrLength) 
        {
            if((int)arrLength < 0 || (int)arrLength > strArr.Length)
            {
                return;
            }

            ResetValue();

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i=0; i< (int)arrLength; i++)
            {
                GetCharCount(strArr[i]);
            }
            stopWatch.Stop();

            Console.WriteLine("Done for {0} with {1} ms", arrLength, stopWatch.ElapsedMilliseconds);
        }

        public async Task CalculateCharCountAsync(object arrLength)
        {
            await Task.Run(() => CalculateCharCount(arrLength));
        }

        #endregion
    }
}
