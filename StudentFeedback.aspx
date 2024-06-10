<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StudentFeedback.aspx.vb" Inherits="StudentFeedback" %>

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
           <a href="#" class="nav-item">LogOut</a>
       </div>
</nav>
    <form id="form1" runat="server" class="registration">
        <div>
        <h2>Submit Feedback</h2>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Select Menu Type" Style="margin-left:3px;"></asp:Label><br />
            <asp:DropDownList ID="MenuList" runat="server" CssClass="textbox" Style="margin-left:3px;">
                <asp:ListItem>Select type</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:TextBox ID="FeedbackText" runat="server" TextMode="MultiLine" Rows="5" Columns="40" placeholder="Enter your feedback here" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:TextBox ID="Rating" runat="server" placeholder="Enter Rating (1-10)" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:Button ID="SubmitFeedback" runat="server" Text="Submit" CssClass="button" /><br /><br />
        </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
