namespace World404.Core
{
    using System.Collections.Generic;

    public class Game : Entity
    {
        public int? Seed { get; set; }

        public List<Link> Links { get; set; } 
    }
}