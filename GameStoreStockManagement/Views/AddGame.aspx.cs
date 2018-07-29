﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStoreStockManagement
{
    public partial class AddGame : System.Web.UI.Page
    {
        public List<string> platformNames = DataLayerAccess.GetPlatforms();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            // validate the platform controls first
            Page.Validate("ValPlatform");

            if(Page.IsValid)
            { 
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

                // loop through the Panel1 control to find all platform related checkboxes
                for (int i = 0; i < Panel1.Controls.Count; i++)
                {
                    if (Panel1.Controls[i] is CheckBox)
                    {
                        // loop through platform names to compare input field id's.
                        for (int j = 0; j < platformNames.Count; j++)
                        {
                            // generate the platform based id for comparing with checkbox id
                            string chkId = "Chk" + platformNames[j];
                            
                            // get the proper controls from the html
                            CheckBox chk = (CheckBox)Panel1.Controls[i];
                            
                            // if checkbox is not null AND checkbox belongs to that specific platform AND checkbox is checked
                            // then set the values of game object.
                            if (chk != null && chk.ID.Equals(chkId) && chk.Checked)
                            {
                                string txtPriceId = "TxtPrice" + platformNames[j];
                                string txtStockId = "TxtStock" + platformNames[j];
                                TextBox txtPrice = (TextBox)FindControlRecursive(Panel1, txtPriceId);
                                TextBox txtStock = (TextBox)FindControlRecursive(Panel1, txtStockId);

                                GamePlatform gp = new GamePlatform();
                                gp.Platform = chk.Text;
                                gp.Price = Convert.ToInt32(txtPrice.Text);
                                gp.InStock = Convert.ToInt32(txtStock.Text);
                                game.GamePlatforms.Add(gp);
                            }
                        }
                    }
                }

                DataLayerAccess.AddGame(game);
                Response.Redirect("AddGame.aspx");
            }
        }

        /// <summary>
        /// Find the any control by it's id in a Panel(rootControl).
        /// </summary>
        /// <param name="rootControl"></param>
        /// <param name="controlID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validate if the related checkbox of the textbox that fires the serverValidation are not empty.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected bool MultipleFieldValidation(object source)
        {
            // get the proper TextBox
            CustomValidator validationControl = (CustomValidator)source;
            string txtBoxId = ((CustomValidator)source).ControlToValidate;
            TextBox txtBox = (TextBox)((CustomValidator)source).Parent.FindControl(txtBoxId);

            // substring the id for getting platform name
            string id = (txtBox.ID).Substring(8);

            // get the related checkbox
            string chkPlatformId = "Chk" + id;
            CheckBox chkPlatform = (CheckBox)FindControlRecursive(Panel1, chkPlatformId);

            // if checkbox is NOT checked   AND textBox is NOT empty    then return false
            // if checkbox is checked       AND textbox is empty        then return false
            // else return true
            if (chkPlatform == null || (chkPlatform.Checked && String.IsNullOrEmpty(txtBox.Text)))
            {
                validationControl.Text = txtBox.ID.Substring(3, 5) + " cannot be empty.";
                return false;
            }
            else if(chkPlatform == null || (!chkPlatform.Checked && !String.IsNullOrEmpty(txtBox.Text)))
            {
                validationControl.Text = "Platform must be selected.";
                return false;
            }
            else
            {
                validationControl.Text = "";
                return true;
            }
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
    }
}