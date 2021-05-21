<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertMedicinepage.aspx.cs" Inherits="CentuDY.View.InsertMedicinepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnBack" OnClick="btnBack_Click" Text="Back" runat="server" />
            <br />
            <asp:Label Text="Nama: " runat="server" />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Description: " runat="server" />
            <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Stock: " runat="server" />
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Price: " runat="server" />
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

            <asp:Button ID="btnInsert" Text="Insert" OnClick="btnInsert_Click" runat="server" />
        </div>
        <asp:Label Text="" ID="lblErr" style="color:red" runat="server" />
        </form>
</body>
</html>
