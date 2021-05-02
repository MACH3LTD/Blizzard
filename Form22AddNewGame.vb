Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class Form22AddNewGame
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")

    Private Sub Form22AddNewGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox7.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or RichTextBox1.Text = "" Or RichTextBox2.Text = "" Or RichTextBox3.Text = "" Then
            MessageBox.Show("Fields Cannot Be Empty.")
        Else
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to add this game?", "Blizzard Game Details", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim cmd As New SqlCommand("insert into gameinfo(name, pic0title, dev, pub, reldate, min, max, price, mode, pic1, pic2, pic3, pic4, gamedes, avblstock, link, COA) values(@tit, @pi0, @de, @pu, @reldat, @mins, @maxs, @pri, @mod,  @pi1, @pi2, @pi3, @pi4, @des, '0', @l, @pi5)", cn)

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
                cmd.ExecuteNonQuery()
                Dim memstr6 As New MemoryStream
                PictureBox7.Image.Save(memstr6, PictureBox7.Image.RawFormat)
                cmd.Parameters.AddWithValue("@pi5", memstr6.ToArray)
                cmd.ExecuteNonQuery()
            End If
            MessageBox.Show("Title Added Successfully")
            Form20AdminSkeleton.OpenMainPanel(New Form22AddNewGame)
        End If
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

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.Filter = "images|*.jpg;*.png;*.gif;*.bmp"
        If openfiledialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox7.Image = Image.FromFile(openfiledialog1.FileName)
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
End Class