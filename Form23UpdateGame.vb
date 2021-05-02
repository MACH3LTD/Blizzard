Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class Form23UpdateGame
    Dim RdOnly As Boolean = False
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Public Property s As String


    Private Sub Form23UpdateGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        RdOnly = True
        Button1.Hide()
        Button3.Hide()
        TextBox1.BackColor = Color.LightGray
        TextBox2.BackColor = Color.LightGray
        TextBox3.BackColor = Color.LightGray
        TextBox7.BackColor = Color.LightGray
        TextBox5.BackColor = Color.LightGray
        TextBox6.BackColor = Color.LightGray
        PictureBox6.Enabled = False
        PictureBox1.Enabled = False
        PictureBox5.Enabled = False
        PictureBox7.Enabled = False
        PictureBox2.Enabled = False
        PictureBox4.Enabled = False

        RichTextBox1.BackColor = Color.LightGray
        RichTextBox2.BackColor = Color.LightGray
        RichTextBox3.BackColor = Color.LightGray
        RichTextBox1.ReadOnly = True
        RichTextBox2.ReadOnly = True
        RichTextBox3.ReadOnly = True
        Dim c2 As New SqlCommand("select * from gameinfo where name = '" + s + "'", cn)
        Dim da1 As New SqlDataAdapter(c2)
        Dim dt2 As New DataTable
        da1.Fill(dt2)
        For Each row As DataRow In dt2.Rows
            TextBox1.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())
            TextBox2.Text = (DirectCast(row, System.Data.DataRow)("dev").ToString())
            TextBox3.Text = (DirectCast(row, System.Data.DataRow)("pub").ToString())
            DateTimePicker1.Value = (DirectCast(row, System.Data.DataRow)("reldate"))
            TextBox7.Text = (DirectCast(row, System.Data.DataRow)("mode").ToString())
            TextBox5.Text = (DirectCast(row, System.Data.DataRow)("price").ToString())
            RichTextBox1.Text = (DirectCast(row, System.Data.DataRow)("gamedes").ToString())
            RichTextBox2.Text = (DirectCast(row, System.Data.DataRow)("min").ToString())
            RichTextBox3.Text = (DirectCast(row, System.Data.DataRow)("max").ToString())
            TextBox6.Text = (DirectCast(row, System.Data.DataRow)("link").ToString())
            Dim img() As Byte
            img = dt2.Rows(0)(2)
            Dim ms As New MemoryStream(img)
            PictureBox6.Image = Image.FromStream(ms)
            Dim img1() As Byte
            img1 = dt2.Rows(0)(11)
            Dim ms1 As New MemoryStream(img1)
            PictureBox1.Image = Image.FromStream(ms1)
            Dim img2() As Byte
            img2 = dt2.Rows(0)(12)
            Dim ms2 As New MemoryStream(img2)
            PictureBox5.Image = Image.FromStream(ms2)
            Dim img3() As Byte
            img3 = dt2.Rows(0)(13)
            Dim ms3 As New MemoryStream(img3)
            PictureBox2.Image = Image.FromStream(ms3)
            Dim img4() As Byte
            img4 = dt2.Rows(0)(14)
            Dim ms4 As New MemoryStream(img4)
            PictureBox4.Image = Image.FromStream(ms4)
            Dim img5() As Byte
            img5 = dt2.Rows(0)(19)
            Dim ms5 As New MemoryStream(img5)
            PictureBox7.Image = Image.FromStream(ms5)
        Next
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.Filter = "images|*.jpg;*.png;*.gif;*.bmp"
        If openfiledialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(openfiledialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.Filter = "images|*.jpg;*.png;*.gif;*.bmp"
        If openfiledialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox6.Image = Image.FromFile(openfiledialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.Filter = "images|*.jpg;*.png;*.gif;*.bmp"
        If openfiledialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox5.Image = Image.FromFile(openfiledialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.Filter = "images|*.jpg;*.png;*.gif;*.bmp"
        If openfiledialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(openfiledialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.Filter = "images|*.jpg;*.png;*.gif;*.bmp"
        If openfiledialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox4.Image = Image.FromFile(openfiledialog1.FileName)
        End If
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to go back? Data not stored will be deleted.", "Blizzard Game Details", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Form20AdminSkeleton.OpenMainPanel(New Form21GameDB)
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RdOnly = False
        PictureBox6.Enabled = True
        PictureBox1.Enabled = True
        PictureBox5.Enabled = True
        PictureBox7.Enabled = True
        PictureBox2.Enabled = True
        PictureBox4.Enabled = True
        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White
        TextBox3.BackColor = Color.White
        TextBox7.BackColor = Color.White
        TextBox5.BackColor = Color.White
        TextBox6.BackColor = Color.White

        RichTextBox1.BackColor = Color.White
        RichTextBox2.BackColor = Color.White
        RichTextBox3.BackColor = Color.White
        RichTextBox1.ReadOnly = False
        RichTextBox2.ReadOnly = False
        RichTextBox3.ReadOnly = False
        Button2.Hide()
        Button3.Show()
        Button1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox7.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or RichTextBox1.Text = "" Or RichTextBox2.Text = "" Or RichTextBox3.Text = "" Then
            MessageBox.Show("Fields Cannot Be Empty.")
        Else
            RdOnly = True
            TextBox1.BackColor = Color.LightGray
            TextBox2.BackColor = Color.LightGray
            TextBox3.BackColor = Color.LightGray
            TextBox7.BackColor = Color.LightGray
            TextBox5.BackColor = Color.LightGray
            TextBox6.BackColor = Color.LightGray

            RichTextBox1.BackColor = Color.LightGray
        RichTextBox2.BackColor = Color.LightGray
        RichTextBox3.BackColor = Color.LightGray
        Dim result1 As DialogResult = MessageBox.Show("Confirm Update?", "Blizzard Game Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
                Dim cmd As New SqlCommand("update gameinfo set name=@tit, pic0title=@pi0, dev=@de, pub=@pu, reldate=@reldat, min=@mins, max=@maxs, price=@pri, mode=@mod, pic1=@pi1, pic2=@pi2, pic3=@pi3, pic4=@pi4, gamedes=@des, link=@l, COA=@coa1 where name ='" + s + "'", cn)
                cn.Open()
            cmd.Parameters.AddWithValue("@tit", TextBox1.Text)
            cmd.Parameters.AddWithValue("@de", TextBox2.Text)
            cmd.Parameters.AddWithValue("@pu", TextBox3.Text)
            cmd.Parameters.AddWithValue("@reldat", DateTimePicker1.Value)
            cmd.Parameters.AddWithValue("@mod", TextBox7.Text)
            cmd.Parameters.AddWithValue("@pri", TextBox5.Text)
            cmd.Parameters.AddWithValue("@des", RichTextBox1.Text)
            cmd.Parameters.AddWithValue("@mins", RichTextBox2.Text)
            cmd.Parameters.AddWithValue("@maxs", RichTextBox3.Text)
            cmd.Parameters.AddWithValue("@l", TextBox6.Text)

            Dim memstr1 As New MemoryStream
            PictureBox6.Image.Save(memstr1, PictureBox6.Image.RawFormat)
            cmd.Parameters.AddWithValue("@pi0", memstr1.ToArray)
            Dim memstr2 As New MemoryStream
            PictureBox1.Image.Save(memstr2, PictureBox1.Image.RawFormat)
            cmd.Parameters.AddWithValue("@pi1", memstr2.ToArray)
            Dim memstr3 As New MemoryStream
            PictureBox5.Image.Save(memstr3, PictureBox5.Image.RawFormat)
            cmd.Parameters.AddWithValue("@pi2", memstr3.ToArray)
            Dim memstr4 As New MemoryStream
            PictureBox2.Image.Save(memstr4, PictureBox2.Image.RawFormat)
            cmd.Parameters.AddWithValue("@pi3", memstr4.ToArray)
            Dim memstr5 As New MemoryStream
            PictureBox4.Image.Save(memstr5, PictureBox4.Image.RawFormat)
                cmd.Parameters.AddWithValue("@pi4", memstr5.ToArray)
                Dim memstr6 As New MemoryStream
                PictureBox7.Image.Save(memstr6, PictureBox7.Image.RawFormat)
                cmd.Parameters.AddWithValue("@coa1", memstr6.ToArray)
                cmd.ExecuteNonQuery()

        End If
        Dim result As DialogResult = MessageBox.Show("You will be logged out and the application will be closed for the changes to be saved.", "Blizzard User Details", MessageBoxButtons.OK)
            If result = DialogResult.OK Then
                Application.Exit()
            End If
        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub RichTextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles RichTextBox1.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub RichTextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles RichTextBox2.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub RichTextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles RichTextBox3.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As DialogResult = MessageBox.Show("Do you want to cancel?", "Blizzard User Details", MessageBoxButtons.YesNo)
        If r = DialogResult.Yes Then
            RdOnly = True
            TextBox1.BackColor = Color.LightGray
            TextBox2.BackColor = Color.LightGray
            TextBox3.BackColor = Color.LightGray
            TextBox7.BackColor = Color.LightGray
            TextBox5.BackColor = Color.LightGray
            TextBox6.BackColor = Color.LightGray

            RichTextBox1.BackColor = Color.LightGray
            RichTextBox2.BackColor = Color.LightGray
            RichTextBox3.BackColor = Color.LightGray
            Dim c2 As New SqlCommand("select * from gameinfo where name ='" + s + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            For Each row As DataRow In dt2.Rows


                TextBox1.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())
                TextBox2.Text = (DirectCast(row, System.Data.DataRow)("dev").ToString())
                TextBox3.Text = (DirectCast(row, System.Data.DataRow)("pub").ToString())
                DateTimePicker1.Value = (DirectCast(row, System.Data.DataRow)("reldate"))
                TextBox7.Text = (DirectCast(row, System.Data.DataRow)("mode").ToString())
                TextBox5.Text = (DirectCast(row, System.Data.DataRow)("price").ToString())
                RichTextBox1.Text = (DirectCast(row, System.Data.DataRow)("gamedes").ToString())
                RichTextBox2.Text = (DirectCast(row, System.Data.DataRow)("min").ToString())
                RichTextBox3.Text = (DirectCast(row, System.Data.DataRow)("max").ToString())
                Dim img() As Byte
                img = dt2.Rows(0)(2)
                Dim ms As New MemoryStream(img)
                PictureBox6.Image = Image.FromStream(ms)
                Dim img1() As Byte
                img1 = dt2.Rows(0)(11)
                Dim ms1 As New MemoryStream(img1)
                PictureBox1.Image = Image.FromStream(ms1)
                Dim img2() As Byte
                img2 = dt2.Rows(0)(12)
                Dim ms2 As New MemoryStream(img2)
                PictureBox5.Image = Image.FromStream(ms2)
                Dim img3() As Byte
                img3 = dt2.Rows(0)(13)
                Dim ms3 As New MemoryStream(img3)
                PictureBox2.Image = Image.FromStream(ms3)
                Dim img4() As Byte
                img4 = dt2.Rows(0)(14)
                Dim ms4 As New MemoryStream(img4)
                PictureBox4.Image = Image.FromStream(ms4)
                Dim img5() As Byte
                img5 = dt2.Rows(0)(19)
                Dim ms5 As New MemoryStream(img5)
                PictureBox7.Image = Image.FromStream(ms5)
            Next
            Button1.Hide()
            Button3.Hide()
            Button2.Show()
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim charactersAllowed As String = ".1234567890"
        Dim theText As String = TextBox5.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = TextBox5.SelectionStart
        Dim Change As Integer
        For x As Integer = 0 To TextBox5.Text.Length - 1
            Letter = TextBox5.Text.Substring(x, 1)
            If charactersAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next
        TextBox5.Text = theText
        TextBox5.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.Filter = "images|*.jpg;*.png;*.gif;*.bmp"
        If openfiledialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox7.Image = Image.FromFile(openfiledialog1.FileName)
        End If
    End Sub
End Class