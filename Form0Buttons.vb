Imports System.Data.SqlClient

Public Class Form0Buttons
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Private Sub Form0Buttons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c As New SqlCommand("select name from userinfo where username='" + Form1.TextBox1.Text + "'", cn)
        Dim da As New SqlDataAdapter(c)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            Label2.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())

        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Form4progskeleton.OpenSubPanel(New Form8searchgame)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4progskeleton.OpenMainPanel(New Form9AccountDeets)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result1 As DialogResult = MessageBox.Show("Are You Sure You Want To Log Out??", "Blizzard Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Form1.Show()
            Form4progskeleton.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4progskeleton.OpenMainPanel(New Form14Cart)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form4progskeleton.OpenMainPanel(New Form29Review)

    End Sub
End Class