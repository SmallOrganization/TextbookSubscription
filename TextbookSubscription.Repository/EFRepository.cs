namespace TextbookSubscription.Repository
{
    using System.Collections.Generic;
    using TextbookSubscription.Domain;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System;
    using Z.EntityFramework.Plus;

    public class EFRepository<TAggregateRoot> : Repository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        #region 私有变量

        private readonly IEFRepositoryDbContext _context;

        #endregion

        #region Proteced 属性

        /// <summary>
        /// 存储上下文
        /// </summary>
        protected IEFRepositoryDbContext EFContext
        {
            get { return _context; }
        }

        /// <summary>
        /// 数据集
        /// </summary>
        protected DbSet<TAggregateRoot> Set
        {
            get { return _context.Context.Set<TAggregateRoot>(); }
        }

        #endregion

        #region 构造函数

        public EFRepository(IRepositoryDbContext context)
            :base(context)
        {
            if (context is IEFRepositoryDbContext)
            {
                _context = context as IEFRepositoryDbContext;
            }
        }

        #endregion

        #region 实现Repository<TAggregateRoot>

        /// <summary>
        /// 获得全部实体
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<TAggregateRoot> GetAll()
        {
            //不启用更改跟踪，启用并行化查询
            return Set.AsParallel().ToList();
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <returns></returns>
        public override IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression)
        {
            //启用并行化查询
            return Set.Where(expression).AsParallel().ToList();
        }

        /// <summary>
        /// 获得满足条件的单个实体
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <returns></returns>
        public override TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return Set.SingleOrDefault(expression);
        }

        /// <summary>
        /// 返回满足条件的第一个实体
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <returns></returns>
        public override TAggregateRoot First(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return Set.FirstOrDefault(expression);
        }

        /// <summary>
        /// 注册实体为Added状态
        /// </summary>
        /// <param name="entity">将要添加的实体</param>
        public override void Add(TAggregateRoot entity)
        {
            _context.RegisterNew(entity);
        }

        /// <summary>
        /// 注册实体为Deleted状态
        /// </summary>
        /// <param name="entity">将要删除的实体</param>
        public override void Remove(TAggregateRoot entity)
        {
            _context.RegisterDeleted<TAggregateRoot>(entity);
        }

        /// <summary>
        /// 注册实体为Modified状态
        /// </summary>
        /// <param name="entity">已被修改过的实体</param>
        public override void Modify(TAggregateRoot entity)
        {
            _context.RegisterModified<TAggregateRoot>(entity);
        }

        /// <summary>
        /// 执行sql查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sqlQuery">sql语句</param>
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public override IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            //将查询结果转换为实体，但不提供跟踪更改
            return _context.Context.Database.SqlQuery<TEntity>(sqlQuery, parameters).AsParallel().ToList();
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sqlCommand">sql语句</param>
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public override int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            //标准ADO.NET命令
            return _context.Context.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        /// <summary>
        /// 注册批量实体为Deleted状态
        /// </summary>
        /// <param name="expression">筛选条件表达式</param>
        public override void Remove(Expression<Func<TAggregateRoot, bool>> expression)
        {
            Set.Where(expression).Delete();
        }

        /// <summary>
        /// 注册批量实体为Modified状态
        /// </summary>
        /// <param name="filterExpression">筛选条件表达式</param>
        /// <param name="updateExpression">更新表达式</param>
        public override void Modify(Expression<Func<TAggregateRoot, bool>> filterExpression, 
            Expression<Func<TAggregateRoot, TAggregateRoot>> updateExpression)
        {
            Set.Where(filterExpression).Update(updateExpression);
        }

        #endregion
    }
}
