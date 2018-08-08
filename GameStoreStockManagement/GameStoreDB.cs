namespace GameStoreStockManagement
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameStoreDB : DbContext
    {
        public GameStoreDB()
            : base("name=GameStoreDBConnectionString")
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GamePlatform> GamePlatforms { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceGame> InvoiceGames { get; set; }
        public virtual DbSet<GameGenre> GameGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(e => e.GamePlatforms)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.GameGenres)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceGames)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<GameGenre>()
                .HasKey(e => new { e.Id, e.GameId });

            modelBuilder.Entity<GamePlatform>()
                .HasKey(e => new { e.Id, e.GameId });

            modelBuilder.Entity<InvoiceGame>()
                .HasKey(e => new { e.Id, e.InvoiceId});

            modelBuilder.Entity<InvoiceGame>()
                .HasKey(e => new { e.Id, e.ItemId });
        }
    }
}
