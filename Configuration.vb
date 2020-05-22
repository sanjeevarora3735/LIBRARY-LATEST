Imports System.Data.SqlClient

Public Class Configuration

    Dim num As Integer
    Dim r1, r2 As Boolean
    Dim tran As String
    Private Sub Configuration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        r1 = False
        r2 = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False

        TextBox2.Text = "  +  COUNT"
        If My.Settings.TRANSACT = True Then
            Dim con1 As New SqlConnection(My.Settings.LIBRARY)
            Dim cmd1 As New SqlCommand("SELECT ConfigurationText FROM Configuration ", con1)
            con1.Open()
            Dim DA As SqlDataReader = cmd1.ExecuteReader
            While (DA.Read())
                TextBox1.Text = DA.GetValue(0).ToString()
            End While
            con1.Close()
        Else

        End If
        If TextBox1.Text <> "" Then
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            RadioButton1.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox5.Enabled = False
            RadioButton1.Checked = False
            Button1.Enabled = False
        End If



    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
            TextBox1.Enabled = True
            TextBox2.Enabled = False
            TextBox5.Enabled = False
        Else
        End If

    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
            TextBox5.Enabled = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        Else
            'do nothing
        End If

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyUp
        TextBox3.Text = TextBox5.Text
        TextBox4.Text = TextBox1.Text + TextBox2.Text
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        TextBox3.Text = TextBox5.Text
        TextBox4.Text = TextBox1.Text + TextBox2.Text
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        TextBox3.Text = TextBox5.Text
        TextBox4.Text = TextBox1.Text + TextBox2.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CON As New SqlConnection(My.Settings.LIBRARY)

        Dim a As DialogResult
        a = MessageBox.Show("Are You Want To Sure To Save This,This is a one time setting You won't change it any more ", "Settings", MessageBoxButtons.OKCancel)
        If a.OK = DialogResult.OK Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            If RadioButton1.Checked = True Then
                tran = TextBox1.Text
                r1 = True
                TextBox5.Clear()
                Dim cmd1 As New SqlCommand("INSERT INTO Configuration VALUES(@ConfigurationText)", CON)
                cmd1.Parameters.Add("@ConfigurationText", SqlDbType.NVarChar).Value = tran
                CON.Open()
                cmd1.ExecuteNonQuery()
                CON.Close()

            ElseIf RadioButton2.Checked = True Then
                num = TextBox5.Text
                r2 = True
                TextBox1.Clear()
                Dim cmd1 As New SqlCommand("INSERT INTO Configuration VALUES(@ConfigurationText)", CON)
                cmd1.Parameters.Add("@ConfigurationText", SqlDbType.NVarChar).Value = num
                CON.Open()
                cmd1.ExecuteNonQuery()
                CON.Close()
            Else
                'do nothing
            End If

            Me.Close()

        Else
            'DO NOTHING
        End If
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        TextBox5.Enabled = False
        Button1.Enabled = False
        My.Settings.TRANSACT = True


    End Sub
End Class