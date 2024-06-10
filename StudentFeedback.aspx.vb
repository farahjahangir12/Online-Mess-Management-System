Imports System.Data.SqlClient

Partial Class StudentFeedback
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadMenus()
        End If


    End Sub

    Private Sub LoadMenus()
        Dim currentdate As Date = Date.Today
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)
        Dim query As String = "SELECT [MenuID], [Type] FROM Menu WHERE Date=@currentdate"
        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@currentdate", currentdate)
        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            MenuList.Items.Clear() ' Clear existing items
            While reader.Read
                Dim newItem As New ListItem
                newItem.Text = reader("Type").ToString()
                newItem.Value = reader("MenuID").ToString()
                MenuList.Items.Add(newItem)
            End While
        Catch ex As Exception
            Label1.Text = "Error: " & ex.Message
        Finally
            con.Close()
        End Try
    End Sub

    Protected Sub SubmitFeedback_Click(sender As Object, e As EventArgs)
        Label1.Text = "" ' Clear previous messages

        If Not ValidateInputs() Then
            Return
        End If

        Dim menuID As Integer = Convert.ToInt32(MenuList.SelectedValue)
        Dim userID As Integer = Convert.ToInt32(Session("UID"))
        Dim feedback As String = FeedbackText.Text
        Dim menuRating As Integer = Convert.ToInt32(Rating.Text)

        If InsertFeedback(menuID, userID, feedback, menuRating) Then
            Label1.Text = "Feedback submitted successfully."
            ClearInputs()
        Else
            Label1.Text = "Insertion failed or no rows affected."
        End If
    End Sub

    Private Function ValidateInputs() As Boolean
        If MenuList.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(MenuList.SelectedValue) Then
            Label1.Text = "Please select a menu."
            Return False
        End If

        If Session("UID") Is Nothing OrElse Not Integer.TryParse(Session("UID").ToString(), Nothing) Then
            Label1.Text = "User session is not valid. Please log in again."
            Return False
        End If

        If String.IsNullOrEmpty(FeedbackText.Text) Then
            Label1.Text = "Please enter feedback."
            Return False
        End If

        Dim menuRating As Integer
        If Not Integer.TryParse(Rating.Text, menuRating) Then
            Label1.Text = "Please enter a valid rating."
            Return False
        End If

        Return True
    End Function

    Private Function InsertFeedback(menuID As Integer, userID As Integer, feedback As String, rating As Integer) As Boolean
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim query As String = "INSERT INTO Feedback ([MenuID], [UserID], [FeedbackText], [Rating]) VALUES (@MenuID, @UserID, @FeedbackText, @Rating)"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@MenuID", menuID)
                cmd.Parameters.AddWithValue("@UserID", userID)
                cmd.Parameters.AddWithValue("@FeedbackText", feedback)
                cmd.Parameters.AddWithValue("@Rating", rating)

                Try
                    con.Open()
                    Dim inserted As Integer = cmd.ExecuteNonQuery()
                    Return inserted > 0
                Catch ex As Exception
                    Label1.Text = "Error: " & ex.Message
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Sub ClearInputs()
        FeedbackText.Text = ""
        Rating.Text = ""
    End Sub
End Class
