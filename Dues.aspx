<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Dues.aspx.vb" Inherits="Dues" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="AdminStyles.css" rel="stylesheet" />
</head>
<body>
                <nav class="navbar">
    <div class="nav-left">
           <a href="StudentMenuView.aspx" class="nav-item">Today's Menu</a>
           <a href="MarkMess.aspx" class="nav-item">Mark Mess</a>
           <a href="Dues.aspx" class="nav-item">Dues</a>
           <a href="MyProfile.aspx" class="nav-item">Edit Profile</a>
           <a href="Feedback.aspx" class="nav-item">Feedback</a>
       </div>
       <div class="nav-right">
          <a href="AppInterface.aspx" class="nav-item">LogOut</a>
       </div>
</nav>
    <form id="form1" runat="server" class="registration">
        <div>
            <asp:GridView ID="InvoiceGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order ID" />
                    <asp:BoundField DataField="Date" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="MenuItemDescription" HeaderText="Menu Item" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="ItemTotal" HeaderText="Total" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Bill" runat="server" Font-Bold="True"></asp:Label>
        </div>
    </form>
</body>
</html>
