namespace TextbookSubscription.Domain.EntityMapping
{
    using System.Data.Entity.ModelConfiguration;
    using Entity;

    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            // Primary Key
            HasKey(d => d.DepartmentID);

            // Relationships
            // Department : School = * : 1
            HasRequired(d => d.School).WithMany(s => s.Departments);

            // Property Constraints
            Property(d => d.DepartmentNum).IsRequired().HasMaxLength(20);
            Property(d => d.DepartmentName).IsRequired().HasMaxLength(50);
            Property(d => d.SchoolID).IsRequired().HasMaxLength(50);
            Property(d => d.Contact).HasMaxLength(50);
            Property(d => d.Telephone).HasMaxLength(20);

            // Table && Column Mappings
            ToTable("Department", "dbo");

            // Ignore
            Ignore(t => t.ID);
        }
    }
}
