<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ShippersCRUD.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxCompanyName" runat="server" Width="250px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelCompanyName" runat="server" Text="Companyname"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxPhone" runat="server" Width="250px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelPhone" runat="server" Text="Phone"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelMessage" runat="server" Text="No message"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Create" />
            <br />
            <br />
            <asp:Button ID="ButtonGoToReadUpdate" runat="server" PostBackUrl="~/ReadUpdate.aspx" Text="Go to ReadUpdate" />
&nbsp;&nbsp;
            <asp:Button ID="ButtonGoToDelete" runat="server" PostBackUrl="~/Delete.aspx" Text="Go to Delete" />
        </div>
    </form>
</body>
</html>
