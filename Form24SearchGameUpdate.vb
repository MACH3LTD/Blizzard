Imports System.Data.SqlClient

Public Class Form24SearchGameUpdate
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim cmd As New SqlCommand("select name from gameinfo", cn)
    Dim dt As New DataTable
    Public Property s1 As String

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub
    Private Sub Form24SearchGameUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Hide()
        ComboBox1.Items.Add("A to Z")
        ComboBox1.Items.Add("Z to A")
        TextBox1.Text = ""
        ComboBox1.Items.Add("Rating")
        ListBox1.DataSource = getData("select name from gameinfo")
        ListBox1.DisplayMember = "name"
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

        Form23UpdateGame.Close()
        Form23UpdateGame.TopLevel = False
        Form23UpdateGame.FormBorderStyle = FormBorderStyle.None
        Form23UpdateGame.Dock = DockStyle.Fill
        Form20AdminSkeleton.Panel2.Controls.Add(Form23UpdateGame)
        Form20AdminSkeleton.Panel2.Tag = Form23UpdateGame
        Form23UpdateGame.s = s1
        Form23UpdateGame.BringToFront()
        Form23UpdateGame.Show()
    End Sub

End Class