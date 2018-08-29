namespace TextbookSubscription.Domain.EntityMapping
{
    using System.Data.Entity.ModelConfiguration;
    using Entity;

    public class ProfessionalClassMap : EntityTypeConfiguration<ProfessionalClass>
    {
        public ProfessionalClassMap()
        {
            // Primary Key
            HasKey(pc => pc.ClassID);

            // Relationships
            // ProfessionalClass : AssociateSDPC = 1 : *
            HasMany(pc => pc.AssociateSDPC).WithRequired(a => a.ProfessionalClass);

            // Property Constraints
            Property(pc => pc.ClassNum).IsRequired().HasMaxLength(20);
            Property(pc => pc.ClassName).IsRequired().HasMaxLength(50);
            Property(pc => pc.Grade).IsRequired().HasMaxLength(20);
            Property(pc => pc.SchoolID).IsRequired().HasMaxLength(50);

            // Table && Column Mappings
            ToTable("ProfessionalClass", "dbo");

            // Ignore
            Ignore(t => t.ID);
        }
    }
}
