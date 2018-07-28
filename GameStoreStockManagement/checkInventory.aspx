<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkInventory.aspx.cs" Inherits="GameStoreStockManagement.checkInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <h1>Check Inventory</h1>
    <table class="table table-striped">
        <thead class="thead-dark">
            <tr>
                <th>Title</th>
                <th>Rating</th>
                <th>Year</th>
                <th>Platform</th>
                <th>Price</th>
                <th>Stock</th>
                <th>Genres</th>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody class="">
            <% for (int i = 0; i < listGames.Count; i++){ %>
            <% 
                string platform = "";
                double price;
                int inStock;
                string platforms = "";
                string prices = "";
                string stocks = "";

                for (int j = 0; j < listGames[i].GamePlatforms.Count; j++)
                {
                    platform = listGames[i].GamePlatforms[j].Platform;
                    price = listGames[i].GamePlatforms[j].Price;
                    inStock = listGames[i].GamePlatforms[j].InStock;

                    platforms += platform + "</br>";
                    prices += price + "</br>";
                    stocks += inStock + "</br>";
                }

                string genre = "";
                    string genres = "";

                    for (int j = 0; j < listGames[i].GameGenres.Count; j++)
                    {
                        genre = listGames[i].GameGenres[j].Genre;

                        genres += genre + "</br>";
                    }
            %> 
            <tr>
                <td><%= listGames[i].Title %></td>
                <td><%= listGames[i].Rating %></td>
                <td><%= listGames[i].ReleaseYear %></td>
                <td><%= platforms %></td>
                <td><%= prices %></td>
                <td><%= stocks %></td>
                <td><%= genres %></td>
            
                <td><a href="EditItem.aspx?id=<%= listGames[i].Id %>" >Edit</a> </td>
                <td><a href="DeleteItem.aspx?id=<%= listGames[i].Id %>">Delete</a></td>
            </tr>
            <% }; %>
        </tbody>
            
    </table>

 </asp:Content>
