using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStoreStockManagement
{
    public partial class InvoiceView : System.Web.UI.Page
    {
        public List<Invoice> listInvoices = DataLayerAccess.GetAllInvoices();
        public Invoice searchInvoice = new Invoice();
        public string searchInvoiceResult = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtSearchInvoice_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearchInvoice_Click(object sender, EventArgs e)
        {
            searchInvoice = DataLayerAccess.GetInvoice(Convert.ToInt32(txtSearchInvoice.Text));
            searchInvoiceResult = searchInvoice == null ? "No invoices found." : "";
        }

        protected void btnResetInvoice_Click(object sender, EventArgs e)
        {
            {
                searchInvoice = null;
                searchInvoiceResult = "";
                Response.Redirect("InvoiceView.aspx");
            }
        }
    }
}