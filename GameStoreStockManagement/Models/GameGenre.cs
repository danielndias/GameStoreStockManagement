using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GameStoreStockManagement
{
    public class GameGenre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public string Genre { get; set; }

        public virtual Game Game { get; set; }
    }
}