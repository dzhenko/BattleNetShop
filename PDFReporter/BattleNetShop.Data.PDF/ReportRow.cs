using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleNetShop.Data.PDF
{
    public class ReportRow
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Vendor { get; set; }
        public double Sum { get; set; }

        public ReportRow(string productName, int quantity, double unitPrice, string vendor)
        {
            this.ProductName = productName;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.Vendor = vendor;
            this.Sum = this.Quantity * this.UnitPrice;
        }
    }
}
