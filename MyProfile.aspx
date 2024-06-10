<%@ Page Language="VB" AutoEventWireup="true" CodeFile="MyProfile.aspx.vb" Inherits="MyProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Your Details</title>
    <link href="appStyles.css" rel="stylesheet" />
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
    <section>
        <div class="form-box">
            <div class="form-value">
                <form id="form1" runat="server">
                    <div>
                        <h2>Edit Your Details</h2>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>CNIC:</td>
                                <td><asp:TextBox ID="CNICTextBox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Address:</td>
                                <td><asp:TextBox ID="AddressTextBox" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Username:</td>
                                <td><asp:TextBox ID="UsernameTextBox" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Semester:</td>
                                <td>
                                    <asp:TextBox ID="SemesterTextBox" runat="server"></asp:TextBox>
                            </tr>
                            <tr>
                                <td>Session:</td>
                                <td><asp:TextBox ID="SessionTextBox" runat="server" CssClass="textbox"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Room No:</td>
                                <td><asp:TextBox ID="RoomNoTextBox" runat="server" CssClass="textbox"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="UpdateButton" runat="server" Text="Update" CssClass="button" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </form>
            </div>
        </div>
    </section>
</body>
</html>
