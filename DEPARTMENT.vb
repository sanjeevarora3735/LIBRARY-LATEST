Imports System.Data.SqlClient

Public Class DEPARTMENT
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM DEPARTMENT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "DID"
        ComboBox1.ValueMember = "DID"

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("DELETE FROM DEPARTMENT WHERE DID='" + ComboBox1.Text + "'", con)
        con.Open()
        cmd.ExecuteNonQuery()
        MsgBox("DONE")

        ComboBox1.Text = ""
        TextBox3.Text = ""
        Button1.PerformClick()
        con.Dispose()

    End Sub

    Private Sub DEPARTMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM DEPARTMENT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "DID"
        ComboBox1.ValueMember = "DID"
        Button3.PerformClick()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("INSERT INTO DEPARTMENT (DID,DEPARTMENT) VALUES (@DID,@DEPARTMENT)", con)
            cmd.Parameters.Add("@DID", SqlDbType.VarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@DEPARTMENT", SqlDbType.VarChar).Value = TextBox2.Text
            Dim adapter As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable()
            adapter.Fill(tbl)
            If tbl.Rows.Count() <= 0 Then
                MsgBox("DONE")
                TextBox1.Clear()
                Button1.PerformClick()



            Else
                'DO NOTHING
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM DEPARTMENT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "DID"
        ComboBox1.ValueMember = "DID"

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim CON As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT DEPARTMENT FROM DEPARTMENT where did=@DID", CON)
        CON.Open()

        cmd.Parameters.AddWithValue("@DID", SqlDbType.NVarChar).Value = ComboBox1.Text
        Dim DA As SqlDataReader = cmd.ExecuteReader
        While (DA.Read())
            TextBox3.Text = DA.GetValue(0).ToString()

        End While

        CON.Close()

    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM DEPARTMENT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "DID"
        ComboBox1.ValueMember = "DID"
    End Sub
End Class