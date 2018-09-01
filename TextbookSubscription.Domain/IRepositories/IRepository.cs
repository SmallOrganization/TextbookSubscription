namespace TextbookSubscription.Domain.IRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// 规定所有接口仓库的基础方法
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
    public interface IRepository<TAggregateRoot> : ISql
        where TAggregateRoot : class, IAggregateRoot
    {
        /// <summary>
        /// 仓库上下文
        /// </summary>
        IRepositoryDbContext Context { get; }

        /// <summary>
        /// 单对象查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 首个对象查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TAggregateRoot First(Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 获得全部实体
        /// </summary>
        /// <returns>全部实体</returns>
        IEnumerable<TAggregateRoot> GetAll();

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">对象实体</param>
        void Add(TAggregateRoot entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">对象实体</param>
        void Remove(TAggregateRoot entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Modify(TAggregateRoot entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">对象实体集合</param>
        void Remove(Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="filterExpression"></param>
        /// <param name="updateExpression"></param>
        void Modify(Expression<Func<TAggregateRoot, bool>> filterExpression, 
            Expression<Func<TAggregateRoot, TAggregateRoot>> updateExpression);

    }
}
