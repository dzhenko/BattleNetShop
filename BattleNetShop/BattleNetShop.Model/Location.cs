namespace BattleNetShop.Model
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PurchaseLocations")]
    public class Location
    {
        private ICollection<Purchase> purchases;

        public Location()
        {
            this.purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

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
