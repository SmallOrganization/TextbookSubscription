namespace TextbookSubscription.Repository
{
    using TextbookSubscription.Domain.Entity;
    using TextbookSubscription.Domain;
    using TextbookSubscription.Domain.IRepositories;

    public class ProfessionalClassRepository : EFRepository<ProfessionalClass>, IProfessionalClassRepository
    {
        public ProfessionalClassRepository(IRepositoryDbContext context)
            :base(context)
        {

        }

        public ProfessionalClass GetByName(string className)
        {
            return Single(pc => pc.ClassName == className);
        }
    }
}
