Imports System.Data.SqlClient
Imports System.IO
Public Class Form5home
    Dim currentChildForm As New Form
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim imgindex As String = "1"
    Dim url As String = ""
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim check As Boolean = False
    Public Property s As String

    Private Sub Form5home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim f As New Form8searchgame
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        Dim c2 As New SqlCommand("select * from gameinfo where name ='" + s + "'", cn)
        Dim da1 As New SqlDataAdapter(c2)
        Dim dt2 As New DataTable
        Dim stock As Integer = 0
        da1.Fill(dt2)
        For Each row As DataRow In dt2.Rows

            url = (DirectCast(row, System.Data.DataRow)("link").ToString())
            RichTextBox1.Text = (DirectCast(row, System.Data.DataRow)("gamedes").ToString())
            Label2.Text = (DirectCast(row, System.Data.DataRow)("price").ToString())
            stock = (DirectCast(row, System.Data.DataRow)("avblstock").ToString())
            Dim img() As Byte
            img = dt2.Rows(0)(2)
            Dim ms As New memorystream(img)
            PictureBox4.Image = Image.FromStream(ms)
            Dim img1() As Byte
            img1 = dt2.Rows(0)(11)
            Dim ms1 As New MemoryStream(img1)
            PictureBox1.Image = Image.FromStream(ms1)
        Next
        If stock >= 20 Then
            Label4.Text = "Available"
        ElseIf stock = 1 Then
            Label4.Text = stock.ToString + " copy left"
        ElseIf stock = 0 Then
            Label4.Text = "Unvailable"
        Else
            Label4.Text = stock.ToString + " copies left"
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form7PCdeets.Close()
        Form7PCdeets.TopLevel = False
        Form7PCdeets.FormBorderStyle = FormBorderStyle.None
        Form7PCdeets.Dock = DockStyle.Fill
        Me.body.Controls.Add(Form7PCdeets)
        body.Tag = Form7PCdeets
        Form7PCdeets.name2 = s
        Form7PCdeets.BringToFront()
        Form7PCdeets.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'MessageBox.Show(s)
        Form6GameDeets.Close()
        Form6GameDeets.TopLevel = False
        Form6GameDeets.FormBorderStyle = FormBorderStyle.None
        Form6GameDeets.Dock = DockStyle.Fill
        Me.body.Controls.Add(Form6GameDeets)
        body.Tag = Form6GameDeets
        Form6GameDeets.name1 = s
        Form6GameDeets.BringToFront()
        Form6GameDeets.Show()
    End Sub


    Public Sub OpenChildForm(ChildForm As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        ChildForm.TopLevel = False
        ChildForm.FormBorderStyle = FormBorderStyle.None
        ChildForm.Dock = DockStyle.Fill
        currentChildForm = ChildForm
        body.Controls.Add(ChildForm)
        body.Tag = ChildForm
        ChildForm.BringToFront()
        ChildForm.Show()

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result1 As DialogResult = MessageBox.Show("Add Item to Cart?", "Blizzard Pruchase Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Dim cmd As New SqlCommand("select name,price from gameinfo where name ='" + s + "'", cn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim cmd2 As New SqlCommand("select * from " + Form1.TextBox1.Text + "_mycart", cn1)
            Dim da1 As New SqlDataAdapter(cmd2)
            Dim dt1 As New DataTable
            da1.Fill(dt1)
            Dim i As Integer = 0
            For Each row As DataRow In dt1.Rows

                If dt1.Rows(i)(1) = dt.Rows(0)(0) Then
                    check = True
                End If
                i = i + 1
            Next
            If check = False Then
                Dim cmd1 As New SqlCommand("insert into " + Form1.TextBox1.Text + "_mycart(name, price)values (@nic,@add)", cn1)
                cn1.Open()
                cmd1.Parameters.AddWithValue("@nic", dt.Rows(0)(0))
                cmd1.Parameters.AddWithValue("@add", dt.Rows(0)(1))
                cmd1.ExecuteNonQuery()
                cn1.Close()
                MessageBox.Show("Item added successfully!")
            Else
                MessageBox.Show("Item limit is 1 per customer.")
            End If
        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If imgindex = "1" Then
            Dim c2 As New SqlCommand("select name, pic" + imgindex + "  from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img() As Byte
            img = dt2.Rows(0)(1)
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            imgindex = "2"

        ElseIf imgindex = "2" Then
            Dim c2 As New SqlCommand("select name, pic" + imgindex + "  from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img() As Byte
            img = dt2.Rows(0)(1)
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            imgindex = "3"

        ElseIf imgindex = "3" Then
            Dim c2 As New SqlCommand("select name, pic" + imgindex + "  from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img() As Byte
            img = dt2.Rows(0)(1)
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            imgindex = "4"
        ElseIf imgindex = "4" Then
            Dim c2 As New SqlCommand("select name, pic" + imgindex + "  from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img() As Byte
            img = dt2.Rows(0)(1)
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            imgindex = "1"
        End If



    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If imgindex = "1" Then
            Dim c2 As New SqlCommand("select name, pic" + imgindex + "  from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img() As Byte
            img = dt2.Rows(0)(1)
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            imgindex = "4"

        ElseIf imgindex = "2" Then
            Dim c2 As New SqlCommand("select name, pic" + imgindex + "  from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img() As Byte
            img = dt2.Rows(0)(1)
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            imgindex = "1"

        ElseIf imgindex = "3" Then
            Dim c2 As New SqlCommand("select name, pic" + imgindex + "  from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img() As Byte
            img = dt2.Rows(0)(1)
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            imgindex = "2"
        ElseIf imgindex = "4" Then
            Dim c2 As New SqlCommand("select name, pic" + imgindex + "  from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img() As Byte
            img = dt2.Rows(0)(1)
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
            imgindex = "3"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result1 As DialogResult = MessageBox.Show("Do you want to open the Developer's site for the virtual copy?", "Blizzard Game Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            System.Diagnostics.Process.Start(url)
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form30Rating.s = s
        Form30Rating.Show()
    End Sub
End Class