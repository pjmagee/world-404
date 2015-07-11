namespace World404.Tangibles.Commands
{
    using System;
    using Core;

    public class StrokeCommand : Command
    {
        public override void Execute()
        {
            Console.WriteLine($"{TickManager.Current.Humanic} strokes {Owner}");
        }
    }
}