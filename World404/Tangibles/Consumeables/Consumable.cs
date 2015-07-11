namespace World404.Tangibles.Consumeables
{
    public abstract class Consumable : Tangible
    {
        public Tangible Owner { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} ({nameof(Consumable)})";
        }
    }
}