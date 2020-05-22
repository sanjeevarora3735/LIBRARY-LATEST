Imports System.Data.SqlClient

Public Class REMOVEUSER

    Private Sub REMOVEUSER_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'TODO: This line of code loads data into the 'LIBRARYDataSet.LLOGIN' table. You can move, or remove it, as needed.

        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM LLOGIN", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "USERNAME"
        ComboBox1.ValueMember = "PASSWORD"



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("DELETE FROM LLOGIN WHERE USERNAME='" + ComboBox1.Text + "'", con)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Dispose()


    End Sub
End Class