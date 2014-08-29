namespace BattleNetShop.Model
{
    using System.Collections.Generic;

    public class Purchase
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int DateId { get; set; }
        public virtual Date Date { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
