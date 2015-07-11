namespace World404.Tangibles
{
    using System.Collections.Generic;

    public class Area : Node
    {
        public virtual List<Node> Children { get; set; }

        public Area()
        {
            Children = new List<Node>();
        }

        public override string ToString()
        {
            return $"{Name} ({nameof(Area)})";
        }
    }
}