namespace BattleNetShop.ReportsModel
{
    using System;
    using System.Collections.Generic;

    public class ProductsReport
    {
        private IEnumerable<ProductInformation> products;

        public ProductsReport()
        {
            this.products = new List<ProductInformation>();
        }

        public DateTime Date { get; set; }

        public IEnumerable<ProductInformation> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }
    }
}
