namespace World404.Tangibles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commands;
    using Core;

    public abstract class Tangible : Entity
    {
        public IEnumerable<Command> Commands => GetCommands(); 

        public abstract IEnumerable<Command> GetCommands();
        
        public override string ToString()
        {
            return $"{GetType().Name} {ID.ToString().Split('-').First()} ({nameof(Tangible)})";
        }
    }
}