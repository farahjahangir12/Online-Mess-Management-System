<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdminView.aspx.vb" Inherits="AdminView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="appStyles.css" rel="stylesheet" />
    <title></title>
</head>
<body>
     <nav class="navbar">
     <div class="nav-left">
            <a href="Inventory.aspx" class="nav-item">Inventory</a>
            <a href="AddMenu.aspx" class="nav-item">Menu</a>
            <a href="StudentDetails.aspx" class="nav-item">Students</a>
            <a href="AdminFeedback.aspx" class="nav-item">Feedback</a>
        </div>
        <div class="nav-right">
            <a href="AppInterface.aspx" class="nav-item">LogOut</a>
        </div>
 </nav>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
