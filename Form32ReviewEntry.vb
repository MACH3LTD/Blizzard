Imports System.Data.SqlClient

Public Class Form32ReviewEntry
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Public Property rev As String
    Public Property gamename As String
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Form32ReviewEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Clear()
        TextBox1.ReadOnly = True
        TextBox1.Text = gamename
        If rev = "blizzard" Then
            TextBox1.Hide()
            Label5.Hide()
        End If
    End Sub
    Private Sub RichTextBox1_gotfocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.GotFocus
        If RichTextBox1.Text = "Enter Your Review..." Then
            RichTextBox1.Text = ""
            RichTextBox1.ForeColor = Color.Black

        End If
    End Sub
    Private Sub RichTextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.LostFocus
        If RichTextBox1.Text = "" Then
            RichTextBox1.ForeColor = Color.Silver
            RichTextBox1.Text = "Enter Your Review..."
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        Dim result As DialogResult = MessageBox.Show("Do you want to go back? Your Review will not be saved", "Blizzard Review Details", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me.Close()
            Form4progskeleton.OpenMainPanel(New Form29Review)
            Form4progskeleton.OpenSubPanel(New Form0Buttons)

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RichTextBox1.Text = "" Or RichTextBox1.Text = "Enter Your Review..." Then
            MessageBox.Show("Fields cannot be Empty.")
        ElseIf TextBox1.Text = "" And TextBox1.Visible = True Then
            MessageBox.Show("Please select Title")
        Else
            Dim result As DialogResult = MessageBox.Show("Are You Sure You Want to Submit This Review?", "Blizzard Review Details", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim cmd As New SqlCommand("insert into reviews values (@n,@t,@r)", cn)
                cn.Open()
                If TextBox1.Visible = False Then
                    cmd.Parameters.AddWithValue("@n", Form1.TextBox1.Text)
                    cmd.Parameters.AddWithValue("@t", "Blizzard")
                    cmd.Parameters.AddWithValue("@r", RichTextBox1.Text)
                Else
                    cmd.Parameters.AddWithValue("@n", Form1.TextBox1.Text)
                    cmd.Parameters.AddWithValue("@t", gamename)
                    cmd.Parameters.AddWithValue("@r", RichTextBox1.Text)
                End If

                Dim value = cmd.ExecuteScalar()
                If value > 0 Then
                    MessageBox.Show("unsuccessful!")
                Else
                    MessageBox.Show("Review sent successfully!")
                End If
                cn.Close()
            End If
        End If

    End Sub
End Class