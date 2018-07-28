using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStoreStockManagement
{
    public partial class checkInventory : System.Web.UI.Page
    {

        public List<Game> listGames = DataLayerAccess.GetGames();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

    }
}