using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain;
using TextbookSubscription.Domain.Entity;
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
            int totalCount = rep.ExecuteQuery<School>("SELECT * FROM School").Count();
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
            string expectedID = rep.ExecuteQuery<School>("SELECT * FROM School WHERE SchoolName = '环境与安全工程学院'").First().SchoolID;

            var actualID = rep.GetSchoolIDByName("环境与安全工程学院");
            Assert.AreEqual(expectedID, actualID);
        }
    }
}
