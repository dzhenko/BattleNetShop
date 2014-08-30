namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using System.Data;
    using System.Data.OleDb;

    using BattleNetShop.Utils.ZipFileHandler;
    using BattleNetShop.Model;

    /// <summary>
    /// Class holding all xls files data manipulation
    /// </summary>
    public class ExcelXlsData
    {
        /// <summary>
        /// Reads every row of every report and performs an action of your choice.
        /// </summary>
        /// <param name="action">Action to perform on the returned ProductId, Quantity, UnitPrice, LocationName and Date.</param>
        public void ReadAllPurchases(Action<int, int, decimal, string, DateTime> action)
        {
            this.ReadAllPurchases(ExcelSettings.Default.ZipFileResultLocation, action);
        }

        /// <summary>
        /// Reads every row of every report and performs an action of your choice.
        /// </summary>
        /// <param name="action">Action to perform on the returned ProductId, Quantity, UnitPrice, LocationName and Date.</param>
        public void ReadAllPurchases(IDictionary<string, int> locationsMapping, Action<Purchase> action)
        {
            this.ReadAllPurchases(ExcelSettings.Default.ZipFileResultLocation, (productId, quantity, unitPrice, locationName, date) =>
                {
                    action(new Purchase()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        LocationId = locationsMapping[locationName],
                        Date = date
                    });
                });
        }

        /// <summary>
        /// Reads every row of every report and performs an action of your choice.
        /// </summary>
        /// <param name="zipFileLocation">The Zip File To Open</param>
        /// <param name="action">Action to perform on the returned ProductId, Quantity, UnitPrice, LocationName and Date.</param>
        public void ReadAllPurchases(string zipFileLocation, Action<int, int, decimal, string, DateTime> action)
        {
            const string tempFolderName = @"UnzippedSalesReports";

            var excelXlsHander = new ExcelXlsHandler();

            var zip = new ZipFileHandler();

            zip.UnzipFolder(zipFileLocation, tempFolderName);

            foreach (var subfolder in Directory.GetDirectories(tempFolderName))
            {
                var dateAsString = subfolder.Substring(subfolder.LastIndexOf('\\') + 1);
                var date = DateTime.ParseExact(dateAsString, "dd-MMM-yyyy", CultureInfo.InvariantCulture);

                foreach (var file in Directory.GetFiles(subfolder))
                {
                    var slashIndex = file.LastIndexOf('\\') + 1;
                    var locationName = file.Substring(slashIndex, file.IndexOf('-', slashIndex));

                    excelXlsHander.ReadExcelSheet(file, row =>
                    {
                        if (row[0] != DBNull.Value)
                        {
                            action((int)(double)row[0], (int)(double)row[1], (decimal)(double)row[2], locationName, date);
                        }
                    });
                }
            }

            Directory.Delete(tempFolderName, true);
        }

        
    }
}
