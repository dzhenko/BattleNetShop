namespace BattleNetShop.Data.JSON
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class JSONHandler
    {
        // Tuple<string, ICollection<Tuple<int, string, string, int, decimal>> will become a class
        // Task 4 output

        //NOTES:
        // We can use this Library: JSON.NET - Installed via Nuged Packages
        // http://james.newtonking.com/json

        private List<JSONReport> AllReports { get; set; }

        public JSONHandler()
        {
            this.AllReports = new List<JSONReport>();
        }

        public void AddReport(JSONReport report)
        {
            this.AllReports.Add(report);
        }

        public void GenerateJSONFileReports(string saveDirectory)
        {
            foreach (var report in this.AllReports)
            {
                // Serialize the report and save it to file in the hard drive!
                TextWriter writer = File.CreateText(String.Format("{0}{1}.json", saveDirectory, report.ProductID));
                using (writer)
                {
                    writer.Write(report.ToString());
                }
                Console.WriteLine("{0}.json file saved in {1}", report.ProductID, saveDirectory);
                Console.WriteLine(report);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("\n");
            Console.WriteLine("JSON REPORTS were created successfully");
        }
    }
}
