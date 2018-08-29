namespace TextbookSubscription.Domain.EntityMapping
{
    using System.Data.Entity.ModelConfiguration;
    using Entity;

    public class SchoolMap : EntityTypeConfiguration<School>
    {
        public SchoolMap()
        {
            // PrimaryKey
            HasKey(s => s.SchoolID);

            // Property Constraints
            Property(s => s.SchoolNum).IsRequired().HasMaxLength(20);
            Property(s => s.SchoolName).IsRequired().HasMaxLength(50);
            Property(s => s.Contact).HasMaxLength(50);
            Property(s => s.Telephone).HasMaxLength(20);

            // Table
            ToTable("School", "dbo");

            // Ignore
            Ignore(s => s.ID);
        }
    }
}
