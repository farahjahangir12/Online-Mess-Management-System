<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StudentMenuView.aspx.vb" Inherits="StudentMenuView" %>

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
            <nav class="navbar">
    <div class="nav-left">
           <a href="StudentMenuView.aspx" class="nav-item">Today's Menu</a>
           <a href="MarkMess.aspx" class="nav-item">Mark Mess</a>
           <a href="MyDues.aspx" class="nav-item">Dues</a>
           <a href="MyProfile.aspx" class="nav-item">Edit Profile</a>
           <a href="Feedback.aspx" class="nav-item">Feedback</a>
       </div>
       <div class="nav-right">
            <a href="AppInterface.aspx" class="nav-item">LogOut</a>
       </div>
</nav>
    <form id="form1" runat="server" style="display:flex; align-items:flex-start; flex-direction:row;">
    <asp:Panel ID="Breakfast" runat="server" CssClass="menu-panel" Style="background-color:#d9dad7;">
        <asp:Label runat="server" Text="Breakfast" Style="background-color:#1d1716;padding:4px;margin:3px;color:white;text-align:center;" Width="100%"></asp:Label>

    </asp:Panel><br />
      <asp:Panel ID="Lunch" runat="server" CssClass="menu-panel" Style="background-color:#d9dad7;" >
        <asp:Label runat="server" Text="Lunch" Style="background-color:#1d1716;padding:4px;margin:3px;color:white;text-align:center;" Width="100%"></asp:Label>

      </asp:Panel><br />
      <asp:Panel ID="Dinner" runat="server" CssClass="menu-panel" Style="background-color:#d9dad7;">
        <asp:Label runat="server" Text="Dinner" Style="background-color:#1d1716;padding:4px;margin:3px;color:white;text-align:center;" Width="100%"></asp:Label>

      </asp:Panel><br />
      <asp:Panel ID="Other" runat="server" CssClass="menu-panel" Style="background-color:#d9dad7;">
        <asp:Label runat="server" Text="Other" Style="background-color:#1d1716;padding:4px;margin:3px;color:white;text-align:center;" Width="100%"></asp:Label>

      </asp:Panel><br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</form>
</body>
</html>
