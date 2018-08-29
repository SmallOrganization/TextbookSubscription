using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookSubscription.Domain;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain.Entity;
using System.Linq;

namespace TextbookSubscription.RepositoryTests
{
    [TestClass]
    public class StudentDeclarationRepositoryTests
    {
        StudentDeclarationRepository rep = new StudentDeclarationRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllStudentDeclaration()
        {
            int totalCount = rep.ExecuteQuery<StudentDeclaration>("SELECT * FROM Subscription.StudentDeclaration").Count();
            var declarationList = rep.GetAll();
            Assert.AreEqual(totalCount, declarationList.Count());
        }
    }
}
