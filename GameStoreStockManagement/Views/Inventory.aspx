<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="GameStoreStockManagement.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inventory
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <h1>Check Inventory</h1>

    <asp:Label ID="LblSearch" runat="server" Text="Search Game" Font-Bold="True" Font-Size="Large"></asp:Label>
    <hr />
    <div class="form-group row">
        <asp:Label ID="LblTitle" runat="server" Text="Title" class="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-5">
            <asp:TextBox ID="TxtTitle" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="BtbSearch" runat="server" Text="Search" class="btn btn-primary" OnClick="BtbSearch_Click"/>
    <asp:Button ID="BtnReset" runat="server" Text="Reset" class="btn btn-primary" OnClick="BtnReset_Click" />
    <br />
    <br />
    <% if (searchGames.Count > 0 && String.IsNullOrEmpty(searchResult))
        { %>
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
            <tbody>
            <% for (int i = 0; i < searchGames.Count; i++)
                { %>
            <% 
                    string platforms = "";
                    string prices = "";
                    string stocks = "";

                    for (int j = 0; j < searchGames[i].GamePlatforms.Count; j++)
                    {
                        platforms += searchGames[i].GamePlatforms[j].Platform + "</br>";
                        prices += searchGames[i].GamePlatforms[j].Price + "</br>";
                        stocks += searchGames[i].GamePlatforms[j].InStock + "</br>";
                    }

                    string genres = "";

                    for (int j = 0; j < searchGames[i].GameGenres.Count; j++)
                    {
                        genres += searchGames[i].GameGenres[j].Genre + "</br>";
                    }
                %> 
                    <tr>
                        <td><%= searchGames[i].Title %></td>
                        <td><%= searchGames[i].Rating %></td>
                        <td><%= searchGames[i].ReleaseYear %></td>
                        <td><%= platforms %></td>
                        <td><%= prices %></td>
                        <td><%= stocks %></td>
                        <td><%= genres %></td>
            
                        <td><a href="EditGame.aspx?id=<%= listGames[i].Id %>" >Edit</a> </td>
                        <td><a href="DeleteGame.aspx?id=<%= listGames[i].Id %>">Delete</a></td>
                    </tr>
            <% }; %>
        </tbody>
        </table>
    <% } else if(searchGames.Count == 0 && !String.IsNullOrEmpty(searchResult)) { %>
        <asp:Label ID="LblResult" runat="server" Text=""><%= searchResult %></asp:Label>
    <%} else
        { %>
    <br />
    <asp:Label ID="LblInventory" runat="server" Text="Inventory" Font-Bold="True" Font-Size="Large"></asp:Label>
    <hr />
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
        <tbody>
            <% for (int i = 0; i < listGames.Count; i++)
                { %>
            <% 
                string platforms = "";
                string prices = "";
                string stocks = "";

                for (int j = 0; j < listGames[i].GamePlatforms.Count; j++)
                {
                    platforms += listGames[i].GamePlatforms[j].Platform + "</br>";
                    prices += listGames[i].GamePlatforms[j].Price + "</br>";
                    stocks += listGames[i].GamePlatforms[j].InStock + "</br>";
                }

                string genres = "";

                for (int j = 0; j < listGames[i].GameGenres.Count; j++)
                {
                    genres += listGames[i].GameGenres[j].Genre + "</br>";
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
            
                <td><a href="EditGame.aspx?id=<%= listGames[i].Id %>" >Edit</a> </td>
                <td><a href="DeleteGame.aspx?id=<%= listGames[i].Id %>">Delete</a></td>
            </tr>
            <% }; %>
        </tbody>
            
    </table>
    <% };%>
 </asp:Content>
