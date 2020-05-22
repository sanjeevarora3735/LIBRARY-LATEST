Imports System.Data.SqlClient

Public Class COURSE


    Private Sub COURSE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM COURSE", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "COURSE"
        ComboBox1.ValueMember = "COURSE"
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("DELETE FROM COURSE WHERE COURSE='" + ComboBox1.Text + "'", con)
        con.Open()
        cmd.ExecuteNonQuery()
        MsgBox("DONE")
        Button3.PerformClick()
        con.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("INSERT INTO COURSE (COURSE) VALUES (@COURSE)", con)
            cmd.Parameters.Add("@COURSE", SqlDbType.VarChar).Value = TextBox1.Text

            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            If tbl.Rows.Count() <= 0 Then
                MsgBox("DONE")
                TextBox1.Clear()
                Button3.PerformClick()



            Else
                'DO NOTHING
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM COURSE", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "COURSE"
        ComboBox1.ValueMember = "COURSE"
    End Sub
End Class