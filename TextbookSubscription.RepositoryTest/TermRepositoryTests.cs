using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain;

namespace TextbookSubscription.RepositoryTests
{
    [TestClass]
    public class TermRepositoryTests
    {
        public TestContext TestContext { get; set; }
        TermRepository rep = new TermRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllTerm()
        {
            //SELECT COUNT(*) FROM Term = 16
            int totalCount = 16;
            var termList = rep.GetAll();
            foreach (var t in termList)
            {
                TestContext.WriteLine(t.TermName);
            }
            Assert.AreEqual(totalCount, termList.Count());
        }
    }
}
