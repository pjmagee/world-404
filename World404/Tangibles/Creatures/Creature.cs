namespace World404.Tangibles.Creatures
{
    using System;
    using System.Collections.Generic;
    using Brains;
    using Commands;
    using Core;

    public class Creature : Tangible
    {
        private CreatureBehaviour _creatureBehaviour;

        public string Name { get; set; }
        public virtual Mode Mode { get; set; }
        public virtual Node Node { get; set; }
        public string Type { get; set; }
        
        private CreatureBehaviour Behaviour => _creatureBehaviour ?? (_creatureBehaviour = Activator.CreateInstance(System.Type.GetType(Type)) as CreatureBehaviour);

        public override IEnumerable<Command> GetCommands()
        {
            return Behaviour.GetCommands();
        }

        public void Execute()
        {
            Behaviour.Execute(this);
        }

        public override string ToString()
        {
            return $"{Mode} {Name} ({nameof(Creature)})";
        }
    }
}