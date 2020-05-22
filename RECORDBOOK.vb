Imports System.Data.SqlClient

Public Class RECORDBOOK
    Private Sub RECORDBOOK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

        DataGridView1.EditMode = DataGridView1.EditMode.EditProgrammatically

        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT * FROM ADDBOOK ", con)

            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            DataGridView1.DataSource = tbl
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

End Class