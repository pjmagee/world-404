namespace World404.Tangibles.Commands
{
    using System;
    using Core;

    public class SkinCreatureCommand : Command
    {
        public override void Execute()
        {
            Console.WriteLine($"{Owner} was skinned by {TickManager.Current.Humanic}.");
        }
    }
}