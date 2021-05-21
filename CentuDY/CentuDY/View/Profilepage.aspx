<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profilepage.aspx.cs" Inherits="CentuDY.View.Profilepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Back to Home" ID="btnBack" OnClick="btnBack_Click" runat="server" />
            <br />
            <asp:Label Text="Username: " runat="server" />
            <asp:Label ID="lblUsername" Text="" runat="server" />
            <br />
            <asp:Label Text="Name: " runat="server" />
            <asp:Label ID="lblName" Text="" runat="server" />
            <br />
            <asp:Label Text="Gender: " runat="server" />
            <asp:Label ID="lblGender" Text="" runat="server" />
            <br />
            <asp:Label Text="Phone Number: " runat="server" />
            <asp:Label ID="lblPhone" Text="" runat="server" />
            <br />
            <asp:Label Text="Address: " runat="server" />
            <asp:Label ID="lblAddress" Text="" runat="server" />
            <br />
            <asp:Button Text="Update Profile" ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" />
            <asp:Button Text="Change Password" ID="btnChangePass" OnClick="btnChangePass_Click" runat="server" />
        </div>
    </form>
</body>
</html>
