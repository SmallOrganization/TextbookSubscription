using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain;
using System.Linq;

namespace TextbookSubscription.RepositoryTests
{
    /// <summary>
    /// SchoolRepositoryTest 的摘要说明
    /// </summary>
    [TestClass]
    public class SchoolRepositoryTests
    {
        public TestContext TestContext { get; set; }
        SchoolRepository rep = new SchoolRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllSchool()
        {
            //SELECT COUNT(*) FROM School = 55
            int totalCount = 55;
            var schoollist = rep.GetAll();
            foreach (var t in schoollist)
            {
                TestContext.WriteLine(t.SchoolName);
            }
            Assert.AreEqual(totalCount, schoollist.Count());
        }

        [TestMethod]
        public void RetriveSchoolIDByName()
        {
            //SELECT SchoolID FROM School WHERE SchoolName = "环境与安全工程学院"
            string expectedID = "FD652812831549878016B0B01F24509A";
            var actualID = rep.GetSchoolIDByName("环境与安全工程学院");
            Assert.AreEqual(expectedID, actualID);
        }
    }
}
