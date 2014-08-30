namespace BattleNetShop.Data.MongoDb
{
    using System;
    using System.Collections.Generic;

    using MongoDB.Driver;

    using BattleNetShop.Model;

    /// <summary>
    /// Class holding all mongoDb data manipulation
    /// </summary>
    public class MongoDbData
    {
        private Lazy<MongoDBHandler> mongoHandler = new Lazy<MongoDBHandler>();

        /// <summary>
        /// Returns all the products from the database without their class type properties.
        /// </summary>
        /// <returns>A collection with all the products in the database.</returns>
        public ICollection<Product> GetAllProducts()
        {
            var allProducts = new List<Product>();

            mongoHandler.Value.ReadCollection<Product>("Products", p => allProducts.Add(p));

            return allProducts;
        }

        /// <summary>
        /// Returns all the product details from the database without their class type properties.
        /// </summary>
        /// <returns>A collection with all the product details in the database.</returns>
        public ICollection<ProductDetails> GetAllProductDetails()
        {
            var allProductDetails = new List<ProductDetails>();

            mongoHandler.Value.ReadCollection<ProductDetails>("ProductDetails", pd => allProductDetails.Add(pd));

            return allProductDetails;
        }

        /// <summary>
        /// Returns all the product categories from the database without their class type properties.
        /// </summary>
        /// <returns>A collection with all the product categories in the database.</returns>
        public ICollection<ProductCategory> GetAllProductCategories()
        {
            var allProductCategories = new List<ProductCategory>();

            mongoHandler.Value.ReadCollection<ProductCategory>("ProductCategories", pc => allProductCategories.Add(pc));

            return allProductCategories;
        }

        /// <summary>
        /// Returns all the vendors from the database without their class type properties.
        /// </summary>
        /// <returns>A collection with all the vendors in the database.</returns>
        public ICollection<Vendor> GetAllVendors()
        {
            var allVendors = new List<Vendor>();

            mongoHandler.Value.ReadCollection<Vendor>("Vendors", pc => allVendors.Add(pc));

            return allVendors;
        }

        /// <summary>
        /// Saves the givven sales expenses in the database.
        /// </summary>
        /// <param name="allExpenses">Collection of expenses to save in the database.</param>
        public void SaveExpenses(ICollection<VendorExpense> allExpenses)
        {
            mongoHandler.Value.WriteCollection<VendorExpense>("VendorExpenses", allExpenses);
        }
    }
}
