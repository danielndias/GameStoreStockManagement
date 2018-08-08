<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGame.aspx.cs" Inherits="GameStoreStockManagement.AddGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Game
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
        .auto-style6 {
            width: 504px;
        }
        .auto-style7 {
            height: 26px;
            width: 504px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <h1>Add Game</h1>
    <br />
    <asp:Label ID="LblGame" runat="server" Text="Game Details" Font-Bold="True" Font-Size="Large"></asp:Label>
    <hr />
    <div class="form-group row">
        <asp:Label ID="LblTitle" runat="server" Text="Title" class="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-5">
            <asp:TextBox ID="TxtTitle" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="validator" runat="server" ControlToValidate="TxtTitle" Display="Dynamic" ErrorMessage="Title cannot be empty." ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" class="validator" runat="server" ControlToValidate="TxtTitle" ErrorMessage="Title can be 50 chars long, and cannot contain special characters.)" ValidationExpression="^[ A-Za-z0-9]{1,50}$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="form-group row">
        <asp:Label ID="LblRating" runat="server" Text="Rating" class="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-5">
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
        <div class="col-sm-5">
            <asp:TextBox ID="TxtYear" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" class="validator" runat="server" ErrorMessage="Year cannot be empty." Display="Dynamic" ControlToValidate="TxtYear" ></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" class="validator" runat="server" ErrorMessage="Year must be between 1980 and 2050." MaximumValue="2050" MinimumValue="1980" Type="Integer" Display="Dynamic" ControlToValidate="TxtYear"></asp:RangeValidator>
        </div>
    </div>
    <br />
    <asp:Label ID="LblGenre" runat="server" Text="Select a Genre" Font-Bold="True" Font-Size="Large"></asp:Label>
    &nbsp;
    <asp:CustomValidator ID="CustomValidator15" class="validator" runat="server" Display="Dynamic" ErrorMessage="Select at least one genre." OnServerValidate="CustomValidator15_ServerValidate" ValidationGroup="ValPlatform"></asp:CustomValidator>
    <hr />
    <asp:Panel ID="Panel2" runat="server">
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name" RepeatDirection="Horizontal" RepeatColumns="7" Height="29px" Width="892px"></asp:CheckBoxList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GameStoreDBConnectionString %>" SelectCommand="SELECT [Name] FROM [Genre]"></asp:SqlDataSource>
    <br />
    </asp:Panel>
    <br />
    <asp:Label ID="LblPlatform" runat="server" Text="Select a Platform" Font-Bold="True" Font-Size="Large"></asp:Label>
    &nbsp;
    <asp:CustomValidator ID="CustomValidator16" class="validator" runat="server" ErrorMessage="Select at least one platform." OnServerValidate="CustomValidator16_ServerValidate" Display="Dynamic"></asp:CustomValidator>
    <hr />
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
                    <asp:CustomValidator ID="CustomValidator1" class="validator" runat="server" ControlToValidate="TxtPriceXBoxOne" Display="Dynamic" ErrorMessage="Price cannot be empty." OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" ValidationGroup="ValPlatform"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator2" class="validator" runat="server" ControlToValidate="TxtStockXBoxOne" Display="Dynamic" ErrorMessage="Stock cannot be empty." OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator1" class="validator" runat="server" ControlToValidate="TxtPriceXBoxOne" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Currency" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator2" class="validator" runat="server" ControlToValidate="TxtStockXBoxOne" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                    <asp:RangeValidator ID="RangeValidator2" class="validator" runat="server" ControlToValidate="TxtPriceXBoxOne" ErrorMessage="Price must be between 1.0 and 999.99" MaximumValue="999.99" MinimumValue="1" Type="Currency" Display="Dynamic"></asp:RangeValidator>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" class="validator" ControlToValidate="TxtStockXBoxOne" Display="Dynamic" ErrorMessage="Stock must be between 1 and 999." MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
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
                    <asp:CustomValidator ID="CustomValidator3" class="validator" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." ControlToValidate="TxtPriceXBox360" OnServerValidate="CustomValidator3_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator4" class="validator" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." ControlToValidate="TxtStockXBox360" OnServerValidate="CustomValidator4_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator3" class="validator" runat="server" ControlToValidate="TxtPriceXBox360" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator4" class="validator" runat="server" ControlToValidate="TxtStockXBox360" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                    <asp:RangeValidator ID="RangeValidator4" runat="server" class="validator" ControlToValidate="TxtPriceXBox360" Display="Dynamic" ErrorMessage="Price must be between 1.0 and 999.99" MaximumValue="999.99" MinimumValue="1" Type="Currency"></asp:RangeValidator>
                    <asp:RangeValidator ID="RangeValidator10" runat="server" class="validator" ControlToValidate="TxtStockXBox360" Display="Dynamic" ErrorMessage="Stock must be between 1 and 999." MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
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
                    <asp:CustomValidator ID="CustomValidator5" class="validator" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." ControlToValidate="TxtPricePlaystation3" OnServerValidate="CustomValidator5_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator6" class="validator" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." ControlToValidate="TxtStockPlaystation3" OnServerValidate="CustomValidator6_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator5" class="validator" runat="server" ControlToValidate="TxtPricePlaystation3" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator6" class="validator" runat="server" ControlToValidate="TxtStockPlaystation3" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>    
                    <asp:RangeValidator ID="RangeValidator5" runat="server" class="validator" ControlToValidate="TxtPricePlaystation3" Display="Dynamic" ErrorMessage="Price must be between 1.0 and 999.99" MaximumValue="999.99" MinimumValue="1" Type="Currency"></asp:RangeValidator>
                    <asp:RangeValidator ID="RangeValidator11" runat="server" class="validator" ControlToValidate="TxtStockPlaystation3" Display="Dynamic" ErrorMessage="Stock must be between 1 and 999." MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
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
                    <asp:CustomValidator ID="CustomValidator7" class="validator" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." ControlToValidate="TxtPricePlaystation4" OnServerValidate="CustomValidator7_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator8" class="validator" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." ControlToValidate="TxtStockPlaystation4" OnServerValidate="CustomValidator8_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator7" class="validator" runat="server" ControlToValidate="TxtPricePlaystation4" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator8" class="validator" runat="server" ControlToValidate="TxtStockPlaystation4" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                    <asp:RangeValidator ID="RangeValidator6" runat="server" class="validator" ControlToValidate="TxtPricePlaystation4" Display="Dynamic" ErrorMessage="Price must be between 1.0 and 999.99" MaximumValue="999.99" MinimumValue="1" Type="Currency"></asp:RangeValidator>
                    <asp:RangeValidator ID="RangeValidator12" runat="server" class="validator" ControlToValidate="TxtStockPlaystation4" Display="Dynamic" ErrorMessage="Stock must be between 1 and 999." MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
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
                    <asp:CustomValidator ID="CustomValidator9" class="validator" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." ControlToValidate="TxtPriceWii" OnServerValidate="CustomValidator9_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator10" class="validator" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." ControlToValidate="TxtStockWii" OnServerValidate="CustomValidator10_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator9" class="validator" runat="server" ControlToValidate="TxtPriceWii" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator10" class="validator" runat="server" ControlToValidate="TxtStockWii" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                    <asp:RangeValidator ID="RangeValidator7" runat="server" class="validator" ControlToValidate="TxtPriceWii" Display="Dynamic" ErrorMessage="Price must be between 1.0 and 999.99" MaximumValue="999.99" MinimumValue="1" Type="Currency"></asp:RangeValidator>
                    <asp:RangeValidator ID="RangeValidator13" runat="server" class="validator" ControlToValidate="TxtStockWii" Display="Dynamic" ErrorMessage="Stock must be between 1 and 999." MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
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
                    <asp:CustomValidator ID="CustomValidator11" class="validator" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." ControlToValidate="TxtPriceWiiU" OnServerValidate="CustomValidator11_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator12" class="validator" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." ControlToValidate="TxtStockWiiU" OnServerValidate="CustomValidator12_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator11" class="validator" runat="server" ControlToValidate="TxtPriceWiiU" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator12" class="validator" runat="server" ControlToValidate="TxtStockWiiU" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                    <asp:RangeValidator ID="RangeValidator8" runat="server" class="validator" ControlToValidate="TxtPriceWiiU" Display="Dynamic" ErrorMessage="Price must be between 1.0 and 999.99" MaximumValue="999.99" MinimumValue="1" Type="Currency"></asp:RangeValidator>
                    <asp:RangeValidator ID="RangeValidator14" runat="server" class="validator" ControlToValidate="TxtStockWiiU" Display="Dynamic" ErrorMessage="Stock must be between 1 and 999." MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
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
                    <asp:CustomValidator ID="CustomValidator13" class="validator" runat="server" Display="Dynamic" ErrorMessage="Price cannot be empty." ControlToValidate="TxtPricePC" OnServerValidate="CustomValidator13_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator14" class="validator" runat="server" Display="Dynamic" ErrorMessage="Stock cannot be empty." ControlToValidate="TxtStockPC" OnServerValidate="CustomValidator14_ServerValidate" ValidationGroup="ValPlatform" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator13" class="validator" runat="server" ControlToValidate="TxtPricePC" Display="Dynamic" ErrorMessage="Enter a valid price." Operator="DataTypeCheck" Type="Double" ></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator14" class="validator" runat="server" ControlToValidate="TxtStockPC" Display="Dynamic" ErrorMessage="Enter a valid stock." Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                    <asp:RangeValidator ID="RangeValidator9" runat="server" class="validator" ControlToValidate="TxtPricePC" Display="Dynamic" ErrorMessage="Price must be between 1.0 and 999.99" MaximumValue="999.99" MinimumValue="1" Type="Currency"></asp:RangeValidator>
                    <asp:RangeValidator ID="RangeValidator15" runat="server" class="validator" ControlToValidate="TxtStockPC" Display="Dynamic" ErrorMessage="Stock must be between 1 and 999." MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Button ID="BtnSubmit" runat="server" Text="Add Game" class="btn btn-primary" OnClick="BtnSubmit_Click" />
</asp:Content>

