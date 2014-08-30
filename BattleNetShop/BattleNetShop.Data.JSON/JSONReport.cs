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
        [JsonProperty(PropertyName = "product-id")]
        public int ProductID { get; set; }

        [JsonProperty(PropertyName = "product-name")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "vendor-name")]
        public string VendorName { get; set; }

        [JsonProperty(PropertyName = "total-quantity-sold")]
        public int TotalQuantitySold { get; set; }

        [JsonProperty(PropertyName = "total-incomes")]
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
