<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add.aspx.vb" Inherits="Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="AdminStyles.css" rel="stylesheet" />
</head>
<body>
           
               
    <nav class="navbar" style="background-color:#1d1716;">
           <div class="nav-left">
           <a href="AddMenu.aspx" class="nav-item">Add Menu</a>
           <a href="ViewMenu.aspx" class="nav-item">View Menu</a> 
           <a href="AddItems.aspx" class="nav-item">Add Items</a>
           <a href="ViewMenuItems.aspx" class="nav-item">View Items</a> 
         </div>
       <div class="nav-right">
           <a href="Inventory.aspx" class="nav-item">Return</a>
       </div>
</nav>
    <form id="form1" runat="server" class="registration">
        
  <h1>Items Entry</h1><br />
 <label for="description">Description</label><br />
 <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="textbox" ></asp:TextBox><br />
 <label for="price">Price</label><br />
 <asp:TextBox ID="PriceTextBox" runat="server" CssClass="textbox" ></asp:TextBox><br />
 <label for="unit-measure">Unit Of Measure</label><br />
 <asp:TextBox ID="UnitMeasure" runat="server" CssClass="textbox"></asp:TextBox><br />
  <label for="quantity">Quantity</label><br />
 <asp:TextBox ID="QtyTextBox" runat="server" CssClass="textbox"></asp:TextBox><br />
 <asp:Button ID="Add" runat="server" Text="Done" CssClass="button"/><br />
 <asp:Label ID="Label1" runat="server"></asp:Label>
        
    </form>
</body>
</html>
