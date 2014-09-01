namespace BattleNetShop.ReportsModel
{
    using System;

    public class JsonReport
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string VendorName { get; set; }

        public int TotalQuantitySold { get; set; }

        public int TotalIncomes { get; set; }
    }
}
