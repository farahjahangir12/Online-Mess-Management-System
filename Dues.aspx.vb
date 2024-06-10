
Imports System.Data
Imports System.Data.SqlClient

Partial Class Dues
    Inherits System.Web.UI.Page

    Protected Sub Dues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadInvoice()
        End If
    End Sub

    Private Sub LoadInvoice()
        Dim userId As Integer = Convert.ToInt32(Session("UID"))
        Dim connectionString As String = "workstation id=MessMate.mssql.somee.com;packet size=4096;user id=farahj265_SQLLogin_1;pwd=vBc9D4q8GFNQSi9;data source=MessMate.mssql.somee.com;persist security info=False;initial catalog=MessMate;TrustServerCertificate=True"
        Dim query As String = "SELECT * FROM MessBillView WHERE UserId = @UserId"

        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@UserId", userId)
                Dim totalBill As Decimal = 0
        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(reader)
            InvoiceGridView.DataSource = dt
            InvoiceGridView.DataBind()

            For Each row As DataRow In dt.Rows
                totalBill += Convert.ToDecimal(row("ItemTotal"))
            Next

            Bill.Text = "Total Bill: Rs. " & totalBill.ToString
        Catch ex As Exception

            Bill.Text = "Error: " & ex.Message
                End Try

    End Sub

End Class
