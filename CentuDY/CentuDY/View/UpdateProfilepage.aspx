<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfilepage.aspx.cs" Inherits="CentuDY.View.UpdateProfilepage" %>

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
            <asp:Label Text="Name: " runat="server" />
            <asp:TextBox ID="txtName" runat="server" />
            <br />
            <asp:Label Text="Gender" runat="server" />
            <asp:RadioButton ID="rbGenderMale" Text="Male" GroupName="gender" runat="server" />
            <asp:RadioButton ID="rbGenderFemale" Text="Female" GroupName="gender" runat="server" />
            <br />
            <asp:Label Text="Phone Number: " runat="server" />
            <asp:TextBox ID="txtPhone" runat="server" />
            <br />
            <asp:Label Text="Address: " runat="server" />
            <asp:TextBox ID="txtAddress" style="resize:none;" Rows="10" Columns="15" TextMode="MultiLine" runat="server" />
            <br />
            <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" Text="Update Profile" runat="server" />
            <asp:Label ID="lblErr" style="color:red;" Text="" runat="server" />
        </div>
    </form>
</body>
</html>
