namespace TextbookSubscription.Domain.EntityMapping
{
    using Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    public class StudentDeclarationMap : EntityTypeConfiguration<StudentDeclaration>
    {
        public StudentDeclarationMap()
        {
            // Primary Key
            HasKey(sd => sd.DeclarationID);

            // Relationships
            // StudentDeclaration : Textbook = 1 : 1
            HasRequired(sd => sd.Textbook).WithOptional();
            // StudentDeclaration : AssociateSDPC = 1 : *
            HasMany(sd => sd.AssociateSDPC).WithRequired(a => a.StudentDeclaration);

            // Property Constraints
            Property(sd => sd.DeclarationNum).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(sd => sd.Term).IsRequired().HasMaxLength(20);
            Property(sd => sd.SchoolID).IsRequired().HasMaxLength(50);
            Property(sd => sd.SchoolName).IsRequired().HasMaxLength(50);
            Property(sd => sd.DepartmentID).IsRequired().HasMaxLength(50);
            Property(sd => sd.DepartmentName).IsRequired().HasMaxLength(50);
            Property(sd => sd.CourseID).IsRequired().HasMaxLength(50);
            Property(sd => sd.CourseCode).HasMaxLength(50);
            Property(sd => sd.CourseName).IsRequired().HasMaxLength(50);
            Property(sd => sd.Telephone).HasMaxLength(50);
            Property(sd => sd.ImportDate).IsRequired();
            Property(sd => sd.ApprovalStatus).IsRequired().HasMaxLength(50);
            Property(sd => sd.Priority).IsRequired().HasMaxLength(50);
            Property(sd => sd.DataSign).IsRequired().IsFixedLength().HasMaxLength(1);
            Property(sd => sd.NeedTextbook).IsRequired().IsFixedLength().HasMaxLength(1);
            Property(sd => sd.Remark).HasMaxLength(50);

            // Table && Column Mappings
            ToTable("StudentDeclaration", "Subscription");

            // Ignore
            Ignore(sd => sd.ID);
        }
    }
}
