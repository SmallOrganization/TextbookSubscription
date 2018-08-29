namespace TextbookSubscription.Domain.Entity
{
    using System;

    public class Declaration : AggregateRoot
    {
        /// <summary>
        /// 申报ID
        /// </summary>
        public string DeclarationID { get; set; }

        /// <summary>
        /// 申报教材ID
        /// </summary>
        public string TextbookID { get; set; }

        /// <summary>
        /// 申报编号
        /// </summary>
        public int DeclarationNum { get; set; }

        /// <summary>
        /// 学期名称
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// 学院ID
        /// </summary>
        public string SchoolID { get; set; }

        /// <summary>
        /// 学院名称
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 课程ID
        /// </summary>
        public string CourseID { get; set; }

        /// <summary>
        /// 课程编号
        /// </summary>
        public string CourseCode { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 导入时间
        /// </summary>
        public DateTime ImportDate { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public string ApprovalStatus { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// 数据标识
        /// </summary>
        public string DataSign { get; set; }

        /// <summary>
        /// 是否需要教材
        /// </summary>
        public string NeedTextbook { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 申报教材
        /// </summary>
        public virtual Textbook Textbook { get; set; }
    }
}
