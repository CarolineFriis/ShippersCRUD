<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadUpdate.aspx.cs" Inherits="ShippersCRUD.ReadUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Read and update</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewShippers" runat="server" EmptyDataText="No data" OnSelectedIndexChanged="GridViewShippers_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField HeaderText="Your choise" ShowHeader="True" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="LabelMessage" runat="server" Text="No message"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxCompanyName" runat="server" Width="250px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelCompanyName" runat="server" Text="CompanyName"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxPhone" runat="server" Width="250px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelPhone" runat="server" Text="Phone"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" />
            <br />
            <br />
            <asp:Button ID="ButtonGoTocreate" runat="server" OnClick="ButtonGoTocreate_Click" Text="Go to Create" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonGoToDelete" runat="server" OnClick="ButtonGoToDelete_Click" Text="Go to Delete" />
        </div>
    </form>
</body>
</html>
