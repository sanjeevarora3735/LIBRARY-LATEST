Imports System.Data.SqlClient

Public Class Form1
    Dim id As Integer
    Dim ids As Integer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.Text = "  LIBRARY  MANAGEMENT SYSTEM  "
        Timer1.Start()
        '''''''''Get IDS ''''''''''''
        Try

            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ID FROM SLASTID WHERE I=@1", con1)
            cmd1.Parameters.Add("@1", SqlDbType.Int).Value = 0
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                id = DA.GetValue(0).ToString()
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
                ids = DA.GetValue(0).ToString()
            End While
            con1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '''''''''''''''''''''''''''''
        Dim t As Integer
        t = id + ids
        If t <= 9 Then
            Label13.Text = t
        ElseIf t <= 99 And t >= 10 Then
            Dim temp As Integer = t \ 10
            Dim temp1 As Integer = t Mod 10
            Label13.Text = temp1.ToString
            Label12.Text = temp.ToString
        End If
        '''''''''''''''''''''''''''''

        TRANSPARENT.ShowDialog()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateTime.Today.ToShortDateString
        Label2.Text = Now.ToLongTimeString
        ProgressBar1.Increment(100000000)

        '''''''''''''''''''''''''''''
    End Sub

    Private Sub SUBJECTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SUBJECTToolStripMenuItem.Click
        SUBJECT.ShowDialog()

    End Sub

    Private Sub COURSEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COURSEToolStripMenuItem.Click
        COURSE.ShowDialog()

    End Sub

    Private Sub DEPARTMENTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DEPARTMENTToolStripMenuItem.Click
        DEPARTMENT.ShowDialog()

    End Sub

    Private Sub BOOKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BOOKToolStripMenuItem.Click
        BOOK.ShowDialog()


    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        issue.ShowDialog()
    End Sub
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Application.ExitThread()
    End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Staffissue.ShowDialog()
    End Sub

    Private Sub YEARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YEARToolStripMenuItem.Click
        YEAR.ShowDialog()

    End Sub

    Private Sub STUDENTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STUDENTToolStripMenuItem.Click
        STUDENT.ShowDialog()
    End Sub

    Private Sub STAFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STAFFToolStripMenuItem.Click
        STAFF.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        STUDENT.ShowDialog()
    End Sub

    Private Sub ADDNEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDNEWToolStripMenuItem.Click
        ADDUSER.ShowDialog()
    End Sub

    Private Sub REMOVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REMOVEToolStripMenuItem.Click
        REMOVEUSER.ShowDialog()
    End Sub

    Private Sub MODIFIYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MODIFIYToolStripMenuItem.Click
        MODIFYUSER.ShowDialog()
    End Sub
    Private Sub BOOKISSUEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BOOKISSUEToolStripMenuItem.Click
        bookissue.ShowDialog()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        BOOK.ShowDialog()
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        bookissue.ShowDialog()
    End Sub

    Private Sub BOOKRETURNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BOOKRETURNToolStripMenuItem.Click
        BOOKRETURN.ShowDialog()
    End Sub

    Private Sub BOOKSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BOOKSToolStripMenuItem.Click
    End Sub

    Private Sub AllBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllBooksToolStripMenuItem.Click
        RECORDBOOK.ShowDialog()
    End Sub
    Private Sub SearchByToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchByToolStripMenuItem.Click
        recordbooksearch.ShowDialog()
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        recordstudent.ShowDialog()
    End Sub

    Private Sub SearchByToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SearchByToolStripMenuItem1.Click
        recordstudentsearch.ShowDialog()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        BOOKRETURN.ShowDialog()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        RECORDBOOK.ShowDialog()
    End Sub

    Private Sub STAFFToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles STAFFToolStripMenuItem2.Click
        recordstaff.ShowDialog()
    End Sub

    Private Sub ConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurationToolStripMenuItem.Click
        Configuration.ShowDialog()
    End Sub

    Private Sub StudentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem1.Click
        issue.ShowDialog()
    End Sub

    Private Sub FINEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FINEToolStripMenuItem.Click
    End Sub
    Private Sub StaffToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StaffToolStripMenuItem1.Click
        Staffissue.ShowDialog()
    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        recordbooksearch.ShowDialog()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class
