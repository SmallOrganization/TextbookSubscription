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

        public ProfessionalClass GetProfessionalClass(string classID)
        {
            return Single(a => a.ClassID == classID).ProfessionalClass;
        }

        public StudentDeclaration GetStudentDeclaration(string declarationID)
        {
            return Single(a => a.DeclarationID == declarationID).StudentDeclaration;
        }
    }
}
