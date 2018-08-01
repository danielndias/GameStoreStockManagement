using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStoreStockManagement
{
    public partial class Sale : System.Web.UI.Page
    {
        public List<GamePlatform> searchInventory = new List<GamePlatform>();
        public GamePlatform gp = new GamePlatform();
        public string searchResult = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            searchInventory = DataLayerAccess.GetGamesPlatform(TxtGameName.Text, DdlPlatform.Text);
            searchResult = (searchInventory.Count > 0) ? "" : "No games found.";
        }

        protected void AddToCart(object sender, EventArgs e)
        {

        }
    }
}