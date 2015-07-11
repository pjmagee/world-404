namespace World404.Tangibles.Structures
{
    using System.Collections.Generic;
    using Commands;

    public class Barn : Structure
    {
        public override IEnumerable<Command> GetCommands()
        {
            yield return new OpenBarnDoor();
        }
    }
}