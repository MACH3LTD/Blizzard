Imports System.Data.SqlClient

Public Class trial
    Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\trial.mdf;Integrated Security=True"
    Dim str1 As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True"
    Dim Conn As New SqlConnection(str)
    Dim Conn1 As New SqlConnection(str1)
    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Private Sub trial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.VerticalScroll.Maximum = 0
        Me.AutoScroll = True
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "INSERT INTO trialdb (Name,age,usertype) values (@name, @age, @ut)"
        Using Conn As New SqlConnection(str)
            Using cmd As New SqlCommand(sql, Conn)
                Conn.Open()
                cmd.Parameters.AddWithValue("@name", TextBox1.Text)
                cmd.Parameters.AddWithValue("@age", TextBox2.Text)
                Dim value = cmd.ExecuteScalar()
                If value > 0 Then
                    MessageBox.Show("Signup Unsucessful")
                Else
                    MessageBox.Show("Signup Sucessful")
                End If
            End Using
        End Using
        Dim sql1 As String = "CREATE TABLE " + TextBox1.Text + "orderhist (number int, number1 int)"
        Using Conn1 As New SqlConnection(str1)
            Using cmd1 As New SqlCommand(sql1, Conn1)
                Conn1.Open()
                cmd1.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql1 As String = "Insert Into corrorderhist values (@num, @num1)"
        Using Conn1 As New SqlConnection(str1)
            Using cmd1 As New SqlCommand(sql1, Conn1)
                Conn1.Open()
                cmd1.Parameters.AddWithValue("@num", TextBox3.Text)
                cmd1.Parameters.AddWithValue("@num1", TextBox4.Text)
                Dim value = cmd1.ExecuteScalar()
            End Using
        End Using

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cmd As SqlCommand = New SqlCommand("select * from corrorderhist", Conn1)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)
        RichTextBox1.Text = " "
        For Each row As DataRow In dt.Rows
            ListBox1.Items.Add(DirectCast(row, System.Data.DataRow)("number").ToString())
            ListBox2.Items.Add(DirectCast(row, System.Data.DataRow)("number1").ToString())
            RichTextBox1.Text = RichTextBox1.Text + (DirectCast(row, System.Data.DataRow)("number").ToString())
            RichTextBox1.Text = RichTextBox1.Text + ControlChars.Lf
        Next



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim l As Integer = 0
        For l_index As Integer = 0 To ListBox2.Items.Count - 1

            l = l + CInt(ListBox2.Items(l_index))
        Next
        TextBox5.Text = l
    End Sub
End Class