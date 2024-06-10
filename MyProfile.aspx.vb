
Imports System.Data.SqlClient

Partial Class MyProfile
    Inherits System.Web.UI.Page


    Protected Sub MyProfile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadStudentDetails()
        End If
    End Sub

    Private Sub LoadStudentDetails()
        Dim userId As Integer = CType(Session("UID"), Integer)
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"

        Dim query As String = "SELECT U.Name, U.CNIC, U.Address, U.Username, S.Semester, S.Session, S.Room_No " &
                              "FROM [User] U INNER JOIN Student S ON U.UserId = S.UserId WHERE U.UserId = @UserId"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserId", userId)
                Try
                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        NameTextBox.Text = reader("Name").ToString()
                        CNICTextBox.Text = reader("CNIC").ToString()
                        AddressTextBox.Text = reader("Address").ToString()
                        UsernameTextBox.Text = reader("Username").ToString()
                        SemesterTextBox.Text = reader("Semester").ToString()
                        SessionTextBox.Text = reader("Session").ToString()
                        RoomNoTextBox.Text = reader("Room_No").ToString()
                    End If
                Catch ex As Exception
                    Label1.Text = "Error loading details: " & ex.Message
                End Try
            End Using
        End Using
    End Sub

    Protected Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        Dim userId As Integer = CType(Session("UID"), Integer)
        Dim name As String = NameTextBox.Text
        Dim cnic As String = CNICTextBox.Text
        Dim address As String = AddressTextBox.Text
        Dim username As String = UsernameTextBox.Text
        Dim semester As Integer = SemesterTextBox.Text
        Dim session_t As String = SessionTextBox.Text
        Dim roomNo As String = RoomNoTextBox.Text

        If Not Integer.TryParse(SemesterTextBox.Text, semester) Then
            Label1.Text = "Invalid semester format. Please enter a valid number."
            Return
        End If

        Dim cnicPattern As String = "^\d{5}-\d{7}-\d{1}$"
        If Not Regex.IsMatch(cnic, cnicPattern) Then
            Label1.Text = "Invalid CNIC format. Please use the format 00000-0000000-0"
            Return
        End If

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"

        Dim query As String = "UPDATE [User] SET Name=@Name, CNIC=@CNIC, Address=@Address, Username=@Username WHERE UserId=@UserId;" &
                              "UPDATE Student SET Semester=@Semester, Session=@Session, Room_No=@RoomNo WHERE UserId=@UserId"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Name", name)
                cmd.Parameters.AddWithValue("@CNIC", cnic)
                cmd.Parameters.AddWithValue("@Address", address)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Semester", semester)
                cmd.Parameters.AddWithValue("@Session", session)
                cmd.Parameters.AddWithValue("@RoomNo", roomNo)
                cmd.Parameters.AddWithValue("@UserId", userId)

                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    Label1.Text = "Details updated successfully."
                Catch ex As Exception
                    Label1.Text = "Error updating details: " & ex.Message
                End Try
            End Using
        End Using
    End Sub

End Class
