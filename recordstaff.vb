Imports System.Data.SqlClient

Public Class recordstaff
    Private Sub recordstaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'LIBRARYDataSet.STAFF' table. You can move, or remove it, as needed.
        Me.STAFFTableAdapter.Fill(Me.LIBRARYDataSet.STAFF)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView1.EditMode = DataGridView1.EditMode.EditProgrammatically

        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT [STAFF_ID],[NAME_OF_STAFF],[GENDER],[FATHER_NAME],[DEPARTMENT],[DATE_OF_JOINING],[DOB],[MOBILE_NUMBER],[E_MAIL],[ADDRESS] FROM STAFF ", con)

            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            DataGridView1.DataSource = tbl
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub
End Class