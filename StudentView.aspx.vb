Imports System.Data.SqlClient

Partial Class StudentView
    Inherits System.Web.UI.Page

    Protected Sub Reg_Click(sender As Object, e As EventArgs) Handles Reg.Click
        Dim id As Integer = CType(Session("UID"), Integer)
        Dim session_t As String = SessionTextBox.Text
        Dim semester_t As String = Semester.Text
        Dim roomNo_t As String = RoomNo.Text


        If String.IsNullOrEmpty(session_t) OrElse String.IsNullOrEmpty(semester_t) OrElse String.IsNullOrEmpty(roomNo_t) Then
            Label1.Text = "All fields are required."
            Return
        End If

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)

        Dim query As String = "INSERT INTO Student ([UserId], [Session], [Semester],[Room_No], [CNIC]) VALUES (@id, @session, @semester, @roomno, @cnic)"
        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@session", session_t)
        cmd.Parameters.AddWithValue("@semester", semester_t)
        cmd.Parameters.AddWithValue("@roomno", roomNo_t)


        Try
            con.Open()
            Dim inserted As Integer = cmd.ExecuteNonQuery()

            If inserted > 0 Then
                Label1.Text = "Registration successful."
                Response.Redirect("MarkMess.aspx")
            Else
                Label1.Text = "Registration failed. Please try again."
            End If
        Catch ex As Exception
            Label1.Text = "Error during registration: " & ex.Message
        Finally
            con.Close()
        End Try
    End Sub
End Class
