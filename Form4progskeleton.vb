Imports System.Data.SqlClient
Public Class Form4progskeleton
    Dim currentChildForm As New Form
    Private Property mf As Boolean
    Private Property mfm As Point
    Dim currentChildForm1 As New Form
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub
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

    Public Sub OpenMainPanel1(ChildForm As Form)

        ChildForm.TopLevel = False
        ChildForm.FormBorderStyle = FormBorderStyle.None
        ChildForm.Dock = DockStyle.Fill
        Panel2.Controls.Add(ChildForm)
        Panel2.Tag = ChildForm
        ChildForm.BringToFront()
        ChildForm.Show()

    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Form4progskeleton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenSubPanel(New Form0Buttons)
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

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class

