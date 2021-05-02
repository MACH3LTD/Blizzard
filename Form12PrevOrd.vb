Imports System.Data.SqlClient

Public Class Form12PrevOrd
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim rowc As Integer = 0
    Dim nam As String = ""
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form4progskeleton.OpenMainPanel(New Form9AccountDeets)

    End Sub

    Private Sub Form12PrevOrd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        ListBox1.Items.Clear()
        Dim c As New SqlCommand("select number from " + Form1.TextBox1.Text + "_orderhist", cn1)
        Dim da As New SqlDataAdapter(c)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            ListBox1.Items.Add(DirectCast(row, System.Data.DataRow)("number").ToString())
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim c As New SqlCommand("select number1,digit from " + Form1.TextBox1.Text + "_orderhist where number = '" + ListBox1.SelectedItem.ToString + "'", cn1)
        Dim da As New SqlDataAdapter(c)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        Dim change As String = ""
        Dim change1 As String = ""

        For Each row As DataRow In dt.Rows
            change = (DirectCast(row, System.Data.DataRow)("number1").ToString())
            change1 = (DirectCast(row, System.Data.DataRow)("digit").ToString())

        Next
        Dim words As String() = change.Split(New Char() {","c})
        Dim word As String
        For Each word In words
            ListBox2.Items.Add(word)
        Next
        Dim words1 As String() = change1.Split(New Char() {","c})
        Dim word1 As String
        For Each word1 In words1
            ListBox3.Items.Add(word1)
        Next
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Try
            TextBox1.Text = ListBox2.SelectedItem.ToString()
            nam = TextBox1.Text
        Catch e1 As Exception
            Console.WriteLine("Error: {0}", e1)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please select a Title.")
        Else
            Me.Close()
            Form31DownCert.TopLevel = False
        Form31DownCert.FormBorderStyle = FormBorderStyle.None
        Form31DownCert.Dock = DockStyle.Fill
        Form4progskeleton.Panel2.Controls.Add(Form31DownCert)
        Form4progskeleton.Panel2.Tag = Form31DownCert
        Form31DownCert.na = nam
        Form31DownCert.BringToFront()
        Form31DownCert.Show()
        End If

    End Sub
End Class