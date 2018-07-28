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

        public static GameStoreDB context = new GameStoreDB();


        public static List<string> GetGenres()
        {
            string cs = ConfigurationManager.ConnectionStrings["GameStoreDBConnectionString"].ConnectionString;

            List<string> listGenres = new List<string>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Genre", con);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listGenres.Add(rdr["Name"].ToString());
                }
            }
            return listGenres;
        }


        public static List<string> GetPlatforms()
        {
            string cs = ConfigurationManager.ConnectionStrings["GameStoreDBConnectionString"].ConnectionString;

            List<string> listPlatforms = new List<string>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Platform", con);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listPlatforms.Add(rdr["Name"].ToString());
                }
            }
            return listPlatforms;
        }

        //public static void AddGame(Game game, List<GameGenre> genres, List<GamePlatform> platforms)
        //{
        //    Game newGame = new Game();
        //    game.Title = game.Title;

        //    for (int i = 0; i < platforms.Count; i++)
        //    {
        //        GamePlatform gp = new GamePlatform();

        //        gp.Platform = platforms[i].Platform;
        //        gp.Price = platforms[i].Price;
        //        gp.InStock = platforms[i].InStock;

        //        game.GamePlatforms.Add(gp);
        //    }

        //    for (int i = 0; i < genres.Count; i++)
        //    {
        //        GameGenre gg = new GameGenre();

        //        gg.Genre = genres[i].Genre;

        //        game.GameGenres.Add(gg);
        //    }

        //    context.Games.Add(game);
        //    context.SaveChanges();
        //}

        public static void AddGame(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }

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

            context.SaveChanges();
        }


        public static void DeleteGame(Game game)
        {
            Game Game = context.Games
                .Where(m => m.Id == game.Id)
                .FirstOrDefault();

            context.Games.Remove(game);

            context.SaveChanges();
        }

        public static List<Game> GetGames()
        {
            return context.Games
                .Include("GamePlatforms")
                .ToList();
        }

        public static Game GetGameById(int id)
        {
            return context.Games
                .Include("GamePlatforms")
                .Include("GameGenres")
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }

        public static Game GetGameByTitle(string title)
        {
            return context.Games
                .Include("GamePlatforms")
                .Include("GameGenres")
                .Where(m => m.Title == title)
                .FirstOrDefault();
        }
    }
}