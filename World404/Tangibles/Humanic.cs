namespace World404.Tangibles
{
    using System.Collections.Generic;
    using Commands;

    public class Humanic : Tangible
    {
        public string Name { get; set; }
        public virtual Node Node { get; set; }
        public int Energy { get; set; }
        public virtual List<Tangible> Tangibles { get; set; }

        public Humanic()
        {
            Tangibles = new List<Tangible>();
        }

        public override IEnumerable<Command> GetCommands()
        {
            yield break;
        }

        public override string ToString()
        {
            return $"{Name}. Energy: [{Energy}] ({nameof(Humanic)})";
        }
    }
}