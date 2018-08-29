namespace TextbookSubscription.Domain.Entity
{
    public class Bookseller : AggregateRoot
    {
        /// <summary>
        /// 书商ID
        /// </summary>
        public System.Guid BooksellerID { get; set; }

        /// <summary>
        /// 书商编号
        /// </summary>
        public long BooksellerNum { get; set; }

        /// <summary>
        /// 书商名称
        /// </summary>
        public string BooksellerName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }
    }
}
