namespace World404.Tangibles.Creatures
{
    using System.Collections.Generic;
    using Tangibles.Commands;

    public abstract class CreatureBehaviour
    {
        public abstract IEnumerable<Command> GetCommands(); 
        public abstract void Execute(Creature creature);
    }
}