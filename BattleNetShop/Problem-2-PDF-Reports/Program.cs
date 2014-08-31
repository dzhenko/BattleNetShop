namespace Problem_2_PDF_Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.PDF;
    using BattleNetShop.ReportsModel;
    class Program
    {
        static void Main()
        {
            var pdf = new PDFHandler();

            var report = new ProductsReport();

            report.Date = DateTime.Now;

            report.Products.Add(new ProductInformation()
            {
                Location = "Realm Netherlands",
                Name = "Stone of Jordan",
                Price = 1.4,
                Quantity = 2,
                Vendor = "Atanas"
            });

            report.Products.Add(new ProductInformation()
            {
                Location = "Realm: Stormwind",
                Name = "Gold",
                Price = 0.2,
                Quantity = 45888,
                Vendor = "Blizzard"
            });

            report.Products.Add(new ProductInformation()
            {
                Location = "Realm: Black Temple",
                Name = "Awesome Item 2",
                Price = 334,
                Quantity = 45,
                Vendor = "Gosheto"
            });

            List<ProductsReport> reportsCollection = new List<ProductsReport>();
            reportsCollection.Add(report);

            pdf.GenerateAllProductsReportForPeriod(reportsCollection);
        }
    }
}
