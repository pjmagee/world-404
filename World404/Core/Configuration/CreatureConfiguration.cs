namespace World404.Core.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Tangibles.Creatures;

    public class CreatureConfiguration : EntityTypeConfiguration<Creature>
    {
        public CreatureConfiguration()
        {
            ToTable("Creatures");
            HasKey(x => x.ID);
            Property(x => x.Name);
            Property(x => x.Type);
            HasRequired(x => x.Node);
        }
    }
}