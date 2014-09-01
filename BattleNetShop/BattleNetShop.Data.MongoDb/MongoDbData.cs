namespace BattleNetShop.Data.MongoDb
{
    using System;
    using System.Collections.Generic;

    using MongoDB.Driver;

    using BattleNetShop.Model;

    public class MongoDbData : IMongoDbData
    {
        private Lazy<MongoDbHandler> mongoHandler = new Lazy<MongoDbHandler>();

        public ICollection<Product> GetAllProducts()
        {
            var allProducts = new List<Product>();

            mongoHandler.Value.ReadCollection<Product>("Products", p => allProducts.Add(p));

            return allProducts;
        }

        public ICollection<ProductDetails> GetAllProductDetails()
        {
            var allProductDetails = new List<ProductDetails>();

            mongoHandler.Value.ReadCollection<ProductDetails>("ProductDetails", pd => allProductDetails.Add(pd));

            return allProductDetails;
        }

        public ICollection<ProductCategory> GetAllProductCategories()
        {
            var allProductCategories = new List<ProductCategory>();

            mongoHandler.Value.ReadCollection<ProductCategory>("ProductCategories", pc => allProductCategories.Add(pc));

            return allProductCategories;
        }

        public ICollection<Vendor> GetAllVendors()
        {
            var allVendors = new List<Vendor>();

            mongoHandler.Value.ReadCollection<Vendor>("Vendors", pc => allVendors.Add(pc));

            return allVendors;
        }

        public void SaveExpenses(ICollection<VendorExpense> allExpenses)
        {
            mongoHandler.Value.WriteCollection<VendorExpense>("VendorExpenses", allExpenses);
        }
    }
}
