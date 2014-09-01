namespace BattleNetShop.Data.MySql
{
    using System;

    public class MySqlHandler
    {
        public void ReadAllReports(Action<Salereport> action)
        {
            using (var connection = new BattleNetShopMySqlDbContext())
            {
                foreach (var report in connection.Salereports)
                {
                    action(new Salereport
                    {
                        Product_id = report.Product_id,
                        ProductName = report.ProductName,
                        VendorName = report.VendorName,
                        TotalQuantitySold = report.TotalQuantitySold,
                        TotalIncomes = report.TotalIncomes
                    });
                }
            }
        }

        public void WriteReport(Salereport report)
        {
            using (var connection = new BattleNetShopMySqlDbContext())
            {
                connection.Add(report);

                connection.SaveChanges();

                Console.WriteLine("REPORT SUCCESSFULLY RECORDED TO MYSQL!");
            }
        }
    }
}
