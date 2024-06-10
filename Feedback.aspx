<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Feedback.aspx.vb" Inherits="Feedback" %>

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
           <a href="AppInterface" class="nav-item">LogOut</a>
       </div>
</nav>
    <form id="form1" runat="server" class="registration">
        <h2 style="margin-left:3px;">Submit Feedback</h2><br />
        <div>
          
            <label for="MenuType">Menu Type:</label><br />
            <asp:DropDownList ID="ddlMenuType" runat="server" Style="margin-left:3px;" CssClass="textbox">
                <asp:ListItem Text="Breakfast" Value="1"></asp:ListItem>
                <asp:ListItem Text="Lunch" Value="2"></asp:ListItem>
                <asp:ListItem Text="Dinner" Value="3"></asp:ListItem>
                 <asp:ListItem Text="Other" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <label for="txtFeedback">Feedback Text:</label><br />
            <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" CssClass="textbox" Rows="5" Columns="40"></asp:TextBox>
            <br /><radiobutton></radiobutton>
            <label for="Rating">Rating:</label><br />
            <asp:DropDownList ID="ddlRating" runat="server" CssClass="textbox" Style="margin-left:3px;">
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="button" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
