Imports System.Data.SqlClient

Public Class Form1
    Dim cn As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Private Property mf As Boolean
    Private Property mfm As Point
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim signup As New Form2
        signup.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "username" Or TextBox1.Text = "" Then
            MessageBox.Show("Username field cannot be empty when trying to change password.")
        Else
            Form3.s = TextBox1.Text
            Form3.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim cmd As SqlCommand = New SqlCommand("select username, name, password, usertype from userinfo where username='" & TextBox1.Text & "' and Password= '" & TextBox2.Text + "'", cn)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)

        If (dt.Rows.Count > 0) Then
            MessageBox.Show("You have Logged-in as " + dt.Rows(0)(1))
            Dim c As SqlCommand = New SqlCommand("update userinfo set log='1' where username= '" & TextBox1.Text + "'", cn)
            cn.Open()
            c.ExecuteNonQuery()
            If dt.Rows(0)(3) = "user" Then
                Form4progskeleton.Show()

                Me.Hide()
                cn.Close()
            Else
                Form20AdminSkeleton.Show()
                Me.Hide()
                cn.Close()
            End If
        Else
            MessageBox.Show("Incorrect Details entered! Please Check.")
        End If


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ForeColor = Color.Silver
        TextBox1.Text = "username"
        TextBox2.ForeColor = Color.Silver
        TextBox2.Text = "password"
    End Sub
    Private Sub textbox1_gotfocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = "username" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black

        End If
    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus

        If TextBox2.Text = "password" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black

        End If
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.ForeColor = Color.Silver
            TextBox1.Text = "username"
        End If
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus

        If TextBox2.Text = "" Then
            TextBox2.ForeColor = Color.Silver
            TextBox2.Text = "password"
        End If
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Exit()

    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            mf = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            mf = True
            Me.Cursor = Cursors.Default
            mfm = e.Location
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If mf Then
            Me.Location = Me.Location + (e.Location - mfm)
        End If
    End Sub
End Class
