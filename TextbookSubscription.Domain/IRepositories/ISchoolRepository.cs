namespace TextbookSubscription.Domain.IRepositories
{
    using TextbookSubscription.Domain.Entity;
    using System.Collections.Generic;

    public interface ISchoolRepository:IRepository<School>
    {
        /// <summary>
        /// 根据学院名称获得学院ID
        /// </summary>
        /// <param name="shcoolName">学院名称</param>
        /// <returns>学院ID</returns>
        string GetSchoolIDByName(string shcoolName);
    }
}
