using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TextbookSubscription.Domain;
using TextbookSubscription.Repository;

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
            int totalcount = 320;
            var departmentList = rep.GetAll();
            foreach (var d in departmentList)
            {
                TestContext.WriteLine(d.DepartmentName);
            }
            Assert.AreEqual(totalcount, departmentList.Count());
        }

        [TestMethod]
        public void RetriveDepartmentListBySchoolID()
        { 
            //SELECT COUNT(*) FROM Department WHERE SchoolID='' = 6
            int totalCount = 6;
            var departmentList = rep.GetDepartmentBySchoolID("FD652812831549878016B0B01F24509A");
            foreach (var d in departmentList)
            {
                TestContext.WriteLine($"{d.DepartmentName} -- {d.SchoolID}");
            }
            Assert.AreEqual(totalCount, departmentList.Count());
        }
    }
}
