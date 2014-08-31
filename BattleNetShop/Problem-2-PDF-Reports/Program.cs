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
                Location = "here",
                Name = "name",
                Price = 3,
                Quantity = 4,
                Vendor = "gosho"
            });

            pdf.GenerateAllProductsReportForDate(report);
        }
    }
}
