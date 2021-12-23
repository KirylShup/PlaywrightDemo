using System;
using System.Linq;

namespace PlayWrightDemo.Utils
{
    public static class RandomHelper
    {
        private const string AlphanumericalString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
        private const string NumericalString = "0123456789";

        public static string GetRandomAlphanumericalString (int stringLength)
        {
            var random = new Random ();
            return new string(Enumerable.Repeat(AlphanumericalString, stringLength).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomNumericalString (int stringLength)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(NumericalString, stringLength).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GetRandomNumber (int maxNumber)
        {
            var random = new Random();
            return random.Next (0, maxNumber);
        }
    }
}
