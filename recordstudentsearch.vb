Imports System.Data.SqlClient

Public Class recordstudentsearch
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells.DisplayedCells
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically


        If ComboBox1.Text = "" And TextBox1.Text = "" Then
            MsgBox("Enter the Blank field")
        ElseIf ComboBox1.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT [STUDENT_ID],[NAME_OF_STUDENT],[GENDER],[FATHER_NAME],[DEPARTMENT],[COURSE],[YEAR],[DOB],[MOBILE_NUMBER],[E_MAIL],[ADDRESS]  FROM STUDENT WHERE Name_of_student=@name", con)
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = ComboBox1.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView1.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        ElseIf TextBox1.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT [STUDENT_ID],[NAME_OF_STUDENT],[GENDER],[FATHER_NAME],[DEPARTMENT],[COURSE],[YEAR],[DOB],[MOBILE_NUMBER],[E_MAIL],[ADDRESS]  FROM STUDENT WHERE Name_of_student=@name", con)
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView1.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
        If TextBox1.Text <> "" And ComboBox1.Text <> "" Then
            Dim a As String
            a = TextBox1.Text
            MsgBox(a.ToString() + " is used as search criteria")

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells.Fill
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically


        If ComboBox2.Text = "" And TextBox2.Text = "" Then
            MsgBox("Enter the Blank field")
        ElseIf ComboBox2.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT [STUDENT_ID],[NAME_OF_STUDENT],[GENDER],[FATHER_NAME],[DEPARTMENT],[COURSE],[YEAR],[DOB],[MOBILE_NUMBER],[E_MAIL],[ADDRESS]  FROM STUDENT WHERE STUDENT_ID=@id", con)
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = ComboBox2.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView2.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        ElseIf TextBox2.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT [STUDENT_ID],[NAME_OF_STUDENT],[GENDER],[FATHER_NAME],[DEPARTMENT],[COURSE],[YEAR],[DOB],[MOBILE_NUMBER],[E_MAIL],[ADDRESS]  FROM STUDENT WHERE STUDENT_ID=@id", con)
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox2.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView2.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
        If TextBox2.Text <> "" And ComboBox2.Text <> "" Then
            Dim a As String
            a = TextBox2.Text
            MsgBox(a.ToString() + " is used as search criteria")

        End If
    End Sub

    Private Sub recordstudentsearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT Name_of_student FROM student", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "Name_of_student"
        ComboBox1.ValueMember = "Name_of_student"


        Dim cmd1 As New SqlCommand("SELECT student_id FROM student", con)
        Dim adapter1 As New SqlDataAdapter(cmd1)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)
        ComboBox2.DataSource = table1
        ComboBox2.DisplayMember = "student_id"
        ComboBox2.ValueMember = "student_id"
        Dim cmd2 As New SqlCommand("SELECT department FROM department", con)
        Dim adapter2 As New SqlDataAdapter(cmd2)
        Dim table2 As New DataTable()
        adapter2.Fill(table2)
        ComboBox3.DataSource = table2
        ComboBox3.DisplayMember = "department"
        ComboBox3.ValueMember = "department"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells.Fill
        DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically


        If ComboBox3.Text = "" And TextBox3.Text = "" Then
            MsgBox("Enter the Blank field")
        ElseIf ComboBox3.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT [STUDENT_ID],[NAME_OF_STUDENT],[GENDER],[FATHER_NAME],[DEPARTMENT],[COURSE],[YEAR],[DOB],[MOBILE_NUMBER],[E_MAIL],[ADDRESS]  FROM STUDENT WHERE department=@id", con)
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = ComboBox3.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView2.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        ElseIf TextBox3.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT [STUDENT_ID],[NAME_OF_STUDENT],[GENDER],[FATHER_NAME],[DEPARTMENT],[COURSE],[YEAR],[DOB],[MOBILE_NUMBER],[E_MAIL],[ADDRESS]  FROM STUDENT WHERE DEPARTMENT=@id", con)
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox3.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView3.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
        If TextBox3.Text <> "" And ComboBox3.Text <> "" Then
            Dim a As String
            a = TextBox3.Text
            MsgBox(a.ToString() + " is used as search criteria")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComboBox1.ResetText()
        TextBox1.Clear()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ComboBox2.ResetText()
        TextBox2.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ComboBox3.ResetText()
        TextBox3.Clear()
    End Sub
End Class