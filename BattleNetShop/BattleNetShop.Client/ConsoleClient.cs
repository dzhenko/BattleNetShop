namespace BattleNetShop.Client
{
    using System;

    using BattleNetShop.Logic;

    // TODO : remove reference
    using BattleNetShop.ReportsModel;

    public class ConsoleClient
    {
        public static void Main()
        {
            //// new DataSeeder().Seed();

            //// new ExcelReportsLoader().Load();

            var pdf = new PdfReportsGenerator();

            var productsReportForDate = pdf.GetAllProductsReportForDate(new DateTime(2014, 1, 1));

            var productsReportForDates = pdf.GetAllProductsReportForPeriod(new[] { new DateTime(2014, 1, 1), new DateTime(2014, 1, 2), new DateTime(2014, 1, 3) });
        }
    }
}
