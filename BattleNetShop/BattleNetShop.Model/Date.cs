namespace BattleNetShop.Model
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PurchaseDates")]
    public class Date
    {
        private ICollection<Purchase> purchases;

        public Date()
        {
            this.purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        public DateTime Value { get; set; }

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
