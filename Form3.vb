Imports System.Data.SqlClient
Public Class Form3
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Public Property s As String
    Private Property mf As Boolean
    Private Property mfm As Point
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text = "" And TextBox3.Text = "" Then
                MessageBox.Show("Field cannot be Empty!")
            Else

                If TextBox2.Text.Trim() = TextBox3.Text.Trim() Then
                    Dim cmd As New SqlCommand("Update userinfo set password ='" + TextBox3.Text + "' where username = '" + Form1.TextBox1.Text + "' ", cn)
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Password Updated Sucessfully")
                    cn.Close()
                Else
                    MsgBox("Passwords dont match")
                End If
                TextBox2.Text = ""
                TextBox3.Text = ""
                Dim fpage As New Form1
                fpage.Show()

                Me.Close()
            End If
        Catch e1 As Exception
            MessageBox.Show("Error: " + e1.Message)
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Hide()
        Label2.Hide()
        Label3.Hide()
        TextBox2.Hide()
        TextBox3.Hide()
        Dim c As New SqlCommand("select secque from userinfo where username ='" + Form1.TextBox1.Text + "'", cn)
        Dim da As New SqlDataAdapter(c)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            TextBox4.Text = (DirectCast(row, System.Data.DataRow)("secque").ToString())
        Next
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim fpage As New Form1
        fpage.Show()

        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim c As SqlCommand = New SqlCommand("select secans from userinfo where username ='" + Form1.TextBox1.Text + "'", cn)
            Dim da As New SqlDataAdapter(c)
            Dim dt As New DataTable
            Dim ans As String = ""
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                ans = (DirectCast(row, System.Data.DataRow)("secans").ToString().Trim())
            Next
            da.Fill(dt)
            If TextBox5.Text.Trim() = ans Then
                MessageBox.Show("Verified. Please Enter New Password")
                Button2.Hide()
                Button1.Show()
                Label2.Show()
                Label3.Show()
                TextBox2.Show()
                TextBox3.Show()
                TextBox2.ReadOnly = False
                TextBox3.ReadOnly = False
            Else
                MessageBox.Show("Incorrect Details")
            End If
        Catch e1 As Exception
            MessageBox.Show("Error: " + e1.Message)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

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