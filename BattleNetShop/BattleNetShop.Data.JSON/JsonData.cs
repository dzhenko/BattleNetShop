namespace BattleNetShop.Data.Json
{
    using System;
    using System.IO;

    using Newtonsoft.Json;

    using BattleNetShop.ReportsModel;

    public class JsonData
    {
        public void GenerateJSONFileReport(JsonReport report)
        {
            this.GenerateJSONFileReport(JsonSettings.Default.ReportsDestinationFolder, report);
        }
        
        public void GenerateJSONFileReport(string saveDirectory, JsonReport report)
        {
            using (var writer = File.CreateText(string.Format("{0}{1}.json", saveDirectory, report.ProductID)))
            {
                writer.Write(JsonConvert.SerializeObject(report));
            }
        }
    }
}
