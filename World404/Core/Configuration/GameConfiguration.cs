namespace World404.Core.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            ToTable("Games");
            HasKey(x => x.ID);
            Property(x => x.Seed).IsOptional();
            HasMany(x => x.Links).WithRequired(x => x.Game);
        }
    }
}