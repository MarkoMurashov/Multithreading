using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multithreading
{
    public class CharFinder
    {

        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int arrLength = 500000;
        private Random random;

        public Dictionary<char, int> result { get; private set; }
        public string[] strArr { get; private set; }

        public CharFinder()
        {
            random = new Random();
            result = new Dictionary<char, int>();
            strArr = new string[arrLength];

            InitializeDictionary();
            InitializeStrArray();
        }

        private string GetRandomString(int length, string chars)
        {
            return new string(Enumerable.Repeat(chars, length)
              .Select(str => str[random.Next(str.Length)]).ToArray());
        }

        private void InitializeDictionary()
        {
            foreach (char symbol in chars)
            {
                result.Add(symbol, 0);
            }
        }

        private void InitializeStrArray()
        {
            for (int i = 0; i < arrLength; i++)
            {
                strArr[i] = GetRandomString(1000, chars);
            }
        }

        public void ResetValue()
        {
            foreach (char symbol in chars)
            {
                result[symbol] = 0;
            }
        }

        public void GetCharCount(object str)
        {
            foreach (char symbol in (string)str)
            {               
                result[symbol]++;         
            }
        }

        public async Task GetCharCountAsync(object str)
        {
            await Task.Run(() => GetCharCount(str));
        }

    }
}
