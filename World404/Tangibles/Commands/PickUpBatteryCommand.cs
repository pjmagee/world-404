namespace World404.Tangibles.Commands
{
    using System;
    using Core;

    public class PickUpBatteryCommand : Command
    {
        public override void Execute()
        {
            Console.WriteLine($" {TickManager.Current.Humanic} picked up battery {ID}");
        }
    }
}