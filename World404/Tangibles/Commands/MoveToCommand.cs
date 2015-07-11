namespace World404.Tangibles.Commands
{
    using System;
    using Core;

    public class MoveToCommand : Command
    {
        public override void Execute()
        {
            TickManager.Current.Humanic.Node = (Node) Owner;
            Console.WriteLine($"{TickManager.Current.Humanic} moved to {Owner.ID}");
        }
    }
}