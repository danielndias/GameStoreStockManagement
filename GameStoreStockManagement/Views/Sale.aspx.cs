using GameStoreStockManagement.Models;
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
        public List<GamePlatform> searchInventory = null;
        public GamePlatform gp = new GamePlatform();

        public List<CartItem> cart = null;

        private double subTotal = 0;
        private double tax = 0;
        private double total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LblPurchaseResult.Text = "";
            cart = (List<CartItem>)HttpContext.Current.Session["Cart"];
            searchInventory = (List<GamePlatform>)Session["searchList"];

            // checks if there is already a cart in this user's session
            if (cart == null)
            {
                cart = new List<CartItem>();
                BtnCheckout.Visible = false;
                BtnResetCart.Visible = false;
            }

            // if there are items in the cart
            else
            {
                CreateCartTable();
                BtnCheckout.Visible = true;
                BtnResetCart.Visible = true;
            }

            if (searchInventory == null)
            {
                searchInventory = new List<GamePlatform>();
            }

            else
            {
                CreateSearchTable();
            }
            
            ClientScript.GetPostBackEventReference(this, string.Empty);

            string targetCtrl = Page.Request.Params.Get("__EVENTTARGET");

            // if an "add" button was clicked
            if(targetCtrl != null && targetCtrl != string.Empty)
            {
                int indexAdd = targetCtrl.IndexOf("Add");

                string gamePlatId = targetCtrl.Substring(indexAdd + 3, targetCtrl.Length - indexAdd - 3);

                GamePlatform gp = DataLayerAccess.GetGamePlatform(Convert.ToInt32(gamePlatId));

                bool isItemInCart = false;

                // see if cart already contains item
                for (int j = 0; j < cart.Count; j++)
                {
                    // if item was found, simply add 1 to the quantity of that item
                    if (cart[j].Item.Id.ToString() == gamePlatId)
                    {
                        if(gp.InStock > cart[j].Quantity)
                        {
                            cart[j].Quantity++;
                        }
                        
                        isItemInCart = true;
                    }
                }

                if (!isItemInCart)
                {
                    cart.Add(new CartItem
                    {
                        Item = gp,
                        Quantity = 1
                    });
                }

                HttpContext.Current.Session["Cart"] = cart;

                CreateCartTable();
                BtnCheckout.Visible = true;
                BtnResetCart.Visible = true;
            }
        }

        protected void CreateCartTable()
        {
            // erase any previous displayed cart
            cartContainer.Controls.Clear();

            var table = new Table
            {
                CssClass = "table table-stripped resultsTable"
            };

            // add header for this table
            var headerRow = new TableHeaderRow
            {
                CssClass = "thread-dark saleCartHeader"
            };

            var nameHeaderCell = new TableCell
            {
                Text = "Name",
                Width = new Unit(180)
            };

            var platHeaderCell = new TableCell
            {
                Text = "Platform",
                Width = new Unit(180)
            };

            var qtyHeaderCell = new TableCell
            {
                Text = "Quantity",
                Width = new Unit(180)
            };

            var unitPriceHeaderCell = new TableCell
            {
                Text = "Unit Price",
                Width = new Unit(180)
            };

            var totalHeaderCell = new TableCell
            {
                Text = "Total",
                Width = new Unit(180)
            };

            headerRow.Cells.Add(nameHeaderCell);
            headerRow.Cells.Add(platHeaderCell);
            headerRow.Cells.Add(qtyHeaderCell);
            headerRow.Cells.Add(unitPriceHeaderCell);
            headerRow.Cells.Add(totalHeaderCell);

            table.Rows.Add(headerRow);

            // get each cart item and create table for cart
            for (int i = 0; i < cart.Count; i++)
            {
                // create table elems
                var row = new TableRow();
                var nameCell = new TableCell();
                var platCell = new TableCell();
                var qtyCell = new TableCell();
                var unitPriceCell = new TableCell();
                var totalCell = new TableCell();

                // create controls to go into the cells
                // used it to make it unique across all searched results
                string idForControls = cart[i].Item.Id.ToString();

                Label lblName = new Label
                {
                    ID = "lblTitleCart" + idForControls,
                    Text = cart[i].Item.Game.Title
                };

                Label lblPlat = new Label
                {
                    ID = "lblPlatCart" + idForControls,
                    Text = cart[i].Item.Platform
                };

                Label lblQty = new Label
                {
                    ID = "lblQtyCart" + idForControls,
                    Text = cart[i].Quantity.ToString()
                };

                Label lblUnitPrice = new Label
                {
                    ID = "lblUnitPriceCart" + idForControls,
                    Text = cart[i].Item.Price.ToString("C")
                };

                Label lblTotal = new Label
                {
                    ID = "lblTotalCart" + idForControls,
                    Text = (cart[i].Quantity * cart[i].Item.Price).ToString("C")
                };

                // add Controls into cells
                nameCell.Controls.Add(lblName);
                platCell.Controls.Add(lblPlat);
                qtyCell.Controls.Add(lblQty);
                unitPriceCell.Controls.Add(lblUnitPrice);
                totalCell.Controls.Add(lblTotal);

                // add cells into row
                row.Cells.Add(nameCell);
                row.Cells.Add(platCell);
                row.Cells.Add(qtyCell);
                row.Cells.Add(unitPriceCell);
                row.Cells.Add(totalCell);

                // add row into table
                table.Rows.Add(row);
            }

            cartContainer.Controls.AddAt(0, new Label
            {
                Text = "Items in Cart",
                CssClass = "subtitle"
            });

            cartContainer.Controls.AddAt(1, table);

            subTotal = 0;

            // create subtotal, tax and total fields
            for(int i = 0; i < cart.Count; i++)
            {
                subTotal += (cart[i].Item.Price * cart[i].Quantity);
            }

            tax = subTotal * 0.13;
            total = subTotal + tax;

            var summaryTable = new Table
            {
                CssClass = "summaryTable"
            };

            var rowSubtotal = new TableRow();
            var rowTax = new TableRow();
            var rowTotal = new TableRow();
            var lblSubtotalCell = new TableCell();
            var lblTaxCell = new TableCell();
            var lblTotalCell = new TableCell();
            var valSubtotalCell = new TableCell();
            var valTaxCell = new TableCell();
            var valTotalCell = new TableCell();

            Label lblSubtotal = new Label
            {
                ID = "lblSubtotal",
                Text = "Subtotal: ",
                Width = new Unit(180)
            };

            Label lblTax = new Label
            {
                ID = "lblTax",
                Text = "Tax: ",
                Width = new Unit(180)
            };

            Label lblTotalSum = new Label
            {
                ID = "lblTotal",
                Text = "Total: ",
                Width = new Unit(180)
            };

            Label lblSubtotalVal = new Label
            {
                ID = "lblSubtotalVal",
                Text = subTotal.ToString("C"),
                Width = new Unit(180)
            };

            Label lblTaxVal = new Label
            {
                ID = "lblTaxVal",
                Text = tax.ToString("C"),
                Width = new Unit(180)
            };

            Label lblTotalSumVal = new Label
            {
                ID = "lblTotalVal",
                Text = total.ToString("C"),
                Width = new Unit(180)
            };

            // add Controls into cells
            lblSubtotalCell.Controls.Add(lblSubtotal);
            lblTaxCell.Controls.Add(lblTax);
            lblTotalCell.Controls.Add(lblTotalSum);
            valSubtotalCell.Controls.Add(lblSubtotalVal);
            valTaxCell.Controls.Add(lblTaxVal);
            valTotalCell.Controls.Add(lblTotalSumVal);

            // add cells into row
            rowSubtotal.Cells.Add(lblSubtotalCell);
            rowSubtotal.Cells.Add(valSubtotalCell);
            rowTax.Cells.Add(lblTaxCell);
            rowTax.Cells.Add(valTaxCell);
            rowTotal.Cells.Add(lblTotalCell);
            rowTotal.Cells.Add(valTotalCell);

            // add row into table
            summaryTable.Rows.Add(rowSubtotal);
            summaryTable.Rows.Add(rowTax);
            summaryTable.Rows.Add(rowTotal);

            cartContainer.Controls.AddAt(2, summaryTable);

            cartContainer.Visible = true;
        }

        protected void CreateSearchTable()
        {
            // erase any previous displayed search
            container.Controls.Clear();

            var table = new Table
            {
                CssClass = "table table-stripped resultsTable"
            };

            // add header for this table
            var headerRow = new TableHeaderRow
            {
                CssClass = "thread-dark saleSearchHeader"
            };

            var nameHeaderCell = new TableCell
            {
                Text = "Name",
                Width = new Unit(180)
            };

            var platHeaderCell = new TableCell
            {
                Text = "Platform",
                Width = new Unit(180)
            };

            var priceHeaderCell = new TableCell
            {
                Text = "Price",
                Width = new Unit(180)
            };

            var stockHeaderCell = new TableCell
            {
                Text = "Stock",
                Width = new Unit(180)
            };

            var addHeaderCell = new TableCell
            {
                Text = "",
                Width = new Unit(180)
            };

            headerRow.Cells.Add(nameHeaderCell);
            headerRow.Cells.Add(platHeaderCell);
            headerRow.Cells.Add(priceHeaderCell);
            headerRow.Cells.Add(stockHeaderCell);
            headerRow.Cells.Add(addHeaderCell);

            table.Rows.Add(headerRow);

            // for each item found, will create a row in the table
            for (int i = 0; i < searchInventory.Count; i++)
            {
                // create table elems
                var row = new TableRow();
                var nameCell = new TableCell();
                var platCell = new TableCell();
                var priceCell = new TableCell();
                var stockCell = new TableCell();
                var addCell = new TableCell();

                // create controls to go into the cells (gameId|paltformID)
                // used it to make it unique across all searched results
                //string idForControls = searchInventory[i].GameId + "|" + searchInventory[i].Platform.Replace(" ", ""); // remove spaces for id
                string idForControls = searchInventory[i].Id.ToString();

                Label lblName = new Label
                {
                    ID = "lblTitle" + idForControls,
                    Text = searchInventory[i].Game.Title
                };

                Label lblPlat = new Label
                {
                    ID = "lblPlat" + idForControls,
                    Text = searchInventory[i].Platform
                };

                Label lblPrice = new Label
                {
                    ID = "lblPrice" + idForControls,
                    Text = searchInventory[i].Price.ToString("C")
                };

                Label lblStock = new Label
                {
                    ID = "lblStock" + idForControls,
                    Text = searchInventory[i].InStock.ToString()
                };

                LinkButton btnAdd = new LinkButton
                {
                    ID = "btnAdd" + idForControls,
                    Text = "Add"
                };

                btnAdd.Attributes.Add("OnClientClick", "DoPostBack()");
                //btnAdd.Click += new EventHandler(AddToCart);


                // add Controls into cells
                nameCell.Controls.Add(lblName);
                platCell.Controls.Add(lblPlat);
                priceCell.Controls.Add(lblPrice);
                stockCell.Controls.Add(lblStock);
                addCell.Controls.Add(btnAdd);

                // add cells into row
                row.Cells.Add(nameCell);
                row.Cells.Add(platCell);
                row.Cells.Add(priceCell);
                row.Cells.Add(stockCell);
                row.Cells.Add(addCell);

                // add row into table
                table.Rows.Add(row);

                // if stock is equal to the amount in cart, hide add button
                ValidateAddToCart(searchInventory[i].InStock, Convert.ToInt32(idForControls), btnAdd);
            }

            container.Controls.AddAt(0, new Label
            {
                Text = "Search Results",
                CssClass = "subtitle"
            });

            container.Controls.AddAt(1, table);
            container.Visible = true;
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if(TxtGameName.Text.Trim() != "")
            {
                searchInventory = DataLayerAccess.GetGamesPlatform(TxtGameName.Text.Trim(), DdlPlatform.SelectedValue);
            }

            else
            {
                searchInventory = DataLayerAccess.GetGamesByPlatform(DdlPlatform.SelectedValue);
            }

            Session["searchList"] = (searchInventory.Count > 0) ? searchInventory : null;

            if(Session["searchList"] != null)
            {
                CreateSearchTable();
            }
            // if no results found
            else
            {
                container.Controls.Clear();
                container.Controls.AddAt(0, new Literal
                {
                    Text = "No games found. <br /><br />"
                });
            }
        }

        protected void ValidateAddToCart(int stock, int id, LinkButton btnAdd)
        {
            CartItem ci = null;

            // find if item already in cart
            for (int i = 0; i < cart.Count; i++)
            {
                // item found
                if(cart[i].Item.Id == id)
                {
                    ci = cart[i];
                    break;
                }
            } 

            // if item in cart has same quantity as the amount in stock, hides button for adding more
            if (ci != null && stock == ci.Quantity)
            {
                btnAdd.Enabled = false;
                btnAdd.Text = "Cannot add more";
                btnAdd.ForeColor = System.Drawing.Color.Black;
            }
        }

        protected void BtnResetCart_Click(object sender, EventArgs e)
        {
            cart = null;
            HttpContext.Current.Session["Cart"] = null;
            Response.Redirect("Sale.aspx");
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            

            // when checkout is clicked, each item contained in the cart is saved into Invoice and InvoiceGame
            Invoice invoice = new Invoice
            {
                InvoiceDate = DateTime.Now,
                SubTotal = subTotal,
                Tax = tax,
                TotalAmount = total
            };

            // add invoice to db
            DataLayerAccess.AddInvoice(invoice);

            // get id of invoice just added
            Invoice inv = DataLayerAccess.GetLastInvoice();

            foreach (var item in cart)
            {
                InvoiceGame ig = new InvoiceGame
                {
                    InvoiceId = inv.Id,
                    Price = item.Item.Price,
                    QuantitySold = item.Quantity,
                    Item = item.Item,
                    Invoice = inv
                };

                DataLayerAccess.AddInvoiceGame(ig);

                // update stock
                int newStock = item.Item.InStock - item.Quantity;
                DataLayerAccess.UpdateStock(item.Item.Id, newStock);
            }

            // reset chart, hide buttons, erase cart display and show message
            cart = null;
            HttpContext.Current.Session["Cart"] = null;
            BtnCheckout.Visible = false;
            BtnResetCart.Visible = false;
            cartContainer.Controls.Clear();
            LblPurchaseResult.Text = "Purchase Successful!";
        }
    }
}