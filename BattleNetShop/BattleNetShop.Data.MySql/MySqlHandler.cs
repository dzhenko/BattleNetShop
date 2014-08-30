using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleNetShop.Data.MySql
{
    public class MySqlHandler
    {
        public void ReadAllReports(Action<Salereport> action)
        {
            using (var connection = new BattleNetShopMySqlDbContext())
            {
                foreach (var report in connection.Salereports)
                {
                    var currentReport = new Salereport
                    {
                        Product_id = report.Product_id,
                        ProductName = report.ProductName,
                        VendorName = report.VendorName,
                        TotalQuantitySold = report.TotalQuantitySold,
                        TotalIncomes = report.TotalIncomes
                    };

                    action(currentReport);
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
