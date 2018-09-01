namespace TextbookSubscription.Domain.Entity
{
    using System.Collections.Generic;

    public class School : AggregateRoot
    {
        /// <summary>
        /// 学院ID
        /// </summary>
        public string SchoolID { get; set; }
        
        /// <summary>
        /// 学院编号
        /// </summary>
        public string SchoolNum { get; set; }

        /// <summary>
        /// 学院名称
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        public virtual ICollection<ProfessionalClass> ProfessionalClasses { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
    }
}
