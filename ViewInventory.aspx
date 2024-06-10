<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewInventory.aspx.vb" Inherits="ViewInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="TableStyles.css" rel="stylesheet" />
</head>
    
<body style="background-color:#f5b553;">
     <nav class="navbar">
      <a href="AdminView.aspx" class="nav-item">Return</a>
 </nav>
    <form id="form1" runat="server">
          <h2 style="margin:10px auto;text-align:center;">Added Items</h2>
  <asp:Table ID="qtable" runat="server" class="qtable">
      <asp:TableHeaderRow CssClass="qrow">
          <asp:TableHeaderCell Text="Item Id" CssClass="count">
          </asp:TableHeaderCell>
           <asp:TableHeaderCell Text="Description" CssClass="qcell">
          </asp:TableHeaderCell>
           <asp:TableHeaderCell Text="Price" CssClass="optcell">
           </asp:TableHeaderCell>
           <asp:TableHeaderCell Text="Unit Of Measure" CssClass="optcell">
           </asp:TableHeaderCell>
           <asp:TableHeaderCell Text="Quantity" CssClass="correctcell">
 </asp:TableHeaderCell>
      </asp:TableHeaderRow>
  </asp:Table>
  <asp:Label ID="Label1" runat="server" ></asp:Label>
    </form>
</body>
</html>
