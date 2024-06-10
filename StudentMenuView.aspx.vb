
Imports System.Data.SqlClient

Partial Class StudentMenuView
    Inherits System.Web.UI.Page

    Private Sub StudentMenuView_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)

        Try
            con.Open()
            PopulatePanel(con, "Breakfast", Breakfast)
            PopulatePanel(con, "Lunch", Lunch)
            PopulatePanel(con, "Dinner", Dinner)
            PopulatePanel(con, "Other", Other)
        Catch ex As Exception
            Label1.Text = ex.Message
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub PopulatePanel(con As SqlConnection, menuType As String, panel As Panel)
        Dim query1 As String = "SELECT * FROM MenuItem WHERE [MenuItemId] IN"
        query1 &= "(SELECT [MenuItemId] FROM Contains_T WHERE [MenuId] IN"
        query1 &= "(SELECT [MenuId] FROM Menu WHERE [Type]=@menuType AND [Date]=@currentDate))"
        Dim cmd As New SqlCommand(query1, con)
        cmd.Parameters.AddWithValue("@menuType", menuType)
        cmd.Parameters.AddWithValue("@currentDate", DateTime.Today)

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        Dim table As New Table()
        panel.Controls.Add(table)
        table.CssClass = "menu-table"

        If reader.HasRows Then
            While reader.Read()
                Dim row As New TableRow()

                Dim cellId As New TableCell()
                cellId.Text = reader("MenuItemId").ToString()
                cellId.CssClass = "cells"
                row.Cells.Add(cellId)

                Dim cellDescription As New TableCell()
                cellDescription.CssClass = "cells"
                cellDescription.Text = reader("Description").ToString()
                row.Cells.Add(cellDescription)

                Dim cellPrice As New TableCell()
                cellPrice.CssClass = "cells"
                cellPrice.Text = reader("Price").ToString()
                row.Cells.Add(cellPrice)

                Dim cellServing As New TableCell()
                cellServing.Text = reader("Serving").ToString()
                cellServing.CssClass = "cells"
                row.Cells.Add(cellServing)

                table.Rows.Add(row)
            End While
        Else
            Dim row As New TableRow()
            Dim cell As New TableCell()
            cell.Text = "Nill"
            cell.ColumnSpan = 4
            cell.HorizontalAlign = HorizontalAlign.Center
            row.Cells.Add(cell)
            table.Rows.Add(row)
        End If

        reader.Close()
    End Sub
End Class
