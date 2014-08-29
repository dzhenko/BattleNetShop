namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ExcelZippedDataSeeder
    {
        private Dictionary<int, decimal> productsWithPrices;
        private List<string> purchaseLocations;

        private readonly Random random;

        public ExcelZippedDataSeeder()
        {
            random = new Random();
        }

        public void Seed(string destinationPath, int numberOfRecords)
        {
            GenerateDataToUse();

            GenerateAllFolders(destinationPath, numberOfRecords);

            GenerateZipFile();
        }

        private void GenerateZipFile()
        {
            
        }

        private void GenerateAllFolders(string destinationPath, int numberOfRecords)
        {
            var startDate = new DateTime(2014, 1, 1);

            for (int i = 0; i < numberOfRecords; i++)
            {
                var currentDestinationPath = destinationPath + string.Format(@"\{0}", startDate.ToString("dd-MMM-yyyy"));

                Directory.CreateDirectory(currentDestinationPath);

                foreach (var location in purchaseLocations)
                {
                    // create excel file
                }

                startDate = startDate.AddDays(1);
            }
        }

        private void GenerateDataToUse()
        {
            var excelHander = new ExcelXlsHandler();

            productsWithPrices = new Dictionary<int, decimal>();

            excelHander.ReadExcelSheet(ExcelSettings.Default.InitialProductsFileLocation, "Products", reader =>
            {
                productsWithPrices.Add((int)(double)reader["Id"], (decimal)(double)reader["Base Price"]);
            });

            purchaseLocations = new List<string>();

            excelHander.ReadExcelSheet(ExcelSettings.Default.InitialProductsFileLocation, "Locations", reader =>
            {
                purchaseLocations.Add((string)reader["Name"]);
            });
        }
    }
}
