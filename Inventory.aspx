<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Inventory.aspx.vb" Inherits="Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="AdminStyles.css" rel="stylesheet" />
</head>
<body>
        <nav class="navbar" style="background-color:#1d1716;">
    <div class="nav-left">
           <a href="Add.aspx" class="nav-item">Add</a>
           <a href="ViewInventory.aspx" class="nav-item">View</a>
           
          
         
       </div>
       <div class="nav-right">
           <a href="AdminView.aspx" class="nav-item">Return</a>
       </div>
</nav>
    <form id="form1" runat="server" class="registration">
        <div>
               <h1>Search Items</h1><br />
   <asp:DropDownList ID="inventoryDropDown" runat="server" DataTextField="Description" DataValueField="Price" Style="padding:4px; width:52%;margin-bottom:2px;">
       <asp:ListItem Text="Select Items" id="list" runat="server" Value="" />
   </asp:DropDownList><br /></br>
    
   <asp:Button ID="Button1" runat="server" Text="See Details" Width="20%" Style="padding:8px; background-color:#4a4a48; color:azure; margin-top:2px;margin-bottom:2px; border:1px solid #4a4a48; border-radius:3px;" /><br />
  <div id="details" runat="server" visible="false">
<asp:Label ID="Price" runat="server" Style="margin-top:2px;"  ></asp:Label><br />
   <asp:Label ID="Measure" runat="server" Style="margin-top:2px;"></asp:Label><br /></div> 
<br />
              <asp:Label ID="Quantity" runat="server" Style="margin-top:2px;"></asp:Label><br /></div> 
<br /><asp:Label runat="server" id="Label1"></asp:Label>
        </div>
    </form>
</body>
</html>
