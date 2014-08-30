namespace BattleNetShop.Logic
{
    using System.Collections.Generic;

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

            foreach (var category in mongo.GetAllProductCategories())
            {
                MSSQL.ProductCategories.Add(category);
            }

            foreach (var detail in mongo.GetAllProductDetails())
            {
                MSSQL.ProductDetails.Add(detail);
            }

            foreach (var vendor in mongo.GetAllVendors())
            {
                MSSQL.Vendors.Add(vendor);
            }

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

            foreach (var location in setOfLocations)
            {
                MSSQL.PurchaseLocations.Add(new PurchaseLocation() 
                {
                    Name = location
                });

                dictionaryWithLocations.Add(location, index);
                index++;
            }

            excel.ReadAllPurchases(dictionaryWithLocations, purchase =>
            {
                MSSQL.Purchases.Add(purchase);
            });

            MSSQL.SaveChanges();
        }
    }
}
