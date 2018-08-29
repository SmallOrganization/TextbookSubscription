using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TextbookSubscription.Domain;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain.Entity;

namespace TextbookSubscription.RepositoryTests
{
    [TestClass]
    public class BooksellerRepositoryTests
    {
        public TestContext TestContext { get; set; }
        BooksellerRepository rep = new BooksellerRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllBookseller()
        {
            int totalCount = rep.ExecuteQuery<Bookseller>("SELECT * FROM Bookseller").Count();
            var sellerList = rep.GetAll();
            foreach (var seller in sellerList)
            {
                TestContext.WriteLine(seller.BooksellerName);
            }
            Assert.AreEqual(totalCount, sellerList.Count());
        }
    }
}
