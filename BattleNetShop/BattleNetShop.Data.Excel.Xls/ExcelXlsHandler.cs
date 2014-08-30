namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using System.Data;
    using System.Data.OleDb;

    using BattleNetShop.Utils.ZipFileHandler;

    /// <summary>
    /// Holds All operation with the excel files via the standard ADO.NET OleDb.
    /// </summary>
    public class ExcelXlsHandler
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
        /// <param name="zipFileLocation">The Zip File To Open</param>
        /// <param name="action">Action to perform on the returned ProductId, Quantity, UnitPrice, LocationName and Date.</param>
        public void ReadAllPurchases(string zipFileLocation, Action<int, int, decimal, string, DateTime> action)
        {
            const string tempFolderName = @"UnzippedSalesReports";

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

                    this.ReadExcelSheet(file, row =>
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

        /// <summary>
        /// Reads a single Excel sheet and performs action of your choice.
        /// </summary>
        /// <param name="fileName">The file you want to read. Always reads the first sheet.</param>
        /// <param name="actionForEachRow">Action to perform on the returned DataTableReader.</param>
        public void ReadExcelSheet(string fileName, Action<DataTableReader> actionForEachRow)
        {
            this.ReadExcelSheet(fileName, null, actionForEachRow);
        }

        /// <summary>
        /// Reads a single Excel sheet and performs action of your choice.
        /// </summary>
        /// <param name="fileName">The file you want to read.</param>
        /// <param name="sheetName">The sheet you want to read.</param>
        /// <param name="actionForEachRow">Action to perform on the returned DataTableReader.</param>
        public void ReadExcelSheet(string fileName, string sheetName, Action<DataTableReader> actionForEachRow)
        {
            var connectionString = string.Format(ExcelSettings.Default.ExcelConnectionStringFormat, fileName);

            using (var excelConnection = new OleDbConnection(connectionString))
            {
                excelConnection.Open();

                if (sheetName == null)
                {
                    var excelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                }

                var excelDbCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "]", excelConnection);

                using (var oleDbDataAdapter = new OleDbDataAdapter(excelDbCommand))
                {
                    DataSet dataSet = new DataSet();
                    oleDbDataAdapter.Fill(dataSet);

                    using (var reader = dataSet.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            actionForEachRow(reader);
                        }
                    }
                }
            }
        }
    }
}
