namespace TextbookSubscription.Domain.EntityMapping
{
    using System.Data.Entity.ModelConfiguration;
    using Entity;

    public class AssociateSDPCMap : EntityTypeConfiguration<AssociateSDPC>
    {
        public AssociateSDPCMap()
        {
            // Primary Key
            HasKey(a => new { a.ClassID, a.DeclarationID });

            // Relationships
            // AssociateSDPC : ProfessionalClass = * : 1
            HasRequired(a => a.ProfessionalClass).WithMany(pc => pc.AssociateSDPC);
            // AssociateSDPC : StudentDeclaration = * : 1
            HasRequired(a => a.StudentDeclaration).WithMany(pc => pc.AssociateSDPC);

            // Property Constraints
            Property(a => a.DeclarationCount).IsRequired();

            // Table && Column Mapping
            ToTable("Associate_StudentDeclaration_ProfessionalClass", "Subscription");

            // Ignore
            Ignore(a => a.ID);
        }
    }
}
