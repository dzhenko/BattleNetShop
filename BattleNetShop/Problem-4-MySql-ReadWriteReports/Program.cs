namespace Problem_4_MySql_ReadWriteReports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.MySqlTelerikDA;
    class Program
    {
        static void Main()
        {
            MySqlTelerikHandler mysqlReporter = new MySqlTelerikHandler();
            var allReports = mysqlReporter.ReadAllReports();

            // Example for using the reports
            foreach (var report in allReports)
            {
                Console.WriteLine("ID: {0}", report.ProductID);
                Console.WriteLine("ProductName: {0}", report.ProductName);
                Console.WriteLine("VendorName: {0}", report.VendorName);
                Console.WriteLine("Total Quantity Sold: {0}", report.TotalQuantitySold);
                Console.WriteLine("Total Incomes: {0}", report.TotalIncomes);
                Console.WriteLine("------------------------");
            }
        }
    }
}
