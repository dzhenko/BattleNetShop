namespace BattleNetShop.Data.MySqlTelerikDA
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.JSON;

    public class MySqlTelerikHandler
    {
        public MySqlSaleReportEntities connection { get; set; }

        public MySqlTelerikHandler()
        {
            this.connection = new MySqlSaleReportEntities();
        }

        public List<JSONReport> ReadAllReports()
        {
            List<JSONReport> allReports = new List<JSONReport>();

            using (this.connection)
            {
                foreach (var report in this.connection.Salereports)
                {
                    JSONReport currentReport = 
                        new JSONReport(report.Product_id, report.ProductName, 
                                       report.VendorName, report.TotalQuantitySold, 
                                       report.TotalIncomes);
                    allReports.Add(currentReport);
                }
            }

            return allReports;
        }

        public void WriteReport(int productId, string productName, string vendorName, int totalQuantitySold, int totalIncomes)
        {
            using (this.connection)
            {
                Salereport newReport = new Salereport();
                newReport.Product_id = productId;
                newReport.ProductName = productName;
                newReport.VendorName = vendorName;
                newReport.TotalQuantitySold = totalQuantitySold;
                newReport.TotalIncomes = totalIncomes;
                this.connection.Add(newReport);
                this.connection.SaveChanges();
                Console.WriteLine("REPORT SUCCESSFULLY RECORDED TO MYSQL!");
            }
        }
    }
}
