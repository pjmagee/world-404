namespace World404.Core.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    public class LinkConfiguration : EntityTypeConfiguration<Link>
    {
        public LinkConfiguration()
        {
            ToTable("Links");
            HasKey(x => x.ID);
            HasRequired(x => x.Humanic);
            Ignore(x => x.Brain);
            Property(x => x.Type);
        }
    }
}