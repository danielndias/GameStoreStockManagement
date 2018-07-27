namespace GameStoreStockManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public double SubTotal { get; set; }

        [Required]
        public double Tax { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        public virtual List<InvoiceGame> InvoiceGames { get; set; }
    }
}
