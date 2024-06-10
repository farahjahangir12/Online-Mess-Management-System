<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StudentView.aspx.vb" Inherits="StudentView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="appStyles.css" rel="stylesheet" />
</head>
<body>
        
    <section>
    <div class="form-box">
        <div class="form-value">
    <form id="form1" runat="server">
            <asp:Panel ID="RegisterPanel" runat="server"  Height="100%">
    <h2>Personal Information</h2>
    <div class="inputbox">
        <asp:TextBox ID="SessionTextBox" runat="server" CssClass="input-field" required="required" placeholder="Session"></asp:TextBox>
    </div>
    <div class="inputbox">
        <asp:DropDownList ID="Semester" runat="server" CssClass="input-field" required="required">
            <asp:ListItem>Select Semester</asp:ListItem>
             <asp:ListItem>1</asp:ListItem>
             <asp:ListItem>2</asp:ListItem>
             <asp:ListItem>3</asp:ListItem>
             <asp:ListItem>4</asp:ListItem>
             <asp:ListItem>5</asp:ListItem>
             <asp:ListItem>6</asp:ListItem>
             <asp:ListItem>7</asp:ListItem>
             <asp:ListItem>8</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="inputbox">
        <asp:DropDownList ID="Wing" runat="server" CssClass="input-field">
             <asp:ListItem>Select Wing</asp:ListItem>
             <asp:ListItem>A</asp:ListItem>
             <asp:ListItem>B</asp:ListItem>
             <asp:ListItem>C</asp:ListItem>
             <asp:ListItem>D</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="inputbox">
        <asp:TextBox ID="RoomNo" runat="server" CssClass="input-field" required="required" placeholder="Room No."></asp:TextBox>
    </div>
    
    <asp:Button ID="Reg" runat="server" Text="Confirm" CssClass="button" />
                </asp:Panel>
    </form>
            </div>
         </div>
        </section>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</body>
</html>
