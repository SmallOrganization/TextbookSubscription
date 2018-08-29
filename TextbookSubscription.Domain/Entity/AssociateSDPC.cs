namespace TextbookSubscription.Domain.Entity
{
    public class AssociateSDPC : AggregateRoot
    {
        /// <summary>
        /// 班级ID
        /// </summary>
        public string ClassID { get; set; }

        /// <summary>
        /// 申报ID
        /// </summary>
        public string DeclarationID { get; set; }

        /// <summary>
        /// 申报数量
        /// </summary>
        public int DeclarationCount { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public virtual ProfessionalClass ProfessionalClass { get; set; }

        /// <summary>
        /// 学生申报
        /// </summary>
        public virtual StudentDeclaration StudentDeclaration { get; set; }
    }
}
