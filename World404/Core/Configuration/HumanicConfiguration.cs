namespace World404.Core.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Tangibles;

    public class HumanicConfiguration : EntityTypeConfiguration<Humanic>
    {
        public HumanicConfiguration()
        {
            ToTable("Humanics");
            HasKey(x => x.ID);
            HasRequired(x => x.Node); // Node
        }
    }
}