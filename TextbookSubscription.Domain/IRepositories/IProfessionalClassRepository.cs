namespace TextbookSubscription.Domain.IRepositories
{
    using Entity;

    public interface IProfessionalClassRepository : IRepository<ProfessionalClass>
    {
        /// <summary>
        /// 根据课程名称获得课程
        /// </summary>
        /// <param name="className">课程名称</param>
        /// <returns></returns>
        ProfessionalClass GetByName(string className);
    }
}
