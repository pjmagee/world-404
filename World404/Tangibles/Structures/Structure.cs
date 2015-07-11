namespace World404.Tangibles.Structures
{
    using System.Collections.Generic;
    using Commands;
    using Tangibles;

    public class Structure : Tangible
    {
        public virtual Node Node { get; set; }

        public override IEnumerable<Command> GetCommands()
        {
            yield break;
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({nameof(Structure)})";
        }
    }
}