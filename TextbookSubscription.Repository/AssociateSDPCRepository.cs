namespace TextbookSubscription.Repository
{
    using TextbookSubscription.Domain;
    using TextbookSubscription.Domain.Entity;
    using TextbookSubscription.Domain.IRepositories;

    public class AssociateSDPCRepository : EFRepository<AssociateSDPC>, IAssociateSDPCRepository
    {
        public AssociateSDPCRepository(IRepositoryDbContext context)
            :base(context)
        {

        }
    }
}
