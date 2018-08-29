namespace TextbookSubscription.Domain.Entity
{
    using System.Collections.Generic;

    public class StudentDeclaration : Declaration
    {
        public StudentDeclaration()
        {
            AssociateSDPC = new HashSet<AssociateSDPC>();
        }

        /// <summary>
        /// 学生申报-专业班级 关联表
        /// </summary>
        public virtual ICollection<AssociateSDPC> AssociateSDPC { get; set; }
    }
}
