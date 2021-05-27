<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMedicinespage.aspx.cs" Inherits="CentuDY.View.ViewMedicinespage" %>

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
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button Text="Search" ID="btnSearch" OnClick="btnSearch_Click" runat="server" />
            <br />
            <asp:GridView ID="gvMedicine" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                    <% if(roleUser.Equals("Administrator"))
                        { %>
                            <asp:button ID="btnUpdate" CommandArgument='<%# Eval("MedicineId")%>' text="Update" OnClick="btnUpdate_Click" runat="server" />
                       <% } %>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete"> 
                        <ItemTemplate>
                    <% if(roleUser.Equals("Administrator"))
                        { %>
                            <asp:button ID="btnDelete" CommandArgument='<%# Eval("MedicineId")%>' text="Delete" OnClick="btnDelete_Click" runat="server" />
                        <% } %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:TemplateField HeaderText="Add to Cart"> 
                        <ItemTemplate>
                        <% if(roleUser.Equals("Member")) { %>
                            <asp:button ID="btnAddToCart" CommandArgument='<%# Eval("MedicineId")%>' text="Add To Cart" OnClick="btnAddToCart_Click" runat="server" />
                        <% } %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <% if(roleUser.Equals("Administrator"))
               { %>
            <asp:Button Text="Insert" ID="btnInsert" OnClick="btnInsert_Click" runat="server" />
            <% } %>
        <asp:Label Text="" ID="lblErr" runat="server" />
        </div>
    </form>
</body>
</html>
