namespace BattleNetShop.Data.JSON
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Newtonsoft.Json;

    using BattleNetShop.Data.MySql;

    public class JSONHandler
    {
        public void GenerateJSONFileReports()
        {
            this.GenerateJSONFileReports(JSONSettings.Default.ReportsDestinationFolder);
        }
        public void GenerateJSONFileReports(string saveDirectory)
        {
            var handler = new MySqlHandler();

            handler.ReadAllReports(report =>
                {
                    using (var writer = File.CreateText(String.Format("{0}{1}.json", saveDirectory, report.Product_id)))
                    {
                        writer.Write(JsonConvert.SerializeObject(report));
                    }

                    Console.WriteLine("{0}.json file saved in {1}", report.Product_id, saveDirectory);
                    Console.WriteLine(report);
                    Console.WriteLine("--------------------");
                });

            Console.WriteLine("\n");
            Console.WriteLine("JSON REPORTS were created successfully");
        }
    }
}
