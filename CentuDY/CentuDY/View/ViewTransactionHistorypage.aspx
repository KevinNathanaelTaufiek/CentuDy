<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTransactionHistorypage.aspx.cs" Inherits="CentuDY.View.ViewTransactionHistorypage" %>

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
            <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="MedicineName" HeaderText="Medicine Name" SortExpression="Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="SubTotal" />
                </Columns>
            </asp:GridView>
        
            <asp:Label Text="Grand Total : " runat="server" />
            <asp:Label ID="lblGTotal" Text="" runat="server" />
        </div>
    </form>
</body>
</html>
