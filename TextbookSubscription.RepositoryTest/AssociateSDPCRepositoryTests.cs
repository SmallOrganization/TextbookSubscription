using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain;
using TextbookSubscription.Domain.Entity;
using System.Linq;

namespace TextbookSubscription.RepositoryTests
{
    [TestClass]
    public class AssociateSDPCRepositoryTests
    {
        AssociateSDPCRepository rep = new AssociateSDPCRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllAssociation()
        {
            var totalCount = rep.ExecuteQuery<AssociateSDPC>($"SELECT * FROM Subscription.Associate_StudentDeclaration_ProfessionalClass").Count();
            var associationList = rep.GetAll();
            Assert.AreEqual(totalCount, associationList.Count());
        }
    }
}
