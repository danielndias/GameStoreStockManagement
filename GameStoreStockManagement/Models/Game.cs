namespace GameStoreStockManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        public Game()
        {
            GamePlatforms = new List<GamePlatform>();
            GameGenres = new List<GameGenre>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(3)]
        public string Rating { get; set; }

        [Required]
        [Range(1980, 2050, ErrorMessage = "Year must be between 1980 to 2050.")]
        public int ReleaseYear { get; set; }

        public virtual List<GamePlatform> GamePlatforms { get; set; }

        public virtual List<GameGenre> GameGenres { get; set; }
    }
}
