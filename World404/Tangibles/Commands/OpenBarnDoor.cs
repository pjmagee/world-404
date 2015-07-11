namespace World404.Tangibles.Commands
{
    using System;
    using Core;

    public class OpenBarnDoor : Command
    {
        public override void Execute()
        {
            Console.WriteLine($"{TickManager.Current.Humanic} opens the {Owner} door.");
        }
    }
}