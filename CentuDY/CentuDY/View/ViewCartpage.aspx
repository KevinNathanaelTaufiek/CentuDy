<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCartpage.aspx.cs" Inherits="CentuDY.View.ViewCartpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnBack" OnClick="btnBack_Click" Text="Back" runat="server" />
            <br />
            <asp:GridView ID="gvInfo" runat="server" AutoGenerateColumns="False">
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CommandArgument='<%# Eval("MedicineId") %>' ID="btnDelete" Text="Delete Cart"
                                    runat="server" OnClick="btnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MedicineName" HeaderText="Medicine Name" SortExpression="Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                        <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="SubTotal" />
                        <asp:BoundField DataField="MedicineId" HeaderText="Medicine Id"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" SortExpression="MedicineId" />
                    </Columns>
            </asp:GridView>
            <asp:Label Text="Grand Total : " runat="server" />
            <asp:Label ID="lblGTotal" Text="" runat="server" />
            <br />
            <asp:Button ID="btnCheckout" Text="Checkout" OnClick="btnCheckout_Click" runat="server" />
            <br />
            <asp:Label Text="" ID="lblErr" style="color:red" runat="server" />
        </div>
    </form>
</body>
</html>
