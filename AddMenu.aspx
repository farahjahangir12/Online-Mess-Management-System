<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddMenu.aspx.vb" Inherits="AddMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="AdminStyles.css" rel="stylesheet" />
   <style>

    .menu-panel {
        display: inline-block;
        vertical-align: top;
        width: 23%;
        margin: 1%;
        padding: 10px;
        border: 1px solid #ccc;
        box-sizing: border-box;
    }

</style>
    
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
    <h1 style="text-align:center;">Add Menu</h1><br />
    <form id="form1" runat="server" style="display:flex; flex-direction:row; align-items:flex-start;">
        
        <asp:Panel ID="Panel1" runat="server"  CssClass="menu-panel" Style="background-color:#d9dad7;">
            <asp:Label ID="Type" runat="server" Text="Select Menu Type" Style="margin-left:3px;"></asp:Label><br />
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textbox">
            <asp:ListItem>Select Type</asp:ListItem>
            <asp:ListItem>Breakfast</asp:ListItem>
            <asp:ListItem>Lunch</asp:ListItem>
            <asp:ListItem>Dinner</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Button ID="Show" runat="server" Text="Show Items" CssClass="button"  Width="50%"  Style="background-color:#1d1716;color:white;"/><br />
          </asp:Panel><br />
            <asp:Panel ID="Panel2" runat="server" CssClass="menu-panel" Style="background-color:#d9dad7;" Enabled="False" >
            <asp:Label ID="Menu" runat="server" Text="Select Items"></asp:Label><br />
               <div >
                   <asp:RadioButtonList ID="ItemsList" runat="server" CssClass="textbox"></asp:RadioButtonList><br />
               </div>
                
            <asp:Button ID="Confirm" runat="server" Text="Ok" CssClass="button" Width="50%" Style="background-color:#1d1716;color:white;"/><br />
                </asp:Panel><br />
           
            <asp:Panel ID="Panel3" runat="server" CssClass="menu-panel" Style="background-color:#d9dad7;" Enabled="False">
                <asp:Label  runat="server" Text="Select Items Required"></asp:Label><br />
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="textbox">
                    <asp:ListItem>Select Item</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="ShowInventory" runat="server" Text="Ok" CssClass="button" Style="background-color:#1d1716;color:white;"  Width="50%"/>
                </asp:Panel><br />
            <asp:Panel ID="Panel4" runat="server"  CssClass="menu-panel" Style="background-color:#d9dad7;" Enabled="False">
                  <asp:Label  runat="server" Text="Enter Quantity"></asp:Label><br />
                <asp:TextBox ID="ItemQuantity" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:Button ID="ConfirmItem" runat="server" Text="Ok" CssClass="button" Style="background-color:#1d1716;color:white;"  Width="50%" />
            </asp:Panel>
        <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    </form>
</body>
</html>

