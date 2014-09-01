namespace BattleNetShop.Data.MongoDb
{
    using System;
    using System.Collections.Generic;

    using MongoDB.Driver;

    using BattleNetShop.Model;
    using BattleNetShop.Data.Excel.Xls;

    public class MongoDataSeeder
    {
        private MongoDbHandler mongoHandler;
        private ExcelXlsHandler excelHandler;

        /// <summary>
        /// Seeds the default products, categories, vendors, locations and descriptions
        /// </summary>
        public void Seed()
        {
            mongoHandler = new MongoDbHandler();
            excelHandler = new ExcelXlsHandler();

            this.SeedVendors();

            this.SeedCategories();

            this.SeedDetails();

            this.SeedProducts();
        }

        private void SeedVendors()
        {
            var allVendors = new List<Vendor>();

            excelHandler.ReadInitialDataFile("Vendors$", row =>
                {
                    allVendors.Add(new Vendor 
                    {
                        Id = (int)(double)row[0],
                        Name = (string)row[1]
                    });
                });

            mongoHandler.WriteCollection<Vendor>("Vendors", allVendors);
        }

        private void SeedCategories()
        {
            var allCategories = new List<ProductCategory>();

            excelHandler.ReadInitialDataFile("Categories$", row =>
            {
                allCategories.Add(new ProductCategory
                {
                    Id = (int)(double)row[0],
                    Name = (string)row[1]
                });
            });

            mongoHandler.WriteCollection<ProductCategory>("ProductCategories", allCategories);
        }

        private void SeedDetails()
        {
            var allDetails = new List<ProductDetails>();

            excelHandler.ReadInitialDataFile("ProductDetails$", row =>
            {
                allDetails.Add(new ProductDetails
                {
                    Id = (int)(double)row[0],
                    Type = (string)row[1],
                    Description = (string)row[2]
                });
            });

            mongoHandler.WriteCollection<ProductDetails>("ProductDetails", allDetails);
        }

        private void SeedProducts()
        {
            var allProducts = new List<Product>();

            excelHandler.ReadInitialDataFile("Products$", row =>
            {
                allProducts.Add(new Product
                {
                    Id = (int)(double)row[0],
                    Name = (string)row[1],
                    VendorId = (int)(double)row[2],
                    CategoryId = (int)(double)row[3],
                    DetailsId = (int)(double)row[4],
                    Measure = (ProductMeasure)((int)(double)row[5]),
                    BasePrice = (decimal)(double)row[6]
                });
            });

            mongoHandler.WriteCollection<Product>("Products", allProducts);
        }
    }
}
