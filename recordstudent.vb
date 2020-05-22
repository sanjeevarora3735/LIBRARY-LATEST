Imports System.Data.SqlClient

Public Class recordstudent
    Private Sub recordstudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView1.EditMode = DataGridView1.EditMode.EditProgrammatically

        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT [STUDENT_ID],[NAME_OF_STUDENT],[GENDER],[FATHER_NAME],[DEPARTMENT],[COURSE],[YEAR],[DOB],[MOBILE_NUMBER],[E_MAIL],[ADDRESS] FROM student ", con)

            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            DataGridView1.DataSource = tbl
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class