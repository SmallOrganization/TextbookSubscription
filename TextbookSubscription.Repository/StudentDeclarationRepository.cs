namespace TextbookSubscription.Repository
{
    using TextbookSubscription.Domain;
    using TextbookSubscription.Domain.Entity;
    using TextbookSubscription.Domain.IRepositories;

    public class StudentDeclarationRepository : EFRepository<StudentDeclaration>, IStudentDeclarationRepository
    {
        public StudentDeclarationRepository(IRepositoryDbContext context)
            :base(context)
        {

        }

    }
}
