using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStoreStockManagement
{
    public partial class DeleteItem : System.Web.UI.Page
    {

        public Game game = new Game();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/checkInventory.aspx");
            }

            int id = Convert.ToInt32(Request.QueryString["id"]);

            game = DataLayerAccess.GetGameById(id);
        }

        

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataLayerAccess.DeleteGame(game);
            Response.Redirect("~/checkInventory.aspx");
        }
    }
}