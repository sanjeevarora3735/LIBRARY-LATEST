﻿Imports System.Data.SqlClient

Public Class Staffissue
    Private Sub Staffissue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.PerformClick()
    End Sub
    Private Sub ComboBox1_enter(sender As Object, e As EventArgs) Handles ComboBox1.Enter
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT Name_Of_Staff FROM staff", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "Name_Of_Staff"
        ComboBox1.ValueMember = "Name_Of_Staff"
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.Enter
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT staff_id FROM staff", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox2.DataSource = table
        ComboBox2.DisplayMember = "staff_id"
        ComboBox2.ValueMember = "staff_id"
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader.AllCells
        DataGridView1.EditMode = DataGridView1.EditMode.EditProgrammatically

        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT [TRANSACTION_ID],[ISSUE],[RETURN_DATE],[STAFF_ID],[STAFF_NAME],[DEPARTMENT],[ACCESSION_NO],[BOOK_TITLE],[AUTHOR],[EDITION],[ISSUE_FOR],[STATUS] FROM staffissue ", con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            DataGridView1.DataSource = tbl
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader.AllCells
        DataGridView1.EditMode = DataGridView1.EditMode.EditProgrammatically
        If ComboBox1.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT [TRANSACTION_ID],[ISSUE],[RETURN_DATE],[STAFF_ID],[STAFF_NAME],[DEPARTMENT],[ACCESSION_NO],[BOOK_TITLE],[AUTHOR],[EDITION],[ISSUE_FOR],[STATUS] FROM staffissue  where STAFF_Name = @name", con)
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = ComboBox1.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView1.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        ElseIf ComboBox2.Text <> "" Then
            Try
                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("SELECT [TRANSACTION_ID],[ISSUE],[RETURN_DATE],[STAFF_ID],[STAFF_NAME],[DEPARTMENT],[ACCESSION_NO],[BOOK_TITLE],[AUTHOR],[EDITION],[ISSUE_FOR],[STATUS] FROM staffissue  where STAFF_ID = @id", con)
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = ComboBox2.Text
                Dim adapter As New SqlDataAdapter(cmd)
                Dim tbl As New DataTable()
                adapter.Fill(tbl)
                DataGridView1.DataSource = tbl
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" Then

            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT [TRANSACTION_ID],[ISSUE],[RETURN_DATE],[STAFF_ID],[STAFF_NAME],[DEPARTMENT],[ACCESSION_NO],[BOOK_TITLE],[AUTHOR],[EDITION],[ISSUE_FOR],[STATUS] FROM staffissue  where STAFF_ID = @id", con)
            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = ComboBox2.Text
            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            DataGridView1.DataSource = tbl

        Else

        End If
        MsgBox("STAFF ID IS TAKEN AS SEARCH CRITERIA ", MsgBoxStyle.Information)

    End Sub
End Class