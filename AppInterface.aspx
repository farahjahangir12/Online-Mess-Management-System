<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AppInterface.aspx.vb" Inherits="AppInterface" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main</title>
    <link href="appStyles.css" rel="stylesheet" />
   
    
</head>
<body>
    
    <section>
        <div class="form-box">
            <div class="form-value">
                <form id="form1" runat="server">
                    <asp:Panel ID="LoginPanel" runat="server" Visible="true">
                        <h2>Login</h2>
                        <div class="inputbox">
                            <asp:TextBox ID="LoginUser" runat="server" CssClass="input-field" required="required" placeholder="Username"></asp:TextBox>
                        </div>
                        <div class="inputbox">
                            <asp:TextBox ID="LoginPassword" runat="server" CssClass="input-field" TextMode="Password" required="required" placeholder="Password"></asp:TextBox>
                        </div>
                        <asp:Button ID="LogIn" runat="server" Text="Log In" CssClass="button" />
                        <div class="register">
                            <p>Don't have an account? <a href="#" id="ShowReg" runat="server">Sign Up</a></p>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="RegisterPanel" runat="server" Visible="false" Height="100%">
                        <h2>Register</h2>
                        <div class="inputbox">
                            <asp:TextBox ID="RegUser" runat="server" CssClass="input-field" required="required" placeholder="Username"></asp:TextBox>
                        </div>
                        <div class="inputbox">
                            <asp:TextBox ID="Sname" runat="server" CssClass="input-field" required="required" placeholder="Name"></asp:TextBox>
                        </div>
                        <div class="inputbox">
                            <asp:TextBox ID="Scnic" runat="server" CssClass="input-field" required="required" placeholder="CNIC"></asp:TextBox>
                        </div>
                        <div class="inputbox">
                            <asp:TextBox ID="Saddress" runat="server" CssClass="input-field" required="required" placeholder="Address"></asp:TextBox>
                        </div>
                        <div class="inputbox">
                            <asp:TextBox ID="Password" runat="server" CssClass="input-field" TextMode="Password" required="required" placeholder="Password"></asp:TextBox>
                        </div>
                        <asp:Button ID="Reg" runat="server" Text="Sign Up" CssClass="button" />
                        <div class="register">
                            <p>Already have an account? <a href="#" runat="server" id="ShowLogin">Sign In</a></p>
                        </div>
                    </asp:Panel>
                </form>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </section>

    
</body>
</html>
