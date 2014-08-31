// TODO : remove reference
using BattleNetShop.ReportsModel;

namespace BattleNetShop.Client
{
    using System;

    using BattleNetShop.Logic;

    public class ConsoleClient
    {
        public static void Main()
        {
            //new DataSeeder().Seed();

            //new ExcelReportsLoader().Load();

            var pdf = new PdfReportsGenerator();

            var ProductsReportForDate = pdf.GetAllProductsReportForDate(new DateTime(2014, 1, 1));

            var ProductsReportForDates = pdf.GetAllProductsReportForPeriod(new[] { new DateTime(2014, 1, 1), new DateTime(2014, 1, 2), new DateTime(2014, 1, 3) });
        }
    }
}
