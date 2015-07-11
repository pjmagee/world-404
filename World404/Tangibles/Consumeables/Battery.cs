namespace World404.Tangibles.Consumeables
{
    using System.Collections.Generic;
    using Commands;

    public class Battery : Consumable
    {       
        public override IEnumerable<Command> GetCommands()
        {
            yield return new PickUpBatteryCommand();        
        }
    }
}