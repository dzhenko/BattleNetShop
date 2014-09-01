using BattleNetShop.Data.Excel.Xlsx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlsxReport
{
    class Program
    {
        static void Main(string[] args)
        {
            var xlsxHandler = new ExcelXlsxHandler();
            var reportData = new List<Tuple<string, decimal, decimal, decimal>>();
            reportData.Add(new Tuple<string, decimal, decimal, decimal>("Item1", 1m, 2m, 3m));
            reportData.Add(new Tuple<string, decimal, decimal, decimal>("Item2", 1m, 2m, 3m));
            reportData.Add(new Tuple<string, decimal, decimal, decimal>("Item3", 1m, 2m, 3m));
            reportData.Add(new Tuple<string, decimal, decimal, decimal>("Item4", 1m, 2m, 5m));
            xlsxHandler.GenerateVendorsFinancialResultsReport(reportData, "test.xlsx");
        }
    }
}
