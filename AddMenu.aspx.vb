Imports System.Data.SqlClient

Partial Class AddMenu
    Inherits System.Web.UI.Page

    Private Sub Show_Click(sender As Object, e As EventArgs) Handles Show.Click
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)

        Dim query As String = "SELECT DISTINCT [Description], [MenuItemId] FROM MenuItem"
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader

        Try
            con.Open()
            reader = cmd.ExecuteReader()

            ItemsList.Items.Clear()
            While reader.Read()
                Dim newItem As New ListItem()
                newItem.Text = reader("Description")
                newItem.Value = reader("MenuItemId")
                ItemsList.Items.Add(newItem)
            End While
            reader.Close()
        Catch er As Exception
            Label1.Text = er.Message
        Finally
            con.Close()
        End Try

        Panel2.Enabled = True
        Show.Enabled = False
    End Sub

    Private Sub Confirm_Click(sender As Object, e As EventArgs) Handles Confirm.Click
        Panel2.Enabled = False
        Panel3.Enabled = True

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)

        Dim query As String = "SELECT [Description], [ItemId] FROM Inventory"
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader

        Try
            con.Open()
            reader = cmd.ExecuteReader()

            DropDownList2.Items.Clear()
            DropDownList2.Items.Add(New ListItem("Select Item", "0"))
            While reader.Read()
                Dim newItem As New ListItem()
                newItem.Text = reader("Description")
                newItem.Value = reader("ItemId")
                DropDownList2.Items.Add(newItem)
            End While
            reader.Close()
        Catch er As Exception
            Label1.Text = er.Message
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ShowInventory_Click(sender As Object, e As EventArgs) Handles ShowInventory.Click
        If DropDownList2.SelectedIndex > 0 Then
            Panel3.Enabled = False
            Panel4.Enabled = True
        Else
            Label1.Text = "Please select an inventory item."
        End If
    End Sub

    Private Sub ConfirmItem_Click(sender As Object, e As EventArgs) Handles ConfirmItem.Click
        Dim menuType As String = DropDownList1.SelectedItem.Text
        Dim currentDate As DateTime = DateTime.Today
        Dim ItemId As Integer = Convert.ToInt32(DropDownList2.SelectedValue)
        Dim enteredQ As Integer = Convert.ToInt32(ItemQuantity.Text)

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)

        Dim CheckQuantity As String = "SELECT SUM(UsedQuantity) AS Used, (SELECT SUM(Quantity) FROM Inventory WHERE ItemId = @itemId) AS Available FROM Uses WHERE ItemId = @itemId"
        Dim cmdCheckQuantity As New SqlCommand(CheckQuantity, con)
        cmdCheckQuantity.Parameters.AddWithValue("@itemId", ItemId)

        Try
            con.Open()
            Dim reader As SqlDataReader = cmdCheckQuantity.ExecuteReader()
            Dim availableQ As Integer = 0
            Dim totalUsed As Integer = 0

            If reader.Read() Then
                totalUsed = If(IsDBNull(reader("Used")), 0, Convert.ToInt32(reader("Used")))
                availableQ = If(IsDBNull(reader("Available")), 0, Convert.ToInt32(reader("Available")))
            End If
            reader.Close()

            If enteredQ > (availableQ - totalUsed) Then
                Label1.Text = "Entered quantity greater than available"
                Panel4.Enabled = True
            Else

                Dim updateInventory As String = "UPDATE Inventory SET Quantity = Quantity - @usedQuantity WHERE ItemId = @itemId"
                Dim cmdUpdateInventory As New SqlCommand(updateInventory, con)
                cmdUpdateInventory.Parameters.AddWithValue("@usedQuantity", enteredQ)
                cmdUpdateInventory.Parameters.AddWithValue("@itemId", ItemId)
                cmdUpdateInventory.ExecuteNonQuery()


                Dim queryInsertMenu As String = "INSERT INTO Menu ([Type], [Date]) OUTPUT INSERTED.MenuId VALUES (@menuType, @date)"
                Dim cmdInsertMenu As New SqlCommand(queryInsertMenu, con)
                cmdInsertMenu.Parameters.AddWithValue("@menuType", menuType)
                cmdInsertMenu.Parameters.AddWithValue("@date", currentDate)

                Dim menuId As Integer = Convert.ToInt32(cmdInsertMenu.ExecuteScalar())


                Dim menuItemIds As New List(Of Integer)
                For Each item As ListItem In ItemsList.Items
                    If item.Selected Then
                        menuItemIds.Add(Convert.ToInt32(item.Value))
                    End If
                Next

                For Each menuItemId As Integer In menuItemIds
                    Dim queryInsertContains As String = "INSERT INTO Contains_T (MenuId, MenuItemId) VALUES (@menuId, @menuItemId)"
                    Dim cmdInsertContains As New SqlCommand(queryInsertContains, con)
                    cmdInsertContains.Parameters.AddWithValue("@menuId", menuId)
                    cmdInsertContains.Parameters.AddWithValue("@menuItemId", menuItemId)
                    cmdInsertContains.ExecuteNonQuery()

                    Dim queryInsertUses As String = "INSERT INTO Uses (UsedQuantity, ItemId, MenuItemId) VALUES (@usedQuantity, @itemId, @menuItemId)"
                    Dim cmdInsertUses As New SqlCommand(queryInsertUses, con)
                    cmdInsertUses.Parameters.AddWithValue("@usedQuantity", enteredQ)
                    cmdInsertUses.Parameters.AddWithValue("@itemId", ItemId)
                    cmdInsertUses.Parameters.AddWithValue("@menuItemId", menuItemId)
                    cmdInsertUses.ExecuteNonQuery()
                Next

                Label1.Text = "Menu and items added successfully."
                Panel4.Enabled = False
                ItemsList.Items.Clear()
                DropDownList2.Items.Clear()
                DropDownList1.ClearSelection()
            End If
        Catch ex As Exception
            Label1.Text = ex.Message
        Finally
            con.Close()
        End Try
    End Sub
End Class
