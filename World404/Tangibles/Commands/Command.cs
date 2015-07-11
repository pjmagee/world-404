namespace World404.Tangibles.Commands
{
    using Core;

    public abstract class Command : Entity
    {
        public Tangible Owner { get; set; }

        public abstract void Execute();
    }
}