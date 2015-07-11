namespace World404.Core.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Tangibles;

    public class NodeConfiguration : EntityTypeConfiguration<Node>
    {
        public NodeConfiguration()
        {
            ToTable("Nodes");
            HasKey(x => x.ID);
            HasMany(x => x.Siblings);
            HasOptional(x => x.Owner);
        }
    }
}