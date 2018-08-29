namespace TextbookSubscription.Repository
{
    using TextbookSubscription.Domain;
    using TextbookSubscription.Domain.Entity;
    using TextbookSubscription.Domain.IRepositories;

    public class TextbookRepository : EFRepository<Textbook>, ITextbookRepository
    {
        public TextbookRepository(IRepositoryDbContext context)
            :base(context)
        {

        }
    }
}
