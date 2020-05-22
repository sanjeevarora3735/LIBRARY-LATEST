Imports System.Data.SqlClient

Public Class ADDUSER
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("INSERT INTO LLOGIN (USERNAME,PASSWORD) VALUES (@username,@password)", con)
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBox2.Text
            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            If tbl.Rows.Count() <= 0 Then
                MsgBox("DONE")
                TextBox1.Clear()
                TextBox2.Clear()
                Me.Hide()

            Else
                'DO NOTHING
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

End Class