<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteItem.aspx.cs" Inherits="GameStoreStockManagement.DeleteItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <h1>Delete Game</h1>
    <asp:Label ID="LblMessage" runat="server" Text="Are you sure to delete this game?"></asp:Label>
    <br />
    <asp:Label ID="LblTitle" runat="server" Text=""><%= "Title: " + game.Title %></asp:Label>
    <br />
    <asp:Label ID="LblYear" runat="server" Text=""><%= "Year: " + game.ReleaseYear %></asp:Label>
    <br />
    <br />
    <asp:Button ID="BtnSubmit" runat="server" Text="Delete Game" OnClick="BtnSubmit_Click" />
</asp:Content>