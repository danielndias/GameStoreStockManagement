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

    <asp:Label ID="lblSearchGame" runat="server" Text="Search Game" Font-Bold="True" Font-Size="Large"></asp:Label>
    <hr />
    <table style="margin-bottom: 10px;">
        <tr>
            <td>
                <asp:Label ID="LblGameName" runat="server" Text="Game Name" class="col-md-2 col-form-label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtGameName" runat="server" class="form-control"></asp:TextBox>
            </td>
            <td>
                
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblPlatform" runat="server" Text="Platform" class="col-md-2 col-form-label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DdlPlatform" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name" class="form-control"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GameStoreDBConnectionString %>" SelectCommand="SELECT [Name] FROM [Platform]"></asp:SqlDataSource>
            </td>
            <td>
                
                &nbsp;</td>
            
        </tr>
        <tr>
            <td colspan="3"><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" class="btn btn-primary"/></td>
        </tr>
    </table>

    <asp:PlaceHolder ID="container" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="cartContainer" runat="server"></asp:PlaceHolder>


    <br />
    <asp:Button ID="BtnResetCart" runat="server" Text="Reset Cart" OnClick="BtnResetCart_Click" Visible="False" class="btn btn-primary"/>
    <asp:Button ID="BtnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" Visible="False" class="btn btn-primary"/>

    <br />
    <asp:Label ID="LblPurchaseResult" runat="server" Font-Bold="True" ForeColor="#003300"></asp:Label>

</asp:Content>
