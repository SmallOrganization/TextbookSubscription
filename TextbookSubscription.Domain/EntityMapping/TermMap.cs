namespace TextbookSubscription.Domain.EntityMapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Entity;

    public class TermMap : EntityTypeConfiguration<Term>
    {
        public TermMap()
        {
            // Primary Key
            HasKey(t => t.TermNum);
            Property(t => t.TermNum).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Property Constraints
            Property(t => t.TermName).IsRequired().HasMaxLength(20);
            Property(t => t.IsCurrentTerm).IsRequired().IsFixedLength().HasMaxLength(1);
            Property(t => t.BeginDate).IsRequired();
            Property(t => t.EndDate).IsRequired();

            // Table && Column Mappings
            ToTable("Term", "dbo");
            Property(t => t.TermName).HasColumnName("Term");

            // Ingore property
            Ignore(t => t.ID);
        }
    }
}
