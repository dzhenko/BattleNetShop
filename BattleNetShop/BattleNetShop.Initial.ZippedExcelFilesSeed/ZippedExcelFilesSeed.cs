namespace BattleNetShop.Initial.ZippedExcelFilesSeed
{
    /// <summary>
    /// Class used to initialize the data in the MongoDB used as input for task one.
    /// The data is retrieved from an excel file in the Project directory.
    /// </summary>
    public class ZippedExcelFilesSeed
    {
        // The Excel files are given inside a ZIP archive holding subfolders named as the dates of the report in format dd-MMM-yyyy.
        // Note that the ZIP file could contain few hundred dates (folders), each holding few hundreds Excel files, each holding thousands of data.
        // Input: MongoDB database; ZIP file with Excel 2003 reports (xls files).
        public static void SeedData()
        {

        }
    }
}
