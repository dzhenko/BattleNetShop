namespace BattleNetShop.Model
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        private ICollection<Purchase> purchases;

        public Product()
        {
            this.purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int DetailsId { get; set; }
        public virtual Details Details { get; set; }

        public Measure Measure { get; set; }

        public decimal BasePrice { get; set; }

        public virtual ICollection<Purchase> Purchases
        {
            get
            {
                return this.purchases;
            }
            set
            {
                this.purchases = value;
            }
        }
    }
}
