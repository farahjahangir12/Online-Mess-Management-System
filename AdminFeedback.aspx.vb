Imports System.Data.SqlClient

Partial Class AdminFeedback
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DisplayFeedback()
        End If
    End Sub

    Private Sub DisplayFeedback()
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"

        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT FeedbackID, MenuType, UserName, FeedbackText, Rating FROM FeedbackView"

            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    FeedbackTable.Rows.Clear()
                    Dim headerRow As New TableHeaderRow()
                    Dim headerCell1 As New TableHeaderCell()
                    headerCell1.Text = "Feedback ID"
                    headerCell1.CssClass = "count"
                    headerRow.Cells.Add(headerCell1)

                    Dim headerCell2 As New TableHeaderCell()
                    headerCell2.Text = "Menu Type"
                    headerCell2.CssClass = "qcell"
                    headerRow.Cells.Add(headerCell2)

                    Dim headerCell3 As New TableHeaderCell()
                    headerCell3.Text = "User Name"
                    headerCell3.CssClass = "optcell"
                    headerRow.Cells.Add(headerCell3)

                    Dim headerCell4 As New TableHeaderCell()
                    headerCell4.Text = "Feedback Text"
                    headerCell4.CssClass = "correctcell"
                    headerRow.Cells.Add(headerCell4)

                    Dim headerCell5 As New TableHeaderCell()
                    headerCell5.Text = "Rating"
                    headerCell5.CssClass = "correctcell"
                    headerRow.Cells.Add(headerCell5)

                    FeedbackTable.Rows.Add(headerRow)

                    If reader.HasRows Then
                        While reader.Read()
                            Dim row As New TableRow()
                            Dim cell1 As New TableCell()
                            cell1.Text = reader("FeedbackID").ToString()
                            cell1.CssClass = "count"
                            row.Cells.Add(cell1)

                            Dim cell2 As New TableCell()
                            cell2.Text = reader("MenuType").ToString()
                            cell2.CssClass = "qcell"
                            row.Cells.Add(cell2)

                            Dim cell3 As New TableCell()
                            cell3.Text = reader("UserName").ToString()
                            cell3.CssClass = "optcell"
                            row.Cells.Add(cell3)

                            Dim cell4 As New TableCell()
                            cell4.Text = reader("FeedbackText").ToString()
                            cell4.CssClass = "correctcell"
                            row.Cells.Add(cell4)

                            Dim cell5 As New TableCell()
                            cell5.Text = reader("Rating").ToString()
                            cell5.CssClass = "correctcell"
                            row.Cells.Add(cell5)

                            FeedbackTable.Rows.Add(row)
                        End While
                    Else
                        Dim msgrow As New TableRow()
                        Dim msgcell As New TableCell()
                        msgcell.ColumnSpan = 5
                        msgcell.Text = "No feedback records found."
                        msgrow.Cells.Add(msgcell)
                        FeedbackTable.Rows.Add(msgrow)
                    End If
                Catch ex As Exception
                    Label1.Text = "An error occurred while retrieving the feedback"
                End Try
            End Using
        End Using
    End Sub
End Class