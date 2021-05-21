<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordpage.aspx.cs" Inherits="CentuDY.View.ChangePasswordpage" %>

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
            <asp:Label Text="Old Password" runat="server" />
            <asp:TextBox ID="txtOld" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="New Password" runat="server" />
            <asp:TextBox ID="txtNew" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Confirm Password" runat="server" />
            <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnUpdate" Text="Update Password" OnClick="btnUpdate_Click" runat="server" />
            <asp:Label ID="lblErr" style="color:red" Text="" runat="server" />
        </div>
    </form>
</body>
</html>
