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

        public static void AddGame(Game game, List<GameGenre> genres, List<GamePlatform> platforms)
        {
            string cs = ConfigurationManager.ConnectionStrings["GameStoreDBConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Game VALUES (@Title);SELECT CAST(scope_identity() AS int)", con);
                con.Open();

                cmd.Parameters.AddWithValue("Title", game.Title);
                int id = Convert.ToInt32(cmd.ExecuteScalar());

                //int id = GetGameId(cs, game.Title);

                for (int i = 0; i < platforms.Count; i++)
                {
                    SqlCommand cmd3 = new SqlCommand("INSERT INTO GamePlatform (Platform, GameId, Price, InStock) VALUES (@Platform,@GameId,@Price,@InStock)", con);
                    cmd3.Parameters.AddWithValue("Platform", platforms[i].Platform);
                    cmd3.Parameters.AddWithValue("GameId", id);
                    cmd3.Parameters.AddWithValue("Price", platforms[i].Price);
                    cmd3.Parameters.AddWithValue("InStock", platforms[i].InStock);
                    cmd3.ExecuteNonQuery();
                }

                for (int i = 0; i < genres.Count; i++)
                {
                    SqlCommand cmd4 = new SqlCommand("INSERT INTO GameGenres VALUES (@GameId,@Genre)", con);
                    cmd4.Parameters.AddWithValue("GameId", id);
                    cmd4.Parameters.AddWithValue("Genre", genres[i].Genre);
                    cmd4.ExecuteNonQuery();
                }
            }
        }
    }
}