namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Data.OleDb;
    using System.Data;

    using ExcelFile.net;
    using NPOI.HSSF.Util;

    using BattleNetShop.Utils.ZipFileHandler;

    public class ExcelZippedDataSeeder
    {
        private Dictionary<int, double> productsWithPrices;
        private List<string> purchaseLocations;

        private readonly Random random;

        public ExcelZippedDataSeeder()
        {
            random = new Random();
        }

        public void Seed()
        {
            this.Seed(ExcelSettings.Default.SalesReportsFoldersLocation, 20);
        }

        public void Seed(string destinationPath, int numberOfRecords)
        {
            Console.WriteLine("Seeding excel 2003 sales reports");

            GenerateDataToUse();

            GenerateAllFolders(destinationPath, numberOfRecords);

            GenerateZipFile();

            Console.WriteLine("Done");
        }

        private void GenerateZipFile()
        {
            Console.WriteLine("Zipping files...");

            var zip = new ZipFileHandler();

            zip.ZipFolder(ExcelSettings.Default.SalesReportsFoldersLocation,
                ExcelSettings.Default.ZipFileResultLocation);
        }

        private void GenerateAllFolders(string destinationPath, int numberOfRecords)
        {
            Console.WriteLine("Generating sample sales reports...");

            var startDate = new DateTime(2014, 1, 1);

            for (int i = 0; i < numberOfRecords; i++)
            {
                Console.WriteLine("Now generating report {0} of {1}", i + 1, numberOfRecords);

                var dateAsString = startDate.ToString("dd-MMM-yyyy");
                var currentDestinationPath = destinationPath + string.Format(@"\{0}", dateAsString);

                Directory.CreateDirectory(currentDestinationPath);

                foreach (var location in purchaseLocations)
                {
                    var currentFilePath = currentDestinationPath 
                        + string.Format(@"\{0}-Purchases-Report-{1}.xls", location, dateAsString);

                    WriteFile(currentFilePath, location);
                }

                startDate = startDate.AddDays(1);
            }
        }

        private void GenerateDataToUse()
        {
            Console.WriteLine("Reading sample Products to use...");

            var excelHander = new ExcelXlsHandler();

            productsWithPrices = new Dictionary<int, double>();

            excelHander.ReadExcelSheet(ExcelSettings.Default.InitialProductsFileLocation, "Products", reader =>
            {
                productsWithPrices.Add((int)(double)reader["Id"], (double)reader["Base Price"]);
            });

            purchaseLocations = new List<string>();

            excelHander.ReadExcelSheet(ExcelSettings.Default.InitialProductsFileLocation, "Locations", reader =>
            {
                purchaseLocations.Add((string)reader["Name"]);
            });
        }

        private void WriteFile(string filename, string location)
        {
            var excel = new ExcelFile();

            excel.Sheet("Sale Report");

            excel.Row(30, excel.NewStyle()
                .Background(HSSFColor.Aqua.Index)
                .Align(NPOI.SS.UserModel.HorizontalAlignment.CenterSelection)
                .Bold()
                .FontSize(200.00))
                .Cell("Sales in Realm " + location, 1, 4);

            excel.Row().Cell("ProductId").Cell("Quantity").Cell("Unit Price").Cell("Sum");

            var totalRows = random.Next(15, 30);
            var totalSum = 0.0;

            for (int i = 0; i < totalRows / 2; i++)
            {
                var index = random.Next(1, 27);
                var quantity = random.Next(1, 10);
                var price = Math.Round(productsWithPrices[index] * (1 + (random.Next(5, 25) / 100.0)),2);
                excel.Row().Cell(index).Cell(quantity).Cell(price).Cell((quantity * price));
            }

            for (int i = 0; i < totalRows / 2; i++)
            {
                var index = random.Next(34, 45);
                var quantity = random.Next(25, 95);
                var price = Math.Round(productsWithPrices[index] * (1 + (random.Next(5, 25) / 100.0)));
                excel.Row().Cell(index).Cell(quantity).Cell(price).Cell((quantity * price));
            }

            var characterIndex = random.Next(27,34);
            var characterPrice = Math.Round(productsWithPrices[characterIndex] * (1 + (random.Next(5, 25) / 100.0)),2);
            excel.Row().Cell(characterIndex).Cell(1).Cell(characterPrice).Cell(characterPrice);
            totalSum += characterPrice;

            var accountIndex = random.Next(45, 51);
            var accountPrice = Math.Round(productsWithPrices[accountIndex] * (1 + (random.Next(5, 25) / 100.0)));
            excel.Row().Cell(accountIndex).Cell(1).Cell(accountPrice).Cell(accountPrice);
            totalSum += accountPrice;

            excel.Row()
                .Cell("Total", 1, 3)
                .Cell(totalSum + 0.0, 1, 1, excel.NewStyle().Bold());

            excel.Save(filename);
        }
    }
}
