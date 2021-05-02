Imports System.Data.SqlClient
Public Class Form8searchgame
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim cmd As New SqlCommand("select name from gameinfo", cn)
    Dim dt As New DataTable
    Dim i As Integer = 0
    Public Property formname As String
    Public Property s1 As String
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
        Form4progskeleton.OpenSubPanel(New Form0Buttons)
    End Sub

    Private Sub Form8searchgame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Hide()
        ComboBox1.Items.Add("A to Z")
        ComboBox1.Items.Add("Z to A")
        ComboBox1.Items.Add("Rating")
        TextBox1.Text = ""
        ListBox1.DataSource = getData("select name from gameinfo")
        ListBox1.DisplayMember = "name"
        i = 1
        If formname = "review" Then
            PictureBox3.Hide()
        End If
    End Sub
    Private Function getData(ByVal c As String) As DataTable
        dt.Clear()
        Dim c1 As New SqlCommand(c, cn)
        Dim da As New SqlDataAdapter(c1)
        da.Fill(dt)
        Return dt
    End Function
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim dv As New DataView
        dv = dt.DefaultView
        dv.RowFilter = "name like '%" + TextBox1.Text + "%'"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "A to Z" Then
            ListBox1.DataSource = getData("select name from gameinfo order by name asc")
            ListBox1.DisplayMember = "name"

        ElseIf ComboBox1.SelectedItem = "Z to A" Then
            ListBox1.DataSource = getData("select name from gameinfo order by name desc")
            ListBox1.DisplayMember = "name"
        Else
            ListBox1.DataSource = getData("select name from gameinfo order by rating desc")
            ListBox1.DisplayMember = "name"
        End If
    End Sub

    Public Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox2.Text = ListBox1.GetItemText(ListBox1.SelectedItem)
        s1 = TextBox2.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If formname = "game" Then
            Form32ReviewEntry.Close()
            Form32ReviewEntry.TopLevel = False
            Form32ReviewEntry.FormBorderStyle = FormBorderStyle.None
            Form32ReviewEntry.Dock = DockStyle.Fill
            Form32ReviewEntry.gamename = s1
            Form4progskeleton.Panel2.Controls.Add(Form32ReviewEntry)
            Form4progskeleton.Panel2.Tag = Form32ReviewEntry
            Form32ReviewEntry.BringToFront()
            Form32ReviewEntry.Show()
        Else
            Form5home.Close()
            Form5home.TopLevel = False
            Form5home.FormBorderStyle = FormBorderStyle.None
            Form5home.Dock = DockStyle.Fill
            Form4progskeleton.Panel2.Controls.Add(Form5home)
            Form4progskeleton.Panel2.Tag = Form5home
            Form5home.s = s1
            Form5home.BringToFront()
            Form5home.Show()
        End If
    End Sub
End Class
