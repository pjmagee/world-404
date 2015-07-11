namespace World404.Core.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Tangibles;

    public class AreaConfiguration : EntityTypeConfiguration<Area>
    {
        public AreaConfiguration()
        {
            ToTable("Areas");
            HasKey(x => x.ID);
        }
    }
}