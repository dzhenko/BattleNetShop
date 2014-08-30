namespace Problem_4_MySql_ReadWriteReports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.MySql;
    class Program
    {
        static void Main()
        {
            var mysqlReporter = new MySqlHandler();
            mysqlReporter.ReadAllReports(report => 
            {
                Console.WriteLine("ID: {0}", report.Product_id);
                Console.WriteLine("ProductName: {0}", report.ProductName);
                Console.WriteLine("VendorName: {0}", report.VendorName);
                Console.WriteLine("Total Quantity Sold: {0}", report.TotalQuantitySold);
                Console.WriteLine("Total Incomes: {0}", report.TotalIncomes);
                Console.WriteLine("------------------------");
            });
        }
    }
}
