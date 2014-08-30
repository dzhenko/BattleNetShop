﻿namespace BattleNetShop.Data.MSSQL.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T: class
    {
        void Add(T entity);

        T Delete(T entity);

        IQueryable Search(Expression<Func<T, bool>> predicate);

        void Detach(T entity);

        void SaveChanges();
    }
}