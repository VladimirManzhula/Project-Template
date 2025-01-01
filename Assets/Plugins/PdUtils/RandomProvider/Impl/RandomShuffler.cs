using System;
using System.Collections.Generic;

namespace PdUtils.RandomProvider.Impl
{
    public static class RandomShuffler
    {
        private static Random _random = new();
        
        public static void Random<T>(List<T> list)
        {
            _random = new Random();
            var count = list.Count;
            for (var i = count - 1; i > 0; i--)
            {
                var j = _random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}