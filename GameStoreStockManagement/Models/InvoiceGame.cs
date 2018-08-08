namespace GameStoreStockManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceGame")]
    public partial class InvoiceGame
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int InvoiceId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int QuantitySold { get; set; }

        [Required]
        public int ItemId { get; set; }

        public virtual GamePlatform Item { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
