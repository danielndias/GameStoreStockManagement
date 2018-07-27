<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addToInventory.aspx.cs" Inherits="GameStoreStockManagement.addToInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 29px;
    }
        .auto-style2 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <h1>Add to Inventory Page</h1>
    <asp:Label ID="LblTitle" runat="server" Text="Title"></asp:Label>
    <asp:TextBox ID="TxtTitle" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtTitle" Display="Dynamic" ErrorMessage="Title cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server">
        <asp:Label ID="LblGenre" runat="server" Text="Select a Genre"></asp:Label>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name" RepeatColumns="5"></asp:CheckBoxList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GameStoreDBConnectionString %>" SelectCommand="SELECT [Name] FROM [Genre]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GameStoreDBConnectionString %>" SelectCommand="SELECT [Name] FROM [Platform]"></asp:SqlDataSource>
    <br />
    <asp:Label ID="LblPlatform" runat="server" Text="Select a Platform"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <table>
        <tr>
            <th>Platform</th>
            <th>Price</th>
            <th>Stock</th>
            <th></th>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:CheckBox ID="ChkXBoxOne" runat="server" Text="XBox One"/>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtPriceXBoxOne" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtStockXBoxOne" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TxtPriceXBoxOne" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" ValidationGroup="ValPlatform"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TxtStockXBoxOne" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator15" runat="server" ErrorMessage="CustomValidator" OnServerValidate="CustomValidator15_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="ChkXBox360" runat="server" Text="XBox 360"/>
            </td>
            <td>
                <asp:TextBox ID="TxtPriceXBox360" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtStockXBox360" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CustomValidator ID="CustomValidator3" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPriceXBox360" OnServerValidate="CustomValidator3_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator4" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockXBox360" OnServerValidate="CustomValidator4_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="ChkPs3" runat="server" Text="Playstation 3"/>
            </td>
            <td>
                <asp:TextBox ID="TxtPricePs3" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtStockPs3" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CustomValidator ID="CustomValidator5" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPricePs3" OnServerValidate="CustomValidator5_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator6" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockPs3" OnServerValidate="CustomValidator6_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:CheckBox ID="ChkPs4" runat="server" Text="Playstation 4"/>
             </td>
            <td class="auto-style2">
                <asp:TextBox ID="TxtPricePs4" runat="server"></asp:TextBox>
                </td>
            <td class="auto-style2">
                <asp:TextBox ID="TxtStockPs4" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">
                <asp:CustomValidator ID="CustomValidator7" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPricePs4" OnServerValidate="CustomValidator7_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator8" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockPs4" OnServerValidate="CustomValidator8_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="ChkWii" runat="server" Text="Wii"/>
             </td>
            <td>
                <asp:TextBox ID="TxtPriceWii" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtStockWii" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CustomValidator ID="CustomValidator9" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPriceWii" OnServerValidate="CustomValidator9_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator10" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockWii" OnServerValidate="CustomValidator10_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="ChkWiiU" runat="server" Text="Wii U"/>
            </td>
            <td>
                <asp:TextBox ID="TxtPriceWiiU" runat="server"></asp:TextBox>
                </td>
            <td>
                <asp:TextBox ID="TxtStockWiiU" runat="server"></asp:TextBox>
                </td>
            <td>
                <asp:CustomValidator ID="CustomValidator11" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPriceWiiU" OnServerValidate="CustomValidator11_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator12" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockWiiU" OnServerValidate="CustomValidator12_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:CheckBox ID="ChkPc" runat="server" Text="PC"/>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtPricePc" runat="server"></asp:TextBox>
                </td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtStockPc" runat="server"></asp:TextBox>
                </td>
            <td>
                <asp:CustomValidator ID="CustomValidator13" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPricePc" OnServerValidate="CustomValidator13_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator14" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockPc" OnServerValidate="CustomValidator14_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
            </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Button ID="BtnSubmit" runat="server" Text="Add Game" OnClick="BtnSubmit_Click" />
</asp:Content>

