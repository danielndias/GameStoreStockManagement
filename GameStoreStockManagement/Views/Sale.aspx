<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="GameStoreStockManagement.Sale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Sale
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <h1>Sale Page</h1>

    <table>
        <tr>
            <td>
                <asp:Label ID="LblGameName" runat="server" Text="Game Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtGameName" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblPlatform" runat="server" Text="Platform"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DdlPlatform" runat="server"></asp:DropDownList>
            </td>
            <td>
                
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblQuantity" runat="server" Text="Quantity"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtQuantity" runat="server"></asp:TextBox>
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td colspan="3"><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" /></td>
        </tr>
    </table>

    <% if (searchInventory.Count > 0 && String.IsNullOrEmpty(searchResult))
        { %>
            <table>
                <thead class="table table-striped">
                    <tr>
                        <th>Title</th>
                        <th>Platform</th>
                        <th>Unit Price</th>
                        <th>Stock</th>
                        <th>Quantity</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < searchInventory.Count; i++)
                       {
                            gp = searchInventory[i];%>
                            <tr>
                                <td><%= gp.Game.Title %></td>
                                <td><%= gp.Platform %></td>
                                <td><%= gp.Price %></td>
                                <td><%= gp.InStock %></td>
                                <td><asp:TextBox ID="<%= "Txt" + (gp.Game.Title + "&"  + gp.Platform) + "qty"  %>" runat="server"></asp:TextBox></td>
                                <td><asp:Button ID="<%= "Btn" + (gp.Game.Title + "&"  + gp.Platform) %>" OnClick="AddToCart" CommandArgument="<%= (gp.Game.Title + "&"  + gp.Platform) %>" runat="server" Text="Button" /></td>
                            </tr>       
                       <%}%>



                            
                </tbody>
            </table>
      <%} %>
   

</asp:Content>
