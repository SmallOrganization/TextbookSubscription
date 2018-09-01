namespace TextbookSubscription.Domain
{
    using System;
    using System.Data.Entity;
    using System.Threading;
    using TextbookSubscription.Domain.EFDbContext;

    public class EFRepositoryDbContext : RepositoryContext, IEFRepositoryDbContext
    {
        #region 私有变量

        private readonly ThreadLocal<TbMISDbContext> localCtx = new ThreadLocal<TbMISDbContext>(() => new TbMISDbContext());

        #endregion

        #region 重写父类方法

        public override void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Set<TAggregateRoot>().Remove(obj);
            Committed = false;
        }

        public override void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Entry<TAggregateRoot>(obj).State = EntityState.Modified;
            Committed = false;
        }

        public override void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Set<TAggregateRoot>().Add(obj);
            Committed = false;
        }

        #endregion

        #region 实现RepositoryContext
        
        /// <summary>
        /// 向数据库提交更改
        /// </summary>
        public override void Commit()
        {
            if (!Committed)
            {
                var validationErrors = localCtx.Value.GetValidationErrors();
                var count = localCtx.Value.SaveChanges();
                Committed = true;
            }
        }

        /// <summary>
        /// 回滚操作
        /// </summary>
        public override void Rollback()
        {
            Committed = false;
        }

        #endregion

        #region 重写Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!Committed)
                    Commit();
                localCtx.Value.Dispose();
                localCtx.Dispose();
                base.Dispose(disposing);
            }
        }
        #endregion

        #region IEFRepositoryDbContext Members

        public DbContext Context
        {
            get { return localCtx.Value; }
        }

        #endregion

    }
}
