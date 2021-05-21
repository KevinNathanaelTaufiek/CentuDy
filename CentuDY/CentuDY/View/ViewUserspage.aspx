<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUserspage.aspx.cs" Inherits="CentuDY.View.ViewUserspage" %>

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

            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="RoleName" HeaderText="Role" SortExpression="RoleName" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" CommandArgument='<%# Eval("UserId")%>' runat="server" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label Text="" style="color:red" ID="lblErr" runat="server" />
        </div>
    </form>
</body>
</html>
