using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlayWrightDemo.Utils
{
    public static class RandomStringHelper
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

        public static string GetStringWithCurrentDate()
        {
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            currentDate = Regex.Replace(currentDate, "[^0-9]", "_"); // Replaces all chars except digits in date-string;
            return currentDate; 
        }
    }
}
