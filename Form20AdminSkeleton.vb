Imports System.Data.SqlClient
Public Class Form20AdminSkeleton
    Dim currentChildForm As New Form
    Dim currentChildForm1 As New Form
    Private Property mf As Boolean
    Private Property mfm As Point
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Public Sub OpenMainPanel(ChildForm As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        ChildForm.TopLevel = False
        ChildForm.FormBorderStyle = FormBorderStyle.None
        ChildForm.Dock = DockStyle.Fill
        currentChildForm = ChildForm
        Panel2.Controls.Add(ChildForm)
        Panel2.Tag = ChildForm
        ChildForm.BringToFront()
        ChildForm.Show()

    End Sub

    Public Sub OpenSubPanel(ChildForm1 As Form)
        If currentChildForm1 IsNot Nothing Then
            currentChildForm1.Close()
        End If
        ChildForm1.TopLevel = False
        ChildForm1.FormBorderStyle = FormBorderStyle.None
        ChildForm1.Dock = DockStyle.Fill
        currentChildForm1 = ChildForm1
        Panel1.Controls.Add(ChildForm1)
        Panel1.Tag = ChildForm1
        ChildForm1.BringToFront()

        ChildForm1.Show()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenMainPanel(New Form21GameDB)
    End Sub

    Private Sub Form20AdminSkeleton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c As New SqlCommand("select name from userinfo where username='" + Form1.TextBox1.Text + "'", cn)
        Dim da As New SqlDataAdapter(c)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            Label2.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenMainPanel(New Form27Reports)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenMainPanel(New Form28UserReport)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenMainPanel(New Form33ReviewView)
    End Sub
    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        If e.Button = MouseButtons.Left Then
            mf = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        If e.Button = MouseButtons.Left Then
            mf = True
            Me.Cursor = Cursors.Default
            mfm = e.Location
        End If
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If mf Then
            Me.Location = Me.Location + (e.Location - mfm)
        End If
    End Sub
End Class