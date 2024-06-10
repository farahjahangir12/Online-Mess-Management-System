<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdminFeedback.aspx.vb" Inherits="AdminFeedback" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Feedback Details</title>
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
            <asp:Label ID="Label1" runat="server" CssClass="Label"></asp:Label>
        </div>
        <asp:Panel ID="FeedbackPanel" runat="server" Visible="true">
            <h2 style="margin:10px auto;text-align:center;">Feedback Details</h2>
            <asp:Table ID="FeedbackTable" runat="server" CssClass="qtable">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Feedback ID" CssClass="count"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Menu Type" CssClass="qcell"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="User Name" CssClass="optcell"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Feedback Text" CssClass="correctcell"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Rating" CssClass="correctcell"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </asp:Panel>
    </form>
</body>
</html>
