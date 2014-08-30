namespace Problem_4_GenerateJSONFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.JSON;
    class Program
    {
        static void Main()
        {
            JSONHandler reporter = new JSONHandler();

            JSONReport simpleReport1 = new JSONReport(1,"Sword of Justice", "Blizzard", 255, 655);
            JSONReport simpleReport2 = new JSONReport(3, "Gold", "Blizzard", 500000, 5468);
            JSONReport simpleReport3 = new JSONReport(4, "Awesome Item 2", "Blizzard", 346, 1235);
            JSONReport simpleReport4 = new JSONReport(22, "DOOMBRINGER", "Bulgarian PRO", 235, 48647);

            reporter.AddReport(simpleReport1);
            reporter.AddReport(simpleReport2);
            reporter.AddReport(simpleReport3);
            reporter.AddReport(simpleReport4);

            reporter.GenerateJSONFileReports("../../../Json-Reports/");


        }
    }
}
