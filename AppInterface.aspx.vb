Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Partial Class AppInterface
    Inherits System.Web.UI.Page

    Private Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        Label1.Text = ""
        Dim username As String = LoginUser.Text
        Dim pswd As String = LoginPassword.Text

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(pswd) Then
            Label1.Text = "Enter Credentials First!"
            Return
        End If

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim query As String = "SELECT [UserId], [UserName] FROM [User] WHERE UserName=@user AND Password=@pswd"
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@user", username)
        cmd.Parameters.AddWithValue("@pswd", pswd)

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                Dim id As String = reader("UserId").ToString()
                Dim dbUsername As String = reader("UserName").ToString()

                If dbUsername = "farahj2612" Then
                    Session("ID") = id
                    Response.Redirect("~/AdminView.aspx")
                Else
                    Session("UID") = id
                    Response.Redirect("~/MarkMess.aspx")
                End If
            Else
                Label1.Text = "Invalid username or password."
            End If
        Catch ex As Exception
            Label1.Text = "Error: " & ex.Message
        Finally
            con.Close()
        End Try

        ClearLoginFields()
    End Sub

    Private Sub Reg_Click(sender As Object, e As EventArgs) Handles Reg.Click
        If RegUser.Text = "" OrElse Password.Text = "" Then
            Label1.Text = "Enter Credentials First!"
            Return
        End If

        Dim user As String = RegUser.Text
        Dim pswd As String = Password.Text


        Dim passwordPattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$"
        If Not Regex.IsMatch(pswd, passwordPattern) Then
            Label1.Text = "Password must be 8-12 characters long, include at least one uppercase letter, one lowercase letter, one digit, and one special character."
            Return
        End If

        Dim name As String = Sname.Text
        Dim address As String = Saddress.Text
        Dim cnic As String = Scnic.Text
        Dim inserted As Integer = 0
        Dim cnicPattern As String = "^\d{5}-\d{7}-\d{1}$"
        If Not Regex.IsMatch(cnic, cnicPattern) Then
            Label1.Text = "Invalid CNIC format. Please use the format 00000-0000000-0"
            Return
        End If

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)

        Dim queryCheckUser As String = "SELECT COUNT(*) FROM [User] WHERE UserName=@user"
        Dim cmdCheckUser As New SqlCommand(queryCheckUser, con)
        cmdCheckUser.Parameters.AddWithValue("@user", user)

        Try
            con.Open()
            Dim userCounter As Integer = Convert.ToInt32(cmdCheckUser.ExecuteScalar())
            If userCounter > 0 Then
                Label1.Text = "User already exists, Please Sign Up."
                Return
            End If
        Catch ex As Exception
            Label1.Text = "Error checking user: " & ex.Message
            Return
        Finally
            con.Close()
        End Try

        Dim query As String = "INSERT INTO [User] ([Name], [CNIC], [Address], [Password], [UserName]) VALUES (@name, @cnic, @address, @pswd, @user)"
        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@cnic", cnic)
        cmd.Parameters.AddWithValue("@address", address)
        cmd.Parameters.AddWithValue("@pswd", pswd)
        cmd.Parameters.AddWithValue("@user", user)

        Try
            con.Open()
            inserted = cmd.ExecuteNonQuery()
        Catch ex As Exception
            Label1.Text = "Registration Failed: " & ex.Message
        Finally
            con.Close()
        End Try

        If inserted > 0 Then
            Response.Redirect("~/StudentView.aspx")
        Else
            Label1.Text = "Registration Failed"
        End If

        RegisterPanel.Visible = False
        LoginPanel.Visible = True
        ClearRegisterFields()
    End Sub

    Private Sub ClearLoginFields()
        LoginUser.Text = ""
        LoginPassword.Text = ""
        Label1.Text = ""
    End Sub

    Private Sub ClearRegisterFields()
        RegUser.Text = ""
        Password.Text = ""
        Sname.Text = ""
        Saddress.Text = ""
        Scnic.Text = ""
        Label1.Text = ""
    End Sub

    Private Sub ShowLogin_ServerClick(sender As Object, e As EventArgs) Handles ShowLogin.ServerClick
        RegisterPanel.Visible = False
        LoginPanel.Visible = True
        ClearRegisterFields()
    End Sub

    Private Sub ShowReg_ServerClick(sender As Object, e As EventArgs) Handles ShowReg.ServerClick
        RegisterPanel.Visible = True
        LoginPanel.Visible = False
        ClearLoginFields()
    End Sub
End Class
