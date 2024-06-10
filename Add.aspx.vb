Imports System.Data.SqlClient
Partial Class Add
    Inherits System.Web.UI.Page

    Protected Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click

        Dim description As String = DescriptionTextBox.Text
        Dim price As Decimal = Decimal.Parse(PriceTextBox.Text)
        Dim unit As String = UnitMeasure.Text
        Dim qty As Integer = Integer.Parse(QtyTextBox.Text)

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"

        Dim checkQuery As String = "SELECT COUNT(*) FROM Inventory WHERE LOWER([Description]) = LOWER(@Description)"
        Dim insertQuery As String = "INSERT INTO Inventory ([Description], [Price], [Unit_of_Measure], [Quantity]) VALUES (@Description, @Price, @Measure, @Quantity)"
        Dim updateQuery As String = "UPDATE Inventory SET [Quantity] = [Quantity] + @Quantity WHERE LOWER([Description]) = LOWER(@Description)"

        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand()
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@Description", description)
        cmd.Parameters.AddWithValue("@Price", price)
        cmd.Parameters.AddWithValue("@Measure", unit)
        cmd.Parameters.AddWithValue("@Quantity", qty)

        Try
            con.Open()
            cmd.CommandText = checkQuery
            Dim itemExists As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If itemExists > 0 Then

                cmd.CommandText = updateQuery
                cmd.ExecuteNonQuery()
                Label1.Text = "Quantity updated for existing item."
            Else

                cmd.CommandText = insertQuery
                cmd.ExecuteNonQuery()
                Label1.Text = "New item inserted."
            End If

        Catch ex As Exception
            Label1.Text = ex.Message
        Finally
            con.Close()
        End Try

    End Sub

End Class
