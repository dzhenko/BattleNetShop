namespace BattleNetShop.Data.MSSQL
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BattleNetShop.Model;

    public interface IBattleNetShopDbContext
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<ProductCategory> Categories { get; set; }

        IDbSet<Vendor> Vendors { get; set; }

        IDbSet<ProductDetails> Details { get; set; }

        IDbSet<Purchase> Purchases { get; set; }

        IDbSet<PurchaseLocation> Locations { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
