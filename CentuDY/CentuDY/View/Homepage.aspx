<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="CentuDY.View.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Homepage</h1>
    <form id="form1" runat="server">
        <div>
            Hi, <asp:Label ID="lblUsername" Text="" runat="server" /> 
            <br />

            <asp:GridView ID="gvRekomen" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Medicine Name" SortExpression="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:TemplateField HeaderText="Add to Cart"> 
                        <ItemTemplate>
                            <asp:button ID="btnAddToCart" CommandArgument='<%# Eval("MedicineId")%>' text="Add To Cart" OnClick="btnAddToCart_Click" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <asp:Button ID="btnInsertMedicines" Visible="false" Text="Insert Medicine" runat="server" OnClick="btnInsertMedicines_Click"/>
            <asp:Button ID="btnViewUsers" Visible="false" Text="View Users" runat="server" OnClick="btnViewUsers_Click"/>
            <asp:Button ID="btnTransReport" Visible="false" Text="View Transaction Report" runat="server" OnClick="btnTransReport_Click"/>


            <asp:Button ID="btnViewCart" Visible="false" Text="View Cart" runat="server" OnClick="btnViewCart_Click"/>
            <asp:Button ID="btnTransHistory" Visible="false" Text="View Transaction History" runat="server" OnClick="btnTransHistory_Click"/>
            
            <br />
            <hr />
            
            <asp:Button ID="btnViewMedicines" Text="View Medicines" runat="server" OnClick="btnViewMedicines_Click" />
            <asp:Button ID="btnProfile" Text="Profile" runat="server" OnClick="btnProfile_Click"/>

            <asp:Button ID="btnLogout" Text="Logout" OnClick="btnLogout_Click" runat="server" />

        </div>
    </form>
</body>
</html>
