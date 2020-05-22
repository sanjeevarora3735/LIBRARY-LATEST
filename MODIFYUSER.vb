Imports System.Data.SqlClient

Public Class MODIFYUSER
    Private Sub MODIFYUSER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Try

            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("Update LLOGIN SET PASSWORD = '" + TextBox2.Text + "'WHERE USERNAME= '" + ComboBox1.Text + "'", con)
            con.Open()

            cmd.ExecuteNonQuery()
            MsgBox("8")
            con.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        TextBox2.Clear()

    End Sub
End Class