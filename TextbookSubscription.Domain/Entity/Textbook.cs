using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextbookSubscription.Domain.Entity
{
    public class Textbook : AggregateRoot
    {
        /// <summary>
        /// 教材ID
        /// </summary>
        public string TextbookID { get; set; }

        /// <summary>
        /// 教材编号
        /// </summary>
        public int TextbookNum2 { get; set; }

        /// <summary>
        /// 格式化后的教材编号
        /// </summary>
        public string TextbookNum { get; set; }

        /// <summary>
        /// Isbn
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        public string TextbookName { get; set; }

        /// <summary>
        /// 出版社名称
        /// </summary>
        public string Press { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Edition { get; set; }

        /// <summary>
        /// 印刷版次
        /// </summary>
        public string PrintingCount { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        public decimal RetailPrice { get; set; }

        /// <summary>
        /// 教材类型
        /// </summary>
        public string TextbookType { get; set; }

        /// <summary>
        /// 译者
        /// </summary>
        public string Translator { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        public string Catalog { get; set; }

        /// <summary>
        /// 是否自编
        /// </summary>
        public string IsSelfCompile { get; set; }
    }
}
