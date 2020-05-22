Imports System.Data.SqlClient

Public Class recordbooksearch
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        ComboBox1.ResetText()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ComboBox1.Text = "" And TextBox1.Text = "" Then
            MsgBox("Enter the Blank field")
        ElseIf ComboBox1.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT * FROM ADDBOOK WHERE Book_Title=@book", con)
                cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = ComboBox1.Text
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
                Dim cmd As New SqlCommand("SELECT * FROM ADDBOOK WHERE Book_Title=@book", con)
                cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = TextBox1.Text
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

    Private Sub recordbooksearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.EditMode = DataGridView1.EditMode.EditProgrammatically
        DataGridView2.EditMode = DataGridView1.EditMode.EditProgrammatically
        DataGridView3.EditMode = DataGridView1.EditMode.EditProgrammatically
        DataGridView4.EditMode = DataGridView1.EditMode.EditProgrammatically
        DataGridView5.EditMode = DataGridView1.EditMode.EditProgrammatically



        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT book_title FROM addbook", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "book_title"
        ComboBox1.ValueMember = "book_title"

        Dim cmd1 As New SqlCommand("SELECT * FROM Author", con)
        Dim adapter1 As New SqlDataAdapter(cmd1)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)
        ComboBox2.DataSource = table1
        ComboBox2.DisplayMember = "Author"
        ComboBox2.ValueMember = "Author"

        Dim cmd2 As New SqlCommand("SELECT * FROM DEPARTMENT", con)
        Dim adapter2 As New SqlDataAdapter(cmd2)
        Dim table2 As New DataTable()
        adapter2.Fill(table2)
        ComboBox3.DataSource = table2
        ComboBox3.DisplayMember = "DEPARTMENT"
        ComboBox3.ValueMember = "DEPARTMENT"

        Dim cmd3 As New SqlCommand("SELECT * FROM subject", con)
        Dim adapter3 As New SqlDataAdapter(cmd3)
        Dim table3 As New DataTable()
        adapter3.Fill(table3)
        ComboBox4.DataSource = table3
        ComboBox4.DisplayMember = "subject"
        ComboBox4.ValueMember = "subject"

        Dim cmd4 As New SqlCommand("SELECT accession_no  FROM ADDBOOK", con)
        Dim adapter4 As New SqlDataAdapter(cmd4)
        Dim table4 As New DataTable()
        adapter4.Fill(table4)
        ComboBox5.DataSource = table4
        ComboBox5.DisplayMember = "accession_no"
        ComboBox5.ValueMember = "accession_no"


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ComboBox2.Text = "" And TextBox2.Text = "" Then
            MsgBox("Enter the Blank field")
        ElseIf TextBox2.Text = "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT * FROM ADDBOOK WHERE Author=@Author", con)
                cmd.Parameters.Add("@Author", SqlDbType.VarChar).Value = ComboBox2.Text
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
                Dim cmd As New SqlCommand("SELECT * FROM ADDBOOK WHERE Author=@Author", con)
                cmd.Parameters.Add("@Author", SqlDbType.VarChar).Value = TextBox2.Text
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




    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If ComboBox3.Text = "" And TextBox3.Text = "" Then
            MsgBox("Enter the Blank field")
        ElseIf ComboBox3.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT * FROM addbook WHERE department=@book", con)
                cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = ComboBox3.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView3.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        ElseIf TextBox3.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT * FROM addbook WHERE department=@book", con)
                cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = TextBox3.Text
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If ComboBox4.Text = "" And TextBox4.Text = "" Then
            MsgBox("Enter the Blank field")
        ElseIf ComboBox4.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT * FROM addbook WHERE subject=@book", con)
                cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = ComboBox4.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView4.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        ElseIf TextBox4.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT * FROM addbook WHERE subject=@book", con)
                cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = TextBox4.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView4.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
        If TextBox4.Text <> "" And ComboBox4.Text <> "" Then
            Dim a As String
            a = TextBox4.Text
            MsgBox(a.ToString() + " is used as search criteria")

        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        If ComboBox5.Text = "" And TextBox5.Text = "" Then
            MsgBox("Enter the Blank field")
        ElseIf ComboBox5.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT * FROM addbook WHERE accession_no=@book", con)
                cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = ComboBox5.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView5.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        ElseIf TextBox5.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT * FROM addbook WHERE accession_no=@book", con)
                cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = TextBox5.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView5.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
        If TextBox5.Text <> "" And ComboBox5.Text <> "" Then
            Dim a As String
            a = TextBox5.Text
            MsgBox(a.ToString() + " is used as search criteria")

        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox4.Clear()
        ComboBox5.ResetText()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox3.Clear()
        ComboBox4.ResetText()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox3.Clear()
        ComboBox3.ResetText()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox2.Clear()
        ComboBox2.ResetText()
    End Sub

End Class