namespace TextbookSubscription.IApplication
{
    public interface IDeclarationAppl
    {
        /// <summary>
        /// 通过excel导入申报计划
        /// </summary>
        /// <param name="excelPath">excel路径</param>
        void Import(string excelPath);
    }
}
