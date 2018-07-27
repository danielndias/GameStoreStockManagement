namespace GameStoreStockManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GamePlatform")]
    public partial class GamePlatform
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public string Platform { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int InStock { get; set; }

        public virtual Game Game { get; set; }

        public virtual List<InvoiceGame> InvoiceGames { get; set; }
    }
}
