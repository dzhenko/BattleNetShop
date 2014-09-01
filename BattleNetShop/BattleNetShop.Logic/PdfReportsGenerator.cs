namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.SqlServer;

    using BattleNetShop.ReportsModel;

    public class PdfReportsGenerator
    {
        private readonly IBattleNetShopMSSQLData msSqlData;

        public PdfReportsGenerator()
            : this(new BattleNetShopMSSQLData())
        {
        }

        public PdfReportsGenerator(IBattleNetShopMSSQLData msSqlDataToUse)
        {
            this.msSqlData = msSqlDataToUse;
        }

        public ProductsReport GetAllProductsReportForDate(DateTime date)
        {
            var allProductInformations = this.msSqlData.Purchases
                .Search(p => p.Date == date)
                .GroupBy(p => p.Product.Name)
                .OrderByDescending(g => g.Key)
                .Select(gr => new ProductInformation
                {
                    Name = gr.Key,
                    Price = gr.Average(p => p.UnitPrice),
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

        public IEnumerable<ProductsReport> GetProductInfoForDates()
        {
            return null;
        }
    }
}