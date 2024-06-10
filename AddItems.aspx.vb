
Imports System.Data.SqlClient

Partial Class AddItems
    Inherits System.Web.UI.Page

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim description As String = DescriptionTextBox.Text
        Dim price As Decimal = Decimal.Parse(PriceTextBox.Text)
        Dim serving As Integer = Integer.Parse(ServingTextBox.Text)

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim query As String = "INSERT INTO MenuItem ([Description], [Price], [Serving]) VALUES (@Description, @Price, @Serving)"

        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand()
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@Description", description)
        cmd.Parameters.AddWithValue("@Price", price)
        cmd.Parameters.AddWithValue("@Serving", serving)


        Try
            con.Open()
            cmd.CommandText = query
            cmd.ExecuteNonQuery()
            Label1.Text = "New item inserted."

        Catch ex As Exception
            Label1.Text = ex.Message
        Finally
            con.Close()
        End Try

    End Sub
End Class
