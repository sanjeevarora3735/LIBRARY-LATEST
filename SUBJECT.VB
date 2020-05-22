Imports System.Data.SqlClient

Public Class SUBJECT
    Private Sub SUBJECT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM SUBJECT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "SUBJECT"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM SUBJECT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "SUBJECT"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("INSERT INTO SUBJECT (SUBJECT) VALUES (@SUBJECT)", con)
            cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar).Value = TextBox1.Text

            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            If tbl.Rows.Count() <= 0 Then
                MsgBox("DONE")
                Button1.PerformClick()

                TextBox1.Clear()
                

            Else
                'DO NOTHING
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("DELETE FROM SUBJECT WHERE SUBJECT='" + ComboBox1.Text + "'", con)
        con.Open()
        cmd.ExecuteNonQuery()
        MsgBox("DONE")
        Button1.PerformClick()

        con.Dispose()


    End Sub


End Class