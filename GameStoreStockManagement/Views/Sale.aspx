<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="GameStoreStockManagement.Sale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Sale
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

    <style>

        .resultsTable {
            margin-top: 20px;
        }

        .summaryTable {
            margin-top: 10px;
            float: right;
        }

        .summaryTable tr :nth-child(1) {
            font-weight: bold;
        }
    </style>
    
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
                <asp:DropDownList ID="DdlPlatform" runat="server" DataSourceID="SqlDataSource1" DataTextField="Platform" DataValueField="Platform"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GameStoreDBConnectionString %>" SelectCommand="SELECT [Platform] FROM [GamePlatform]"></asp:SqlDataSource>
            </td>
            <td>
                
                &nbsp;</td>
            
        </tr>
        <tr>
            <td colspan="3"><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" /></td>
        </tr>
    </table>

    <asp:PlaceHolder ID="container" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="cartContainer" runat="server"></asp:PlaceHolder>


    <br />
    <asp:Button ID="BtnResetCart" runat="server" Text="Reset Cart" OnClick="BtnResetCart_Click" Visible="False" />
    <asp:Button ID="BtnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" Visible="False" />

    <br />
    <asp:Label ID="LblPurchaseResult" runat="server" Font-Bold="True" ForeColor="#003300"></asp:Label>

</asp:Content>
