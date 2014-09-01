﻿namespace BattleNetShop.Data.Pdf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.ReportsModel;

    public class PdfHandler
    {
        private Lazy<PdfWriter> pdfWriter = new Lazy<PdfWriter>();

        public void GenerateAllProductsInformation(IEnumerable<ProductsReportEntry> productInformations)
        {
            // magic DATE (rows = all products names)
        }

        public void GenerateAllProductsReportForDate(ProductsReport report)
        {
            // magic DATE (rows = all products names)
        }

        public void GenerateAllProductsReportForPeriod(IEnumerable<ProductsReport> reports)
        {
            // remove this when magic is done
            reports.ToList();
            return;

            // magic DATE (rows = all products names)
            foreach (var report in reports)
            {
                this.pdfWriter.Value.GenerateReport(report, "BattleNetShop Aggregated Sales Report");
            }
        }

        public void GenerateProductInfoForDates(IEnumerable<ProductsReport> productSales)
        {
            // remove this when magic is done
            productSales.ToList();
            return;

            // PRoduct (rows = dates)
        }

        public void GenerateProductInfoForLocations(IEnumerable<ProductsReport> productSales)
        {
            // remove this when magic is done
            productSales.ToList();
            return;

            // product (rows = locations)
        }

        public void GenerateLocationReportForDate(ProductsReport report)
        {
            // magic
        }

        public void GenerateLocationReportForPeriod(IEnumerable<ProductsReport> reports)
        {
            // remove this when magic is done
            reports.ToList();
            return;

            // magic
        }
    }
}
