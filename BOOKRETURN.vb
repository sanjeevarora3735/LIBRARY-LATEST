Imports System.Data.SqlClient

Public Class BOOKRETURN
    Private Sub BOOKRETURN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT Transaction_id FROM STAFFissue", con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            ComboBox2.DataSource = table
            ComboBox2.DisplayMember = "Transaction_id"
            ComboBox2.ValueMember = "Transaction_id"
        Catch EX As Exception
            MsgBox(EX.ToString)
        End Try
        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT Transaction_id FROM issue", con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            ComboBox1.DataSource = table
            ComboBox1.DisplayMember = "Transaction_id"
            ComboBox1.ValueMember = "Transaction_id"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim con1 As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd1 As New SqlCommand("SELECT [Issue],[Return_Date],[Student_id],[Student_Name],[Department],[Accession_no],[Book_Title],[Author],[Edition] FROM issue where Transaction_id=@ID", con1)
        con1.Open()
        cmd1.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ComboBox1.Text
        Dim DA As SqlDataReader = cmd1.ExecuteReader
        While (DA.Read())
            DateTimePicker1.Text = DA.GetValue(0)
            DateTimePicker2.Text = DA.GetValue(1)
            TextBox13.Text = DA.GetValue(2)
            TextBox2.Text = DA.GetValue(3)
            TextBox3.Text = DA.GetValue(4)
            TextBox14.Text = DA.GetValue(5)
            TextBox5.Text = DA.GetValue(6)
            TextBox4.Text = DA.GetValue(7)
            TextBox6.Text = DA.GetValue(8)
        End While
        con1.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim AQTY As Integer

        Try
            Dim conn As New SqlConnection(My.Settings.LIBRARY)
            Dim comd As New SqlCommand("SELECT available_qty FROM addbook where accession_no=@acno", conn)
            conn.Open()
            comd.Parameters.AddWithValue("@acno", SqlDbType.NVarChar).Value = TextBox14.Text
            Dim DA As SqlDataReader = comd.ExecuteReader
            While (DA.Read())
                AQTY = DA.GetValue(0)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("UPDATE ISSUE SET status=@status WHERE TRANSACTION_ID=@ID", con)
            cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = "Returned"
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ComboBox1.Text
            con.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                AQTY += 1
                Dim cmd1 As New SqlCommand("UPDATE addbook SET Available_Qty = @aqty WHERE Accession_no =@Accession_no", con)
                cmd1.Parameters.Add("@aqty", SqlDbType.NVarChar).Value = AQTY
                cmd1.Parameters.Add("@Accession_no", SqlDbType.NVarChar).Value = TextBox14.Text
                cmd1.ExecuteNonQuery()

                MsgBox("Book Returned Successfully")
            Else
                MsgBox("Some Error Occurs! Please Try Again Later", MsgBoxStyle.Critical)
            End If
            con.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try

            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT Transaction_id FROM issue", con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            ComboBox1.DataSource = table
            ComboBox1.DisplayMember = "Transaction_id"
            ComboBox1.ValueMember = "Transaction_id"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim con1 As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd1 As New SqlCommand("SELECT [Issue],[Return_Date],[Staff_id],[Staff_Name],[Department],[Accession_no],[Book_Title],[Author],[Edition] FROM staffissue where Transaction_id=@ID", con1)
        con1.Open()
        cmd1.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ComboBox2.Text
        Dim DA As SqlDataReader = cmd1.ExecuteReader
        While (DA.Read())
            DateTimePicker4.Text = DA.GetValue(0)
            DateTimePicker3.Text = DA.GetValue(1)
            TextBox1.Text = DA.GetValue(2)
            TextBox11.Text = DA.GetValue(3)
            TextBox10.Text = DA.GetValue(4)
            TextBox12.Text = DA.GetValue(5)
            TextBox9.Text = DA.GetValue(6)
            TextBox8.Text = DA.GetValue(7)
            TextBox7.Text = DA.GetValue(8)
        End While
        con1.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim AQTY As Integer

        Try
            Dim conn As New SqlConnection(My.Settings.LIBRARY)
            Dim comd As New SqlCommand("SELECT available_qty FROM addbook where accession_no=@acno", conn)
            conn.Open()
            comd.Parameters.AddWithValue("@acno", SqlDbType.NVarChar).Value = TextBox12.Text
            Dim DA As SqlDataReader = comd.ExecuteReader
            While (DA.Read())
                AQTY = DA.GetValue(0)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try

            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("DELETE FROM staffISSUE WHERE TRANSACTION_ID=@ID", con)
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ComboBox2.Text
            con.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                AQTY += 1
                Dim cmd1 As New SqlCommand("UPDATE addbook SET Available_Qty = @aqty WHERE Accession_no =@Accession_no", con)
                cmd1.Parameters.Add("@aqty", SqlDbType.NVarChar).Value = AQTY
                cmd1.Parameters.Add("@Accession_no", SqlDbType.NVarChar).Value = TextBox12.Text
                cmd1.ExecuteNonQuery()

                MsgBox("Book Returned Successfully")
            Else
                MsgBox("Some Error Occurs! Please Try Again Later", MsgBoxStyle.Critical)
            End If
            con.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try

            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("SELECT Transaction_id FROM issue", con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            ComboBox1.DataSource = table
            ComboBox1.DisplayMember = "Transaction_id"
            ComboBox1.ValueMember = "Transaction_id"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text = ""
        TextBox11.Text = ""
        TextBox10.Text = ""
        TextBox12.Text = ""
        TextBox9.Text = ""
        TextBox8.Text = ""
        TextBox7.Text = ""
        ComboBox2.Text = ""
        DateTimePicker4.ResetText()
        DateTimePicker3.ResetText()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox13.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox6.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox14.Text = ""
        ComboBox1.Text = ""
        DateTimePicker1.ResetText()
        DateTimePicker2.ResetText()
    End Sub
End Class