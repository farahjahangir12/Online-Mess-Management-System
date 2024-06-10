Imports System.Data.SqlClient

Partial Class Inventory
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateInventoryDropdown()
        End If
    End Sub

    Private Sub PopulateInventoryDropdown()

        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)

        Dim query As String = "SELECT [Description] FROM Inventory"
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader


        Try
            con.Open()
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim newItem As New ListItem()


                newItem.Text = reader("description")

                inventoryDropDown.Items.Add(newItem)
            End While
            reader.Close()

        Catch er As Exception
            Label1.Text = er.Message
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim index As String = inventoryDropDown.SelectedItem.Text
        Dim selected As Integer = inventoryDropDown.SelectedIndex
        If selected = 0 Then
            Label1.Text = "Please select a product"

        Else
            details.Visible = True

            Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
            Dim con As New SqlConnection(connectionString)


            Dim query As String = "SELECT [Price], [Unit_of_Measure],[Quantity] FROM Inventory "
            query &= "WHERE [Description] = @Description"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Description", index)

            Dim reader As SqlDataReader


            Try
                con.Open()
                reader = cmd.ExecuteReader()

                While reader.Read()

                    Price.Text = " Price: " & "$" & reader("Price").ToString()

                    Measure.Text = "Unit Of Measure: " & reader("Unit_of_Measure").ToString()
                    Quantity.Text = "Quantity: " & reader("Quantity").ToString()


                End While
                reader.Close()

            Catch er As Exception
                Label1.Text = "Error while opening connection"
            Finally
                con.Close()
            End Try

        End If
    End Sub

End Class