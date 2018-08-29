namespace TextbookSubscription.Domain.EntityMapping
{
    using Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BooksellerMap : EntityTypeConfiguration<Bookseller>
    {
        public BooksellerMap()
        {
            // Primary Key
            HasKey(b => b.BooksellerID);

            // Property Constraints
            Property(b => b.BooksellerNum).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.BooksellerName).IsRequired().HasMaxLength(50);
            Property(b => b.Contact).HasMaxLength(50);
            Property(b => b.Telephone).HasMaxLength(20);

            // Table && Column Mapping
            ToTable("Bookseller", "dbo");

            // Ignore
            Ignore(b => b.ID);
        }
    }
}
