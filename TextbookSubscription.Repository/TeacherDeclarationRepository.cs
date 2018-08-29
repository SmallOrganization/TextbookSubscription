namespace TextbookSubscription.Repository
{
    using TextbookSubscription.Domain;
    using TextbookSubscription.Domain.Entity;
    using TextbookSubscription.Domain.IRepositories;

    public class TeacherDeclarationRepository : EFRepository<TeacherDeclaration>, ITeacherDeclarationRepository
    {
        public TeacherDeclarationRepository(IRepositoryDbContext context)
            :base(context)
        {

        }
    }
}
