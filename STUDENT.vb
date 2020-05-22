Imports System.Data.SqlClient
Imports System.IO

Public Class STUDENT
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim MS As New MemoryStream
            PictureBox1.Image.Save(MS, PictureBox1.Image.RawFormat)
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("INSERT INTO STUDENT  (STUDENT_ID,NAME_OF_STUDENT,GENDER,FATHER_NAME,DEPARTMENT,COURSE,YEAR,DOB,MOBILE_NUMBER,E_MAIL,ADDRESS,PHOTOGRAPH) VALUES (@STUDENT_ID,@NAME_OF_STUDENT,@GENDER,@FATHER_NAME,@DEPARTMENT,@COURSE,@YEAR,@DOB,@MOBILE_NUMBER,@E_MAIL,@ADDRESS,@PHOTOGRAPH)", con)
            cmd.Parameters.Add("@STUDENT_ID", SqlDbType.NVarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@NAME_OF_STUDENT  ", SqlDbType.NVarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@GENDER", SqlDbType.NVarChar).Value = TextBox3.Text
            cmd.Parameters.Add("@FATHER_NAME", SqlDbType.NVarChar).Value = TextBox6.Text
            cmd.Parameters.Add("@DEPARTMENT", SqlDbType.NVarChar).Value = ComboBox2.Text
            cmd.Parameters.Add("@COURSE    ", SqlDbType.NVarChar).Value = ComboBox1.Text
            cmd.Parameters.Add("@YEAR", SqlDbType.NVarChar).Value = ComboBox3.Text
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@MOBILE_NUMBER", SqlDbType.NVarChar).Value = TextBox7.Text
            cmd.Parameters.Add("@E_MAIL", SqlDbType.NVarChar).Value = TextBox10.Text
            cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = TextBox12.Text
            cmd.Parameters.Add("@PHOTOGRAPH", SqlDbType.Image).Value = MS.ToArray()

            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("STUDENT Added Successfully  !")
            con.Dispose()


        Catch EX As Exception
            MsgBox(EX.ToString())
        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            With OpenFileDialog1
                .Filter = "IMAGES | *.PNG;*.BMP;*.JPG;*.JPEG;*.GIF;*.ICO;"
                .FilterIndex = 4

            End With
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())

        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.MouseClick
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM DEPARTMENT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox2.DataSource = table
        ComboBox2.DisplayMember = "DEPARTMENT"
        ComboBox2.ValueMember = "DEPARTMENT"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.MouseClick
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM COURSE", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "COURSE"
        ComboBox1.ValueMember = "COURSE"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox10.Clear()
        TextBox12.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        DateTimePicker1.ResetText()
        ComboBox1.ResetText()
        ComboBox2.ResetText()
        ComboBox3.ResetText()
        PictureBox1.Image = Nothing
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.MouseClick
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM YEAR", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox3.DataSource = table
        ComboBox3.DisplayMember = "YEAR"
        ComboBox3.ValueMember = "YEAR"
    End Sub

End Class