using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStoreStockManagement
{
    public partial class addToInventory : System.Web.UI.Page
    {
        public List<string> platformNames = new List<string>() { "Ps3", "Ps4", "XBoxOne", "XBox360", "Wii", "WiiU", "Pc"};

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate("ValPlatform");
            if(Page.IsValid)
            { 
                List<GamePlatform> listPlatforms = new List<GamePlatform>();
                List<GameGenre> listGenres = new List<GameGenre>();

                Game game = new Game();
                game.GameGenres = null ;

                game.Title = TxtTitle.Text;
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    ListItem chk = CheckBoxList1.Items[i];
                    if (chk.Selected)
                    {
                        GameGenre gg = new GameGenre();
                        gg.Genre = chk.Text;
                        listGenres.Add(gg);
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
                                listPlatforms.Add(gp);
                            }
                        }
                    }
                }

                DataLayerAccess.AddGame(game, listGenres, listPlatforms);
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
            if(chkPlatform != null && chkPlatform.Checked)
            {
                string txtStockId = "TxtStock" + id;
                string txtPriceId = "TxtPrice" + id;

                TextBox txtStock = (TextBox)FindControlRecursive(Panel1, txtStockId);
                TextBox txtPrice = (TextBox)FindControlRecursive(Panel1, txtPriceId);

                return chkPlatform.Checked && !String.IsNullOrEmpty(txtBox.Text) ? true : false;
            } else
            {
                return true;
            }
        }

        protected bool ChekBoxChecked(object source)
        {
            CustomValidator validationControl = (CustomValidator)source;

            string txtBoxId = ((CustomValidator)source).ControlToValidate;
            TextBox txtBox = (TextBox)((CustomValidator)source).Parent.FindControl(txtBoxId);

            string id = (txtBox.ID).Substring(8);
            string chkPlatformId = "Chk" + id;

            CheckBox chkPlatform = (CheckBox)FindControlRecursive(Panel1, chkPlatformId);

            return chkPlatform != null && chkPlatform.Checked ? true : false;

        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            { 
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator6_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator7_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator8_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator9_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator10_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator11_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator12_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator13_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }

        protected void CustomValidator14_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ChekBoxChecked(source))
            {
                args.IsValid = MultipleFieldValidation(source);
            }
        }
    }
}