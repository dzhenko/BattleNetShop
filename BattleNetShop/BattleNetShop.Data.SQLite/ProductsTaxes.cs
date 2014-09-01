namespace BattleNetShop.Data.SqLite
{
    using System;

    public class ProductsTaxes
    {
        public ProductsTaxes(string productName, float tax)
        {
            this.ProductName = productName;
            this.Tax = tax;
        }

        public string ProductName { get; set; }

        public float Tax { get; set; }
    }
}
