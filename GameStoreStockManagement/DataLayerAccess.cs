using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameStoreStockManagement
{
    public class DataLayerAccess
    {
        public string ConnectionManager { get; private set; }

        /// <summary>
        ///  Context object for linq queries. 
        /// </summary>
        private static GameStoreDB _context = new GameStoreDB();

        /// <summary>
        /// Returns all the genres from DB
        /// </summary>
        /// <returns></returns>
        public static List<string> GetGenres()
        {
            return _context.Genres
                .Select(m => m.Name)
                .ToList();
        }

        /// <summary>
        /// Returns all the platforms from DB
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPlatformsNames()
        {
            return _context.Platforms
                .Select(m => m.Name)
                .ToList();
        }

        /// <summary>
        /// Returns all the platform fieldId's from DB
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPlatformsFieldIds()
        {
            return _context.Platforms
                .Select(m => m.FieldId)
                .ToList();
        }

        /// <summary>
        /// Adds a game to DB
        /// </summary>
        /// <param name="game"></param>
        public static void AddGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }
        /// <summary>
        /// Updates the game with adding/deleting/updating the related child entries in the DB
        /// </summary>
        /// <param name="newGame"></param>
        public static void UpdateGame(Game newGame)
        {
            Game oldGame = GetGameByTitle(newGame.Title);

            oldGame.Title = newGame.Title;

            oldGame.GamePlatforms.Clear();
            oldGame.GameGenres.Clear();
            
            for (int i = 0; i < newGame.GamePlatforms.Count; i++)
            {
                GamePlatform gp = new GamePlatform();
                gp.Platform = newGame.GamePlatforms[i].Platform;
                gp.Price = newGame.GamePlatforms[i].Price;
                gp.InStock = newGame.GamePlatforms[i].InStock;

                oldGame.GamePlatforms.Add(gp);
            }

            for (int i = 0; i < newGame.GameGenres.Count; i++)
            {
                GameGenre gg = new GameGenre();

                gg.Genre = newGame.GameGenres[i].Genre;
                oldGame.GameGenres.Add(gg);
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the game and all related child entries from DB
        /// </summary>
        /// <param name="game"></param>
        public static void DeleteGame(Game game)
        {
            Game Game = _context.Games
                .Where(m => m.Id == game.Id)
                .FirstOrDefault();

            _context.Games.Remove(game);

            _context.SaveChanges();
        }

        /// <summary>
        /// Returns all the games
        /// </summary>
        /// <returns></returns>
        public static List<Game> GetGames()
        {
            return _context.Games
                .Include("GamePlatforms")
                .ToList();
        }

        /// <summary>
        /// Returns a game with ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Game GetGameById(int id)
        {
            return _context.Games
                .Include("GamePlatforms")
                .Include("GameGenres")
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Returns a game according to the title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static Game GetGameByTitle(string title)
        {
            return _context.Games
                .Include("GamePlatforms")
                .Include("GameGenres")
                .Where(m => m.Title == title)
                .FirstOrDefault();
        }

        /// <summary>
        /// Returns all the games which title contains the given string 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static List<Game> GetGamesByTitle(string title)
        {
            return _context.Games
                .Include("GamePlatforms")
                .Include("GameGenres")
                .Where(m => m.Title.ToLower().Contains(title.Trim()))
                .ToList();
        }

        public static List<GamePlatform> GetGamesByPlatform(string platform)
        {
            return _context.GamePlatforms
                 .Include("Game")
                 .Where(m => m.Platform.ToLower().Contains(platform.Trim()))
                 .ToList();
        }

        /// <summary>
        /// Returns all the games which title and platform contains the given strings
        /// </summary>
        /// <param name="title"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static List<GamePlatform> GetGamesPlatform(string title, string platform)
        {
            return _context.GamePlatforms
                .Include("Game")
                .Where(m => m.Game.Title.ToLower().Contains(title.Trim()) && (m.Platform.ToLower().Contains(platform.Trim())))
                .ToList();
        }

        /// <summary>
        /// Returns the gamePlatform with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GamePlatform GetGamePlatform(int id)
        {
            return _context.GamePlatforms
                .Include("Game")
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Adds an invoice to DB
        /// </summary>
        /// <param name="invoice"></param>
        public static void AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        /// <summary>
        /// Adds an invoiceGame to DB
        /// </summary>
        /// <param name="invoiceGame"></param>
        public static void AddInvoiceGame(InvoiceGame invoiceGame)
        {
            _context.InvoiceGames.Add(invoiceGame);
            _context.SaveChanges();
        }

        /// <summary>
        /// Returns the last invoice added
        /// </summary>
        /// <returns></returns>
        public static Invoice GetLastInvoice()
        {
            return _context.Invoices
                .OrderByDescending(x => x.Id)
                .Take(1)
                .FirstOrDefault();
        }

        /// <summary>
        /// Updates the stock of a game
        /// </summary>
        /// <param name="gamePlatId"></param>
        /// <param name="newStock"></param>
        public static void UpdateStock(int gamePlatId, int newStock)
        {
            GamePlatform gp = GetGamePlatform(gamePlatId);
            gp.InStock = newStock;

            _context.SaveChanges();
        }

        /// <summary>
        /// Returns an invoice
        /// </summary>
        /// <returns></returns>
        public static List<Invoice> GetAllInvoices()
        {
            return _context.Invoices
                .Include("InvoiceGames")
                .ToList();
        }

        /// <summary>
        /// Returns an invoice
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Invoice GetInvoice(int id)
        {
            return _context.Invoices
                .Include("InvoiceGames")
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}