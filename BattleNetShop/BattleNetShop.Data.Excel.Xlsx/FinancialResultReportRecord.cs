namespace BattleNetShop.Data.Excel.Xlsx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FinancialResultReportRecord
    {
        // TODO: add expenses ?
        public string VendorName { get; set; }

        public decimal Incomes { get; set; }

        public decimal Taxes { get; set; }

        public decimal FinancialBalance { get; set; }
    }
}
