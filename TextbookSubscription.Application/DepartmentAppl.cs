using System.Collections.Generic;
using TextbookSubscription.Domain.IRepositories;
using TextbookSubscription.IApplication;
using TextbookSubscription.Infrastructure;
using TextbookSubscription.ViewModels;

namespace TextbookSubscription.Application
{
    public class DepartmentAppl : IDepartmentAppl
    {
        private IDepartmentRepository _departmentRep;
        private ISchoolRepository _schoolRep;
        private ITypeAdapter _adapter;

        public DepartmentAppl(IDepartmentRepository departmentRep, ISchoolRepository schoolRep,ITypeAdapter adapter)
        {
            _departmentRep = departmentRep;
            _schoolRep = schoolRep;
            _adapter = adapter;
        }

        public IEnumerable<DepartmentView> GetDepartmentList(string schoolName)
        {
            var schoolId = _schoolRep.GetSchoolIDByName(schoolName);
            var departmentList = _schoolRep.Single(s => s.SchoolID == schoolId).Departments;
            var departmentViewList = _adapter.Adapt<DepartmentView>(departmentList);

            return departmentViewList;
        }
    }
}
