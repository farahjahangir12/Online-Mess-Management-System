Imports System.Data.SqlClient

Partial Class StudentDetails
    Inherits System.Web.UI.Page

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Details.Visible = True

        Dim id As Integer
        If Integer.TryParse(Sname.Text, id) Then
            Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
            Using con As New SqlConnection(connectionString)
                Dim query As String = "SELECT U.UserId, U.Name, S.Semester, S.Room_No, SUM(D.ItemTotal) AS Dues 
                                       FROM [User] U 
                                       INNER JOIN Student S ON U.UserId = S.UserId
                                       INNER JOIN MessBillView D ON S.UserId = D.UserId
                                       WHERE S.UserId = @id
                                       GROUP BY U.UserId, U.Name, S.Semester, S.Room_No"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id", id)
                    Try
                        con.Open()
                        Dim reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                                Dim lbl1 As New Label
                            lbl1.Text = reader("Name").ToString()

                            Dim lbl2 As New Label
                                lbl2.Text = reader("Semester").ToString()

                                Dim lbl3 As New Label
                                lbl3.Text = reader("Room_No").ToString()

                                Dim lbl4 As New Label
                            lbl4.Text = reader("Dues").ToString()

                            Dim rows As New TableRow()
                                Dim cell1 As New TableCell()
                                cell1.Controls.Add(lbl1)

                                Dim cell2 As New TableCell()
                                cell2.Controls.Add(lbl2)

                                Dim cell3 As New TableCell()
                                cell3.Controls.Add(lbl3)

                                Dim cell4 As New TableCell()
                                cell4.Controls.Add(lbl4)

                                rows.Controls.Add(cell1)
                                rows.Controls.Add(cell2)
                                rows.Controls.Add(cell3)
                                rows.Controls.Add(cell4)

                                qtable.Controls.Add(rows)

                                rows.CssClass = "qrow"
                                cell1.CssClass = "count"
                                cell2.CssClass = "qcell"
                                cell3.CssClass = "optcell"
                                cell4.CssClass = "correctcell"
                            End While

                    Catch ex As Exception
                        Label2.Text = ex.Message
                    End Try
                End Using
            End Using
        Else
            Label2.Text = "Invalid Id Format"
            Sname.Text = ""
        End If
    End Sub

    Private Sub StudentDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            qtable.Controls.Clear()
            Sname.Text = ""
            Details.Visible = False
        End If
    End Sub
End Class
