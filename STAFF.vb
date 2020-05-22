Imports System.Data.SqlClient
Imports System.IO

Public Class STAFF
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim MS As New MemoryStream
            PictureBox1.Image.Save(MS, PictureBox1.Image.RawFormat)
            Dim con As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd As New SqlCommand("INSERT INTO STAFF  (STAFF_ID,NAME_OF_STAFF,GENDER,FATHER_NAME,DEPARTMENT,DOB,DATE_OF_JOINING,MOBILE_NUMBER,E_MAIL,ADDRESS,PHOTOGRAPH) VALUES (@STAFF_ID,@NAME_OF_STAFF,@GENDER,@FATHER_NAME,@DEPARTMENT,@DOB,@DATE_OF_JOINING,@MOBILE_NUMBER,@E_MAIL,@ADDRESS,@PHOTOGRAPH)", con)
            cmd.Parameters.Add("@STAFF_ID", SqlDbType.NVarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@NAME_OF_STAFF  ", SqlDbType.NVarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@GENDER", SqlDbType.NVarChar).Value = ComboBox1.Text
            cmd.Parameters.Add("@FATHER_NAME", SqlDbType.NVarChar).Value = TextBox6.Text
            cmd.Parameters.Add("@DEPARTMENT", SqlDbType.NVarChar).Value = ComboBox3.Text
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@DATE_OF_JOINING", SqlDbType.Date).Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@MOBILE_NUMBER", SqlDbType.NVarChar).Value = TextBox7.Text
            cmd.Parameters.Add("@E_MAIL", SqlDbType.NVarChar).Value = TextBox10.Text
            cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = TextBox12.Text
            cmd.Parameters.Add("@PHOTOGRAPH", SqlDbType.Image).Value = MS.ToArray()

            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("STAFF MEMBER Added Successfully  !")
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

    Private Sub STAFF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.Click, ComboBox3.Enter
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT * FROM DEPARTMENT", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox3.DataSource = table
        ComboBox3.DisplayMember = "DEPARTMENT"
        ComboBox3.ValueMember = "DEPARTMENT"
    End Sub
End Class