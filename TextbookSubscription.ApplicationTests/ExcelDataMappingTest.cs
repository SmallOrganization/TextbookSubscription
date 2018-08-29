using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookSubscription.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using Npoi.Mapper;
using TextbookSubscription.Infrastructure;
using TextbookSubscription.Application.DTOAdapter;

namespace TextbookSubscription.ApplicationTests
{
    [TestClass]
    public class ExcelDataMappingTest
    {
        AutoMapperTypeAdapter adpater = new AutoMapperTypeAdapter();
        Mapper mapper = new Mapper("../../征订计划导入示例数据.xlsx");

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Init()
        {
            MapperConfigration();
        }

        [TestMethod]
        public void DataMapping()
        {
            var stuDeclaration = GetStudentDeclaration();
            var teaDeclaration = GetTeacherDeclaration();
            Assert.AreEqual(true, true);
        }

        private void MapperConfigration()
        {
            #region Textbook Map

            mapper
                  // Column Mapping
                  .Map<Textbook>("BookID", t => t.TextbookID)
                  .Map<Textbook>("BookName", t => t.TextbookName)
                  .Map<Textbook>("ISBN", t => t.Isbn)
                  .Map<Textbook>("Publisher", t => t.Press)
                  .Map<Textbook>("EditionOrder", t => t.PrintingCount)
                  .Map<Textbook>("TextBookType", t => t.TextbookType)
                  .Map<Textbook>("Price", t => t.RetailPrice,
                  (columnInfo, targetObj) =>
                  {
                      ((Textbook)targetObj).RetailPrice
                        = columnInfo.CurrentValue.ToString().ConvertToDecimal();
                      return true;
                  })

                  // Ignore Property
                  .Ignore<Textbook>(t => t.ID);

            #endregion

            #region DeclarationMap

            mapper
                // Column Mapping
                .Map<Declaration>("BookID", sd => sd.TextbookID)
                .Map<Declaration>("ApprovedAmount", sd => sd.DeclarationNum,
                (columnInfo, targetObj) => // tryTake resolver : Custom logic to take cell value into target object.
                {
                    ((Declaration)targetObj).DeclarationNum
                        = columnInfo.CurrentValue.ToString().ConvertToInt();
                    return true;
                })
                .Map<Declaration>("TermName", sd => sd.Term)
                .Map<Declaration>("Phone", sd => sd.Telephone)
                .Map<Declaration>("CheckState", sd => sd.ApprovalStatus)
                .Map<Declaration>("Remarks", o => o.NeedTextbook,    // Remarks数据列 => NeedTextbook && Remark
                (columnInfo, targetObj) =>
                {
                    ((Declaration)targetObj).NeedTextbook
                        = (columnInfo.CurrentValue.ToString() == "不要教材") ? "0" : "1";
                    ((Declaration)targetObj).Remark
                        = columnInfo.CurrentValue.ToString();
                    return true;
                })

                // Ignore Property
                .Ignore<Declaration>(sd => sd.ID)
                .Ignore<Declaration>(sd => sd.Textbook)
                .Ignore<Declaration>(sd => sd.DeclarationID)
                .Ignore<Declaration>(sd => sd.ImportDate);

            #endregion
        }

        public IEnumerable<StudentDeclaration> GetStudentDeclaration()
        {
            var ret = new List<StudentDeclaration>();
            var declarations = mapper.Take<Declaration>("学生用书");
            var books = mapper.Take<Textbook>("学生用书");
            Assert.AreEqual(21, declarations.Count());
            Assert.AreEqual(21, books.Count());
            for (int i = 0; i < declarations.Count(); i++)
            {
                var declaration = declarations.ElementAt(i).Value;
                if (declaration.TextbookID != "NULL")
                    declaration.Textbook = books.ElementAt(i).Value;
                ret.Add(adpater.Adapt<StudentDeclaration>(declaration));
            }
            return ret;
        }

        public IEnumerable<TeacherDeclaration> GetTeacherDeclaration()
        {
            var ret = new List<TeacherDeclaration>();
            var declarations = mapper.Take<Declaration>("教师用书");
            var books = mapper.Take<Textbook>("教师用书");
            for (int i = 0; i < declarations.Count(); i++)
            {
                var declaration = declarations.ElementAt(i).Value;
                if (declaration.TextbookID != "NULL")
                    declaration.Textbook = books.ElementAt(i).Value;
                ret.Add(adpater.Adapt<TeacherDeclaration>(declaration));
            }
            return ret;
        }


    }
}
