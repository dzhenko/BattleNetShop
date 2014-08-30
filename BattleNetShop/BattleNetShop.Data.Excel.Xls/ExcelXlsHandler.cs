namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Collections.Generic;

    using System.Data;
    using System.Data.OleDb;

    public class ExcelXlsHandler
    {
        // Task 1 input
        public void ReadAllPurchases(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ReadExcelSheet(string fileName, string sheetName, Action<DataTableReader> actionForEachRow)
        {
            var connectionString = string.Format(ExcelSettings.Default.ExcelConnectionStringFormat, fileName);

            using (var excelConnection = new OleDbConnection(connectionString))
            {
                excelConnection.Open();

                var excelDbCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "$]", excelConnection);

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
