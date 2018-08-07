<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceView.aspx.cs" Inherits="GameStoreStockManagement.InvoiceView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Invoice
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <h1>Invoice</h1>
    <asp:Label ID="lblSearchInvoice" runat="server" Font-Bold="True" Font-Size="Large" Text="Search Invoice"></asp:Label>
    <hr />
    <div class="form-group row">
        <asp:Label ID="lblInvoiceNumber" runat="server" Text="Invoice Number" class="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtSearchInvoice" runat="server" class="form-control"> </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearchInvoice" Display="Dynamic" ErrorMessage="Please provide an invoice number" ForeColor="Red" CssClass="validator"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtSearchInvoice" Display="Dynamic" ErrorMessage="Invalid Invoice Number" ForeColor="Red" Operator="DataTypeCheck" Type="Integer" CssClass="validator"></asp:CompareValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ErrorMessage="Invalid Invoice Number" ForeColor="Red" MaximumValue="9999999" MinimumValue="1" ControlToValidate="txtSearchInvoice" CssClass="validator"></asp:RangeValidator>
        </div>
    </div>
    <p>
        <asp:Button ID="btnSearchInvoice" runat="server" class="btn btn-primary" Text="Search" OnClick="btnSearchInvoice_Click" />
        <asp:Button ID="btnResetInvoice" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnResetInvoice_Click" />
    </p>
    <% if (searchInvoice != null && searchInvoice.Id != 0 && String.IsNullOrEmpty(searchInvoiceResult))
        { %>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Invoices" Font-Bold="True" Font-Size="Large"></asp:Label>
    <hr />
    <table class="table table-striped">
        <thead class="thead-dark">
            <tr>
                <th>Invoice #</th>
                <th>Date</th>
                <th>Games</th>
                <th>Quantity</th>
                <th>Total</th>
                <th>Subtotal</th>
                <th>Tax</th>
                <th>Invoice Total</th>
            </tr>
        </thead>
        <tbody>
            <% 
                string titles = "";
                string quantities = "";
                string subtotal = "";

                for (int j = 0; j < searchInvoice.InvoiceGames.Count; j++)
                {
                    titles += searchInvoice.InvoiceGames[j].Item.Game.Title + "</br>";
                }

                for (int j = 0; j < searchInvoice.InvoiceGames.Count; j++)
                {
                    quantities += searchInvoice.InvoiceGames[j].QuantitySold + "</br>";
                }

                for (int j = 0; j < searchInvoice.InvoiceGames.Count; j++)
                {
                    subtotal += (searchInvoice.InvoiceGames[j].Price * searchInvoice.InvoiceGames[j].QuantitySold).ToString("C")  + "</br>";
                }
            %> 
            <tr>
                <td><%= searchInvoice.Id%></td>
                <td><%= searchInvoice.InvoiceDate %></td>
                <td><%= titles %></td>
                <td><%= quantities %></td>
                <td><%= subtotal %></td>
                <td><%= searchInvoice.SubTotal.ToString("C") %></td>
                <td><%= searchInvoice.Tax.ToString("C") %></td>
                <td><%= searchInvoice.TotalAmount.ToString("C") %></td>
            </tr>
        </tbody>
            
    </table>
    <% } else if(searchInvoice == null && !String.IsNullOrEmpty(searchInvoiceResult)) { %>
        <asp:Label ID="LblResult2" runat="server" Text=""><%= searchInvoiceResult %></asp:Label>
    <%} else
        { %>
    <br />
    <asp:Label ID="lblInvoices" runat="server" Text="Invoices" Font-Bold="True" Font-Size="Large"></asp:Label>
    <hr />
    <table class="table table-striped">
        <thead class="thead-dark">
            <tr>
                <th>Invoice #</th>
                <th>Date</th>
                <th>Games</th>
                <th>Quantity</th>
                <th>Total</th>
                <th>Subtotal</th>
                <th>Tax</th>
                <th>Invoice Total</th>
            </tr>
        </thead>
        <tbody>
            <% for (int i = 0; i < listInvoices.Count; i++)
                { %>
            <% 
                string titles = "";
                string quantities = "";
                string subtotals = "";

                for (int j = 0; j < listInvoices[i].InvoiceGames.Count; j++)
                {
                    titles += listInvoices[i].InvoiceGames[j].Item.Game.Title + "</br>";
                }

                for (int j = 0; j < listInvoices[i].InvoiceGames.Count; j++)
                {
                    quantities += listInvoices[i].InvoiceGames[j].QuantitySold + "</br>";
                }

                for (int j = 0; j < listInvoices[i].InvoiceGames.Count; j++)
                {
                    subtotals += (listInvoices[i].InvoiceGames[j].Price * listInvoices[i].InvoiceGames[j].QuantitySold).ToString("C")  + "</br>";
                }
            %> 
            <tr>
                <td><%= listInvoices[i].Id%></td>
                <td><%= listInvoices[i].InvoiceDate %></td>
                <td><%= titles %></td>
                <td><%= quantities %></td>
                <td><%= subtotals %></td>
                <td><%= listInvoices[i].SubTotal.ToString("C") %></td>
                <td><%= listInvoices[i].Tax.ToString("C") %></td>
                <td><%= listInvoices[i].TotalAmount.ToString("C") %></td>
            </tr>
            <% }; %>
        </tbody>
            
    </table>
     <% };%>
</asp:Content>
