namespace World404.Brains
{
    using System;
    using Tangibles;

    public class SimpleBrain : Brain
    {
        public override void Execute(Humanic humanic)
        {
            foreach (var item in humanic.Tangibles)
            {
                Console.WriteLine($"{humanic} found a {item}");
            }
        }
    }
}