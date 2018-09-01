namespace TextbookSubscription.Domain.EntityMapping
{
    using Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TeacherDeclarationMap : EntityTypeConfiguration<TeacherDeclaration>
    {
        public TeacherDeclarationMap()
        {
            // Primary Key
            HasKey(td => td.DeclarationID);

            // Foreign Key
            HasRequired(td => td.Textbook).WithOptional();

            // Property Constraints
            Property(td => td.DeclarationNum).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(td => td.Term).IsRequired().HasMaxLength(20);
            Property(td => td.SchoolID).IsRequired().HasMaxLength(50);
            Property(td => td.SchoolName).IsRequired().HasMaxLength(50);
            Property(td => td.DepartmentID).IsRequired().HasMaxLength(50);
            Property(td => td.DepartmentName).IsRequired().HasMaxLength(50);
            Property(td => td.CourseID).IsRequired().HasMaxLength(50);
            Property(td => td.CourseCode).HasMaxLength(50);
            Property(td => td.CourseName).IsRequired().HasMaxLength(50);
            Property(td => td.Telephone).HasMaxLength(50);
            Property(td => td.ImportDate).IsRequired();
            Property(td => td.ApprovalStatus).IsRequired().HasMaxLength(50);
            Property(td => td.Priority).IsRequired().HasMaxLength(50);
            Property(td => td.DataSign).IsRequired();
            Property(td => td.NeedTextbook).IsRequired();
            Property(td => td.Remark).HasMaxLength(50);

            // Table && Column Mappings
            ToTable("TeacherDeclaration", "Subscription");

            // Ignore
            Ignore(td => td.ID);
        }
    }
}
