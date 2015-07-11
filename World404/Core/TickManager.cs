namespace World404.Core
{
    using System;
    using System.Linq;

    public static class TickManager
    {
        public static Link Current { get; set; }
    }

    public class Generate
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwyxzeeeiouea";
        private static char RandomLetter => Alphabet[_random.Next(Alphabet.Length)];
        private static readonly Random _random = new Random();
        
        public static string Name(int length) => new string(Enumerable.Range(0, length).Select(x => x == 0 ? char.ToUpper(RandomLetter) : RandomLetter).ToArray());
    }
}