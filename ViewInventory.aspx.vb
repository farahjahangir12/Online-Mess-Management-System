
Imports System.Data.SqlClient

Partial Class ViewInventory
    Inherits System.Web.UI.Page

    Private Sub ViewInventory_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim query As String = "SELECT * FROM Inventory"
        If id IsNot Nothing Then
            Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, con)
            Dim reader As SqlDataReader
            Try
                con.Open()
                reader = cmd.ExecuteReader
                While reader.Read
                    Dim lbl1 As New Label
                    Dim lbl2 As New Label
                    Dim lbl3 As New Label
                    Dim lbl4 As New Label
                    lbl1.Text = reader("ItemId")

                    Dim rows As New TableRow
                    Dim cell1 As New TableCell
                    cell1.Controls.Add(lbl1)
                    Dim cell2 As New TableCell
                    lbl2.Text = reader("Description").ToString
                    cell2.Controls.Add(lbl2)
                    Dim cell3 As New TableCell
                    lbl3.Text = reader("Price").ToString

                    cell3.Controls.Add(lbl3)
                    Dim cell4 As New TableCell
                    lbl4.Text = reader("Unit_of_Measure").ToString
                    cell4.Controls.Add(lbl4)
                    Dim cell5 As New TableCell
                    Dim lbl5 As New Label
                    lbl5.Text = reader("Quantity")
                    cell5.Controls.Add(lbl5)
                    rows.Controls.Add(cell1)
                    rows.Controls.Add(cell2)
                    rows.Controls.Add(cell3)
                    rows.Controls.Add(cell4)
                    rows.Controls.Add(cell5)
                    qtable.Controls.Add(rows)

                    rows.CssClass = "qrow"
                    cell1.CssClass = "count"
                    cell2.CssClass = "qcell"
                    cell3.CssClass = "optcell"
                    cell4.CssClass = "optcell"
                    cell5.CssClass = "correctcell"

                End While
            Catch ex As Exception
                Label1.Text = ex.Message
            Finally
                con.Close()
            End Try
        End If

    End Sub
End Class
