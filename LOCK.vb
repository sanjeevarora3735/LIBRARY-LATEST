Imports System.Data.SqlClient

Public Class LOCK
    Dim l As Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("select * from LLOGIN where username=@username and password=@password", con)
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBox1.Text
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBox2.Text
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)
        If tbl.Rows.Count() <= 0 Then
            MsgBox("The username or password you enterd are invalid")
        Else
            Me.Hide()
            TRANSPARENT.Hide()
            l = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub LOCK_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If l = True Then
            Dim a As DialogResult
            a = MessageBox.Show(" Are You Want To Sure To Exit The Application", "Warning", MessageBoxButtons.YesNo)
            If a = DialogResult.Yes Then
                Application.ExitThread()
            ElseIf a = DialogResult.No Then
                e.Cancel = True
            End If
        Else
            Me.Hide()

        End If

    End Sub



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        ADDUSER.ShowDialog()

    End Sub

    Private Sub LOCK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        l = True

    End Sub
End Class