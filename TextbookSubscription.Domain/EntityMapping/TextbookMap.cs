namespace TextbookSubscription.Domain.EntityMapping
{
    using Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TextbookMap : EntityTypeConfiguration<Textbook>
    {
        public TextbookMap()
        {
            // Primary Key
            HasKey(tb => tb.TextbookID);

            // Property Constraints
            Property(tb => tb.TextbookNum2).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(tb => tb.TextbookNum).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(tb => tb.Isbn).IsRequired().HasMaxLength(20);
            Property(tb => tb.TextbookName).IsRequired().HasMaxLength(200);
            Property(tb => tb.Press).IsRequired().HasMaxLength(50);
            Property(tb => tb.Author).IsRequired().HasMaxLength(50);
            Property(tb => tb.Edition).IsRequired().HasMaxLength(20);
            Property(tb => tb.PrintingCount).IsRequired().HasMaxLength(20);
            Property(tb => tb.RetailPrice).IsRequired().HasColumnType("numeric");
            Property(tb => tb.TextbookType).HasMaxLength(50);
            Property(tb => tb.Translator).HasMaxLength(50);
            Property(tb => tb.Language).HasMaxLength(20);
            Property(tb => tb.Page).IsOptional();
            Property(tb => tb.Summary).HasMaxLength(200);
            Property(tb => tb.Catalog).HasMaxLength(200);
            Property(tb => tb.IsSelfCompile).IsFixedLength().HasMaxLength(1);

            // Table && Column Mappings
            ToTable("Textbook", "dbo");

            // Ignore
            Ignore(tb => tb.ID);
        }
    }
}
