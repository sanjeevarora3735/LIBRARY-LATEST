Imports System.Data.SqlClient

Public Class YEAR
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("INSERT INTO YEAR (YEAR) VALUES (@YEAR)", con)
            cmd.Parameters.Add("@YEAR", SqlDbType.VarChar).Value = TextBox1.Text
            con.Open()
            cmd.ExecuteNonQuery()
            con.Dispose()

            MsgBox("DONE!!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub
End Class