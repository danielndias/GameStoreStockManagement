using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStoreStockManagement
{
    public partial class EditItem : System.Web.UI.Page
    {
        public List<string> platformNames = new List<string>() { "Playstation3", "Playstation4", "XBoxOne", "XBox360", "Wii", "WiiU", "PC" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] == null)
            { 
                Response.Redirect("~/checkInventory.aspx");
            }

            List<string> genreList = DataLayerAccess.GetGenres();

            if (CheckBoxList1.Items.Count == 0)
            {
                for (int i = 0; i < genreList.Count; i++)
                {
                    CheckBoxList1.Items.Add(genreList[i]);
                }
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Game game = DataLayerAccess.GetGameById(id);

                TxtTitle.Text = game.Title;
                DdlRating.SelectedValue = game.Rating;
                TxtYear.Text = game.ReleaseYear.ToString();
                for (int i = 0; i < game.GameGenres.Count; i++)
                {
                    for (int j = 0; j < CheckBoxList1.Items.Count; j++)
                    {
                        if (CheckBoxList1.Items[j].Text == game.GameGenres[i].Genre)
                        {
                            CheckBoxList1.Items[j].Selected = true;
                            break;
                        }
                    }
                }
                for (int i = 0; i < game.GamePlatforms.Count; i++)
                {
                    string chkPlatformId = "Chk" + game.GamePlatforms[i].Platform.ToString().Replace(" ", "");
                    CheckBox chk = (CheckBox)FindControlRecursive(Panel1, chkPlatformId);
                    chk.Checked = true;

                    string txtPriceId = "TxtPrice" + game.GamePlatforms[i].Platform.ToString().Replace(" ", "");
                    TextBox txtPrice = (TextBox)FindControlRecursive(Panel1, txtPriceId);
                    txtPrice.Text = game.GamePlatforms[i].Price.ToString();

                    string txtStockId = "TxtStock" + game.GamePlatforms[i].Platform.ToString().Replace(" ", "");
                    TextBox txtStock = (TextBox)FindControlRecursive(Panel1, txtStockId);
                    txtStock.Text = game.GamePlatforms[i].InStock.ToString();
                }
            }
            
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate("ValPlatform");
            if (Page.IsValid)
            {
                List<GamePlatform> listPlatforms = new List<GamePlatform>();
                List<GameGenre> listGenres = new List<GameGenre>();

                int id = Convert.ToInt32(Request.QueryString["id"]);
                Game game = new Game();

                game.Title = TxtTitle.Text;
                game.Rating = DdlRating.SelectedValue;
                game.ReleaseYear = Convert.ToInt32(TxtYear.Text);

                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    ListItem chk = CheckBoxList1.Items[i];
                    if (chk.Selected)
                    {
                        GameGenre gg = new GameGenre();
                        gg.Genre = chk.Text;
                        game.GameGenres.Add(gg);
                    }
                }

                for (int i = 0; i < Panel1.Controls.Count; i++)
                {
                    if (Panel1.Controls[i] is CheckBox)
                    {
                        for (int j = 0; j < platformNames.Count; j++)
                        {
                            // generate the id's
                            string chkId = "Chk" + platformNames[j];
                            string txtPriceId = "TxtPrice" + platformNames[j];
                            string txtStockId = "TxtStock" + platformNames[j];

                            // get the proper controls from the html
                            CheckBox chk = (CheckBox)Panel1.Controls[i];
                            TextBox txtPrice = (TextBox)FindControlRecursive(Panel1, txtPriceId);
                            TextBox txtStock = (TextBox)FindControlRecursive(Panel1, txtStockId);

                            if (chk != null && chk.ID.Equals(chkId) && chk.Checked)
                            {
                                GamePlatform gp = new GamePlatform();
                                gp.Platform = chk.Text;
                                gp.Price = Convert.ToInt32(txtPrice.Text);
                                gp.InStock = Convert.ToInt32(txtStock.Text);
                                game.GamePlatforms.Add(gp);
                            }
                        }
                    }
                }
               
                DataLayerAccess.UpdateGame(game);
                Response.Redirect("~/checkInventory.aspx");
            }

        }

        private Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn = FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null)
                    return controlToReturn;
            }
            return null;
        }

        protected bool MultipleFieldValidation(object source)
        {
            CustomValidator validationControl = (CustomValidator)source;

            string txtBoxId = ((CustomValidator)source).ControlToValidate;
            TextBox txtBox = (TextBox)((CustomValidator)source).Parent.FindControl(txtBoxId);

            string id = (txtBox.ID).Substring(8);
            string chkPlatformId = "Chk" + id;

            CheckBox chkPlatform = (CheckBox)FindControlRecursive(Panel1, chkPlatformId);

            if (chkPlatform != null && chkPlatform.Checked && !String.IsNullOrEmpty(txtBox.Text))
            {
                return true;
            }
            else if ((chkPlatform != null && !chkPlatform.Checked && !String.IsNullOrEmpty(txtBox.Text))
                || (chkPlatform != null && chkPlatform.Checked && String.IsNullOrEmpty(txtBox.Text)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool IsChekBoxChecked(object source)
        {
            CustomValidator validationControl = (CustomValidator)source;

            string boxId = ((CustomValidator)source).ControlToValidate;
            var box = ((CustomValidator)source).Parent.FindControl(boxId);
            string id = "";
            string txtPriceId = "";
            string txtStockId = "";
            string chkPlatformId = "";

            if (box is CheckBox)
            {
                id = box.ID.Substring(4);
                txtPriceId = "TxtPrice" + id;
                txtStockId = "TxtStock" + id;

                TextBox txtPrice = (TextBox)FindControlRecursive(Panel1, txtPriceId);
                TextBox txtStock = (TextBox)FindControlRecursive(Panel1, txtStockId);
                CheckBox chkPlatform = (CheckBox)box;
                if (chkPlatform != null && chkPlatform.Checked && !String.IsNullOrEmpty(txtPrice.Text) && !String.IsNullOrEmpty(txtStock.Text))
                {
                    return true;
                }
                else if (!chkPlatform.Checked && String.IsNullOrEmpty(txtPrice.Text) && !String.IsNullOrEmpty(txtStock.Text))
                {
                    return false;
                }
            }
            else
            {
                TextBox txtBox = (TextBox)box;
                id = box.ID.Substring(8);
                chkPlatformId = "Chk" + id;

                CheckBox chkPlatform = (CheckBox)FindControlRecursive(Panel1, chkPlatformId);

                if (chkPlatform != null && chkPlatform.Checked && !String.IsNullOrEmpty(txtBox.Text))
                {
                    return true;
                }
                else if (!chkPlatform.Checked && String.IsNullOrEmpty(txtBox.Text))
                {
                    return false;
                }
            }
            return false;
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator6_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator7_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator8_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator9_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator10_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator11_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator12_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator13_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator14_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = MultipleFieldValidation(source);
        }

        protected void CustomValidator15_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CheckBoxList1.SelectedIndex != -1 ? true : false;
        }

        protected void CustomValidator16_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = IsChekBoxChecked(source);
        }

        protected void CustomValidator17_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = IsChekBoxChecked(source);
        }

        protected void CustomValidator18_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = IsChekBoxChecked(source);
        }

        protected void CustomValidator19_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = IsChekBoxChecked(source);
        }

        protected void CustomValidator20_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = IsChekBoxChecked(source);
        }

        protected void CustomValidator21_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = IsChekBoxChecked(source);
        }

        protected void CustomValidator22_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = IsChekBoxChecked(source);
        }

        
    }
}