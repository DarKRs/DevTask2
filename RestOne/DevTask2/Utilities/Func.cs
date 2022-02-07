using System;
using System.Linq;

namespace DevTask2.Utilities
{
    public static class Func
    {
        private static Random random = new Random();
        public static string RandStr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, random.Next(length) + 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandInt(int max = int.MaxValue)
        {
            return random.Next(max);
        }
        public static DateTime RandDay()
        {
            DateTime start = new DateTime(1937, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }


    }
}
