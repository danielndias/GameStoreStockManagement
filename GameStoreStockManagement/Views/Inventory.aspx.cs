using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStoreStockManagement
{
    public partial class Inventory : System.Web.UI.Page
    {
        public List<Game> listGames = DataLayerAccess.GetGames();
        public List<Game> searchGames = new List<Game>();
        public string searchResult = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtbSearch_Click(object sender, EventArgs e)
        {
            searchGames = DataLayerAccess.GetGamesByTitle(TxtTitle.Text);
            searchResult = searchGames.Count == 0 ? "No games found." : "";
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            searchGames = null;
            searchResult = "";
            Response.Redirect("Inventory.aspx");
        }
    }
}