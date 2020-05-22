Imports System.Data.SqlClient

Public Class BOOK
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("INSERT INTO Addbook (Accession_no,Book_Title,Author,Joint_Author,Part_Volume,Subject,Position,Department,CD,Publisher,Edition,DateofEntry,Total_Qty,Available_Qty,Remarks,Price) VALUES (@Accession_no,@Book_Title,@Author,@Joint_Author,@Part_Volume,@Subject,@Position,@Department,@CD,@Publisher,@Edition,@DateofEntry,@Total_Qty,@Available_qty,@Remarks,@Price)", con)
            cmd.Parameters.Add("@Accession_no", SqlDbType.NVarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@Book_Title  ", SqlDbType.NVarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = TextBox3.Text
            cmd.Parameters.Add("@Joint_Author", SqlDbType.NVarChar).Value = TextBox4.Text
            cmd.Parameters.Add("@Part_Volume", SqlDbType.NVarChar).Value = TextBox10.Text
            cmd.Parameters.Add("@Subject    ", SqlDbType.NVarChar).Value = ComboBox1.Text
            cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = TextBox8.Text
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = ComboBox2.Text
            cmd.Parameters.Add("@CD", SqlDbType.NVarChar).Value = ComboBox3.Text
            cmd.Parameters.Add("@Publisher", SqlDbType.NVarChar).Value = TextBox6.Text
            cmd.Parameters.Add("@Edition", SqlDbType.NVarChar).Value = TextBox7.Text
            cmd.Parameters.Add("@DateofEntry", SqlDbType.Date).Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@Total_Qty", SqlDbType.NVarChar).Value = TextBox5.Text
            cmd.Parameters.Add("@Available_qty", SqlDbType.NVarChar).Value = TextBox5.Text
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = RichTextBox1.Text
            cmd.Parameters.Add("@Price", SqlDbType.NVarChar).Value = TextBox12.Text
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Book Added Successfully")
            con.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("INSERT INTO author(Author) values (@Author)", con1)
            cmd1.Parameters.Add("@Author", SqlDbType.NVarChar).Value = TextBox3.Text
            con1.Open()
            cmd1.ExecuteNonQuery()
            con1.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub BOOK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Enabled = False

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.MouseClick
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM DEPARTMENT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox2.DataSource = table
        ComboBox2.DisplayMember = "department"
        ComboBox2.ValueMember = "department"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.MouseClick
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM SUBJECT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "SUBJECT"
        ComboBox1.ValueMember = "SUBJECT"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox10.Clear()
        RichTextBox1.Clear()
        ComboBox1.ResetText()
        ComboBox2.ResetText()
        ComboBox3.ResetText()

        TextBox12.Clear()


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class