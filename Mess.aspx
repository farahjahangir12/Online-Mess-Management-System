<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mess.aspx.vb" Inherits="Mess"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
     <h1>Mark Mess</h1><br />
     <div>
         <asp:Label ID="Type" runat="server" Text="Select Menu Type"></asp:Label><br />
         <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textbox">
         <asp:ListItem>Select Type</asp:ListItem>
         <asp:ListItem>Breakfast</asp:ListItem>
         <asp:ListItem>Lunch</asp:ListItem>
         <asp:ListItem>Dinner</asp:ListItem>
          <asp:ListItem>Other</asp:ListItem>
         </asp:DropDownList><br />
         <asp:Button ID="ShowItems" runat="server" Text="Show Items" CssClass="button"  Width="50%"/><br />
       
         <asp:Panel ID="PanelItem" runat="server" Visible="False">
         <asp:Label ID="Menu" runat="server" Text="Select Items"></asp:Label><br />
         <asp:CheckBoxList ID="ItemsList" runat="server" CssClass="textbox" Style="display:flex; align-items:flex-start;flex-direction:row;"></asp:CheckBoxList><br />
         <asp:Button ID="ConfirmItems" runat="server" Text="Confirm" CssClass="button" Width="50%"/><br />
             </asp:Panel>
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
     </div>
    </form>
</body>
</html>
