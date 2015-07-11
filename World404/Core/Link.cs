namespace World404.Core
{
    using System;
    using Brains;
    using Tangibles;

    public class Link : Entity
    {
        private Brain _brain;

        public string Type { get; set; }

        public Brain Brain => _brain ?? (_brain = Activator.CreateInstance(System.Type.GetType(Type)) as Brain);
        
        public virtual Game Game { get; set; }

        public virtual Humanic Humanic { get; set; }
    }
}