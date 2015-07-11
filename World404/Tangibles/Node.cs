namespace World404.Tangibles
{
    using System.Collections.Generic;
    using Commands;
    using Intangibles;

    public class Node : Tangible
    {
        public virtual Area Owner { get; set; }
        public string Name { get; set; }
        public virtual List<Tangible> Tangibles { get; set; }
        public virtual List<Intangible> Intangibles { get; set; }
        public virtual List<Node> Siblings { get; set; }

        public Node()
        {
            Tangibles = new List<Tangible>();
            Intangibles = new List<Intangible>();
            Siblings = new List<Node>();
        }

        public override IEnumerable<Command> GetCommands()
        {
            yield return new MoveToCommand();
        }

        public override string ToString()
        {
            return $"{Name} -> ({Owner}) ({nameof(Node)})";
        }
    }
}