namespace Problem_2_PDF_Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.PDF;
    class Program
    {
        static void Main()
        {
            PDFHandler PDFMaker = new PDFHandler();


            List<ReportRow> allReports = new List<ReportRow>();

            ReportRow simpleReport1 = new ReportRow("Sword of Justice", 455, 2.5, "Blizzard");
            ReportRow simpleReport2 = new ReportRow("Gold", 20000, 0.9, "Random Vendor");
            ReportRow simpleReport3 = new ReportRow("Stone of Jordan", 1455, 4.5, "Blizzard");
            ReportRow simpleReport4 = new ReportRow("Awesome Amulet", 2455, 1.5, "Blizzard");
            allReports.Add(simpleReport1);
            allReports.Add(simpleReport2);
            allReports.Add(simpleReport3);
            allReports.Add(simpleReport4);


            PDFMaker.TestPdfCreate(allReports);
        }
    }
}
