Imports System.Data.SqlClient

Partial Class MarkMess
    Inherits System.Web.UI.Page

    Private Sub Show_Click(sender As Object, e As EventArgs) Handles Show.Click
        Dim menutype As String = DropDownList1.SelectedItem.Text
        Dim currentdate As DateTime = DateTime.Today
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)

        Dim query As String = "SELECT [Description],[Price],[MenuItemId] FROM MenuItem WHERE [MenuItemId] IN"
        query &= "(SELECT [MenuItemId] FROM Contains_T WHERE [MenuId] IN"
        query &= "(SELECT [MenuId] FROM Menu WHERE [Type]=@menutype AND [Date]=@currentdate))
                   AND [Serving] > 0"

        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@menutype", menutype)
        cmd.Parameters.AddWithValue("@currentdate", currentdate)
        Dim reader As SqlDataReader

        Try
            con.Open()
            reader = cmd.ExecuteReader
            While reader.Read
                Dim newItem As New ListItem
                newItem.Text = reader("Description")
                newItem.Value = reader("MenuItemId")
                ItemsList.Items.Add(newItem)
            End While
        Catch ex As Exception
            Label1.Text = ex.Message
        Finally
            con.Close()
        End Try

        Panel2.Visible = True
    End Sub

    Private Sub Confirm_Click(sender As Object, e As EventArgs) Handles Confirm.Click
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)
        Dim userId As Integer = GetCurrentUserId()
        Dim currentdate As Date = Date.Today

        Try
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()

            Dim insertOrderQuery As String = "INSERT INTO Orders (Date, UserId) OUTPUT INSERTED.OrderId VALUES (@OrderDate, @UserId)"
            Dim insertOrderCmd As New SqlCommand(insertOrderQuery, con, transaction)
            insertOrderCmd.Parameters.AddWithValue("@OrderDate", currentdate)
            insertOrderCmd.Parameters.AddWithValue("@UserId", userId)
            Dim orderId As Integer = Convert.ToInt32(insertOrderCmd.ExecuteScalar())


            For Each item As ListItem In ItemsList.Items
                If item.Selected Then
                    Dim menuItemId As Integer = Convert.ToInt32(item.Value)

                    Dim servingQuery As String = "UPDATE MenuItem SET Serving = Serving - 1 WHERE MenuItemId = @MenuItemId"
                    Dim servingCmd As New SqlCommand(servingQuery, con, transaction)
                    servingCmd.Parameters.AddWithValue("@MenuItemId", menuItemId)
                    servingCmd.ExecuteNonQuery()

                    Dim insertOrderLine As String = "INSERT INTO Orderline (Quantity, OrderId, MenuItemId) VALUES (1, @OrderId, @MenuItemId)"
                    Dim insertOrderLineCmd As New SqlCommand(insertOrderLine, con, transaction)
                    insertOrderLineCmd.Parameters.AddWithValue("@OrderId", orderId)
                    insertOrderLineCmd.Parameters.AddWithValue("@MenuItemId", menuItemId)
                    insertOrderLineCmd.ExecuteNonQuery()
                End If
            Next

            transaction.Commit()
            Label1.Text = "Mess Marked successfully!"
        Catch ex As Exception
            Label1.Text = "Error: " & ex.Message
        Finally
            con.Close()
        End Try
    End Sub

    Private Function GetCurrentUserId() As Integer
        Dim userId As Integer = 0
        If Session("UID") IsNot Nothing Then
            userId = Convert.ToInt32(Session("UID"))
        End If
        Return userId
    End Function

End Class
