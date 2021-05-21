<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registerpage.aspx.cs" Inherits="CentuDY.View.Registerpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Registration</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Username" runat="server" />
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Password" runat="server" />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Confirm Password" runat="server" />
            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Name" runat="server" />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Gender" runat="server" />
            <asp:RadioButton ID="rbGenderMale" Text="Male" GroupName="gender" runat="server" />
            <asp:RadioButton ID="rbGenderFemale" Text="Female" GroupName="gender" runat="server" />
            <br />
            <asp:Label Text="PhoneNumber" runat="server" />
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Address" runat="server" />
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" Text="Register" runat="server" OnClick="btnSubmit_Click" />
            <asp:Label ID="lblErr" Style="color:red" Text="" runat="server" />
        </div>
    </form>
</body>
</html>
