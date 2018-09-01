using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TextbookSubscription.Domain;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain.Entity;

namespace TextbookSubscription.RepositoryTests
{
    [TestClass]
    public class DepartmentRepositoryTests
    {
        public TestContext TestContext { set; get; }
        DepartmentRepository rep = new DepartmentRepository(new EFRepositoryDbContext());

        [TestMethod]
        public void RetriveAllDepartment()
        {
            //SELECT COUNT(*) FROM Department = 320
            int totalcount = rep.ExecuteQuery<Department>("SELECT * FROM Department").Count();
            var departmentList = rep.GetAll();
            foreach (var d in departmentList)
            {
                TestContext.WriteLine(d.DepartmentName);
            }
            Assert.AreEqual(totalcount, departmentList.Count());
        }
    }
}
