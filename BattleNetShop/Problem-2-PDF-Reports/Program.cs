namespace Problem_2_PDF_Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.PDF;
    class Program
    {
        static void Main()
        {
            PDFHandler PDFMaker = new PDFHandler();
            PDFMaker.TestPdfCreate();
        }
    }
}
