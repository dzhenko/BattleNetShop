﻿namespace BattleNetShop.Data.MySql
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IBattleNetShopMySqlGenericRepository
    {
        void Add(Salereport entity);

        void AddMany(IEnumerable<Salereport> entities);

        IQueryable<Salereport> All();

        void SaveChanges();
    }
}
