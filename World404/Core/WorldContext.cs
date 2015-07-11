namespace World404.Core
{
    using System.Data.Entity;
    using Intangibles;
    using Tangibles;
    using Tangibles.Creatures;
    using Tangibles.Structures;

    public class WorldContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Tangible> Tangibles { get; set; }
        public DbSet<Intangible> Intangibles { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Creature> Creatures { get; set; } 
        public DbSet<Humanic> Humanics { get; set; }
        public DbSet<Structure> Structures { get; set; }

        public WorldContext() : base("DefaultConnection")
        {
            // Enabled by default
            // Configuration.LazyLoadingEnabled = true;
            // Configuration.ProxyCreationEnabled = true;
            // Configuration.AutoDetectChangesEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(WorldContext).Assembly);

            //modelBuilder
            //    .Configurations
            //    .Add(new TangibleConfiguration())
            //    .Add(new HumanicConfiguration())
            //    .Add(new AreaConfiguration())
            //    .Add(new NodeConfiguration())
            //    .Add(new CreatureConfiguration())
            //    ;
        }
    }
}