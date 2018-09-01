using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain;
using TextbookSubscription.Domain.Entity;

namespace TextbookSubscription.RepositoryTests
{
    [TestClass]
    public class ProfessionalClassRepositoryTests
    {
        public TestContext TestContext { get; set; }
        ProfessionalClassRepository rep = new ProfessionalClassRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllClass()
        {
            int totalCount = rep.ExecuteQuery<ProfessionalClass>("SELECT * FROM ProfessionalClass").Count();
            var termList = rep.GetAll();
            Assert.AreEqual(totalCount, termList.Count());
        }

        [TestMethod]
        public void RetriveSchool()
        {
            string expectedSchoolName = "经济与法学学院";
            ProfessionalClass pc = rep.Single(p => p.ClassNum == "201541102");
            Assert.AreEqual(expectedSchoolName, pc.School.SchoolName);
        }
    }
}
