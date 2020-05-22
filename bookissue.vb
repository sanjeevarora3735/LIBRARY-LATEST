Imports System.Data.SqlClient

Public Class bookissue
    Dim ID As Integer
    Dim IDS As Integer
    Dim ID1 As Integer
    Dim IDS1 As Integer
    Dim Transaction_id As String


    Private Sub bookissue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' count'

        Try
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ID FROM SLASTID WHERE I=@1", con1)
            cmd1.Parameters.Add("@1", SqlDbType.Int).Value = 0
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                ID = DA.GetValue(0).ToString()
                ID += 1
                TextBox1.Text = ID.ToString
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ID FROM SLASTID WHERE I=@1", con1)
            cmd1.Parameters.Add("@1", SqlDbType.Int).Value = 1
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                IDS = DA.GetValue(0).ToString()
                IDS += 1
                TextBox16.Text = IDS.ToString
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ''''''
        DateTimePicker1.Enabled = False
        DateTimePicker4.Enabled = False
        TextBox13.Enabled = False

        TextBox14.Enabled = False
        TextBox15.Enabled = False
        TextBox12.Enabled = False
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        'INITIALS
        Try
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ConfigurationText FROM Configuration", con1)
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                TextBox14.Text = DA.GetValue(0).ToString()
                TextBox12.Text = DA.GetValue(0).ToString()
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim lid As Integer
        Dim lids As Integer
        lid = ID - 1
        LIds = lid - 1
        TextBox13.Text = TextBox14.Text + lid.ToString
        TextBox15.Text = TextBox12.Text + lids.ToString
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim issue As DateTime = Convert.ToDateTime(DateTimePicker1.Text)
        Dim issue_for As DateTime = Convert.ToDateTime(DateTimePicker2.Text)
        Dim tdays As TimeSpan = issue_for.Subtract(issue)
        Dim day = Convert.ToInt32(tdays.Days)
        Dim tdays1 As TimeSpan = issue_for.Subtract(Now.Date)
        Dim rday = Convert.ToInt32(tdays1.Days)
        Dim aqty As Integer
        Try
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT available_qty FROM addbook where accession_no=@acno", con1)
            con1.Open()
            cmd1.Parameters.AddWithValue("@acno", SqlDbType.NVarChar).Value = ComboBox2.Text
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                aqty = DA.GetValue(0)
            End While
            con1.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If aqty < 1 Then
            MsgBox("Not Enough Quantity of this book is Available", MsgBoxStyle.Critical, "Book Qty")
        Else
            Transaction_id = TextBox14.Text + TextBox1.Text
            Try

                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("INSERT INTO issue (Transaction_id,Issue,Return_Date,Student_id,Student_Name,Department,Accession_no,Book_Title,Author,Edition,issue_for,Remaining_Day) VALUES (@Transaction_id,@Issue,@Return_Date,@Student_id,@Student_Name,@Department,@Accession_no,@Book_Title,@Author,@Edition,@issue_for,@Remaining_Day)", con)
                cmd.Parameters.Add("@Transaction_id", SqlDbType.NVarChar).Value = Transaction_id.ToString
                cmd.Parameters.Add("@Issue  ", SqlDbType.Date).Value = DateTimePicker1.Value.Date
                cmd.Parameters.Add("@Return_Date", SqlDbType.Date).Value = DateTimePicker2.Value.Date
                cmd.Parameters.Add("@Student_id", SqlDbType.NVarChar).Value = ComboBox1.Text
                cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = TextBox2.Text
                cmd.Parameters.Add("@Department    ", SqlDbType.NVarChar).Value = TextBox3.Text
                cmd.Parameters.Add("@Accession_no", SqlDbType.NVarChar).Value = ComboBox2.Text
                cmd.Parameters.Add("@Book_Title", SqlDbType.NVarChar).Value = TextBox5.Text
                cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = TextBox4.Text
                cmd.Parameters.Add("@Edition", SqlDbType.NVarChar).Value = TextBox6.Text
                cmd.Parameters.Add("@issue_for", SqlDbType.Int).Value = day
                cmd.Parameters.Add("@Remaining_Day", SqlDbType.Int).Value = rday
                aqty -= 1
                con.Open()
                cmd.ExecuteNonQuery()
                Dim cmd1 As New SqlCommand("UPDATE addbook SET Available_Qty = @aqty WHERE Accession_no =@Accession_no", con)
                cmd1.Parameters.Add("@aqty", SqlDbType.NVarChar).Value = aqty
                cmd1.Parameters.Add("@Accession_no", SqlDbType.NVarChar).Value = ComboBox2.Text
                cmd1.ExecuteNonQuery()
                MsgBox("Book Issued Successfully")
                Dim command As New SqlCommand("UPDATE SLASTID SET ID = @ID WHERE I=@I", con)
                command.Parameters.Add("@ID", SqlDbType.Int).Value = TextBox1.Text
                command.Parameters.Add("@I", SqlDbType.Int).Value = 0
                command.ExecuteNonQuery()
                TextBox13.Text = TextBox14.Text + TextBox1.Text
                Me.Refresh()
                con.Dispose()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        '''''''''Get IDS ''''''''''''
        Try

            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ID FROM SLASTID WHERE I=@1", con1)
            cmd1.Parameters.Add("@1", SqlDbType.Int).Value = 0
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                ID1 = DA.GetValue(0).ToString()
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '''''''''Get IDS ''''''''''''
        Try
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ID FROM SLASTID WHERE I=@1", con1)
            cmd1.Parameters.Add("@1", SqlDbType.Int).Value = 1
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                IDS1 = DA.GetValue(0).ToString()
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '''''''''''''''''''''''''''''
        Dim t As Integer
        t = ID1 + IDS1
        If t <= 9 Then
            Form1.Label13.Text = t
        ElseIf t <= 99 And t >= 10 Then
            Dim temp As Integer = t \ 10
            Dim temp1 As Integer = t Mod 10
            Form1.Label13.Text = temp1.ToString
            Form1.Label12.Text = temp.ToString
        End If
        '''''''''''''''''''''''''''''

    End Sub

    Private Sub button12_click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim datex As DateTime = DateTimePicker2.Value
        DateTimePicker2.Value = datex.AddDays(14)
    End Sub

    Private Sub button11_click(sender As Object, e As EventArgs) Handles Button11.Click

        Dim datex As DateTime = DateTimePicker2.Value
        DateTimePicker2.Value = datex.AddDays(7)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.Enter
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT student_id FROM student", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "student_id"
        ComboBox1.ValueMember = "student_id"
        '
        Dim con1 As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd1 As New SqlCommand("SELECT Name_of_student,department FROM student where student_id=@id", con1)
        con1.Open()
        cmd1.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = ComboBox1.Text
        Dim DA As SqlDataReader = cmd1.ExecuteReader
        While (DA.Read())
            TextBox2.Text = DA.GetValue(0).ToString()
            TextBox3.Text = DA.GetValue(1).ToString()
        End While
        con1.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.Enter
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT accession_no  FROM addbook", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox2.DataSource = table
        ComboBox2.DisplayMember = "accession_no"
        ComboBox2.ValueMember = "accession_no"
        '
        Dim con1 As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd1 As New SqlCommand("SELECT book_title,author,edition FROM addbook where accession_no=@id", con1)
        con1.Open()
        cmd1.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = ComboBox2.Text
        Dim DA As SqlDataReader = cmd1.ExecuteReader
        While (DA.Read())
            TextBox5.Text = DA.GetValue(0).ToString()
            TextBox4.Text = DA.GetValue(1).ToString()
            TextBox6.Text = DA.GetValue(2).ToString()
        End While
        con1.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.Click


    End Sub
    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.Click


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ' Date Calculator'
        Dim issue As DateTime = Convert.ToDateTime(DateTimePicker4.Text)
        Dim issue_for As DateTime = Convert.ToDateTime(DateTimePicker3.Text)
        Dim tdays As TimeSpan = issue_for.Subtract(issue)
        Dim day = Convert.ToInt32(tdays.Days)
        Dim tdays1 As TimeSpan = issue_for.Subtract(Now.Date)
        Dim rday = Convert.ToInt32(tdays1.Days)
        Dim aqty As Integer
        'Check Available Quantity'
        Try
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT available_qty FROM addbook where accession_no=@acno", con1)
            con1.Open()
            cmd1.Parameters.AddWithValue("@acno", SqlDbType.NVarChar).Value = ComboBox4.Text
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                aqty = DA.GetValue(0)
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' MsgBox '
        If aqty < 1 Then
            MsgBox("Not Enough Quantity of this book is Available", MsgBoxStyle.Critical, "Book Qty")
        Else
            Transaction_id = TextBox12.Text + TextBox1.Text

            'insertion command'

            Try

                Dim con As New SqlConnection(My.Settings.LIBRARY)
                Dim cmd As New SqlCommand("INSERT INTO staffissue (Transaction_id,Issue,Return_Date,Staff_id,Staff_Name,Department,Accession_no,Book_Title,Author,Edition,issue_for,Remaining_Day) VALUES (@Transaction_id,@Issue,@Return_Date,@Staff_id,@Staff_Name,@Department,@Accession_no,@Book_Title,@Author,@Edition,@issue_for,@Remaining_Day)", con)
                cmd.Parameters.Add("@Transaction_id", SqlDbType.NVarChar).Value = Transaction_id.ToString
                cmd.Parameters.Add("@Issue  ", SqlDbType.Date).Value = DateTimePicker4.Value.Date
                cmd.Parameters.Add("@Return_Date", SqlDbType.Date).Value = DateTimePicker3.Value.Date
                cmd.Parameters.Add("@Staff_id", SqlDbType.NVarChar).Value = ComboBox3.Text
                cmd.Parameters.Add("@Staff_Name", SqlDbType.NVarChar).Value = TextBox11.Text
                cmd.Parameters.Add("@Department    ", SqlDbType.NVarChar).Value = TextBox10.Text
                cmd.Parameters.Add("@Accession_no", SqlDbType.NVarChar).Value = ComboBox4.Text
                cmd.Parameters.Add("@Book_Title", SqlDbType.NVarChar).Value = TextBox9.Text
                cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = TextBox8.Text
                cmd.Parameters.Add("@Edition", SqlDbType.NVarChar).Value = TextBox7.Text
                cmd.Parameters.Add("@issue_for", SqlDbType.Int).Value = day
                cmd.Parameters.Add("@Remaining_Day", SqlDbType.Int).Value = rday
                aqty -= 1
                con.Open()
                cmd.ExecuteNonQuery()
                Dim cmd1 As New SqlCommand("UPDATE addbook SET Available_Qty = @aqty WHERE Accession_no =@Accession_no", con)
                cmd1.Parameters.Add("@aqty", SqlDbType.NVarChar).Value = aqty
                cmd1.Parameters.Add("@Accession_no", SqlDbType.NVarChar).Value = ComboBox4.Text
                cmd1.ExecuteNonQuery()
                MsgBox("Book Issued Successfully")
                Dim command As New SqlCommand("UPDATE SLASTID SET ID = @ID WHERE I=@I", con)
                command.Parameters.Add("@ID", SqlDbType.Int).Value = TextBox16.Text
                command.Parameters.Add("@I", SqlDbType.Int).Value = 1
                command.ExecuteNonQuery()
                Me.Close()
                con.Dispose()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
        '''''''''Get IDS ''''''''''''
        Try

            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ID FROM SLASTID WHERE I=@1", con1)
            cmd1.Parameters.Add("@1", SqlDbType.Int).Value = 0
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                ID1 = DA.GetValue(0).ToString()
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '''''''''Get IDS ''''''''''''
        Try
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ID FROM SLASTID WHERE I=@1", con1)
            cmd1.Parameters.Add("@1", SqlDbType.Int).Value = 1
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                IDS1 = DA.GetValue(0).ToString()
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '''''''''''''''''''''''''''''
        Dim t As Integer
        t = ID1 + IDS1
        If t <= 9 Then
            Form1.Label13.Text = t
        ElseIf t <= 99 And t >= 10 Then
            Dim temp As Integer = t \ 10
            Dim temp1 As Integer = t Mod 10
            Form1.Label13.Text = temp1.ToString
            Form1.Label12.Text = temp.ToString
        End If
        '''''''''''''''''''''''''''''
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim datex As DateTime = DateTimePicker3.Value
        DateTimePicker3.Value = datex.AddDays(14)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim datex As DateTime = DateTimePicker3.Value
        DateTimePicker3.Value = datex.AddDays(7)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.Enter
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT STAFF_ID FROM STAFF", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox3.DataSource = table
        ComboBox3.DisplayMember = "STAFF_ID"
        ComboBox3.ValueMember = "STAFF_ID"
        '
        Dim con1 As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd1 As New SqlCommand("SELECT Name_of_staff,department FROM staff where STAFF_ID=@id", con1)
        con1.Open()
        cmd1.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = ComboBox3.Text
        Dim DA As SqlDataReader = cmd1.ExecuteReader
        While (DA.Read())
            TextBox11.Text = DA.GetValue(0).ToString()
            TextBox10.Text = DA.GetValue(1).ToString()
        End While
        con1.Close()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.Enter
        Dim con As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd As New SqlCommand("SELECT accession_no  FROM addbook", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        ComboBox4.DataSource = table
        ComboBox4.DisplayMember = "accession_no"
        ComboBox4.ValueMember = "accession_no"
        '
        Dim con1 As New SqlConnection(My.Settings.LIBRARY)
        Dim cmd1 As New SqlCommand("SELECT book_title,author,edition FROM addbook where accession_no=@id", con1)
        con1.Open()
        cmd1.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = ComboBox4.Text
        Dim DA As SqlDataReader = cmd1.ExecuteReader
        While (DA.Read())
            TextBox9.Text = DA.GetValue(0).ToString()
            TextBox8.Text = DA.GetValue(1).ToString()
            TextBox7.Text = DA.GetValue(2).ToString()
        End While
        con1.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class