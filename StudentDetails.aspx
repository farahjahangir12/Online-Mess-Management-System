<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StudentDetails.aspx.vb" Inherits="StudentDetails" %>

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
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter Mess Id:"></asp:Label><br />
            <asp:TextBox ID="Sname" runat="server" CssClass="textbox"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="See Details" CssClass="button"/>
        </div>
         <asp:Panel ID="Details" runat="server" Visible="false">
                 <h2 style="margin:10px auto;text-align:center;">Details</h2>
           <asp:Table ID="qtable" runat="server" class="qtable">
     <asp:TableHeaderRow CssClass="qrow">
         <asp:TableHeaderCell Text="Name" CssClass="count">
         </asp:TableHeaderCell>
          <asp:TableHeaderCell Text="Semester" CssClass="qcell">
         </asp:TableHeaderCell>
          <asp:TableHeaderCell Text="Room No" CssClass="optcell">
          </asp:TableHeaderCell>
          <asp:TableHeaderCell Text="Dues" CssClass="optcell">
          </asp:TableHeaderCell>
         
     </asp:TableHeaderRow>
 </asp:Table>
        </asp:Panel>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
