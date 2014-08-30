namespace BattleNetShop.Data.JSON
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    public class JSONReport
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string VendorName { get; set; }
        public int TotalQuantitySold { get; set; }
        public int TotalIncomes { get; set; }

        public JSONReport(int productID, string productName, string vendorName, int totalQuantitySold, int totalIncomes)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.VendorName = vendorName;
            this.TotalQuantitySold = totalQuantitySold;
            this.TotalIncomes = totalIncomes;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
