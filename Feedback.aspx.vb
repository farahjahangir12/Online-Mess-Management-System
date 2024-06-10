
Imports System.Data.SqlClient

Partial Class Feedback
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim menuType As Integer = Convert.ToInt32(ddlMenuType.SelectedValue)
        Dim feedbackText As String = txtFeedback.Text.Trim()
        Dim rating As Integer = Convert.ToInt32(ddlRating.SelectedValue)
        Dim userId As Integer = Convert.ToInt32(Session("UserId")) '

        Dim query As String = "INSERT INTO Feedback (Date, MenuId, UserId, FeedbackText, Rating) VALUES (@Date, @MenuId, @UserId, @FeedbackText, @Rating)"

        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, con)

        cmd.Parameters.AddWithValue("@Date", DateTime.Now)
        cmd.Parameters.AddWithValue("@MenuId", menuType)
        cmd.Parameters.AddWithValue("@UserId", userId)
        cmd.Parameters.AddWithValue("@FeedbackText", feedbackText)
        cmd.Parameters.AddWithValue("@Rating", rating)

        Try
            con.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                Label1.Text = "Feedback submitted successfully."
                txtFeedback.Text = ""
                ddlRating.SelectedIndex = 0
                ddlMenuType.SelectedIndex = 0
            Else
                Label1.Text = "Failed to submit feedback."
            End If
                Catch ex As Exception
            Label1.Text = "Error: " & ex.Message
        End Try

    End Sub
End Class

