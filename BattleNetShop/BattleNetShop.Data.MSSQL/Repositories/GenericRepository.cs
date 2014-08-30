namespace BattleNetShop.Data.MSSQL.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private IBattleNetShopMSSQLDbContext context;

        public GenericRepository(IBattleNetShopMSSQLDbContext battleNetShopMSSQLDbContext)
	    {
            this.context = battleNetShopMSSQLDbContext;
	    }

        public GenericRepository()
            : this(new BattleNetShopMSSQLDbContext())
        {
        }

        protected IBattleNetShopMSSQLDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public IQueryable Search(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where(predicate);
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        private void ChangeState(T entity, EntityState state)
        {
            this.context.Entry(entity).State = state;
        }


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
