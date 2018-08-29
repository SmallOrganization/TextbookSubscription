namespace TextbookSubscription.Domain.Entity
{
    using System.Collections.Generic;
    using TextbookSubscription.Domain;

    public class ProfessionalClass : AggregateRoot
    {
        /// <summary>
        /// 班级ID
        /// </summary>
        public string ClassID { get; set; }

        /// <summary>
        /// 班级编号
        /// </summary>
        public string ClassNum { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 班级对应的学院ID
        /// </summary>
        public string SchoolID { get; set; }

        /// <summary>
        /// 学生申报-专业班级 关联表
        /// </summary>
        public virtual ICollection<AssociateSDPC> AssociateSDPC { get; set; }
    }
}
