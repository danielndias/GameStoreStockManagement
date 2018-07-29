<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="EditGame.aspx.cs" Inherits="GameStoreStockManagement.EditGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Edit Game
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 128px;
        }
        .auto-style4 {
            height: 29px;
            width: 128px;
        }
        .auto-style5 {
            height: 26px;
            width: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <h1>Add Game</h1>
    <div class="form-group row">
        <asp:Label ID="LblTitle" runat="server" Text="Title" class="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-5">
            <asp:TextBox ID="TxtTitle" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtTitle" Display="Dynamic" ErrorMessage="Title cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group row">
        <asp:Label ID="LblRating" runat="server" Text="Rating" class="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-2">
            <asp:DropDownList ID="DdlRating" runat="server" class="form-control">
                <asp:ListItem>E</asp:ListItem>
                <asp:ListItem>E10</asp:ListItem>
                <asp:ListItem>T</asp:ListItem>
                <asp:ListItem>M</asp:ListItem>
                <asp:ListItem>A</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group row">
        <asp:Label ID="LblYear" runat="server" Text="Year" class="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-2">
            <asp:TextBox ID="TxtYear" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Year cannot be empty." Display="Dynamic" Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtYear" ></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Year must be between 1980 and 2050." MaximumValue="2050" MinimumValue="1980" Type="Integer" Font-Italic="True" Font-Size="Small" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtYear"></asp:RangeValidator>
        </div>
    </div>
    <br />
        <asp:Label ID="LblGenre" runat="server" Text="Select a Genre" Font-Bold="True" Font-Size="Large"></asp:Label>
        <asp:Panel ID="Panel2" runat="server">
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataTextField="Name" DataValueField="Name" RepeatDirection="Horizontal" RepeatColumns="7" Height="29px" Width="892px"></asp:CheckBoxList>
        <asp:CustomValidator ID="CustomValidator15" runat="server" Display="Dynamic" ErrorMessage="You must select at least one genre." Font-Italic="True" Font-Size="Small" ForeColor="Red" OnServerValidate="CustomValidator15_ServerValidate" ValidationGroup="ValPlatform"></asp:CustomValidator>
    <br />
    </asp:Panel>
    <br />
    <asp:Label ID="LblPlatform" runat="server" Text="Select a Platform" Font-Bold="True" Font-Size="Large"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <th class="auto-style3">Platform</th>
                <th>Price</th>
                <th>Stock</th>
                <th class="auto-style6"></th>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:CheckBox ID="ChkXBoxOne" runat="server" Text="XBox One" />
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtPriceXBoxOne" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtStockXBoxOne" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TxtPriceXBoxOne" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" ValidationGroup="ValPlatform"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TxtStockXBoxOne" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TxtPriceXBoxOne" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TxtStockXBoxOne" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:CheckBox ID="ChkXBox360" runat="server" Text="XBox 360"/>
                </td>
                <td>
                    <asp:TextBox ID="TxtPriceXBox360" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TxtStockXBox360" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="CustomValidator3" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPriceXBox360" OnServerValidate="CustomValidator3_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockXBox360" OnServerValidate="CustomValidator4_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TxtPriceXBox360" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="TxtStockXBox360" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:CheckBox ID="ChkPlaystation3" runat="server" Text="Playstation 3"/>
                </td>
                <td>
                    <asp:TextBox ID="TxtPricePlaystation3" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TxtStockPlaystation3" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="CustomValidator5" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPricePlaystation3" OnServerValidate="CustomValidator5_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator6" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockPlaystation3" OnServerValidate="CustomValidator6_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="TxtPricePlaystation3" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="TxtStockPlaystation3" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>    
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:CheckBox ID="ChkPlaystation4" runat="server" Text="Playstation 4"/>
                 </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtPricePlaystation4" runat="server" class="form-control"></asp:TextBox>
                    </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtStockPlaystation4" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:CustomValidator ID="CustomValidator7" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPricePlaystation4" OnServerValidate="CustomValidator7_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator8" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockPlaystation4" OnServerValidate="CustomValidator8_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="TxtPricePlaystation4" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="TxtStockPlaystation4" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:CheckBox ID="ChkWii" runat="server" Text="Wii"/>
                 </td>
                <td>
                    <asp:TextBox ID="TxtPriceWii" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TxtStockWii" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="CustomValidator9" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPriceWii" OnServerValidate="CustomValidator9_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator10" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockWii" OnServerValidate="CustomValidator10_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="TxtPriceWii" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="TxtStockWii" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:CheckBox ID="ChkWiiU" runat="server" Text="Wii U"/>
                </td>
                <td>
                    <asp:TextBox ID="TxtPriceWiiU" runat="server" class="form-control"></asp:TextBox>
                    </td>
                <td>
                    <asp:TextBox ID="TxtStockWiiU" runat="server" class="form-control"></asp:TextBox>
                    </td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="CustomValidator11" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPriceWiiU" OnServerValidate="CustomValidator11_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator12" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockWiiU" OnServerValidate="CustomValidator12_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="TxtPriceWiiU" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="TxtStockWiiU" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:CheckBox ID="ChkPC" runat="server" Text="PC"/>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtPricePC" runat="server" class="form-control"></asp:TextBox>
                    </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtStockPC" runat="server" class="form-control"></asp:TextBox>
                    </td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="CustomValidator13" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtPricePC" OnServerValidate="CustomValidator13_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator14" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." Font-Italic="True" Font-Size="Small" ForeColor="Red" ControlToValidate="TxtStockPC" OnServerValidate="CustomValidator14_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="TxtPricePC" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="TxtStockPC" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" Font-Italic="True" Font-Size="Small" ForeColor="Red" ></asp:CompareValidator>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="BtnSubmit" runat="server" Text="Update Game" class="btn btn-primary" OnClick="BtnSubmit_Click" />
</asp:Content>