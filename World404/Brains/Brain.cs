namespace World404.Brains
{
    using Core;
    using Tangibles;

    public abstract class Brain : Entity
    {
        public abstract void Execute(Humanic humanic);
    }
}