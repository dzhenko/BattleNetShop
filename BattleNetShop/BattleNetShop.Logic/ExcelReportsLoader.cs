namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.Excel.Xls;
    using BattleNetShop.Data.MongoDb;
    using BattleNetShop.Data.MSSQL;
    using BattleNetShop.Model;

    public class ExcelReportsLoader
    {
        public void Load()
        {
            var MSSQL = new BattleNetShopMSSQLData();

            var mongo = new MongoDbData();

            Console.WriteLine("Adding product categories from MongoDb to MS SQL...");
            foreach (var category in mongo.GetAllProductCategories())
            {
                MSSQL.ProductCategories.Add(category);
            }

            Console.WriteLine("Adding product details from MongoDb to MS SQL...");
            foreach (var detail in mongo.GetAllProductDetails())
            {
                MSSQL.ProductDetails.Add(detail);
            }

            Console.WriteLine("Adding vendors from MongoDb to MS SQL...");
            foreach (var vendor in mongo.GetAllVendors())
            {
                MSSQL.Vendors.Add(vendor);
            }

            Console.WriteLine("Adding products from MongoDb to MS SQL...");
            foreach (var product in mongo.GetAllProducts())
            {
                MSSQL.Products.Add(product);
            }

            var excel = new ExcelXlsData();

            var setOfLocations = new HashSet<string>();

            excel.ReadAllPurchases((productId, quantity, unitPrice, locationName, date) =>
            {
                if (setOfLocations.Contains(locationName))
                {
                    return;
                }

                setOfLocations.Add(locationName);
            });

            var dictionaryWithLocations = new Dictionary<string, int>();
            var index = 1;

            Console.WriteLine("Adding purchase locations from Zipped excel reports to MS SQL...");
            foreach (var location in setOfLocations)
            {
                MSSQL.PurchaseLocations.Add(new PurchaseLocation()
                {
                    Name = location
                });

                dictionaryWithLocations.Add(location, index);
                index++;
            }

            Console.WriteLine("Adding purchases from Zipped excel reports to MS SQL (be patient)...");
            excel.ReadAllPurchases(dictionaryWithLocations, purchase =>
            {
                MSSQL.Purchases.Add(purchase);
            });

            MSSQL.SaveChanges();
        }

        public void Test()
        {
            var MSSQL = new BattleNetShopMSSQLData();

            var found = MSSQL.Products.GetById(5);

            Console.WriteLine(found.Purchases.Sum(x=>x.Quantity * x.Sum));
        }
    }
}