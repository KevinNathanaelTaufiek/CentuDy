<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="CentuDY.View.Loginpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Login</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Username" runat="server" />
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Password" runat="server" />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:CheckBox ID="cbRemember" Text="Remember Me" runat="server" />
            <br />
            <asp:Button ID="btnSubmit" Text="Login" OnClick="btnSubmit_Click" runat="server" />
            <asp:Label ID="lblErr" Style="color:red" Text="" runat="server" />
            <br />
            <a href="Registerpage.aspx">Create an account</a>
        </div>
    </form>
</body>
</html>
