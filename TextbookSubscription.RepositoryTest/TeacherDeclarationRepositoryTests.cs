using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookSubscription.Domain.Entity;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain;
using System.Linq;

namespace TextbookSubscription.RepositoryTests
{
    [TestClass]
    public class TeacherDeclarationRepositoryTests
    {
        TeacherDeclarationRepository rep = new TeacherDeclarationRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllTeacherDeclaration()
        {
            int totalCount = rep.ExecuteQuery<TeacherDeclaration>("SELECT * FROM Subscription.TeacherDeclaration").Count();
            var declarationList = rep.GetAll();
            Assert.AreEqual(totalCount, declarationList.Count());
        }
    }
}
