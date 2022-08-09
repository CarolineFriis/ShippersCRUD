<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ShippersCRUD.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewShippers" runat="server" EmptyDataText="No data">
            </asp:GridView>
            <br />
            <asp:DropDownList ID="DropDownListShippers" runat="server" OnSelectedIndexChanged="DropDownListShippers_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="LabelMessage" runat="server" Text="No message"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" />
            <br />
            <br />
            <asp:Button ID="ButtonGoToReadUpdate" runat="server" PostBackUrl="~/ReadUpdate.aspx" Text="Go to ReadUpodate" />
&nbsp;&nbsp;
            <asp:Button ID="ButtonGoToCreate" runat="server" PostBackUrl="~/Create.aspx" Text="Go to Create" />
            <br />
        </div>
    </form>
</body>
</html>
