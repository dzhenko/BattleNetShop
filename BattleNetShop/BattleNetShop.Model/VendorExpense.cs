namespace BattleNetShop.Model
{
    using System;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VendorExpenses")]
    public class VendorExpense
    {
        public int Id { get; set; }

        [Required]
        public decimal Ammount { get; set; }

        [Required]
        public string Month { get; set; }

        [NotMapped]
        public string VendorName { get; set; }

        [Required]
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
