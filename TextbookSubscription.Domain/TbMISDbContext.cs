namespace TextbookSubscription.Domain.EFDbContext
{
    using System.Data.Entity;
    using Entity;
    using EntityMapping;

    public partial class TbMISDbContext : DbContext
    {
        public TbMISDbContext()
            : base("name=TbMISDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TermMap());
            modelBuilder.Configurations.Add(new ProfessionalClassMap());
            modelBuilder.Configurations.Add(new SchoolMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new TextbookMap());
            modelBuilder.Configurations.Add(new BooksellerMap());
            modelBuilder.Configurations.Add(new StudentDeclarationMap());
            modelBuilder.Configurations.Add(new TeacherDeclarationMap());
            modelBuilder.Configurations.Add(new AssociateSDPCMap());
        }

        public virtual DbSet<Term> Term { get; set; }
        public virtual DbSet<ProfessionalClass> ProfessionalClass {get;set;}
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Textbook> Textbook { get; set; }
        public virtual DbSet<Bookseller> Bookseller { get; set; }
        public virtual DbSet<StudentDeclaration> StudentDeclaration { get; set; }
        public virtual DbSet<TeacherDeclaration> TeacherDeclaration { get; set; }
        public virtual DbSet<AssociateSDPC> AssociateSDPC { get; set; }
    }

}
