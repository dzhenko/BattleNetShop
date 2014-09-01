namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.SqlServer;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    internal class MsSqlReportsFetcher
    {
        private readonly IBattleNetShopSqlServerData msSqlData;

        public MsSqlReportsFetcher()
            : this(new BattleNetShopSqlServerData())
        {
        }

        public MsSqlReportsFetcher(IBattleNetShopSqlServerData msSqlDataToUse)
        {
            this.msSqlData = msSqlDataToUse;
        }

        public IEnumerable<ProductsReportEntry> GetAllProductInformations()
        {
            return this.msSqlData.Purchases
                .All()
                .GroupBy(purchase => purchase.ProductId)
                .OrderBy(gr => gr.Key)
                .Select(gr => new ProductsReportEntry
                {
                    Name = gr.Min(p => p.Product.Name),
                    Price = gr.Average(p => p.UnitPrice),
                    ProductId = gr.Key,
                    Quantity = gr.Sum(g => g.Quantity),
                    Vendor = gr.Min(p => p.Product.Vendor.Name)
                });
        }

        public ProductsReport GetAllProductsReportForDate(DateTime date)
        {
            var allProductInformations = this.msSqlData.Purchases
                .Search(purchase => purchase.Date == date)
                .GroupBy(purchase => purchase.Product.Name)
                .OrderBy(gr => gr.Min(p => p.ProductId))
                .Select(gr => new ProductsReportEntry
                {
                    Name = gr.Key,
                    Price = gr.Average(purchase => purchase.UnitPrice),
                    ProductId = gr.Min(purchase => purchase.ProductId),
                    Vendor = gr.Min(purchase => purchase.Product.Vendor.Name),
                    Quantity = gr.Count()
                });

            return new ProductsReport()
            {
                Date = date,
                Products = allProductInformations
            };
        }

        public IEnumerable<ProductsReport> GetAllProductsReportForPeriod(IEnumerable<DateTime> dates)
        {
            return dates.Select(d => this.GetAllProductsReportForDate(d));
        }

        public IEnumerable<ProductsReport> GetProductInformationForDates(int productId)
        {
            return this.GetProductInformationForDates(this.msSqlData.Products.GetById(productId).Name);
        }

        public IEnumerable<ProductsReport> GetProductInformationForDates(Product product)
        {
            return this.GetProductInformationForDates(product.Name);
        }

        public IEnumerable<ProductsReport> GetProductInformationForDates(string productName)
        {
            return this.msSqlData.Purchases
                .Search(purchase => purchase.Product.Name == productName)
                .GroupBy(purchase => purchase.Date)
                .OrderBy(gr => gr.Min(p => p.ProductId))
                .Select(gr => new ProductsReport 
                {
                   Date = gr.Key,
                   Products = gr.Select(g => new ProductsReportEntry
                   {
                       Name = productName,
                       Price = g.UnitPrice,
                       Quantity = g.Quantity,
                       ProductId = gr.Min(purchase => purchase.ProductId),
                       Vendor = gr.Min(purchase => purchase.Product.Vendor.Name),
                   })
                });
        }

        public IEnumerable<ProductsReport> GetProductInformationForLocations(int productId)
        {
            return this.GetProductInformationForDates(this.msSqlData.Products.GetById(productId).Name);
        }

        public IEnumerable<ProductsReport> GetProductInformationForLocations(Product product)
        {
            return this.GetProductInformationForDates(product.Name);
        }

        public IEnumerable<ProductsReport> GetProductInformationForLocations(string productName)
        {
            return this.msSqlData.Purchases
                .Search(purchase => purchase.Product.Name == productName)
                .GroupBy(purchase => purchase.Location.Name)
                .OrderBy(gr => gr.Min(p => p.ProductId))
                .Select(gr => new ProductsReport
                {
                    Products = gr.Select(g => new ProductsReportEntry
                    {
                        Name = productName,
                        Price = g.UnitPrice,
                        Quantity = g.Quantity,
                        Location = g.Location.Name,
                        ProductId = gr.Min(purchase => purchase.ProductId),
                        Vendor = gr.Min(purchase => purchase.Product.Vendor.Name),
                    })
                });
        }

        public ProductsReport GetLocationReportForDate(PurchaseLocation location, DateTime date)
        {
            return this.GetLocationReportForDate(location.Name, date);
        }

        public ProductsReport GetLocationReportForDate(int locationId, DateTime date)
        {
            return this.GetLocationReportForDate(this.msSqlData.PurchaseLocations.GetById(locationId).Name, date);
        }

        public ProductsReport GetLocationReportForDate(string locationName, DateTime date)
        {
            var allProductInformations = this.msSqlData.Purchases
                .Search(purchase => purchase.Location.Name == locationName)
                .Where(purchase => purchase.Date == date)
                .GroupBy(purchase => purchase.Product.Name)
                .OrderBy(gr => gr.Min(p => p.ProductId))
                .Select(gr => new ProductsReportEntry
                {
                    Name = gr.Key,
                    Price = gr.Average(purchase => purchase.UnitPrice),
                    Quantity = gr.Count(),
                    ProductId = gr.Min(purchase => purchase.ProductId),
                    Vendor = gr.Min(purchase => purchase.Product.Vendor.Name),
                });

            return new ProductsReport()
            {
                Date = date,
                Products = allProductInformations
            };
        }

        public IEnumerable<ProductsReport> GetLocationReportForPeriod(PurchaseLocation location, IEnumerable<DateTime> dates)
        {
            return this.GetLocationReportForPeriod(location.Name, dates);
        }

        public IEnumerable<ProductsReport> GetLocationReportForPeriod(int LocationId, IEnumerable<DateTime> dates)
        {
            return this.GetLocationReportForPeriod(this.msSqlData.PurchaseLocations.GetById(LocationId).Name, dates);
        }

        public IEnumerable<ProductsReport> GetLocationReportForPeriod(string locationName, IEnumerable<DateTime> dates)
        {
            return dates.Select(d => this.GetLocationReportForDate(locationName, d));
        }

        public IQueryable<LocationReport> GetAllLocationsReport()
        {
            return this.msSqlData.Purchases.All()
                .GroupBy(purchase => purchase.Location.Name)
                .Select(gr => new LocationReport
                {
                    LocationName = gr.Key,
                    Entries = gr.GroupBy(g => g.Date).Select(group => new LocationReportEntry()
                    {
                        Date = group.Key,
                        TotalSum = group.Sum(g => g.Quantity * g.UnitPrice)
                    })
                });
        }
    }
}
