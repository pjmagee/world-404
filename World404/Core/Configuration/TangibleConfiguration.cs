namespace World404.Core.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Tangibles;

    public class TangibleConfiguration : EntityTypeConfiguration<Tangible>
    {
        public TangibleConfiguration()
        {
            //ToTable("Tangibles");
            //HasKey(x => x.ID);
        }
    }
}