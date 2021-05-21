<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToCartpage.aspx.cs" Inherits="CentuDY.View.AddToCartpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Name : " runat="server" />
            <asp:Label ID="lblName" Text="" runat="server" />
            <br />
            <asp:Label Text="Description : " runat="server" />
            <asp:Label ID="lblDesc" Text="" runat="server" />
            <br />
            <asp:Label Text="Stock : " runat="server" />
            <asp:Label ID="lblStock" Text="" runat="server" />
            <br />
            <asp:Label Text="Price : " runat="server" />
            <asp:Label ID="lblPrice" Text="" runat="server" />
            <br />
            <asp:Label Text="Quantity : " runat="server" />
            <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAdd" Text="Add to Cart" OnClick="btnAdd_Click" runat="server" />
            <asp:Label Text="" ID="lblErr" style="color:red" runat="server" />
        </div>
    </form>
</body>
</html>
