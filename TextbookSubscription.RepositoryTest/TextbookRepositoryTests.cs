using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain;
using TextbookSubscription.Domain.Entity;
using System.Linq;

namespace TextbookSubscription.RepositoryTests
{
    [TestClass]
    public class TextbookRepositoryTests
    {
        TextbookRepository rep = new TextbookRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllTextbook()
        {
            int totalCount = rep.ExecuteQuery<Textbook>("SELECT * FROM Textbook").Count();
            var textbookList = rep.GetAll();
            Assert.AreEqual(totalCount, textbookList.Count());
        }
    }
}
