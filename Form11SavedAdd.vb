Imports System.Data.SqlClient
Public Class Form11SavedAdd
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Private Sub Form11SavedAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Hide()
        TextBox1.Hide()
        Button5.Hide()
        Button6.Hide()
        Button2.Hide()
        RichTextBox1.ReadOnly = True
        Dim cmd As New SqlCommand("select * from " + Form1.TextBox1.Text + "_svdadd", cn1)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            ComboBox1.Items.Add(DirectCast(row, System.Data.DataRow)("nickname").ToString())
        Next
        RichTextBox1.ForeColor = Color.Silver
        RichTextBox1.Text = "Choose a nickname..."
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form4progskeleton.OpenMainPanel(New Form9AccountDeets)
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button4.Show()
        Button2.Show()
        Dim cmd1 As New SqlCommand("select address from " + Form1.TextBox1.Text + "_svdadd where nickname ='" + ComboBox1.SelectedItem + "'", cn1)
        Dim da As New SqlDataAdapter(cmd1)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows

            RichTextBox1.Text = (DirectCast(row, System.Data.DataRow)("address").ToString())
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Show()
        ComboBox1.Hide()
        Button4.Hide()
        Button6.Show()
        Button5.Show()
        Button2.Hide()
        Button1.Hide()
        RichTextBox1.ReadOnly = False
        RichTextBox1.Text = "Enter Your Address..."
        RichTextBox1.ForeColor = Color.Black
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus


        If Button4.Visible = False And TextBox1.Text = "Enter Nick Name..." And Button3.Visible = False Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black

        End If
    End Sub
    Private Sub RichTextBox1_lostfocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.LostFocus
        If RichTextBox1.Text = "" And Button2.Visible = False Then
            RichTextBox1.ForeColor = Color.Silver
            RichTextBox1.Text = "Enter Your Address..."
        End If
    End Sub
    Private Sub RichTextBox1_gotfocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.GotFocus


        If Button4.Visible = False And RichTextBox1.Text = "Enter Your Address..." And Button2.Visible = False Then
            RichTextBox1.Text = ""
            RichTextBox1.ForeColor = Color.Black

        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus

        If TextBox1.Text = "" And Button3.Visible = False Then
            TextBox1.ForeColor = Color.Silver
            TextBox1.Text = "Enter Nick Name..."
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "Enter Nick Name..." Or RichTextBox1.Text = "Enter Your Address..." Then
            MessageBox.Show("Fields Cannot Be Empty.")

        Else
            Dim result1 As DialogResult = MessageBox.Show("Add new Addess?", "Blizzard Address Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                Dim cmd As New SqlCommand("insert into " + Form1.TextBox1.Text + "_svdadd values (@nic,@add)", cn1)
                cn1.Open()
                cmd.Parameters.AddWithValue("@nic", TextBox1.Text)
                cmd.Parameters.AddWithValue("@add", RichTextBox1.Text)
                Dim value = cmd.ExecuteScalar()
                If value > 0 Then
                    MessageBox.Show("unsuccessful!")
                Else
                    MessageBox.Show("address added successfully!")
                End If
                RichTextBox1.ForeColor = Color.LightGray
                RichTextBox1.ReadOnly = True
                cn1.Close()
                Button6.Hide()
                Button4.Show()
                TextBox1.Hide()
                ComboBox1.Show()
                Button5.Hide()
                Button2.Show()
                Button1.Show()
                Form4progskeleton.OpenMainPanel(New Form11SavedAdd)
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to cancel?", "Blizzard Address Details", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Button6.Hide()
            Button4.Show()
            Button3.Hide()
            TextBox1.Hide()
            ComboBox1.Show()
            Button5.Hide()
            Button2.Show()
            Button1.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.ForeColor = Color.Black
        Button2.Hide()
        Button5.Show()
        Button3.Show()
        ComboBox1.Hide()
        TextBox1.Show()
        RichTextBox1.ReadOnly = False
        TextBox1.Text = ComboBox1.SelectedItem
        Button1.Hide()
        Button4.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or RichTextBox1.Text = "" Then
            MessageBox.Show("Fields Cannot Be Empty.")
        Else
            Dim result1 As DialogResult = MessageBox.Show("Confirm Update?", "Blizzard Address Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then

                Dim cmd As New SqlCommand("update " + Form1.TextBox1.Text + "_svdadd set address=@add, nickname=@nic where nickname='" + ComboBox1.SelectedItem + "'", cn1)
                cn1.Open()
                cmd.Parameters.AddWithValue("@add", RichTextBox1.Text)
                cmd.Parameters.AddWithValue("@nic", TextBox1.Text)
                cmd.ExecuteNonQuery()
                cn1.Close()
            End If
            Button3.Hide()
            Button5.Hide()
            Button2.Show()
            TextBox1.Hide()
            ComboBox1.Show()
            Button1.Show()
            Button4.Show()
            RichTextBox1.ForeColor = Color.LightGray
            RichTextBox1.ReadOnly = True
            Form4progskeleton.OpenMainPanel(New Form11SavedAdd)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RichTextBox1.Text = "Choose a nickname..." Then
            MessageBox.Show("Please Choose a Nickname.")
        Else
            Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to delete this address?", "Blizzard Address Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                Dim cmd As New SqlCommand("delete from " + Form1.TextBox1.Text + "_svdadd where nickname= '" + ComboBox1.SelectedItem + "'", cn1)
                cn1.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Form4progskeleton.OpenMainPanel(New Form11SavedAdd)
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim charactersAllowed As String = " _.ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890"
        Dim theText As String = TextBox1.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = TextBox1.SelectionStart
        Dim Change As Integer
        For x As Integer = 0 To TextBox1.Text.Length - 1
            Letter = TextBox1.Text.Substring(x, 1)
            If charactersAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next
        TextBox1.Text = theText
        TextBox1.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class