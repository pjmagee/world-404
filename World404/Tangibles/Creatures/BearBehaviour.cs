namespace World404.Tangibles.Creatures
{
    using System;
    using System.Collections.Generic;
    using Brains;
    using Commands;

    public class BearBehaviour : CreatureBehaviour
    {
        public override IEnumerable<Command> GetCommands()
        {
            yield return new StrokeCommand();
            yield return new SkinCreatureCommand();
        }

        public override void Execute(Creature creature)
        {
            Console.WriteLine($"{creature} doing nothing at {creature.Node}...");
        }
    }
}