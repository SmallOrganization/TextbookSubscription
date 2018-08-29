namespace TextbookSubscription.Repository
{
    using TextbookSubscription.Domain;
    using TextbookSubscription.Domain.Entity;
    using TextbookSubscription.Domain.IRepositories;

    public class BooksellerRepository : EFRepository<Bookseller>, IBooksellerRepository
    {
        public BooksellerRepository(IRepositoryDbContext context)
            :base(context)
        {

        }
    }
}
