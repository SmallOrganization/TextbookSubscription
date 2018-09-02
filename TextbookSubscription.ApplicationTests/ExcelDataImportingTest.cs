using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookSubscription.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using Npoi.Mapper;
using TextbookSubscription.Infrastructure;
using TextbookSubscription.Application.DTOAdapter;
using TextbookSubscription.Repository;
using TextbookSubscription.Domain;
using System.Data.Entity;
using System;

namespace TextbookSubscription.ApplicationTests
{
    [TestClass]
    public class ExcelDataImportingTest
    {
        Mapper mapper = new Mapper("../../征订计划导入示例数据.xlsx");

        AutoMapperTypeAdapter adpater = new AutoMapperTypeAdapter();

        readonly static EFRepositoryDbContext context = new EFRepositoryDbContext();
        readonly StudentDeclarationRepository sdRep = new StudentDeclarationRepository(context);
        readonly TeacherDeclarationRepository tdRep = new TeacherDeclarationRepository(context);
        readonly AssociateSDPCRepository associationRep = new AssociateSDPCRepository(context);
        readonly ProfessionalClassRepository pcRep = new ProfessionalClassRepository(context);
        readonly DepartmentRepository depRep = new DepartmentRepository(context);
        readonly TextbookRepository bookRep = new TextbookRepository(context);
        int curLine = 0;

        DbContextTransaction transaction = context.Context.Database.BeginTransaction();

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Init()
        {
            MapperConfigration();
        }

        [TestCleanup]
        public void CleanUp()
        {
            transaction.Rollback();
            transaction.Dispose();
        }

        [TestMethod]
        public void DataMappingTest()
        {
            var stuDeclaration = GetStudentDeclaration();
            var teaDeclaration = GetTeacherDeclaration();
            var associations = GetAssociateSDPC();
            Assert.AreEqual(stuDeclaration.Count(), 21);
            Assert.AreEqual(associations.Count(), 21);
            Assert.AreEqual(teaDeclaration.Count(), 42);
        }

        [TestMethod]
        public void InsertTest()
        {
            #region 导入学生申报

            //某条学生申报导入流程
            // 1.根据DepartmentID查询是否存在该教研室,不存在则提示失败
            // 2.根据ClassName查询是否存在该班级,不存在则提示失败
            // 3.根据TextbookID查询是否存在该教材，不存在则新增教材
            // 4.向数据库中添加相关数据并提示成功

            var stuDeclarations = GetStudentDeclaration();
            var associateSDPCs = GetAssociateSDPC();
            for (int i = 0; i < stuDeclarations.Count(); i++)
            {
                #region 数据验证

                var depId = stuDeclarations.ElementAt(i).DepartmentID;
                var pcId = associateSDPCs.ElementAt(i).ClassID;
                var bookId = stuDeclarations.ElementAt(i).TextbookID;
                var deparment = depRep.Single(d => d.DepartmentID == depId);
                var professionalClass = pcRep.Single(pc => pc.ClassID == pcId);
                var textbook = bookRep.Single(b => b.TextbookID == bookId);

                if (deparment == null)
                {
                    // 教研室不存在
                    TestContext.WriteLine($"对于第{++curLine}条学生申报记录:\t教研室不存在");
                    continue;
                }
                if (professionalClass == null)
                {
                    // 班级不存在
                    TestContext.WriteLine($"对于第{++curLine}条学生申报记录:\t班级不存在");
                    continue;
                }
                if (textbook != null)
                {
                    // 若教材已经存在,要避免重复添加教材
                    stuDeclarations.ElementAt(i).Textbook = null;
                }

                #endregion

                #region 数据添加

                // 数据准备 
                var declaration = stuDeclarations.ElementAt(i);
                declaration.DeclarationID = Guid.NewGuid().ToString();
                declaration.ImportDate = DateTime.Now.ToLocalTime();

                var association = associateSDPCs.ElementAt(i);
                association.DeclarationID = declaration.DeclarationID;
                association.StudentDeclaration = declaration;
                association.ProfessionalClass = null;
                

                // 添加数据
                associationRep.Add(association);

                //提交更改
                context.Commit();
                TestContext.WriteLine($"对于第{++curLine}条学生申报记录:\t导入成功");

                #endregion
            }

            #endregion

            #region 导入教师申报

            //某条教师申报导入流程
            // 1.根据DepartmentID查询是否存在该教研室,不存在则提示失败
            // 2.根据TextbookID查询是否存在该教材，不存在则添加
            // 3.向数据库添加相关数据
            var teaDeclarations = GetTeacherDeclaration();
            curLine = 0;
            foreach (var declaration in teaDeclarations)
            {
                #region 数据验证

                var department = depRep.Single(d => d.DepartmentID == declaration.DepartmentID);
                var textbook = bookRep.Single(d => d.TextbookID == declaration.TextbookID);

                if (department == null)
                {
                    // 教研室不存在
                    Console.WriteLine($"对于第{++curLine}条教师申报记录\t教研室不存在");
                    continue;
                }
                if (textbook != null)
                {
                    // 若教材已经存在,要避免重复添加教材
                    declaration.Textbook = null;
                }

                #endregion

                // 数据准备
                declaration.DeclarationID = Guid.NewGuid().ToString();
                declaration.ImportDate = DateTime.Now.ToLocalTime();

                // 数据添加
                tdRep.Add(declaration);

                // 提交更改
                context.Commit();
                TestContext.WriteLine($"对于第{++curLine}条教师申报记录:\t导入成功");
            }
            #endregion

            #region 导入结果验证

            var stuDeclarationList = sdRep.GetAll();
            Assert.AreNotEqual(0, stuDeclarations.Count());
            var associationList = associationRep.GetAll();
            Assert.AreNotEqual(0, associationList.Count());

            var teaDeclarationList = tdRep.GetAll();
            Assert.AreNotEqual(0, teaDeclarationList.Count());

            #endregion
        }

        #region Excel数据映射

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
                      ((Textbook)targetObj).IsSelfCompile = "0";    //默认不是自编教材
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

            #region AssociateSDPCMap
            mapper
                  // Column Mapping
                  .Map<AssociateSDPC>("ClassName", a => a.ClassID,
                  (columnInfo,target) =>
                  {
                      var pc = pcRep.GetByName(columnInfo.CurrentValue.ToString()); // 将ClassName转换成ClassID
                      ((AssociateSDPC)target).ClassID
                        = (pc == null) ? "NULL" : pc.ClassID;
                      return true;
                  })
                  .Map<AssociateSDPC>("ClassSize", a => a.DeclarationCount,
                  (columnInfo, target) =>
                  {
                      string curValue = columnInfo.CurrentValue.ToString();
                      ((AssociateSDPC)target).DeclarationCount
                        = (curValue == "NULL") ? 0 : curValue.ConvertToInt();
                      return true;
                  })

                  // Ignore Mapping
                  .Ignore<AssociateSDPC>(a => a.ID)
                  .Ignore<AssociateSDPC>(a => a.ProfessionalClass)
                  .Ignore<AssociateSDPC>(a => a.StudentDeclaration);
            #endregion
        }

        private IEnumerable<StudentDeclaration> GetStudentDeclaration()
        {
            var ret = new List<StudentDeclaration>();
            var declarations = mapper.Take<Declaration>("学生用书");
            var books = mapper.Take<Textbook>("学生用书");
            for (int i = 0; i < declarations.Count(); i++)
            {
                var declaration = declarations.ElementAt(i).Value;
                if (declaration.TextbookID != "NULL")
                {
                    declaration.Textbook = books.ElementAt(i).Value;
                }
                else
                {
                    declaration.Textbook = null;
                }
                ret.Add(adpater.Adapt<StudentDeclaration>(declaration));
            }
            return ret;
        }

        private IEnumerable<AssociateSDPC> GetAssociateSDPC()
        {
            var ret = new List<AssociateSDPC>();
            foreach (var associations in mapper.Take<AssociateSDPC>("学生用书"))
            {
                ret.Add(associations.Value);
            }
            return ret;
        }

        private IEnumerable<TeacherDeclaration> GetTeacherDeclaration()
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

        #endregion
    }
}
